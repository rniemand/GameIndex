import React from 'react';
import './App.css';
import { GameList } from './components/GameList';
import { GamePlatformEntity } from './api';
import { GamePlatforms } from './components/GamePlatforms';
import 'semantic-ui-css/semantic.min.css'
import ISearchableGame from './models/ISearchableGame';

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
        <GameList platform={selectedPlatform} />
      </div>
    );
  }

  _platformSelected = (platform: GamePlatformEntity) => {
    this.setState({ selectedPlatform: platform });
  }
}

