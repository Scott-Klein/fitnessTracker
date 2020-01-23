using fitnessTracker.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessTracker.Data
{
    class SqlProfileData : IProfileData
    {
        private readonly FitnessTrackerDbContext db;

        public SqlProfileData(FitnessTrackerDbContext db)
        {
            this.db = db;
        }

        public bool Add(ProfileData profile)
        {
            db.Add(profile);
            return true;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public bool Delete(string email)
        {
            var profile = GetByEmailAddress(email);
            if (profile != null)
            {
                db.Remove(profile);
            }
            else
            {
                return false;
            }
            return true;
        }

        public ProfileData GetByEmailAddress(string email)
        {
            return db.UserProfiles.Find(email);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public ProfileData Update(ProfileData profile)
        {
            throw new NotImplementedException();
        }
    }
}
