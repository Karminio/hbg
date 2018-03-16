using HotelEngine;
using System;
using System.Drawing;
using System.Windows.Forms;
using HotelEntities;

namespace Hotel
{
    public partial class GameMasterControl : UserControl
    {
        const int COLNO_IDX     = 0;
        const int CELLTYPE_IDX  = 1;
        const int LPLEV_IDX     = 2;
        const int LP_IDX        = 3;
        const int LPENT_IDX     = 4;
        const int PLAYERNO_IDX  = 5;
        const int RPENT_IDX     = 6;
        const int RP_IDX        = 7;
        const int RPLEV_IDX     = 8;

        // User controls
        private GUIBuyProperty guiBuyProperty;
        private GUIBuildProperty guiBuildProperty;
        private GUIBuyEntrance guiBuyEntrance;

        public GameMasterControl()
        {
            InitializeComponent();
        }

        private GameLogicObj _tableLogic;
        public GameLogicObj TableGame
        {
            set 
            {
                _tableLogic = value;
                InitializeControl();
            }
        }

        private void InitializeControl()
        {
            int numberOfCells = _tableLogic.NumberOfCells - 1; // -1 because the first cell is the park lot and has position -1 
            grid.RowCount = numberOfCells;

            for (int i = 0; i < numberOfCells; i++)
            {
                grid[COLNO_IDX, i].Value = i.ToString();

                GameCell gc = _tableLogic.GetCell(i);

                grid[CELLTYPE_IDX, i].Value = gc.CellActionType.ToString();

                if (gc.LeftHotel != null)
                {
                    grid[LP_IDX, i].Value = gc.LeftHotel;
                }

                if (gc.RightHotel != null)
                {
                    grid[RP_IDX, i].Value = gc.RightHotel;
                }
            }

            // Interfaccia del PlayerControl - Solo per DEBUG!!!
            pc1.PlayerID = 0;
            pc2.PlayerID = 1;
            pc3.PlayerID = 2;
            pc4.PlayerID = 3;

            pc1.TG = pc2.TG = pc3.TG = pc4.TG = _tableLogic;

            guiStatus.TG = _tableLogic;

            UpdateControl();
        }

        private void BuyEntranceGUI(bool free)
        {
            guiStatus.Visible = false;
            guiBuyEntrance = new GUIBuyEntrance(_tableLogic, free);
            guiBuyEntrance.OnCloseGUI += new GUIBuyEntrance.CloseGUI(guiBuyEntrance_OnCloseGUI);
            guiBuyEntrance.Dock = DockStyle.Fill;

            UserPanel.Controls.Add(guiBuyEntrance);
        }

        void guiBuyEntrance_OnCloseGUI()
        {
            UserPanel.Controls.Remove(guiBuyEntrance);
            guiBuyEntrance.Dispose();
            guiStatus.Visible = true;

            ExecuteNextAction();
        }

        private void BuildPropertyGUI()
        {
            guiStatus.Visible = false;
            guiBuildProperty = new GUIBuildProperty(_tableLogic);
            guiBuildProperty.OnCloseGUI += new GUIBuildProperty.CloseGUI(guiBuildProperty_OnCloseGUI);
            guiBuildProperty.Dock = DockStyle.Fill;

            UserPanel.Controls.Add(guiBuildProperty);
        }

        void guiBuildProperty_OnCloseGUI()
        {
            UserPanel.Controls.Remove(guiBuildProperty);
            guiBuildProperty.Dispose();
            guiStatus.Visible = true;

            ExecuteNextAction();
        }

        private void BuyPropertyGUI()
        {
            guiStatus.Visible = false;
            guiBuyProperty = new GUIBuyProperty(_tableLogic);
            guiBuyProperty.OnCloseGUI += new GUIBuyProperty.CloseGUI(guiBP_OnCloseGUI);
            guiBuyProperty.Dock = DockStyle.Fill;

            UserPanel.Controls.Add(guiBuyProperty);
        }

        void guiBP_OnCloseGUI()
        {
            UserPanel.Controls.Remove(guiBuyProperty);
            guiBuyProperty.Dispose();
            guiStatus.Visible = true;

            ExecuteNextAction();
        }

