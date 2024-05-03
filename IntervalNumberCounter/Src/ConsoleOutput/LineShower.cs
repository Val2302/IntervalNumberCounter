namespace IntervalNumberCounter.Src.ConsoleOutput
{
    public static class LineShower
    {
        private static readonly string Line = "====================================================================\n";

        public static void Show ( )
        {
            System.Console.WriteLine( Line );
        }
    }
}
