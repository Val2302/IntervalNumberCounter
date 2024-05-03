using IntervalNumberCounter.Src.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.WorkTime
{
    public static class WorkPeriodDurationCalculator
    {
        private static IEnumerable<TimeSpan> GetWorkPeriodDurations ( IEnumerable<EventTime> workPeriod )
        {
            var stopPeriods = workPeriod.Where( wp => wp.EventType == EEventType.Stop );

            return workPeriod
                   .Join(
                        stopPeriods,
                        start => start.Id,
                        stop => stop.OwnerEventId,
                        ( start, stop ) => stop.Time - start.Time
                   );
        }

        public static TimeSpan Calc ( IEnumerable<EventTime> stopPeriod )
        {
            var workPeriodDurations = GetWorkPeriodDurations( stopPeriod );

            if ( Helper.IsEmptyCollection( workPeriodDurations ) )
            {
                return TimeSpan.Zero;
            }

            return workPeriodDurations.Aggregate( ( current, item ) => current + item );
        }
    }
}
