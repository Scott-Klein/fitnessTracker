using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessTracker.core
{
    public interface IDiscreteExercisePlan
    {
        List<IExerciseSet> GetSetsForDay(DateTime forDate);
    }
}
