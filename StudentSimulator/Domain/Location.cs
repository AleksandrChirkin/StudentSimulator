using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Location
    {
        public string Name { get; }
        private HashSet<GameObject> gameObjects;
        public IReadOnlyCollection<GameObject> Entities => gameObjects;

        public Location(HashSet<GameObject> gameObjs)
        {
            gameObjects = gameObjs;
        }
    }
}