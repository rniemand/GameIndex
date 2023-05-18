import React from "react";
import { BasicGameInfoDto, ReceiptClient, ReceiptDto } from "../../api";
import { Button, Checkbox, CheckboxProps, Input, InputOnChangeData } from "semantic-ui-react";
import { FindReceiptModal } from "../../modals/FindReceiptModal";

interface GameInfoModalOrderInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalOrderInfoState {
  receipt?: ReceiptDto;
  loading: boolean;
  dirty: boolean;
  saving: boolean;
  receiptDate: string;
}

export class GameInfoModalOrderInfo extends React.Component<GameInfoModalOrderInfoProps, GameInfoModalOrderInfoState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({ loading: true, receipt: undefined, dirty: false, saving: false, receiptDate: '' }, this._fetchReceipt);
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const game = this.props.game;

    if (this.state.loading) {
      return (<div>Loading <strong>{game.gameName}</strong> order info...</div>);
    }

    if (!this.state.receipt) {
      return (<React.Fragment>
        <div>No order information available for <strong>{game.gameName}</strong>.</div>
        <div><Button content='Add Receipt' onClick={this._addReceipt} /></div>
        <div><FindReceiptModal onReceiptSelected={this._onReceiptSelected} /></div>
      </React.Fragment>);
    }

    const receiptNumber = this.state.receipt.receiptNumber;
    const receiptName = this.state.receipt.receiptName;
    const receiptUrl = this.state.receipt.receiptUrl;
    const receiptDate = this.state.receiptDate;
    const receiptScanned = this.state.receipt.receiptScanned;
    const store = this.state.receipt.store;
    const dirty = this.state.dirty;
    const saving = this.state.saving;

    return (<React.Fragment>
      <div className="order-toggle">
        <span>Receipt Scanned:</span>
        <Checkbox toggle checked={receiptScanned} onChange={this._toggleReceiptScanned} />
      </div>
      <div>
        <Input placeholder='Store' value={store} onChange={this._setStoreName} />
      </div>
      <div>
        <Input placeholder='Order #' value={receiptNumber} onChange={this._setReceiptNumber} />
      </div>
      <div>
        <Input placeholder='Receipt Name' value={receiptName} onChange={this._setReceiptName} />
      </div>
      <div>
        <Input placeholder='Order URL' value={receiptUrl} onChange={this._setReceiptUrl} />
      </div>
      <div>
        <Input placeholder='Order Date' value={receiptDate} type="string" onChange={this._setReceiptDate} />
      </div>
      <div>
        <Button content='Save Changes' disabled={!dirty && !saving} onClick={this._saveReceipt} />
      </div>
    </React.Fragment>);
  }

  _addReceipt = () => {
    new ReceiptClient().addReceipt(this.props.game.gameID).then(receipt => {
      this.setState({
        loading: false,
        receipt: receipt,
      });
    });
  }

  _saveReceipt = () => {
    if (!this.state.receipt) return;
    this.setState({ saving: true }, () => {
      new ReceiptClient().updateReceipt(this.state.receipt!).then(receipt => {
        this.setState({
          saving: false,
          dirty: false,
          receipt: receipt,
        });
      });
    })
  }

  _fetchReceipt = () => {
    (new ReceiptClient()).getOrderInformation(this.props.game.receiptID).then(receipt => {
      this.setState({
        loading: false,
        receipt: receipt,
      });
    });
  }

  _toggleReceiptScanned = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => {
    this.setState({
      receipt: new ReceiptDto({
        ...this.state.receipt!,
        receiptScanned: data.checked || false,
      }),
      dirty: true,
    });
  }

  _setReceiptNumber = (_: any, data: InputOnChangeData) => {
    this.setState({
      receipt: new ReceiptDto({
        ...this.state.receipt!,
        receiptNumber: data.value
      }),
      dirty: true,
    });
  }

  _setStoreName = (_: any, data: InputOnChangeData) => {
    this.setState({
      receipt: new ReceiptDto({
        ...this.state.receipt!,
        store: data.value
      }),
      dirty: true,
    });
  }

  _setReceiptName = (_: any, data: InputOnChangeData) => {
    this.setState({
      receipt: new ReceiptDto({
        ...this.state.receipt!,
        receiptName: data.value
      }),
      dirty: true,
    });
  }

  _setReceiptUrl = (_: any, data: InputOnChangeData) => {
    this.setState({
      receipt: new ReceiptDto({
        ...this.state.receipt!,
        receiptUrl: data.value
      }),
      dirty: true,
    });
  }

  _setReceiptDate = (_: any, data: InputOnChangeData) => {
    this.setState({ receiptDate: data.value }, () => {
      if (data.value.length < 10) return;
      const dp = data.value.split('-');
      this.setState({
        receipt: new ReceiptDto({
          ...this.state.receipt!,
          receiptDate: new Date(parseInt(dp[0]), parseInt(dp[1]), parseInt(dp[2]))
        }),
        dirty: true,
      });
    });
  }

  _onReceiptSelected = (receipt: ReceiptDto) => {
    if (!this.props.game || !receipt) return;
    const gameID = this.props.game.gameID;
    const receiptID = receipt.receiptID;
    this.setState({ saving: true }, () => {
      new ReceiptClient().associateReceiptToGame(gameID, receiptID).then(receipt => {
        this.setState({
          loading: false,
          saving: false,
          receipt: receipt,
          receiptDate: receipt?.receiptDate ? receipt.receiptDate.toISOString().split('T')[0] : ''
        });
      });
    });
  }
}
