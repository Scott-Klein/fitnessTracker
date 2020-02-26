var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

function ExerciseCard(props) {
    return React.createElement(
        "div",
        { className: "card card-body mb-5" },
        React.createElement(
            "h5",
            { className: "card-title" },
            "Todays ",
            props.name,
            "!"
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
                    React.createElement(SetsDisplay, { sets: props.discreteExercises.setsOfExercise })
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

function SetsDisplay(props) {
    var _React$useState = React.useState(5),
        _React$useState2 = _slicedToArray(_React$useState, 2),
        sets = _React$useState2[0],
        setSets = _React$useState2[1];

    React.useEffect(function () {
        if (props.sets !== undefined) {
            if (props.sets.length !== undefined) {
                setSets(props.sets.length);
            }
        }
    });
    return React.createElement(
        "table",
        null,
        React.createElement(
            "tbody",
            null,
            utils.range(1, sets).map(function (setId) {
                return React.createElement(Set, { key: setId, setObject: props.sets, index: setId - 1 });
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

function Set(props) {
    var _React$useState3 = React.useState(22),
        _React$useState4 = _slicedToArray(_React$useState3, 2),
        repetitions = _React$useState4[0],
        setRepetitions = _React$useState4[1];

    var _React$useState5 = React.useState(1),
        _React$useState6 = _slicedToArray(_React$useState5, 2),
        setNum = _React$useState6[0],
        setSetNum = _React$useState6[1];

    React.useEffect(function () {
        console.log(props.setObject);
        if (props.setObject !== undefined && props.setObject[props.index] !== undefined) {
            setRepetitions(props.setObject[props.index].repetitions);
            setSetNum(props.setObject[props.index].setNumber);
        }
    });
    return React.createElement(
        "tr",
        null,
        React.createElement(
            "td",
            null,
            "Set ",
            setNum
        ),
        React.createElement(
            "td",
            null,
            React.createElement(
                "button",
                { type: "button", className: "btn btn-success" },
                repetitions
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

export { ExerciseCard, utils };