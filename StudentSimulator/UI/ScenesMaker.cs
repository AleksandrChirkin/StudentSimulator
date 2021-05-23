using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.UI
{
    public enum Scenes
    {
        MainMenu,
        Home,
        Univer,
        Map
    }
    class ScenesMaker
    {

        private Dictionary<int, Scene> scenes;

        public ScenesMaker()
        {
            scenes = new Dictionary<int,Scene>();
        }
        public Dictionary<int, Scene> GetScenes()
        {
            AddMainMenu();
            AddHome();
            AddUniver();
            return scenes;
        }

        private void AddMainMenu()
        {

        }

        private void AddUniver()
        {

        }

        private void AddHome()
        {

        }
    }
}
