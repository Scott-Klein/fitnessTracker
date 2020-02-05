using System;
using System.Collections.Generic;
using System.Text;
using fitnessTracker.core;
using NUnit.Framework;

namespace FitnessTracker.Tests.Unit
{
    class ExerciseSetTests
    {
        [Test]
        public void CompareEquality_ReturnsTrue()
        {
            var fake1 = ExerciseSet.FakeFactory();
            var fake2 = ExerciseSet.FakeFactory();

            Assert.That(fake1, Is.EqualTo(fake2));
            Assert.That((fake1 == fake2), Is.True);
        }

        [Test]
        public void CompareObjectEquals_ReturnsTrue()
        {
            var fake1 = ExerciseSet.FakeFactory();
            var fake2 = ExerciseSet.FakeFactory();

            Assert.That(fake1.Equals(fake2), Is.True);
        }

        [Test]
        public void CompareInequality_ReturnsTrue()
        {
            var fake1 = ExerciseSet.FakeFactory();
            var fake2 = ExerciseSet.FakeFactory();
            fake2.Repetitions = fake1.Repetitions + 1; // Make fake 2 different.

            Assert.That(fake1 != fake2, Is.True);
        }

        [Test]
        public void CompareEqualityFalse_ReturnsFalse()
        {
            var fake1 = ExerciseSet.FakeFactory();
            var fake2 = ExerciseSet.FakeFactory();

            fake2.Repetitions = fake1.Repetitions + 1;

            Assert.That((fake1 == fake2), Is.False);
        }

        [Test]
        public void CompareInEqaulityFalse_ReturnsFalse()
        {
            var fake1 = ExerciseSet.FakeFactory();
            var fake2 = ExerciseSet.FakeFactory();

            Assert.That((fake1 != fake2), Is.False);
        }

        [Test]
        public void CompareObjectEqualityFalse_ReturnsFalse()
        {
            var fake1 = ExerciseSet.FakeFactory();
            var fake2 = ExerciseSet.FakeFactory();
            fake2.Repetitions = fake1.Repetitions + 1;
            Assert.That(fake1.Equals(fake2), Is.False);
        }
    }
}
