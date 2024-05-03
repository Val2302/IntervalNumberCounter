using IntervalNumberCounter.Src.Controllers;
using System.Collections.Generic;

namespace IntervalNumberCounter.Src.Menu
{
    public static class MainMenuBuilder
    {
        private static Dictionary<int, MenuItem> BuildMenuItems ( MainMenuController mainMenuController )
        {
            return new Dictionary<int, MenuItem>
            {
                { 1, new MenuItem ( "Запустить счётчик", mainMenuController.StartCounterTask ) },
                { 2, new MenuItem ( "Остановить счётчик", mainMenuController.StopCounterTask ) },
                { 3, new MenuItem ( "Сбростиь счётчик", mainMenuController.ResetCounter ) },
                { 4, new MenuItem ( "Показать состояние счётчика", mainMenuController.ShowCounterState ) },
                { 5, new MenuItem ( "Показать продолжительность работы счётчика за текущий месяц", mainMenuController.ShowWorkTimeCounterForMonth ) },
                { 6, new MenuItem ( "Показать продолжительность простоя счётчика за текущий месяц", mainMenuController.ShowIdleTimeCounterForMonth ) },
                { 0, new MenuItem ( "Выйти из программы", mainMenuController.QuitProgram ) },
            };
        }

        public static MainMenu BuildMainMenu ( MainMenuController mainMenuController )
        {
            return new MainMenu( BuildMenuItems( mainMenuController ), mainMenuController.ShowCounterState );
        }
    }
}
