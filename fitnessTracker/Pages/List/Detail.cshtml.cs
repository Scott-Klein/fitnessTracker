using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fitnessTracker.core;
using fitnessTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fitnessTracker
{
    public class DetailModel : PageModel
    {
        public FitnessPlan FitnessPlan { get; set; }

        [TempData]
        public string Message { get; set; }

        private readonly IPlanData planData;

        public DetailModel(IPlanData planData)
        {
            this.planData = planData;
        }

        public IActionResult OnGet(int fitnessPlanId)
        {
            FitnessPlan = planData.GetById(fitnessPlanId);
            if (FitnessPlan == null)
            {
                return Redirect("../NotFound");
            }
            return Page();
        }
    }
}