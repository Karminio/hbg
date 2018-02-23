using HotelEngine;
using System.Windows.Forms;
using HotelEntities;

namespace Hotel
{
    public partial class PlayerInfoControl : UserControl
    {
        public PlayerInfoControl()
        {
            InitializeComponent();
            _playerID = -1;
        }

        private GameLogicObj _gameLogic;
        public GameLogicObj TG
        {
            set { _gameLogic = value; }
        }

        private int _playerID;

        public int PlayerID
        {
            get { return _playerID; }
            set { _playerID = value; }
        }

        public void UpdatePlayerStatus()
        {
            if (_playerID == -1)
                return;

            Player p = _gameLogic.GetPlayerByID(_playerID);

            if (p == null) { return; }

            PlayerTitle.Text = "Player " + p.Name;
            txtMoney.Text = p.Money.ToString();
            txtCurrPos.Text = p.CurrentPosition.ToString();
            chkActive.Checked = (_gameLogic.ActivePlayerId == _playerID);
        }
    }
}
