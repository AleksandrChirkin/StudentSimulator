namespace StudentSimulator.Domain
{
    public class Task
    {
        public bool IsNecessary { get; }
        private TaskResult taskResult;
        // TODO: ну чё нить ещё тут придумать.
        // в чём вообще сущность таска? Типа, зачем таск меняет игрока,
        // если игрок сам при выполнении может себя изменить. 
        // метод мейктаск должен быть у игрока получается.
        // а таск резалт зачем тогда. может он не нужен?
        // значит в таске должна быть инфа о стоимости его выполнения и награды.
        public StatParameters Prices;

        public Task(StatParameters prices)
        {
            Prices = prices;
        }
    }
}