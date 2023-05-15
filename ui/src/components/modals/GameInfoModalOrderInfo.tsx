import React from "react";
import { BasicGameInfoDto, GameOrderInfoDto, GamesClient } from "../../api";
import { Button, Input, InputOnChangeData } from "semantic-ui-react";

interface GameInfoModalOrderInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalOrderInfoState {
  orderInfo?: GameOrderInfoDto;
  loading: boolean;
  receiptLocation: string;
  locationDirty: boolean;
  cost: number;
  costDirty: boolean;
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
          cost: 0,
          costDirty: false,
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
      const price = this.state.cost;
      const orderUrl = this.state.orderUrl;
      const orderNumber = this.state.orderNumber;
      const orderDate = this.state.orderDate;

      return (<React.Fragment>
        <div>Order info for: {game.gameName}</div>
        <div onClick={this._toggleProtection}>Protection: {orderInfo.hasProtection ? 'YES' : 'NO'}</div>
        <div onClick={this._toggleReceipt}>Receipt: {orderInfo.haveReceipt ? 'YES' : 'NO'}</div>
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
          <Input placeholder='Price' type="number" value={price} onChange={this._setGamePrice} />
          &nbsp;
          <Button disabled={!this.state.costDirty} onClick={this._saveCostChanges}>Save</Button>
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
          receiptLocation: orderInfo?.receiptLocation || '',
          locationDirty: false,
          cost: orderInfo?.cost || 0,
          costDirty: false,
          orderNumber: orderInfo?.orderNumber || '',
          orderNumberDirty: false,
          orderUrl: orderInfo?.orderUrl || '',
          orderUrlDirty: false,
          orderDate: orderInfo?.purchaseDate?.toISOString().split('T')[0] || '',
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

    _toggleReceipt = () => {
      new GamesClient().toggleGameReceipt(this.props.game.gameID).then(orderInfo => {
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

    _setGamePrice = (_: any, data: InputOnChangeData) => {
      this.setState({
        cost: parseFloat(data.value),
        costDirty: true,
      });
    }

    _saveCostChanges = () => {
      new GamesClient().setGamePrice(this.props.game.gameID, this.state.cost).then(orderInfo => {
        this.setState({
          orderInfo: orderInfo || undefined,
          costDirty: false,
        });
      });
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