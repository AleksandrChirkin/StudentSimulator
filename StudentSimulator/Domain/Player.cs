using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Player
    {
        public string Name { get; }
        public PlayerNeeds Needs { get; private set; }
        public ILearningSkill AlgebraSkill { get; private set; }
        public ILearningSkill ProgrammingSkill { get; private set; }
        public ILearningSkill PhilosophySkill { get; private set; }
        public int Authority { get; private set; }

        private readonly List<GameTask> tasks;
        // всё что выше, нужно лучше проработать и понять как игрок будет знать про свои скиллы.

        public IReadOnlyCollection<GameTask> GameTasks => tasks;

        public Player(string name)
        {
            Name = name;
            tasks = new List<GameTask>();
            Needs = new PlayerNeeds(0, 100, 0);
            AlgebraSkill = new AlgebraSkill();
            ProgrammingSkill = new ProgrammingSkill();
            PhilosophySkill = new PhilosophySkill();
        }
        
        public void InteractWith(GameObject gameObject)
        {
            tasks.Add(gameObject.GetNextTask());
        }

        public void MakeTask(GameTask task)
        {
            Needs += task.Prices;
            Authority += task.Authority;
            // тут может какая-то миниигра запускаться при выполнении.
            // можно передавать сюда лямбду.
        }
    }
}