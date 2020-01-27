using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Tests
{

    class HelloNunit
    {
        [Test]
        public void TestsNunit()
        {
            var varUnderTest = true;

            Assert.That(varUnderTest, Is.EqualTo(true));
        }
    }
}
