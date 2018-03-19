using System;
using BerlinClock;
using BerlinClock.Entities;
using BerlinClock.Interfaces;
using Moq;
using NUnit.Framework;

namespace BerlinClockTests
{
    [TestFixture]
    public class TimeConverterTests
    {
        private Mock<ITimeValidator> _timeValidator;
        private Mock<ITimeParser> _timeParser;
        private TimeConverter _sut;


        [SetUp]
        public void SeutUp()
        {
            _timeValidator = new Mock<ITimeValidator>();
            _timeParser = new Mock<ITimeParser>();
            _sut = new TimeConverter(_timeValidator.Object, _timeParser.Object);
        }

        [TestCase("13:27:12")]
        public void ConvertTime_GetRightOutput(string time)
        {
            _timeValidator.Setup(x => x.IsValid(time)).Returns(true);
            _timeParser.Setup(x => x.Parse(time)).Returns(new Time(13, 27, 12));

            var asd = _sut.ConvertTime(time);
            Assert.NotNull(asd);
        }

        
    }
}