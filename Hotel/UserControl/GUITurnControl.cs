using HotelEngine;
using System;
using System.Windows.Forms;

namespace Hotel
{
    public partial class GUITurnControl : UserControl
    {
        private GameLogicObj _gameLogic;
        public GameLogicObj TG
        {
            set
            {
                _gameLogic = value;
                txtActivePlayer.Text = _gameLogic.ActivePlayerId.ToString();
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
            if (Dice.Text != string.Empty)
                DiceValue = Convert.ToInt32(Dice.Text);

            //if (DiceValue != 6)
            //{
            //    btnRoll.Enabled = false;
            //    btnEndTurn.Enabled = true;
            //}

            btnEndTurn.Enabled = true;

            try
            {
                Dice.Text = _gameLogic.DoTurn(DiceValue).ToString();

                OnExecuteActions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //OnUpdateControlRequired();
        }

        private void btnForceAP_Click(object sender, EventArgs e)
        {
            _gameLogic.ActivePlayerId = Convert.ToInt32(txtActivePlayer.Text);
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
            txtActivePlayer.Text = _gameLogic.ActivePlayerId.ToString();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            _gameLogic.ResetGame();
            OnUpdateControlRequired();
        }

    }
}
