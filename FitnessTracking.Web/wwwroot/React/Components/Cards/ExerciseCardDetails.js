import CompletionForm from './CompletionForm.js';

function ExerciseCardDetails() {
    return React.createElement(
        "div",
        null,
        React.createElement(
            "h4",
            null,
            "Details"
        ),
        React.createElement(
            "div",
            null,
            "All Time Pushups: 1263"
        ),
        React.createElement(
            "div",
            null,
            "Yesterday: 125"
        ),
        React.createElement(
            "div",
            { className: "mb-3" },
            "Tomorrow: 127"
        ),
        React.createElement(CompletionForm, null)
    );
}

export { ExerciseCardDetails as default };