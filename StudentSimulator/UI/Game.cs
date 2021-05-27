using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StudentSimulator.Domain;

namespace StudentSimulator.UI
{
    public class GameMain : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Dictionary<Scenes, Scene> scenes;
        private ScenesMaker scenesMaker;
        private Scene currentScene;
        private Dictionary<string, IObjectUi> currentSceneObjects;
        private Vector2 screenSize;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            scenesMaker = new ScenesMaker(Content);
            SetFullScreen();
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

        // Выполняет начальную инициализацию игры
        protected override void Initialize()
        {
            // здесь нужно создавать непосредсвенно логическую часть игры, выполнять загрузку данных и т.д
            // крч проводить все подготовочные мероприятия
            GameManipulator.CreateGame();
            scenes = scenesMaker.GetScenes();
            Console.WriteLine(Window.ClientBounds.Width);
            Console.WriteLine(Window.ClientBounds.Height);
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
            GameManipulator.SaveGame();
        }

        // Обновляет состояние игры, управляет ее логикой
        protected override void Update(GameTime gameTime)
        {
            // здесь будет проходит все обновление логики - вычисляться текущее состоянии игры
            // координаты обьектов, текущая сцена и т.д
            // взаимодействие с юзверем
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        // Выполняет отрисовку на экране
        protected override void Draw(GameTime gameTime)
        {
            // здесь происходит исключительно отрисовка. Никаких вычислений!!!
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (var obj in currentSceneObjects)
            {
                spriteBatch.Draw(obj.Value.Texture, obj.Value.Coordinates, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
