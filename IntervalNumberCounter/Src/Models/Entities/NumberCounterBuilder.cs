namespace IntervalNumberCounter.Src.Models.Entities
{
    public static class NumberCounterBuilder
    {
        public static NumberCounter Build ( )
        {
            var beginValue = 0;
            var step = 3;
            var timeout = 100;

            return new NumberCounter( beginValue, step, timeout );
        }
    }
}
