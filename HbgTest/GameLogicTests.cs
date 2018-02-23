using HotelEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelEntities;

namespace HbgTest
{
    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        public void RollingDice()
        {
            GameLogicObj logic = new GameLogicObj();
            Player qui = new Player();
            qui.Name = "Qui";
            logic.AddPlayer(qui);

            logic.DoTurn(6);

            Assert.AreEqual(6, logic.CurrentPlayerCell.Position);
        }
    }
}
