import React from "react";
import { Button, CheckboxProps, Form, InputOnChangeData, Modal, Rating, RatingProps } from "semantic-ui-react";
import { BasicGameInfoDto, GamesClient, LocationDto, PlatformDto } from "../api";
import { LocationDropdown } from "../components/locations/LocationDropdown";

interface AddGameModalProps {
    platform: PlatformDto;
    onGameAdded: () => void;
}

interface AddGameModalState {
    open: boolean;
    game: BasicGameInfoDto;
    formValid: boolean;
    saving: boolean;
}

export class AddGameModal extends React.Component<AddGameModalProps, AddGameModalState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({
            open: false,
            game: new BasicGameInfoDto({
              ...new BasicGameInfoDto(),
              platformID: this.props.platform.platformID,
              platformName: this.props.platform.platformName,
            }),
            formValid: false,
            saving: false,
        });
    }

    render(): React.ReactNode {
        if (!this.state?.game) return null;
        const open = this.state.open;
        const platform = this.props.platform;

        return (<Modal
            onClose={() => this._setOpen(false)}
            onOpen={() => this._setOpen(true)}
            open={open}
            size="small"
            trigger={<Button color="green" className="add-game-btn">
              Add new {platform.platformName} game
            </Button>}>
            {this._renderContents()}
        </Modal>);
    }

    _renderContents = () => {
      const platform = this.props.platform;
      const formValid = this.state.formValid;
      const game = this.state.game;

      return(<React.Fragment>
        <Modal.Header>Add {platform.platformName} Game</Modal.Header>
        <Modal.Content>
          <Form>
            <Form.Group widths='equal'>
              <Form.Input label='Name' fluid onChange={this._setName} />
              <Form.Input label='Price' fluid type="number" onChange={this._setPrice} />
              <Form.Input label='Case' fluid onChange={this._setCase} />
            </Form.Group>

            <Form.Group>
              <Form.Checkbox label='Has Box' toggle onChange={this._setHasBox} />
              <Form.Checkbox label='Protection' toggle onChange={this._setProtection} />
            </Form.Group>

            <LocationDropdown platform={platform} onChange={this._locationSelected} />
            <span className="pad-left">Rating: <Rating maxRating={10} rating={game.gameRating} icon="star" onRate={this._setRating} /></span>

            <Form.Button type="button" disabled={!formValid} content='Add Game' onClick={this._addGame} />
          </Form>
        </Modal.Content>
        <Modal.Actions>
          <Button color='black' onClick={() => this._setOpen(false)}>
              Close
          </Button>
        </Modal.Actions>
      </React.Fragment>);
    }

    _setOpen = (open: boolean) => {
        this.setState({ open: open }, () => {
            if (!open) return;
        });
    }

    _setGameProperty = (props: any) => {
      let valid = true;
      const game = new BasicGameInfoDto({
        ...this.state.game,
        ...props
      });

      if(!game.locationID || game.locationID <= 0) valid = false;
      if(!game.gameName || game.gameName.length < 1) valid = false;
      this.setState({ game: game, formValid: valid });
    }

    _setName = (_event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => this._setGameProperty({ gameName: data.value });
    _setCase = (_event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => this._setGameProperty({ gameCaseLocation: data.value });
    _setPrice = (_event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => this._setGameProperty({ gamePrice: parseFloat(data.value) });
    _setProtection = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => this._setGameProperty({ hasProtection: data.checked || false });
    _setHasBox = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => this._setGameProperty({ hasGameBox: data.checked || false });
    _setRating = (_event: React.MouseEvent<HTMLDivElement>, data: RatingProps) => this._setGameProperty({ gameRating: data.rating || 0 });

    _locationSelected = (location: LocationDto | undefined) => {
      if(this.state.game.locationID === location?.locationID) return;
      this._setGameProperty({
        locationID: location?.locationID || undefined,
        locationName: location?.locationName || '',
      });
    }

    _addGame = () => {
      this.setState({ saving: true }, () => {
        new GamesClient().addGame(this.state.game).then(_success => {
          this.setState({
            formValid: false,
            game: new BasicGameInfoDto(),
            open: false,
            saving: false,
          }, () => this.props.onGameAdded());
        });
      });
    }
}
