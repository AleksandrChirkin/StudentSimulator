using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class Player
    {
        public string Name { get; }
        public StatParameters Stats { get; private set; }
        public ISkillParameters AlgebraSkill { get; private set; }
        public ISkillParameters ProgrammingSkill { get; private set; }
        public ISkillParameters PhilosophySkill { get; private set; }
        public int Authority { get; private set; }

        private readonly List<GameTask> tasks = new List<GameTask>();
        // всё что выше, нужно лучше проработать и понять как игрок будет знать про свои скиллы.

        public void InteractWith(GameObject gameObject)
        {
            tasks.Add(gameObject.GetNextTask());
        }

        public void MakeTask(GameTask task)
        {
            Stats += task.Prices;
            // тут может какая-то миниигра запускаться при выполнении.
            // можно передавать сюда лямбду.
        }
    }
}