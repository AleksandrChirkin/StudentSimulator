using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class GlobalMap
    {
        private HashSet<Location> locations;
        public Location CurrentLocation { get; set; }
        public IReadOnlyCollection<Location> Locations => locations;
        
        public GlobalMap(HashSet<Location> locations)
        {
            this.locations = locations;
        }
    }
}