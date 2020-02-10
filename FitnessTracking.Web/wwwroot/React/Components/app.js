var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

import Screen from './Screen.js';
import ExerciseCard from './Cards/DiscreteExerciseCard.js';

function App() {
    var _React$useState = React.useState(),
        _React$useState2 = _slicedToArray(_React$useState, 2),
        profile = _React$useState2[0],
        setProfile = _React$useState2[1];

    var stringData = void 0;
    React.useEffect(function () {
        fetch("https://localhost:44313/api/profile").then(function (response) {
            return response.json();
        }).then(function (data) {
            if (ProfileComparer(data, profile)) {
                console.log("They are the same!");
                console.log(data);
            } else {
                console.log("Re rendering");
                setProfile(data);
            }
        });
    });

    return React.createElement(
        'div',
        { className: 'container' },
        React.createElement(Screen, { toDisplay: 'React is working Correctly' }),
        React.createElement(ExerciseCard, null)
    );
}

ReactDOM.render(React.createElement(App, null), document.getElementById('appContainer'));

function ProfileComparer(prof1, prof2) {
    if (BothDefined(prof1, prof2)) {
        if (prof1.Email === prof2.Email) {
            return true;
        } else {
            return false;
        }
    }
    return false;
}

function BothDefined(obj1, obj2) {
    if (obj1 !== undefined && obj2 !== undefined) {
        return true;
    } else {
        return false;
    }
}