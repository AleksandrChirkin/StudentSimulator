using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.Domain
{
    class Game
    {
        public int Days { get; private set; }
        public Player Player { get; }
        public GlobalMap Map { get; }

        public Game(int days, Player player, GlobalMap map)
        {

        }

        public void ChangeLocation(string name)
        {

        }
    }
}
