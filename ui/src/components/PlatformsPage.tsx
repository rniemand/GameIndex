import React from "react";
import { Card, Container } from "semantic-ui-react";
import { PlatformDto, PlatformsClient } from "../api";
import { PlatformListEntry } from "./platforms/PlatformListEntry";

interface PlatformsPageProps {
}

interface PlatformsPageState {
  platforms: PlatformDto[];
  loading: boolean;
}

export class PlatformsPage extends React.Component<PlatformsPageProps, PlatformsPageState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({
          loading: true,
          platforms: [],
        }, this._refreshPlatforms);
    }

    render(): React.ReactNode {
      if(!this.state) return null;

      if(this.state.loading) {
        return(<Container>Loading...</Container>)
      }

      const platforms = this.state.platforms;

      return(<Container>
        <Card.Group itemsPerRow={3}>
          {platforms.map(platform => <PlatformListEntry platform={platform} />)}
        </Card.Group>
      </Container>);
    }

    _refreshPlatforms = () => {
      new PlatformsClient().getAll().then(platforms => {
        this.setState({
          loading: false,
          platforms: platforms || [],
        });
      });
    }
}
