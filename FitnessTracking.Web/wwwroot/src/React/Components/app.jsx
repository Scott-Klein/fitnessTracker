import Screen from './Screen.js';
import ExerciseCard  from './Cards/DiscreteExerciseCard.js';
import utils from '../../Utilities/utils.js';

function App() {
    const [profile, setProfile] = React.useState({ email: "Loading...", discreteExercisePlans: [{ name: "No name", setsOfExercise: [{ sets: { id: 999, setNumber: 1, repetitions: 12, repetitionsCompleted: 25 } }]}] });
    const [exercises, setExercises] = React.useState(1);

    let stringData;
    React.useEffect(() => {
        fetch("https://localhost:44313/api/profile").then((response) => {
            return response.json();
        })
            .then((data) => {
                setProfile(data);
                setExercises(data.discreteExercisePlans.length);
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

