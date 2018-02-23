using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelEngine;
using System.Configuration;
using HotelEntities;

namespace HbgTest
{
    [TestClass]
    public class GamePersistence
    {
        [TestMethod]
        public void SaveGameTest()
        {
            ConfigurationManager.AppSettings["PersistenceFilePath"] = @"c:\temp\savedGameTest.json";
            GameLogicObj savedGame = new GameLogicObj();
            savedGame.SaveGameState();

            GameLogicObj loadedGame = new GameLogicObj();
            loadedGame.LoadGameState();

            Assert.AreEqual(savedGame, loadedGame, "Loaded game state is different from the saved one");
        }
    }
}
