using System;
using System.Linq;
using TicTacToeConsoleApp.HelperClasses;
using TicTacToeConsoleApp.TicTacToeGame;

// *TO DO*
// Make the method of loading the saving
// Output warning of loading correctly

namespace TicTacToeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe(9, new char[] { 'X', 'O' }, new GameBoardConsole(), null);

            if (args.Contains("--load-saved"))
            {
                TicTacToeSavingModel model = GameSaving.LoadSave();
                if(model != null)
                {
                    game = new TicTacToe(model.PlayersTurn, 
                        model.PlayingSymbols, new GameBoardConsole(model.Board.Board), model.Score);
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