using Newtonsoft.Json;
using System.IO;

namespace TicTacToeConsoleApp.TicTacToeGame
{
    public static class GameSaving
    {
        private const string SavingFileName = "save.json";

        private static string GetSaveFilePath()
        {
            return Directory.GetCurrentDirectory() + $"\\{SavingFileName}";
        }

        public static void MakeSave(TicTacToe game)
        {
            string saveFilePath = GetSaveFilePath();
            if(!File.Exists(saveFilePath))
                File.Create("save.json");

            string output = JsonConvert.SerializeObject(game);
            File.WriteAllText(saveFilePath, output);
        }

        public static TicTacToeSavingModel LoadSave()
        {
            string saveFilePath = GetSaveFilePath();
            if (!File.Exists(saveFilePath))
                return null;

            //var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            string json = File.ReadAllText(saveFilePath);
            //var deserializedObj = JsonConvert.DeserializeObject<SavingGame>(json);


            if (TryParseJson(json, out TicTacToeSavingModel game))
            {
                return game;
            }
            return null;
        }

        public static bool TryParseJson<T>(string json, out T result)
        {
            bool success = true;
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };
            result = JsonConvert.DeserializeObject<T>(json, settings);
            return success;
        }
    }
}
