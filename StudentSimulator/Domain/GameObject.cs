using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace StudentSimulator.Domain
{
    public class GameObject
    {
        public string Name { get; }
        public IReadOnlyCollection<GameTask> Tasks { get; }

        public GameObject(string name, params GameTask[] tasks)
        {
            Name = name;
            Tasks = tasks.ToList();
        }

        [JsonConstructor]
        public GameObject(string name, IReadOnlyCollection<GameTask> tasks)
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