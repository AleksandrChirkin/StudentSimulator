using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Location
    {
        public string Name { get; }
        private Dictionary<string, GameObject> gameObjects; // не лучше ли GameObject сделать TaskGiver
        public IReadOnlyDictionary<string, GameObject> Entities => gameObjects;
    }
}