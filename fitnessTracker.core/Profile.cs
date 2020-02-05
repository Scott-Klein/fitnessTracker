﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace fitnessTracker.core
{
    public class Profile : IProfile, IEquatable<Profile>
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

        //Equality Overrides
        public override bool Equals(object obj)
        {
            if (obj is Profile)
                return Equals(obj as Profile);
            else
                return false;
        }

        public bool Equals(Profile other)
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

        public static bool operator ==(Profile lhs, Profile rhs)
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

        public static bool operator !=(Profile lhs, Profile rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode() ^ DiscreteExercisePlans.GetHashCode();
        }

        private List<DiscreteExercisePlan> ThisProfileIntersectsExercises(Profile other)
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
    }
}
