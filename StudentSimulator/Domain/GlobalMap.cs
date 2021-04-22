using System.Collections.Generic;

namespace StudentSimulator.Domain
{
    public class GlobalMap
    {
        public Location CurrentLocation { get; private set; }
        private Dictionary<string, Location> locations;
        public void ChangeLocation(string name) { } // ??? зачем нам чендж локейшн и в гейме и тут
        // В гейме у него дергается ивент (и выполняется какая-то графика) и вызывается тутошний метод
        // (у него нет связи графикой)
        // GlobalMap, по идее, должен знать, какая из его локаций текущая и позволять менять ее только у себя
        // Гейм же - лишь класс, плотно взаимодействующий с графикой;
        // всю логику гейм вызывает у других классов из domain
    }
}