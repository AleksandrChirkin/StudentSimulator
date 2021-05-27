namespace StudentSimulator.Domain
{
    public class Game
    {
        public int Days { get; private set; }
        public Player Player { get; }
        public GlobalMap Map { get; }
        public int Id { get; }

        public Game(int days, Player player, GlobalMap map, int id)
        {
            Days = days;
            Player = player;
            Map = map;
            Id = id;
        }

        public void ChangeLocation(string name)
        {
            Map.CurrentLocationName = name;
        }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) ||
                                                   obj is Game game && game.Id == Id;

        public override int GetHashCode() => Id;
    }
}
