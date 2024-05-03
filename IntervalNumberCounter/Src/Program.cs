using IntervalNumberCounter.Src.Controllers;
using IntervalNumberCounter.Src.Menu;

using static IntervalNumberCounter.Src.Helper;
using static System.Console;

using IntervalNumberCounter.Src.ConsoleOutput;

namespace IntervalNumberCounter.Src
{
    class Program
    {
        static void Main ( string[ ] args )
        {
            RunProgram( );
        }

        static void RunProgram ( )
        {
            var mainMenuController = new MainMenuController( );
            MainMenu mainMenu = MainMenuBuilder.BuildMainMenu( mainMenuController );

            char keyItemId;
            int menuItemId;

            while ( true )
            {
                Write( mainMenu.ToString() );
                keyItemId = ReadKey( ).KeyChar;
                menuItemId = KeyItemIdConverter.ToMenuItemId( keyItemId );
                WriteLine( "\n" );

                if ( IsSelectedQuitProgram( keyItemId ) )
                {
                    mainMenuController.QuitProgram( );
                    WriteLine( " Программа завершена \n" );
                    return;
                }

                if ( mainMenu.MenuItems.TryGetValue( menuItemId, out MenuItem menuItem ) )
                {
                    LineShower.Show( );
                    menuItem.Execute( );
                    LineShower.Show( );
                }
            }
        }
    }
}
