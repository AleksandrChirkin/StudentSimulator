using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StudentSimulator.Domain;


namespace StudentSimulator.UI
{
    public class PlayerUI : IObjectUI
    {
        public Vector2 Coordinates { get; set; }
        public Texture2D Texture { get; private set; }
        
        public Player Player { get; }
        
        public PlayerUI(Player player)
        {
            Player = player;
            Coordinates = Vector2.Zero;
        }
        
        public void LoadTexture(ContentManager content, string pathToTexture)
        {
            Texture = content.Load<Texture2D>(pathToTexture);
        }
    }
}