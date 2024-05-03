using System.Collections.Generic;
using System.Linq;

namespace IntervalNumberCounter.Src.Models.TimeCalculations
{
    public class Helper
    {
        public static bool IsEmptyCollection<T> ( IEnumerable<T> collection )
        {
            return collection.Count( ) == 0;
        }
    }
}
