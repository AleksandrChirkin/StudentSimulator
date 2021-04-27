using System;
using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public static class GameManipulator
    {
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
            //TODO: как-то записываем сохраненную игру в файл
        }

        public static Dictionary<int, Game> GetListOfGames()
        {
            var games = new Dictionary<int, Game>();
            //TODO: как-то берем инфу о сохраненной игре из файлика
            return games;
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
