using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace fitnessTracker.core
{
    public class DiscreteExercisePlan : IEquatable<DiscreteExercisePlan>
    {
        public DiscreteExercisePlan()
        {

        }

        public DiscreteExercisePlan(bool randomGenerate)
        {
            this.Name = "Randomised Exercise";
            SetsOfExercise = new List<ExerciseSet>();
            var set = new ExerciseSet();
            set.Day = DateTime.Now;
            set.Repetitions = 50;
            set.RepetitionsCompleted = 25;
            set.SetNumber = 1;
            SetsOfExercise.Add(set);
        }

        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        List<ExerciseSet> SetsOfExercise;

        public List<ExerciseSet> GetSetsForDay(DateTime day)
        {
            var query = from S in SetsOfExercise
                        where S.Day.Date == day.Date
                        select S;
            return query.ToList();
        }

        //Equality
        public override bool Equals(object obj) => Equals(obj as DiscreteExercisePlan);

        public bool Equals(DiscreteExercisePlan other)
        {

            if (this.Name == other.Name)
            {
                if (this.SetsOfExercise.Count == other.SetsOfExercise.Count)
                {
                    List<ExerciseSet> intersection = ThisPlanIntersectsWith(other);

                    if (intersection.Count == this.SetsOfExercise.Count && intersection.Count == other.SetsOfExercise.Count)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private List<ExerciseSet> ThisPlanIntersectsWith(DiscreteExercisePlan other)
        {
            //Find the intersection of .this and .other
            var intersection = new List<ExerciseSet>();
            foreach (var set in this.SetsOfExercise)
            {
                foreach (var set2 in other.SetsOfExercise)
                {
                    if (set == set2)
                    {
                        intersection.Add(set);
                    }
                }
            }
            return intersection;
        }


        public static bool operator ==(DiscreteExercisePlan lhs, DiscreteExercisePlan rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(DiscreteExercisePlan lhs, DiscreteExercisePlan rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return id.ToString().GetHashCode() ^ this.Name.GetHashCode();
        }
    }


}
