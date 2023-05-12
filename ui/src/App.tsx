import React from 'react';
import './App.css';
import { GameList } from './components/GameList';
import { GamePlatformEntity, GamesClient } from './api';
import { GamePlatforms } from './components/GamePlatforms';
import 'semantic-ui-css/semantic.min.css'
import ISearchableGame from './models/ISearchableGame';

const gamesClient = new GamesClient();

interface AppProps { }

interface AppState {
  selectedPlatform?: GamePlatformEntity;
  games: ISearchableGame[];
}

export default class App extends React.Component<AppProps, AppState> {
  componentDidMount(): void {
    this.setState({
      selectedPlatform: undefined
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const selectedPlatform = this.state.selectedPlatform;
    const games = this.state.games || [];

    return (
      <div className="App test">
        <GamePlatforms onPlatformSelected={this._platformSelected} selectedPlatform={selectedPlatform} />
        <GameList games={games} />
      </div>
    );
  }

  _platformSelected = (platform: GamePlatformEntity) => {
    this.setState({ selectedPlatform: platform }, this._loadPlatformGames);
  }

  _loadPlatformGames = () => {
    const selectedPlatform = this.state.selectedPlatform;
    if (!selectedPlatform) {
      this.setState({ games: [] });
      return;
    }

    gamesClient.getAllGames(selectedPlatform.platformID).then(_games => {
      this.setState({
        games: _games.map(game => ({
          game: game,
          searchString: `${game.gameCase}|${game.gameName}|${game.locationName}|${game.seller}|${game.orderNumber}`.toLowerCase()
        }))
      });
    });
  }
}

