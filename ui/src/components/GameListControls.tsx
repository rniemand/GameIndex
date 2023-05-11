import React from "react";
import { Container, Menu } from "semantic-ui-react";

interface GameListControlsProps {
    itemsPerPage: number;
    onSetItemsPerPage: (count: number) => void;
}

interface GameListControlsState { }

export class GameListControls extends React.Component<GameListControlsProps, GameListControlsState> {
    constructor(props: any) {
        super(props);
    }

    render(): React.ReactNode {
        const itemsPerPage = this.props.itemsPerPage || 3;

        return (<Container>
            <Menu>
                <Menu.Menu position="right">
                    {[3, 4, 5, 6].map(num => {
                        return (<Menu.Item key={num} active={num === itemsPerPage} onClick={() => this.props.onSetItemsPerPage(num)}>
                            {num}
                        </Menu.Item>);
                    })}
                </Menu.Menu>
            </Menu>
        </Container>);
    }
}