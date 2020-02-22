using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using fitnessTracker.core;
using fitnessTracker.core.ExercisePlans;
using fitnessTracker.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracking.Web.Api.Exercise
{
    [Route("profile/api/[controller]")]
    [ApiController]
    public class DiscreteExerciseController : ControllerBase
    {

        private readonly IProfileData profileData;

        public DiscreteExerciseController(IProfileData profileData)
        {
            this.profileData = profileData;
        }

        [HttpPost]
        public async Task<IActionResult> PostExercise([FromForm]DiscreteExercisePlanOptions options)
        {
            if (options == null)
            {
                return this.StatusCode(500);
            }

            var userEmail = User.FindFirst(ClaimTypes.Name).Value;
            var thisUser = this.profileData.GetByEmailAddress(userEmail);
            options.Profile = thisUser;
            var exercisePlan = DiscretePlanGenerator.Generate(options);
            profileData.Add(userEmail, exercisePlan);
            profileData.Commit();
            return LocalRedirect("~/index");
        }
    }
}