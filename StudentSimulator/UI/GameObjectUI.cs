using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StudentSimulator.UI
{
    //графическая обертка над классами из логики
    //gameObject, player, InterfaceObject и т.д...
    class GameObjectUi<TObj> : IObjectUi
    {
        public Vector2 Coordinates { get; set; }
        public Texture2D Texture { get; private set; }
        public TObj LogicalGameObject { get; }

        public bool IsInteractable { get; }

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



    }
}