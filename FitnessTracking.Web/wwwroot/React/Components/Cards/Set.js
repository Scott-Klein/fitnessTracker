var _slicedToArray = function () { function sliceIterator(arr, i) { var _arr = []; var _n = true; var _d = false; var _e = undefined; try { for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) { _arr.push(_s.value); if (i && _arr.length === i) break; } } catch (err) { _d = true; _e = err; } finally { try { if (!_n && _i["return"]) _i["return"](); } finally { if (_d) throw _e; } } return _arr; } return function (arr, i) { if (Array.isArray(arr)) { return arr; } else if (Symbol.iterator in Object(arr)) { return sliceIterator(arr, i); } else { throw new TypeError("Invalid attempt to destructure non-iterable instance"); } }; }();

function Set(props) {
    var _React$useState = React.useState(22),
        _React$useState2 = _slicedToArray(_React$useState, 2),
        repetitions = _React$useState2[0],
        setRepetitions = _React$useState2[1];

    var _React$useState3 = React.useState(1),
        _React$useState4 = _slicedToArray(_React$useState3, 2),
        setNum = _React$useState4[0],
        setSetNum = _React$useState4[1];

    React.useEffect(function () {
        console.log(props);
        //if (props.setObject !== undefined && props.setObject[props.index] !== undefined) {
        //    setRepetitions(props.setObject[props.index].repetitions);
        //    setSetNum(props.setObject[props.index].setNumber);
        //}
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

export { Set as default };