using BerlinClock.Entities;
using BerlinClock.Interfaces;
using BerlinClock.Resources;

namespace BerlinClock
{
    public class OneHoursClockDecorator : ClockDecorator, IClock
    {
        private const int LampFrequency = 5;
        private const int LampCounter = 4;

        public OneHoursClockDecorator(IClock clock)
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
            var onLampCounter = time.Hours % LampFrequency;
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