using fitnessTracker.core;
using fitnessTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FitnessTracking.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        //private readonly FitnessTrackerDbContext _context;

        private readonly IProfileData profileData;

        public ProfileController(IProfileData profileData)
        {
            //_context = context;
            this.profileData = profileData;
        }

        // GET: api/Profile
        [HttpGet]
        public Profile GetProfileDataAsync()
        {
            var userEmail = User.FindFirst(ClaimTypes.Name).Value;

            var thisUser = this.profileData.GetByEmailAddress(userEmail);

            GenerateUserProfile(userEmail, thisUser);

            return thisUser;
        }



        //Helper methods
        private void GenerateUserProfile(string userEmail, Profile thisUser)
        {
            if (thisUser == null)
            {
                CreateProfile(userEmail);
            }
            if (thisUser.DiscreteExercisePlans == null)
            {
                CreateExercisePlans(userEmail);
            }
        }

        private void CreateExercisePlans(string userEmail)
        {
            var exPlan = new DiscreteExercisePlan(true);
            this.profileData.Update(userEmail, exPlan);
            this.profileData.Commit();
        }

        private void CreateProfile(string userEmail)
        {
            var newProfile = new Profile(userEmail);
            this.profileData.Add(newProfile);
            this.profileData.Commit();
        }
    }
}
