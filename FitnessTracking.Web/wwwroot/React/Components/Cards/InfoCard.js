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

export default InfoCard;