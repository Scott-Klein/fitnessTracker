using fitnessTracker.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fitnessTracker.ViewComponents
{
    public class FitnessPlanCountViewComponent : ViewComponent
    {
        private IPlanData planData;

        public FitnessPlanCountViewComponent(IPlanData planData)
        {
            this.planData = planData;
        }

        public IViewComponentResult Invoke()
        {
            var count = planData.GetCount();

            return View(count);
        }
    }
}
