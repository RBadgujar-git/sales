namespace sample
{
    partial class PartyReportByItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartyReportByItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbparty = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvPartyReport = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartyReport)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbparty
            // 
            this.cmbparty.BackColor = System.Drawing.Color.Transparent;
            this.cmbparty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbparty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbparty.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbparty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbparty.FocusedState.Parent = this.cmbparty;
            this.cmbparty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbparty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbparty.HoverState.Parent = this.cmbparty;
            this.cmbparty.ItemHeight = 30;
            this.cmbparty.Items.AddRange(new object[] {
            "Party Name"});
            this.cmbparty.ItemsAppearance.Parent = this.cmbparty;
            this.cmbparty.Location = new System.Drawing.Point(78, 39);
            this.cmbparty.Name = "cmbparty";
            this.cmbparty.ShadowDecoration.Parent = this.cmbparty;
            this.cmbparty.Size = new System.Drawing.Size(140, 36);
            this.cmbparty.StartIndex = 0;
            this.cmbparty.TabIndex = 88;
            this.cmbparty.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancel.BackgroundImage")));
            this.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncancel.Location = new System.Drawing.Point(966, 7);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(28, 26);
            this.btncancel.TabIndex = 85;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(890, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 24);
            this.btnPrint.TabIndex = 84;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(846, 38);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(26, 19);
            this.btnImport.TabIndex = 83;
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 90;
            this.label3.Text = "FILTER";
            // 
            // txtSearch1
            // 
            this.txtSearch1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch1.DefaultText = "";
            this.txtSearch1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch1.DisabledState.Parent = this.txtSearch1;
            this.txtSearch1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch1.FocusedState.Parent = this.txtSearch1;
            this.txtSearch1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSearch1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch1.HoverState.Parent = this.txtSearch1;
            this.txtSearch1.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch1.IconLeft")));
            this.txtSearch1.Location = new System.Drawing.Point(289, 43);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.PasswordChar = '\0';
            this.txtSearch1.PlaceholderText = "";
            this.txtSearch1.SelectedText = "";
            this.txtSearch1.ShadowDecoration.Parent = this.txtSearch1;
            this.txtSearch1.Size = new System.Drawing.Size(246, 25);
            this.txtSearch1.TabIndex = 94;
            this.txtSearch1.TextChanged += new System.EventHandler(this.txtSearch1_TextChanged);
            // 
            // dgvPartyReport
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvPartyReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPartyReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartyReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartyReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPartyReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPartyReport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartyReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPartyReport.ColumnHeadersHeight = 18;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartyReport.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPartyReport.EnableHeadersVisualStyles = false;
            this.dgvPartyReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPartyReport.Location = new System.Drawing.Point(3, 90);
            this.dgvPartyReport.Name = "dgvPartyReport";
            this.dgvPartyReport.RowHeadersVisible = false;
            this.dgvPartyReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartyReport.Size = new System.Drawing.Size(991, 480);
            this.dgvPartyReport.TabIndex = 237;
            this.dgvPartyReport.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvPartyReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPartyReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPartyReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPartyReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPartyReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPartyReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPartyReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPartyReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPartyReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPartyReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPartyReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPartyReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPartyReport.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvPartyReport.ThemeStyle.ReadOnly = false;
            this.dgvPartyReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPartyReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPartyReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPartyReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPartyReport.ThemeStyle.RowsStyle.Height = 22;
            this.dgvPartyReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPartyReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // PartyReportByItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvPartyReport);
            this.Controls.Add(this.txtSearch1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbparty);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PartyReportByItem";
            this.Size = new System.Drawing.Size(1000, 570);
            this.Load += new System.EventHandler(this.PartyReportByItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartyReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbparty;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPartyReport;
    }
}
