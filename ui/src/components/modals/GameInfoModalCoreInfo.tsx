import React from "react";
import { BasicGameInfoDto } from "../../api";

interface GameInfoModalCoreInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalCoreInfoState { }

export class GameInfoModalCoreInfo extends React.Component<GameInfoModalCoreInfoProps, GameInfoModalCoreInfoState> {
    constructor(props: any) {
        super(props);
    }

    render(): React.ReactNode {
      const game = this.props.game;

        return (<div>
          Information for: {game.gameName}
        </div>);
    }
}