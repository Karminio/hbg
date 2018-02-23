using System.Collections.Generic;
using System.Xml.Serialization;
using HotelEntities;

namespace HotelEngine
{
    public class GameLogicPersistence
    {
        public GameLogicPersistence()
        {
            _activePLayerID = -1;
            _players = new PlayerCollection();
            _ownerShips = new OwnershipCollection();
        }

        public int Id { get; set; }

        private int _activePLayerID;
        public int ActivePlayerID
        {
            get { return _activePLayerID; }
            set { _activePLayerID = value; }
        }

        [XmlArray("PlayersList")]
        [XmlArrayItem("Player")]
        public PlayerCollection Players
        {
            get { return _players; }
            set { _players = value; }
        }

        private PlayerCollection _players;
        private OwnershipCollection _ownerShips;

        public OwnershipCollection OwnerShips
        {
            get { return _ownerShips; }
            set { _ownerShips = value; }
        }

        /// <summary>
        /// Each element indicates an entrance in the corrisponding cell number, left side of cells uses an offset of 100.
        /// Examples:
        /// cell 12 right -> 12
        /// cell 14 left -> 114
        /// </summary>
        [XmlArray("EntranceList")]
        [XmlArrayItem("EntrancePosition")]
        public List<EntrancePosition> EntrancePositions { get; set; }
    }
}
