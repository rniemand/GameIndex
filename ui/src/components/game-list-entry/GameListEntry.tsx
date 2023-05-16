import React from "react";
import { BasicGameInfoDto } from "../../api";
import { GameListEntryImage } from "./GameListEntryImage";
import { Card, Icon } from "semantic-ui-react";
import { GameListEntryCase } from "./GameListEntryCase";
import { GameInfoModal } from "../../modals/GameInfoModal";
import { SetConsoleModal } from "../../modals/SetConsoleModal";

interface GameListEntryProps {
  game: BasicGameInfoDto;
  onGameLocationChange: () => void;
  gamesInfoModalClosed: () => void;
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
        <GameInfoModal game={game} onModalClosed={this.props.gamesInfoModalClosed} />
      </Card.Content>
      <Card.Content extra>
        <div>
          {!game.gameSold && <GameListEntryCase game={game} />}
          {!game.gameSold && <span className="spacer">|</span>}
          <SetConsoleModal game={game} onGameLocationChange={this.props.onGameLocationChange} />
        </div>
        <div>
          {game.haveReceipt && <Icon name='list alternate outline' />}
          {game.cost > 0 && <span>${game.cost}</span>}
        </div>
      </Card.Content>
    </Card>);
  }
}
