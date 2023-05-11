import React from 'react';
import './App.css';
import { TestComponent } from './components/Test';
import { BasicGameInfoDto } from './api';
import { GamePlatforms } from './components/GamePlatforms';

function App(props: { games: BasicGameInfoDto[] }) {
  return (
    <div className="App">
      <header className="App-header">
        <GamePlatforms />
        <TestComponent games={props.games} />
      </header>
    </div>
  );
}

export default App;
