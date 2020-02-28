import ExerciseCardDetails from "./ExerciseCardDetails.js";
import SetsDisplay from "./SetsDisplay.js";

function ExerciseCard(props) {
    const [futureSets, setFutureSets] = React.useState(loadingSets);
    React.useEffect(() => {
        if (props.discreteExercises.setsOfExercise !== undefined) {
            setFutureSets(GetNextExercise(props.discreteExercises.setsOfExercise));
        }
    });

    return (
        <div className="card card-body mb-5">
            <h5 className="card-title">Todays {props.name}!</h5>
            <div className="container">
                <div className="row">
                    <div className="col-sm">
                        <SetsDisplay sets={futureSets} />
                    </div>
                    <div className="col-sm">
                        <ExerciseCardDetails></ExerciseCardDetails>
                    </div>
                </div>
            </div>
        </div>
    );
}

const loadingSets =
    [{
        repetitions: 25,
        setNumber: 1
    }];

export { ExerciseCard as default };
