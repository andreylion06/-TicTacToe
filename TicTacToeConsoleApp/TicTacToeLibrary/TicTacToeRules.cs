using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsoleApp.TicTacToeLibrary
{
    internal class TicTacToeRules
    {
        public static GameResult CheckIfGameIsOver(char[] field, char[] playingSymbols)
        {
            //Winning Condition For 1 Row
            int result;
            if (field[0] == field[1] && field[1] == field[2])
                result = Array.IndexOf(playingSymbols, field[0]) + 1;

            //Winning Condition For 2 Row
            else if (field[3] == field[4] && field[4] == field[5])
                result = Array.IndexOf(playingSymbols, field[3]) + 1;

            //Winning Condition For 3 Row
            else if (field[6] == field[7] && field[7] == field[8])
                result = Array.IndexOf(playingSymbols, field[6]) + 1;

            //Winning Condition For 1 Column
            else if (field[0] == field[3] && field[3] == field[6])
                result = Array.IndexOf(playingSymbols, field[0]) + 1;   

            //Winning Condition For 2 Column
            else if (field[1] == field[4] && field[4] == field[7])
                result = Array.IndexOf(playingSymbols, field[1]) + 1;
            //Winning Condition For 3 Column
            else if (field[2] == field[5] && field[5] == field[8])
                result = Array.IndexOf(playingSymbols, field[2]) + 1;   

            //Diagonals
            else if (field[0] == field[4] && field[4] == field[8])
                result = Array.IndexOf(playingSymbols, field[0]) + 1;
            else if (field[2] == field[4] && field[4] == field[6])
                result = Array.IndexOf(playingSymbols, field[2]) + 1;

            // Draw
            else if (field.Distinct().Count() == playingSymbols.Count())
                result = 3;
            else
                result = 0;

            return (GameResult)result;
        }
    }
}
