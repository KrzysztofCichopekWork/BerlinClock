using System;
using BerlinClock.Interfaces;
using BerlinClock.Validators;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeValidator _timeValidator;
        private readonly ITimeParser _timeParser;

        public TimeConverter(ITimeValidator timeValidator,
            ITimeParser timeParser)
        {
            _timeValidator = timeValidator;
            _timeParser = timeParser;
        }

        public TimeConverter()
        : this(new TimeValidator(), new TimeParser())
        {
        }

        public string ConvertTime(string aTime)
        {
            ValidateTime(aTime);

            var time = _timeParser.Parse(aTime);

            var clockRepresentation =
                new OneMinutesClockDecorator(
                    new FiveMinutesClockDecorator(
                        new OneHoursClockDecorator(
                            new FiveHoursClockDecorator(
                                new SecondsClockDecorator(
                                    new Clock())))));

            return clockRepresentation.GetRepresentationOfClock(time);
        }

        private void ValidateTime(string aTime)
        {
            if (_timeValidator.IsValid(aTime) == false)
            {
                throw new ArgumentException("Parameter is invalid.", nameof(aTime));
            }
        }
    }
}