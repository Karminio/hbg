using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace HotelEngine
{
    public class Player : IEquatable<Player>
    {
        private List<CellActionTypeEnum> m_actions;
        private string m_IPAddress;

        public Player()
        {
            m_actions = new List<CellActionTypeEnum>();
        }

        public Player(string name, string ip, HbgColor playerColor)
        {
            Name = name;
            m_IPAddress = ip;

            Money = 15000;
            m_currentPosition = -1;
            //m_CurrentPosition = 0;

            PlaceholderColor = playerColor;
            m_actions = new List<CellActionTypeEnum>();
        }

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        public HbgColor PlaceholderColor { get; set; }

        [XmlElement("PlayerColor")]
        public string ClrGridHtml
        {
            get { return ColorTranslator.ToHtml(PlaceholderColor.CustomColor); }
            set { PlaceholderColor.CustomColor = ColorTranslator.FromHtml(value); }
        }

        public bool CanBuyEntrance { get; set; }

        private int m_currentPosition;
        public int CurrentPosition
        {
            get { return m_currentPosition; }
            set
            {
                // Passata la linea per ritare il premio (MONEYCELL)
                if (m_currentPosition <= GameConst.MONEYCELL && value > GameConst.MONEYCELL)
                    Money += GameConst.MONEYPRIZE;

                // Passata la linea per acquistare ingressi (ENTRANCECELL)
                if (m_currentPosition <= GameConst.ENTRANCECELL && value > GameConst.ENTRANCECELL)
                    CanBuyEntrance = true;
                //OnCanBuyEntrance();

                m_currentPosition = value;
            }
        }

        public decimal Money { get; set; }
        #endregion

        public void AddAction(CellActionTypeEnum cat)
        {
            m_actions.Add(cat);
        }

        public CellActionTypeEnum GetNextAction()
        {
            if (m_actions.Count > 0)
            {
                CellActionTypeEnum cat = (CellActionTypeEnum)m_actions[0];
                m_actions.RemoveAt(0);
                return cat;
            }
            else
                return CellActionTypeEnum.NoAction;
        }

        //private ArrayList m_HotelOwned;

        #region IEquatable<Player> Members

        public bool Equals(Player other)
        {
            return (Id == other.Id);
        }

        #endregion
    }
}
