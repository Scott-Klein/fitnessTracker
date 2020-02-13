using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessTracker.core.ExercisePlans
{
    public struct DiscreteExercisePlanOptions : IEquatable<DiscreteExercisePlanOptions>
    {
        public string Name { get; set; }
        public FitnessProfile Profile { get; set; }
        public int Sets { get; set; }
        public int MaxReps { get; set; }
        public int LevelUpFrequency { get; set; }
        public int LevelUpIntensity { get; set; }



        #region Equality Overides
        public override bool Equals(object obj)
        {
            return obj is DiscreteExercisePlanOptions && this == (DiscreteExercisePlanOptions)obj;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Sets.GetHashCode() ^ MaxReps.GetHashCode() ^ LevelUpFrequency.GetHashCode() ^ LevelUpIntensity.GetHashCode();
        }

        public static bool operator ==(DiscreteExercisePlanOptions left, DiscreteExercisePlanOptions right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiscreteExercisePlanOptions left, DiscreteExercisePlanOptions right)
        {
            return !(left == right);
        }

        public bool Equals(DiscreteExercisePlanOptions other)
        {
            if (this.Name != other.Name)
            {
                return false;
            }
            if (this.Sets != other.Sets)
            {
                return false;
            }
            if (this.MaxReps != other.MaxReps)
            {
                return false;
            }
            if (this.LevelUpFrequency != other.LevelUpFrequency)
            {
                return false;
            }
            if (this.LevelUpIntensity != other.LevelUpIntensity)
            {
                return false;
            }
            if (this.Profile != other.Profile)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
