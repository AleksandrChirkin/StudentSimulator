using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Location
    {
        public string Name { get; }
        private Dictionary<string, GameObject> gameObjects; // не лучше ли GameObject сделать TaskGiver
        // Можно, но ведь эти объекты прежде всего игровые сущности, а уже потом TaskGivers
        public IReadOnlyDictionary<string, GameObject> Entities => gameObjects;

        public Location(Dictionary<string, GameObject> gameObjs)
        {
            gameObjects = gameObjs;
        }
    }
}