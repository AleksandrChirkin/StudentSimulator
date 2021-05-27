using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace StudentSimulator.Domain
{
    public static class GameManipulator
    {
        private static readonly string savedGamesFile = "./games.json";
        public static Game currentGame { get; private set; }
        
        public static void CreateGame()
        {
            var locations = new HashSet<Location>();
            var objectsBase = new XmlDocument();
            objectsBase.Load("../../objectsBase.xml");
            foreach (XmlNode node in objectsBase.DocumentElement)
            {
                var locationName = node.Attributes.GetNamedItem("name").InnerText;
                var locationBuilder = new LocationBuilder();
                foreach (XmlNode element in node["objects"].ChildNodes)
                    locationBuilder.AddGameObject(new GameObject
                        (element.Attributes.GetNamedItem("name").InnerText));
                locations.Add(locationBuilder.Build(locationName));
            }
            currentGame = new Game(0, new Player(), 
                new GlobalMap(locations),new Random().Next());
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
                JsonSerializer.Create().Serialize(writer, games);
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
