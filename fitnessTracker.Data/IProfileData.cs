using System;
using System.Collections.Generic;
using System.Text;
using fitnessTracker.core;
namespace fitnessTracker.Data
{
    /// <summary>
    /// Implements returning profile data from a database
    /// </summary>
    public interface IProfileData
    {
        FitnessProfile GetByEmailAddress(string email);
        FitnessProfile Update(FitnessProfile profile);
        FitnessProfile Update(string userEmail, DiscreteExercisePlan exercisePlan);
        
        void Add(FitnessProfile profile);
        void Add(string userEmail, DiscreteExercisePlan exercisePlan);
        void Delete(string email);

        int GetCount();
        int Commit();
    }
}
