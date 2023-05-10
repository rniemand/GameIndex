import React from "react";
import { GamesClient } from "../api";


export class TestComponent extends React.Component {
  gamesClient: GamesClient;

  constructor(props: any) {
    super(props);

    this.gamesClient = new GamesClient();
  }


  render(): React.ReactNode {
    this.gamesClient.getAllGames().then(games => {
      console.log(games);
    });

    return (<div>Hello</div>);
  }
}