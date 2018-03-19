using BerlinClock.Entities;
using BerlinClock.Interfaces;

namespace BerlinClock
{
    public class TimeParser : ITimeParser
    {
        private const char TimeDelimiter = ':';

        public Time Parse(string time)
        {
            var splitedTime = time.Split(TimeDelimiter);

            return new Time(splitedTime);
        }
    }
}