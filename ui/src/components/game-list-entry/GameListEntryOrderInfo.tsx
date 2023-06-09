import React from "react";
import { BasicGameInfoDto } from "../../api";
import { Icon } from "semantic-ui-react";

interface GameListEntryOrderInfoProps {
  game: BasicGameInfoDto;
}

interface GameListEntryOrderInfoState { }

export class GameListEntryOrderInfo extends React.Component<GameListEntryOrderInfoProps, GameListEntryOrderInfoState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const game = this.props.game;
    if((game.receiptNumber?.length ?? 0) === 0) return null;

    return (<div className="order-info">
      {game.store}
      {game.hasProtection && <Icon name='checkmark' color="green" className="protection" />}
    </div>);
  }
}
