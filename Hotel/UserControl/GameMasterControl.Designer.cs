namespace Hotel
{
    partial class GameMasterControl
    {
        private System.Windows.Forms.DataGridView grid;
        private PlayerInfoControl pc1;
        private PlayerInfoControl pc3;
        private PlayerInfoControl pc4;
        private PlayerInfoControl pc2;
        private System.Windows.Forms.Panel UserPanel;
        private GUITurnControl guiStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellType;
        private System.Windows.Forms.DataGridViewTextBoxColumn LPLev;
        private System.Windows.Forms.DataGridViewTextBoxColumn LPName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerNO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RPL;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.CellNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPLev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PlayerNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RPE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RPL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.btLoad = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.guiStatus = new Hotel.GUITurnControl();
            this.pc4 = new Hotel.PlayerInfoControl();
            this.pc2 = new Hotel.PlayerInfoControl();
            this.pc3 = new Hotel.PlayerInfoControl();
            this.pc1 = new Hotel.PlayerInfoControl();
            this.btnSimulate1Turn = new System.Windows.Forms.Button();
            this.btnSimulate10Turns = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.UserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CellNO,
            this.CellType,
            this.LPLev,
            this.LPName,
            this.LPE,
            this.PlayerNO,
            this.RPE,
            this.RPName,
            this.RPL});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle6;
            this.grid.Location = new System.Drawing.Point(269, 3);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 20;
            this.grid.RowTemplate.Height = 15;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowCellToolTips = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(479, 501);
            this.grid.TabIndex = 0;
            // 
            // CellNO
            // 
            this.CellNO.HeaderText = "No.";
            this.CellNO.Name = "CellNO";
            this.CellNO.ReadOnly = true;
            this.CellNO.Width = 30;
            // 
            // CellType
            // 
            this.CellType.HeaderText = "Cell Type";
            this.CellType.Name = "CellType";
            this.CellType.ReadOnly = true;
            this.CellType.Width = 80;
            // 
            // LPLev
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LPLev.DefaultCellStyle = dataGridViewCellStyle1;
            this.LPLev.HeaderText = "Lev.";
            this.LPLev.Name = "LPLev";
            this.LPLev.ReadOnly = true;
            this.LPLev.Width = 30;
            // 
            // LPName
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LPName.DefaultCellStyle = dataGridViewCellStyle2;
            this.LPName.HeaderText = "Left property";
            this.LPName.Name = "LPName";
            this.LPName.ReadOnly = true;
            // 
            // LPE
            // 
            this.LPE.HeaderText = "En.";
            this.LPE.Name = "LPE";
            this.LPE.ReadOnly = true;
            this.LPE.Width = 30;
            // 
            // PlayerNO
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNO.DefaultCellStyle = dataGridViewCellStyle3;
            this.PlayerNO.HeaderText = "Player No.";
            this.PlayerNO.Name = "PlayerNO";
            this.PlayerNO.ReadOnly = true;
            this.PlayerNO.Width = 40;
            // 
            // RPE
            // 
            this.RPE.HeaderText = "En.";
            this.RPE.Name = "RPE";
            this.RPE.ReadOnly = true;
            this.RPE.Width = 30;
            // 
            // RPName
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.RPName.DefaultCellStyle = dataGridViewCellStyle4;
            this.RPName.HeaderText = "Right propery";
            this.RPName.Name = "RPName";
            this.RPName.ReadOnly = true;
            // 
            // RPL
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RPL.DefaultCellStyle = dataGridViewCellStyle5;
            this.RPL.HeaderText = "Lev.";
            this.RPL.Name = "RPL";
            this.RPL.ReadOnly = true;
            this.RPL.Width = 30;
            // 
            // UserPanel
            // 
            this.UserPanel.Controls.Add(this.btnSimulate10Turns);
            this.UserPanel.Controls.Add(this.btnSimulate1Turn);
            this.UserPanel.Controls.Add(this.btLoad);
            this.UserPanel.Controls.Add(this.btSave);
            this.UserPanel.Controls.Add(this.guiStatus);
            this.UserPanel.Location = new System.Drawing.Point(4, 512);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(744, 181);
            this.UserPanel.TabIndex = 5;
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(344, 53);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 2;
            this.btLoad.Text = "Load state";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(344, 23);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Save state";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // guiStatus
            // 
            this.guiStatus.Location = new System.Drawing.Point(0, 0);
            this.guiStatus.Name = "guiStatus";
            this.guiStatus.Size = new System.Drawing.Size(212, 178);
            this.guiStatus.TabIndex = 0;
            this.guiStatus.OnUpdateControlRequired += new Hotel.GUITurnControl.UpdateControlRequired(this.guiStatus_OnUpdateControlRequired);
            this.guiStatus.OnExecuteActions += new Hotel.GUITurnControl.ExecuteActions(this.ExecuteNextAction);
            this.guiStatus.OnEndTurn += new Hotel.GUITurnControl.EndTurn(this.guiStatus_OnEndTurn);
            // 
            // pc4
            // 
            this.pc4.Location = new System.Drawing.Point(0, 255);
            this.pc4.Name = "pc4";
            this.pc4.PlayerID = -1;
            this.pc4.Size = new System.Drawing.Size(263, 84);
            this.pc4.TabIndex = 4;
            // 
            // pc2
            // 
            this.pc2.Location = new System.Drawing.Point(0, 87);
            this.pc2.Name = "pc2";
            this.pc2.PlayerID = -1;
            this.pc2.Size = new System.Drawing.Size(263, 84);
            this.pc2.TabIndex = 3;
            // 
            // pc3
            // 
            this.pc3.Location = new System.Drawing.Point(0, 171);
            this.pc3.Name = "pc3";
            this.pc3.PlayerID = -1;
            this.pc3.Size = new System.Drawing.Size(263, 84);
            this.pc3.TabIndex = 2;
            // 
            // pc1
            // 
            this.pc1.Location = new System.Drawing.Point(0, 3);
            this.pc1.Name = "pc1";
            this.pc1.PlayerID = -1;
            this.pc1.Size = new System.Drawing.Size(263, 84);
            this.pc1.TabIndex = 1;
            // 
            // btnSimulate1Turn
            // 
            this.btnSimulate1Turn.Location = new System.Drawing.Point(470, 26);
            this.btnSimulate1Turn.Name = "btnSimulate1Turn";
            this.btnSimulate1Turn.Size = new System.Drawing.Size(173, 19);
            this.btnSimulate1Turn.TabIndex = 3;
            this.btnSimulate1Turn.Text = "Simulate 1 turn";
            this.btnSimulate1Turn.UseVisualStyleBackColor = true;
            this.btnSimulate1Turn.Click += new System.EventHandler(this.btnSimulate1Turn_Click);
            // 
            // btnSimulate10Turns
            // 
            this.btnSimulate10Turns.Location = new System.Drawing.Point(470, 53);
            this.btnSimulate10Turns.Name = "btnSimulate10Turns";
            this.btnSimulate10Turns.Size = new System.Drawing.Size(173, 19);
            this.btnSimulate10Turns.TabIndex = 4;
            this.btnSimulate10Turns.Text = "Simulate 10 turns";
            this.btnSimulate10Turns.UseVisualStyleBackColor = true;
            this.btnSimulate10Turns.Click += new System.EventHandler(this.btnSimulate10Turns_Click);
            // 
            // GameMasterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UserPanel);
            this.Controls.Add(this.pc4);
            this.Controls.Add(this.pc2);
            this.Controls.Add(this.pc3);
            this.Controls.Add(this.pc1);
            this.Controls.Add(this.grid);
            this.Name = "GameMasterControl";
            this.Size = new System.Drawing.Size(751, 711);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.UserPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btnSimulate10Turns;
        private System.Windows.Forms.Button btnSimulate1Turn;
    }
}
