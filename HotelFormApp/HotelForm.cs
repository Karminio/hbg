using HotelEngine;
using System;
using System.Windows.Forms;

namespace HotelFormApp
{
    public partial class HotelForm : Form
    {
        public HotelForm()
        {
            InitializeComponent();
        }

        private void HotelForm_Load(object sender, EventArgs e)
        {
            StartingInfo newGameModal = new StartingInfo();  
            DialogResult dr = newGameModal.ShowDialog();

            if (dr == DialogResult.OK)
            {
                GameLogicObj gameLogic = newGameModal.GameLogic;
            }
            else {
                Close();
            }
        }
    }
}
