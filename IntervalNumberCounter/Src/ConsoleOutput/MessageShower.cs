using System;

using static System.Console;

namespace IntervalNumberCounter.Src.ConsoleOutput
{
    public static class MessageShower
    {
        private static void ShowMessage ( string title, string message, string messageHeader, ConsoleColor fontColor )
        {
            var oldFontColor = ForegroundColor;
            ForegroundColor = fontColor;

            var textMessageHeader = Helper.IsEmptyMessageHeader( messageHeader ) ? string.Empty : $"{messageHeader}:";
            WriteLine( $"{textMessageHeader} {title}\n{message}" );

            ForegroundColor = oldFontColor;
        }

        public static void ShowError ( string title, string message = "" )
        {
            ShowMessage( title, message, "ОШИБКА", ConsoleColor.Red );
        }

        public static void ShowWarning ( string title, string message = "" )
        {
            ShowMessage( title, message, "ВНИМАНИЕ", ConsoleColor.Yellow );
        }

        public static void ShowMessage ( string title, string message = "" )
        {
            ShowMessage( title, message, "", ConsoleColor.Green );
        }
    }
}
