using fitnessTracker.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using fitnessTracker.core;
using Microsoft.EntityFrameworkCore;

//[UnitOfWorkName]_[ScenarioUnderTest]_[ExpectedBehavior]

namespace FitnessTracker.Tests.Unit
{
    class SqlProfileDataTests
    {
        private SqlProfileData profileData;
        private readonly string testEmail = "test@gmail.com";
        [Test]
        public void SQLprofile_AddingProfile_ProfileInDBset()
        {
            //Arrange
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            var fakeProfile = Profile.FakeFactory("test@gmail.com");

            //Act
            profileData.Add(fakeProfile);

            var addResult = profileData.db.UserProfiles.Find(fakeProfile.Email);

            //Assert
            Assert.That(addResult, Is.Not.Null);
        }

        [Test]
        public void SQLprofile_AddingProfileByElements_ProfileInDBset()
        {
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            var fakeProfile = new Profile();
            var discExcPlans = new List<DiscreteExercisePlan>();
            discExcPlans.Add(new DiscreteExercisePlan(true));

            fakeProfile.DiscreteExercisePlans = discExcPlans;

            profileData.Add(testEmail, new DiscreteExercisePlan(true));

            var addResult = profileData.db.UserProfiles.Find(testEmail);

            Assert.That(addResult, Is.Not.Null);
        }

        [Test]
        public void SQLprofile_ProveExerciseWasAdded_ExerciseInProfile()
        {
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            var fakeProfile = new Profile();
            var discExcPlans = new List<DiscreteExercisePlan>
            {
                new DiscreteExercisePlan(true)
            };

            fakeProfile.DiscreteExercisePlans = discExcPlans;

            profileData.Add(testEmail, new DiscreteExercisePlan(true));

            var addResult = profileData.db.UserProfiles.Find(testEmail);

            Assert.That(addResult.DiscreteExercisePlans, Is.EqualTo(discExcPlans));
        }
    }
}
