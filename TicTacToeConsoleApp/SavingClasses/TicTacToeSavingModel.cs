
namespace TicTacToeConsoleApp.TicTacToeGame
{
    public class TicTacToeSavingModel
    {
        public int PlayersTurn { get; set; }
        public char[] PlayingSymbols { get; set; }
        public int[] Score { get; set; }
        public SavingBoard Board { get ; set; }
        public TicTacToeSavingModel(int playersTurn, 
            char[] playingSymbols, int[] score, SavingBoard board)
        {
            PlayersTurn = playersTurn;
            PlayingSymbols = playingSymbols;
            Score = score;
            Board = board;
        }
    }
}
