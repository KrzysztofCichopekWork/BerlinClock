using System;
using BerlinClock.Entities;
using BerlinClock.Interfaces;

namespace BerlinClock
{
    public class Clock : IClock
    {
        private string _clockRepresentation;

        public string ClockRepresentation
        {
            set { _clockRepresentation = value; }
        }

        public string GetRepresentationOfClock(Time time)
        {
            if (string.IsNullOrEmpty(_clockRepresentation))
            {
                return _clockRepresentation;
            }

            return _clockRepresentation.TrimEnd(Environment.NewLine.ToCharArray()); ;
        }
    }
}