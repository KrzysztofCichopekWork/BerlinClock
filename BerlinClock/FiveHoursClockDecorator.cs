using BerlinClock.Entities;
using BerlinClock.Interfaces;
using BerlinClock.Resources;

namespace BerlinClock
{
    public class FiveHoursClockDecorator : ClockDecorator, IClock
    {
        private const int LampCounter = 4;
        private const int LampFrequency = 5;

        public FiveHoursClockDecorator(IClock clock)
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
            var representation = string.Empty;
            var onLampCounter = time.Hours / LampFrequency;
            for (var i = 0; i < LampCounter; i++)
            {
                representation += i < onLampCounter
                    ? ClockLampRepresentationResources.RedLampRepresentation
                    : ClockLampRepresentationResources.OffLampRepresentation;
            }

            return representation;
        }
    }
}