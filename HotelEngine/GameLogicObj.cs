using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace HotelEngine
{
    public class GameLogicObj
    {
        #region Properties

        public int Id { get; set; }

        public PlayerCollection Players
        {
            get { return m_persistanceObject.Players; }
            //set { m_persistanceObject.Players = value; }
        }

        public int ActivePlayerId
        {
            get { return m_persistanceObject.ActivePlayerID; }
            set { m_persistanceObject.ActivePlayerID = value; }
        }

        private HotelCollection m_hotelList;

        /// <summary>
        /// Game can be saved only between two turns, only when previous player declares "end turn" and before next player
        /// does any action.
        /// Start value is false.
        /// </summary>
        private bool m_canSave;

        public bool CanSave
        {
            get { return m_canSave; }
            //set { m_canSave = value; }
        }

        #endregion

        public GameLogicObj()
        {
            /// If game is starting now no persistance object allready exists
            /// Otherwise at this point the object is valorized by deserialization
            if (m_persistanceObject == null)
                m_persistanceObject = new GameLogicPersistence();

            InitHotelList();
            InitGameScheme();
            ActivePlayerId = 0;
            m_canSave = false;
        }

        #region Game state management
        /// <summary>
        /// Initialize game variables which are not serilized for persistence
        /// </summary>
        private void InitHotelList()
        { 
            m_hotelList = new HotelCollection();

            // TODO: create an XML to serialize hotel data
            // President
            HotelObj hoPresident    = new HotelObj("President", 3500,   250);
            hoPresident.AddCategory(new Category(5000, 200));
            hoPresident.AddCategory(new Category(3000, 400));
            hoPresident.AddCategory(new Category(2250, 600));
            hoPresident.AddCategory(new Category(1750, 800));
            hoPresident.AddCategory(new Category(5000, 1100));
            m_hotelList.Add(hoPresident);
            
            // Royal
            HotelObj hoRoyal        = new HotelObj("Royal",     2500,   200);
            hoRoyal.AddCategory(new Category(3600, 150));
            hoRoyal.AddCategory(new Category(2600, 300));
            hoRoyal.AddCategory(new Category(1800, 300));
            hoRoyal.AddCategory(new Category(1800, 450));
            hoRoyal.AddCategory(new Category(3000, 600));
            m_hotelList.Add(hoRoyal);
            
            // Waikiki
            HotelObj hoWaikiki      = new HotelObj("Waikiki",   250,    200);
            hoWaikiki.AddCategory(new Category(3500, 200));
            hoWaikiki.AddCategory(new Category(2500, 350));
            hoWaikiki.AddCategory(new Category(2500, 500));
            hoWaikiki.AddCategory(new Category(1750, 500));
            hoWaikiki.AddCategory(new Category(1750, 650));
            hoWaikiki.AddCategory(new Category(2500, 1000));
            m_hotelList.Add(hoWaikiki);

            // Safari
            HotelObj hoSafari       = new HotelObj("Safari",    2000,   150);
            hoSafari.AddCategory(new Category(2600, 100));
            hoSafari.AddCategory(new Category(1200, 100));
            hoSafari.AddCategory(new Category(1200, 250));
            hoSafari.AddCategory(new Category(2000, 500));
            m_hotelList.Add(hoSafari);

            // Boomerang
            HotelObj hoBoomerang    = new HotelObj("Boomerang", 500,    100);
            hoBoomerang.AddCategory(new Category(1800, 400));
            hoBoomerang.AddCategory(new Category(250, 600));
            m_hotelList.Add(hoBoomerang);

            // Taj Mahal
            HotelObj hoTajMahal     = new HotelObj("Taj Mahal", 1500,   100);
            hoTajMahal.AddCategory(new Category(2400, 100));
            hoTajMahal.AddCategory(new Category(1000, 100));
            hoTajMahal.AddCategory(new Category(500, 200));
            hoTajMahal.AddCategory(new Category(1000, 300));
            m_hotelList.Add(hoTajMahal);

            // Fujiyama
            HotelObj hoFujiyama     = new HotelObj("Fujiyama",  1000,   100);
            hoFujiyama.AddCategory(new Category(2200, 100));
            hoFujiyama.AddCategory(new Category(1400, 100));
            hoFujiyama.AddCategory(new Category(1400, 200));
            hoFujiyama.AddCategory(new Category(500, 400));
            m_hotelList.Add(hoFujiyama);

            // Etoile
            HotelObj hoEtoile       = new HotelObj("L' Etoile", 3000,   250);
            hoEtoile.AddCategory(new Category(3300, 150));
            hoEtoile.AddCategory(new Category(2200, 300));
            hoEtoile.AddCategory(new Category(1800, 300));
            hoEtoile.AddCategory(new Category(1800, 300));
            hoEtoile.AddCategory(new Category(1800, 450));
            hoEtoile.AddCategory(new Category(4000, 750));
            m_hotelList.Add(hoEtoile);

        }

        private void InitGameScheme()
        {
            #region Getting hotel objects
            // TODO: migliorare
            HotelObj hoPresident = m_hotelList.GetHotelByName("President");
            HotelObj hoRoyal = m_hotelList.GetHotelByName("Royal");
            HotelObj hoWaikiki = m_hotelList.GetHotelByName("Waikiki");
            HotelObj hoSafari = m_hotelList.GetHotelByName("Safari");
            HotelObj hoBoomerang = m_hotelList.GetHotelByName("Boomerang");
            HotelObj hoTajMahal = m_hotelList.GetHotelByName("Taj Mahal");
            HotelObj hoFujiyama = m_hotelList.GetHotelByName("Fujiyama");
            HotelObj hoEtoile = m_hotelList.GetHotelByName("L' Etoile");
            #endregion

            #region Putting hotels into grid
            m_cellsList = new GameCellCollection();

            m_cellsList.Add(new GameCell(-1, CellActionTypeEnum.ParkLot, null, null));  // Park lot
            m_cellsList.Add(new GameCell(0, CellActionTypeEnum.Start, null, null));
            m_cellsList.Add(new GameCell(1, CellActionTypeEnum.CanBuild, null, "Fujiyama"));
            m_cellsList.Add(new GameCell(2, CellActionTypeEnum.CanBuy, "Boomerang", "Fujiyama"));
            m_cellsList.Add(new GameCell(3, CellActionTypeEnum.CanBuild, "Boomerang", "Fujiyama"));
            m_cellsList.Add(new GameCell(4, CellActionTypeEnum.CanBuy, "Boomerang", "Fujiyama"));
            m_cellsList.Add(new GameCell(5, CellActionTypeEnum.CanBuild, "Boomerang", "Fujiyama"));
            m_cellsList.Add(new GameCell(6, CellActionTypeEnum.FreeEntrance, null, "Fujiyama"));  // Bank
            m_cellsList.Add(new GameCell(7, CellActionTypeEnum.CanBuild, null, null));  // Bank/River
            m_cellsList.Add(new GameCell(8, CellActionTypeEnum.CanBuy, null, "L' Etoile"));  // Bank
            m_cellsList.Add(new GameCell(9, CellActionTypeEnum.CanBuy, "President", "L' Etoile"));
            m_cellsList.Add(new GameCell(10, CellActionTypeEnum.FreeBuilding, "President", "L' Etoile"));
            m_cellsList.Add(new GameCell(11, CellActionTypeEnum.CanBuy, "President", "Royal"));
            m_cellsList.Add(new GameCell(12, CellActionTypeEnum.CanBuild, "President", "Royal"));
            m_cellsList.Add(new GameCell(13, CellActionTypeEnum.CanBuy, "President", "Royal"));
            m_cellsList.Add(new GameCell(14, CellActionTypeEnum.CanBuild, "President", "Royal"));
            m_cellsList.Add(new GameCell(15, CellActionTypeEnum.CanBuy, "President", "Royal"));
            m_cellsList.Add(new GameCell(16, CellActionTypeEnum.CanBuild, "Waikiki", "Royal"));
            m_cellsList.Add(new GameCell(17, CellActionTypeEnum.CanBuy, "Waikiki", "Royal"));
            m_cellsList.Add(new GameCell(18, CellActionTypeEnum.FreeEntrance, "Waikiki", "Royal"));
            m_cellsList.Add(new GameCell(19, CellActionTypeEnum.CanBuild, "Waikiki", "Royal"));
            m_cellsList.Add(new GameCell(20, CellActionTypeEnum.CanBuy, "Waikiki", "Royal"));
            m_cellsList.Add(new GameCell(21, CellActionTypeEnum.CanBuy, "Taj Mahal", "L' Etoile"));
            m_cellsList.Add(new GameCell(22, CellActionTypeEnum.CanBuild, "Taj Mahal", "L' Etoile"));
            m_cellsList.Add(new GameCell(23, CellActionTypeEnum.CanBuy, "Taj Mahal", "L' Etoile"));
            m_cellsList.Add(new GameCell(24, CellActionTypeEnum.FreeEntrance, "Taj Mahal", "L' Etoile"));
            m_cellsList.Add(new GameCell(25, CellActionTypeEnum.CanBuild, "Taj Mahal", null));  // Town hall
            m_cellsList.Add(new GameCell(26, CellActionTypeEnum.CanBuild, "Safari", null));  // Town hall
            m_cellsList.Add(new GameCell(27, CellActionTypeEnum.CanBuild, "Safari", null));  // Town hall
            m_cellsList.Add(new GameCell(28, CellActionTypeEnum.CanBuy, "Safari", "L' Etoile"));
            m_cellsList.Add(new GameCell(29, CellActionTypeEnum.FreeEntrance, "Safari", "L' Etoile"));
            m_cellsList.Add(new GameCell(30, CellActionTypeEnum.CanBuild, "Safari", null));  // River
            #endregion
        }

        public MessageObj ResetGame()
        {
            // Backup of players
            PlayerCollection tempPC = Players;
            m_persistanceObject = new GameLogicPersistence();

            foreach (Player p in tempPC)
                AddPlayer(p.Name, p.PlaceholderColor);

            ActivePlayerId = 0;

            return new MessageObj()
            {
                Summary = "Reset game",
                Description = "A new game has been created",
                Type = MessageTypeEnum.Info,
                Buttons = MessageButtonsEnum.OK
            };
        }

        public MessageObj SaveGameState()
        {
            // For debug purpose only!! =========================
            //HotelObj h = m_hotelList.GetHotelByName("President");
            //Player p = Players.GetPlayerByID(2);
            //m_persistanceObject.OwnerShips.AddOwnership(h, p.ID);
            // ==================================================
            MessageObj resultMessage;
            MergeDataForSave();
            TextWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(GameLogicPersistence));
                writer = new StreamWriter("GameStatus.xml");
                ser.Serialize(writer, m_persistanceObject);

                resultMessage = new MessageObj()
                {
                    Summary = "Save game",
                    Description = "Game saved",
                    Type = MessageTypeEnum.Info,
                    Buttons = MessageButtonsEnum.OK
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.InnerException.Message);
                resultMessage = new MessageObj()
                {
                    Summary = "Save game",
                    Description = "An error occurred while saving game",
                    Type = MessageTypeEnum.Error,
                    Buttons = MessageButtonsEnum.OK
                };
            }
            finally
            {
                writer.Close();
            }

            return resultMessage;
        }

        public MessageObj LoadGameState()
        {
            MessageObj resultMessage;
            TextReader reader = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(GameLogicPersistence));
                reader = new StreamReader("GameStatus.xml");
                m_persistanceObject = (GameLogicPersistence)ser.Deserialize(reader);
                MergeDataForLoad();

                resultMessage = new MessageObj()
                {
                    Summary = "Load game",
                    Description = "Game loaded",
                    Type = MessageTypeEnum.Info,
                    Buttons = MessageButtonsEnum.OK
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.InnerException.Message);
                resultMessage = new MessageObj()
                {
                    Summary = "Save game",
                    Description = "An error occurred while loading game",
                    Type = MessageTypeEnum.Error,
                    Buttons = MessageButtonsEnum.OK
                };
            }
            finally
            {
                reader.Close();
            }

            return resultMessage;
        }

        /// <summary>
        /// Update hotels owner according to read data
        /// </summary>
        private void MergeDataForLoad()
        {
            HotelCollection ownedHotels =  m_persistanceObject.OwnerShips.GetAllOwnedHotels();
            foreach (HotelObj ownedHotel in ownedHotels)
            {
                m_hotelList.OverWrite(ownedHotel);
            }

            m_cellsList.SetEntrancePosition(m_persistanceObject.EntrancePositions);
        }

        /// <summary>
        /// Update hotels owner in the persistance object
        /// </summary>
        private void MergeDataForSave()
        {
            foreach (HotelObj hotel in m_hotelList)
            {
                if (hotel.Owner != null)
                    m_persistanceObject.OwnerShips.AddOwnership(hotel, hotel.Owner.Id);
            }

            m_persistanceObject.EntrancePositions = m_cellsList.GetEntrancesPosition();
        }

        #endregion

        #region Utilities

        public HotelObj GetHotelByName(string name)
        {
            return m_hotelList.GetHotelByName(name);
        }

        public GameCell GetCurrentPlayerCell
        {
            get
            {
                Player p = GetPlayerByID(ActivePlayerId);
                return (GameCell)m_cellsList.GetCellByPosition(p.CurrentPosition);
            }
        }

        #endregion

        #region Player's manager functions
        public bool AddPlayer(Player p)
        {
            return Players.Add(p);
        }
        public bool AddPlayer(string name, HbgColor playerColor) 
        { 
            return Players.Add(new Player(name, "0.0.0.0", playerColor)); 
        }

        public bool AddPlayer(string name, string playerColor)
        {
            if (Players.Exists(name))
                return false;

            ColorConverter cc = new ColorConverter();
            Color c = (Color)cc.ConvertFromString(playerColor);
            return Players.Add(new Player(name, "0.0.0.0", new HbgColor() { CustomColor = c }));
        }

        public Player GetPlayerByID(int id)
        {
            return Players.GetPlayerByID(id);
        }

        /// <summary>
        /// Gets all player's owned hotels
        /// </summary>
        /// <param name="p">Player who owns</param>
        /// <returns>Owned hotel collection</returns>
        public HotelCollection GetOwnedProperties(Player p)
        {
            return m_hotelList.GetOwnedProperties(p);
            //return m_persistanceObject.OwnerShips.GetOwnedHotelsByPlayerID(p.ID);
        }
        #endregion

        #region Cell management functions
        public struct CellEntrance
        {
            public CellEntrance(int idx, CellEntranceTypeEnum cet)
            {
                CellNO = idx;
                CET = cet;
            }

            public int CellNO;
            public CellEntranceTypeEnum CET;
        }

        /// <summary>
        /// Returns true if cell isn't occupied by a player
        /// </summary>
        /// <param name="idx">Cell number</param>
        /// <returns></returns>
        private bool IsCellEmpty(int idx)
        {
            foreach (Player p in Players)
                if (p.CurrentPosition == idx) return false;

            return true;
        }

        public GameCell GetCell(int idx)
        {
            return (GameCell)m_cellsList.GetCellByPosition(idx);
        }
        #endregion

        private int RollDice(/*Player p,*/ int value)
        {
#if Debug
#else
            Random rd = new Random();
            value = rd.Next(1, 7);
#endif

            //int newPosition = Convert.Toint(p.CurrentPosition + value);
            //newPosition = CorrectPosition(newPosition);

            //while (!IsCellEmpty(newPosition))
            //{
            //    newPosition++;
            //    newPosition = CorrectPosition(newPosition);
            //}

            //p.CurrentPosition = newPosition;

            return value;
        }

        private void MovePlayer(Player p, int value)
        {
            int newPosition = p.CurrentPosition + value;
            newPosition = (newPosition >= GameConst.LASTCELL) ? (newPosition -= GameConst.LASTCELL) : newPosition;

            while (!IsCellEmpty(newPosition))
            {
                newPosition++;
                newPosition = (newPosition >= GameConst.LASTCELL) ? (newPosition -= GameConst.LASTCELL) : newPosition;
            }

            p.CurrentPosition = newPosition;
        }

        private ContructionPermissionEnum RollConstructionDice()
        {
            /*
             * 1 - green face: permission granted
             * 2 - red face: permission denied
             * 3 - H: permission granted, for free
             * 4 - 2x: permission granted, double charge
            */

            int value;
            Random rd = new Random();
            value = rd.Next(1, 5);

            return (ContructionPermissionEnum)value;
        }

        /// <summary>
        /// Utilizzata per acquistare una proprietà
        /// </summary>
        /// <param name="h">Hotel beeing sold</param>
        /// <param name="p">Player who buys</param>
        public MessageObj BuyProperty(HotelObj h, Player p)
        {
            bool bFirseSellForProperty = (h.Owner == null);

            if (p.Money >= h.Cost)
            {
                if (!bFirseSellForProperty)
                {
                    Player oldOwner = h.Owner;
                    oldOwner.Money += h.Cost;
                }

                h.Owner = p;
                p.Money -= h.Cost;

                // E' la prima vendita, quindi dimezzo il prezzo per i successivi acquisti
                if (bFirseSellForProperty)
                {
                    h.SetExpropriationCost();

                }

                return new MessageObj()
                {
                    Summary = "Buy hotel",
                    Description = "You have just bought " + h.Name + ", congratulation!",
                    Type = MessageTypeEnum.Info,
                    Buttons = MessageButtonsEnum.OK
                };
            }
            else
            {
                return new MessageObj()
                {
                    Summary = "Buy hotel",
                    Description = "Sorry, you haven't enought money for " + h.Name,
                    Type = MessageTypeEnum.OperationDenied,
                    Buttons = MessageButtonsEnum.OK
                };
            }
        }

        public void NextTurn()
        {
            // Turno al giocatore successivo...
            ActivePlayerId++;
            if (ActivePlayerId == Players.Count)
                ActivePlayerId = 0;

            m_canSave = true;
        }

        public int DoTurn(int value)
        {
            try
            {
                m_canSave = false;
                Player p = GetPlayerByID(ActivePlayerId);
                value = RollDice(value);
                MovePlayer(p, value);

                // todo azioni
                // 1. devo ritirare i $$ del giro? FATTO!
                // 2. posso acquistare ingressi? FATTO!
                // 3. sono finito in casa di qualcuno e devo pagare?
                // 4. valutazione dell'azione possibile delle cella su cui sono capitato

                // Transition actions
                if (p.CanBuyEntrance)
                {
                    p.AddAction(CellActionTypeEnum.CanBuyEntrance);
                }

                // Final cell actions
                p.AddAction(GetCurrentPlayerCell.CellActionType);

                // Payments
                switch (GetCurrentPlayerCell.Entrance)
                {
                    case CellEntranceTypeEnum.Left:
                        BillPayment(p, m_hotelList.GetHotelByName(GetCurrentPlayerCell.LeftHotel));
                        break;
                    case CellEntranceTypeEnum.Right:
                        BillPayment(p, m_hotelList.GetHotelByName(GetCurrentPlayerCell.RightHotel));
                        break;
                    case CellEntranceTypeEnum.BothSides:
                        BillPayment(p, m_hotelList.GetHotelByName(GetCurrentPlayerCell.LeftHotel));
                        BillPayment(p, m_hotelList.GetHotelByName(GetCurrentPlayerCell.RightHotel));
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exceptin in DoTurn: " + ex.Message + " - " + ex.InnerException);
            }


            return value;
        }

        /// <summary>
        /// Tells which action can the player do now
        /// </summary>
        public CellActionTypeEnum GetNextAction()
        {
            Player p = GetPlayerByID(ActivePlayerId);
            return p.GetNextAction();
        }

        private void BillPayment(Player p, HotelObj h)
        {
            if (p.Equals(h.Owner))
                return; // TODO: segnalare!!!

            // Roll dice to calculate nights
            Decimal oneNightBill = h.GetCurrentRate().PricePerNight;
            //Transfer

            // TODO: dice will be rolled automatically, so it's necessary to notice players someway.
            int nights = RollDice(0);
            Decimal totalBill = oneNightBill * nights;
            p.Money -= totalBill;
            h.Owner.Money += totalBill;
        }

        public MessageObj BuyEntrance(int cellNumber, CellEntranceTypeEnum cet)
        {
            Player p = GetPlayerByID(ActivePlayerId);
            return AddEntrance(cet, p, false, m_cellsList.GetCellByPosition(cellNumber));
        }

        public MessageObj AddEntrance(CellEntranceTypeEnum side, Player currentPlayer, bool freeEntrance, GameCell cell)
        {
            // Se esiste già l'entrata esco subito
            if (cell.Entrance == CellEntranceTypeEnum.BothSides || cell.Entrance == side)
                return new MessageObj()
                {
                    Summary = "Add entrance",
                    Description = "Entrance already present in this position",
                    Type = MessageTypeEnum.Error,
                    Buttons = MessageButtonsEnum.OK
                };

            HotelObj tempHotel = null;

            if (side == CellEntranceTypeEnum.Left)
                tempHotel = m_hotelList.GetHotelByName(cell.LeftHotel);
            else if (side == CellEntranceTypeEnum.Right)
                tempHotel = m_hotelList.GetHotelByName(cell.RightHotel);
            else
                return new MessageObj()
                {
                    Summary = "Add entrance",
                    Description = "Cannot add entrance on both sides (developer mistake)",
                    Type = MessageTypeEnum.Error,
                    Buttons = MessageButtonsEnum.OK
                };

            if (tempHotel.CanHaveEntrance() && tempHotel.Owner == currentPlayer)
            {
                if (freeEntrance || tempHotel.Owner.Money >= tempHotel.EntranceCost)
                {
                    tempHotel.Owner.Money -= tempHotel.EntranceCost;
                    cell.Entrance = side;
                    string cost = (freeEntrance) ? " for free" : " at a cost of " + tempHotel.EntranceCost;
                    return new MessageObj()
                    {
                        Summary = "Add entrance",
                        Description = "A new entrance has been added to " + tempHotel.Name + " " + cost,
                        Type = MessageTypeEnum.Info,
                        Buttons = MessageButtonsEnum.OK
                    };
                }
                else
                    return new MessageObj()
                    {
                        Summary = "Add entrance",
                        Description = "Sorry, you've not enough money to buy a new entrance",
                        Type = MessageTypeEnum.OperationDenied,
                        Buttons = MessageButtonsEnum.OK
                    };
            }
            else
            {
                string message = (tempHotel.CanHaveEntrance()) ? "No entrance allowed in this position" : "You must own the hotel to buy a new entrance";
                return new MessageObj()
                {
                    Summary = "Add entrance",
                    Description = message,
                    Type = MessageTypeEnum.OperationDenied,
                    Buttons = MessageButtonsEnum.OK
                };
            }
        }

        public MessageObj UpgradeProperty(HotelObj h, int requestedCategory, decimal cost)
        {
            Player p = GetPlayerByID(ActivePlayerId);

            ContructionPermissionEnum cp = RollConstructionDice();
            string diceResult;

            switch (cp)
            {
                case ContructionPermissionEnum.Denied:
                    return new MessageObj()
                    {
                        Summary = "Upgrade property",
                        Description = "Sorry, permission denied!",
                        Type = MessageTypeEnum.OperationDenied,
                        Buttons = MessageButtonsEnum.OK
                    };
                    break;
                case ContructionPermissionEnum.DoubleCharged:
                    cost = cost * 2;
                    break;
                case ContructionPermissionEnum.ForFree:
                    cost = 0;
                    break;
            }

            if (h.UpgradeCategory(p, requestedCategory, cost))
            {
                return new MessageObj()
                {
                    Summary = "Upgrade property",
                    Description = h.Name + " has been upgraded to category " + requestedCategory + " at a cost of " + cost + " (" + cp + ")",
                    Type = MessageTypeEnum.OperationDenied,
                    Buttons = MessageButtonsEnum.OK
                };
            }
            else
            {
                return new MessageObj()
                {
                    Summary = "Upgrade property",
                    Description = "Sorry, you haven't enought money for " + h.Name,
                    Type = MessageTypeEnum.OperationDenied,
                    Buttons = MessageButtonsEnum.OK
                };
            }
        }

        public Player GetActivePlayer()
        {
            return Players.GetPlayerByID(ActivePlayerId);
        }

        private GameCellCollection m_cellsList;
        /// <summary>
        /// Contains all data that need to be serialized for persistance and multiplaying game
        /// </summary>
        private GameLogicPersistence m_persistanceObject;

    }
}
