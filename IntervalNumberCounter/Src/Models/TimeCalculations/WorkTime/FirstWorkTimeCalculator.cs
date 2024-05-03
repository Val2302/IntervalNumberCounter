using IntervalNumberCounter.Src.Models.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.WorkTime
{
    public static class FirstWorkTimeCalculator
    {
        private static bool IsExistFirstWorkTime( EventTime firstEvent )
        {
            return firstEvent.EventType == EEventType.Stop;
        }

        public static TimeSpan Calculate ( IEnumerable<EventTime> workPeriod, DateTime firstDate )
        {
            var firstEvent = workPeriod.First( );
            return IsExistFirstWorkTime( firstEvent ) ? firstEvent.Time - firstDate : TimeSpan.Zero;
        }
    }
}
