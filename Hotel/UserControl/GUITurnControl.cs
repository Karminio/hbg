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
    public partial class GUITurnControl : UserControl
    {
        private GameLogicObj m_GameLogic;
        public GameLogicObj TG
        {
            set
            {
                m_GameLogic = value;
                txtActivePlayer.Text = m_GameLogic.ActivePlayerId.ToString(); 
            }
        }

        // Control's events
        public delegate void UpdateControlRequired();
        public event UpdateControlRequired OnUpdateControlRequired;

        public delegate void ExecuteActions();
        public event ExecuteActions OnExecuteActions;

        public delegate void EndTurn();
        public event EndTurn OnEndTurn;

        public GUITurnControl()
        {
            InitializeComponent();

            btnRoll.Enabled = true;
            btnEndTurn.Enabled = false;
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            int DiceValue = 1;
            if(Dice.Text != string.Empty)
                DiceValue = Convert.ToInt32(Dice.Text);

            //if (DiceValue != 6)
            //{
            //    btnRoll.Enabled = false;
            //    btnEndTurn.Enabled = true;
            //}

            btnEndTurn.Enabled = true;

            try
            {
                Dice.Text = m_GameLogic.DoTurn(DiceValue).ToString();

                OnExecuteActions();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
            }
            //OnUpdateControlRequired();
        }

        private void btnForceAP_Click(object sender, EventArgs e)
        {
            m_GameLogic.ActivePlayerId = Convert.ToInt32(txtActivePlayer.Text);
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            btnRoll.Enabled = true;
            btnEndTurn.Enabled = false;
            OnEndTurn();
        }

        /// <summary>
        /// Ridisegna il lo user control
        /// </summary>
        public void UpdateControl()
        {
            txtActivePlayer.Text = m_GameLogic.ActivePlayerId.ToString(); 
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            m_GameLogic.ResetGame();
            OnUpdateControlRequired();
        }

    }
}
