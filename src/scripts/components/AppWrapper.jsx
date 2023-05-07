((app) => {
    class AppWrapper extends React.Component {
        constructor(props) {
            super(props);
        }

        render() {
            return (<React.Fragment>
                <semanticUIReact.Container>
                    <semanticUIReact.Menu>
                        <semanticUIReact.Menu.Item>
                            Item
                        </semanticUIReact.Menu.Item>
                        <semanticUIReact.Menu.Item>
                            Item
                        </semanticUIReact.Menu.Item>
                    </semanticUIReact.Menu>
                </semanticUIReact.Container>
            </React.Fragment>);
        }
    }

    app.components.AppWrapper = AppWrapper;
})(GameManager);