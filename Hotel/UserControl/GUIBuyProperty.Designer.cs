namespace Hotel
{
    partial class GUIBuyProperty
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnNone = new System.Windows.Forms.Button();
            this.BuyButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuyButton,
            this.PropertyName,
            this.Price,
            this.PropertyOwner});
            this.grid.Location = new System.Drawing.Point(3, 3);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(295, 113);
            this.grid.TabIndex = 0;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(3, 122);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(295, 23);
            this.btnNone.TabIndex = 1;
            this.btnNone.Text = "Buy nothing";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // BuyButton
            // 
            this.BuyButton.HeaderText = "Buy";
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.ReadOnly = true;
            this.BuyButton.Width = 40;
            // 
            // PropertyName
            // 
            this.PropertyName.HeaderText = "ActivePlayerID name";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.ReadOnly = true;
            this.PropertyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 70;
            // 
            // PropertyOwner
            // 
            this.PropertyOwner.HeaderText = "Owner";
            this.PropertyOwner.Name = "PropertyOwner";
            this.PropertyOwner.ReadOnly = true;
            this.PropertyOwner.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyOwner.Width = 70;
            // 
            // GUIBuyProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.grid);
            this.Name = "GUIBuyProperty";
            this.Size = new System.Drawing.Size(300, 150);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.DataGridViewButtonColumn BuyButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyOwner;
    }
}
