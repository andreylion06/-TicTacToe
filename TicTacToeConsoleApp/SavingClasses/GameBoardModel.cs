namespace TicTacToeConsoleApp.SavingClasses
{
    public class GameBoardModel
    {
        public char[] Board { get; set; }
        public GameBoardModel(char[] board)
        {
            Board = board;
        }
    }
}
