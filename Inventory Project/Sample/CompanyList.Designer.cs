﻿namespace sample
{
    partial class CompanyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvCompanylist = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnnewcompany = new System.Windows.Forms.Button();
            this.btnrestore = new System.Windows.Forms.Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanylist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(48, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company List";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Controls.Add(this.button3);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(983, 49);
            this.guna2Panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(936, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 29);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvCompanylist
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCompanylist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompanylist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompanylist.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompanylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompanylist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCompanylist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanylist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompanylist.ColumnHeadersHeight = 18;
            this.dgvCompanylist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompanylist.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCompanylist.EnableHeadersVisualStyles = false;
            this.dgvCompanylist.GridColor = System.Drawing.Color.Black;
            this.dgvCompanylist.Location = new System.Drawing.Point(37, 138);
            this.dgvCompanylist.Name = "dgvCompanylist";
            this.dgvCompanylist.RowHeadersVisible = false;
            this.dgvCompanylist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompanylist.Size = new System.Drawing.Size(833, 326);
            this.dgvCompanylist.TabIndex = 2;
            this.dgvCompanylist.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvCompanylist.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCompanylist.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCompanylist.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCompanylist.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCompanylist.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCompanylist.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCompanylist.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvCompanylist.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCompanylist.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompanylist.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCompanylist.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCompanylist.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCompanylist.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvCompanylist.ThemeStyle.ReadOnly = false;
            this.dgvCompanylist.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCompanylist.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCompanylist.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCompanylist.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCompanylist.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCompanylist.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCompanylist.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCompanylist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanylist_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Business Name";
            this.Column1.Name = "Column1";
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(37, 93);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(246, 27);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnnewcompany
            // 
            this.btnnewcompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnnewcompany.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnewcompany.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnnewcompany.Location = new System.Drawing.Point(626, 485);
            this.btnnewcompany.Name = "btnnewcompany";
            this.btnnewcompany.Size = new System.Drawing.Size(118, 42);
            this.btnnewcompany.TabIndex = 11;
            this.btnnewcompany.Text = "New Company";
            this.btnnewcompany.UseVisualStyleBackColor = false;
            this.btnnewcompany.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnrestore
            // 
            this.btnrestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnrestore.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrestore.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnrestore.Location = new System.Drawing.Point(475, 485);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(118, 42);
            this.btnrestore.TabIndex = 12;
            this.btnrestore.Text = "Restore Backup";
            this.btnrestore.UseVisualStyleBackColor = false;
            this.btnrestore.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnrestore);
            this.Controls.Add(this.btnnewcompany);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvCompanylist);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CompanyList";
            this.Size = new System.Drawing.Size(983, 554);
            this.Load += new System.EventHandler(this.CompanyList_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCompanylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Button btnnewcompany;
        private System.Windows.Forms.Button btnrestore;
        private System.Windows.Forms.Button button3;
    }
}
