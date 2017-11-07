using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HotelEngine;

namespace Hotel
{
    public partial class GUIBuyProperty : UserControl
    {
        const int IDX_BUYBUTTON = 0;
        const int IDX_NAME = 1;
        const int IDX_COST = 2;
        const int IDX_OWNER = 3;

        private GameLogicObj m_GameLogic;

        // Events
        public delegate void CloseGUI();
        public event CloseGUI OnCloseGUI;

        private ArrayList m_alHotel;

        public GUIBuyProperty()
        {
            InitializeComponent();
            grid.RowCount = 0;
            m_alHotel = new ArrayList();
        }

        public GUIBuyProperty(GameLogicObj tableGame)
            :
            this()
        {
            m_GameLogic = tableGame;

            HotelObj lHotel = m_GameLogic.GetHotelByName(m_GameLogic.GetCurrentPlayerCell.LeftHotel);
            HotelObj rHotel = m_GameLogic.GetHotelByName(m_GameLogic.GetCurrentPlayerCell.RightHotel);

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

            m_alHotel.Add(h);
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

            HotelObj selHotel = (HotelObj)m_alHotel[e.RowIndex];
            MessageObj resultMessage = m_GameLogic.BuyProperty(selHotel, m_GameLogic.GetActivePlayer());
            ((GameMasterControl)Parent.Parent).ShowMessage(resultMessage);
            OnCloseGUI();
            
        }
    }
}
