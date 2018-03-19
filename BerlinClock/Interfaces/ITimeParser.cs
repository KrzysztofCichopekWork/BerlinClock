using BerlinClock.Entities;

namespace BerlinClock.Interfaces
{
    public interface ITimeParser
    {
        Time Parse(string time);
    }
}