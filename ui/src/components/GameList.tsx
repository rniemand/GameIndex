import React from "react";
import { BasicGameInfoDto } from "../api";
import { Card, Container } from "semantic-ui-react";
import { GameListEntry } from "./GameListEntry";

interface GamesListProps {
  games: BasicGameInfoDto[];
}

interface GamesListState { }

export class GameList extends React.Component<GamesListProps, GamesListState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const games = this.props.games;

    return (<Container>
      <Card.Group itemsPerRow={5}>
        {games.map(game => {
          return (<GameListEntry key={game.gameID} game={game} />);
        })}
      </Card.Group>
    </Container>);
  }
}
