using System;
using BerlinClock;
using NUnit.Framework;

namespace BerlinClockTests
{
    [TestFixture]
    public class SecondsClockDecoratorTests
    {
        private SecondsClockDecorator _sut;

        [SetUp]
        public void SeutUp()
        {
            _sut = new SecondsClockDecorator(new Clock());
        }

        [TestCase(0, ExpectedResult = "Y")]
        [TestCase(1, ExpectedResult = "O")]
        [TestCase(59, ExpectedResult = "O")]
        public string GetRepresentationOfClock_ReturnRightValueBasedOnSeconds(int seconds)
        {
            var time = TimeUtilis.GetDateTimeWithSpecificSecondValue(seconds);

            return _sut.GetRepresentationOfClock(time);
        }

       
    }
}