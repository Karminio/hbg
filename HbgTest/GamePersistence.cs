using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelEngine;
using System.Configuration;
using Hotel.FixedProvider;
using Newtonsoft.Json;
using HotelEntities;
using System.IO;

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

        [TestMethod]
        public void GenerateJSON()
        {
            HotelFixedProvider fp = new HotelFixedProvider();
            HotelCollection hc = fp.RetrieveHotelCollection();
            string json = JsonConvert.SerializeObject(hc);
            File.WriteAllText(@"c:\temp\hotelCollection.json", json);
        }

    }
}
