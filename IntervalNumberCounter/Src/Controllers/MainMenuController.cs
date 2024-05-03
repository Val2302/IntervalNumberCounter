using IntervalNumberCounter.Src.ConsoleOutput;
using IntervalNumberCounter.Src.Models.Tasks;
using IntervalNumberCounter.Src.Models.Entities;
using IntervalNumberCounter.Src.Models.TimeCalculations;
using IntervalNumberCounter.Src.Models.TimeCalculations.WorkTime;
using IntervalNumberCounter.Src.Models.TimeCalculations.StopTime;

using System;
using System.Linq;

namespace IntervalNumberCounter.Src.Controllers
{
    public class MainMenuController
    {
        private MainMenuDbContext _dbContext;
        private NumberCounter _numberCounter;
        private CycleTask _counterTask;
        
        private string _counterState;

        #region Constructors

        public MainMenuController ( )
        {
            _dbContext = new MainMenuDbContext( );
            _numberCounter = _dbContext.GetNumberCounter( );
            _counterTask = new CycleTask( _numberCounter.Increment, _numberCounter.Timeout );
        }

        #endregion

        #region Methods

        private TimePeriod GetMonthPeriod ( )
        {
            var now = DateTime.Now;

            var firstMonthDay = new DateTime( now.Year, now.Month, 1 );
            var lastMonthDay = firstMonthDay.AddMonths( 1 ).AddDays( -1 );

            return new TimePeriod( firstMonthDay, lastMonthDay );
        }

        #endregion

        #region EventHandlers

        public void StartCounterTask ( )
        {
            if ( _counterTask.IsRun )
            {
                MessageShower.ShowMessage( "Счётчик не может быть запущен - сейчас он считает" );
                return;
            }

            _counterTask.Start( );
            _dbContext.Save( _numberCounter, EEventType.Start );
            MessageShower.ShowMessage( "Счётчик запущен" );
        }

        public void StopCounterTask ( )
        {
            if ( !_counterTask.IsRun )
            {
                MessageShower.ShowMessage( "Счётчик не может быть остановлен - сейчас он простаивает" );
                return;
            }

            _counterTask.Stop( );
            _dbContext.Save( _numberCounter, EEventType.Stop );
            MessageShower.ShowMessage( "Счётчик остановлен" );
        }

        public void ResetCounter ( )
        {
            if ( !_counterTask.IsRun )
            {
                MessageShower.ShowMessage( "Счётчик не может быть сброшен - сейчас он простаивает" );
                return;
            }

            _numberCounter.Reset( );
            _dbContext.Save( _numberCounter, EEventType.Reset );
            MessageShower.ShowMessage( "Счётчик сброшен" );
        }

        public void ShowCounterState ( )
        {
            _counterState = CounterStateConverter.ToText( _counterTask.IsRun );

            MessageShower.ShowMessage( $"Состояние счётчика : {_counterState}" );
            MessageShower.ShowMessage( $"Значение счётчика  : {_numberCounter.CurrentValue}" );
        }

        public void ShowWorkTimeCounterForMonth ( )
        {
            var totalTime = WorkTimeCalculator.Calculate( _dbContext.DataBase.EventTimeTable, GetMonthPeriod( ) );
            MessageShower.ShowMessage( $"Наработато времени за месяц: {totalTime:T}" );
        }

        public void ShowIdleTimeCounterForMonth ( )
        {
            var totalTime = StopTimeCalculator.Calculate( _dbContext.DataBase.EventTimeTable, GetMonthPeriod( ) );
            MessageShower.ShowMessage( $"Простояно времени за месяц: {totalTime:T}" );
        }

        public void QuitProgram ( )
        {
            if ( _counterTask.IsRun )
            {
                _dbContext.Save( _numberCounter, EEventType.Stop );
            }
        }

        #endregion
    }
}
