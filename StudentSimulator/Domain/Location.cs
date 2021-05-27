using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Location
    {
        public string Name { get; }
        public IReadOnlyCollection<GameObject> Entities { get; }

        public Location(string name, IReadOnlyCollection<GameObject> entities)
        {
            Name = name;
            Entities = entities;
        }
    }
}