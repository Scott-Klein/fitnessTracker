
function ExerciseCard() {
    const sets = 5;
    return (
        <div className="card card-body mb-5">
            <h5 className="card-title">Todays' pushups!</h5>
            <div className="container">
                <div className="row">
                    <div className="col-sm">
                        <table>
                            {utils.range(1, sets).map(setId =>
                                <Set key={setId}></Set>
                                )}
                        </table>
                    </div>
                    <div className="col-sm">
                        <ExerciseCardDetails></ExerciseCardDetails>
                    </div>
                </div>
            </div>
        </div>
    );
}

function ExerciseCardDetails() {
    return (
        <div>
            <h4>Details</h4>
            <div>All Time Pushups: 1263</div>
            <div>Yesterday: 125</div>
            <div className="mb-3">Tomorrow: 127</div>
            <form>
                <label>Current set:</label>
                <div className="row">
                    <div className="col">
                        <button type="button" className="btn btn-succes">Complete</button>
                    </div>
                    <div className="col">
                        <input type="text" className="form-control" placeholder="Reps"></input>
                    </div>
                </div>
            </form> 
        </div>
    );
}

function Set() {
    return (
        <tr>
            <td>Set #</td>
            <td><button type="button" className="btn btn-success">45</button></td>
        </tr>  
    );
}

const utils = {
    range: (min, max) => Array.from({ length: max - min + 1 }, (_, i) => min + i)
};

export default ExerciseCard;
