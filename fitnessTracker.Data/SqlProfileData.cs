using fitnessTracker.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fitnessTracker.Data
{
    public class SqlProfileData : IProfileData
    {
        private readonly FitnessTrackerDbContext db;

        public SqlProfileData(FitnessTrackerDbContext db)
        {
            this.db = db;
        }

        public bool Add(Profile profile)
        {
            db.Add(profile);
            return true;
        }

        public bool Add(string userEmail, DiscreteExercisePlan exercisePlan)
        {
            var userProfile = db.UserProfiles.Find(userEmail);
            List<DiscreteExercisePlan> exPlans;
            if (userProfile.DiscreteExercisePlans == null)
            {
                userProfile.DiscreteExercisePlans = new List<DiscreteExercisePlan>();
                exPlans = userProfile.DiscreteExercisePlans.ToList();
            } else
            {
                exPlans = userProfile.DiscreteExercisePlans.ToList();
            }

            exPlans.Add(exercisePlan);
            userProfile.DiscreteExercisePlans = exPlans;
            if(Update(userProfile) != null)
            {
                return true;
            } else
            {
                return false;
            }
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

        public Profile GetByEmailAddress(string email)
        {
            return db.UserProfiles.Find(email);
        }

        public int GetCount()
        {
            return db.UserProfiles.Count();
        }

        public Profile Update(Profile profile)
        {
            var entity = db.UserProfiles.Attach(profile);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return profile;
        }

        public Profile Update(string userEmail, DiscreteExercisePlan exercisePlan)
        {
            var userProfile = db.UserProfiles.Find(userEmail);
            var planList = userProfile.DiscreteExercisePlans.ToList();
            var discreteExercisePlan = planList.Find(dep => dep.id == exercisePlan.id);
            planList.Add(exercisePlan);
            userProfile.DiscreteExercisePlans = planList;
            return Update(userProfile);
        }
    }
}
