using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using StudentSimulator.Domain;
using Microsoft.Xna.Framework;
using System.Linq;

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
        private int offsetY;
        private GameMain game;

        public ScenesMaker(ContentManager content, GameMain game)
        {
            scenes = new Dictionary<Scenes, Scene>();
            this.content = content;
            this.game = game;
        }
        public Dictionary<Scenes, Scene> GetScenes(int offsetY)
        {
            this.offsetY = offsetY;
            AddMainMenu();
            //AddHome();
            AddUniver();
            return scenes;
        }

        private void AddMainMenu()
        {
            var objects = new Dictionary<string, IObjectUi>();
            // рандомная штука для заглушки
            var background = new GameObjectUi<int>(0, false, false);
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
            var playerUi = new GameObjectUi<Player>(currentPlayer, false, false);
            /* playerUi.LoadTexture(content, ...)
             objects.Add(playerUi);*/
            var background = new GameObjectUi<GameObject>(null, false, false);
            background.LoadTexture(content, "textures/Univer/back_matmeh");
            background.Name = "background";
            background.Coordinates = new Vector2(0, offsetY);
            objects.Add("background", background);
            foreach (var gameObj in currentGame.Map.Univer.Entities)
            {
                var sprite = new GameObjectUi<GameObject>(gameObj, true, false);
                System.Console.WriteLine($"textures/{gameObj.Name}");
                sprite.LoadTexture(content, $"textures/Univer/{gameObj.Name}");
                sprite.LoadFlashedTexture(content, $"textures/Univer/{gameObj.Name}Enable");
                sprite.Name = gameObj.Name;
                objects.Add(gameObj.Name, sprite);
            }
            //добавим интерфейс
            var allObjects = objects.Union(GetUI()).ToDictionary(x => x.Key, x => x.Value);

            var univer = new Scene(allObjects, currentPlayer);
            //лучше заменить на добычу координат из xml как и путей до текстур
            PlaceObjectsOnScreenUniver(univer, offsetY);
            scenes.Add(Scenes.Univer, univer);
        }

        private Dictionary<string, IObjectUi> GetUI()
        {
            var objects = new Dictionary<string, IObjectUi>();

            var uiSample = new GameObjectUi<GameObject>(null, false, true);
            uiSample.LoadTexture(content, "textures/Interface/leftUI");
            uiSample.Name = "uiL";
            uiSample.Coordinates = new Vector2(0, 0);
            objects.Add("uiL", uiSample);

            var uiSample2 = new GameObjectUi<GameObject>(null, false, true);
            uiSample2.LoadTexture(content, "textures/Interface/rightUI");
            uiSample2.Name = "uiR";
            uiSample2.Coordinates = new Vector2(game.Window.ClientBounds.Width - 200, 0);
            objects.Add("uiR", uiSample2);
            return objects;
        }

        private void PlaceObjectsOnScreenUniver(Scene scene, int offsetY)
        {
            //куча хардкода, который стоило бы автоматизировать через XML но это потом...
            //558 218 - 632
            var objects = scene.UiObjects;
            objects["632cab"].Coordinates = new Vector2(558, 218 + offsetY);
            objects["608cab"].Coordinates = new Vector2(2291, 218 + offsetY);
            objects["628cab"].Coordinates = new Vector2(3131, 218 + offsetY);
            objects["desk"].Coordinates = new Vector2(2588, 284 + offsetY);
            objects["foodAutomat"].Coordinates = new Vector2(913, 212 + offsetY);
        }

        private void AddHome()
        {
            // то же самое, но с локацией "home"
            var objects = new Dictionary<string, IObjectUi>();
            var currentGame = GameManipulator.CurrentGame;
            var currentPlayer = currentGame.Player;
            var playerUi = new GameObjectUi<Player>(currentPlayer, false, false);
            //playerUi.LoadTexture(content, ...);
            //objects.Add(playerUi);
            foreach (var gameObj in currentGame.Map.Home.Entities)
            {
                var background = new GameObjectUi<GameObject>(gameObj, true, false);
                //background.LoadTexture(content, $"textures/{gameObj.Name}");
                objects.Add(gameObj.Name, background);
            }
            var home = new Scene(objects, currentPlayer);
            scenes.Add(Scenes.Home, home);
        }
    }
}
