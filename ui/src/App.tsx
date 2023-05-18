import React from 'react';
import './App.css';
import { GameList } from './components/GameList';
import { GamePlatforms } from './components/GamePlatforms';
import 'semantic-ui-css/semantic.min.css'
import { PlatformDto } from './api';
import { SettingsPage } from './components/SettingsPage';
import { PlatformsPage } from './components/PlatformsPage';

interface AppProps { }

interface AppState {
  selectedPlatform?: PlatformDto;
  page: string | undefined;
}

export default class App extends React.Component<AppProps, AppState> {
  componentDidMount(): void {
    this.setState({
      selectedPlatform: undefined,
      page: undefined,
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const selectedPlatform = this.state.selectedPlatform;
    const page = this.state.page || '';

    return (
      <div className="App test">
        <GamePlatforms onPlatformSelected={this._platformSelected} selectedPlatform={selectedPlatform} onPageSelected={this._pageSelected} selectedPage={page} />
        {selectedPlatform && <GameList platform={selectedPlatform} />}
        {page == 'settings' && <SettingsPage onPageSelected={this._pageSelected} />}
        {page == 'platforms' && <PlatformsPage />}
      </div>
    );
  }

  _platformSelected = (platform: PlatformDto) => {
    this.setState({
      selectedPlatform: platform,
      page: undefined,
    });
  }

  _pageSelected = (page: string) => {
    this.setState({
      selectedPlatform: undefined,
      page: page,
    });
  }
}

