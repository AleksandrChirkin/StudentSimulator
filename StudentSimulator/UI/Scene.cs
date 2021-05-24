using StudentSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSimulator.UI
{
    class Scene
    {
        public List<IObjectUI> UIObjects { get; }
        public Player player { get; }

        public Scene(List<IObjectUI> UIObjects, Player player)
        {
            this.UIObjects = UIObjects;
            this.player = player;
        }

        public void UserInteractedWith(IObjectUI objectUI)
        {
            // проверяем, если это Player, то одно
            // если это gameObject то интерракт от пользователя
            // если это элемент интерфейса, то третье
            switch (objectUI)
            {
                case PlayerUI playerUi:
                    break;
                case GameObjectUI gameObjectUi:
                    if (gameObjectUi.LogicalGameObject != null)
                        player.InteractWith(gameObjectUi.LogicalGameObject);
                    else
                        ;
                    break;
            }
        }
    }
}
