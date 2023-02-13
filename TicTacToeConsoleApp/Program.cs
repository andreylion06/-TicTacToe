using System;
using System.Linq;
using TicTacToeConsoleApp.HelperClasses;
using TicTacToeConsoleApp.TicTacToeGame;

namespace TicTacToeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe(9, new char[] { 'X', 'O' }, new GameBoardConsole(), null);

            if (args.Contains("--load-saved"))
                game.LoadFromSaving();

            game.Start();
        }
    }
}