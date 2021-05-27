using StudentSimulator.Domain;
using System.Collections.Generic;

namespace StudentSimulator.UI
{
    class Scene
    {
        public Dictionary<string, IObjectUi> UiObjects { get; private set; }
        public Player Player { get; private set; }

        public Scene(Dictionary<string, IObjectUi> uiObjects, Player player)
        {
            UiObjects = uiObjects;
            Player = player;
        }

        public void UserInteractedWith(IObjectUi objectUi)
        {
            // проверяем, если это Player, то одно
            // если это gameObject то интерракт от пользователя
            // если это элемент интерфейса, то третье 
        }
    }
}
