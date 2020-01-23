using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessTracker.core
{
    public interface IDiscreteExercisePlan
    {
        IEnumerable<int> GetForDay(DateTime forDate);
        IEnumerable<int> GetRemaining();
        int GetSetsForDay(DateTime forDate);
        int GetTodayTotal();
        int GetSets();
        bool SplitSet(int setId);
        bool CombineSets(int firstSet, int secondSet);
        bool CompleteSet(int setId);
        bool PartialSet(int setId, int value);
    }
}
