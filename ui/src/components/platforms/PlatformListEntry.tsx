import React from "react";
import { PlatformDto } from "../../api";
import { Button, Card } from "semantic-ui-react";

interface PlatformListEntryProps {
  platform: PlatformDto;
  onSelected: (platform: PlatformDto) => void;
}

interface PlatformListEntryState { }

export class PlatformListEntry extends React.Component<PlatformListEntryProps, PlatformListEntryState> {
  constructor(props: any) {
    super(props);
  }

  render(): React.ReactNode {
    const platform = this.props.platform;

    return (<Card>
      <Card.Content>
        <Card.Header>{platform.platformName}</Card.Header>
      </Card.Content>
      <Card.Content extra>
        <Button basic onClick={() => this.props.onSelected(platform)}>Manage</Button>
      </Card.Content>
    </Card>);
  }
}
