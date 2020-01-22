using System;
using System.Collections.Generic;
using fitnessTracker.core;
using System.Linq;

namespace fitnessTracker.Data
{
    public class InMemoryFitnessPlanData : IPlanData
    {
        List<FitnessPlan> fitnessPlans;

        public InMemoryFitnessPlanData()
        {
            fitnessPlans = new List<FitnessPlan>()
            {
                new FitnessPlan { Id = 1, CustomerName = "Scott Klein", Pushups = 50 },
                new FitnessPlan { Id = 2, CustomerName = "Jenny Craig", Pushups =25 },
                new FitnessPlan { Id = 3, CustomerName = "Donald Thomas", Pushups = 10 }
            };
        }

        public FitnessPlan Add(FitnessPlan fitnessPlan)
        {
            fitnessPlan.Id = fitnessPlans.Max(f => f.Id) + 1;
            fitnessPlans.Add(fitnessPlan);
            return fitnessPlan;
        }

        public int Commit()
        {
            return 0;
        }

        public FitnessPlan Delete(int id)
        {
            var fitnessPlan = fitnessPlans.FirstOrDefault(fp => fp.Id == id);
            if (fitnessPlan != null)
            {
                fitnessPlans.Remove(fitnessPlan);
            }
            return fitnessPlan;
        }

        public FitnessPlan GetById(int id)
        {
            return fitnessPlans.SingleOrDefault(r => r.Id == id);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FitnessPlan> GetPlansByName(string name = null)
        {
            return from fp in fitnessPlans
                   where string.IsNullOrEmpty(name) || fp.CustomerName.Contains(name)
                   orderby fp.CustomerName
                   select fp;
        }

        public FitnessPlan Update(FitnessPlan updatedFitnessPlan)
        {
            var fitnessPlan = fitnessPlans.SingleOrDefault(fp => fp.Id == updatedFitnessPlan.Id);
            if (fitnessPlan != null)
            {
                fitnessPlan.CustomerName = updatedFitnessPlan.CustomerName;
                fitnessPlan.Pushups = updatedFitnessPlan.Pushups;
            }
            return fitnessPlan;
        }
    }

}



