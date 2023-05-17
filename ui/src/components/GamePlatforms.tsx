import React from "react";
import { Menu } from "semantic-ui-react";
import { PlatformDto, PlatformsClient } from "../api";

interface GamePlatformsProps {
    onPlatformSelected: (platform: PlatformDto) => void;
    selectedPlatform?: PlatformDto;
}

interface GamePlatformsState {
    platforms: PlatformDto[];
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
                return (<Menu.Item
                    key={platform.platformID}
                    active={selectedPlatform?.platformID == platform.platformID}
                    as='a'
                    onClick={() => this.props.onPlatformSelected(platform)}
                    content={platform.platformName}
                />);
            })}
        </Menu>);
    }

    _refreshPlatforms = () => {
        new PlatformsClient().getAll().then(_platforms => {
            this.setState({
                platforms: _platforms
            }, () => {
                this.props.onPlatformSelected(_platforms[0]);
            });
        });
    }
}
