using System;
using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class GlobalMap
    {
        private Dictionary<string, Location> locations;
        public Location CurrentLocation { get; private set; }
        public IReadOnlyDictionary<string, Location> Locations => locations;
        
        public GlobalMap(Dictionary<string, Location> locations)
        {
            this.locations = locations;
        }

        public void ChangeLocation(string name)
        {
            if (!locations.ContainsKey(name))
                throw new InvalidOperationException();
            CurrentLocation = locations[name];
        }
    }
}