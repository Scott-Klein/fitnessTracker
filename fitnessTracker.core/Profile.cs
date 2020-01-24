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



        [Key]
        public string Email { get; set; }

        public IEnumerable<DiscreteExercisePlan> DiscreteExercisePlans { get; set; }
    }
}
