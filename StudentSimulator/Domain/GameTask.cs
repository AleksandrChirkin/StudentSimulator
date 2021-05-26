namespace StudentSimulator.Domain
{
    public class GameTask
    {
        public bool IsNecessary { get; }
        public string Name { get; }
        public string Description { get; }
        // TODO: ну чё нить ещё тут придумать.
        // в чём вообще сущность таска? Типа, зачем таск меняет игрока,
        // если игрок сам при выполнении может себя изменить. 
        // метод мейктаск должен быть у игрока получается.
        // а таск резалт зачем тогда. может он не нужен?
        // значит в таске должна быть инфа о стоимости его выполнения и награды.
        public PlayerNeeds Prices { get; }
        public int Authority { get; }

        public GameTask(bool isNecessary,
            string name,
            string description,
            PlayerNeeds prices,
            int authority = 0) 
        {
            IsNecessary = isNecessary;
            Name = name;
            Description = description;
            Prices = prices;
            Authority = authority;
        }
    }
}