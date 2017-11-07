namespace Hotel
{
    partial class GUIBuildProperty
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
            this.btnNone = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.BuildButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ImprovmentLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImrpovmentCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(3, 123);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(347, 23);
            this.btnNone.TabIndex = 3;
            this.btnNone.Text = "Build nothing";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuildButton,
            this.ImprovmentLevel,
            this.PropertyName,
            this.ImrpovmentCost});
            this.grid.Location = new System.Drawing.Point(3, 4);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(347, 113);
            this.grid.TabIndex = 2;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // BuildButton
            // 
            this.BuildButton.HeaderText = "Build";
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.ReadOnly = true;
            this.BuildButton.Width = 40;
            // 
            // ImprovmentLevel
            // 
            this.ImprovmentLevel.HeaderText = "Improv. level";
            this.ImprovmentLevel.Name = "ImprovmentLevel";
            this.ImprovmentLevel.ReadOnly = true;
            this.ImprovmentLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PropertyName
            // 
            this.PropertyName.HeaderText = "ActivePlayerID name";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.ReadOnly = true;
            this.PropertyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ImrpovmentCost
            // 
            this.ImrpovmentCost.HeaderText = "Improv. cost";
            this.ImrpovmentCost.Name = "ImrpovmentCost";
            this.ImrpovmentCost.ReadOnly = true;
            this.ImrpovmentCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GUIBuildProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.grid);
            this.Name = "GUIBuildProperty";
            this.Size = new System.Drawing.Size(356, 150);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewButtonColumn BuildButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImprovmentLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImrpovmentCost;
    }
}
