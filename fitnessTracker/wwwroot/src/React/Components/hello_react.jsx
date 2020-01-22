
function Button(props) {

    const handleClick = () => props.incrementFunc(props.increment);
    return (
        <button onClick={handleClick} >
            +{props.increment}
        </button>
    );
}

function Display(props) {
    return (
        <div>
            <p>Display : {props.counter}</p>
        </div>
    );
}


function App() {
    const [getCounter, setCounter] = React.useState(6);
    const incrementCounter = (incrementValue) => setCounter(getCounter + incrementValue);
    return (
        <div> 
            <Button incrementFunc={incrementCounter} increment={1} />
            <Button incrementFunc={incrementCounter} increment={5} />
            <Button incrementFunc={incrementCounter} increment={10} />
            <Button incrementFunc={incrementCounter} increment={50} />
            <Display counter={getCounter}/>
        </div>
    );
}

ReactDOM.render(
    <App />,
    document.getElementById('buttonMound'),
);