import React from "react";
import { Card, Container, SemanticWIDTHSNUMBER } from "semantic-ui-react";
import { GameListEntry } from "./game-list-entry/GameListEntry";
import { GameListControls } from "./game-list-entry/GameListControls";
import { storageHelper } from "../helpers/StorageHelper";
import ISearchableGame from "../models/ISearchableGame";
import { BasicGameInfoDto } from "../api";

interface GamesListProps {
  games: ISearchableGame[];
}

interface GamesListState {
  itemsPerPage: number;
  searchValue: string;
  counter: number;
}

export class GameList extends React.Component<GamesListProps, GamesListState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      itemsPerPage: storageHelper.getNumber('app.items.pp', 3),
      searchValue: '',
      counter: 0
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const games = this._getFilteredGames();
    const itemsPerPage = this.state.itemsPerPage || 3;

    return (<React.Fragment>
      <GameListControls itemsPerPage={itemsPerPage} onSetItemsPerPage={this._setItemsPerPage} onSearchChanged={this._onSearchChanged} />
      <br style={{ marginBottom: '6px' }} />
      <Container className="game-list">
        {games.length === 0 && <p className="center">No games found.</p>}
        <Card.Group itemsPerRow={itemsPerPage as SemanticWIDTHSNUMBER}>
          {games.map(game => {
            return (<GameListEntry key={game.gameID} game={game} onGameLocationChange={this._onGameLocationChange} />);
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

  _onGameLocationChange = (game: BasicGameInfoDto) => {
    if(game.locationName.toLowerCase() == 'home') return;

    const homeLocation = this.props.games.reduce((pv: BasicGameInfoDto | null, cv) => {
      if(pv) return pv;
      if(cv.game.locationName.toLowerCase() === 'home') return cv.game;
      return null;
    }, null);

    if(!homeLocation) return;

    this.props.games
      .filter(x => x.game.locationID === game.locationID && x.game.gameID !== game.gameID)
      .forEach(entry => {
        entry.game.locationID = homeLocation.locationID;
        entry.game.locationName = homeLocation.locationName;
      });

    this.props.games.forEach(e => {
      const game = e.game;
      e.searchString = `${game.gameCase}|${game.gameName}|${game.locationName}|${game.seller}|${game.orderNumber}`.toLowerCase();
    });

    this.setState({
      counter: this.state.counter+1
    });
  }
}
