import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BasicGameInfoDto, GamesClient } from './api';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const gamesClient = new GamesClient();
let games: BasicGameInfoDto[] = [];

gamesClient.getAllGames(1).then(_games => {
  games = _games;
  console.log('got games', games);

  root.render(
    <React.StrictMode>
      <App games={games} />
    </React.StrictMode>
  );
});

// root.render(
//   <React.StrictMode>
//     <App games={games} />
//   </React.StrictMode>
// );
