using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace StudentSimulator.Domain
{
    public class GlobalMap
    {
        private string _currentLocationName;
        [XmlElement]
        public Location Home { get; set; }
        
        [XmlElement]
        public Location Univer { get; set; }
        
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

        public GlobalMap() {}

        [JsonConstructor]
        public GlobalMap(Location home, Location univer, string currentLocationName)
        {
            Home = home;
            Univer = univer;
            CurrentLocationName = currentLocationName;
        }
    }
}