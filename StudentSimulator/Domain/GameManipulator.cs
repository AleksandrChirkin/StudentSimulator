using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace StudentSimulator.Domain
{
    public static class GameManipulator
    {
        private static readonly string savedGamesFile = $"{Environment.CurrentDirectory}/games.json";
        public static Game currentGame { get; private set; }
        
        public static void CreateGame()
        {
            var game = new Game(0, new Player(), 
                new GlobalMap(new HashSet<Location>()), 
                new Random().Next());
            currentGame = game;
        }

        public static void LoadGame(Game game)
        {
            currentGame = game;
        }

        public static void SaveGame()
        {
            var games = GetSetOfGames();
            if (!games.Contains(currentGame))
                games.Add(currentGame);
            using (var writer = new JsonTextWriter
                (new StreamWriter(new FileStream(savedGamesFile, FileMode.OpenOrCreate))))
            {
                JsonSerializer.Create().Serialize(writer, games);
            }
            currentGame = null;
        }

        public static HashSet<Game> GetSetOfGames()
        {
            if (!File.Exists(savedGamesFile))
                return new HashSet<Game>();
            using (var reader = new JsonTextReader(new StreamReader(savedGamesFile)))
            {
                var jsonString = reader.ReadAsString();
                return JsonConvert.DeserializeObject<HashSet<Game>>(jsonString);
            }
        }
    }
}
