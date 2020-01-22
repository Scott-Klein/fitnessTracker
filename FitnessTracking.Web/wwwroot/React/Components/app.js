import Screen from './Screen.js';

function App() {
    return React.createElement(
        'div',
        null,
        React.createElement(
            'p',
            null,
            'Hello ',
            Math.random(),
            ' this is React'
        ),
        React.createElement(Screen, { toDisplay: 'React is working Correctly' })
    );
}

ReactDOM.render(React.createElement(App, null), document.getElementById('appContainer'));