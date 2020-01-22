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
    public class DeleteModel : PageModel
    {
        private readonly IPlanData planData;

        public FitnessPlan FitnessPlan { get; set; }

        public DeleteModel(IPlanData planData)
        {
            this.planData = planData;
        }

        public IActionResult OnGet(int fitnessPlanId)
        {
            FitnessPlan = planData.GetById(fitnessPlanId);
            if (FitnessPlan == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int fitnessPlanId)
        {
            var plan = planData.Delete(fitnessPlanId);
            planData.Commit();

            if (plan == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = "Fitness Plan Deleted";
            return RedirectToPage("./List");
        }
    }
}