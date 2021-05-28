using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StudentSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool IsMooving { get; set; }
        public string Name { get; set; }
        public bool IsStatic { get; private set; }
        public bool IsFlashed { get; set; }
        private float mooveDestination = -1;
        private int mooveSpeed = 5;

        public List<Texture2D> Animation { get; private set; }

        public GameObjectUi(TObj gameObject, bool isInteractable, bool isStatic)
        {
            LogicalGameObject = gameObject;
            IsInteractable = isInteractable;
            IsStatic = isStatic;
            IsMooving = false;
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

        public void OnClick(IObjectUi player)
        {
            var mooveVector = Coordinates.X.CompareTo(player.Coordinates.X);
            player.SetMoveDestination(Coordinates.X, mooveVector * 5);
            player.IsMooving = true;

            //берем таск
            if (LogicalGameObject is GameObject lg)
            {
                var logicalPlayer = GameManipulator.CurrentGame.Player;
                if (Name.Equals("desk"))
                {
                    //решаем таск
                    var task = logicalPlayer.GameTasks.FirstOrDefault();
                    if (task != null)
                        logicalPlayer.MakeTask(logicalPlayer.GameTasks.GetEnumerator().Current);
                    else
                        Console.WriteLine("There is not tasks to do");
                }
                else
                {
                    logicalPlayer.InteractWith(lg);
                }
                Console.WriteLine(logicalPlayer.GameTasks);
            }

        }

        public void SetMoveDestination(float destinationX, int speed)
        {
            mooveDestination = destinationX;
            mooveSpeed = speed;
        }
        public void MoveTo()
        {
            if (Math.Abs(Coordinates.X - mooveDestination) > Math.Abs(mooveSpeed))
            {
                Coordinates = new Vector2(Coordinates.X + mooveSpeed, Coordinates.Y);
            }
            else
            {
                IsMooving = false;
            }
        }
    }
}