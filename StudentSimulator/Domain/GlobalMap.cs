using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class GlobalMap
    {
        public Location CurrentLocation { get; private set; }
        private Dictionary<string, Location> locations;
        public void ChangeLocation(string name) { } // ??? зачем нам чендж локейшн и в гейме и тут
    }
}