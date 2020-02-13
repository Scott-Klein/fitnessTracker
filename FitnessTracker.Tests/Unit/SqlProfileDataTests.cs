using fitnessTracker.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using fitnessTracker.core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

//[UnitOfWorkName]_[ScenarioUnderTest]_[ExpectedBehavior]

namespace FitnessTracker.Tests.Unit
{
    class SqlProfileDataTests
    {
        private SqlProfileData profileData;
        private readonly string testEmail = "test@gmail.com";
        private FitnessProfile fakeProfile;

        [Test]
        public void AddingProfile_ProfileInDBset()
        {
            //Arrange
            SetupFakeWithDb();

            var addResult = profileData.db.UserProfiles.Find(fakeProfile.Email);

            //Assert
            Assert.That(addResult, Is.Not.Null);
        }

        [Test]
        public void AddingProfileByElements_ProfileInDBset()
        {
            //Arrange
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());

            fakeProfile = new FitnessProfile();
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
            SetupFakeWithDb();
            //Assert
            var addResult = profileData.db.UserProfiles.Find(testEmail);

            Assert.That(addResult, Is.EqualTo(fakeProfile));
        }

        [Test]
        public void ProfileDeletes()
        {
            SetupFakeWithDb();

            var addResult = profileData.db.UserProfiles.Find(fakeProfile.Email);

            //Assert the profile exists before deleting it.
            Assert.That(addResult, Is.Not.Null);

            profileData.Delete(fakeProfile.Email);
            
            addResult = profileData.db.UserProfiles.Find(fakeProfile.Email);

            //Assert the profile is gone.
            Assert.That(addResult, Is.Null);
        }

        [Test]
        public void GetsProfileCount()
        {
            SetupFakeWithDb();
            profileData.Add("test2@gmail.com", new DiscreteExercisePlan(true));
            Assert.That(profileData.GetCount(), Is.EqualTo(2));
            profileData.Add("test3@gmail.com", new DiscreteExercisePlan(true));
            Assert.That(profileData.GetCount(), Is.EqualTo(3));
        }

        [Test]
        public void UpdatesProfile()
        {
            SetupFakeWithDb();
            var fakeExerciseList = fakeProfile.DiscreteExercisePlans.ToList();
            fakeExerciseList.Add(new DiscreteExercisePlan(true));
            fakeProfile.DiscreteExercisePlans = fakeExerciseList;
            var updatedProfile = profileData.Update(fakeProfile);
            Assert.That(fakeProfile, Is.EqualTo(updatedProfile));
        }

        [Test]
        public void UpdatesProfile_byEmailAndPlan()
        {
            SetupFakeWithDb();

            var fakeExerciseList = fakeProfile.DiscreteExercisePlans.ToList();

            fakeExerciseList.Add(new DiscreteExercisePlan(true));

            fakeProfile.DiscreteExercisePlans = fakeExerciseList;

            var updatedProfile = profileData.Update(fakeProfile.Email, new DiscreteExercisePlan(true));

            Assert.That(fakeProfile, Is.EqualTo(updatedProfile));
        }
        //Gives you a fake in memory db with a fake profile ready to go.
        public void SetupFakeWithDb()
        {
            profileData = new SqlProfileData(FitnessTrackerDbContext.MockDBContextFactory());
            fakeNewProfile();

            //Act
            profileData.Add(fakeProfile);
        }

        private void fakeNewProfile()
        {
            fakeProfile = new FitnessProfile(testEmail);
            var discExcPlans = new List<DiscreteExercisePlan>
            {
                new DiscreteExercisePlan(true)
            };

            fakeProfile.DiscreteExercisePlans = discExcPlans;
        }
    }
}
