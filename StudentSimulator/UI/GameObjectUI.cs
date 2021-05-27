using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StudentSimulator.Domain;

namespace StudentSimulator.UI
{
    //графическая обертка над классами из логики
    //gameObject, player, InterfaceObject и т.д...
    class GameObjectUi<TObj> : IObjectUi
    {
        public Vector2 Coordinates { get; set; }
        public Texture2D Texture { get; private set; }
        public Texture2D FlashedTexture { get; private set; }
        public TObj LogicalGameObject { get; }

        public bool IsInteractable { get; }
        public string Name { get; set; }

        public bool IsFlashed { get; set; }

        public GameObjectUi(TObj gameObject, bool isInteractable)
        {
            LogicalGameObject = gameObject;
            IsInteractable = isInteractable;
            // в начало координат - левый верхний угол
            Coordinates = Vector2.Zero;
        }

        public void LoadTexture(ContentManager content, string pathToTexture)
        {
            Texture = content.Load<Texture2D>(pathToTexture);
        }

        public void LoadFlashedTexture(ContentManager content, string pathToTexture)
        {
            FlashedTexture = content.Load<Texture2D>(pathToTexture);
        }

        public bool MouseOnObj(float mouseX, float mouseY)
        {
            var minX = Coordinates.X;
            var minY = Coordinates.Y;
            var maxX = Texture.Width + minX;
            var maxY = Texture.Height + minY;
            return ((mouseX > minX) && (mouseX < maxX) && (mouseY > minY) && (mouseY < maxY));
        }

        public bool MouseClickedOn(string state)
        {
            // надо задать таймаут для нажатия
            return state.Equals("Pressed");
        }

        public void OnClick()
        {
            System.Console.WriteLine(Name);
        }
    }
}