using System;
using System.Collections.Generic;
using System.Text;
using fitnessTracker.core;
using NUnit.Framework;

namespace FitnessTracker.Tests.Unit
{
    class DiscretePlanGeneratorTests
    {
        [Test]
        public void ReturnsExercisePlan()
        {
            var plan = DiscretePlanGenerator.Generate("Pushups", FitnessProfile.FakeFactory("fake@gmail.com"), 5, 50);

            Assert.That(plan is DiscreteExercisePlan);
        }
    }
}
