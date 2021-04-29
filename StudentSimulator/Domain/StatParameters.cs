using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.Domain
{
    public class StatParameters
    {
        public int Expulsion { get; }
        public int Time { get; }
        public int Energy { get; }
        public int Experience { get; }

        public StatParameters(int expulsion, int time, int energy, int experience)
        {
            Expulsion = expulsion;
            Time = time;
            Energy = energy;
            Experience = experience;
        }
    }
}
