using fitnessTracker.core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessTracker.Data
{
    public class FitnessTrackerDbContext : DbContext
    {
        public FitnessTrackerDbContext(DbContextOptions<FitnessTrackerDbContext> options)
            : base(options)
        {

        }
        public DbSet<FitnessPlan> FitnessPlans { get; set; }
        public DbSet<Profile> UserProfiles { get; set; }
    }
}
