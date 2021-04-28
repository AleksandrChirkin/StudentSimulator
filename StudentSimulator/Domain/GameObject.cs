using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class GameObject
    {
        public string Name { get; }
        private List<Task> tasks = new List<Task>();

        public GameObject(string name, params Task[] tasks)
        {
            Name = name;
            this.tasks.AddRange(tasks);
        }

        private IEnumerable<Task> GetTasks()
        {
            foreach (var task in tasks)
                yield return task;
        }

        public Task GetNextTask()
        {
            return GetTasks().GetEnumerator().Current;
        }
    }
}