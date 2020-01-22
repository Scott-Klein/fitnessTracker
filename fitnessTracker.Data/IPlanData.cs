using System.Collections.Generic;
using System.Text;
using fitnessTracker.core;

namespace fitnessTracker.Data
{
    public interface IPlanData
    {
        IEnumerable<FitnessPlan> GetPlansByName(string name);
        FitnessPlan GetById(int id);
        FitnessPlan Update(FitnessPlan updatedFitnessPlan);
        FitnessPlan Add(FitnessPlan fitnessPlan);
        FitnessPlan Delete(int id);
        int GetCount();
        int Commit();
    }
}



