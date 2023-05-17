import React from "react";
import { BasicGameInfoDto, GamesClient } from "../../api";
import { Button, Checkbox, CheckboxProps, Form, Input, InputOnChangeData, Label } from "semantic-ui-react";

interface GameInfoModalCoreInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalCoreInfoState {
  gameName: string;
  gameCaseLocation: string;
  dirty: boolean;
  saving: boolean;
  gamePrice: number;
  hasProtection: boolean;
}

export class GameInfoModalCoreInfo extends React.Component<GameInfoModalCoreInfoProps, GameInfoModalCoreInfoState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      gameName: this.props.game.gameName,
      dirty: false,
      gameCaseLocation: this.props.game.gameCaseLocation,
      saving: false,
      gamePrice: this.props.game.gamePrice,
      hasProtection: this.props.game.hasProtection
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const cost = this.state.gamePrice;
    const hasProtection = this.state.hasProtection;

    return (<div>
      {this.state.saving && <p>Saving changes...</p>}
      <Form>
        <Form.Field>
          <label>Game Name</label>
          <Input placeholder='Game Name' value={this.state.gameName} onChange={this._onNameChange} />
        </Form.Field>
        <Form.Field>
          <label>Location</label>
          <Input placeholder='Case' value={this.state.gameCaseLocation} onChange={this._onCaseChange} />
        </Form.Field>
        <Form.Field>
          <label>Price</label>
          <Input placeholder='Price' value={cost} type="number" onChange={this._onPriceChanged} />
        </Form.Field>
        <Form.Field>
          <label>Has Protection</label>
          <Checkbox toggle checked={hasProtection} onChange={this._onProtectionChanged} />
        </Form.Field>
        <Button type='button' disabled={!this.state.dirty && !this.state.saving} onClick={this._saveChanges}>Save Changes</Button>
      </Form>
    </div>);
  }

  _onNameChange = (_: any, data: InputOnChangeData) => {
    this.props.game.gameName = data.value;
    this.setState({
      gameName: this.props.game.gameName,
      dirty: true,
    });
  }

  _onProtectionChanged = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => {
    this.props.game.hasProtection = data.checked || false;
    this.setState({
      hasProtection: this.props.game.hasProtection,
      dirty: true,
    });
  }

  _onCaseChange = (_: any, data: InputOnChangeData) => {
    this.props.game.gameCaseLocation = data.value;
    this.setState({
      dirty: true,
      gameCaseLocation: this.props.game.gameCaseLocation,
    })
  }

  _onPriceChanged = (_: any, data: InputOnChangeData) => {
    this.props.game.gamePrice = parseFloat(data.value || '0');
    this.setState({
      dirty: true,
      gamePrice: this.props.game.gamePrice,
    })
  }

  _saveChanges = () => {
    this.setState({ saving: true }, () => {
      new GamesClient().updateGameInfo(this.props.game).then(_ => {
        this.setState({
          saving: false,
          dirty: false,
        });
      });
    });
  }
}