using IntervalNumberCounter.Src.Models.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.WorkTime
{
    public static class LastWorkTimeCalculator
    {
        private static bool IsExistLastWorkTime( EventTime lastEvent )
        {
            return lastEvent.EventType == EEventType.Start;
        }

        public static TimeSpan Calculate ( IEnumerable<EventTime> workPeriod, DateTime lastDate )
        {
            var lastEvent = workPeriod.Last( );
            return IsExistLastWorkTime( lastEvent ) ? lastDate - lastEvent.Time : TimeSpan.Zero;
        }
    }
}
