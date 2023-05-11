import React from "react";
import { BasicGameInfoDto } from "../api";
import { GameListEntryImage } from "./GameListEntryImage";
import { Card } from "semantic-ui-react";
import { GameListEntryCase } from "./GameListEntryCase";
import { GameListEntryLocation } from "./GameListEntryLocation";
import { GameListEntryOrderInfo } from "./GameListEntryOrderInfo";

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

    return (<Card className="game-list-entry">
      <GameListEntryImage game={game} />
      <Card.Content>
        <Card.Header>{game.gameName}</Card.Header>
      </Card.Content>
      <Card.Content extra>
        <GameListEntryOrderInfo game={game} />
        <div>
          <GameListEntryCase game={game} />
          <span className="spacer">|</span>
          <GameListEntryLocation game={game} />
        </div>
      </Card.Content>
    </Card>);
  }
}
