using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fitnessTracker.core
{
    public class Profile : IProfile
    {
        public Profile()
        {

        }

        public Profile(string Email)
        {
            this.Email = Email;
        }

        //This creates a functional fake profile with a fake DiscreteExercisePlan.
        public static Profile FakeFactory(string Email)
        {
            Profile fake = new Profile(Email);
            var discreteFake = new DiscreteExercisePlan(true);
            var discreteList = new List<DiscreteExercisePlan>();
            discreteList.Add(discreteFake);
            fake.DiscreteExercisePlans = discreteList;
            return fake;
        }

        [Key]
        public string Email { get; set; }

        public IEnumerable<DiscreteExercisePlan> DiscreteExercisePlans { get; set; }
    }
}
