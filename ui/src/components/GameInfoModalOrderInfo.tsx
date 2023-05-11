import React from "react";
import { BasicGameInfoDto, GameOrderInfoDto, GamesClient } from "../api";

interface GameInfoModalOrderInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalOrderInfoState {
  orderInfo?: GameOrderInfoDto;
  loading: boolean;
}

export class GameInfoModalOrderInfo extends React.Component<GameInfoModalOrderInfoProps, GameInfoModalOrderInfoState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({ loading: true }, this._fetchOrderInfo);
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

        return (<div>
          Order info for: {game.gameName} | {orderInfo.cost}
        </div>);
    }

    _fetchOrderInfo = () => {
      (new GamesClient()).getOrderInformation(this.props.game.gameID).then(orderInfo => {
        this.setState({
          loading: false,
          orderInfo: orderInfo
        });
      });
    }
}