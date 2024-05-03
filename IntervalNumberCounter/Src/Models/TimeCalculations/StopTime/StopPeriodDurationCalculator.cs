using IntervalNumberCounter.Src.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.StopTime
{
    public static class StopPeriodDurationCalculator
    {
        private static IEnumerable<TimeSpan> GetStopPeriodDurations ( IEnumerable<EventTime> stopPeriod )
        {
            var stopPeriods = stopPeriod.Where( wp => wp.EventType == EEventType.Stop );

            return stopPeriod
                   .Join(
                        stopPeriods,
                        start => start.OwnerEventId,
                        stop => stop.Id,
                        ( stop, start ) => start.Time - stop.Time
                   );
        }

        public static TimeSpan Calc ( IEnumerable<EventTime> stopPeriod )
        {
            var stopPeriodDurations = GetStopPeriodDurations( stopPeriod );

            if ( Helper.IsEmptyCollection( stopPeriodDurations ) )
            {
                return TimeSpan.Zero;
            }

            return stopPeriodDurations.Aggregate( ( current, item ) => current + item );
        }
    }
}
