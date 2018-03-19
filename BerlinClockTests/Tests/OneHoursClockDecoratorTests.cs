using BerlinClock;
using NUnit.Framework;

namespace BerlinClockTests
{
    [TestFixture]
    public class OneHoursClockDecoratorTests
    {
        private OneHoursClockDecorator _sut;


        [SetUp]
        public void SeutUp()
        {
            _sut = new OneHoursClockDecorator(new Clock());
        }

        [TestCase(0, ExpectedResult = "OOOO")]
        [TestCase(1, ExpectedResult = "ROOO")]
        [TestCase(2, ExpectedResult = "RROO")]
        [TestCase(3, ExpectedResult = "RRRO")]
        [TestCase(4, ExpectedResult = "RRRR")]
        public string GetRepresentationOfClock_WhenHoursIsPass_ReturnValidRepresentation(int hours)
        {
            return _sut.GetRepresentationOfClock(TimeUtilis.GetDateTimeWithSpecificHourValue(hours));
        }
    }
}