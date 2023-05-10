import React from 'react';
import './App.css';
import { TestComponent } from './components/Test';
import { BasicGameInfoDto } from './api';

function App(props: { games: BasicGameInfoDto[] }) {
  return (
    <div className="App">
      <header className="App-header">
        <TestComponent games={props.games} />
      </header>
    </div>
  );
}

export default App;
