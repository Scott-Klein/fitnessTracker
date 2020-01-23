using fitnessTracker.core;
using fitnessTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FitnessTracking.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly FitnessTrackerDbContext _context;

        public ProfileController(FitnessTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileData>>> GetProfileDataAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

    }
}
