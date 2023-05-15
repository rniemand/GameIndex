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

      return (<React.Fragment>
        <div>Order info for: {game.gameName} | {orderInfo.cost}</div>
        <div onClick={this._toggleProtection}>Protection: {orderInfo.hasProtection ? 'YES' : 'NO'}</div>
        <div onClick={this._toggleReceipt}>Receipt: {orderInfo.haveReceipt ? 'YES' : 'NO'}</div>
        <div>
          <Input placeholder='Order #' value={orderInfo.orderNumber} />
        </div>
        <div>
          <Input placeholder='Receipt Location' value={receiptLocation} onChange={this._setReceiptLocation} />
          <Button disabled={!this.state.locationDirty} onClick={this._saveReceiptLocation}>Save</Button>
        </div>
      </React.Fragment>);
    }

    _fetchOrderInfo = () => {
      (new GamesClient()).getOrderInformation(this.props.game.gameID).then(orderInfo => {
        this.setState({
          loading: false,
          orderInfo: orderInfo,
          receiptLocation: orderInfo?.receiptLocation || ''
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
}