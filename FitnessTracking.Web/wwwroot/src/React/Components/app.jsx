import Screen from './Screen.js';

function App() {
    return (
        <div className="container">
            <Screen toDisplay="React is working Correctly" />
            <ExerciseCard />
            <FoodCard />
            <InfoCard />
        </div>
        );
}


function ExerciseCard() {
    return (
        <div className="card card-body mb-5">
            <h5 className="card-title">Exercises #1</h5>
            <p className="card-text">You have X many pushups to do today</p>
            <p className="card-text">There will be buttons here that let you click to finish sets of exercise</p>
        </div>
        );
}

function FoodCard() {
    return (
        <div className="card card-body mb-5">
            <h5 className="card-title">Food #1</h5>
            <p className="card-text">You have so many calories left in your budget.</p>
            <p className="card-text">You can eat one apple</p>
        </div>
    );
}

function InfoCard() {
    const today = new Date(Date.now());
    const now = today.toDateString();
    return (
        <div className="card card-body mb-5">
            <h5 className="card-title">Info #1</h5>
            <p className="card-text">Today is: {now}</p>
        </div>
    );
}

ReactDOM.render(
    <App />,
    document.getElementById('appContainer'),
);