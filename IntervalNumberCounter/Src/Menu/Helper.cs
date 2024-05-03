using System;
using System.Collections.Generic;

namespace IntervalNumberCounter.Src.Menu
{
    public static class Helper
    {
        public static bool IsEmptyMenuItems ( Dictionary<int, MenuItem> menuItems ) => menuItems.Count == 0;

        public static bool IsEmptyAction ( Action action ) => action is null;
    }
}
