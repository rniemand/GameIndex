import React from "react";
import { Button, Modal } from "semantic-ui-react";
import { PlatformDto } from "../api";

interface AddLocationModalProps {
    platform: PlatformDto;
}

interface AddLocationModalState {
    open: boolean;
}

export class AddLocationModal extends React.Component<AddLocationModalProps, AddLocationModalState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({
            open: false,
        });
    }

    render(): React.ReactNode {
        if (!this.state) return null;
        const open = this.state.open;

        return (<Modal
            onClose={() => this._setOpen(false)}
            onOpen={() => this._setOpen(true)}
            open={open}
            size="tiny"
            trigger={<Button color="green">
              Add new {this.props.platform.platformName} location
            </Button>}>
            <Modal.Header>Add Platform Location</Modal.Header>
            <Modal.Content>
                More to come
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
        });
    }
}
