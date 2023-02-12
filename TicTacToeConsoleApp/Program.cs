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
            TicTacToe game = new TicTacToe(9, new char[] { 'X', 'O' }, new GameBoardConsole());

            if (args.Contains("--load-saved"))
            {
                TicTacToeSavingModel model = GameSaving.LoadSave();
                if(model != null)
                {
                    game = new TicTacToe(model.PlayersTurn, 
                        model.PlayingSymbols, new GameBoardConsole(model.Board.Board));
                }
                else
                {
                    ColorOutputConsole.Print("No saved game was found!", ConsoleColor.DarkYellow);
                }
            }

            game.Start();
        }
    }
}
