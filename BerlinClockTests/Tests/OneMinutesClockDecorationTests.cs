using BerlinClock;
using NUnit.Framework;

namespace BerlinClockTests
{
    [TestFixture]
    public class OneMinutesClockDecorationTests
    {
        private OneMinutesClockDecorator _sut;

        [SetUp]
        public void SeutUp()
        {
            _sut = new OneMinutesClockDecorator(new Clock());
        }

        [TestCase(0, ExpectedResult = "OOOO")]
        [TestCase(1, ExpectedResult = "YOOO")]
        [TestCase(2, ExpectedResult = "YYOO")]
        [TestCase(3, ExpectedResult = "YYYO")]
        [TestCase(4, ExpectedResult = "YYYY")]
        [TestCase(5, ExpectedResult = "OOOO")]
        [TestCase(59, ExpectedResult = "YYYY")]
        public string GetRepresentationOfClock_WhenHoursIsPass_ReturnValidRepresentation(int hours)
        {
            return _sut.GetRepresentationOfClock(TimeUtilis.GetDateTimeWithSpecificMinuteValue(hours));
        }
    }
}