using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HotelEngine;
using HotelEntities;

namespace Hotel
{
    public partial class GUIBuyEntrance : UserControl
    {
        // Events
        public delegate void CloseGUI();
        public event CloseGUI OnCloseGUI;

        private GameLogicObj _gameLogic;

        /// <summary>
        /// Apre l'interfaccia per il posizionamento di una nuova entrata
        /// </summary>
        /// <param name="free">True se l'entrata è gratuita</param>
        public GUIBuyEntrance(GameLogicObj tableGame, bool free)
        {
            InitializeComponent();
            _gameLogic = tableGame;

            if (free)
            {
                groupBox1.Text = "Free entrance";
                btnBuy.Text = "Place";
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            // Verificare se la posizione richiesta corrisponde ad un albergo di proprietà del
            // giocatore e se non esiste già un'entrata in tale posizione
            MessageObj resultMessage = _gameLogic.BuyEntrance(int.Parse(txtCellNumber.Text), rbLeft.Checked ? CellEntranceTypeEnum.Left : CellEntranceTypeEnum.Right);
            ((GameMasterControl)Parent.Parent).ShowMessage(resultMessage);
            OnCloseGUI();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            OnCloseGUI();
        }
    }
}
