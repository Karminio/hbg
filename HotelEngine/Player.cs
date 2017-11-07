using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace HotelEngine
{
    public class Player : IEquatable<Player>
    {
        private ArrayList m_actions;

        public Player()
        {
            m_actions = new ArrayList();
        }

        public Player(string name, string ip, Color playerColor)
        {
            m_name = name;
            m_IPAddress = ip;

            m_Money = 15000;
            m_CurrentPosition = -1;
            //m_CurrentPosition = 0;

            m_color = playerColor;
            m_actions = new ArrayList();
        }

        #region Properties
        private string m_name;
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private string m_IPAddress;

        private Color m_color;

        [XmlIgnore]
        public Color Color
        {
            get { return m_color; }
            set { m_color = value; }
        }

        [XmlElement("PlayerColor")]
        public string ClrGridHtml
        {
            get { return ColorTranslator.ToHtml(m_color); }
            set { m_color = ColorTranslator.FromHtml(value); }
        }

        private bool m_CanBuyEntrance;
        public bool CanBuyEntrance
        {
            get { return m_CanBuyEntrance; }
            set { m_CanBuyEntrance = value; }
        }

        private int m_CurrentPosition;
        public int CurrentPosition
        {
            get { return m_CurrentPosition; }
            set
            {
                // Passata la linea per ritare il premio (MONEYCELL)
                if (m_CurrentPosition <= GameConst.MONEYCELL && value > GameConst.MONEYCELL)
                    m_Money += GameConst.MONEYPRIZE;

                // Passata la linea per acquistare ingressi (ENTRANCECELL)
                if (m_CurrentPosition <= GameConst.ENTRANCECELL && value > GameConst.ENTRANCECELL)
                    CanBuyEntrance = true;
                    //OnCanBuyEntrance();

                m_CurrentPosition = value;
            }
        }

        private decimal m_Money;
        public decimal Money
        {
            get { return m_Money; }
            set { m_Money = value; }
        }
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

        private int m_ID;

        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        //private ArrayList m_HotelOwned;

        #region IEquatable<Player> Members

        public bool Equals(Player other)
        {
            return (ID == other.ID);
        }

        #endregion
    }
}
