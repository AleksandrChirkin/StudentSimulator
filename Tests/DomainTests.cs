using System.IO;
using NUnit.Framework;
using StudentSimulator.Domain;

namespace Tests
{
    public class DomainTests
    {
        [SetUp]
        public void Setup()
        {
            GameManipulator.CreateGame();
        }

        [Test]
        public void TestCreateGame()
        {
            var currentGame = GameManipulator.CurrentGame;
            GameObjectsExistsContainsAllFields(currentGame);
            Assert.AreEqual(0, currentGame.Days);
        }

        [Test]
        public void TestSaveGame()
        {
            GameManipulator.SaveGame();
            Assert.IsNull(GameManipulator.CurrentGame);
            Assert.IsTrue(File.Exists("./games.json"));
        }

        [Test]
        public void TestSaveMultipleGamesAndRestoreSetOfGame()
        {
            GameManipulator.SaveGame();
            GameManipulator.CreateGame();
            GameManipulator.SaveGame();
            var gamesSet = GameManipulator.GetSetOfGames();
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