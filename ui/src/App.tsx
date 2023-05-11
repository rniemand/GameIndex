import React from 'react';
import './App.css';
import { TestComponent } from './components/Test';
import { BasicGameInfoDto, GamePlatformEntity } from './api';
import { GamePlatforms } from './components/GamePlatforms';
import 'semantic-ui-css/semantic.min.css'

interface AppProps {
  games: BasicGameInfoDto[];
}

interface AppState {
  selectedPlatform?: GamePlatformEntity;
}

export default class App extends React.Component<AppProps, AppState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      selectedPlatform: undefined
    });
  }

  render(): React.ReactNode {
    if(!this.state) return null;
    const selectedPlatform = this.state.selectedPlatform;

    const onPlatformSelectedHandler = (platform: GamePlatformEntity) => {
      this.setState({ selectedPlatform: platform });
    };

    return (
      <div className="App">
        <header className="App-header">
          <GamePlatforms onPlatformSelected={onPlatformSelectedHandler} selectedPlatform={selectedPlatform} />
          <TestComponent games={this.props.games} />
        </header>
      </div>
    );
  }
}

// function App(props: { games: BasicGameInfoDto[] }) {
  
// }

// export default App;
