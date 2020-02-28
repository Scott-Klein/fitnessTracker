import CompletionForm from './CompletionForm.js'

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

export { ExerciseCardDetails as default }