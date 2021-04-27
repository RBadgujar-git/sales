namespace sample
{
    partial class TaxReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxReport));
            this.txtAmountPurchase = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAmountSale = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTaxReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmbAllFirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnminimize = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxReport)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmountPurchase
            // 
            this.txtAmountPurchase.BorderColor = System.Drawing.Color.Gray;
            this.txtAmountPurchase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmountPurchase.DefaultText = "";
            this.txtAmountPurchase.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmountPurchase.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmountPurchase.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountPurchase.DisabledState.Parent = this.txtAmountPurchase;
            this.txtAmountPurchase.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountPurchase.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountPurchase.FocusedState.Parent = this.txtAmountPurchase;
            this.txtAmountPurchase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAmountPurchase.ForeColor = System.Drawing.Color.Black;
            this.txtAmountPurchase.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountPurchase.HoverState.Parent = this.txtAmountPurchase;
            this.txtAmountPurchase.Location = new System.Drawing.Point(753, 3);
            this.txtAmountPurchase.Name = "txtAmountPurchase";
            this.txtAmountPurchase.PasswordChar = '\0';
            this.txtAmountPurchase.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtAmountPurchase.PlaceholderText = "0";
            this.txtAmountPurchase.SelectedText = "";
            this.txtAmountPurchase.ShadowDecoration.Parent = this.txtAmountPurchase;
            this.txtAmountPurchase.Size = new System.Drawing.Size(159, 36);
            this.txtAmountPurchase.TabIndex = 136;
            this.txtAmountPurchase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmountSale
            // 
            this.txtAmountSale.BorderColor = System.Drawing.Color.Gray;
            this.txtAmountSale.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmountSale.DefaultText = "";
            this.txtAmountSale.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmountSale.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmountSale.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountSale.DisabledState.Parent = this.txtAmountSale;
            this.txtAmountSale.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountSale.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountSale.FocusedState.Parent = this.txtAmountSale;
            this.txtAmountSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAmountSale.ForeColor = System.Drawing.Color.Black;
            this.txtAmountSale.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountSale.HoverState.Parent = this.txtAmountSale;
            this.txtAmountSale.Location = new System.Drawing.Point(251, 3);
            this.txtAmountSale.Name = "txtAmountSale";
            this.txtAmountSale.PasswordChar = '\0';
            this.txtAmountSale.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtAmountSale.PlaceholderText = "0";
            this.txtAmountSale.SelectedText = "";
            this.txtAmountSale.ShadowDecoration.Parent = this.txtAmountSale;
            this.txtAmountSale.Size = new System.Drawing.Size(159, 36);
            this.txtAmountSale.TabIndex = 134;
            this.txtAmountSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txtAmountPurchase);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.txtAmountSale);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 515);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1052, 53);
            this.guna2Panel1.TabIndex = 155;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 16);
            this.label2.TabIndex = 135;
            this.label2.Text = "Tax Amount for Purchase :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 133;
            this.label1.Text = "Tax Amount for Sale :";
            // 
            // dgvTaxReport
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dgvTaxReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvTaxReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaxReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaxReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaxReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaxReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaxReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvTaxReport.ColumnHeadersHeight = 18;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaxReport.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvTaxReport.EnableHeadersVisualStyles = false;
            this.dgvTaxReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaxReport.Location = new System.Drawing.Point(6, 104);
            this.dgvTaxReport.Name = "dgvTaxReport";
            this.dgvTaxReport.RowHeadersVisible = false;
            this.dgvTaxReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaxReport.Size = new System.Drawing.Size(1013, 407);
            this.dgvTaxReport.TabIndex = 154;
            this.dgvTaxReport.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvTaxReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaxReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTaxReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTaxReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTaxReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTaxReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaxReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaxReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTaxReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTaxReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTaxReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTaxReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTaxReport.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvTaxReport.ThemeStyle.ReadOnly = false;
            this.dgvTaxReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaxReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaxReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTaxReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTaxReport.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTaxReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaxReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTaxReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaxReport_CellContentClick);
            // 
            // cmbAllFirms
            // 
            this.cmbAllFirms.BackColor = System.Drawing.Color.Transparent;
            this.cmbAllFirms.BorderColor = System.Drawing.Color.Gray;
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
            this.cmbAllFirms.Location = new System.Drawing.Point(33, 21);
            this.cmbAllFirms.Name = "cmbAllFirms";
            this.cmbAllFirms.ShadowDecoration.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAllFirms.StartIndex = 0;
            this.cmbAllFirms.TabIndex = 153;
            this.cmbAllFirms.SelectedIndexChanged += new System.EventHandler(this.cmbAllFirms_SelectedIndexChanged);
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
            this.btnminimize.Location = new System.Drawing.Point(923, 3);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 446;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(996, 4);
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
            this.btnPrint.Location = new System.Drawing.Point(994, 41);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 25);
            this.btnPrint.TabIndex = 147;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(846, 34);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(22, 23);
            this.btnImport.TabIndex = 146;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(993, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 447;
            this.label3.Text = "Print";
            // 
            // txtfilter
            // 
            this.txtfilter.BorderColor = System.Drawing.Color.Gray;
            this.txtfilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfilter.DefaultText = "";
            this.txtfilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtfilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtfilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfilter.DisabledState.Parent = this.txtfilter;
            this.txtfilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfilter.FocusedState.Parent = this.txtfilter;
            this.txtfilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtfilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtfilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfilter.HoverState.Parent = this.txtfilter;
            this.txtfilter.Location = new System.Drawing.Point(320, 28);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.PasswordChar = '\0';
            this.txtfilter.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtfilter.PlaceholderText = "Party Name";
            this.txtfilter.SelectedText = "";
            this.txtfilter.ShadowDecoration.Parent = this.txtfilter;
            this.txtfilter.Size = new System.Drawing.Size(163, 27);
            this.txtfilter.TabIndex = 448;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 449;
            this.label4.Text = " Filter by :";
            // 
            // TaxReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvTaxReport);
            this.Controls.Add(this.cmbAllFirms);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaxReport";
            this.Size = new System.Drawing.Size(1052, 568);
            this.Load += new System.EventHandler(this.TaxReport_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtAmountPurchase;
        private Guna.UI2.WinForms.Guna2TextBox txtAmountSale;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTaxReport;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAllFirms;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtfilter;
        private System.Windows.Forms.Label label4;
    }
}
