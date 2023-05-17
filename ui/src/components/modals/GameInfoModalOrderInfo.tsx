import React from "react";
import { BasicGameInfoDto, GameReceiptDto, GamesClient, ReceiptClient } from "../../api";
import { Checkbox, CheckboxProps, Input, InputOnChangeData } from "semantic-ui-react";

interface GameInfoModalOrderInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalOrderInfoState {
  orderInfo?: GameReceiptDto;
  loading: boolean;
  dirty: boolean;
}

export class GameInfoModalOrderInfo extends React.Component<GameInfoModalOrderInfoProps, GameInfoModalOrderInfoState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      loading: true,
      orderInfo: undefined,
      dirty: false,
    }, this._fetchOrderInfo);
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const game = this.props.game;

    if (this.state.loading) {
      return (<div>Loading <strong>{game.gameName}</strong> order info...</div>);
    }

    if (!this.state.orderInfo) {
      return (<div>No order information available for <strong>{game.gameName}</strong>.</div>);
    }

    const receiptNumber = this.state.orderInfo.receiptNumber;
    const receiptName = this.state.orderInfo.receiptName;
    const receiptUrl = this.state.orderInfo.receiptUrl;
    const receiptDate = this.state.orderInfo.receiptDate;
    const receiptScanned = this.state.orderInfo.receiptScanned;

    return (<React.Fragment>
      <div className="order-toggle">
        <span>Receipt Scanned:</span>
        <Checkbox toggle checked={receiptScanned} onChange={this._toggleReceiptScanned} />
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
        <Input placeholder='Order Date' value={receiptDate} type="date" onChange={this._setReceiptDate} />
      </div>
    </React.Fragment>);
  }

  _fetchOrderInfo = () => {
    (new ReceiptClient()).getOrderInformation(this.props.game.receiptID).then(orderInfo => {
      this.setState({
        loading: false,
        orderInfo: orderInfo,
      });
    });
  }

  _toggleReceiptScanned = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => {
    this.setState({
      orderInfo: new GameReceiptDto({
        ...this.state.orderInfo!,
        receiptScanned: data.checked || false,
      }),
      dirty: true,
    });
  }

  _setReceiptNumber = (_: any, data: InputOnChangeData) => {
    this.setState({
      orderInfo: new GameReceiptDto({
        ...this.state.orderInfo!,
        receiptNumber: data.value
      }),
      dirty: true,
    });
  }

  _setReceiptName = (_: any, data: InputOnChangeData) => {
    this.setState({
      orderInfo: new GameReceiptDto({
        ...this.state.orderInfo!,
        receiptName: data.value
      }),
      dirty: true,
    });
  }

  _setReceiptUrl = (_: any, data: InputOnChangeData) => {
    this.setState({
      orderInfo: new GameReceiptDto({
        ...this.state.orderInfo!,
        receiptUrl: data.value
      }),
      dirty: true,
    });
  }

  _setReceiptDate = (_: any, data: InputOnChangeData) => {
    this.setState({
      orderInfo: new GameReceiptDto({
        ...this.state.orderInfo!,
        receiptDate: new Date(data.value)
      }),
      dirty: true,
    });
  }
}
