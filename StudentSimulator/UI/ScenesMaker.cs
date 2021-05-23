using Microsoft.Xna.Framework.Content;
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
        private ContentManager content;

        public ScenesMaker(ContentManager content)
        {
            scenes = new Dictionary<int, Scene>();
            this.content = content;
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
            var objects = new List<IObjectUI>();
            // рандомная штука для заглушки
            var background = new GameObjectUI<int>(0, false);
            background.LoadTexture(content, "textures/back_matmeh");
            objects.Add(background);
            // пока рандомный плеер для заглушки
            var mainMenu = new Scene(objects, new Domain.Player());
            scenes.Add((int)Scenes.MainMenu, mainMenu);
        }

        private void AddUniver()
        {

        }

        private void AddHome()
        {

        }
    }
}
