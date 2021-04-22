namespace StudentSimulator.Domain
{
    public class Task
    {
        public bool IsNecessary { get; }
        private TaskResult taskResult;
        // TODO: ну чё нить ещё тут придумать.

        public TaskResult MakeTask()
        {
            // Какая-то логика таска, которая на выходе дает результат, зависящий от текущей статы игрока
            // (получается, нужно протащить сюда игрока, чтобы брать стату)
            return new TaskResult();
        }

    }
}