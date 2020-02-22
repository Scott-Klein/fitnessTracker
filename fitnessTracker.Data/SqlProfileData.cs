using fitnessTracker.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fitnessTracker.Data
{
    public class SqlProfileData : IProfileData
    {
        private readonly FitnessTrackerDbContext _db;

        public FitnessTrackerDbContext db
        {
            get
            {
                return _db;
            }
            set => throw new AccessViolationException();
        }

        public SqlProfileData(FitnessTrackerDbContext db)
        {
            this._db = db;
        }

        public void Add(FitnessProfile profile)
        {
            db.Add(profile);
        }

        //if the profile already exists call the more appropriate update function instead.
        public void Add(string userEmail, DiscreteExercisePlan exercisePlan)
        {
            var userProfile = db.UserProfiles.Find(userEmail);
            if (userProfile != null)
            {
                Update(userEmail, exercisePlan);
            }
            else
            {
                userProfile = new FitnessProfile(userEmail);
                var exPlans = new List<DiscreteExercisePlan>();
                exPlans.Add(exercisePlan);
                userProfile.DiscreteExercisePlans = exPlans;

                Add(userProfile);
            }
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Delete(string email)
        {
            var profile = GetByEmailAddress(email);
            if (profile != null)
            {
                db.Remove(profile);
            }
        }

        public FitnessProfile GetByEmailAddress(string email)
        {
            var result = db.UserProfiles.Find(email);
            
            var allPlans = db.DiscreteExercisePlans.ToList();
            var allSets = db.ExerciseSets.ToList();
            return result;
        }

        public int GetCount()
        {
            return db.UserProfiles.Local.Count;
        }

        public FitnessProfile Update(FitnessProfile profile)
        {
            var entity = db.UserProfiles.Attach(profile);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return profile;
        }

        public FitnessProfile Update(string userEmail, DiscreteExercisePlan exercisePlan)
        {
            var userProfile = db.UserProfiles.Find(userEmail);
            if (userProfile.DiscreteExercisePlans.Count() == 0)
            {
                InsertNewExercisePlan(exercisePlan, userProfile);
            }
            else
            {
                UpdateExistingPlan(exercisePlan, userProfile);
            }
            return Update(userProfile);
        }


        //Helper methods
        private static void UpdateExistingPlan(DiscreteExercisePlan exercisePlan, FitnessProfile userProfile)
        {
            var planList = userProfile.DiscreteExercisePlans.ToList();
            var discreteExercisePlan = planList.Find(dep => dep.id == exercisePlan.id);

            if (discreteExercisePlan != null)
            {
                planList[planList.IndexOf(discreteExercisePlan)] = exercisePlan;
            } else
            {
                planList.Add(exercisePlan);
            }
            userProfile.DiscreteExercisePlans = planList;
        }

        private static void InsertNewExercisePlan(DiscreteExercisePlan exercisePlan, FitnessProfile userProfile)
        {
            var exercises = new List<DiscreteExercisePlan>();
            exercises.Add(exercisePlan);
            userProfile.DiscreteExercisePlans = exercises;
        }
    }
}
