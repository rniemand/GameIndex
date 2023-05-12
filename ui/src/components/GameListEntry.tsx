import React from "react";
import { BasicGameInfoDto } from "../api";
import { GameListEntryImage } from "./GameListEntryImage";
import { Card } from "semantic-ui-react";
import { GameListEntryCase } from "./GameListEntryCase";
import { GameListEntryLocation } from "./GameListEntryLocation";
import { GameListEntryOrderInfo } from "./GameListEntryOrderInfo";
import { GameInfoModal } from "./GameInfoModal";

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
    const classes= ['game-list-entry'];
    if(game.gameSold) classes.push('sold');

    return (<Card className={classes.join(' ')}>
      <GameListEntryImage game={game} />
      <Card.Content>
        <Card.Header>{game.gameName}</Card.Header>
      </Card.Content>
      <Card.Content extra>
        <GameInfoModal game={game} />
      </Card.Content>
      <Card.Content extra>
        {/* <GameListEntryOrderInfo game={game} /> */}
        <div>
          {!game.gameSold && <GameListEntryCase game={game} />}
          {!game.gameSold && <span className="spacer">|</span>}
          <GameListEntryLocation game={game} />
        </div>
      </Card.Content>
    </Card>);
  }
}
