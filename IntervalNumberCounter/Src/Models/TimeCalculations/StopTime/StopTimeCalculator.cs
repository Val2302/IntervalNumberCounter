using IntervalNumberCounter.Src.Models.Entities;
using IntervalNumberCounter.Src.Models.Tables;

using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations.StopTime
{
    public static class StopTimeCalculator
    {
        private static IEnumerable<EventTime> GetStopPeriod ( EventTimeTable eventMomentTable, TimePeriod timePeriod )
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

            var stopPeriod = GetStopPeriod( eventMomentTable, timePeriod );
            var stopPeriodTime = StopPeriodDurationCalculator.Calc( stopPeriod );

            var firstStopTime = FirstStopTimeCalculator.Calculate( stopPeriod, timePeriod.FirstDate );
            var lastStopTime = LastStopTimeCalculator.Calculate( stopPeriod, timePeriod.LastDate );

            return stopPeriodTime + firstStopTime + lastStopTime;
        }
    }
}
