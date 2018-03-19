using BerlinClock;
using NUnit.Framework;

namespace BerlinClockTests
{
    [TestFixture]
    public class FiveMinutesClockDecoratorTests
    {
        private FiveMinutesClockDecorator _sut;


        [SetUp]
        public void SeutUp()
        {
            _sut = new FiveMinutesClockDecorator(new Clock());
        }

        [TestCase(0, ExpectedResult = "OOOOOOOOOOO")]
        [TestCase(1, ExpectedResult = "OOOOOOOOOOO")]
        [TestCase(4, ExpectedResult = "OOOOOOOOOOO")]
        [TestCase(5, ExpectedResult = "YOOOOOOOOOO")]
        [TestCase(9, ExpectedResult = "YOOOOOOOOOO")]
        [TestCase(10, ExpectedResult = "YYOOOOOOOOO")]
        [TestCase(15, ExpectedResult = "YYROOOOOOOO")]
        [TestCase(20, ExpectedResult = "YYRYOOOOOOO")]
        [TestCase(25, ExpectedResult = "YYRYYOOOOOO")]
        [TestCase(30, ExpectedResult = "YYRYYROOOOO")]
        [TestCase(35, ExpectedResult = "YYRYYRYOOOO")]
        [TestCase(40, ExpectedResult = "YYRYYRYYOOO")]
        [TestCase(45, ExpectedResult = "YYRYYRYYROO")]
        [TestCase(50, ExpectedResult = "YYRYYRYYRYO")]
        [TestCase(55, ExpectedResult = "YYRYYRYYRYY")]
        [TestCase(59, ExpectedResult = "YYRYYRYYRYY")]
        public string GetRepresentationOfClock_WhenHoursIsPass_ReturnValidRepresentation(int minute)
        {
            return _sut.GetRepresentationOfClock(TimeUtilis.GetDateTimeWithSpecificMinuteValue(minute));
        }
    }
}