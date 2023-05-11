import React from "react";
import { BasicGameInfoDto } from "../api";
import { GameListEntryImage } from "./GameListEntryImage";
import { Card } from "semantic-ui-react";

interface GameListEntryProps {
  game: BasicGameInfoDto;
}

interface GameListEntryState { }

export class GameListEntry extends React.Component<GameListEntryProps, GameListEntryState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const game = this.props.game;

    return (<Card>
      <GameListEntryImage game={game} />
      <Card.Content>
        <Card.Header>{game.gameName}</Card.Header>
      </Card.Content>
    </Card>);
  }
}
