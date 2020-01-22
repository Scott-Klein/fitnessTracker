
var Screen = function Screen(props) {
    return React.createElement(
        "div",
        null,
        React.createElement(
            "p",
            null,
            props.toDisplay
        )
    );
};

export default Screen;