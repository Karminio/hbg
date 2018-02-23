using HotelEngine;
using HotelEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void SimulateTurnTest()
        {
            GameLogicObj gameLogic = new GameLogicObj();
            Player qui = new Player("Qui", "", new HbgColor { CustomColor = Color.Red });


            gameLogic.AddPlayer(qui);
            gameLogic.AddPlayer("Quo", "Green");
            gameLogic.AddPlayer("Qua", new HbgColor { CustomColor = Color.Blue });


            gameLogic.SimulateTurn(); // quo
            gameLogic.SimulateTurn(); // qua
            gameLogic.SimulateTurn(); // qui
        }

        [TestMethod]
        public void Simulate10TurnTest()
        {
            GameLogicObj gameLogic = new GameLogicObj();
            Player qui = new Player("Qui", "", new HbgColor { CustomColor = Color.Red });

            gameLogic.AddPlayer(qui);
            gameLogic.AddPlayer("Quo", "Green");
            gameLogic.AddPlayer("Qua", new HbgColor { CustomColor = Color.Blue });

            for(int i = 0; i<10; i++) {
                //ExecuteTurnActions(gameLogic);
                gameLogic.SimulateTurn();
            }
            
        }

        private static void ExecuteTurnActions(GameLogicObj gameLogic) {
            gameLogic.DoTurn(0);
            Player p = gameLogic.GetActivePlayer();
            if (p.CanBuyEntrance)
            {
                Console.WriteLine("Player {0} can buy entrance", p.Name);
            }
       
            gameLogic.EndTurn();
        } 
    }
}
