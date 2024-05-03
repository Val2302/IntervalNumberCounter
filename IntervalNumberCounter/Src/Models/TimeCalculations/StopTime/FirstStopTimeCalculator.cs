using IntervalNumberCounter.Src.Models.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.StopTime
{
    public static class FirstStopTimeCalculator
    {
        private static bool IsExistFirstStopTime ( EventTime firstEvent )
        {
            return firstEvent.EventType == EEventType.Start;
        }

        public static TimeSpan Calculate ( IEnumerable<EventTime> workPeriod, DateTime firstDate )
        {
            var firstEvent = workPeriod.First( );
            return IsExistFirstStopTime( firstEvent ) ? firstEvent.Time - firstDate : TimeSpan.Zero;
        }
    }
}
