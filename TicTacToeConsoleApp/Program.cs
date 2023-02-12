using TicTacToeConsoleApp.TicTacToeGame;

TicTacToe game = new TicTacToe(9, new char[] { 'X', 'O' }, new GameBoardConsole());
game.Start();

//SavingGame saving = GameSaving.LoadSave();