using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fitnessTracker.core
{
    public class ProfileData
    {
        [Required]
        [Key]
        public string Email { get; set; }

        public IEnumerable<DiscreteExercisePlan> DiscreteExercisePlans { get; set; }
    }
}
