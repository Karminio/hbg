using HotelEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace HbgTest
{
    [TestClass]
    public class GameSimulation
    {
        [TestMethod]
        public void StartGameTest()
        {
            GameLogicObj gameLogic = new GameLogicObj();
            Player qui = new Player("Qui", "", new HbgColor { CustomColor = Color.Red });
            gameLogic.AddPlayer(qui);
            gameLogic.AddPlayer("Quo", "Green");
            gameLogic.AddPlayer("Qua", new HbgColor { CustomColor = Color.Blue });

            Player p3 = gameLogic.GetPlayerByID(2);
            Assert.AreEqual("Qua", p3.Name);
        }
    }
}
