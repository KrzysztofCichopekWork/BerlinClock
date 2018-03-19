using BerlinClock.Interfaces;

namespace BerlinClock.Validators
{
    public class TimeValidator : ITimeValidator
    {
        private ITimeParser _timeParser;

        public TimeValidator()
        : this(new TimeParser())
        {
        }

        public TimeValidator(ITimeParser timeParser)
        {
            _timeParser = timeParser;
        }

        public bool IsValid(string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                return false;
            }

            var timeValue = _timeParser.Parse(time);

            if (timeValue.Hours < 0
                || timeValue.Minutes < 0
                || timeValue.Seconds < 0
                || timeValue.Hours > 24
                || timeValue.Minutes > 59
                || timeValue.Seconds > 59
            )
            {
                return false;
            }

            return true;
        }
    }
}