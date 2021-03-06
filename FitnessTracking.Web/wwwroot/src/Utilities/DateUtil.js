﻿function DayInFutureOrToday(day) {
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



function GetNextExercise(plan) {
    const today = Date.now();
    const nextDay = NearestDay(plan);
    const nextExerciseDay = [];
    for (let i = 0; i < plan.length; i++) {
        if (SameDay(plan[i].day, nextDay)) {
            nextExerciseDay.push(plan[i]);
        }
    }
    return nextExerciseDay;
}

function SameDay(day1, day2) {
    console.log("Day 1");
    console.log(day1);
    console.log("Day 2");
    console.log(day2);
    if (day1.getYear() === day2.getYear() && day1.getMonth() === day2.getMonth() && day1.getDate() === day2.getDate()) {
        return true;
    }
    else {
        return false;
    }
}

function NearestDay(plan) {

    let nearest = new Date(Date.now() * 2);//get a huge date
    let today = new Date(Date.now());
    for (let i = 0; i < plan.length; i++) {
        if (IsToday(plan[i].day)) {
            return today;
        }
        if (plan[i].day.getTime() < nearest.getTime()) {
            nearest = plan[i].day;
        }
    }
    return nearest;
}

function IsToday(day) {
    let today = new Date(Date.now());
    return SameDay(day, today);
}

export { DayInFutureOrToday, GetNextExercise, loadingSets };