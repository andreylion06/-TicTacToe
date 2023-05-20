using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLibrary.TicTacToeLibrary;

namespace TicTacToeConsoleApp.TicTacToeLibrary
{
    public static class GameSaving
    {
        private const string filePath = "save.txt";
        public static void SaveToFile(TicTacToeGame game)
        {
            string json = JsonConvert.SerializeObject(game, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static void LoadFromFile(TicTacToeGame game)
        {
            string json = File.ReadAllText(filePath);
            JsonConvert.PopulateObject(json, game);
        }
    }
}
