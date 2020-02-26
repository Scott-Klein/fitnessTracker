var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

import Screen from './Screen.js';
import { ExerciseCard, utils } from './Cards/DiscreteExerciseCard.js';
import DayInFutureOrToday from '../../Utilities/DateUtil.js';

function App() {
    var _React$useState = React.useState({ email: "Loading...", discreteExercisePlans: [{ name: "No name", setsOfExercise: [{ sets: { id: 999, setNumber: 1, repetitions: 12, repetitionsCompleted: 25 } }] }] }),
        _React$useState2 = _slicedToArray(_React$useState, 2),
        profile = _React$useState2[0],
        setProfile = _React$useState2[1];

    var _React$useState3 = React.useState(1),
        _React$useState4 = _slicedToArray(_React$useState3, 2),
        exercises = _React$useState4[0],
        setExercises = _React$useState4[1];

    var stringData = void 0;
    React.useEffect(function () {
        fetch("https://localhost:44313/api/profile").then(function (response) {
            return response.json();
        }).then(function (data) {
            setProfile(data);
            setExercises(data.discreteExercisePlans.length);

            for (var i = 0; i < data.discreteExercisePlans.length; i++) {
                console.log("Log next");
                var next = GetNextExercise(data.discreteExercisePlans[i]);
                console.log(next);
            }
        });
    }, []);

    return React.createElement(
        'div',
        { className: 'container' },
        React.createElement(Screen, { toDisplay: profile.email }),
        utils.range(1, exercises).map(function (exerciseId) {
            return React.createElement(ExerciseCard, { key: exerciseId, discreteExercises: profile.discreteExercisePlans[exerciseId - 1] });
        })
    );
}

ReactDOM.render(React.createElement(App, null), document.getElementById('appContainer'));

function GetNextExercise(plan) {
    var today = Date.now();
    for (var i = 0; i < plan.setsOfExercise.length; i++) {
        var day = new Date(plan.setsOfExercise[i].day);
        if (DayInFutureOrToday(day)) {
            console.log("Found a future or todays plan");
            return plan.setsOfExercise[i];
        }
    }
    return null;
}