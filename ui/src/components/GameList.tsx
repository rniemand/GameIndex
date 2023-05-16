import React from "react";
import { Card, Container, SemanticWIDTHSNUMBER } from "semantic-ui-react";
import { GameListEntry } from "./game-list-entry/GameListEntry";
import { GameListControls } from "./game-list-entry/GameListControls";
import { storageHelper } from "../helpers/StorageHelper";
import { BasicGameInfoDto, GamePlatformEntity, GamesClient } from "../api";
import ISearchableGame from "../models/ISearchableGame";

interface GamesListProps {
  platform?: GamePlatformEntity;
}

interface GamesListState {
  itemsPerPage: number;
  searchValue: string;
  counter: number;
  loading: boolean;
  games: ISearchableGame[];
  platform?: GamePlatformEntity;
}

export class GameList extends React.Component<GamesListProps, GamesListState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      itemsPerPage: storageHelper.getNumber('app.items.pp', 3),
      searchValue: '',
      counter: 0,
      loading: true,
      platform: undefined,
    }, this._refreshGames);
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    
    this._refreshGames();
    if(!this.props.platform) return(<div>You need to select a platform.</div>);
    if(this.state.loading) return(<div>Fetching Games.</div>);

    const games = this._getFilteredGames();
    const itemsPerPage = this.state.itemsPerPage || 3;

    return (<React.Fragment>
      <GameListControls itemsPerPage={itemsPerPage} onSetItemsPerPage={this._setItemsPerPage} onSearchChanged={this._onSearchChanged} />
      <br style={{ marginBottom: '6px' }} />
      <Container className="game-list">
        {games.length === 0 && <p className="center">No games found.</p>}
        <Card.Group itemsPerRow={itemsPerPage as SemanticWIDTHSNUMBER}>
          {games.map(game => {
            return (<GameListEntry key={game.gameID} game={game} onModalClosed={this._onModalClosed} />);
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
    return this.state.games.reduce((pv: BasicGameInfoDto[], cv) => {
      if(runSearch && cv.searchString.indexOf(searchTerm) === -1) return pv;
      pv.push(cv.game);
      return pv;
    }, []);
  }

  _onSearchChanged = (value: string) => {
    this.setState({ searchValue: value });
  }

  _refreshGames = () => {
    if(!this.props.platform) return;
    if(this.state.platform === this.props.platform) return;

    new GamesClient().getAllGames(this.props.platform.platformID).then(games => {
      this.setState({
        loading: false,
        games: (games || []).map(game => ({
          game: game,
          searchString: `${game.gameCase}|${game.gameName}|${game.locationName}|${game.seller}|${game.orderNumber}`.toLowerCase()
        })),
        platform: this.props.platform,
      })
    });
  }

  _onModalClosed = () => {
    this.setState({ loading: true, }, this._refreshGames);
  }
}
