import React from "react";
import { BasicGameInfoDto } from "../api";
import { GameImage } from "./GameImage";

interface ComponentProps {
  games: BasicGameInfoDto[];
}

interface MyState {
}

export class TestComponent extends React.Component<ComponentProps, MyState> {

  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const games = this.props.games;

    return (<div>
      {games.map(game => {
        return(<GameImage key={game.gameID} game={game} />);
      })}
    </div>);
  }
}