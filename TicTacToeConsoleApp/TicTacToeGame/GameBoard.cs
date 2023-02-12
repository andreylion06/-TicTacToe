using Newtonsoft.Json;
using System;
using System.Linq;

namespace TicTacToeConsoleApp.TicTacToeGame
{
    public abstract class GameBoard
    {
        [JsonProperty]
        public char[] Board { get; set; }

        public GameBoard(char[] board)
        {
            Board = board;
        }

        public GameBoard()
        {
            Board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }

        public void SetGameCell(int numberOfCell, char symbol)
        {
            Board[numberOfCell - 1] = symbol;
        }

        public bool IsCellIsSet(int numberOfCell, char[] symbols)
        {
            return symbols.Contains(Board[numberOfCell - 1]);
        }

        //It is possible to set different functionality depending on UI
        public abstract void PrintBoard(char[] playingSymbols, int playersTurn, bool consoleClear = true);
        public abstract string ChooseCell(string exception = null);
        public abstract void GameIsOver(int gameResult);

        public int CheckIfGameIsOver(char[] symbols)
        {
            //If Someone Wins, Return the Player's Index
            //If It Is Draw, Return 0
            //Else Return -1

            //Winning Condition For 1 Row
            bool res;
            if (res = Board[0] == Board[1] && Board[1] == Board[2])
            {
                return Array.IndexOf(symbols, Board[0]) + 1;
            }
            //Winning Condition For 2 Row
            else if (Board[3] == Board[4] && Board[4] == Board[5])
            {
                return Array.IndexOf(symbols, Board[3]) + 1;
            }
            //Winning Condition For 3 Row
            else if (Board[6] == Board[7] && Board[7] == Board[8])
            {
                return Array.IndexOf(symbols, Board[6]) + 1;
            }

            //Winning Condition For 1 Column
            else if (Board[0] == Board[3] && Board[3] == Board[6])
            {
                return Array.IndexOf(symbols, Board[0]) + 1;
            }
            //Winning Condition For 2 Column
            else if (Board[1] == Board[4] && Board[4] == Board[7])
            {
                return Array.IndexOf(symbols, Board[1]) + 1;
            }
            //Winning Condition For 3 Column
            else if (Board[2] == Board[5] && Board[5] == Board[8])
            {
                return Array.IndexOf(symbols, Board[2]) + 1;
            }

            //Diagonals
            else if (Board[0] == Board[4] && Board[4] == Board[8])
            {
                return Array.IndexOf(symbols, Board[0]) + 1;
            }
            else if (Board[2] == Board[4] && Board[4] == Board[6])
            {
                return Array.IndexOf(symbols, Board[2]) + 1;
            }

            // Draw
            else if (Board[0] != '1' && Board[1] != '2' && Board[2] != '3' &&
                Board[3] != '4' && Board[4] != '5' && Board[5] != '6' &&
                Board[6] != '7' && Board[7] != '8' && Board[8] != '9')
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}