using HotelEngine;
using HotelEntities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelFormApp
{
    public partial class StartingInfo : Form
    {
        private Color currentColor;
        //private List<Player> players = new List<Player>();
        private PlayerCollection players = new PlayerCollection();
        public GameLogicObj GameLogic = new GameLogicObj();

        //public List<Player> players = new List<Player>();
        public StartingInfo()
        {
            InitializeComponent();
        }

        private void btAddPlayer_Click(object sender, EventArgs e)
        {
            AddPlayer();
        }

        private void AddPlayer()
        {
            if (!string.IsNullOrEmpty(tbPlayerName.Text))
            {
                Player p = new Player(tbPlayerName.Text, null, new HbgColor() { CustomColor = lbColor.BackColor });
                players.Add(p);
                lbxAddedPlayers.DataSource = null;
                lbxAddedPlayers.DataSource = players;
                lbxAddedPlayers.DisplayMember = "Name";
                tbPlayerName.Text = "";
            }

            tbPlayerName.Focus();
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            if (lbxAddedPlayers.SelectedItem != null)
            {
                players.Remove((Player)lbxAddedPlayers.SelectedItem);
                lbxAddedPlayers.DataSource = null;
                lbxAddedPlayers.DataSource = players;
                lbxAddedPlayers.DisplayMember = "Name";
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (lbxAddedPlayers.Items.Count >= 2)
            {                
                foreach (Player p in lbxAddedPlayers.Items)
                {
                    GameLogic.AddPlayer(p);
                }

            }
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
                lbColor.BackColor = currentColor;
            }


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

    }
}
