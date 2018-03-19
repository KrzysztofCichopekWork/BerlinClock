using System;
using System.Text;
using BerlinClock.Entities;
using BerlinClock.Interfaces;
using BerlinClock.Resources;

namespace BerlinClock
{
    public class OneMinutesClockDecorator : ClockDecorator, IClock
    {
        private const int LampFrequency = 5;
        private const int LampCounter = 4;

        public OneMinutesClockDecorator(IClock clock)
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
            var onLampCounter = time.Minutes % LampFrequency;
            for (var i = 0; i < LampCounter; i++)
            {
                representation += i < onLampCounter
                    ? ClockLampRepresentationResources.YellowLampRepresentation
                    : ClockLampRepresentationResources.OffLampRepresentation;
            }

            return representation;
        }
    }
}