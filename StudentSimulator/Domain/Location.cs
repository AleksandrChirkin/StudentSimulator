using System.Collections.Generic;
using System.Xml.Serialization;

namespace StudentSimulator.Domain
{
    public class Location
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement(typeof(List<GameObject>))]
        public List<GameObject> Entities { get; set; }

        public Location(string name, List<GameObject> entities)
        {
            Name = name;
            Entities = entities;
        }
        
        public Location(){}
    }
}