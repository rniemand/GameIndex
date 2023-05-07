((app, _document) => {
    class AppHelper {
        constructor(renderFn) {
            if (!renderFn) throw new Error('No renderFn passed');
            if (typeof renderFn !== 'function') throw new Error('renderFn needs to be a function');

            this._renderFn = renderFn;
            this._runInit();
        };

        _runInit = () => {
            this._renderFn(this);
        };
    }

    app.helpers.AppHelper = AppHelper;
})(GameManager, document);
