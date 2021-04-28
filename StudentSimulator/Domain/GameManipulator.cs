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
        
        public static event Action OnCreateGame;
        public static event Action<Game> OnLoadGame;
        public static event Action OnSaveGame;

        static GameManipulator()
        {
            OnCreateGame += Game_Created;
            OnLoadGame += Game_Loaded;
            OnSaveGame += Game_Saved;
        }
        private static void Game_Created()
        {
            var game = new Game(0, new Player(), 
                new GlobalMap(new Dictionary<string, Location>()), 
                new Random().Next());
            currentGame = game;
        }

        private static void Game_Loaded(Game game)
        {
            currentGame = game;
        }

        private static void Game_Saved()
        {
            var games = GetListOfGames();
            if (!games.ContainsKey(currentGame.ID))
                games[currentGame.ID] = currentGame;
            using (var writer = new JsonTextWriter
                (new StreamWriter(new FileStream(savedGamesFile, FileMode.OpenOrCreate))))
            {
                JsonSerializer.Create().Serialize(writer, games);
            }
        }

        public static Dictionary<int, Game> GetListOfGames()
        {
            if (!File.Exists(savedGamesFile))
                return new Dictionary<int, Game>();
            using (var reader = new JsonTextReader(new StreamReader(savedGamesFile)))
            {
                var jsonString = reader.ReadAsString();
                return JsonConvert.DeserializeObject<Dictionary<int, Game>>(jsonString);
            }
        }
        
        public static void CreateGame()
        {
            OnCreateGame?.Invoke();
        }

        public static void LoadGame(Game index)
        {
            OnLoadGame?.Invoke(index);
        }

        public static void SaveGame()
        {
            OnSaveGame?.Invoke();
        }
    }
}
