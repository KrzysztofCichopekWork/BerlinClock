using BerlinClock.Entities;

namespace BerlinClockTests
{
    public class TimeUtilis
    {
        public static Time GetDateTimeWithSpecificSecondValue(int seconds)
        {
            return new Time(0, 0, seconds);
        }

        public static Time GetDateTimeWithSpecificHourValue(int hours)
        {
            return new Time(hours, 0, 0);
        }

        public static Time GetDateTimeWithSpecificMinuteValue(int minute)
        {
            return new Time(0, minute, 0);
        }
    }
}