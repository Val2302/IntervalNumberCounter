namespace IntervalNumberCounter.Src
{
    public static class KeyItemIdConverter
    {
        public static int ToMenuItemId ( char keyItemId )
        {
            var firstCharCode = 48;
            return keyItemId - firstCharCode;
        }
    }
}
