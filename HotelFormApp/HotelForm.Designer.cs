namespace HotelFormApp
{
    partial class HotelForm
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
            this.gameMasterControl1 = new Hotel.GameMasterControl();
            this.SuspendLayout();
            // 
            // gameMasterControl1
            // 
            this.gameMasterControl1.Location = new System.Drawing.Point(12, 12);
            this.gameMasterControl1.Name = "gameMasterControl1";
            this.gameMasterControl1.Size = new System.Drawing.Size(751, 711);
            this.gameMasterControl1.TabIndex = 0;
            // 
            // HotelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.gameMasterControl1);
            this.Name = "HotelForm";
            this.Text = "Hotel";
            this.Load += new System.EventHandler(this.HotelFor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Hotel.GameMasterControl gameMasterControl1;
    }
}

