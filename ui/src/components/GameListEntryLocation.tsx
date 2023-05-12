import React from "react";
import { BasicGameInfoDto } from "../api";

interface GameListEntryLocationProps {
  game: BasicGameInfoDto;
}

interface GameListEntryLocationState { }

export class GameListEntryLocation extends React.Component<GameListEntryLocationProps, GameListEntryLocationState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const game = this.props.game;

    if(game.gameSold) return(<span className="location sold">Sold</span>);
    return (<span className="location">{game.locationName}</span>);
  }
}
