namespace sample
{
    partial class LoanStatementReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanStatementReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAllLoanStat = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbloanbank = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txttotalRecieve = new Guna.UI2.WinForms.Guna2TextBox();
            this.txttotalPayable = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLoanStat)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.dgvAllLoanStat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbloanbank);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnimport);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 568);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgvAllLoanStat
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAllLoanStat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllLoanStat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllLoanStat.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllLoanStat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAllLoanStat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllLoanStat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllLoanStat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllLoanStat.ColumnHeadersHeight = 18;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllLoanStat.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllLoanStat.EnableHeadersVisualStyles = false;
            this.dgvAllLoanStat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllLoanStat.Location = new System.Drawing.Point(4, 81);
            this.dgvAllLoanStat.Name = "dgvAllLoanStat";
            this.dgvAllLoanStat.RowHeadersVisible = false;
            this.dgvAllLoanStat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllLoanStat.Size = new System.Drawing.Size(989, 362);
            this.dgvAllLoanStat.TabIndex = 93;
            this.dgvAllLoanStat.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvAllLoanStat.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllLoanStat.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAllLoanStat.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAllLoanStat.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvAllLoanStat.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvAllLoanStat.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllLoanStat.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllLoanStat.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvAllLoanStat.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAllLoanStat.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllLoanStat.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAllLoanStat.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvAllLoanStat.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvAllLoanStat.ThemeStyle.ReadOnly = false;
            this.dgvAllLoanStat.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllLoanStat.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllLoanStat.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllLoanStat.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAllLoanStat.ThemeStyle.RowsStyle.Height = 22;
            this.dgvAllLoanStat.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllLoanStat.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "FILTER";
            // 
            // cmbloanbank
            // 
            this.cmbloanbank.BackColor = System.Drawing.Color.Transparent;
            this.cmbloanbank.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbloanbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbloanbank.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbloanbank.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbloanbank.FocusedState.Parent = this.cmbloanbank;
            this.cmbloanbank.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbloanbank.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbloanbank.HoverState.Parent = this.cmbloanbank;
            this.cmbloanbank.ItemHeight = 30;
            this.cmbloanbank.Items.AddRange(new object[] {
            "All Parties"});
            this.cmbloanbank.ItemsAppearance.Parent = this.cmbloanbank;
            this.cmbloanbank.Location = new System.Drawing.Point(75, 20);
            this.cmbloanbank.Name = "cmbloanbank";
            this.cmbloanbank.ShadowDecoration.Parent = this.cmbloanbank;
            this.cmbloanbank.Size = new System.Drawing.Size(140, 36);
            this.cmbloanbank.StartIndex = 0;
            this.cmbloanbank.TabIndex = 89;
            this.cmbloanbank.SelectedIndexChanged += new System.EventHandler(this.cmbloanbank_SelectedIndexChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(918, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(22, 28);
            this.btnPrint.TabIndex = 91;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(878, 25);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(20, 20);
            this.btnimport.TabIndex = 90;
            this.btnimport.UseVisualStyleBackColor = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txttotalRecieve);
            this.guna2Panel1.Controls.Add(this.txttotalPayable);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 493);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(999, 75);
            this.guna2Panel1.TabIndex = 94;
            // 
            // txttotalRecieve
            // 
            this.txttotalRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalRecieve.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalRecieve.DefaultText = "";
            this.txttotalRecieve.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotalRecieve.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotalRecieve.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalRecieve.DisabledState.Parent = this.txttotalRecieve;
            this.txttotalRecieve.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalRecieve.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalRecieve.FocusedState.Parent = this.txttotalRecieve;
            this.txttotalRecieve.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotalRecieve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttotalRecieve.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalRecieve.HoverState.Parent = this.txttotalRecieve;
            this.txttotalRecieve.Location = new System.Drawing.Point(593, 11);
            this.txttotalRecieve.Name = "txttotalRecieve";
            this.txttotalRecieve.PasswordChar = '\0';
            this.txttotalRecieve.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttotalRecieve.PlaceholderText = "0";
            this.txttotalRecieve.SelectedText = "";
            this.txttotalRecieve.ShadowDecoration.Parent = this.txttotalRecieve;
            this.txttotalRecieve.Size = new System.Drawing.Size(91, 36);
            this.txttotalRecieve.TabIndex = 78;
            this.txttotalRecieve.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttotalPayable
            // 
            this.txttotalPayable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalPayable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalPayable.DefaultText = "";
            this.txttotalPayable.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotalPayable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotalPayable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalPayable.DisabledState.Parent = this.txttotalPayable;
            this.txttotalPayable.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalPayable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalPayable.FocusedState.Parent = this.txttotalPayable;
            this.txttotalPayable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotalPayable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttotalPayable.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalPayable.HoverState.Parent = this.txttotalPayable;
            this.txttotalPayable.Location = new System.Drawing.Point(812, 13);
            this.txttotalPayable.Name = "txttotalPayable";
            this.txttotalPayable.PasswordChar = '\0';
            this.txttotalPayable.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttotalPayable.PlaceholderText = "0";
            this.txttotalPayable.SelectedText = "";
            this.txttotalPayable.ShadowDecoration.Parent = this.txttotalPayable;
            this.txttotalPayable.Size = new System.Drawing.Size(91, 36);
            this.txttotalPayable.TabIndex = 69;
            this.txttotalPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total :";
            // 
            // LoanStatementReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LoanStatementReport";
            this.Size = new System.Drawing.Size(999, 568);
            this.Load += new System.EventHandler(this.LoanStatementReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLoanStat)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAllLoanStat;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbloanbank;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnimport;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txttotalRecieve;
        private Guna.UI2.WinForms.Guna2TextBox txttotalPayable;
        private System.Windows.Forms.Label label2;
    }
}
