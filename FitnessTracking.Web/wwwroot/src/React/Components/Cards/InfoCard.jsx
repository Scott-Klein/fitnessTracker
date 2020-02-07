function InfoCard() {
    const today = new Date(Date.now());
    const now = today.toDateString();
    return (
        <div className="card card-body mb-5">
            <h5 className="card-title">Info #1</h5>
            <p className="card-text">Today is: {now}</p>
        </div>
    );
}

export default InfoCard;