using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HotelEngine;

namespace Hotel
{
    public partial class PlayerInfoControl : UserControl
    {
        public PlayerInfoControl()
        {
            InitializeComponent();
            m_playerID = -1;
        }

        private GameLogicObj m_GameLogic;
        public GameLogicObj TG
        {
            set { m_GameLogic = value; }
        }

        private int m_playerID;

        public int PlayerID
        {
            get { return m_playerID; }
            set { m_playerID = value; }
        }

        public void UpdatePlayerStatus()
        {
            if (m_playerID == -1)
                return;

            Player p = m_GameLogic.GetPlayerByID(m_playerID);
            PlayerTitle.Text = "Player " + p.Name;
            txtMoney.Text = p.Money.ToString();
            txtCurrPos.Text = p.CurrentPosition.ToString();
            chkActive.Checked = (m_GameLogic.ActivePlayerId == m_playerID);
        }
    }
}
