using IntervalNumberCounter.Src.Models.Entities;
using IntervalNumberCounter.Src.Models.Tables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.WorkTime
{
    public static class WorkTimeCalculator
    {
        private static IEnumerable<EventTime> GetWorkPeriod ( EventTimeTable eventMomentTable, TimePeriod timePeriod )
        {
            return eventMomentTable
                   .Where( emt => ( emt.EventType == EEventType.Start || emt.EventType == EEventType.Stop )
                        && timePeriod.IsInclude( emt.Time ) );
        }

        public static TimeSpan Calculate ( EventTimeTable eventMomentTable, TimePeriod timePeriod )
        {
            if ( Helper.IsEmptyCollection( eventMomentTable ) )
            {
                return TimeSpan.Zero;
            }

            var workPeriod = GetWorkPeriod( eventMomentTable, timePeriod );
            var workPeriodTime = WorkPeriodDurationCalculator.Calc( workPeriod );

            var firstWorkTime = FirstWorkTimeCalculator.Calculate( workPeriod, timePeriod.FirstDate );
            var lastWorkTime = LastWorkTimeCalculator.Calculate( workPeriod, timePeriod.LastDate );

            return workPeriodTime + firstWorkTime + lastWorkTime;
        }
    }
}
