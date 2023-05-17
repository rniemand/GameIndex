import React from "react";
import { BasicGameInfoDto, GamesClient, LocationDto } from "../api";
import { Button, Menu, Modal } from "semantic-ui-react";

interface SetConsoleModalProps {
  game: BasicGameInfoDto;
  onGameLocationChange: (game: BasicGameInfoDto) => void;
}

interface SetConsoleModalState {
  open: boolean;
  loading: boolean;
  locations: LocationDto[];
}

export class SetConsoleModal extends React.Component<SetConsoleModalProps, SetConsoleModalState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      open: false,
      loading: true,
      locations: []
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const game = this.props.game;
    const open = this.state.open;
    const loading = this.state.loading;
    const locations = this.state.locations;

    return (<Modal
      onClose={() => this._setOpen(false)}
      onOpen={() => !game.gameSold && this._setOpen(true)}
      open={open}
      size="tiny"
      trigger={<span className={'location ' + (game.gameSold ? 'sold' : '')}>
        {game.gameSold && 'Sold'}
        {!game.gameSold && game.locationName}
      </span>} >
      <Modal.Header>{game.gameName} ({game.platformName})</Modal.Header>
      <Modal.Content>
        {loading && <div>Fetching console list...</div>}
        {!loading && <div>
          <h2>Select console</h2>
          <Menu vertical fluid>
            {locations.map(location => <Menu.Item key={location.locationID} as='a' onClick={() => this._setGameLocation(location)}>
              {location.locationName}
            </Menu.Item>)}
          </Menu>
        </div>}
      </Modal.Content>
      <Modal.Actions>
        <Button color='black' onClick={() => this._setOpen(false)}>
          Close
        </Button>
      </Modal.Actions>
    </Modal>);
  }

  _setOpen = (open: boolean) => {
    this.setState({ open: open }, () => {
      if (!open) return;
      this._loadConsoles();
    });
  }

  _loadConsoles = () => {
    (new GamesClient().getGameLocations(this.props.game.platformID)).then(locations => {
      this.setState({
        loading: false,
        locations: locations || []
      });
    });
  }

  _setGameLocation = (location: LocationDto) => {
    const gameId = this.props.game.gameID;
    new GamesClient().setGameLocation(gameId, location.locationID).then(count => {
      this.props.game.locationID = location.locationID;
      this.props.game.locationName = location.locationName;
      this.props.onGameLocationChange(this.props.game);
      this._setOpen(false);
    });
  }
}
