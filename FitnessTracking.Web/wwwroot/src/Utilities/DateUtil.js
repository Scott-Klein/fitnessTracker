function DayInFutureOrToday(day) {
    const now = new Date();
    now.setTime(Date.now());
    if (now.getTime() < day.getTime()) {
        return true;
    }
    else if (IsToday(day)) {
        return true;
    }
    return false;
}

function IsToday(day) {
    const now = new Date();
    now.setTime(Date.now());
    if (now.getFullYear() === day.getFullYear() && now.getMonth() === day.getMonth() && now.getDate() === day.getDate()) {
        return true;
    }
    else {
        return false
    }
}

export { DayInFutureOrToday as default}