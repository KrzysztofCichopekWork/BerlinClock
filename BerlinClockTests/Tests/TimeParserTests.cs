using System;
using System.Collections;
using BerlinClock;
using BerlinClock.Entities;
using BerlinClock.Interfaces;
using Moq;
using NUnit.Framework;

namespace BerlinClockTests
{
    public class TimeParserTests
    {
        private TimeParser _sut;

        [SetUp]
        public void SeutUp()
        {
            _sut = new TimeParser();
        }

        [Test, TestCaseSource(typeof(TimeFormatForParseTestSource), "TestCases")]
        public Time Parse_ReturnRightValue(string timeValue)
        {
            return _sut.Parse(timeValue);
        }

        public class TimeFormatForParseTestSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData("12:45:13").Returns(new Time(12,45,13));
                    yield return new TestCaseData("12:45").Returns(new Time(12,45,0));
                    yield return new TestCaseData("12").Returns(new Time(12,0,0));
                }
            }
        }
    }
}