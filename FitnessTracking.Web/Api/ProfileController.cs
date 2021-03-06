﻿using fitnessTracker.core;
using fitnessTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
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
        public async Task<FitnessProfile> GetProfileDataAsync()
        {
            var userEmail = User.FindFirst(ClaimTypes.Name).Value;

            var thisUser = this.profileData.GetByEmailAddress(userEmail);

            GenerateUserProfile(userEmail, thisUser);

            return thisUser;
        }



        //Helper methods
        private void GenerateUserProfile(string userEmail, FitnessProfile thisUser)
        {
            if (thisUser == null)
            {
                CreateProfile(userEmail);
            }
            else if (thisUser.DiscreteExercisePlans.Count() == 0)
            {
                CreateExercisePlans(userEmail);
            }
        }

        private void CreateExercisePlans(string userEmail)
        {
            var exPlan = new DiscreteExercisePlan(true);
            this.profileData.Update(userEmail, exPlan);
            this.profileData.Commit();
            var result = this.profileData.GetByEmailAddress(userEmail);
        }

        private void CreateProfile(string userEmail)
        {
            var newProfile = new FitnessProfile(userEmail);
            this.profileData.Add(newProfile);
            this.profileData.Commit();
        }
    }
}
