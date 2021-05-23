using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSimulator.UI;

namespace StudentSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new GameMain())
                game.Run();
        }
    }
}
