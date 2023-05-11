import React from "react";
import { BasicGameInfoDto } from "../api";
import { GameImage } from "./GameImage";
import { Container } from "semantic-ui-react";
import { GameListEntry } from "./GameListEntry";

interface GamesListProps {
  games: BasicGameInfoDto[];
}

interface GamesListState { }

export class GamesList extends React.Component<GamesListProps, GamesListState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const games = this.props.games;

    return (<Container>
      {games.map(game => {
        return (<GameListEntry key={game.gameID} />);
      })}
    </Container>);
  }
}
