import React from "react";
import { Card, Container, SemanticWIDTHSNUMBER } from "semantic-ui-react";
import { GameListEntry } from "./GameListEntry";
import { GameListControls } from "./GameListControls";
import { storageHelper } from "../helpers/StorageHelper";
import ISearchableGame from "../modals/ISearchableGame";
import { BasicGameInfoDto } from "../api";

interface GamesListProps {
  games: ISearchableGame[];
}

interface GamesListState {
  itemsPerPage: number;
  searchValue: string;
}

export class GameList extends React.Component<GamesListProps, GamesListState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      itemsPerPage: storageHelper.getNumber('app.items.pp', 3),
      searchValue: ''
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const games = this._getFilteredGames();
    const itemsPerPage = this.state.itemsPerPage || 3;

    if (games.length === 0) {
      return (<Container>
        <h1>No Games</h1>
        <p>There are no games for the selected category</p>
      </Container>);
    }

    return (<React.Fragment>
      <GameListControls itemsPerPage={itemsPerPage} onSetItemsPerPage={this._setItemsPerPage} onSearchChanged={this._onSearchChanged} />
      <br style={{ marginBottom: '6px' }} />
      <Container className="game-list">
        <Card.Group itemsPerRow={itemsPerPage as SemanticWIDTHSNUMBER}>
          {games.map(game => {
            return (<GameListEntry key={game.gameID} game={game} />);
          })}
        </Card.Group>
      </Container>
    </React.Fragment>);
  }

  _setItemsPerPage = (count: number) => {
    storageHelper.setNumber('app.items.pp', count);
    this.setState({ itemsPerPage: count });
  }

  _getFilteredGames = () => {
    const searchTerm = this.state.searchValue || '';
    const runSearch = searchTerm.length > 0;
    return this.props.games.reduce((pv: BasicGameInfoDto[], cv) => {
      if(runSearch && cv.searchString.indexOf(searchTerm) === -1) return pv;
      pv.push(cv.game);
      return pv;
    }, []);
  }

  _onSearchChanged = (value: string) => {
    this.setState({ searchValue: value });
  }
}
