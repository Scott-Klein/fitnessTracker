using fitnessTracker.core.ExercisePlans;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessTracker.core
{
    public static class TestInput
    {
        public static DateTime testDate = DateTime.Parse("01/01/2000");

        #region testOptions
        public static DiscreteExercisePlanOptions TestOptions = new DiscreteExercisePlanOptions
        {
            Name = "Pushups",
            Profile = FitnessProfile.FakeFactory("test@gamil.com"),
            Sets = 5,
            MaxReps = 50,
            LevelUpFrequency = 1,
            LevelUpIntensity = 1,
            StartDate = TestInput.testDate,
            Days = new ExerciseDays
            {
                Monday = true,
                Tuesday = true,
                Wednesday = true,
                Thursday = true,
                Friday = true,
                Saturday = true,
                Sunday = true
            }
        };
        #endregion
    }
}
