using IntervalNumberCounter.Src.ConsoleOutput;

using System;

namespace IntervalNumberCounter.Src.Menu
{
    public class MenuItem
    {
        private string _title;
        private Action _action;

        public MenuItem ( string title, Action action )
        {
            _title = title;
            _action = action;
        }

        public void Execute ( )
        {
            if ( Helper.IsEmptyAction( _action ) )
            {
                var title = $@"Для пункта ""{_title}"" главного меню не задано действие";
                var message=  "Задайте действие для этого пункта меню";

                MessageShower.ShowError( title, message );

                return;
            }

            _action( );
        }

        public override string ToString ( )
        {
            return $" {_title}";
        }
    }
}
