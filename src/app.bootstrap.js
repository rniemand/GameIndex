((app, _document) => {
    const rel = React.createElement.bind(React);
    const domContainer = _document.querySelector("#react");
    const root = ReactDOM.createRoot(domContainer);

    app.instance = new app.helpers.AppHelper(ctx => {
        root.render(rel(app.components.AppWrapper, {}));
    });
})(GameManager, document);
