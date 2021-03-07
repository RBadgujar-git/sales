namespace sample
{
    partial class StockSummary
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
            if (disposing && (components != null)) {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockSummary));
            this.txtTootalStockQty = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtStockvalue = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvStockSummary = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkBalParty = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkdatefilter = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cmbAAllCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTootalStockQty
            // 
            this.txtTootalStockQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTootalStockQty.DefaultText = "";
            this.txtTootalStockQty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTootalStockQty.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTootalStockQty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTootalStockQty.DisabledState.Parent = this.txtTootalStockQty;
            this.txtTootalStockQty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTootalStockQty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTootalStockQty.FocusedState.Parent = this.txtTootalStockQty;
            this.txtTootalStockQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTootalStockQty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTootalStockQty.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTootalStockQty.HoverState.Parent = this.txtTootalStockQty;
            this.txtTootalStockQty.Location = new System.Drawing.Point(595, 13);
            this.txtTootalStockQty.Name = "txtTootalStockQty";
            this.txtTootalStockQty.PasswordChar = '\0';
            this.txtTootalStockQty.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTootalStockQty.PlaceholderText = "0";
            this.txtTootalStockQty.SelectedText = "";
            this.txtTootalStockQty.ShadowDecoration.Parent = this.txtTootalStockQty;
            this.txtTootalStockQty.Size = new System.Drawing.Size(91, 36);
            this.txtTootalStockQty.TabIndex = 70;
            this.txtTootalStockQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total :";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txtTootalStockQty);
            this.guna2Panel1.Controls.Add(this.txtStockvalue);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 475);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(993, 77);
            this.guna2Panel1.TabIndex = 99;
            // 
            // txtStockvalue
            // 
            this.txtStockvalue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStockvalue.DefaultText = "";
            this.txtStockvalue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStockvalue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStockvalue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStockvalue.DisabledState.Parent = this.txtStockvalue;
            this.txtStockvalue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStockvalue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStockvalue.FocusedState.Parent = this.txtStockvalue;
            this.txtStockvalue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStockvalue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtStockvalue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStockvalue.HoverState.Parent = this.txtStockvalue;
            this.txtStockvalue.Location = new System.Drawing.Point(829, 13);
            this.txtStockvalue.Name = "txtStockvalue";
            this.txtStockvalue.PasswordChar = '\0';
            this.txtStockvalue.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtStockvalue.PlaceholderText = "0";
            this.txtStockvalue.SelectedText = "";
            this.txtStockvalue.ShadowDecoration.Parent = this.txtStockvalue;
            this.txtStockvalue.Size = new System.Drawing.Size(91, 36);
            this.txtStockvalue.TabIndex = 69;
            this.txtStockvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvStockSummary
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvStockSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStockSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStockSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStockSummary.ColumnHeadersHeight = 18;
            this.dgvStockSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.StockValue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockSummary.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStockSummary.EnableHeadersVisualStyles = false;
            this.dgvStockSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStockSummary.Location = new System.Drawing.Point(3, 93);
            this.dgvStockSummary.Name = "dgvStockSummary";
            this.dgvStockSummary.RowHeadersVisible = false;
            this.dgvStockSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockSummary.Size = new System.Drawing.Size(977, 377);
            this.dgvStockSummary.TabIndex = 98;
            this.dgvStockSummary.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvStockSummary.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockSummary.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvStockSummary.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvStockSummary.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvStockSummary.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvStockSummary.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockSummary.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStockSummary.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvStockSummary.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStockSummary.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStockSummary.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStockSummary.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvStockSummary.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvStockSummary.ThemeStyle.ReadOnly = false;
            this.dgvStockSummary.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStockSummary.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStockSummary.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStockSummary.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvStockSummary.ThemeStyle.RowsStyle.Height = 22;
            this.dgvStockSummary.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStockSummary.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Sale Price";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Purchase Price";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Stock Qty";
            this.Column6.Name = "Column6";
            // 
            // StockValue
            // 
            this.StockValue.HeaderText = "Stock Value";
            this.StockValue.Name = "StockValue";
            // 
            // chkBalParty
            // 
            this.chkBalParty.AutoSize = true;
            this.chkBalParty.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkBalParty.CheckedState.BorderRadius = 0;
            this.chkBalParty.CheckedState.BorderThickness = 0;
            this.chkBalParty.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkBalParty.Location = new System.Drawing.Point(619, 28);
            this.chkBalParty.Name = "chkBalParty";
            this.chkBalParty.Size = new System.Drawing.Size(99, 20);
            this.chkBalParty.TabIndex = 97;
            this.chkBalParty.Text = "0 Bal Party";
            this.chkBalParty.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkBalParty.UncheckedState.BorderRadius = 0;
            this.chkBalParty.UncheckedState.BorderThickness = 0;
            this.chkBalParty.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkdatefilter
            // 
            this.chkdatefilter.AutoSize = true;
            this.chkdatefilter.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkdatefilter.CheckedState.BorderRadius = 0;
            this.chkdatefilter.CheckedState.BorderThickness = 0;
            this.chkdatefilter.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkdatefilter.Location = new System.Drawing.Point(329, 29);
            this.chkdatefilter.Name = "chkdatefilter";
            this.chkdatefilter.Size = new System.Drawing.Size(96, 20);
            this.chkdatefilter.TabIndex = 96;
            this.chkdatefilter.Text = "Date Filter";
            this.chkdatefilter.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkdatefilter.UncheckedState.BorderRadius = 0;
            this.chkdatefilter.UncheckedState.BorderThickness = 0;
            this.chkdatefilter.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 95;
            this.label1.Text = "FILTER";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(964, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 91;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(909, 26);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(21, 23);
            this.btnPrint.TabIndex = 90;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(870, 26);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(21, 23);
            this.btnImport.TabIndex = 89;
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // cmbAAllCategory
            // 
            this.cmbAAllCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbAAllCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAAllCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAAllCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAAllCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAAllCategory.FocusedState.Parent = this.cmbAAllCategory;
            this.cmbAAllCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAAllCategory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbAAllCategory.HoverState.Parent = this.cmbAAllCategory;
            this.cmbAAllCategory.ItemHeight = 30;
            this.cmbAAllCategory.Items.AddRange(new object[] {
            "All Category"});
            this.cmbAAllCategory.ItemsAppearance.Parent = this.cmbAAllCategory;
            this.cmbAAllCategory.Location = new System.Drawing.Point(139, 21);
            this.cmbAAllCategory.Name = "cmbAAllCategory";
            this.cmbAAllCategory.ShadowDecoration.Parent = this.cmbAAllCategory;
            this.cmbAAllCategory.Size = new System.Drawing.Size(140, 36);
            this.cmbAAllCategory.StartIndex = 0;
            this.cmbAAllCategory.TabIndex = 100;
            // 
            // guna2DateTimePicker2
            // 
            this.guna2DateTimePicker2.CustomFormat = "MM/dd/yyyy";
            this.guna2DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker2.Location = new System.Drawing.Point(428, 28);
            this.guna2DateTimePicker2.Name = "guna2DateTimePicker2";
            this.guna2DateTimePicker2.Size = new System.Drawing.Size(165, 23);
            this.guna2DateTimePicker2.TabIndex = 101;
            // 
            // StockSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2DateTimePicker2);
            this.Controls.Add(this.cmbAAllCategory);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvStockSummary);
            this.Controls.Add(this.chkBalParty);
            this.Controls.Add(this.chkdatefilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StockSummary";
            this.Size = new System.Drawing.Size(993, 552);
            this.Load += new System.EventHandler(this.StockSummary_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTootalStockQty;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtStockvalue;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStockSummary;
        private Guna.UI2.WinForms.Guna2CheckBox chkBalParty;
        private Guna.UI2.WinForms.Guna2CheckBox chkdatefilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockValue;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAAllCategory;
        private System.Windows.Forms.DateTimePicker guna2DateTimePicker2;
    }
}
