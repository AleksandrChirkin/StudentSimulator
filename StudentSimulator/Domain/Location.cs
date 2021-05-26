using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Location
    {
        public string Name { get; }
        private List<GameObject> gameObjects;
        public IReadOnlyCollection<GameObject> Entities => gameObjects;

        public Location(string name, List<GameObject> gameObjs)
        {
            Name = name;
            gameObjects = gameObjs;
        }
    }
}