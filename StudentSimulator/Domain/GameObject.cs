using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class GameObject
    {
        public string Name { get; }
        private List<GameTask> tasks = new List<GameTask>();

        public GameObject(string name, params GameTask[] tasks)
        {
            Name = name;
            this.tasks.AddRange(tasks);
        }

        private IEnumerable<GameTask> GetTasks()
        {
            foreach (var task in tasks)
                yield return task;
        }

        public GameTask GetNextTask()
        {
            return GetTasks().GetEnumerator().Current;
        }
    }
}