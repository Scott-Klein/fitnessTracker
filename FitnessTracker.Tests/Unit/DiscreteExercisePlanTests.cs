using System;
using System.Collections.Generic;
using System.Text;
using fitnessTracker.core;
using NUnit.Framework;
namespace FitnessTracker.Tests.Unit
{
    
    class DiscreteExercisePlanTests
    {
        [Test]
        public void GetSetsForDay_Returns1()
        {
            var plan = new DiscreteExercisePlan(true);

            var list = plan.GetSetsForDay(DateTime.Parse("01/01/2000"));
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetSetsForDay_Returns2()
        {
            var plan = new DiscreteExercisePlan(true);

            plan.SetsOfExercise.Add(ExerciseSet.FakeFactory());

            var list = plan.GetSetsForDay(DateTime.Parse("01/01/2000"));
            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetTotalRepsForDay()
        {
            var plan = new DiscreteExercisePlan(true);

            Assert.That(plan.GetTotalRepsForDay(DateTime.Parse("01/01/2000")), Is.EqualTo(50));

            plan.SetsOfExercise.Add(ExerciseSet.FakeFactory());
            Assert.That(plan.GetTotalRepsForDay(DateTime.Parse("01/01/2000")), Is.EqualTo(55));
        }
    }
}
