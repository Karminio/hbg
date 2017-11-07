namespace HotelTest
{
    partial class HotelTestForm
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
            this.TableControl = new Hotel.GameMasterControl();
            this.SuspendLayout();
            // 
            // TableControl
            // 
            this.TableControl.Location = new System.Drawing.Point(5, 11);
            this.TableControl.Name = "TableControl";
            this.TableControl.Size = new System.Drawing.Size(754, 692);
            this.TableControl.TabIndex = 0;
            // 
            // HotelTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 715);
            this.Controls.Add(this.TableControl);
            this.Name = "HotelTestForm";
            this.Text = "HotelTestForm";
            this.Load += new System.EventHandler(this.HotelTestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Hotel.GameMasterControl TableControl;
    }
}