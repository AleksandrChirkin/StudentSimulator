using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StudentSimulator.Domain;

namespace StudentSimulator.UI
{
    //графическая обертка над классами из логики
    //gameObject, player, InterfaceObject и т.д...
    class GameObjectUI<ObjectType> : IObjectUI
    {
        public Vector2 Coordinates { get; set; }
        public Texture2D Texture { get; private set; }
        public ObjectType LogicalGameObject { get; private set; }

        public bool IsInteractable { get; private set; }

        public GameObjectUI(ObjectType gameObject, bool isINnteractable)
        {
            LogicalGameObject = gameObject;
            IsInteractable = isINnteractable;
            // в начало координат - левый верхний угол
            Coordinates = Vector2.Zero;
        }

        public void LoadTexture(ContentManager content, string pathToTexture)
        {
            Texture = content.Load<Texture2D>(pathToTexture);
        }



    }
}
