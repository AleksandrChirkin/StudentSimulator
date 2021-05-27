using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentSimulator.Domain
{
    public class GlobalMap
    {
        private string _currentLocationName;
        public Location Home { get; }
        public Location Univer { get; }

        public string CurrentLocationName
        {
            get => _currentLocationName;
            set
            {
                if (!value.Equals("Home") && !value.Equals("Univer"))
                    throw new InvalidOperationException("Invalid location name");
                _currentLocationName = value;
            }
        }
        
        [JsonIgnore]
        public Location CurrentLocation => CurrentLocationName == "Home" ? Home : Univer;

        public GlobalMap(HashSet<Location> locations)
        {
            foreach (var location in locations)
            {
                if (location.Name.Equals("Home") && Home == null)
                    Home = location;
                else if (location.Name.Equals("Univer") && Univer == null)
                    Univer = location;
                else
                    throw new InvalidOperationException("Invalid location name");
            }
        }

        [JsonConstructor]
        public GlobalMap(Location home, Location univer, string currentLocationName)
        {
            Home = home;
            Univer = univer;
            _currentLocationName = currentLocationName;
        }
    }
}