using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace fitnessTracker.core
{
    public class ExerciseSet : IEquatable<ExerciseSet>
    {
        public int Id { get; set; }

        [Required]
        public int SetNumber { get; set; }

        [Required]
        public int Repetitions { get; set; }

        public int RepetitionsCompleted { get; set; }

        [Required]
        public DateTime Day { get; set; }

        //Navigation property
        [JsonIgnore]
        public DiscreteExercisePlan DiscreteExercisePlan { get; set; }

        public override bool Equals(object obj)
        {

            if (obj is ExerciseSet)
                return base.Equals(obj);
            else
                return false;
        }

        public bool Equals(ExerciseSet other)
        {
            if (this.SetNumber == other.SetNumber)
            {
                if (this.Repetitions == other.Repetitions)
                {
                    if (this.RepetitionsCompleted == other.RepetitionsCompleted)
                    {
                        if (this.Day.ToShortDateString() == other.Day.ToShortDateString())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool operator ==(ExerciseSet lhs, ExerciseSet rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ExerciseSet lhs, ExerciseSet rhs)
        {
            return !(lhs == rhs);
        }

        public static ExerciseSet FakeFactory()
        {
            ExerciseSet set = new ExerciseSet();
            //Fake data can be any magic numbers
            set.Day = DateTime.Parse("1/1/2000");
            set.Repetitions = 5;
            set.RepetitionsCompleted = 2;
            set.SetNumber = 1;
            return set;
        }
    }
}
