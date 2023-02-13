using System;
using TicTacToeConsoleApp.HelperClasses;

namespace TicTacToeConsoleApp.TicTacToeGame
{
    public class GameBoardConsole : GameBoard
    {
        public GameBoardConsole(char[] board) : base(board) { }

        public GameBoardConsole() : base()  { }

        public override void PrintBoard(char[] playingSymbols, int[] score, int playersTurn, bool loadingException = false)
        {
            Console.Clear();
            if(loadingException)
                ColorOutputConsole.Print("No saved game was found!", ConsoleColor.DarkYellow);

            Console.WriteLine("Let's play Tic Tac Toe!");
            Console.WriteLine($"Player 1: {playingSymbols[0]} [{score[0]}]");
            Console.WriteLine($"Player 2: {playingSymbols[1]} [{score[1]}]\n\n");

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

        public override bool RoundIsOver(int gameResult)
        {
            if (gameResult != 0)
                ColorOutputConsole.Print($"Player {gameResult} wins!", ConsoleColor.Green);
            else
                ColorOutputConsole.Print("It's a draw!", ConsoleColor.Blue);

            ColorOutputConsole.Print("Do you want to play again? (y/n)", ConsoleColor.DarkYellow);
            return Console.ReadLine().ToLower() == "y";
        }
    }
}
