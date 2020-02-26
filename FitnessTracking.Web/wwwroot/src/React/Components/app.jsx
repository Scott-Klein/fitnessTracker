import Screen from './Screen.js';
import { ExerciseCard, utils } from './Cards/DiscreteExerciseCard.js';
import  DayInFutureOrToday  from '../../Utilities/DateUtil.js';

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

                for (let i = 0; i < data.discreteExercisePlans.length; i++) {
                    console.log("Log next");
                    let next = GetNextExercise(data.discreteExercisePlans[i]);
                    console.log(next);
                }

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

function GetNextExercise(plan) {
    const today = Date.now();
    for (let i = 0; i < plan.setsOfExercise.length; i++) {
        const day = new Date(plan.setsOfExercise[i].day);
        if (DayInFutureOrToday(day)) {
            console.log("Found a future or todays plan")
            return plan.setsOfExercise[i];
        }
    }
    return null;
}
