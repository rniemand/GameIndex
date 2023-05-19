import React from "react";
import { LocationDto, LocationsClient, PlatformDto } from "../../api";
import { DropdownItemProps, DropdownProps, Select } from "semantic-ui-react";

interface LocationDropdownProps {
  platform: PlatformDto;
  onChange: (location: LocationDto | undefined) => void;
}

interface LocationDropdownState {
  loading: boolean;
  locations: LocationDto[];
  selected?: LocationDto;
}

export class LocationDropdown extends React.Component<LocationDropdownProps, LocationDropdownState> {
  constructor(props: any) {
    super(props);
  }

  componentDidMount(): void {
      this.setState({
        loading: false,
        locations: [],
        selected: undefined,
      }, this._refreshLocations);
  }

  render(): React.ReactNode {
    if(!this.state) return;
    
    const loading = this.state.loading;
    if(loading) return <span>Loading...</span>;

    const selected = this.state.selected;
    const locations: DropdownItemProps[] = (this.state.locations || []).map(location => ({
       key: location.locationID,
       value: location.locationID,
       text: location.locationName
    }));

    return (<Select options={locations} value={selected?.locationID} onChange={this._onChange} />);
  }

  _refreshLocations = () => {
    if(this.state.loading) return;
    this.setState({ loading: true }, () => {
      new LocationsClient().getPlatformLocations(this.props.platform.platformID).then(locations => {
        this.setState({
          loading: false,
          locations: locations || [],
        });
      });
    });
  }

  _fireLocationSelected = (locationID: number) => {
    const locations = this.state.locations.filter(x => x.locationID === locationID);
    if(locations.length === 0) {
      this.setState({ selected: undefined }, () => this.props.onChange(undefined));
    } else {
      this.setState({ selected: locations[0] }, () => this.props.onChange(locations[0]));
    }
  }

  _onChange = (_event: React.SyntheticEvent<HTMLElement>, data: DropdownProps) => {
    this._fireLocationSelected(data.value as number);
  }
}
