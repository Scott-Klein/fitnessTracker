using System;
using System.Collections.Generic;
using System.Text;
using fitnessTracker.core;
using fitnessTracker.core.ExercisePlans;
using NUnit.Framework;

namespace FitnessTracker.Tests.Unit
{
    class DiscretePlanGeneratorTests
    {
        static DateTime testDate = DateTime.Parse("01/01/2000");
        DiscreteExercisePlanOptions options = new DiscreteExercisePlanOptions
        {
            Name = "Pushups",
            Profile = FitnessProfile.FakeFactory("test@gamil.com"),
            Sets = 5,
            MaxReps = 50,
            LevelUpFrequency = 1,
            LevelUpIntensity = 1,
            StartDate = testDate,
            Days = new ExerciseDays {
                Monday = true,
                Tuesday = true,
                Wednesday = true,
                Thursday = true,
                Friday = true,
                Saturday = true,
                Sunday = true
            }
        };

        [Test]
        public void ReturnsExercisePlan()
        {
            var plan = DiscretePlanGenerator.Generate(options);

            Assert.That(plan is DiscreteExercisePlan);
        }

        [Test]
        public void ReturnsCorrectSets()
        {
            var plan = DiscretePlanGenerator.Generate(options);

            Assert.That(plan.GetSetsForDay(testDate).Count, Is.EqualTo(5));
        }

        [Test]
        public void ReturnsProgression()
        {
            var plan = DiscretePlanGenerator.Generate(options);

            var setsDay1 = plan.SetsOfExercise;

            var repsDay1 = plan.GetTotalRepsForDay(testDate.AddDays(1));
            var repsDay2 = plan.GetTotalRepsForDay(testDate.AddDays(2));

            Assert.That(repsDay1, Is.LessThan(repsDay2));
        }

        [Test]
        [TestCase(125, 5)]
        [TestCase(125, 6)]
        [TestCase(200, 5)]
        [TestCase(2, 2)]
        public void ReturnsSetsCorrectTotals(int totalBegin, int sets)
        {
            var exerciseSets = DiscretePlanGenerator.CreateSets(totalBegin, sets);
            int total = 0;

            foreach (var set in exerciseSets)
            {
                total += set.Repetitions;
            }

            Assert.That(total, Is.EqualTo(totalBegin));
            Assert.That(exerciseSets.Count, Is.EqualTo(sets));
        }

        [Test]
        public void ReturnsReasonableWeights([Range(2, 50)]int sets)
        {
            var weights = DiscretePlanGenerator.WeightGenerator(sets);

            Assert.That(weights[0], Is.EqualTo(1.0).Within(0.004));
            Assert.That(weights[sets-1], Is.EqualTo(0.3).Within(0.004));
        }

        [Test]
        public void SetsGetEasier([Range(2,50)]int sets)
        {
            var weights = DiscretePlanGenerator.WeightGenerator(sets);

            for (int i = 0; i < weights.Count; i++)
            {
                if (i != 0)
                {
                    Assert.That(weights[i], Is.LessThan(weights[i - 1]));
                }
            }
        }

        [Test]
        [TestCase(10, 9, 2)]
        [TestCase(20, 15, 1)]
        [TestCase(22, 12, 5)]
        [TestCase(10, 5, 2)]
        [TestCase(555, 55, 5)]
        public void ReturnsOnEasier(int first, int second, int third)
        {
            var set = new List<ExerciseSet>()
            {
                new ExerciseSet
                {
                    Repetitions = first
                },
                new ExerciseSet
                {
                    Repetitions = second
                },
                new ExerciseSet
                {
                    Repetitions = third
                }
            };

            Assert.That(DiscretePlanGenerator.SetsGetEasier(set));
        }

        [Test]
        [TestCase(10, 11, 12)]
        [TestCase(20, 21, 111)]
        [TestCase(15, 13, 56)]
        [TestCase(1, 5, 2)]
        [TestCase(555, 1, 5)]
        public void ReturnsFalseOnHarder(int first, int second, int third)
        {
            var set = new List<ExerciseSet>()
            {
                new ExerciseSet
                {
                    Repetitions = first
                },
                new ExerciseSet
                {
                    Repetitions = second
                },
                new ExerciseSet
                {
                    Repetitions = third
                }
            };


            Assert.That(DiscretePlanGenerator.SetsGetEasier(set), Is.False);
        }

    }
}
