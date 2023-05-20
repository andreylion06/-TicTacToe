using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TicTacToeConsoleApp.HelperClasses;
using TicTacToeConsoleApp.TicTacToeLibrary;

namespace TicTacToeLibrary.TicTacToeLibrary
{    
    public class TicTacToeGame
    {
        private Dictionary<int, char> _playingSymbols = new() { { 1, 'X' }, { 2, 'O' } };
        private Dictionary<int, int> _score = new() { { 1, 0 }, { 2, 0 } };
        public int PlayersTurn { get; private set; }
        private GameBoard _board;

        public TicTacToeGame(GameBoard board)
        {
            PlayersTurn = 1;
            _board = board;
        }

        public void Start()
        {
            GameResult result = GameResult.InProcess;
            string message = String.Empty;

            while(result == GameResult.InProcess)
            {
                PrintScreen(message);
                message = String.Empty;

                Console.Write("-->");
                string selectedCellStr = Console.ReadLine();
                int selectedCell;
                if (!int.TryParse(selectedCellStr, out selectedCell))
                    message = "Entered invalid cell number!";
                else
                {
                    try
                    {
                        _board.SetGameCell(selectedCell, PlayersTurn);
                    }
                    catch (Exception e)
                    {
                        message = e.Message;
                    }
                }
                if (string.IsNullOrEmpty(message))
                    this.NextTurn();

                result = TicTacToeRules.CheckIfGameIsOver(
                    _board.GenerateFieldWithSymbols(_playingSymbols), 
                    new char[] { _playingSymbols[1], _playingSymbols[2] }
                    );  
            }

            SetScore(result);
            PrintScreen(String.Empty);
            PrintResult(result);
            
            ColorOutputConsole.Print("\nDo you want to play again? (y/n): ", ConsoleColor.DarkYellow);
            if (Console.ReadLine().ToLower() == "y")
                RestartGame();
        }

        private void PrintScreen(string message)
        {
            Console.Clear();

            if (!string.IsNullOrEmpty(message))
                ColorOutputConsole.Print(message, ConsoleColor.Yellow);

            Console.WriteLine("Let's play Tic Tac Toe!\n\n");
            Console.WriteLine($"Player 1: {_playingSymbols[1]} [{_score[1]}]");
            Console.WriteLine($"Player 2: {_playingSymbols[2]} [{_score[2]}]\n\n");

            Console.WriteLine($"Player {PlayersTurn}'s turn. Select from 1 to 9 from the game board.\n\n");

            _board.PrintBoard(_playingSymbols);
        }

        private void PrintResult(GameResult result)
        {
            if (result == GameResult.FirstWon || result == GameResult.SecondWon)
                ColorOutputConsole.Print($"\nPlayer {(int)result} wins!", ConsoleColor.Green);
            else if(result == GameResult.Draw)
                ColorOutputConsole.Print("\nIt's a draw!", ConsoleColor.Blue);
        }

        private void SetScore(GameResult result)
        {
            if (result == GameResult.FirstWon || result == GameResult.Draw)
                _score[1]++;
            if (result == GameResult.SecondWon || result == GameResult.Draw)
                _score[2]++;
        }

        private void RestartGame()
        {
            _board.SetFieldToDefault();
            SwapPlayingSymbols();
            Start();
        }

        private void NextTurn()
        {
            PlayersTurn = (PlayersTurn == 1 ? 2 : 1);
        }

        private void SwapPlayingSymbols()
        {
            (_playingSymbols[1], _playingSymbols[2]) = (_playingSymbols[2], _playingSymbols[1]);
        }
    }
}