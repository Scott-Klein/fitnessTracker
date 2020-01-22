using fitnessTracker.core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace fitnessTracker.Data
{
    public class SqlFitnessPlanData : IPlanData
    {
        private readonly FitnessTrackerDbContext db;

        public SqlFitnessPlanData(FitnessTrackerDbContext db)
        {
            this.db = db;
        }

        public FitnessPlan Add(FitnessPlan fitnessPlan)
        {
            db.Add(fitnessPlan);
            return fitnessPlan;
        }

        public int Commit()
        {
            return db.SaveChanges();  
        }

        public FitnessPlan Delete(int id)
        {
            var fitnessPlan = GetById(id);
            if (fitnessPlan != null)
            {
                db.Remove(fitnessPlan);
            }
            return fitnessPlan;
        }

        public FitnessPlan GetById(int id)
        {
            return db.FitnessPlans.Find(id);
        }

        public int GetCount()
        {
            return db.FitnessPlans.Count();
        }

        public IEnumerable<FitnessPlan> GetPlansByName(string name)
        {
            var query = from fp in db.FitnessPlans
                        where fp.CustomerName.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby fp.CustomerName
                        select fp;
            return query;
        }

        public FitnessPlan Update(FitnessPlan updatedFitnessPlan)
        {
            var entity = db.FitnessPlans.Attach(updatedFitnessPlan);
            entity.State = EntityState.Modified;
            return updatedFitnessPlan;
        }
    }
}



