using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;
using StudentSimulator.Domain;

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
        private Dictionary<Scenes, Scene> scenes;
        private ContentManager content;

        public ScenesMaker(ContentManager content)
        {
            scenes = new Dictionary<Scenes, Scene>();
            this.content = content;
        }
        public Dictionary<Scenes, Scene> GetScenes()
        {
            AddMainMenu();
            AddHome();
            AddUniver();
            return scenes;
        }

        private void AddMainMenu()
        {
            var objects = new List<IObjectUi>();
            // рандомная штука для заглушки
            var background = new GameObjectUi<int>(0, false);
            background.LoadTexture(content, "textures/back_matmeh");
            objects.Add(background);
            // пока рандомный плеер для заглушки
            var mainMenu = new Scene(objects, new Player());
            scenes.Add(Scenes.MainMenu, mainMenu);
        }

        private void AddUniver()
        {
            // берем текущую игру, загружаем из локации "univer" все лог. объекты,
            // создаем для них граф. представление и закрепляем текстуру с соотв. именем
            var objects = new List<IObjectUi>();
            var currentGame = GameManipulator.CurrentGame;
            var currentPlayer = currentGame.Player;
            var playerUi = new GameObjectUi<Player>(currentPlayer, false);
            //playerUi.LoadTexture(content, ...); - загружаем текстуру для плеера
            objects.Add(playerUi);
            foreach (var gameObj in currentGame.Map.Locations
                .First(location => location.Name == "Univer").Entities)
            {
                var background = new GameObjectUi<GameObject>(gameObj, true);
                background.LoadTexture(content, $"textures/{gameObj.Name}");
                objects.Add(background);
            }
            var univer = new Scene(objects, currentPlayer);
            scenes.Add(Scenes.Univer, univer);
        }

        private void AddHome()
        {
            // то же самое, но с локацией "home"
            var objects = new List<IObjectUi>();
            var currentGame = GameManipulator.CurrentGame;
            var currentPlayer = currentGame.Player;
            var playerUi = new GameObjectUi<Player>(currentPlayer, false);
            //playerUi.LoadTexture(content, ...);
            objects.Add(playerUi);
            foreach (var gameObj in currentGame.Map.Locations
                .First(location => location.Name == "Home").Entities)
            {
                var background = new GameObjectUi<GameObject>(gameObj, true);
                background.LoadTexture(content, $"textures/{gameObj.Name}");
                objects.Add(background);
            }
            var home = new Scene(objects, currentPlayer);
            scenes.Add(Scenes.Home, home);
        }
    }
}
