using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel;
using HotelEngine;

namespace HotelTest
{
    public partial class HotelTestForm : Form
    {
        GameLogicObj myTableGame;

        public HotelTestForm()
        {
            InitializeComponent();
        }

        private void HotelTestForm_Load(object sender, EventArgs e)
        {
            myTableGame = new GameLogicObj();

            myTableGame.AddPlayer("Achille", Color.Orange);
            myTableGame.AddPlayer("Icaro", Color.SeaGreen);
            myTableGame.AddPlayer("Ulisse", Color.Yellow);
            myTableGame.AddPlayer("Patroclo", Color.PaleTurquoise);

            TableControl.TableGame = myTableGame;        
        }

    }
}