        /// <summary>
        /// Ridisegno il TableGameControl
        /// Deve essere richiamato ad ogni cambio di stato della classe TableGame
        /// </summary>
        public void UpdateControl()
        {
            int numberOfCells = _tableLogic.NumberOfCells - 1; // -1 because the first cell is the park lot and has position -1 

            for (int i = 0; i < numberOfCells; i++)
            {
                grid[PLAYERNO_IDX, i].Value = string.Empty;
                grid[PLAYERNO_IDX, i].Style.BackColor = Color.White;
                grid[RPENT_IDX, i].Style.BackColor = Color.White;
                grid[LPENT_IDX, i].Style.BackColor = Color.White;

                GameCell gc = _tableLogic.GetCell(i);

                #region Aggiorno il colore che indica il proprietario degli hotels

                if (gc.LeftHotel != null)
                    if (_tableLogic.GetHotelByName(gc.LeftHotel).Owner == null)
                        grid[LP_IDX, i].Style.BackColor = Color.White;
                    else
                        grid[LP_IDX, i].Style.BackColor = _tableLogic.GetHotelByName(gc.LeftHotel).Owner.PlaceholderColor.CustomColor;
                if (gc.RightHotel != null)
                    if (_tableLogic.GetHotelByName(gc.RightHotel).Owner == null)
                        grid[RP_IDX, i].Style.BackColor = Color.White;
                    else
                        grid[RP_IDX, i].Style.BackColor = _tableLogic.GetHotelByName(gc.RightHotel).Owner.PlaceholderColor.CustomColor;

                #endregion

                #region Aggiorno le entrate

                if (gc.Entrance == CellEntranceTypeEnum.Right || gc.Entrance == CellEntranceTypeEnum.BothSides)
                    grid[RPENT_IDX, i].Style.BackColor = Color.Yellow;
                if (gc.Entrance == CellEntranceTypeEnum.Left || gc.Entrance == CellEntranceTypeEnum.BothSides)
                    grid[LPENT_IDX, i].Style.BackColor = Color.Yellow;

                #endregion

                #region Aggiorno il livello degli Hotels

                if (gc.LeftHotel != null)
                    grid[LPLEV_IDX, i].Value = _tableLogic.GetHotelByName(gc.LeftHotel).CurrentCategory;

                if (gc.RightHotel != null)
                    grid[RPLEV_IDX, i].Value = _tableLogic.GetHotelByName(gc.RightHotel).CurrentCategory;

                #endregion

            }

            #region Aggiorno la posizione dei giocatori sul tabellone
            for (int i = 0; i <= _tableLogic.Players.Count - 1; i++)
            {
                Player p = _tableLogic.GetPlayerByID(i);

                if (p.CurrentPosition > -1)
                {
                    grid[PLAYERNO_IDX, p.CurrentPosition].Value = i;
                    grid[PLAYERNO_IDX, p.CurrentPosition].Style.BackColor = p.PlaceholderColor.CustomColor;
                }
            }
            #endregion

            // Ridisegno i PlayerControls
            foreach (Control c in Controls)
                if (c is PlayerInfoControl)
                    ((PlayerInfoControl)c).UpdatePlayerStatus();

            btSave.Enabled = _tableLogic.CanSave;

            guiStatus.UpdateControl();
        }

        private void guiStatus_OnUpdateControlRequired()
        {
            UpdateControl();
        }

        private void guiStatus_OnEndTurn()
        {
            _tableLogic.EndTurn();
            UpdateControl();
        }

        private void ExecuteNextAction()
        {
            UpdateControl();
            Player p = _tableLogic.GetActivePlayer();
            CellActionTypeEnum cat = p.GetNextAction();

            switch (cat)
            {
                case CellActionTypeEnum.CanBuild:
                    BuyPropertyGUI();
                    break;
                case CellActionTypeEnum.CanBuy:
                    BuildPropertyGUI();
                    break;
                case CellActionTypeEnum.CanBuyEntrance:
                    BuyEntranceGUI(false);
                    break;
                case CellActionTypeEnum.FreeBuilding:
                    BuildPropertyGUI(); // TODO: free
                    break;
                case CellActionTypeEnum.FreeEntrance:
                    BuyEntranceGUI(true);
                    break;
                default:
                    break;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            MessageObj resultMessage = _tableLogic.SaveGameState();
            ShowMessage(resultMessage);
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            MessageObj resultMessage = _tableLogic.LoadGameState();            
            UpdateControl();
            ShowMessage(resultMessage);
        }

        public void ShowMessage(MessageObj message)
        {
            MessageBox.Show(message.Description, message.Summary);
        }

        private void btnSimulate1Turn_Click(object sender, EventArgs e)
        {
            _tableLogic.SimulateTurn();
        }

        private void btnSimulate10Turns_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++) {
                _tableLogic.SimulateTurn();
            }
        }
    }
}
