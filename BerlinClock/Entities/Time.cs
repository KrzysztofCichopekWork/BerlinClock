using System;

namespace BerlinClock.Entities
{
    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Time(int hours, int minutes, int seconds = default(int))
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Time(string[] splitedTimeFormat)
        {
            Action<string>[] arrayToPropertyMap =
            {
                x => Hours = ParseToIntOrDefault(x),
                x => Minutes = ParseToIntOrDefault(x),
                x => Seconds = ParseToIntOrDefault(x)
            };

            for (int i = 0; i < splitedTimeFormat.Length; i++)
            {
                arrayToPropertyMap[i](splitedTimeFormat[i]);
            }
        }

        public override string ToString()
        {
            return string.Format("Time: {0}:{1}:{2}", Hours, Minutes, Seconds);
        }

        public override bool Equals(object obj)
        {
            Time p = obj as Time;
            if (p == null)
            {
                return false;
            }

            return Hours == p.Hours
                && Minutes == p.Minutes
                && Seconds == p.Seconds;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 11;
                hash = hash * 103 + Hours.GetHashCode();
                hash = hash * 103 + Minutes.GetHashCode();
                hash = hash * 103 + Seconds.GetHashCode();
                return hash;
            }
        }

        private static int ParseToIntOrDefault(string value)
        {
            try
            {
                return Int32.Parse(value);
            }
            catch (Exception e)
            {
                return default(int);
            }
        }
    }
}