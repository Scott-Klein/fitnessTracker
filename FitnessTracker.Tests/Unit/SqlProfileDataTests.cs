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
        private Profile fakeProfile;

        [Test]
        public void AddingProfile_ProfileInDBset()
        {
            //Arrange
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            fakeProfile = Profile.FakeFactory("test@gmail.com");

            //Act
            profileData.Add(fakeProfile);

            var addResult = profileData.db.UserProfiles.Find(fakeProfile.Email);

            //Assert
            Assert.That(addResult, Is.Not.Null);
        }

        [Test]
        public void AddingProfileByElements_ProfileInDBset()
        {
            //Arrange
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            fakeProfile = new Profile();
            var discExcPlans = new List<DiscreteExercisePlan>();
            discExcPlans.Add(new DiscreteExercisePlan(true));

            fakeProfile.DiscreteExercisePlans = discExcPlans;

            //Act
            profileData.Add(testEmail, new DiscreteExercisePlan(true));

            //Assert
            var addResult = profileData.db.UserProfiles.Find(testEmail);

            Assert.That(addResult, Is.Not.Null);
        }

        [Test]
        public void ProveExerciseWasAdded_ExerciseInProfile()
        {
            //Arrange
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            fakeProfile = new Profile(testEmail);
            var discExcPlans = new List<DiscreteExercisePlan>
            {
                new DiscreteExercisePlan(true)
            };

            fakeProfile.DiscreteExercisePlans = discExcPlans;

            //Act
            profileData.Add(testEmail, new DiscreteExercisePlan(true));

            //Assert
            var addResult = profileData.db.UserProfiles.Find(testEmail);

            Assert.That(addResult, Is.EqualTo(fakeProfile));
        }

        [Test]
        public void ProfileDeletes()
        {
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            var fakeProfile = new Profile(testEmail);
            var discExcPlans = new List<DiscreteExercisePlan>
            {
                new DiscreteExercisePlan(true)
            };

            fakeProfile.DiscreteExercisePlans = discExcPlans;

            profileData.Add(fakeProfile);

            var addResult = profileData.db.UserProfiles.Find(fakeProfile.Email);

            //Assert
            Assert.That(addResult, Is.Not.Null);

            profileData.Delete(fakeProfile.Email);
            
            addResult = profileData.db.UserProfiles.Find(fakeProfile.Email);

            //Assert
            Assert.That(addResult, Is.Null);
        }


        public void SetupFakeWithDb()
        {
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            fakeProfile = new Profile(testEmail);
            var discExcPlans = new List<DiscreteExercisePlan>
            {
                new DiscreteExercisePlan(true)
            };

            fakeProfile.DiscreteExercisePlans = discExcPlans;

            //Act
            profileData.Add(testEmail, new DiscreteExercisePlan(true));
        }
    }
}
