import Screen from './Screen.js';
import ExerciseCard from './Cards/DiscreteExerciseCard.js';

function App() {
    const [profile, setProfile] = React.useState();
    let stringData;
    React.useEffect(() => {
        fetch("https://localhost:44313/api/profile").then((response) =>
        {
            return response.json();
        })
            .then((data) =>
            {
                    if (ProfileComparer(data, profile)) {
                        console.log("They are the same!");
                        console.log(data);
                    } else {
                        console.log("Re rendering");
                        setProfile(data);
                    }
            });

    });

    return (
        <div className="container">
            <Screen toDisplay="React is working Correctly" />
            <ExerciseCard />

        </div>
        );
}


ReactDOM.render(
    <App />,
    document.getElementById('appContainer'),
);



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