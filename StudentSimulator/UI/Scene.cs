using StudentSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.UI
{
    class Scene
    {
        public List<IObjectUI> UIObjects { get; private set; }
        public Player player { get; private set; }

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
        }
    }
}
