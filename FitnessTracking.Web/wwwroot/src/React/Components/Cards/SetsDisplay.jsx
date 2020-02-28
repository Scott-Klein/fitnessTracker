import utils from '../../../Utilities/utils.js'

function SetsDisplay(props) {
    const [sets, setSets] = React.useState(5);
    React.useEffect(() => {
        if (props.sets !== undefined) {
            if (props.sets.length !== undefined) {
                setSets(props.sets.length);
            }
        }
    });
    return (
        <table>
            <tbody>
                {utils.range(1, sets).map(setId =>
                    <Set key={setId} setObject={props.sets} index={setId - 1} />
                )}
            </tbody>
        </table>
    );
}


export {SetsDisplay as default}