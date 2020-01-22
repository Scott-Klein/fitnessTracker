import Screen from './Screen.js';

function App() {
    return React.createElement(
        "div",
        { className: "container" },
        React.createElement(Screen, { toDisplay: "React is working Correctly" }),
        React.createElement(ExerciseCard, null),
        React.createElement(FoodCard, null),
        React.createElement(InfoCard, null)
    );
}

function ExerciseCard() {
    return React.createElement(
        "div",
        { className: "card card-body mb-5" },
        React.createElement(
            "h5",
            { className: "card-title" },
            "Exercises #1"
        ),
        React.createElement(
            "p",
            { className: "card-text" },
            "You have X many pushups to do today"
        ),
        React.createElement(
            "p",
            { className: "card-text" },
            "There will be buttons here that let you click to finish sets of exercise"
        )
    );
}

function FoodCard() {
    return React.createElement(
        "div",
        { className: "card card-body mb-5" },
        React.createElement(
            "h5",
            { className: "card-title" },
            "Food #1"
        ),
        React.createElement(
            "p",
            { className: "card-text" },
            "You have so many calories left in your budget."
        ),
        React.createElement(
            "p",
            { className: "card-text" },
            "You can eat one apple"
        )
    );
}

function InfoCard() {
    var today = new Date(Date.now());
    var now = today.toDateString();
    return React.createElement(
        "div",
        { className: "card card-body mb-5" },
        React.createElement(
            "h5",
            { className: "card-title" },
            "Info #1"
        ),
        React.createElement(
            "p",
            { className: "card-text" },
            "Today is: ",
            now
        )
    );
}

ReactDOM.render(React.createElement(App, null), document.getElementById('appContainer'));