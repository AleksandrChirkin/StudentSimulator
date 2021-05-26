namespace StudentSimulator.Domain
{
    public class PlayerNeeds
    {
        public int Expulsion { get; }
        //public int Time { get; }
        public int Energy { get; }
        public int Experience { get; }

        public PlayerNeeds(int expulsion, /*int time,*/ int energy, int experience)
        {
            Expulsion = expulsion;
        //    Time = time;
            Energy = energy;
            Experience = experience;
        }

        public static PlayerNeeds operator+(PlayerNeeds stat1, PlayerNeeds stat2)
        {

            var expulsion = stat1.Expulsion + stat2.Expulsion;
            //var time = stat1.Time + stat2.Time;
            var energy = stat1.Energy + stat2.Energy;
            var experience = stat1.Experience + stat2.Experience;
            return new PlayerNeeds(Normalize(expulsion), 
                /*Normalize(time),*/ 
                Normalize(energy),
                Normalize(experience));
        }

        private static int Normalize(int number, int lowerBound, int upperBound)
        {
            return number < lowerBound ? lowerBound : number > upperBound ? upperBound : number;
        }

        private static int Normalize(int number) => Normalize(number, 0, 100);

    }
}
