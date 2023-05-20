using TicTacToeConsoleApp.TicTacToeLibrary;
using TicTacToeLibrary.TicTacToeLibrary;

namespace TicTacToeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame(new GameBoard());
            
            game.Start();
        }
    }
}