using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;

namespace HotelEngine
{
    public class GameLogicPersistence
    {
        public GameLogicPersistence()
        {
            m_activePLayerID = -1;
            m_players = new PlayerCollection();
            m_ownerShips = new OwnershipCollection();
        }

        public int Id { get; set; }

        private int m_activePLayerID;
        public int ActivePlayerID
        {
            get { return m_activePLayerID; }
            set { m_activePLayerID = value; }
        }

        [XmlArray("PlayersList")]
        [XmlArrayItem("Player")]
        public PlayerCollection Players
        {
            get { return m_players; }
            set { m_players = value; }
        }

        private PlayerCollection m_players;
        private OwnershipCollection m_ownerShips;

        public OwnershipCollection OwnerShips
        {
            get { return m_ownerShips; }
            set { m_ownerShips = value; }
        }

        /// <summary>
        /// Each element indicates an entrance in the corrisponding cell number, left side of cells uses an offset of 100.
        /// Examples:
        /// cell 12 right -> 12
        /// cell 14 left -> 114
        /// </summary>
        [XmlArray("EntranceList")]
        [XmlArrayItem("EntrancePosition")]
        public List<EntrancePosition> EntrancePositions{ get;  set; }
    }
}
