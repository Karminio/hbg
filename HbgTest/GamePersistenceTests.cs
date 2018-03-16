using Hotel.FixedProvider;
using Hotel.JSONProvider;
using HotelEngine;
using HotelEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;

namespace HbgTest
{
    [TestClass]
    public class GamePersistenceTests
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

        [TestMethod]
        public void LoadHotelListFromJSON()
        {
            HotelJSONDataProvider hJSON = new HotelJSONDataProvider();
            HotelCollection hc = hJSON.RetrieveHotelCollection();

            Assert.AreEqual(2, hc.Count);
        }

        [TestMethod]
        public void LoadCellListFromJSON()
        {
            HotelJSONDataProvider hJSON = new HotelJSONDataProvider();
            GameCellCollection gcc = hJSON.RetrieveGameCellCollection();

            Assert.AreEqual(3, gcc.Count);
        }

    }
}
