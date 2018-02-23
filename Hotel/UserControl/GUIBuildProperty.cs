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
    public partial class GUIBuildProperty : UserControl
    {
        const int IDX_UPGRADEBUTTON = 0;
        const int IDX_IMPLEVEL = 1;
        const int IDX_NAME = 2;
        const int IDX_IMPCOST = 3;

        private GameLogicObj _gameLogic;

        // Events
        public delegate void CloseGUI();
        public event CloseGUI OnCloseGUI;

        public GUIBuildProperty()
        {
            InitializeComponent();
            grid.RowCount = 0;
        }

        public GUIBuildProperty(GameLogicObj tableGame)
            :
            this()
        {
            _gameLogic = tableGame;
            HotelCollection ownHotelList = _gameLogic.GetOwnedProperties(_gameLogic.GetActivePlayer());

            // TODO: troppa logica, vedere se si può spostare nell'engine
            foreach (HotelObj ob in ownHotelList)
            {
                decimal impCost = 0;
                for (int i = ob.CurrentCategory; i <= ob.MaxCategory; i++)
                {
                    Category cat = ob.GetRate(i);
                    impCost += cat.BuildingCost;   

                    grid.RowCount++;
                    grid[IDX_UPGRADEBUTTON, grid.RowCount - 1].Value = "UPGRADE";
                    grid[IDX_IMPLEVEL, grid.RowCount - 1].Value = i;
                    grid[IDX_NAME, grid.RowCount - 1].Value = ob.Name;
                    grid[IDX_IMPCOST, grid.RowCount - 1].Value = impCost;
                }
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            OnCloseGUI();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Gestisco solo il click sul pulsante "UPGRADE"
            if (e.RowIndex < 0 || e.ColumnIndex != IDX_UPGRADEBUTTON)
                return;

            HotelObj selHotel = _gameLogic.GetHotelByName((string)grid[IDX_NAME, e.RowIndex].Value);
            int level = (int)grid[IDX_IMPLEVEL, e.RowIndex].Value;
            decimal cost = (decimal)grid[IDX_IMPCOST, e.RowIndex].Value;

            MessageObj resultMessage = _gameLogic.UpgradeProperty(selHotel, level, cost);
            ((GameMasterControl)Parent.Parent).ShowMessage(resultMessage);
            OnCloseGUI();
        }
    }
}
