using HotelEngine;
using HotelEntities;
using System;

namespace HotelEngine
{
    public static class GameLogicExtensions
    {
        public static void SimulateTurn(this GameLogicObj gameLogic)
        {
            int diceValue = gameLogic.DoTurn(0);
            Player p = gameLogic.GetActivePlayer();
            Console.WriteLine("Plyer {0} rolled {1}", p.Name, diceValue);

            CellActionTypeEnum cat = p.GetNextAction();
            MessageObj resultMessage = new MessageObj();
            HotelCollection ownHotelList;
            HotelObj selHotel;
            Category category;

            switch (cat)
            {
                case CellActionTypeEnum.CanBuild:
                    ownHotelList = gameLogic.GetOwnedProperties(gameLogic.GetActivePlayer());
                    if (ownHotelList.Count == 0) break;
                    selHotel = ownHotelList[0];
                    category = selHotel.GetRate(selHotel.CurrentCategory);
                    resultMessage = gameLogic.UpgradeProperty(selHotel, selHotel.CurrentCategory, category.BuildingCost);
                    break;
                case CellActionTypeEnum.CanBuy:
                    HotelObj lHotel = gameLogic.GetHotelByName(gameLogic.CurrentPlayerCell.LeftHotel);
                    HotelObj rHotel = gameLogic.GetHotelByName(gameLogic.CurrentPlayerCell.RightHotel);
                    resultMessage = gameLogic.BuyProperty(lHotel, gameLogic.GetActivePlayer());
                    break;
                case CellActionTypeEnum.CanBuyEntrance:
                    //BuyEntranceGUI(false);
                    break;
                case CellActionTypeEnum.FreeBuilding:
                    ownHotelList = gameLogic.GetOwnedProperties(gameLogic.GetActivePlayer());
                    if (ownHotelList.Count == 0) break;
                    selHotel = ownHotelList[0];
                    category = selHotel.GetRate(selHotel.CurrentCategory);
                    resultMessage = gameLogic.UpgradeProperty(selHotel, selHotel.CurrentCategory, 0);
                    break;
                case CellActionTypeEnum.FreeEntrance:
                    //BuyEntranceGUI(true);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Action log: {0} - {1}",resultMessage.Summary, resultMessage.Description);

            gameLogic.EndTurn();
        }
    }
}
