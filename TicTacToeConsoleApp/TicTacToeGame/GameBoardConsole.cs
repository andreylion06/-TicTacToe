using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeConsoleApp.HelperClasses;

namespace TicTacToeConsoleApp.TicTacToeGame
{
    public class GameBoardConsole : GameBoard
    {
        public override void PrintBoard(char[] playingSymbols, int playersTurn)
        {
            Console.Clear();
            Console.WriteLine("Let's play Tic Tac Toe!");
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: 0\n\n");

            Console.WriteLine($"Player {playersTurn}'s turn. Select from 1 to 9 from the game board.\n\n");

            Console.WriteLine(GetStyledStringOfGameBoard());
        }

        public string GetStyledStringOfGameBoard()
        {
            return
                $"\t {Board[0]} | {Board[1]} | {Board[2]}\n" +
                "\t---+---+----\n" +
                $"\t {Board[3]} | {Board[4]} | {Board[5]}\n" +
                "\t---+---+----\n" +
                $"\t {Board[6]} | {Board[7]} | {Board[8]}\n";
        }

        public override string ChooseCell(string exception = null)
        {
            if (exception != null)
                ColorOutputConsole.Print($"\n{exception}\n", ConsoleColor.DarkYellow);
            else
                Console.WriteLine("\n\n");
            Console.Write(" --->");
            string inputVal = Console.ReadLine();

            return inputVal;
        }

        public override void GameIsOver(int gameResult)
        {
            if (gameResult != 0)
                ColorOutputConsole.Print($"Player {gameResult} wins!", ConsoleColor.Green);
            else
                ColorOutputConsole.Print($"It's a draw!", ConsoleColor.Blue);
        }
    }
}
