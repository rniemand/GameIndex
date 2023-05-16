import React from "react";
import { Button, Container, DropdownProps, Icon, Input, InputOnChangeData, Menu, Select } from "semantic-ui-react";

interface GameListControlsProps {
    itemsPerPage: number;
    onSetItemsPerPage: (count: number) => void;
    onSearchChanged: (value: string) => void;
}

interface GameListControlsState {
    searchTerm: string;
}

export class GameListControls extends React.Component<GameListControlsProps, GameListControlsState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({ searchTerm: '' });
    }

    render(): React.ReactNode {
        if(!this.state) return null;
        const itemsPerPage = this.props.itemsPerPage || 3;
        const searchTerm = this.state.searchTerm || '';
        const itemsPerRow = [2,3,4,5,6,7,8,9,10].map(x => ({ key: x, value: x, text: `${x}` }));

        return (<Container>
            <Menu className="filter-menu">
                <Menu.Item>
                    <Input className='icon' value={searchTerm} icon='search' placeholder='Search...' onChange={this._onChange} />
                    <Button icon className="clear" onClick={this._clearSearch}>
                        <Icon name='delete' />
                    </Button>
                </Menu.Item>
                <Menu.Menu position="right" className="item-count-selector">
                    <Menu.Item>
                        <Select placeholder='#' options={itemsPerRow} value={itemsPerPage} fluid onChange={this._onItemsPerPageChange} />
                    </Menu.Item>
                </Menu.Menu>
            </Menu>
        </Container>);
    }

    _onChange = (_: any, data: InputOnChangeData) => {
        this.setState({ searchTerm: data.value }, () => {
            this.props.onSearchChanged(data.value);
        });
    }

    _clearSearch = (_: any, _2: any) => {
        this.setState({ searchTerm: '' }, () => {
            this.props.onSearchChanged('');
        });
    }

    _onItemsPerPageChange = (_event: React.SyntheticEvent<HTMLElement>, data: DropdownProps) => {
        this.props.onSetItemsPerPage(data.value as number);
    }
}