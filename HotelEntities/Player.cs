using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace HotelEntities
{
    public class Player : IEquatable<Player>
    {
        private List<CellActionTypeEnum> _actions;
        private string _IPAddress;

        public Player()
        {
            _actions = new List<CellActionTypeEnum>();
        }

        public Player(string name, string ip, HbgColor playerColor)
        {
            Name = name;
            _IPAddress = ip;

            Money = 15000;
            _currentPosition = -1;
            //_CurrentPosition = 0;

            PlaceholderColor = playerColor;
            _actions = new List<CellActionTypeEnum>();
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

        private int _currentPosition;
        public int CurrentPosition
        {
            get { return _currentPosition; }
            set
            {
                // Passata la linea per ritare il premio (MONEYCELL)
                if (_currentPosition <= GameConst.MONEYCELL && value > GameConst.MONEYCELL)
                    Money += GameConst.MONEYPRIZE;

                // Passata la linea per acquistare ingressi (ENTRANCECELL)
                if (_currentPosition <= GameConst.ENTRANCECELL && value > GameConst.ENTRANCECELL)
                    CanBuyEntrance = true;
                //OnCanBuyEntrance();

                _currentPosition = value;
            }
        }

        public decimal Money { get; set; }
        #endregion

        public void AddAction(CellActionTypeEnum cat)
        {
            _actions.Add(cat);
        }

        public CellActionTypeEnum GetNextAction()
        {
            if (_actions.Count > 0)
            {
                CellActionTypeEnum cat = (CellActionTypeEnum)_actions[0];
                _actions.RemoveAt(0);
                return cat;
            }
            else
                return CellActionTypeEnum.NoAction;
        }

        //private ArrayList _HotelOwned;

        #region IEquatable<Player> Members

        public bool Equals(Player other)
        {
            return (Id == other.Id);
        }

        #endregion
    }
}
