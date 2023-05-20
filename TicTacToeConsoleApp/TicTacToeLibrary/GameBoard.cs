using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeConsoleApp.TicTacToeLibrary
{
    public class GameBoard
    {
        [JsonProperty]
        public readonly char[] DefaultField = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        // In this class, occupied cells are marked with their own characters.
        // When outputting, we take symbols from "main" class
        [JsonProperty]
        private Dictionary<int, char> _fieldSymbols = new() { { 1, 'f' }, { 2, 's' } };
        [JsonProperty]
        public char[] Field { get; private set; }

        public GameBoard()
        {
            SetFieldToDefault();
        }

        public void SetFieldToDefault()
        {
            Field = (char[])DefaultField.Clone();
        }

        public void PrintBoard(Dictionary<int, char> playingSymbols)
        {
            char[] outputField = GenerateFieldWithSymbols(playingSymbols);

            Console.WriteLine(
                $"\t {outputField[0]} | {outputField[1]} | {outputField[2]}\n" +
                "\t---+---+----\n" +
                $"\t {outputField[3]} | {outputField[4]} | {outputField[5]}\n" +
                "\t---+---+----\n" +
                $"\t {outputField[6]} | {outputField[7]} | {outputField[8]}\n");
        }

        public char[] GenerateFieldWithSymbols(Dictionary<int, char> playingSymbols)
        {
            char[] outputField = (char[])Field.Clone();

            for (int i = 0; i < Field.Length; i++)
            {
                if (outputField[i] == _fieldSymbols[1])
                    outputField[i] = playingSymbols[1];
                else if (outputField[i] == _fieldSymbols[2])
                    outputField[i] = playingSymbols[2];
            }

            return outputField;
        }

        public void SetGameCell(int numberOfCell, int playersNumber)
        {
            if (_fieldSymbols.ContainsKey(playersNumber) == false)
                throw new Exception("Number of the player is invalid!");
            if (CheckValidNumberOfCell(numberOfCell) == false)
                throw new Exception("Please enter a valid number between 1 and 9.");
            if(CheckCellIsFree(numberOfCell) == false)
                throw new Exception($"Cell \"{numberOfCell}\" is already set.");

            Field[numberOfCell - 1] = _fieldSymbols[playersNumber];
        }

        public bool CheckCellIsFree(int numberOfCell)
        {
            if (CheckValidNumberOfCell(numberOfCell) == false)
                throw new Exception("Please enter a valid number between 1 and 9.");

            return DefaultField.Contains(Field[numberOfCell - 1]);
        }

        public bool CheckValidNumberOfCell(int numberOfCell)
        {
            return numberOfCell - 1 >= 0 && numberOfCell <= DefaultField.Length;
        }        
    }
}