using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using StudentSimulator.Domain;

namespace Tests
{
    public class DomainTests
    {
        private Game _game;
        [SetUp]
        public void Setup()
        {
            _game = Game.CreateGame(true);
        }

        [Test]
        public void TestCreateGame()
        {
            GameObjectsExistsContainsAllFields(_game);
            Assert.AreEqual(0, _game.Days);
        }

        [Test]
        public void TestSaveGame()
        {
            Game.SaveGame(_game);
            Assert.IsTrue(File.Exists("./games.json"));
            var gamesSet = Game.GetSetOfGames();
            Assert.AreEqual( 1, gamesSet.Count);
            GameObjectsExistsContainsAllFields(gamesSet.First());
        }

        [Test]
        public void TestSaveMultipleGamesAndRestoreSetOfGame()
        {
            Game.SaveGame(_game);
            Thread.Sleep(100);
            _game = Game.CreateGame(true);
            Game.SaveGame(_game);
            var gamesSet = Game.GetSetOfGames();
            Assert.AreEqual( 2, gamesSet.Count);
            foreach (var game in gamesSet)
                GameObjectsExistsContainsAllFields(game);
        }

        private void GameObjectsExistsContainsAllFields(Game currentGame)
        {
            Assert.IsNotNull(currentGame);
            Assert.IsNotNull(currentGame.Map);
            Assert.IsNotNull(currentGame.Map.Home);
            Assert.AreEqual("Home", currentGame.Map.Home.Name);
            Assert.IsNotNull(currentGame.Map.Home.Entities);
            Assert.IsNotNull(currentGame.Map.Univer);
            Assert.AreEqual("Univer", currentGame.Map.Univer.Name);
            Assert.IsNotNull(currentGame.Map.Univer.Entities);
            Assert.IsNotNull(currentGame.Player);
        }

        [TearDown]
        public void Teardown()
        {
            var savedGamesFile = "./games.json";
            if (File.Exists(savedGamesFile))
                File.Delete(savedGamesFile);
        }
    }
}