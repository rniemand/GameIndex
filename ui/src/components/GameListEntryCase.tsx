import React from "react";
import { BasicGameInfoDto } from "../api";

interface GameListEntryCaseProps {
  game: BasicGameInfoDto;
}

interface GameListEntryCaseState { }

export class GameListEntryCase extends React.Component<GameListEntryCaseProps, GameListEntryCaseState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const game = this.props.game;
    
    return (<span className="case">{game.gameCase}</span>);
  }
}
