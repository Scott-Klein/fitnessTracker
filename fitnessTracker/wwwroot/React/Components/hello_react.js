var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

function Button(props) {

    var handleClick = function handleClick() {
        return props.incrementFunc(props.increment);
    };
    return React.createElement(
        'button',
        { onClick: handleClick },
        '+',
        props.increment
    );
}

function Display(props) {
    return React.createElement(
        'div',
        null,
        React.createElement(
            'p',
            null,
            'Display : ',
            props.counter
        )
    );
}

function App() {
    var _React$useState = React.useState(6),
        _React$useState2 = _slicedToArray(_React$useState, 2),
        getCounter = _React$useState2[0],
        setCounter = _React$useState2[1];

    var incrementCounter = function incrementCounter(incrementValue) {
        return setCounter(getCounter + incrementValue);
    };
    return React.createElement(
        'div',
        null,
        React.createElement(Button, { incrementFunc: incrementCounter, increment: 1 }),
        React.createElement(Button, { incrementFunc: incrementCounter, increment: 5 }),
        React.createElement(Button, { incrementFunc: incrementCounter, increment: 10 }),
        React.createElement(Button, { incrementFunc: incrementCounter, increment: 50 }),
        React.createElement(Display, { counter: getCounter })
    );
}

ReactDOM.render(React.createElement(App, null), document.getElementById('buttonMound'));