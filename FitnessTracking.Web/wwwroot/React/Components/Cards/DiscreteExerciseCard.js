
function ExerciseCard() {

    return React.createElement(
        "div",
        { className: "card card-body mb-5" },
        React.createElement(
            "h5",
            { className: "card-title" },
            "Todays' pushups!"
        ),
        React.createElement(
            "div",
            { className: "container" },
            React.createElement(
                "div",
                { className: "row" },
                React.createElement(
                    "div",
                    { className: "col-sm" },
                    React.createElement(SetsDisplay, null)
                ),
                React.createElement(
                    "div",
                    { className: "col-sm" },
                    React.createElement(ExerciseCardDetails, null)
                )
            )
        )
    );
}

function SetsDisplay() {
    var sets = 5;
    return React.createElement(
        "table",
        null,
        React.createElement(
            "tbody",
            null,
            utils.range(1, sets).map(function (setId) {
                return React.createElement(Set, { key: setId });
            })
        )
    );
}

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

function CompletionForm() {
    return React.createElement(
        "form",
        null,
        React.createElement(
            "label",
            null,
            "Current set:"
        ),
        React.createElement(
            "div",
            { className: "row" },
            React.createElement(
                "div",
                { className: "col" },
                React.createElement(
                    "button",
                    { type: "button", className: "btn btn-success" },
                    "Complete"
                )
            ),
            React.createElement(
                "div",
                { className: "col" },
                React.createElement("input", { type: "text", className: "form-control", placeholder: "Reps" })
            )
        )
    );
}

function Set() {
    return React.createElement(
        "tr",
        null,
        React.createElement(
            "td",
            null,
            "Set #"
        ),
        React.createElement(
            "td",
            null,
            React.createElement(
                "button",
                { type: "button", className: "btn btn-success" },
                "45"
            )
        )
    );
}

var utils = {
    range: function range(min, max) {
        return Array.from({ length: max - min + 1 }, function (_, i) {
            return min + i;
        });
    }
};

export default ExerciseCard;