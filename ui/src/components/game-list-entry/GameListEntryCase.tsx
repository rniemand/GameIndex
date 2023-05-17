import React from "react";
import { BasicGameInfoDto } from "../../api";

interface GameListEntryCaseProps {
  game: BasicGameInfoDto;
}

interface GameListEntryCaseState { }

export class GameListEntryCase extends React.Component<GameListEntryCaseProps, GameListEntryCaseState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    return (<span className="case">{this.props.game.gameCaseLocation || 'N/A'}</span>);
  }
}
