using HotelEntities;
using HotelEntities.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Unity;

namespace HotelEngine
{
    public class GameLogicObj
    {
        IUnityContainer _container;
        private GameCellCollection _cellsList;
        /// <summary>
        /// Contains all data that need to be serialized for persistance and multiplaying game
        /// </summary>
        private GameLogicPersistence _persistanceObject;

        #region Properties

        public int Id { get; set; }

        public PlayerCollection Players
        {
            get { return _persistanceObject.Players; }
            //set { _persistanceObject.Players = value; }
        }

        public int ActivePlayerId
        {
            get { return _persistanceObject.ActivePlayerID; }
            set { _persistanceObject.ActivePlayerID = value; }
        }

        private HotelCollection _hotelList;

        /// <summary>
        /// Game can be saved only between two turns, only when previous player declares "end turn" and before next player
        /// does any action.
        /// Start value is false.
        /// </summary>
        private bool _canSave;

        public bool CanSave
        {
            get { return _canSave; }
            //set { _canSave = value; }
        }

        #endregion

        public GameLogicObj()
        {
            // develop branch
            /// If game is starting now no persistance object already exists
            /// Otherwise at this point the object is valorized by deserialization
            /// Remarks: strong-named assemblies can only reference other strong-named assemblies.

            if (_persistanceObject == null)
                _persistanceObject = new GameLogicPersistence();

            _container = new UnityContainer();
            _container.LoadConfiguration();
            //_container.RegisterType<IHotelDataProvider, HotelJSONDataProvider.HotelJSONDataProvider>();
            IHotelDataProvider dataProvider = _container.Resolve<IHotelDataProvider>();

            Action<object> retrieveListsAction = (object obj) =>
            {
                Console.WriteLine("=== Starting task {0} ===", obj.ToString());
                DateTime start = DateTime.Now;
                _hotelList = dataProvider.RetrieveHotelCollection();
                _cellsList = dataProvider.RetrieveGameCellCollection();
                TimeSpan ts = DateTime.Now - start;
                Console.WriteLine("=== Hotel and cell lists retrieved!! In {0} ===", ts.ToString());
            };

            Task getLists = new Task(retrieveListsAction, "retrieveLists");
            getLists.Start();

            ActivePlayerId = 0;
            _canSave = false;
        }

        #region Game state management

        public MessageObj ResetGame()
        {
            // Backup of players
            PlayerCollection tempPC = Players;
            _persistanceObject = new GameLogicPersistence();

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
            //HotelObj h = _hotelList.GetHotelByName("President");
            //Player p = Players.GetPlayerByID(2);
            //_persistanceObject.OwnerShips.AddOwnership(h, p.ID);
            // ==================================================
            MessageObj resultMessage;
            MergeDataForSave();
            TextWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(GameLogicPersistence));
                writer = new StreamWriter(@"c:\temp\GameStatus.xml");
                ser.Serialize(writer, _persistanceObject);

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
                reader = new StreamReader(@"c:\temp\GameStatus.xml");
                _persistanceObject = (GameLogicPersistence)ser.Deserialize(reader);
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
            HotelCollection ownedHotels = _persistanceObject.OwnerShips.GetAllOwnedHotels();
            foreach (HotelObj ownedHotel in ownedHotels)
            {
                _hotelList.OverWrite(ownedHotel);
            }

            _cellsList.SetEntrancePosition(_persistanceObject.EntrancePositions);
        }

        /// <summary>
        /// Update hotels owner in the persistance object
        /// </summary>
        private void MergeDataForSave()
        {
            foreach (HotelObj hotel in _hotelList)
            {
                if (hotel.Owner != null)
                    _persistanceObject.OwnerShips.AddOwnership(hotel, hotel.Owner.Id);
            }

            _persistanceObject.EntrancePositions = _cellsList.GetEntrancesPosition();
        }

        #endregion

        #region Utilities

        public HotelObj GetHotelByName(string name)
        {
            return _hotelList.GetHotelByName(name);
        }

        public GameCell CurrentPlayerCell
        {
            get
            {
                Player p = GetPlayerByID(ActivePlayerId);
                return (GameCell)_cellsList.GetCellByPosition(p.CurrentPosition);
            }
        }

        public int NumberOfCells
        {
            get
            {
                return (_cellsList == null) ? 0 : _cellsList.Count;
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
            return _hotelList.GetOwnedProperties(p);
            //return _persistanceObject.OwnerShips.GetOwnedHotelsByPlayerID(p.ID);
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
            return (GameCell)_cellsList.GetCellByPosition(idx);
        }
        #endregion

        /// <summary>
        /// Generate a dice value in range {1-6}
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int RollDice(int? value = null)
        {
            if (!value.HasValue)
            {
                Random rd = new Random();
                value = rd.Next(1, 7);
            }

            return value.Value;
        }

        private void MovePlayer(Player p, int value)
        {
            // TODO: if 6 is obtained rolling dice, another roll is granted
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

        public void EndTurn()
        {
            // Turno al giocatore successivo...
            ActivePlayerId++;
            if (ActivePlayerId == Players.Count)
                ActivePlayerId = 0;

            _canSave = true;
        }

        /// <summary>
        /// Moves the current player of a random value {1-6} and 
        /// queue the action(s) to the player
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int DoTurn(int value)
        {
            try
            {
                _canSave = false;
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
                p.AddAction(CurrentPlayerCell.CellActionType);

                // Payments
                switch (CurrentPlayerCell.Entrance)
                {
                    case CellEntranceTypeEnum.Left:
                        BillPayment(p, _hotelList.GetHotelByName(CurrentPlayerCell.LeftHotel));
                        break;
                    case CellEntranceTypeEnum.Right:
                        BillPayment(p, _hotelList.GetHotelByName(CurrentPlayerCell.RightHotel));
                        break;
                    case CellEntranceTypeEnum.BothSides:
                        BillPayment(p, _hotelList.GetHotelByName(CurrentPlayerCell.LeftHotel));
                        BillPayment(p, _hotelList.GetHotelByName(CurrentPlayerCell.RightHotel));
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
            return AddEntrance(cet, p, false, _cellsList.GetCellByPosition(cellNumber));
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
                tempHotel = _hotelList.GetHotelByName(cell.LeftHotel);
            else if (side == CellEntranceTypeEnum.Right)
                tempHotel = _hotelList.GetHotelByName(cell.RightHotel);
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

    }
}
