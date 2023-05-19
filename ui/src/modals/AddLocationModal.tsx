import React from "react";
import { Button, Form, InputOnChangeData, Modal } from "semantic-ui-react";
import { LocationDto, LocationsClient, PlatformDto } from "../api";

interface AddLocationModalProps {
    platform: PlatformDto;
    onLocationAdded: () => void;
}

interface AddLocationModalState {
    open: boolean;
    locationName: string;
    adding: boolean;
}

export class AddLocationModal extends React.Component<AddLocationModalProps, AddLocationModalState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({
            open: false,
            locationName: '',
            adding: false,
        });
    }

    render(): React.ReactNode {
        if (!this.state) return null;
        const open = this.state.open;
        const locationName = this.state.locationName || '';
        const formValid = locationName.length > 0;
        const adding = this.state.adding;

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
                {adding && <span>Adding location...</span>}
                {!adding && <Form>
                    <Form.Input label='Location Name' type="text" onChange={this._setLocationName} />
                    <Form.Button content='Add Location' disabled={!formValid} onClick={this._addLocation} />
                </Form>}
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

    _setLocationName = (_event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        this.setState({ locationName: data.value });
    }

    _addLocation = () => {
        this.setState({ adding: true }, () => {
            new LocationsClient().addLocation(new LocationDto({
                locationName: this.state.locationName,
                platformID: this.props.platform.platformID,
                locationID: 0
            })).then(_location => {
                this.setState({ adding: false, open: false, locationName: '' }, this.props.onLocationAdded);
            });
        });
    }
}
