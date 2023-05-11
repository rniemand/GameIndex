import React from "react";
import { BasicGameInfoDto } from "../api";
import { Card, Container, SemanticWIDTHSNUMBER } from "semantic-ui-react";
import { GameListEntry } from "./GameListEntry";
import { GameListControls } from "./GameListControls";

interface GamesListProps {
  games: BasicGameInfoDto[];
}

interface GamesListState {
  itemsPerPage: number;
}

export class GameList extends React.Component<GamesListProps, GamesListState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({ itemsPerPage: 3 });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const games = this.props.games;
    const itemsPerPage = this.state.itemsPerPage || 3;

    if (games.length === 0) {
      return (<Container>
        <h1>No Games</h1>
        <p>There are no games for the selected category</p>
      </Container>);
    }

    return (<React.Fragment>
      <GameListControls itemsPerPage={itemsPerPage} onSetItemsPerPage={this._setItemsPerPage} />
      <br style={{ marginBottom: '6px' }} />
      <Container>
        <Card.Group itemsPerRow={itemsPerPage as SemanticWIDTHSNUMBER}>
          {games.map(game => {
            return (<GameListEntry key={game.gameID} game={game} />);
          })}
        </Card.Group>
      </Container>
    </React.Fragment>);
  }

  _setItemsPerPage = (count: number) => {
    this.setState({ itemsPerPage: count });
  }
}
