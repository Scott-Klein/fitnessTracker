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
        Profile GetByEmailAddress(string email);
        Profile Update(Profile profile);
        Profile Update(string userEmail, DiscreteExercisePlan exercisePlan);
        bool Add(Profile profile);
        bool Add(string userEmail, DiscreteExercisePlan exercisePlan);
        bool Delete(string email);

        int GetCount();
        int Commit();
    }
}
