function FoodCard() {
    return React.createElement(
        "div",
        { className: "card card-body mb-5" },
        React.createElement(
            "h5",
            { className: "card-title" },
            "Food #1"
        ),
        React.createElement(
            "p",
            { className: "card-text" },
            "You have so many calories left in your budget."
        ),
        React.createElement(
            "p",
            { className: "card-text" },
            "You can eat one apple"
        )
    );
}

export default FoodCard;