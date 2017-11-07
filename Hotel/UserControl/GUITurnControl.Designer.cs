namespace Hotel
{
    partial class GUITurnControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnForceAP = new System.Windows.Forms.Button();
            this.Dice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRoll = new System.Windows.Forms.Button();
            this.txtActivePlayer = new System.Windows.Forms.TextBox();
            this.btReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btReset);
            this.groupBox1.Controls.Add(this.btnEndTurn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnForceAP);
            this.groupBox1.Controls.Add(this.Dice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRoll);
            this.groupBox1.Controls.Add(this.txtActivePlayer);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 126);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(118, 73);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(81, 20);
            this.btnEndTurn.TabIndex = 14;
            this.btnEndTurn.Text = "End turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Dice value";
            // 
            // btnForceAP
            // 
            this.btnForceAP.Location = new System.Drawing.Point(118, 21);
            this.btnForceAP.Name = "btnForceAP";
            this.btnForceAP.Size = new System.Drawing.Size(81, 20);
            this.btnForceAP.TabIndex = 12;
            this.btnForceAP.Text = "Force player";
            this.btnForceAP.UseVisualStyleBackColor = true;
            this.btnForceAP.Click += new System.EventHandler(this.btnForceAP_Click);
            // 
            // Dice
            // 
            this.Dice.Location = new System.Drawing.Point(74, 47);
            this.Dice.Name = "Dice";
            this.Dice.Size = new System.Drawing.Size(38, 20);
            this.Dice.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Act. player";
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(118, 47);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(81, 20);
            this.btnRoll.TabIndex = 9;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // txtActivePlayer
            // 
            this.txtActivePlayer.Location = new System.Drawing.Point(74, 21);
            this.txtActivePlayer.Name = "txtActivePlayer";
            this.txtActivePlayer.Size = new System.Drawing.Size(38, 20);
            this.txtActivePlayer.TabIndex = 7;
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(118, 100);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(81, 23);
            this.btReset.TabIndex = 15;
            this.btReset.Text = "Reset all";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // GUITurnControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "GUITurnControl";
            this.Size = new System.Drawing.Size(212, 132);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnForceAP;
        private System.Windows.Forms.TextBox Dice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.TextBox txtActivePlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Button btReset;
    }
}
