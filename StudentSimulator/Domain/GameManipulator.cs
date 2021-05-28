using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace StudentSimulator.Domain
{
    public static class GameManipulator
    {
        private static readonly string savedGamesFile = "./games.json";
        public static Game CurrentGame { get; private set; }
        
        public static void CreateGame(bool forTest = false)
        {
            var locations = new HashSet<Location>();
            var objectsBase = new XmlDocument();
            var basePath = "../../../objectsBase.xml";
            objectsBase.Load(forTest ? $"../{basePath}" : basePath);
            if (objectsBase.DocumentElement != null)
                foreach (XmlNode node in objectsBase.DocumentElement)
                {
                    var locationName = node.Attributes?.GetNamedItem("name").InnerText;
                    var locationBuilder = new LocationBuilder();
                    var xmlNodeList = node["objects"]?.ChildNodes;
                    if (xmlNodeList != null)
                        foreach (XmlNode element in xmlNodeList)
                            locationBuilder.AddGameObject(new GameObject
                                (element.Attributes?.GetNamedItem("name").InnerText));
                    locations.Add(locationBuilder.Build(locationName));
                }
            CurrentGame = new Game(0, new Player("Student"), 
                new GlobalMap(locations),new Random().Next());
            CurrentGame.ChangeLocation("Univer");
        }

        public static void LoadGame(Game game)
        {
            CurrentGame = game;
        }

        public static void SaveGame()
        {
            var games = GetSetOfGames();
            if (!games.Contains(CurrentGame))
                games.Add(CurrentGame);
            File.WriteAllText(savedGamesFile, JsonSerializer.Serialize(games));
            CurrentGame = null;
        }

        public static HashSet<Game> GetSetOfGames() => File.Exists(savedGamesFile) 
            ? JsonSerializer.Deserialize<HashSet<Game>>(File.ReadAllText(savedGamesFile)) 
            : new HashSet<Game>();
    }
}
