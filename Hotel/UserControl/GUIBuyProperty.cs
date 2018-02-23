using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HotelEngine;
using HotelEntities;

namespace Hotel
{
    public partial class GUIBuyProperty : UserControl
    {
        const int IDX_BUYBUTTON = 0;
        const int IDX_NAME = 1;
        const int IDX_COST = 2;
        const int IDX_OWNER = 3;

        private GameLogicObj _gameLogic;

        // Events
        public delegate void CloseGUI();
        public event CloseGUI OnCloseGUI;

        private ArrayList _alHotel;

        public GUIBuyProperty()
        {
            InitializeComponent();
            grid.RowCount = 0;
            _alHotel = new ArrayList();
        }

        public GUIBuyProperty(GameLogicObj tableGame)
            :
            this()
        {
            _gameLogic = tableGame;

            HotelObj lHotel = _gameLogic.GetHotelByName(_gameLogic.CurrentPlayerCell.LeftHotel);
            HotelObj rHotel = _gameLogic.GetHotelByName(_gameLogic.CurrentPlayerCell.RightHotel);

            AddHotelToGrid(lHotel);
            AddHotelToGrid(rHotel);            
        }

        private void AddHotelToGrid (HotelObj h)
        {
            if (h == null)
                return;

            grid.RowCount++;
            grid[IDX_BUYBUTTON, grid.RowCount - 1].Value = "BUY";
            grid[IDX_NAME, grid.RowCount - 1].Value = h.Name;
            grid[IDX_COST, grid.RowCount - 1].Value = h.Cost.ToString();
            grid[IDX_OWNER, grid.RowCount - 1].Value = (h.Owner != null) ? h.Owner.Name : "Nobody";

            _alHotel.Add(h);
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            OnCloseGUI();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gestisco solo il click sul pulsante "BUY"
            if (e.RowIndex < 0 || e.ColumnIndex != IDX_BUYBUTTON)
                return;

            HotelObj selHotel = (HotelObj)_alHotel[e.RowIndex];
            MessageObj resultMessage = _gameLogic.BuyProperty(selHotel, _gameLogic.GetActivePlayer());
            ((GameMasterControl)Parent.Parent).ShowMessage(resultMessage);
            OnCloseGUI();
            
        }
    }
}
