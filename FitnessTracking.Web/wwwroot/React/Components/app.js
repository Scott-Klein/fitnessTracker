import Screen from './Screen.js';
import ExerciseCard from './Cards/DiscreteExerciseCard.js';

function App() {
    return React.createElement(
        'div',
        { className: 'container' },
        React.createElement(Screen, { toDisplay: 'React is woking Correctly' }),
        React.createElement(ExerciseCard, null)
    );
}

ReactDOM.render(React.createElement(App, null), document.getElementById('appContainer'));