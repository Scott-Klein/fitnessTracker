var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

import utils from '../../../Utilities/utils.js';

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
        'table',
        null,
        React.createElement(
            'tbody',
            null,
            utils.range(1, sets).map(function (setId) {
                return React.createElement(Set, { key: setId, setObject: props.sets, index: setId - 1 });
            })
        )
    );
}

export { SetsDisplay as default };