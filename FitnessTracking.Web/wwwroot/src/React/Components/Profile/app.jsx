
function App() {
    return (
        <div>
            <button onClick={ApiTester}>Click me for API call</button>
        </div>
        );
}


function ApiTester() {
    console.log("Testing the api");
    fetch("https://localhost:44313/api/profile")
        .then((response) => {
            return response.json();
        })
        .then((myJson) => {
            console.log(myJson);
        });

}

ReactDOM.render(
    <App />,
    document.getElementById('appContainer'),
);