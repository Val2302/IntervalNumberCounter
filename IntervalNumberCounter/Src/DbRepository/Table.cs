using System.Collections.Generic;
using System;

namespace IntervalNumberCounter.Src.DbRepository
{
    [Serializable]
    public class Table<Entity> : List<Entity> where Entity : IEntity
    {
        private int _idNumerator;

        public Table ( ) : base ( )
        {
            _idNumerator = 0;
        }

        public void Add ( Entity entity )
        {   
            entity.Id = _idNumerator;
            _idNumerator ++;

            base.Add( entity );
        }
    }
}
