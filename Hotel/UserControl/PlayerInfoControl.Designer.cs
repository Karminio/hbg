namespace Hotel
{
    partial class PlayerInfoControl
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
            this.PlayerTitle = new System.Windows.Forms.GroupBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrPos = new System.Windows.Forms.TextBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerTitle
            // 
            this.PlayerTitle.Controls.Add(this.chkActive);
            this.PlayerTitle.Controls.Add(this.label3);
            this.PlayerTitle.Controls.Add(this.txtCurrPos);
            this.PlayerTitle.Controls.Add(this.txtMoney);
            this.PlayerTitle.Controls.Add(this.label2);
            this.PlayerTitle.Location = new System.Drawing.Point(3, 3);
            this.PlayerTitle.Name = "PlayerTitle";
            this.PlayerTitle.Size = new System.Drawing.Size(253, 76);
            this.PlayerTitle.TabIndex = 7;
            this.PlayerTitle.TabStop = false;
            this.PlayerTitle.Text = "Player Control";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Enabled = false;
            this.chkActive.Location = new System.Drawing.Point(106, 44);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 13;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pos.";
            // 
            // txtCurrPos
            // 
            this.txtCurrPos.Location = new System.Drawing.Point(58, 42);
            this.txtCurrPos.Name = "txtCurrPos";
            this.txtCurrPos.ReadOnly = true;
            this.txtCurrPos.Size = new System.Drawing.Size(42, 20);
            this.txtCurrPos.TabIndex = 11;
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(58, 19);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(100, 20);
            this.txtMoney.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Money";
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayerTitle);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(263, 84);
            this.PlayerTitle.ResumeLayout(false);
            this.PlayerTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PlayerTitle;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrPos;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label2;

    }
}
