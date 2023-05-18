import React from "react";
import { Button, Card, Container } from "semantic-ui-react";
import { LocationDto, LocationsClient, PlatformDto, PlatformsClient } from "../api";
import { PlatformListEntry } from "./platforms/PlatformListEntry";
import { LocationListEntry } from "./locations/LocationListEntry";
import { AddLocationModal } from "../modals/AddLocationModal";

interface PlatformsPageProps {
}

interface PlatformsPageState {
  platforms: PlatformDto[];
  loading: boolean;
  selectedPlatform?: PlatformDto;
  locations: LocationDto[];
  view: string;
}

export class PlatformsPage extends React.Component<PlatformsPageProps, PlatformsPageState> {
    constructor(props: any) {
        super(props);
    }

    componentDidMount(): void {
        this.setState({
          loading: true,
          platforms: [],
          selectedPlatform: undefined,
          locations: [],
          view: 'platforms',
        }, this._refreshPlatforms);
    }

    render(): React.ReactNode {
      if(!this.state) return null;

      if(this.state.loading) {
        return(<Container>Loading...</Container>)
      }

      const view = this.state.view || 'platforms';

      return(<Container>
        {this._renderPlatformManager(view)}
        {this._renderLocationManager(view)}
      </Container>);
    }

    _renderPlatformManager = (view: string) => {
      if(view !== 'platforms') return null;
      const platforms = this.state.platforms || [];

      return(<React.Fragment>
        <h2>Platforms</h2>
        <Card.Group itemsPerRow={3}>
          {platforms.map(platform => <PlatformListEntry key={platform.platformID} platform={platform} onSelected={this._platformSelected} />)}
        </Card.Group>
      </React.Fragment>);
    }

    _renderLocationManager = (view: string) => {
      if(view !== 'locations') return null;
      const locations = this.state.locations || [];
      const platform = this.state.selectedPlatform!;

      return(<React.Fragment>
        <h2><a href="#" onClick={() => this._setView('platforms')}>Platforms</a> / {platform.platformName}</h2>
        <div className="bottom-spacing">
          <AddLocationModal platform={platform} />
        </div>
        <Card.Group itemsPerRow={3}>
          {locations.map(location => <LocationListEntry key={location.locationID} location={location} />)}
        </Card.Group>
      </React.Fragment>);
    }

    _refreshPlatforms = () => {
      new PlatformsClient().getAll().then(platforms => {
        this.setState({
          loading: false,
          platforms: platforms || [],
          view: 'platforms',
        });
      });
    }

    _refreshLocations = () => {
      if(!this.state.selectedPlatform) return;
      new LocationsClient().getPlatformLocations(this.state.selectedPlatform.platformID).then(locations => {
        this.setState({
          loading: false,
          locations: locations || [],
        });
      });
    }

    _setView = (view: string) => {
      this.setState({
        view: view,
        locations: view === 'locations' ? this.state.locations : []
      });
    }

    _platformSelected = (platform: PlatformDto) => {
      this.setState({
        selectedPlatform: platform,
        locations: [],
        loading: true,
        view: 'locations',
      }, this._refreshLocations);
    }
}
