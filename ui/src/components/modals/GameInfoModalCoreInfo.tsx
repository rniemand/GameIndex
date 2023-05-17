import React from "react";
import { BasicGameInfoDto, GamesClient } from "../../api";
import { Button, Checkbox, CheckboxProps, Form, Input, InputOnChangeData, Label } from "semantic-ui-react";

interface GameInfoModalCoreInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalCoreInfoState {
  game: BasicGameInfoDto;
  dirty: boolean;
  saving: boolean;
}

export class GameInfoModalCoreInfo extends React.Component<GameInfoModalCoreInfoProps, GameInfoModalCoreInfoState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      game: this.props.game,
      dirty: false,
      saving: false,
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const gamePrice = this.state.game.gamePrice;
    const hasProtection = this.state.game.hasProtection;
    const gameName = this.state.game.gameName;
    const gameCaseLocation = this.state.game.gameCaseLocation;
    const dirty = this.state.dirty;
    const saving = this.state.saving;

    return (<div>
      {this.state.saving && <p>Saving changes...</p>}
      <Form>
        <Form.Field>
          <label>Game Name</label>
          <Input placeholder='Game Name' value={gameName} onChange={this._onNameChange} />
        </Form.Field>
        <Form.Field>
          <label>Location</label>
          <Input placeholder='Case' value={gameCaseLocation} onChange={this._onGameCaseChange} />
        </Form.Field>
        <Form.Field>
          <label>Price</label>
          <Input placeholder='Price' value={gamePrice} type="number" onChange={this._onGamePriceChanged} />
        </Form.Field>
        <Form.Field>
          <label>Has Protection</label>
          <Checkbox toggle checked={hasProtection} onChange={this._onProtectionChanged} />
        </Form.Field>
        <Button type='button' disabled={!dirty && !saving} onClick={this._saveChanges}>Save Changes</Button>
      </Form>
    </div>);
  }

  _onNameChange = (_: any, data: InputOnChangeData) => {
    this.setState({
      dirty: true,
      game: new BasicGameInfoDto({
        ...this.state.game,
        gameName: data.value
      })
    });
  }

  _onGameCaseChange = (_: any, data: InputOnChangeData) => {
    this.setState({
      dirty: true,
      game: new BasicGameInfoDto({
        ...this.state.game,
        gameCaseLocation: data.value
      })
    });
  }

  _onGamePriceChanged = (_: any, data: InputOnChangeData) => {
    this.setState({
      dirty: true,
      game: new BasicGameInfoDto({
        ...this.state.game,
        gamePrice: parseFloat(data.value)
      })
    });
  }

  _onProtectionChanged = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => {
    this.setState({
      dirty: true,
      game: new BasicGameInfoDto({
        ...this.state.game,
        hasProtection: data.checked || false
      })
    });
  }

  _saveChanges = () => {
    this.setState({ saving: true }, () => {
      new GamesClient().updateGameInfo(this.state.game).then(gameInfo => {
        this.setState({
          saving: false,
          dirty: false,
          game: gameInfo,
        });
      });
    });
  }
}