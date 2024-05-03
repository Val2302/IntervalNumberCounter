namespace IntervalNumberCounter.Src
{
    public static class Helper
    {
        private const char QUIT_ITEM = '0';

        public static bool IsSelectedQuitProgram ( char itemId )
        {
            return itemId == QUIT_ITEM;
        }
    }
}
