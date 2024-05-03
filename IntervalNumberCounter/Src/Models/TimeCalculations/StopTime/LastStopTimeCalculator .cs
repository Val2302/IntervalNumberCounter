using IntervalNumberCounter.Src.Models.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.StopTime
{
    public static class LastStopTimeCalculator
    {
        private static bool IsExistLastStopTime ( EventTime lastEvent )
        {
            return lastEvent.EventType == EEventType.Stop;
        }

        public static TimeSpan Calculate ( IEnumerable<EventTime> workPeriod, DateTime lastDate )
        {
            var lastEvent = workPeriod.Last( );
            return IsExistLastStopTime( lastEvent ) ? lastDate - lastEvent.Time : TimeSpan.Zero;
        }
    }
}
