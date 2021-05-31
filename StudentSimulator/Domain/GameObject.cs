using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace StudentSimulator.Domain
{
    public class GameObject
    {
        [XmlElement("ObjectName")]
        public string Name { get; set; }

        [XmlElement(typeof(List<GameTask>))] 
        public List<GameTask> Tasks { get; set; }

        public GameObject() {}

        [JsonConstructor]
        public GameObject(string name, List<GameTask> tasks)
        {
            Name = name;
            Tasks = tasks;
        }

        private IEnumerable<GameTask> GetTasks()
        {
            foreach (var task in Tasks)
                yield return task;
        }

        public GameTask GetNextTask()
        {
            return GetTasks().GetEnumerator().Current;
        }
    }
}