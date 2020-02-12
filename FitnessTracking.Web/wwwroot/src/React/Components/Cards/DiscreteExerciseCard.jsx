
function ExerciseCard(props) {
    
    return (
        <div className="card card-body mb-5">
            <h5 className="card-title">Todays {props.discreteExercises[0].name}!</h5>
            <div className="container">
                <div className="row">
                    <div className="col-sm">
                        <SetsDisplay sets={props.discreteExercises[0].setsOfExercise}/>
                    </div>
                    <div className="col-sm">
                        <ExerciseCardDetails></ExerciseCardDetails>
                    </div>
                </div>
            </div>
        </div>
    );
}

function SetsDisplay(props) {
    const [sets, setSets] = React.useState(5);
    React.useEffect(() => {
        if (props.sets.length !== undefined) {
            setSets(props.sets.length);
        } else {
            for (var i = 0; i < sets; i++) {
                props.sets[i] = 35;
            }
        }
    });
    return (
        <table>
            <tbody>
                {utils.range(1, sets).map(setId =>
                    <Set key={setId} setObject={props.sets} index={setId -1} />
                )}
            </tbody>
        </table>
        );
}

function ExerciseCardDetails() {
    return (
        <div>
            <h4>Details</h4>
            <div>All Time Pushups: 1263</div>
            <div>Yesterday: 125</div>
            <div className="mb-3">Tomorrow: 127</div>
            <CompletionForm />
        </div>
    );
}

function CompletionForm() {
    return (
        <form>
            <label>Current set:</label>
            <div className="row">
                <div className="col">
                    <button type="button" className="btn btn-success">Complete</button>
                </div>
                <div className="col">
                    <input type="text" className="form-control" placeholder="Reps"></input>
                </div>
            </div>
        </form> 
        );
}

function Set(props) {
    const [repetitions, setRepetitions] = React.useState(22);
    const [setNum, setSetNum] = React.useState(1);
    React.useEffect(() => {
        console.log("Logging set object");
        console.log(props.setObject[props.index]);
        if (props.setObject[props.index] !== undefined) {
            setRepetitions(props.setObject[props.index].repetitions);
            setSetNum(props.setObject[props.index].setNumber);
        }
    });
    return (
        <tr>
            <td>Set {setNum}</td>
            <td><button type="button" className="btn btn-success">{repetitions}</button></td>
        </tr>  
    );
}

const utils = {
    range: (min, max) => Array.from({ length: max - min + 1 }, (_, i) => min + i)
};

export default ExerciseCard;
