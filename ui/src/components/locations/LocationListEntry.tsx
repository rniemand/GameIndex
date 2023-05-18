import React from "react";
import { LocationDto } from "../../api";
import { Card } from "semantic-ui-react";

interface LocationListEntryProps {
  location: LocationDto;
}

interface LocationListEntryState { }

export class LocationListEntry extends React.Component<LocationListEntryProps, LocationListEntryState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const location = this.props.location;

    return (<Card>
      <Card.Content>
        <Card.Header>{location.locationName}</Card.Header>
      </Card.Content>
      <Card.Content extra>
        more to come
      </Card.Content>
    </Card>);
  }
}
