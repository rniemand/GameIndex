import React from "react";
import { BasicGameInfoDto } from "../api";
import { Button, Icon, Modal, Tab } from "semantic-ui-react";

interface GameInfoModalProps {
  game: BasicGameInfoDto;
}

interface GameInfoModalState {
  open: boolean;
}

export class GameInfoModal extends React.Component<GameInfoModalProps, GameInfoModalState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
      this.setState({
        open: false
      });
  }

  render(): React.ReactNode {
    if(!this.state) return null;
    const game = this.props.game;
    const open = this.state.open;

    const panes = [
      {
        menuItem: { key: '1', icon: 'info', content: 'Info' },
        render: () => <Tab.Pane attached={true}>Tab 1 Content</Tab.Pane>,
      },
      {
        menuItem: { key: '2', icon: 'shopping basket', content: 'Purchase' },
        render: () => <Tab.Pane attached={true}>Tab 1 Content</Tab.Pane>,
      },
      {
        menuItem: { key: '3', icon: 'picture', content: 'Media' },
        render: () => <Tab.Pane attached={true}>Tab 1 Content</Tab.Pane>,
      }
    ];

    return (<Modal
      onClose={() => this._setOpen(false)}
      onOpen={() => this._setOpen(true)}
      open={open}
      trigger={<Button fluid icon labelPosition='left' color="blue">
        <Icon name='info' />
        Info
      </Button>}
    >
      <Modal.Header>{game.gameName} ({game.platformName})</Modal.Header>
      <Modal.Content>
        <Tab panes={panes} />
      </Modal.Content>
      <Modal.Actions>
        <Button color='black' onClick={() => this._setOpen(false)}>
          Close
        </Button>
      </Modal.Actions>
    </Modal>);
  }

  _setOpen = (open: boolean) => {
    this.setState({ open: open });
  }
}
