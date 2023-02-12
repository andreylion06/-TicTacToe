using Newtonsoft.Json;
using System;

namespace TicTacToeConsoleApp.TicTacToeGame
{
    public class TicTacToe
    {
        private int playerTurn;
        [JsonProperty]
        public int PlayersTurn
        {
            get { return playerTurn; }
            set
            {
                if (value != 1 && value != 2)
                    playerTurn = 1;
                else
                    playerTurn = value;
            }
        }

        private char[] playingSymbols;
        [JsonProperty]
        public char[] PlayingSymbols
        {
            get { return playingSymbols; }
            set
            {
                if (value.Length != 2)
                    playingSymbols = new char[] { 'X', 'O' };
                else
                    playingSymbols = value;
            }
        }

        [JsonProperty]
        private int[] Score { get; set; }

        [JsonProperty]
        private GameBoard Board { get; set; }

        private char CurrentSymbol
        {
            get
            {
                return playingSymbols[PlayersTurn - 1];
            }
        }

        private string CurrentStepValue { get; set; }

        public TicTacToe(int playersTurn, char[] playingSymbols, GameBoard board, int[] score)
        {
            PlayersTurn = playersTurn;
            PlayingSymbols = playingSymbols;
            Board = board;

            if (score == null)
                Score = new int[] { 0, 0 };
            else 
                Score = score;
        }

        public void Start()
        {
            Board.PrintBoard(PlayingSymbols, Score, PlayersTurn, false);
            CurrentStepValue = Board.ChooseCell();
            int roundIsOver = Board.CheckIfGameIsOver(PlayingSymbols);

            while (roundIsOver == -1)
            {
                roundIsOver = Step(CurrentStepValue);
            }

            if(roundIsOver == 0 || roundIsOver == 1)
                Score[0] += 1;
            else if(roundIsOver == 0 || roundIsOver == 2)
                Score[1] += 1;

            if (Board.RoundIsOver(roundIsOver) == true)
            {
                Array.Reverse(playingSymbols);
                Board.SetDefaultBoard();
                Start();
            }
                
        }

        public int Step(string numberOfCell)
        {
            int number;
            string exception = null;

            if (numberOfCell.ToLower() == "s")
                GameSaving.MakeSave(this);
            else if (numberOfCell.ToLower() == "l")
            {
                TicTacToeSavingModel saving = GameSaving.LoadSave();
                if (saving != null)
                {
                    PlayersTurn = saving.PlayersTurn;
                    PlayingSymbols = saving.PlayingSymbols;
                    Score = saving.Score;
                    Board.Board = saving.Board.Board;
                }
            }
            else
            {
                if (int.TryParse(numberOfCell, out number) == false)
                    exception = "Please enter a valid number between 1 and 9.";
                else if (number < 1 || number > 9)
                    exception = $"There is no cell '{number}' on the field.";
                else if (Board.IsCellIsSet(number, PlayingSymbols))
                    exception = $"Cell '{number}' is already set.";

                if (exception == null)
                {
                    Board.SetGameCell(number, CurrentSymbol);
                    PlayersTurn = PlayersTurn == 1 ? 2 : 1;
                }
            }

            Board.PrintBoard(PlayingSymbols, Score, PlayersTurn);

            int endOfGame = Board.CheckIfGameIsOver(PlayingSymbols);
            if (endOfGame != -1)
                return endOfGame;

            CurrentStepValue = Board.ChooseCell(exception);
            return -1;
        }
    }
}