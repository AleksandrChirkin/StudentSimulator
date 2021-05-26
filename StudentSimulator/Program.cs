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
