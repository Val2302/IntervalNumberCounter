using IntervalNumberCounter.Src.Models.Tables;
using System;

namespace IntervalNumberCounter.Src.DbRepository
{
    [Serializable]
    public class DataBase
    {
        public EventTimeTable EventTimeTable { get; set; }
    }
}
