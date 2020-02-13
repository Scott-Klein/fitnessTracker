using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace fitnessTracker.core
{
    public class FitnessProfile : IProfile, IEquatable<FitnessProfile>
    {
        public FitnessProfile()
        {
            this.DiscreteExercisePlans = new List<DiscreteExercisePlan>();
        }

        public FitnessProfile(string Email)
        {
            this.DiscreteExercisePlans = new List<DiscreteExercisePlan>();
            this.Email = Email;
        }

        [Key]
        public string Email { get; set; }

        public IEnumerable<DiscreteExercisePlan> DiscreteExercisePlans { get; set; }

        #region equaity
        //Equality Overrides
        public override bool Equals(object obj)
        {
            if (obj is FitnessProfile)
                return Equals(obj as FitnessProfile);
            else
                return false;
        }

        public bool Equals(FitnessProfile other)
        {
            if (object.Equals(other, null))
            {
                return false;
            }
            if (other.Email == this.Email)
            {
                var intersection = ThisProfileIntersectsExercises(other);
                if (intersection.Count == this.DiscreteExercisePlans.Count())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(FitnessProfile lhs, FitnessProfile rhs)
        {
            if (!object.Equals(lhs, null))
            {
                return lhs.Equals(rhs);
            } else if (object.Equals(lhs, null) && object.Equals(rhs, null))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool operator !=(FitnessProfile lhs, FitnessProfile rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode() ^ DiscreteExercisePlans.GetHashCode();
        }

        private List<DiscreteExercisePlan> ThisProfileIntersectsExercises(FitnessProfile other)
        {
            var intersection = new List<DiscreteExercisePlan>();

            var thisDiscreteExcList = this.DiscreteExercisePlans.ToList();
            var otherDiscreteExcList = other.DiscreteExercisePlans.ToList();

            foreach (var ex1 in thisDiscreteExcList)
            {
                foreach (var ex2 in otherDiscreteExcList)
                {
                    if (ex1 == ex2)
                    {
                        intersection.Add(ex1);
                    }
                }
            }
            return intersection;
        }
        
        
        //This creates a functional fake profile with a fake DiscreteExercisePlan.
        public static FitnessProfile FakeFactory(string Email)
        {
            FitnessProfile fake = new FitnessProfile(Email);
            var discreteFake = new DiscreteExercisePlan(true);
            var discreteList = new List<DiscreteExercisePlan>();
            discreteList.Add(discreteFake);
            fake.DiscreteExercisePlans = discreteList;
            return fake;
        }
        #endregion
    }
}
