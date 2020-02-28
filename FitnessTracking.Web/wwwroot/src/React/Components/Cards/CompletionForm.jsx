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

export { CompletionForm as default } 