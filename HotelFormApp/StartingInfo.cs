using HotelEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelFormApp
{
    public partial class StartingInfo : Form
    {
        private Color currentColor;
        public GameLogicObj GameLogic { get; set; }

        public List<Player> players = new List<Player>();
        public StartingInfo()
        {
            InitializeComponent();
        }

        private void btAddPlayer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPlayerName.Text)) {
                Player p = new Player(tbPlayerName.Text, null, new HbgColor() { CustomColor = Color.Blue });
                lbxAddedPlayers.Items.Add(tbPlayerName.Text);
            }
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (lbxAddedPlayers.Items.Count >= 2)
            {
                GameLogic = new GameLogicObj();

                foreach(string player in lbxAddedPlayers.Items)
                {
                    Player p = new Player(player, null, new HbgColor() { CustomColor = Color.Blue });
                    GameLogic.AddPlayer(p);
                }
                
            }
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if(dr == DialogResult.OK) {
                currentColor = colorDialog1.Color;
                lbColor.BackColor = currentColor;
            }
            
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
