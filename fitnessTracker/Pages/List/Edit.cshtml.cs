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
    public class EditModel : PageModel
    {
        private readonly IPlanData planData;

        [BindProperty]
        public FitnessPlan FitnessPlan { get; set; }

        public EditModel(IPlanData planData)
        {
            this.planData = planData;
        }

        public IActionResult OnGet(int? fitnessPlanId)
        {
            if (fitnessPlanId.HasValue)
            {
                FitnessPlan = planData.GetById(fitnessPlanId.Value);
            }
            else
            {
                FitnessPlan = new FitnessPlan();
                FitnessPlan.CustomerName = "New user";
            }
            if (FitnessPlan == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FitnessPlan.Id > 0)
            {
                planData.Update(FitnessPlan);
            }
            else
            {
                planData.Add(FitnessPlan);
            }
            planData.Commit();
            TempData["Message"] = "Data saved!";
            return RedirectToPage("./Detail", new { fitnessPlanId = FitnessPlan.Id });
        }
    }
}