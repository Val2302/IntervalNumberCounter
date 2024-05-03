using System;

namespace IntervalNumberCounter.Src.Models.TimeCalculations
{
    public class TimePeriod
    {
        public readonly DateTime FirstDate, LastDate;

        public TimePeriod ( DateTime firstDate, DateTime lastDate )
        {
            FirstDate = firstDate;
            LastDate = lastDate;
        }

        public bool IsInclude( DateTime date )
        {
            return FirstDate <= date || date <= LastDate;
        }
    }
}
