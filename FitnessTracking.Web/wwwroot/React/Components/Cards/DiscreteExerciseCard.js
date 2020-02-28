var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

import ExerciseCardDetails from "./ExerciseCardDetails.js";
import SetsDisplay from "./SetsDisplay.js";

function ExerciseCard(props) {
    var _React$useState = React.useState(loadingSets),
        _React$useState2 = _slicedToArray(_React$useState, 2),
        futureSets = _React$useState2[0],
        setFutureSets = _React$useState2[1];

    React.useEffect(function () {
        if (props.discreteExercises.setsOfExercise !== undefined) {
            setFutureSets(GetNextExercise(props.discreteExercises.setsOfExercise));
        }
    });

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
                    React.createElement(SetsDisplay, { sets: futureSets })
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

var loadingSets = [{
    repetitions: 25,
    setNumber: 1
}];

export { ExerciseCard as default };