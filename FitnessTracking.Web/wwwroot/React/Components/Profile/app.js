
function App() {
    return React.createElement(
        "div",
        null,
        React.createElement(
            "button",
            { onClick: ApiTester },
            "Click me for API call"
        )
    );
}

function ApiTester() {
    console.log("Testing the api");
    fetch("https://localhost:44313/api/profile").then(function (response) {
        return response.json();
    }).then(function (myJson) {
        console.log(myJson);
    });
}

ReactDOM.render(React.createElement(App, null), document.getElementById('appContainer'));