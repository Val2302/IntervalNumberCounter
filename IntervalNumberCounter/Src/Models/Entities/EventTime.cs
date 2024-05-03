using IntervalNumberCounter.Src.DbRepository;
using System;

namespace IntervalNumberCounter.Src.Models.Entities
{
    [Serializable]
    public class EventTime : IEntity
    {
        public long Id { get; set; }
        public EEventType EventType { get; set; }
        public DateTime Time { get; set; }
        public long OwnerEventId { get; set; }
        public NumberCounter CounterState { get; set; }

        public EventTime ( DateTime time, EEventType eventType, long ownerEventId, NumberCounter counterState )
        {
            Time = time;
            EventType = eventType;
            OwnerEventId = ownerEventId;
            CounterState = counterState;
        }
    }
}