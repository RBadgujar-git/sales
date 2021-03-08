namespace sample
{
    partial class TaxRateReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxRateReport));
            this.txtTaxOut = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTotalTaxIn = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTaxRate = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbAllFirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnnImport = new System.Windows.Forms.Button();
            this.dtpFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxRate)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTaxOut
            // 
            this.txtTaxOut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaxOut.DefaultText = "";
            this.txtTaxOut.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTaxOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTaxOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaxOut.DisabledState.Parent = this.txtTaxOut;
            this.txtTaxOut.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaxOut.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaxOut.FocusedState.Parent = this.txtTaxOut;
            this.txtTaxOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTaxOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTaxOut.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaxOut.HoverState.Parent = this.txtTaxOut;
            this.txtTaxOut.Location = new System.Drawing.Point(783, 3);
            this.txtTaxOut.Name = "txtTaxOut";
            this.txtTaxOut.PasswordChar = '\0';
            this.txtTaxOut.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTaxOut.PlaceholderText = "0";
            this.txtTaxOut.SelectedText = "";
            this.txtTaxOut.ShadowDecoration.Parent = this.txtTaxOut;
            this.txtTaxOut.Size = new System.Drawing.Size(200, 36);
            this.txtTaxOut.TabIndex = 136;
            this.txtTaxOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalTaxIn
            // 
            this.txtTotalTaxIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalTaxIn.DefaultText = "";
            this.txtTotalTaxIn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalTaxIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalTaxIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalTaxIn.DisabledState.Parent = this.txtTotalTaxIn;
            this.txtTotalTaxIn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalTaxIn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalTaxIn.FocusedState.Parent = this.txtTotalTaxIn;
            this.txtTotalTaxIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalTaxIn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalTaxIn.HoverState.Parent = this.txtTotalTaxIn;
            this.txtTotalTaxIn.Location = new System.Drawing.Point(316, 3);
            this.txtTotalTaxIn.Name = "txtTotalTaxIn";
            this.txtTotalTaxIn.PasswordChar = '\0';
            this.txtTotalTaxIn.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTotalTaxIn.PlaceholderText = "0";
            this.txtTotalTaxIn.SelectedText = "";
            this.txtTotalTaxIn.ShadowDecoration.Parent = this.txtTotalTaxIn;
            this.txtTotalTaxIn.Size = new System.Drawing.Size(200, 36);
            this.txtTotalTaxIn.TabIndex = 134;
            this.txtTotalTaxIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txtTaxOut);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.txtTotalTaxIn);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 504);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1005, 53);
            this.guna2Panel1.TabIndex = 155;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(668, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 135;
            this.label2.Text = "Total Tax Out :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 133;
            this.label1.Text = "Total Tax In :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvTaxRate
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTaxRate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaxRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaxRate.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaxRate.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaxRate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaxRate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaxRate.ColumnHeadersHeight = 18;
            this.dgvTaxRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Tax});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaxRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTaxRate.EnableHeadersVisualStyles = false;
            this.dgvTaxRate.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaxRate.Location = new System.Drawing.Point(3, 88);
            this.dgvTaxRate.Name = "dgvTaxRate";
            this.dgvTaxRate.RowHeadersVisible = false;
            this.dgvTaxRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaxRate.Size = new System.Drawing.Size(996, 421);
            this.dgvTaxRate.TabIndex = 154;
            this.dgvTaxRate.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvTaxRate.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaxRate.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTaxRate.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTaxRate.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTaxRate.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTaxRate.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaxRate.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaxRate.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTaxRate.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTaxRate.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTaxRate.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTaxRate.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTaxRate.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvTaxRate.ThemeStyle.ReadOnly = false;
            this.dgvTaxRate.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaxRate.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaxRate.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTaxRate.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTaxRate.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTaxRate.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaxRate.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTaxRate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaxRate_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tax Type";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tax Percent";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Taxable Sale Amount";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tax In";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Taxable Purchase Amount";
            this.Column3.Name = "Column3";
            // 
            // Tax
            // 
            this.Tax.HeaderText = "Tax Out";
            this.Tax.Name = "Tax";
            // 
            // cmbAllFirms
            // 
            this.cmbAllFirms.BackColor = System.Drawing.Color.Transparent;
            this.cmbAllFirms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAllFirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllFirms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllFirms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllFirms.FocusedState.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllFirms.ForeColor = System.Drawing.Color.Blue;
            this.cmbAllFirms.HoverState.Parent = this.cmbAllFirms;
            this.cmbAllFirms.ItemHeight = 30;
            this.cmbAllFirms.Items.AddRange(new object[] {
            "All Firms"});
            this.cmbAllFirms.ItemsAppearance.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Location = new System.Drawing.Point(49, 21);
            this.cmbAllFirms.Name = "cmbAllFirms";
            this.cmbAllFirms.ShadowDecoration.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAllFirms.StartIndex = 0;
            this.cmbAllFirms.TabIndex = 153;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 152;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 150;
            this.label6.Text = "From";
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
            this.btnCancel.Location = new System.Drawing.Point(971, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 148;
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
            this.btnPrint.Location = new System.Drawing.Point(906, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 23);
            this.btnPrint.TabIndex = 147;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnnImport
            // 
            this.btnnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnnImport.BackgroundImage")));
            this.btnnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnnImport.FlatAppearance.BorderSize = 0;
            this.btnnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnImport.Location = new System.Drawing.Point(862, 34);
            this.btnnImport.Name = "btnnImport";
            this.btnnImport.Size = new System.Drawing.Size(22, 23);
            this.btnnImport.TabIndex = 146;
            this.btnnImport.UseVisualStyleBackColor = false;
            // 
            // dtpFromdate
            // 
            this.dtpFromdate.CustomFormat = "MM/dd/yyyy";
            this.dtpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromdate.Location = new System.Drawing.Point(246, 24);
            this.dtpFromdate.Name = "dtpFromdate";
            this.dtpFromdate.Size = new System.Drawing.Size(133, 23);
            this.dtpFromdate.TabIndex = 156;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM/dd/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(433, 24);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(127, 23);
            this.dtpToDate.TabIndex = 157;
            // 
            // TaxRateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromdate);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvTaxRate);
            this.Controls.Add(this.cmbAllFirms);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnnImport);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaxRateReport";
            this.Size = new System.Drawing.Size(1005, 557);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTaxOut;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalTaxIn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTaxRate;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAllFirms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DateTimePicker dtpFromdate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
    }
}
