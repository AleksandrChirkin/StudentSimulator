using System;

namespace StudentSimulator.Domain
{
    public class Game
    {
        public int Days { get; private set; }
        public Player Player { get; }
        public GlobalMap Map { get; }
        
        public readonly int ID;
        public event Action<string> OnChangeLocation;

        public Game(int days, Player player, GlobalMap map, int id)
        {
            Days = days;
            Player = player;
            Map = map;
            ID = id;
        }

        public void ChangeLocation(string name)
        {
            Map.ChangeLocation(name);
            OnChangeLocation?.Invoke(name);
        }
    }
}
