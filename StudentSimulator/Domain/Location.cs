using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Location
    {
        public string Name { get; }
        private Dictionary<string, GameObject> gameObjects;
        public IReadOnlyDictionary<string, GameObject> Entities => gameObjects;

        public Location(Dictionary<string, GameObject> gameObjs)
        {
            gameObjects = gameObjs;
        }
    }
}