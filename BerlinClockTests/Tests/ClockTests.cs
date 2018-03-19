using BerlinClock;
using NUnit.Framework;

namespace BerlinClockTests
{
    [TestFixture]
    public class ClockTests
    {
        private Clock _sut;

        [SetUp]
        public void SeutUp()
        {
            _sut = new Clock();
        }

        [TestCase("TestClockRepresentation")]
        [TestCase(null)]
        [TestCase("")]
        public void GetRepresentationOfClock_ReturnWholeClockRepresentationValue(string clockRepresentation)
        {
            _sut.ClockRepresentation = clockRepresentation;
            Assert.AreEqual(clockRepresentation, _sut.GetRepresentationOfClock(new BerlinClock.Entities.Time(12, 12, 12)));
        }
    }
}