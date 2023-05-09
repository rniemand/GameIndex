import React from "react";
import { GameInfoClient, IGameInfoClient } from "../api";


export class TestComponent extends React.Component {
  gameInfoClient: IGameInfoClient;

  constructor(props: any) {
    super(props);

    this.gameInfoClient = new GameInfoClient();
  }


  render(): React.ReactNode {
    this.gameInfoClient.getGameNames().then((names) => {
      console.log(names);
    });

    this.gameInfoClient.saveSomething("hello").then(response => console.log(response));

    return (<div>Hello</div>);
  }
}