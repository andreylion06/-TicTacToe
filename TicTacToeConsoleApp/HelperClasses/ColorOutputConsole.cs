using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsoleApp.HelperClasses
{
    public class ColorOutputConsole
    {
        public static void Print(string str, ConsoleColor foreGround, ConsoleColor backGround = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreGround;
            Console.BackgroundColor = backGround;
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
