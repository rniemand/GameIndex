import React from "react";
import { BasicGameInfoDto, GameReceiptDto, GamesClient } from "../../api";
import { Button, Checkbox, Input, InputOnChangeData } from "semantic-ui-react";

interface GameInfoModalOrderInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalOrderInfoState {
  orderInfo?: GameReceiptDto;
  loading: boolean;
  receiptLocation: string;
  locationDirty: boolean;
  orderUrl: string;
  orderUrlDirty: boolean;
  orderNumber: string;
  orderNumberDirty: boolean;
  orderDate?: string;
  orderDateDirty: boolean;
}

export class GameInfoModalOrderInfo extends React.Component<GameInfoModalOrderInfoProps, GameInfoModalOrderInfoState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({ 
          loading: true,
          receiptLocation: '',
          locationDirty: false,
          orderUrl: '',
          orderUrlDirty: false,
          orderNumber: '',
          orderNumberDirty: false,
          orderDate: '',
          orderDateDirty: false,
        }, this._fetchOrderInfo);
    }

    render(): React.ReactNode {
      if(!this.state) return null;
      const game = this.props.game;

      if(this.state.loading) {
        return(<div>Loading <strong>{game.gameName}</strong> order info...</div>);
      }

      const orderInfo = this.state.orderInfo;
      if(!orderInfo) {
        return(<div>No order information available for <strong>{game.gameName}</strong>.</div>);
      }

      const receiptLocation = this.state.receiptLocation;
      const orderUrl = this.state.orderUrl;
      const orderNumber = this.state.orderNumber;
      const orderDate = this.state.orderDate;

      return (<React.Fragment>
        <div className="order-toggle">
          <span>Receipt Scanned:</span> <Checkbox toggle checked={orderInfo.receiptScanned} onChange={this._toggleReceiptScanned} />
        </div>
        <div>
          <Input placeholder='Order #' value={orderNumber} onChange={this._setOrderNumber} />
          &nbsp;
          <Button disabled={!this.state.orderNumberDirty} onClick={this._saveOrderNumber}>Save</Button>
        </div>
        <div>
          <Input placeholder='Receipt Location' value={receiptLocation} onChange={this._setReceiptLocation} />
          &nbsp;
          <Button disabled={!this.state.locationDirty} onClick={this._saveReceiptLocation}>Save</Button>
        </div>
        <div>
          <Input placeholder='Order URL' value={orderUrl} onChange={this._setOrderUrl} />
          &nbsp;
          <Button disabled={!this.state.orderUrlDirty} onClick={this._saveOrderUrlChanges}>Save</Button>
        </div>
        <div>
          <Input placeholder='Order Date' value={orderDate} type="date" onChange={this._setOrderDate} />
          &nbsp;
          <Button disabled={!this.state.orderDateDirty} onClick={this._saveOrderDate}>Save</Button>
        </div>
      </React.Fragment>);
    }

    _fetchOrderInfo = () => {
      (new GamesClient()).getOrderInformation(this.props.game.gameID).then(orderInfo => {
        this.setState({
          loading: false,
          orderInfo: orderInfo,
          receiptLocation: orderInfo?.receiptName || '',
          locationDirty: false,
          orderNumber: orderInfo?.receiptNumber || '',
          orderNumberDirty: false,
          orderUrl: orderInfo?.receiptUrl || '',
          orderUrlDirty: false,
          orderDate: orderInfo?.receiptDate?.toISOString().split('T')[0] || '',
          orderDateDirty: false,
        });
      });
    }

    _toggleProtection = () => {
      new GamesClient().toggleGameProtection(this.props.game.gameID).then(orderInfo => {
        this.setState({
          orderInfo: orderInfo || undefined,
        });
      })
    }

    _toggleReceiptScanned = () => {
      new GamesClient().toggleReceiptScanned(this.props.game.gameID).then(orderInfo => {
        this.setState({
          orderInfo: orderInfo || undefined,
        });
      })
    }

    _setReceiptLocation = (_: any, data: InputOnChangeData) => {
      this.setState({
        receiptLocation: data.value,
        locationDirty: true,
      });
    }

    _saveReceiptLocation = () => {
        new GamesClient().setReceiptLocation(this.props.game.gameID, this.state.receiptLocation).then(orderInfo => {
          this.setState({
            orderInfo: orderInfo || undefined,
            locationDirty: false,
          });
        })
    }
    
    _setOrderUrl = (_: any, data: InputOnChangeData) => {
      this.setState({
        orderUrl: data.value,
        orderUrlDirty: true,
      });
    }

    _saveOrderUrlChanges = () => {
      new GamesClient().setGameOrderUrl(this.props.game.gameID, this.state.orderUrl).then(orderInfo => {
        this.setState({
          orderInfo: orderInfo || undefined,
          orderUrlDirty: false,
        });
      });
    }

    _setOrderNumber = (_: any, data: InputOnChangeData) => {
      this.setState({
        orderNumber: data.value,
        orderNumberDirty: true,
      });
    }

    _saveOrderNumber = () => {
      new GamesClient().setGameOrderNumber(this.props.game.gameID, this.state.orderNumber).then(orderInfo => {
        this.setState({
          orderInfo: orderInfo || undefined,
          orderNumberDirty: false,
        });
      });
    }

    _setOrderDate = (_: any, data: InputOnChangeData) => {
      this.setState({
        orderDate: data.value,
        orderDateDirty: true,
      });
    }

    _saveOrderDate = () => {
      new GamesClient().setOrderDate(this.props.game.gameID, this.state.orderDate || '').then(orderInfo => {
        this.setState({
          orderInfo: orderInfo || undefined,
          orderDateDirty: false,
        });
      });
    }
}
