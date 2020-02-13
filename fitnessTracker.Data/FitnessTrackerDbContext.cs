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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        public DbSet<FitnessPlan> FitnessPlans { get; set; }
        public DbSet<FitnessProfile> UserProfiles { get; set; }
        public DbSet<DiscreteExercisePlan> DiscreteExercisePlans { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }


        public static FitnessTrackerDbContext MockDBContextFactory()
        {
            var options = new DbContextOptionsBuilder<FitnessTrackerDbContext>().UseInMemoryDatabase(databaseName: "FakeDatabase").Options;

            return new FitnessTrackerDbContext(options);
            
        }
    }
}
