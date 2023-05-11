import React from "react";
import { GamePlatformEntity, GamePlatformsClient } from "../api";
import { Menu } from "semantic-ui-react";

const client = new GamePlatformsClient();

interface GamePlatformsProps {
    onPlatformSelected: (platform: GamePlatformEntity) => void;
    selectedPlatform?: GamePlatformEntity;
}

interface GamePlatformsState {
    platforms: GamePlatformEntity[];
}

export class GamePlatforms extends React.Component<GamePlatformsProps, GamePlatformsState> {
    constructor(props: any) {
        super(props);
    }

    override componentDidMount(): void {
        this._refreshPlatforms();
    }

    render(): React.ReactNode {
        if (!this.state) return null;
        const platforms = this.state.platforms || [];
        const selectedPlatform = this.props.selectedPlatform;

        return (<Menu>
            {platforms.map(platform => {
                return (<Menu.Item key={platform.platformID} active={selectedPlatform?.platformID == platform.platformID}>
                    {platform.platformName}
                </Menu.Item>);
            })}
        </Menu>);
    }

    _refreshPlatforms = () => {
        client.getAll().then(_platforms => {
            this.setState({
                platforms: _platforms
            }, () => {
                this.props.onPlatformSelected(_platforms[0]);
            });
        });
    }
}
