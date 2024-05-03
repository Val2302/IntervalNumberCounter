using IntervalNumberCounter.Src.ConsoleOutput;

using System.Linq;
using System.Collections.Generic;
using System;

namespace IntervalNumberCounter.Src.Menu
{
    public class MainMenu
    {
        public readonly Dictionary<int, MenuItem> MenuItems;

        public readonly Action ShowCounterState;

        public MainMenu ( Dictionary<int, MenuItem> menuItems, Action showCounterState )
        {
            if ( menuItems is null || Helper.IsEmptyMenuItems( menuItems ) )
            {
                MessageShower.ShowError( "Главное меню пустое", "Добавьте пункты в главное меню" );
                return;
            }

            if ( showCounterState is null )
            {
                MessageShower.ShowError( @"Действие ""ShowCounterState"" ", "Не реализовано" );
                return;
            }

            MenuItems = menuItems;
            ShowCounterState = showCounterState;
        }

        public override string ToString ( )
        {
            var textMenuItems = MenuItems.Aggregate( "", ( current, num ) => $"{current} {num.Key}.{num.Value}\n" );

            return "    ИНТЕРВАЛЬНЫЙ СЧЁТЧИК \n\n"
                + textMenuItems
                + "\n Выберите действие... ";
        }
    }
}
