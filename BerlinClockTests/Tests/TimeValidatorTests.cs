using System;
using BerlinClock.Entities;
using BerlinClock.Interfaces;
using BerlinClock.Validators;
using Moq;
using NUnit.Framework;

namespace BerlinClockTests
{
    [TestFixture]
    public class TimeValidatorTests
    {
        private Mock<ITimeParser> _timeParser;
        private TimeValidator _sut;

        private string[] _testFormats;

        [SetUp]
        public void SeutUp()
        {
            _timeParser = new Mock<ITimeParser>();
            _sut = new TimeValidator(_timeParser.Object);
        }

        [TestCase(null)]
        [TestCase("")]
        public void IsValid_WhenPassNullOrEmptyTime_ReturnFalse(string time)
        {
            Assert.False(_sut.IsValid(time));
        }

        [TestCase("ValidTime")]
        public void IsValid_WhenValidTimeIsPass_ValidateProperly(string time)
        {
            _timeParser.Setup(x => x.Parse(time)).Returns(new Time(12,12,12));

            Assert.True(_sut.IsValid(time));
        }
    }
}