using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsoleApp.TicTacToeGame
{
    public class TicTacToeSavingModel
    {
        public int PlayersTurn { get; set; }
        public char[] PlayingSymbols { get; set; }
        public SavingBoard Board { get ; set; }
        public TicTacToeSavingModel(int playersTurn, char[] playingSymbols, SavingBoard board)
        {
            PlayersTurn = playersTurn;
            PlayingSymbols = playingSymbols;
            Board = board;
        }
    }
}
