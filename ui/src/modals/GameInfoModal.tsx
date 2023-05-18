import React from "react";
import { BasicGameInfoDto } from "../api";
import { Button, Icon, Modal, Tab } from "semantic-ui-react";
import { GameInfoModalCoreInfo } from "../components/modals/GameInfoModalGame";
import { GameInfoModalImages } from "../components/modals/GameInfoModalImages";
import { GameInfoModalReceipt } from "../components/modals/GameInfoModalReceipt";

interface GameInfoModalProps {
  game: BasicGameInfoDto;
  onModalClosed: () => void;
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
    if (!this.state) return null;
    const game = this.props.game;
    const open = this.state.open;

    const panes = [
      {
        menuItem: { key: '1', icon: 'info', content: 'Game' },
        render: () => <Tab.Pane attached={true}>
          <GameInfoModalCoreInfo game={game} />
        </Tab.Pane>,
      },
      {
        menuItem: { key: '2', icon: 'shopping basket', content: 'Receipt' },
        render: () => <Tab.Pane attached={true}>
          <GameInfoModalReceipt game={game} />
        </Tab.Pane>,
      },
      {
        menuItem: { key: '3', icon: 'picture', content: 'Images' },
        render: () => <Tab.Pane attached={true}>
          <GameInfoModalImages game={game} />
        </Tab.Pane>,
      }
    ];

    return (<Modal
      onClose={() => this._setOpen(false)}
      onOpen={() => this._setOpen(true)}
      open={open}
      trigger={<Icon name='info circle' className="modal-trigger" color="green" />}
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
    this.setState({ open: open }, () => {
      if (open) return;
      this.props.onModalClosed();
    });
  }
}
