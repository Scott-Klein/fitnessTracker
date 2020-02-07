import Screen from './Screen.js';
import ExerciseCard from './Cards/DiscreteExerciseCard.js';

function App() {
    return (
        <div className="container">
            <Screen toDisplay="React is woking Correctly" />
            <ExerciseCard />

        </div>
        );
}


ReactDOM.render(
    <App />,
    document.getElementById('appContainer'),
);