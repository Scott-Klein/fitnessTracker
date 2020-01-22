import Screen from './Screen.js';

function App() {
    return (
        <div>
            <p>Hello {Math.random()} this is React</p>
            <Screen toDisplay="React is working Correctly" />
        </div>
        );
}




ReactDOM.render(
    <App />,
    document.getElementById('appContainer'),
);