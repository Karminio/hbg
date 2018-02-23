namespace HotelFormApp
{
    partial class StartingInfo
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxAddedPlayers = new System.Windows.Forms.ListBox();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.btAddPlayer = new System.Windows.Forms.Button();
            this.ckAIPlayer = new System.Windows.Forms.CheckBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnRemovePlayer = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lbColor = new System.Windows.Forms.Label();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxAddedPlayers
            // 
            this.lbxAddedPlayers.FormattingEnabled = true;
            this.lbxAddedPlayers.Location = new System.Drawing.Point(13, 88);
            this.lbxAddedPlayers.MultiColumn = true;
            this.lbxAddedPlayers.Name = "lbxAddedPlayers";
            this.lbxAddedPlayers.Size = new System.Drawing.Size(184, 160);
            this.lbxAddedPlayers.TabIndex = 0;
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(14, 29);
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(125, 20);
            this.tbPlayerName.TabIndex = 1;
            // 
            // btAddPlayer
            // 
            this.btAddPlayer.Location = new System.Drawing.Point(145, 29);
            this.btAddPlayer.Name = "btAddPlayer";
            this.btAddPlayer.Size = new System.Drawing.Size(75, 20);
            this.btAddPlayer.TabIndex = 2;
            this.btAddPlayer.Text = "Add Player";
            this.btAddPlayer.UseVisualStyleBackColor = true;
            this.btAddPlayer.Click += new System.EventHandler(this.btAddPlayer_Click);
            // 
            // ckAIPlayer
            // 
            this.ckAIPlayer.AutoSize = true;
            this.ckAIPlayer.Location = new System.Drawing.Point(18, 62);
            this.ckAIPlayer.Name = "ckAIPlayer";
            this.ckAIPlayer.Size = new System.Drawing.Size(68, 17);
            this.ckAIPlayer.TabIndex = 3;
            this.ckAIPlayer.Text = "AI Player";
            this.ckAIPlayer.UseVisualStyleBackColor = true;
            // 
            // btnStartGame
            // 
            this.btnStartGame.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStartGame.Location = new System.Drawing.Point(203, 225);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(75, 23);
            this.btnStartGame.TabIndex = 4;
            this.btnStartGame.Text = "Start";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnRemovePlayer
            // 
            this.btnRemovePlayer.Location = new System.Drawing.Point(203, 88);
            this.btnRemovePlayer.Name = "btnRemovePlayer";
            this.btnRemovePlayer.Size = new System.Drawing.Size(75, 21);
            this.btnRemovePlayer.TabIndex = 5;
            this.btnRemovePlayer.Text = "Remove";
            this.btnRemovePlayer.UseVisualStyleBackColor = true;
            this.btnRemovePlayer.Click += new System.EventHandler(this.btnRemovePlayer_Click);
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(97, 64);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 6;
            this.lbColor.Text = "Color";
            // 
            // btnPickColor
            // 
            this.btnPickColor.Location = new System.Drawing.Point(134, 59);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(75, 23);
            this.btnPickColor.TabIndex = 7;
            this.btnPickColor.Text = "Pick";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(203, 196);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(203, 115);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // StartingInfo
            // 
            this.AcceptButton = this.btnStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPickColor);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.btnRemovePlayer);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.ckAIPlayer);
            this.Controls.Add(this.btAddPlayer);
            this.Controls.Add(this.tbPlayerName);
            this.Controls.Add(this.lbxAddedPlayers);
            this.Name = "StartingInfo";
            this.Text = "Start new game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAddedPlayers;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.Button btAddPlayer;
        private System.Windows.Forms.CheckBox ckAIPlayer;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnRemovePlayer;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoad;
    }
}