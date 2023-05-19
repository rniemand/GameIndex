import React from "react";
import { BasicGameInfoDto, GamesClient } from "../../api";
import { Button, Checkbox, CheckboxProps, Form, Input, InputOnChangeData, Label, Rating, RatingProps } from "semantic-ui-react";

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
    const hasGameBox = this.state.game.hasGameBox;
    const dirty = this.state.dirty;
    const saving = this.state.saving;
    const gameRating = this.state.game.gameRating;

    return (<React.Fragment>
      {this.state.saving && <p>Saving changes...</p>}
      <Form>
        <Form.Input value={gameName} onChange={this._setName} label='Game Name' />

        <Form.Group widths='equal'>
          <Form.Input fluid value={gameCaseLocation} onChange={this._setCase} label='Case Location' />
          <Form.Input fluid value={gamePrice} type="number" onChange={this._setPrice} label='Price' />
        </Form.Group>

        <div className="flex-toggles">
          <Form.Checkbox toggle checked={hasProtection} onChange={this._setProtection} label='Has Protection' />
          <Form.Checkbox toggle checked={hasGameBox} onChange={this._setHasBox} label='Has Game Box' />
        </div>

        <Rating maxRating={10} rating={gameRating} icon="star" onRate={this._setRating} className="bottom-spacing" />
        
        <Form.Button type='button' disabled={!dirty && !saving} onClick={this._saveChanges} content='Save Changes' />
      </Form>
    </React.Fragment>);
  }

  _setGameProperty = (merge: any) => {
    this.setState({
      dirty: true,
      game: new BasicGameInfoDto({
        ...this.state.game,
        ...merge
      })
    });
  }

  _setName = (_: any, data: InputOnChangeData) => this._setGameProperty({ gameName: data.value });
  _setCase = (_: any, data: InputOnChangeData) => this._setGameProperty({ gameCaseLocation: data.value });
  _setPrice = (_: any, data: InputOnChangeData) => this._setGameProperty({ gamePrice: parseFloat(data.value) });
  _setProtection = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => this._setGameProperty({ hasProtection: data.checked || false });
  _setHasBox = (_event: React.FormEvent<HTMLInputElement>, data: CheckboxProps) => this._setGameProperty({ hasGameBox: data.checked || false });
  _setRating = (_event: React.MouseEvent<HTMLDivElement>, data: RatingProps) => this._setGameProperty({ gameRating: data.rating || 0 });

  _saveChanges = () => {
    this.setState({ saving: true }, () => {
      new GamesClient().update(this.state.game).then(gameInfo => {
        this.setState({
          saving: false,
          dirty: false,
          game: gameInfo,
        });
      });
    });
  }
}