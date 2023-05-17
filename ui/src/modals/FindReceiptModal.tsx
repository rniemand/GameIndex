import React from "react";
import { Button, Input, InputOnChangeData, Menu, Modal } from "semantic-ui-react";
import { ReceiptClient, ReceiptDto } from "../api";

interface FindReceiptModalProps {
    onReceiptSelected: (receipt: ReceiptDto) => void;
}

interface FindReceiptModalState {
    open: boolean;
    searching: boolean;
    receipts: ReceiptDto[];
}

export class FindReceiptModal extends React.Component<FindReceiptModalProps, FindReceiptModalState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({
            open: false,
            searching: false,
            receipts: [],
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
            trigger={<Button content='Associate Receipt' />}
        >
            <Modal.Header>Associate Receipt</Modal.Header>
            <Modal.Content>
                <div>
                    <Input type="text" onChange={this._findReceipts} />
                </div>
                {this.state.receipts.map(receipt => {
                    return (<div key={receipt.receiptID}>
                        {receipt.receiptNumber}
                        <Button content='Select' onClick={() => this._selectReceipt(receipt)} />
                    </div>);
                })}
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

    _findReceipts = (_event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        this.setState({ searching: true, receipts: [] }, () => {
            if (!data.value) return;
            new ReceiptClient().search(data.value).then(receipts => {
                this.setState({
                    searching: false,
                    receipts: receipts,
                });
            });
        });
    }

    _selectReceipt = (receipt: ReceiptDto) => {
        this.props.onReceiptSelected(receipt);
        this._setOpen(false);
    }
}
