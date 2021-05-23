using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StudentSimulator.UI
{
	public class GameMain : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Dictionary<int, Scene> scenes;
		private ScenesMaker scenesMaker;
		private Scene currentScene;
		private List<IObjectUI> currentSceneObjects;

		public GameMain()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			scenesMaker = new ScenesMaker();
		}

		private void ChangeCurrentScene(Scenes sceneName)
		{
			currentScene = scenes[(int)sceneName];
			//чтобы каждый раз их не добывать во время работы программы
			currentSceneObjects = currentScene.UIObjects;
		}

		// Выполняет начальную инициализацию игры
		protected override void Initialize()
		{
			// здесь нужно создавать непосредсвенно логическую часть игры, выполнять загрузку данных и т.д
			// крч проводить все подготовочные мероприятия
			scenes = scenesMaker.GetScenes();
			ChangeCurrentScene(Scenes.MainMenu);
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
			base.Draw(gameTime);
		}
	}
}
