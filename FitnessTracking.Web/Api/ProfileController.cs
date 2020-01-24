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
            // The logged in users email address
            var userEmail = User.FindFirst(ClaimTypes.Name).Value;

            var thisUser = this.profileData.GetByEmailAddress(userEmail);
            

            //if the user doesn't have a profile automatically generate it.
            if (thisUser == null)
            {
                var newProfile = new Profile(userEmail);
                _ = this.profileData.Add(newProfile);
                _ = this.profileData.Commit();
            }
            return thisUser;
        }

    }
}
