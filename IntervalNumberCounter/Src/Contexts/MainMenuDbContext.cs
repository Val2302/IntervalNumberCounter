using IntervalNumberCounter.Src.DbRepository;
using IntervalNumberCounter.Src.Models.Entities;
using IntervalNumberCounter.Src.Models.Tables;
using System;
using System.Linq;

namespace IntervalNumberCounter.Src.Controllers
{
    public class MainMenuDbContext
    {
        private DbConnector _dbConnector;

        public DataBase DataBase { get; private set; }
        public NumberCounter NumberCounter { get; private set; }

        public MainMenuDbContext ( )
        {
            _dbConnector = new DbConnector( "dataBase.db" );
            DataBase = _dbConnector.Open( );
        }

        private bool IsEmptyEventTimeTable ( EventTimeTable eventTimeTable )
        {
            return eventTimeTable.Count == 0;
        }

        private bool IsEmptyEventTime ( EventTime eventTime )
        {
            return eventTime is null;
        }

        private long GetOwnerEventRegisterId ( )
        {
            var emptyOwnerEventId = -1;

            if ( IsEmptyEventTimeTable( DataBase.EventTimeTable ) )
            {
                return emptyOwnerEventId;
            }

            var lastEventTime = DataBase.EventTimeTable.Where( ett => ett.EventType == EEventType.Start ).Last( );

            return IsEmptyEventTime( lastEventTime ) ? emptyOwnerEventId : lastEventTime.Id;
        }

        public NumberCounter GetNumberCounter ( )
        {
            if ( IsEmptyEventTimeTable( DataBase.EventTimeTable ) )
            {
                return NumberCounterBuilder.Build( );
            }

            var lastEventTime = DataBase.EventTimeTable.Last( );

            return IsEmptyEventTime( lastEventTime ) ? NumberCounterBuilder.Build( ) : lastEventTime.CounterState;
        }

        public void Save ( NumberCounter numberCounter, EEventType eventType )
        {
            var eventTime = new EventTime( DateTime.Now, eventType, GetOwnerEventRegisterId( ), numberCounter );
            DataBase.EventTimeTable.Add( eventTime );
            _dbConnector.Save( DataBase );
        }
    }
}
