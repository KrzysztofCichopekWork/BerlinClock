using System.Text;
using BerlinClock.Interfaces;

namespace BerlinClock
{
    public abstract class ClockDecorator
    {
        protected string _clockRepresentation;
        protected IClock _clock;

        protected string GetClockRepresentationToPass(string computedClockRepresentation)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(computedClockRepresentation);
            if (string.IsNullOrEmpty(_clockRepresentation) == false)
            {
                result.Append(_clockRepresentation);
            }

            return result.ToString();
        }

        public string ClockRepresentation
        {
            set { _clockRepresentation = value; }
        }
    }
}