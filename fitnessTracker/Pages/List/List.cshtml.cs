using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fitnessTracker.core;
using fitnessTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace fitnessTracker
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IPlanData planData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public string Message { get; set; }
        public IEnumerable<FitnessPlan> FitnessPlans { get; set; }

        public ListModel(IConfiguration config, IPlanData planData)
        {
            this.config = config;
            this.planData = planData;
        }

        public void OnGet()
        { 
            FitnessPlans = planData.GetPlansByName(SearchTerm);
        }
    }
}