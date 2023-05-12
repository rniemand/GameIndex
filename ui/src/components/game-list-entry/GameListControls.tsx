import React from "react";
import { Button, Container, Icon, Input, InputOnChangeData, Menu } from "semantic-ui-react";

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

        return (<Container>
            <Menu className="filter-menu">
                <Menu.Item>
                    <Input className='icon' value={searchTerm} icon='search' placeholder='Search...' onChange={this._onChange} />
                    <Button icon className="clear" disabled={searchTerm.length === 0} onClick={this._clearSearch}>
                        <Icon name='delete' />
                    </Button>
                </Menu.Item>
                <Menu.Menu position="right">
                    {[3, 4, 5, 6, 7].map(num => {
                        return (<Menu.Item key={num} active={num === itemsPerPage} onClick={() => this.props.onSetItemsPerPage(num)}>
                            {num}
                        </Menu.Item>);
                    })}
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
}