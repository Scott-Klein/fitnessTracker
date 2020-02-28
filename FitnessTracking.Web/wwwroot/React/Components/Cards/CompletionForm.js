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

export { CompletionForm as default };