import React from "react";
import { Button, Card, Container } from "semantic-ui-react";

interface SettingsPageProps {
  onPageSelected: (page: string) => void;
}

interface SettingsPageState {
}

export class SettingsPage extends React.Component<SettingsPageProps, SettingsPageState> {
    constructor(props: any) {
        super(props);
    }

    render(): React.ReactNode {
        return(<Container>
          <Card.Group>
            <Card>
              <Card.Content>
                <Card.Header>Platforms</Card.Header>
              </Card.Content>
              <Card.Content extra>
                <Button basic onClick={() => this.props.onPageSelected('platforms')}>Manage</Button>
              </Card.Content>
            </Card>
          </Card.Group>
        </Container>);
    }
}
