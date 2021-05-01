namespace sample
{
    partial class SalePurchaseReportbyItemCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalePurchaseReportbyItemCategory));
            this.dgvSalepurchaseReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPartyName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAllFirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.btnminimize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalepurchaseReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalepurchaseReport
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSalepurchaseReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalepurchaseReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalepurchaseReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalepurchaseReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalepurchaseReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalepurchaseReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalepurchaseReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalepurchaseReport.ColumnHeadersHeight = 34;
            this.dgvSalepurchaseReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalepurchaseReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalepurchaseReport.EnableHeadersVisualStyles = false;
            this.dgvSalepurchaseReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalepurchaseReport.Location = new System.Drawing.Point(20, 150);
            this.dgvSalepurchaseReport.Name = "dgvSalepurchaseReport";
            this.dgvSalepurchaseReport.RowHeadersVisible = false;
            this.dgvSalepurchaseReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalepurchaseReport.Size = new System.Drawing.Size(954, 408);
            this.dgvSalepurchaseReport.TabIndex = 112;
            this.dgvSalepurchaseReport.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvSalepurchaseReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalepurchaseReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSalepurchaseReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSalepurchaseReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSalepurchaseReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSalepurchaseReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalepurchaseReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalepurchaseReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSalepurchaseReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSalepurchaseReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalepurchaseReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSalepurchaseReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSalepurchaseReport.ThemeStyle.HeaderStyle.Height = 34;
            this.dgvSalepurchaseReport.ThemeStyle.ReadOnly = false;
            this.dgvSalepurchaseReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSalepurchaseReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSalepurchaseReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalepurchaseReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSalepurchaseReport.ThemeStyle.RowsStyle.Height = 22;
            this.dgvSalepurchaseReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSalepurchaseReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item Category";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Sale Qty";
            this.Column2.Name = "Column2";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Total Sale Amount";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Purchase Qty";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Total Purchase Amount";
            this.Column7.Name = "Column7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 111;
            this.label3.Text = "Party Name :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbPartyName
            // 
            this.cmbPartyName.BackColor = System.Drawing.Color.Transparent;
            this.cmbPartyName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPartyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartyName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPartyName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbPartyName.FocusedState.Parent = this.cmbPartyName;
            this.cmbPartyName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPartyName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbPartyName.HoverState.Parent = this.cmbPartyName;
            this.cmbPartyName.ItemHeight = 30;
            this.cmbPartyName.ItemsAppearance.Parent = this.cmbPartyName;
            this.cmbPartyName.Location = new System.Drawing.Point(164, 93);
            this.cmbPartyName.Name = "cmbPartyName";
            this.cmbPartyName.ShadowDecoration.Parent = this.cmbPartyName;
            this.cmbPartyName.Size = new System.Drawing.Size(221, 36);
            this.cmbPartyName.TabIndex = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 109;
            this.label2.Text = "To";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(946, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 107;
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
            this.btnPrint.Location = new System.Drawing.Point(881, 32);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 21);
            this.btnPrint.TabIndex = 106;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnimport
            // 
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(837, 32);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(26, 21);
            this.btnimport.TabIndex = 105;
            this.btnimport.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 104;
            this.label1.Text = "From";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.cmbAllFirms.Location = new System.Drawing.Point(64, 33);
            this.cmbAllFirms.Name = "cmbAllFirms";
            this.cmbAllFirms.ShadowDecoration.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAllFirms.StartIndex = 0;
            this.cmbAllFirms.TabIndex = 113;
            // 
            // dtpFromdate
            // 
            this.dtpFromdate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromdate.Location = new System.Drawing.Point(294, 33);
            this.dtpFromdate.Name = "dtpFromdate";
            this.dtpFromdate.Size = new System.Drawing.Size(154, 23);
            this.dtpFromdate.TabIndex = 114;
            // 
            // dtpTodate
            // 
            this.dtpTodate.CustomFormat = "dd-MM-yyyy";
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTodate.Location = new System.Drawing.Point(515, 32);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(174, 23);
            this.dtpTodate.TabIndex = 115;
            this.dtpTodate.ValueChanged += new System.EventHandler(this.dtpTodate_ValueChanged);
            // 
            // btnminimize
            // 
            this.btnminimize.BackColor = System.Drawing.Color.White;
            this.btnminimize.BackgroundImage = global::sample.Properties.Resources.MinimizeNew;
            this.btnminimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnminimize.FlatAppearance.BorderSize = 0;
            this.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminimize.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnminimize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnminimize.Location = new System.Drawing.Point(914, 1);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 447;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // SalePurchaseReportbyItemCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtpTodate);
            this.Controls.Add(this.dtpFromdate);
            this.Controls.Add(this.cmbAllFirms);
            this.Controls.Add(this.dgvSalepurchaseReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPartyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SalePurchaseReportbyItemCategory";
            this.Size = new System.Drawing.Size(984, 569);
            this.Load += new System.EventHandler(this.SalePurchaseReportbyItemCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalepurchaseReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvSalepurchaseReport;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPartyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAllFirms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DateTimePicker dtpFromdate;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.Button btnminimize;
    }
}
