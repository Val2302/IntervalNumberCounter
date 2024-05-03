namespace IntervalNumberCounter.Src.Controllers
{
    public static class CounterStateConverter
    {
        public static string ToText ( bool counterState )
        {
            return counterState ? "работает" : "выключен";
        }
    }
}
