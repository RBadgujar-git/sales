﻿namespace sample
{
    partial class ExpenseCategoryReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseCategoryReport));
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTotalExpenses = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvExpensecategory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbAllfirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnminimize = new System.Windows.Forms.Button();
            this.txtfilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpensecategory)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(256, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 166;
            this.label3.Text = "Filter By :";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txtTotalExpenses);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 516);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1009, 53);
            this.guna2Panel1.TabIndex = 177;
            // 
            // txtTotalExpenses
            // 
            this.txtTotalExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalExpenses.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTotalExpenses.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalExpenses.DefaultText = "";
            this.txtTotalExpenses.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalExpenses.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalExpenses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalExpenses.DisabledState.Parent = this.txtTotalExpenses;
            this.txtTotalExpenses.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalExpenses.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalExpenses.FocusedState.Parent = this.txtTotalExpenses;
            this.txtTotalExpenses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalExpenses.ForeColor = System.Drawing.Color.Black;
            this.txtTotalExpenses.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalExpenses.HoverState.Parent = this.txtTotalExpenses;
            this.txtTotalExpenses.Location = new System.Drawing.Point(686, 11);
            this.txtTotalExpenses.Name = "txtTotalExpenses";
            this.txtTotalExpenses.PasswordChar = '\0';
            this.txtTotalExpenses.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTotalExpenses.PlaceholderText = "0";
            this.txtTotalExpenses.SelectedText = "";
            this.txtTotalExpenses.ShadowDecoration.Parent = this.txtTotalExpenses;
            this.txtTotalExpenses.Size = new System.Drawing.Size(200, 36);
            this.txtTotalExpenses.TabIndex = 136;
            this.txtTotalExpenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(687, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 135;
            this.label2.Text = "Total Expense :";
            // 
            // dgvExpensecategory
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvExpensecategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExpensecategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpensecategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpensecategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpensecategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpensecategory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvExpensecategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpensecategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExpensecategory.ColumnHeadersHeight = 18;
            this.dgvExpensecategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpensecategory.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExpensecategory.EnableHeadersVisualStyles = false;
            this.dgvExpensecategory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvExpensecategory.Location = new System.Drawing.Point(5, 106);
            this.dgvExpensecategory.Name = "dgvExpensecategory";
            this.dgvExpensecategory.RowHeadersVisible = false;
            this.dgvExpensecategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpensecategory.Size = new System.Drawing.Size(996, 400);
            this.dgvExpensecategory.TabIndex = 176;
            this.dgvExpensecategory.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvExpensecategory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvExpensecategory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvExpensecategory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvExpensecategory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvExpensecategory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvExpensecategory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvExpensecategory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvExpensecategory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvExpensecategory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpensecategory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExpensecategory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvExpensecategory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvExpensecategory.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvExpensecategory.ThemeStyle.ReadOnly = false;
            this.dgvExpensecategory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvExpensecategory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvExpensecategory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExpensecategory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvExpensecategory.ThemeStyle.RowsStyle.Height = 22;
            this.dgvExpensecategory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvExpensecategory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvExpensecategory.TabIndexChanged += new System.EventHandler(this.dgvExpensecategory_TabIndexChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Expense Category";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Paid Amount";
            this.Column2.Name = "Column2";
            // 
            // cmbAllfirms
            // 
            this.cmbAllfirms.BackColor = System.Drawing.Color.Transparent;
            this.cmbAllfirms.BorderColor = System.Drawing.Color.Gray;
            this.cmbAllfirms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAllfirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllfirms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllfirms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllfirms.FocusedState.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllfirms.ForeColor = System.Drawing.Color.Blue;
            this.cmbAllfirms.HoverState.Parent = this.cmbAllfirms;
            this.cmbAllfirms.ItemHeight = 30;
            this.cmbAllfirms.Items.AddRange(new object[] {
            "All Firms"});
            this.cmbAllfirms.ItemsAppearance.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Location = new System.Drawing.Point(51, 18);
            this.cmbAllfirms.Name = "cmbAllfirms";
            this.cmbAllfirms.ShadowDecoration.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAllfirms.StartIndex = 0;
            this.cmbAllfirms.TabIndex = 175;
            this.cmbAllfirms.SelectedIndexChanged += new System.EventHandler(this.cmbAllfirms_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(949, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 170;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(864, 31);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(22, 23);
            this.btnimport.TabIndex = 168;
            this.btnimport.UseVisualStyleBackColor = false;
            this.btnimport.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(867, 40);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 23);
            this.btnPrint.TabIndex = 169;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnminimize.Location = new System.Drawing.Point(860, 3);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 440;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // txtfilter
            // 
            this.txtfilter.BorderColor = System.Drawing.Color.DarkGray;
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
            this.txtfilter.Location = new System.Drawing.Point(341, 23);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.PasswordChar = '\0';
            this.txtfilter.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtfilter.PlaceholderText = "Expense Category";
            this.txtfilter.SelectedText = "";
            this.txtfilter.ShadowDecoration.Parent = this.txtfilter;
            this.txtfilter.Size = new System.Drawing.Size(182, 27);
            this.txtfilter.TabIndex = 441;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1002, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 442;
            this.label1.Text = "Print";
            // 
            // ExpenseCategoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvExpensecategory);
            this.Controls.Add(this.cmbAllfirms);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExpenseCategoryReport";
            this.Size = new System.Drawing.Size(1009, 569);
            this.Load += new System.EventHandler(this.ExpenseCategoryReport_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpensecategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalExpenses;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvExpensecategory;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAllfirms;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnminimize;
        private Guna.UI2.WinForms.Guna2TextBox txtfilter;
        private System.Windows.Forms.Label label1;
    }
}
