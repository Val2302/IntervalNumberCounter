using System;
using System.Threading.Tasks;

namespace IntervalNumberCounter.Src.Models.Tasks
{
    public class CycleTask
    {
        public const int ONE_SECOND = 1000;

        private Task _task;
        private Action _action;
        private int _timeOut; /// миллисекунды

        public bool IsRun { get; private set; }

        /// <summary>
        /// Создаёт циклическую задачу
        /// </summary>
        /// <param name="cyclickAction">действие, выполняемое в цикле</param>
        /// <param name="timeOut">остановка между итерациями (миллисекунды)</param>
        public CycleTask ( Action cyclickAction, int timeOut = ONE_SECOND )
        {
            _action = cyclickAction;
            _timeOut = timeOut;
        }

        private void Loop ( )
        {
            do
            {
                _action( );
                _task.Wait( _timeOut );
            }
            while ( IsRun );
        }

        public void Start ( )
        {
            if ( IsRun )
            {
                return;
            }

            _task = new Task( Loop );
            _task.Start( );
            IsRun = true;
        }

        public void Stop ( )
        {
            IsRun = false;
        }
    }
}
