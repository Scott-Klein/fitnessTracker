using System;
using System.Collections.Generic;
using System.Text;
using fitnessTracker.core;
namespace fitnessTracker.Data
{
    /// <summary>
    /// Implements returning profile data from a database
    /// </summary>
    interface IProfileData
    {
        ProfileData GetByEmailAddress(string email);
        ProfileData Update(ProfileData profile);
        bool Add(ProfileData profile);
        bool Delete(string email);

        int GetCount();
        int Commit();
    }
}
