using fitnessTracker.core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Tests.Unit
{
    class ProfileUnitTests
    {
        [Test]
        public void CompareEquality_ReturnsTrue()
        {
            var fakeProfile1 = FitnessProfile.FakeFactory("test@gmail.com");
            var fakeProfile2 = FitnessProfile.FakeFactory("test@gmail.com");

            Assert.That(fakeProfile1, Is.EqualTo(fakeProfile2));
            Assert.That(fakeProfile1.Equals(fakeProfile2), Is.True);
            Assert.That((fakeProfile1 == fakeProfile2));
        }
        [Test]
        public void CompareInEqualityReturnsTrue()
        {
            var fakeProfile1 = FitnessProfile.FakeFactory("test@gmail.com");
            var fakeProfile2 = FitnessProfile.FakeFactory("test2@gmail.com");//different profiles

            Assert.That(fakeProfile1, Is.Not.EqualTo(fakeProfile2));
            Assert.That((fakeProfile1 != fakeProfile2));
        }

        [Test]
        public void CompareEqualityFalse()
        {
            var fakeProfile1 = FitnessProfile.FakeFactory("test@gmail.com");
            var fakeProfile2 = FitnessProfile.FakeFactory("test2@gmailc.om");

            Assert.That((fakeProfile1 == fakeProfile2), Is.False);
            Assert.That(fakeProfile1.Equals(fakeProfile2), Is.False);
        }

        [Test]
        public void CompareInEqualityFalse()
        {
            var fakeProfile1 = FitnessProfile.FakeFactory("test@gmail.com");
            var fakeProfile2 = FitnessProfile.FakeFactory("test@gmail.com");

            Assert.That((fakeProfile1 != fakeProfile2), Is.False);
        }

    }
}
