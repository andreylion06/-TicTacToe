using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeConsoleApp.HelperClasses;

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
        private GameBoard Board { get; set; }

        private char CurrentSymbol
        {
            get
            {
                return playingSymbols[PlayersTurn - 1];
            }
        }

        private string CurrentStepValue { get; set; }

        public TicTacToe(int playersTurn, char[] playingSymbols, GameBoard board)
        {
            PlayersTurn = playersTurn;
            PlayingSymbols = playingSymbols;
            Board = board;
        }

        public void Start()
        {
            Board.PrintBoard(PlayingSymbols, PlayersTurn);
            CurrentStepValue = Board.ChooseCell();
            int gameIsOver = Board.CheckIfGameIsOver(PlayingSymbols);

            while (gameIsOver == -1)
            {
                gameIsOver = Step(CurrentStepValue);
            }

            Board.GameIsOver(gameIsOver);
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

            Board.PrintBoard(PlayingSymbols, PlayersTurn);

            int endOfGame = Board.CheckIfGameIsOver(PlayingSymbols);
            if (endOfGame != -1)
                return endOfGame;

            CurrentStepValue = Board.ChooseCell(exception);
            return -1;
        }
    }
}