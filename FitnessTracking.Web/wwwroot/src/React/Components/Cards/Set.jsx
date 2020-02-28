function Set(props) {
    const [repetitions, setRepetitions] = React.useState(22);
    const [setNum, setSetNum] = React.useState(1);
    React.useEffect(() => {
        console.log(props);
        //if (props.setObject !== undefined && props.setObject[props.index] !== undefined) {
        //    setRepetitions(props.setObject[props.index].repetitions);
        //    setSetNum(props.setObject[props.index].setNumber);
        //}
    });
    return (
        <tr>
            <td>Set {setNum}</td>
            <td><button type="button" className="btn btn-success">{repetitions}</button></td>
        </tr>
    );
}

export { Set as default }