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
    
    return (<span className="location">{game.locationName}</span>);
  }
}
