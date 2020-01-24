using System;

namespace fitnessTracker.core
{
    public interface IExerciseSet
    {
        public int SetNumber { get; set; }
        public int Repetitions { get; set; }
        public int RepetitionsCompleted { get; set; }
        public DateTime Day { get; set; }
    }
}