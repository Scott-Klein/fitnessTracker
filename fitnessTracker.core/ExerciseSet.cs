using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace fitnessTracker.core
{
    public class ExerciseSet
    {
        [Required]
        public int Set { get; set; }

        [Required]
        public int Repetitions { get; set; }

        public int RepetitionsCompleted { get; set; }

        [Required]
        public DateTime Day { get; set; }
    }
}
