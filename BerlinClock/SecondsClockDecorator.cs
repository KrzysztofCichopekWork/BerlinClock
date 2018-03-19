using BerlinClock.Entities;
using BerlinClock.Interfaces;
using BerlinClock.Resources;

namespace BerlinClock
{
    public class SecondsClockDecorator : ClockDecorator, IClock
    {
        private const int LampFrequency = 2;

        public SecondsClockDecorator(IClock clock)
        {
            _clock = clock;
        }

        public string GetRepresentationOfClock(Time time)
        {
            _clock.ClockRepresentation = GetClockRepresentationToPass(ComputeClockRepresentation(time));

            return _clock.GetRepresentationOfClock(time);
        }

        private string ComputeClockRepresentation(Time time)
        {
            return time.Seconds % LampFrequency == 0
                ? ClockLampRepresentationResources.YellowLampRepresentation
                : ClockLampRepresentationResources.OffLampRepresentation;
        }
    }
}