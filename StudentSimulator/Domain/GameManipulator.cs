using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.Domain
{
    public static class GameManipulator
    {
        public static Game currentGame { get; private set; }
        public static List<Game> GetListOfGames() => new List<Game>();
        public static void CreateGame() { }
        public static void LoadGame() { }
        public static void SaveGame() { }
    }
}
