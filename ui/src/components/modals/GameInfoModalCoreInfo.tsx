import React from "react";
import { BasicGameInfoDto, GamesClient } from "../../api";
import { Button, Form, Input, InputOnChangeData, Label } from "semantic-ui-react";

interface GameInfoModalCoreInfoProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalCoreInfoState {
  gameName: string;
  gameCase: string;
  dirty: boolean;
  saving: boolean;
}

export class GameInfoModalCoreInfo extends React.Component<GameInfoModalCoreInfoProps, GameInfoModalCoreInfoState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
    this.setState({
      gameName: this.props.game.gameName,
      dirty: false,
      gameCase: this.props.game.gameCase,
      saving: false,
    });
  }

  render(): React.ReactNode {
    if (!this.state) return null;
    const game = this.props.game;

    return (<div>
      {this.state.saving && <p>Saving changes...</p>}
      <Form>
        <Form.Field>
          <label>Game Name</label>
          <Input placeholder='Game Name' value={this.state.gameName} onChange={this._onNameChange} />
        </Form.Field>
        <Form.Field>
          <label>Location</label>
          <Input placeholder='Case' value={this.state.gameCase} onChange={this._onCaseChange} />
        </Form.Field>
        <Button type='button' disabled={!this.state.dirty && !this.state.saving} onClick={this._saveChanges}>Save Changes</Button>
      </Form>
    </div>);
  }

  _onNameChange = (_: any, data: InputOnChangeData) => {
    this.props.game.gameName = data.value;
    this.setState({
      gameName: data.value,
      dirty: true,
    });
  }

  _onCaseChange = (_: any, data: InputOnChangeData) => {
    this.props.game.gameCase = data.value;
    this.setState({
      dirty: true,
      gameCase: data.value,
    })
  }

  _saveChanges = () => {
    this.setState({ saving: true }, () => {
      new GamesClient().updateGameInfo(this.props.game).then(_ => {
        this.setState({
          saving: false,
          dirty: false,
        })
      });
    });
  }
}