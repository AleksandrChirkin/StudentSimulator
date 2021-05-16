using System;

namespace StudentSimulator.Domain
{
    public class Game
    {
        public int Days { get; private set; }
        public Player Player { get; }
        public GlobalMap Map { get; }
        
        public readonly int ID;
        public event Action<Location> OnChangeLocation;

        public Game(int days, Player player, GlobalMap map, int id)
        {
            Days = days;
            Player = player;
            Map = map;
            ID = id;
            OnChangeLocation += Location_Changed;
        }

        public void ChangeLocation(Location location)
        {
            OnChangeLocation?.Invoke(location);
        }

        private void Location_Changed(Location location)
        {
            Map.CurrentLocation = location;
        }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) ||
                                                   obj is Game game && game.ID == ID;

        public override int GetHashCode() => ID;
    }
}
