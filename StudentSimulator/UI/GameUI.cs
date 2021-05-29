using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StudentSimulator.UI
{
    public class GameUI : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Dictionary<Scenes, Scene> scenes;
        private ScenesMaker scenesMaker;
        private Scene currentScene;
        private Dictionary<string, IObjectUi> currentSceneObjects;
        private Vector2 screenSize;
        public static Domain.Game CurrentLogicalGame { get; private set; }

        public GameUI()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            scenesMaker = new ScenesMaker(Content, this);
            SetFullScreen();
            IsMouseVisible = true;
        }

        private void ChangeCurrentScene(Scenes sceneName)
        {
            currentScene = scenes[sceneName];
            //чтобы каждый раз их не добывать во время работы программы
            currentSceneObjects = currentScene.UiObjects;
        }

        private void SetFullScreen()
        {
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        private int CalculateOffset()
        {
            var backgroundHeight = 720;
            return ((int)screenSize.Y - backgroundHeight) / 2;
        }
        // Выполняет начальную инициализацию игры
        protected override void Initialize()
        {
            // здесь нужно создавать непосредсвенно логическую часть игры, выполнять загрузку данных и т.д
            // крч проводить все подготовочные мероприятия
            CurrentLogicalGame = Domain.Game.CreateGame();
            screenSize = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);
            Console.WriteLine(CalculateOffset());
            scenes = scenesMaker.GetScenes(CalculateOffset());
            Console.WriteLine(screenSize.X);
            Console.WriteLine(screenSize.Y);
            ChangeCurrentScene(Scenes.MainMenu);
            ChangeCurrentScene(Scenes.Univer);
            base.Initialize();
        }

        // Загружает ресурсы игры
        protected override void LoadContent()
        {
            //тут уже моя(Димасова) работа - инициализировать спрайтики всякие разные интересные
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        // Вызывается при завершении игры для выгрузки использованных ресурсов
        protected override void UnloadContent()
        {
            Domain.Game.SaveGame(CurrentLogicalGame);
        }

        // Обновляет состояние игры, управляет ее логикой
        protected override void Update(GameTime gameTime)
        {
            // здесь будет проходит все обновление логики - вычисляться текущее состоянии игры
            // координаты обьектов, текущая сцена и т.д
            // взаимодействие с юзверем
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var mouseState = Mouse.GetState();

            foreach (var gameObj in currentSceneObjects)
            {
                if (gameObj.Value.IsMooving)
                    gameObj.Value.MoveTo();
                if (gameObj.Value.MouseOnObj(mouseState.X, mouseState.Y) && gameObj.Value.IsInteractable)
                {
                    gameObj.Value.IsFlashed = true;
                    if (gameObj.Value.MouseClickedOn(mouseState.LeftButton.ToString()))
                        gameObj.Value.OnClick(currentSceneObjects["player"]);
                }
                else
                    gameObj.Value.IsFlashed = false;
            }


            // эталон положения обьектов
            var moveSpeed = 5;
            var backCoordinates = currentSceneObjects["background"].Coordinates;
            if (mouseState.X > (3.0 / 4) * screenSize.X && Math.Abs(backCoordinates.X) != currentSceneObjects["background"].Texture.Width - screenSize.X)
                MoveScreen(-moveSpeed);
            if (mouseState.X < (1.0 / 4) * screenSize.X && Math.Abs(backCoordinates.X) != 0)
                MoveScreen(+moveSpeed);
            base.Update(gameTime);
        }

        private void MoveScreen(int speed)
        {
            foreach (var graphObj in currentSceneObjects)
            {
                if (!graphObj.Value.IsStatic)
                {
                    var newCoordinations = new Vector2(graphObj.Value.Coordinates.X + speed, graphObj.Value.Coordinates.Y);
                    var name = graphObj.Value.Name;
                    currentSceneObjects[name].Coordinates = newCoordinations;
                }
            }
        }



        // Выполняет отрисовку на экране
        protected override void Draw(GameTime gameTime)
        {
            // здесь происходит исключительно отрисовка. Никаких вычислений!!!
            GraphicsDevice.Clear(Color.BurlyWood);
            spriteBatch.Begin();
            foreach (var obj in currentSceneObjects)
            {
                if (!obj.Value.IsFlashed)
                    spriteBatch.Draw(obj.Value.Texture, obj.Value.Coordinates, Color.White);
                else
                {
                    spriteBatch.Draw(obj.Value.FlashedTexture, obj.Value.Coordinates, Color.White);
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
