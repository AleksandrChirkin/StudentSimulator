using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace StudentSimulator.Domain
{
    public class Game
    {
        private static readonly string savedGamesFile = "./games.json";
        public int Days { get; private set; }
        public Player Player { get; }
        public GlobalMap Map { get; }
        public int Id { get; }
        
        [JsonConstructor]
        public Game(int days, Player player, GlobalMap map, int id)
        {
            Days = days;
            Player = player;
            Map = map;
            Id = id;
        }
        
        public static Game CreateGame(bool forTest = false)
        {
            var locations = new HashSet<Location>();
            var objectsBase = new XmlDocument();
            var basePath = $"{Assembly.GetExecutingAssembly().Location}/../../../..";
            objectsBase.Load(forTest ? $"{basePath}/../objectsBase.xml" : $"{basePath}/objectsBase.xml");
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
            var game = new Game(0, new Player("Student"), 
                new GlobalMap(locations),new Random().Next());
            game.ChangeLocation("Univer");
            return game;
        }

        /*public static void LoadGame(Game game)
        {
            CurrentGame = game;
        }*/

        public static void SaveGame(Game game)
        {
            var games = GetSetOfGames();
            if (!games.Contains(game))
                games.Add(game);
            File.WriteAllText(savedGamesFile, JsonSerializer.Serialize(games));
        }

        public static HashSet<Game> GetSetOfGames() => File.Exists(savedGamesFile) 
            ? JsonSerializer.Deserialize<HashSet<Game>>(File.ReadAllText(savedGamesFile)) 
            : new HashSet<Game>();

        public void ChangeLocation(string name)
        {
            Map.CurrentLocationName = name;
        }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) ||
                                                   obj is Game game && game.Id == Id;

        public override int GetHashCode() => Id;
    }
}
