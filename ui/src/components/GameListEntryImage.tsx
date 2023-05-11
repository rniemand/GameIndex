import React from "react";
import { BasicGameInfoDto } from "../api";
import { Image } from "semantic-ui-react";

interface ComponentProps {
  game: BasicGameInfoDto;
}

export class GameListEntryImage extends React.Component<ComponentProps> {

  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const game = this.props.game;
    const imgUrl = `/Image/game/${game.platformName}/${game.gameID}`;
    return (<Image src={imgUrl} wrapped ui={false} />);
  }
}
