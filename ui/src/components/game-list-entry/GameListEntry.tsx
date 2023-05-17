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
    const classes = ['game-list-entry'];
    if (game.gameSold) classes.push('sold');

    return (<Card className={classes.join(' ')}>
      <GameListEntryImage game={game} />
      {game.gamePrice > 0 && <div className="game-price">${game.gamePrice}</div>}
      <Card.Content>
        <Card.Header>{game.gameName}</Card.Header>
      </Card.Content>
      <Card.Content extra>
        <div>
          <GameInfoModal game={game} onModalClosed={this.props.gamesInfoModalClosed} />
          {game.haveReceipt && <Icon name='list alternate outline' title='Has Receipt' />}
          {game.receiptScanned && <Icon name='picture' title='Receipt Scanned' />}
          {game.hasProtection && <Icon name='copy outline' title='Has Protection' />}
          {game.gameSold && <Icon name='dollar sign' title='Sold' />}
          {game.hasGameBox && <Icon name='box' title='Has Cover' />}
        </div>
      </Card.Content>
      {!game.gameSold && <Card.Content extra>
        <GameListEntryCase game={game} />
        <span className="spacer">|</span>
        <SetConsoleModal game={game} onGameLocationChange={this.props.onGameLocationChange} />
      </Card.Content>}
    </Card>);
  }
}
