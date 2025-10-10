using HotelEngine;
using HotelEntities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelFormApp
{
    public partial class HotelForm : Form
    {
        public HotelForm()
        {
            InitializeComponent();
        }

        private void HotelFor_Load(object sender, EventArgs e)
        {
#if DEBUG
            GameLogicObj gameLogic = new GameLogicObj();
            gameLogic.AddPlayer(new Player("Anna", null, new HbgColor() { CustomColor = Color.BlueViolet }));
            gameLogic.AddPlayer(new Player("Dani", null, new HbgColor() { CustomColor = Color.PaleTurquoise }));
            gameLogic.AddPlayer(new Player("Leo", null, new HbgColor() { CustomColor = Color.Tomato }));
            gameMasterControl1.TableGame = gameLogic;
#else
            StartingInfo newGameModal = new StartingInfo();  
            DialogResult dr = newGameModal.ShowDialog();

            if (dr == DialogResult.OK)
            {
                GameLogicObj gameLogic = newGameModal.GameLogic;
                gameMasterControl1.TableGame = gameLogic;
            }
            else {
                Close();
            }
#endif
        }
    }
}
