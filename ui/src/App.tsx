import React from 'react';
import './App.css';
import { TestComponent } from './components/Test';
import { GameImage } from './components/GameImage';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <TestComponent />
        <GameImage />
      </header>
    </div>
  );
}

export default App;
