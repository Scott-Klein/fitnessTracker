using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace fitnessTracker.core
{
    public class DiscreteExercisePlan
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


    }
        

}
