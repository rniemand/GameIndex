import React from "react";
import { GamePlatformEntity, GamePlatformsClient } from "../api";

const client = new GamePlatformsClient();

interface GamePlatformsProps {
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

        return (<div>
            {platforms.map(platform => {
                return (<div key={platform.platformID}>{platform.platformName}</div>);
            })}
        </div>);
    }

    _refreshPlatforms = () => {
        client.getAll().then(_platforms => {
            this.setState({ platforms: _platforms });
        });
    }
}
