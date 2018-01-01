using HotelEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace HbgLiveTest
{
    [TestClass]
    public class PlayerTest1
    {
        [TestMethod]
        public void AddPlayerTest()
        {
            HbgColor col = new HbgColor()
            { CustomColor = Color.Aqua };

            Player p = new Player("TestPlayer", "", col);

            string htmlColor = p.ClrGridHtml;
            CellActionTypeEnum action = p.GetNextAction();

            Assert.AreEqual("Aqua", htmlColor);
            Assert.AreEqual(CellActionTypeEnum.NoAction, action);
        }
        [TestMethod]
        public void AddPlayerActionsTest()
        {
            // Arrange
            Player p = new Player();
            CellActionTypeEnum parkLot = CellActionTypeEnum.ParkLot;
            CellActionTypeEnum canBuild = CellActionTypeEnum.CanBuild;
            CellActionTypeEnum canBuy = CellActionTypeEnum.CanBuy;

            // Act
            p.AddAction(parkLot);
            p.AddAction(canBuild);
            p.AddAction(canBuy);
   
            CellActionTypeEnum action1 = p.GetNextAction();
            CellActionTypeEnum action2 = p.GetNextAction();
            CellActionTypeEnum action3 = p.GetNextAction();

            // Assert
            Assert.AreEqual(action1, CellActionTypeEnum.ParkLot);
            Assert.AreEqual(action2, CellActionTypeEnum.CanBuild);
            Assert.AreEqual(action3, CellActionTypeEnum.CanBuy);
        }
    }
}
