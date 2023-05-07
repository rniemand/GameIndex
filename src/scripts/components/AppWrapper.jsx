((app) => {
    class AppWrapper extends React.Component {
        constructor(props) {
            super(props);
        }

        render() {
            return (<div>App</div>);
        }
    }

    app.components.AppWrapper = AppWrapper;
})(GameManager);