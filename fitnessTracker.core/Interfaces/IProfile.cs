using System.Collections.Generic;

namespace fitnessTracker.core
{
    public interface IProfile
    {
        public string Email { get; set; }

        public IEnumerable<DiscreteExercisePlan> DiscreteExercisePlans { get; set; }
    }
}