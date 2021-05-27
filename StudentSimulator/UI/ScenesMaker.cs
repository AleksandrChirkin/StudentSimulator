using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
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
            //AddHome();
            AddUniver();
            return scenes;
        }

        private void AddMainMenu()
        {
            var objects = new Dictionary<string, IObjectUi>();
            // рандомная штука для заглушки
            var background = new GameObjectUi<int>(0, false);
            background.LoadTexture(content, "textures/back_matmeh");
            objects.Add("background", background);
            // пока рандомный плеер для заглушки
            var mainMenu = new Scene(objects, new Player(""));
            scenes.Add(Scenes.MainMenu, mainMenu);
        }

        private void AddUniver()
        {
            // берем текущую игру, загружаем из локации "univer" все лог. объекты,
            // создаем для них граф. представление и закрепляем текстуру с соотв. именем
            var objects = new Dictionary<string, IObjectUi>();
            var currentGame = GameManipulator.CurrentGame;
            var currentPlayer = currentGame.Player;
            var playerUi = new GameObjectUi<Player>(currentPlayer, false);
            /* playerUi.LoadTexture(content, ...)
             objects.Add(playerUi);*/
            var background = new GameObjectUi<GameObject>(null, false);
            background.LoadTexture(content, "textures/Univer/back_matmeh");
            background.Name = "background";
            objects.Add("background", background);
            foreach (var gameObj in currentGame.Map.Univer.Entities)
            {
                var sprite = new GameObjectUi<GameObject>(gameObj, true);
                System.Console.WriteLine($"textures/{gameObj.Name}");
                sprite.LoadTexture(content, $"textures/Univer/{gameObj.Name}");
                sprite.Name = gameObj.Name;
                objects.Add(gameObj.Name, sprite);
            }
            var univer = new Scene(objects, currentPlayer);
            //лучше заменить на добычу координат из xml как и путей до текстур
            PlaceObjectsOnScreenUniver(univer);
            scenes.Add(Scenes.Univer, univer);
        }

        private void PlaceObjectsOnScreenUniver(Scene scene)
        {
            //куча хардкода, который стоило бы автоматизировать через XML но это потом...
            //558 218 - 632
            var objects = scene.UiObjects;
            objects["632cab"].Coordinates = new Microsoft.Xna.Framework.Vector2(558,218);
            objects["608cab"].Coordinates = new Microsoft.Xna.Framework.Vector2(2291, 218);
            objects["628cab"].Coordinates = new Microsoft.Xna.Framework.Vector2(3131, 218);
            objects["desk"].Coordinates = new Microsoft.Xna.Framework.Vector2(2588, 284);
            objects["foodAutomat"].Coordinates = new Microsoft.Xna.Framework.Vector2(913, 212);

        }

        private void AddHome()
        {
            // то же самое, но с локацией "home"
            var objects = new Dictionary<string, IObjectUi>();
            var currentGame = GameManipulator.CurrentGame;
            var currentPlayer = currentGame.Player;
            var playerUi = new GameObjectUi<Player>(currentPlayer, false);
            //playerUi.LoadTexture(content, ...);
            //objects.Add(playerUi);
            foreach (var gameObj in currentGame.Map.Home.Entities)
            {
                var background = new GameObjectUi<GameObject>(gameObj, true);
                //background.LoadTexture(content, $"textures/{gameObj.Name}");
                objects.Add(gameObj.Name, background);
            }
            var home = new Scene(objects, currentPlayer);
            scenes.Add(Scenes.Home, home);
        }
    }
}
