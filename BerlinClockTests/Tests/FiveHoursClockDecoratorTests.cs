using BerlinClock;
using NUnit.Framework;

namespace BerlinClockTests
{
    public class FiveHoursClockDecoratorTests
    {
        private FiveHoursClockDecorator _sut;


        [SetUp]
        public void SeutUp()
        {
            _sut = new FiveHoursClockDecorator(new Clock());
        }

        [TestCase(0, ExpectedResult = "OOOO")]
        [TestCase(1, ExpectedResult = "OOOO")]
        [TestCase(4, ExpectedResult = "OOOO")]
        [TestCase(5, ExpectedResult = "ROOO")]
        [TestCase(6, ExpectedResult = "ROOO")]
        [TestCase(10, ExpectedResult = "RROO")]
        [TestCase(11, ExpectedResult = "RROO")]
        [TestCase(15, ExpectedResult = "RRRO")]
        [TestCase(16, ExpectedResult = "RRRO")]
        [TestCase(20, ExpectedResult = "RRRR")]
        [TestCase(24, ExpectedResult = "RRRR")]
        public string GetRepresentationOfClock_WhenHoursIsPass_ReturnValidRepresentation(int hours)
        {
            return _sut.GetRepresentationOfClock(TimeUtilis.GetDateTimeWithSpecificHourValue(hours));
        }

    }
}