using System.Linq;
using TicTacToeConsoleApp.TicTacToeLibrary;
using TicTacToeLibrary.TicTacToeLibrary;

namespace TicTacToeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame(new GameBoard());

            if (args.Contains("--load-saved"))
                GameSaving.LoadFromFile(game);

            game.Start();
        }
    }
}