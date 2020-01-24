using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace fitnessTracker.core
{
    public class DiscreteExercisePlan
    {
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
