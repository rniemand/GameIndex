import React from "react";
import { BasicGameInfoDto, GameImageDto, GamesClient } from "../api";

interface GameInfoModalImagesProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalImagesState {
  loading: boolean;
  images: GameImageDto[];
}

export class GameInfoModalImages extends React.Component<GameInfoModalImagesProps, GameInfoModalImagesState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({ loading: true, images: [] }, this._loadGameImages)
    }

    render(): React.ReactNode {
      if(!this.state) return null;

      const game = this.props.game;
      if(this.state.loading) {
        return(<div>Loading <strong>{game.gameName}</strong> images...</div>);
      }

      const images = this.state.images;
      if(images.length == 0) {
        return(<div>No images found for <strong>{game.gameName}</strong>.</div>);
      }

        return (<div>
          We have {images.length} images for {game.gameName}!
        </div>);
    }

    _loadGameImages = () => {
      (new GamesClient()).getGameImages(this.props.game.gameID).then(images => {
        this.setState({
          loading: false,
          images: images || []
        });
      });
    }
}
