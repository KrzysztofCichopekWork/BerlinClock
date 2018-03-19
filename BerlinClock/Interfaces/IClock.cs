using BerlinClock.Entities;

namespace BerlinClock.Interfaces
{
    public interface IClock
    {
        string ClockRepresentation { set; }

        string GetRepresentationOfClock(Time time);
    }
}