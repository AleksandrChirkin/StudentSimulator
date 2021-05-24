using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StudentSimulator.Domain;

namespace StudentSimulator.UI
{
    //графическая обертка над классами из логики
    //gameObject, player, InterfaceObject и т.д...
    class GameObjectUI : IObjectUI
    //Убрал generic, так как мы можем создать оболочку только для GameObject и Player
    //Случай с интерфейсовыми объектами оставил pltcm, только в качестве аргумента передаается null
    //(наверное можно для интерфейсовых объектов выделить свой UI)
    //впрочем, это Димасова работа)))
    {
        public Vector2 Coordinates { get; set; }
        public Texture2D Texture { get; private set; }
        public GameObject LogicalGameObject { get; }

        // Убрал поле IsInteractable, так как возможность взаимодействовать с объектом
        // будет определяться в методе Scene.UserInteractedWith
        public GameObjectUI(GameObject gameObject)
        {
            LogicalGameObject = gameObject;
            // в начало координат - левый верхний угол
            Coordinates = Vector2.Zero;
        }

        public void LoadTexture(ContentManager content, string pathToTexture)
        {
            Texture = content.Load<Texture2D>(pathToTexture);
        }
    }
}
