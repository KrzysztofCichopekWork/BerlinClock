using BerlinClock.Entities;
using BerlinClock.Interfaces;
using BerlinClock.Resources;

namespace BerlinClock
{
    public class FiveMinutesClockDecorator : ClockDecorator, IClock
    {
        private const int LampCounter = 11;
        private const int LampFrequency = 5;

        public FiveMinutesClockDecorator(IClock clock)
        {
            _clock = clock;
        }

        public string ClockRepresentation
        {
            set { _clockRepresentation = value; }
        }

        public string GetRepresentationOfClock(Time time)
        {
            _clock.ClockRepresentation = GetClockRepresentationToPass(ComputeClockRepresentation(time));
            return _clock.GetRepresentationOfClock(time);
        }

        private string ComputeClockRepresentation(Time time)
        {
            var representation = string.Empty;
            var onLampCounter = time.Minutes / LampFrequency;
            for (var i = 0; i < LampCounter; i++)
            {
                representation += i < onLampCounter
                    ? GetRightColorLight(i)
                    : ClockLampRepresentationResources.OffLampRepresentation;
            }

            return representation;
        }

        private static string GetRightColorLight(int lampCount)
        {
            return IsThirdLamp(lampCount) ? ClockLampRepresentationResources.RedLampRepresentation : ClockLampRepresentationResources.YellowLampRepresentation;
        }

        private static bool IsThirdLamp(int i)
        {
            return i % 3 == 2;
        }
    }
}