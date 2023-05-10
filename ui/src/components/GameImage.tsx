import React from "react";
import { BasicGameInfoDto } from "../api";

interface ComponentProps {
  game: BasicGameInfoDto;
}

export class GameImage extends React.Component<ComponentProps> {

  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const game = this.props.game;
    const imgUrl = `/Image/game/${game.platformName}/${game.gameID}`;
    return (<img src={imgUrl} width={100} />);
  }
}
