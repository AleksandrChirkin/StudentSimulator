namespace StudentSimulator.Domain
{
    public class Player
    {
        public string Name { get; }
        public int Expulsion { get; } // отчисление
        public int Time { get; }
        public int Experience { get; }
        public int AlgebraSkill { get; private set; }
        public int ProgrammingSkill { get; private set; }
        public int PhilosophySkill { get; private set; }
        public int Authority { get; private set; }
        // всё что выше, нужно лучше проработать и понять как игрок будет знать про свои скиллы.

    }
}