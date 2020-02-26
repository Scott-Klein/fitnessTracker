import Screen from './Screen.js';
import { ExerciseCard, utils } from './Cards/DiscreteExerciseCard.js';

function App() {
    const [profile, setProfile] = React.useState({ email: "Loading...", discreteExercisePlans: [{ name: "No name", setsOfExercise: [{ sets: { id: 999, setNumber: 1, repetitions: 12, repetitionsCompleted: 25 } }]}] });
    const [exercises, setExercises] = React.useState(1);

    let stringData;
    React.useEffect(() => {
        fetch("https://localhost:44313/api/profile").then((response) => {
            return response.json();
        })
            .then((data) => {
                console.log("Re rendering");
                console.log(data);
                setProfile(data);
                setExercises(data.discreteExercisePlans.length);
                console.log("THe number of plans found is " + data.discreteExercisePlans.length);
            });

    }, []);

    return (
        <div className="container">
            <Screen toDisplay={profile.email} />
            {utils.range(1, exercises).map(exerciseId =>
                <ExerciseCard key={exerciseId} discreteExercises={profile.discreteExercisePlans[exerciseId - 1]} />
                )}
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
