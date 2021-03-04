﻿namespace sample
{
    partial class SaleInvoiceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleInvoiceReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbThisMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtPaid = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtUnpaid = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtOverDue = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.dgvsaleInvoice = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddSale = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbFirm = new System.Windows.Forms.ComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsaleInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbThisMonth
            // 
            this.cmbThisMonth.BackColor = System.Drawing.Color.Transparent;
            this.cmbThisMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbThisMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThisMonth.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbThisMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbThisMonth.FocusedState.Parent = this.cmbThisMonth;
            this.cmbThisMonth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbThisMonth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbThisMonth.HoverState.Parent = this.cmbThisMonth;
            this.cmbThisMonth.ItemHeight = 30;
            this.cmbThisMonth.Items.AddRange(new object[] {
            "All Sale Invoice",
            "This Month",
            "This Year",
            "Last Month",
            "This Qurter"});
            this.cmbThisMonth.ItemsAppearance.Parent = this.cmbThisMonth;
            this.cmbThisMonth.Location = new System.Drawing.Point(43, 44);
            this.cmbThisMonth.Name = "cmbThisMonth";
            this.cmbThisMonth.ShadowDecoration.Parent = this.cmbThisMonth;
            this.cmbThisMonth.Size = new System.Drawing.Size(156, 36);
            this.cmbThisMonth.StartIndex = 0;
            this.cmbThisMonth.TabIndex = 1;
            this.cmbThisMonth.SelectedIndexChanged += new System.EventHandler(this.cmbThisMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Between";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.txtPaid);
            this.guna2Panel1.Controls.Add(this.label9);
            this.guna2Panel1.Location = new System.Drawing.Point(65, 111);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(190, 81);
            this.guna2Panel1.TabIndex = 10;
            // 
            // txtPaid
            // 
            this.txtPaid.BorderThickness = 0;
            this.txtPaid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPaid.DefaultText = "";
            this.txtPaid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPaid.DisabledState.Parent = this.txtPaid;
            this.txtPaid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPaid.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtPaid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPaid.FocusedState.Parent = this.txtPaid;
            this.txtPaid.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPaid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPaid.HoverState.Parent = this.txtPaid;
            this.txtPaid.Location = new System.Drawing.Point(10, 28);
            this.txtPaid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.PasswordChar = '\0';
            this.txtPaid.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtPaid.PlaceholderText = "0";
            this.txtPaid.SelectedText = "";
            this.txtPaid.ShadowDecoration.Parent = this.txtPaid;
            this.txtPaid.Size = new System.Drawing.Size(169, 43);
            this.txtPaid.TabIndex = 56;
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Paid";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Pink;
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.txtUnpaid);
            this.guna2Panel2.Controls.Add(this.label7);
            this.guna2Panel2.Location = new System.Drawing.Point(287, 114);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(178, 78);
            this.guna2Panel2.TabIndex = 10;
            // 
            // txtUnpaid
            // 
            this.txtUnpaid.BorderThickness = 0;
            this.txtUnpaid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnpaid.DefaultText = "";
            this.txtUnpaid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUnpaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUnpaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUnpaid.DisabledState.Parent = this.txtUnpaid;
            this.txtUnpaid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUnpaid.FillColor = System.Drawing.Color.Pink;
            this.txtUnpaid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUnpaid.FocusedState.Parent = this.txtUnpaid;
            this.txtUnpaid.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnpaid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtUnpaid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUnpaid.HoverState.Parent = this.txtUnpaid;
            this.txtUnpaid.Location = new System.Drawing.Point(5, 27);
            this.txtUnpaid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUnpaid.Name = "txtUnpaid";
            this.txtUnpaid.PasswordChar = '\0';
            this.txtUnpaid.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtUnpaid.PlaceholderText = "0";
            this.txtUnpaid.SelectedText = "";
            this.txtUnpaid.ShadowDecoration.Parent = this.txtUnpaid;
            this.txtUnpaid.Size = new System.Drawing.Size(169, 43);
            this.txtUnpaid.TabIndex = 3;
            this.txtUnpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Unpaid";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.guna2Panel3.BorderRadius = 15;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.txtOverDue);
            this.guna2Panel3.Controls.Add(this.label6);
            this.guna2Panel3.Location = new System.Drawing.Point(497, 114);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(178, 78);
            this.guna2Panel3.TabIndex = 11;
            // 
            // txtOverDue
            // 
            this.txtOverDue.BorderThickness = 0;
            this.txtOverDue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOverDue.DefaultText = "";
            this.txtOverDue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOverDue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOverDue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOverDue.DisabledState.Parent = this.txtOverDue;
            this.txtOverDue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOverDue.FillColor = System.Drawing.Color.PaleTurquoise;
            this.txtOverDue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOverDue.FocusedState.Parent = this.txtOverDue;
            this.txtOverDue.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOverDue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtOverDue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOverDue.HoverState.Parent = this.txtOverDue;
            this.txtOverDue.Location = new System.Drawing.Point(5, 28);
            this.txtOverDue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOverDue.Name = "txtOverDue";
            this.txtOverDue.PasswordChar = '\0';
            this.txtOverDue.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtOverDue.PlaceholderText = "0";
            this.txtOverDue.SelectedText = "";
            this.txtOverDue.ShadowDecoration.Parent = this.txtOverDue;
            this.txtOverDue.Size = new System.Drawing.Size(169, 43);
            this.txtOverDue.TabIndex = 3;
            this.txtOverDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "OverDue";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.PeachPuff;
            this.guna2Panel4.BorderRadius = 15;
            this.guna2Panel4.BorderThickness = 1;
            this.guna2Panel4.Controls.Add(this.txtTotal);
            this.guna2Panel4.Controls.Add(this.label8);
            this.guna2Panel4.Location = new System.Drawing.Point(711, 111);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(178, 78);
            this.guna2Panel4.TabIndex = 11;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderThickness = 0;
            this.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotal.DefaultText = "";
            this.txtTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.DisabledState.Parent = this.txtTotal;
            this.txtTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.FillColor = System.Drawing.Color.PeachPuff;
            this.txtTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotal.FocusedState.Parent = this.txtTotal;
            this.txtTotal.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotal.HoverState.Parent = this.txtTotal;
            this.txtTotal.Location = new System.Drawing.Point(5, 30);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PasswordChar = '\0';
            this.txtTotal.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTotal.PlaceholderText = "0";
            this.txtTotal.SelectedText = "";
            this.txtTotal.ShadowDecoration.Parent = this.txtTotal;
            this.txtTotal.Size = new System.Drawing.Size(169, 43);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(468, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 23);
            this.label10.TabIndex = 12;
            this.label10.Text = "+";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(258, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 23);
            this.label11.TabIndex = 13;
            this.label11.Text = "+";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(678, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 25);
            this.label12.TabIndex = 14;
            this.label12.Text = "=";
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.AutoSize = true;
            this.guna2Panel5.Controls.Add(this.guna2Button2);
            this.guna2Panel5.Controls.Add(this.dgvsaleInvoice);
            this.guna2Panel5.Controls.Add(this.btnAddSale);
            this.guna2Panel5.Controls.Add(this.txtSearch);
            this.guna2Panel5.Controls.Add(this.label13);
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel5.Location = new System.Drawing.Point(0, 182);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.Parent = this.guna2Panel5;
            this.guna2Panel5.Size = new System.Drawing.Size(1038, 419);
            this.guna2Panel5.TabIndex = 15;
            // 
            // guna2Button2
            // 
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button2.Location = new System.Drawing.Point(54, 30);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(73, 43);
            this.guna2Button2.TabIndex = 48;
            this.guna2Button2.Text = "guna2Button2";
            // 
            // dgvsaleInvoice
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvsaleInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsaleInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsaleInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvsaleInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvsaleInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvsaleInvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsaleInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsaleInvoice.ColumnHeadersHeight = 37;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvsaleInvoice.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvsaleInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsaleInvoice.EnableHeadersVisualStyles = false;
            this.dgvsaleInvoice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvsaleInvoice.Location = new System.Drawing.Point(17, 89);
            this.dgvsaleInvoice.Name = "dgvsaleInvoice";
            this.dgvsaleInvoice.RowHeadersVisible = false;
            this.dgvsaleInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvsaleInvoice.Size = new System.Drawing.Size(997, 330);
            this.dgvsaleInvoice.TabIndex = 47;
            this.dgvsaleInvoice.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvsaleInvoice.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvsaleInvoice.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvsaleInvoice.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvsaleInvoice.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvsaleInvoice.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvsaleInvoice.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvsaleInvoice.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvsaleInvoice.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvsaleInvoice.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvsaleInvoice.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsaleInvoice.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvsaleInvoice.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvsaleInvoice.ThemeStyle.HeaderStyle.Height = 37;
            this.dgvsaleInvoice.ThemeStyle.ReadOnly = false;
            this.dgvsaleInvoice.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvsaleInvoice.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvsaleInvoice.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsaleInvoice.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvsaleInvoice.ThemeStyle.RowsStyle.Height = 22;
            this.dgvsaleInvoice.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvsaleInvoice.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvsaleInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsaleInvoice_CellContentClick);
            this.dgvsaleInvoice.Enter += new System.EventHandler(this.dgvsaleInvoice_Enter);
            // 
            // btnAddSale
            // 
            this.btnAddSale.BorderRadius = 20;
            this.btnAddSale.CheckedState.Parent = this.btnAddSale;
            this.btnAddSale.CustomImages.Parent = this.btnAddSale;
            this.btnAddSale.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddSale.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSale.ForeColor = System.Drawing.Color.White;
            this.btnAddSale.HoverState.Parent = this.btnAddSale;
            this.btnAddSale.Location = new System.Drawing.Point(890, 23);
            this.btnAddSale.Name = "btnAddSale";
            this.btnAddSale.ShadowDecoration.Parent = this.btnAddSale;
            this.btnAddSale.Size = new System.Drawing.Size(121, 45);
            this.btnAddSale.TabIndex = 2;
            this.btnAddSale.Text = "+ Add Sale";
            this.btnAddSale.Click += new System.EventHandler(this.guna2Button1_Click);
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
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.Location = new System.Drawing.Point(128, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(200, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(40, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Transaction";
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
            this.btnCancel.Location = new System.Drawing.Point(1001, 1);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(27, 27);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1001, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Print";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(908, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Graph";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Transparent;
            this.btnprint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnprint.BackgroundImage")));
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Location = new System.Drawing.Point(1004, 44);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(25, 24);
            this.btnprint.TabIndex = 51;
            this.btnprint.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(959, 45);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(20, 20);
            this.btnImport.TabIndex = 50;
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // btnGraph
            // 
            this.btnGraph.BackColor = System.Drawing.Color.Transparent;
            this.btnGraph.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGraph.BackgroundImage")));
            this.btnGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGraph.FlatAppearance.BorderSize = 0;
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraph.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGraph.Location = new System.Drawing.Point(913, 46);
            this.btnGraph.Margin = new System.Windows.Forms.Padding(4);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(20, 21);
            this.btnGraph.TabIndex = 49;
            this.btnGraph.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(955, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 26);
            this.label3.TabIndex = 54;
            this.label3.Text = "Excel\r\nReport";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(447, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "To";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(653, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 16);
            this.label14.TabIndex = 58;
            this.label14.Text = "All Firms :";
            // 
            // cmbFirm
            // 
            this.cmbFirm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFirm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFirm.FormattingEnabled = true;
            this.cmbFirm.Location = new System.Drawing.Point(731, 49);
            this.cmbFirm.Name = "cmbFirm";
            this.cmbFirm.Size = new System.Drawing.Size(140, 24);
            this.cmbFirm.TabIndex = 59;
            this.cmbFirm.SelectedIndexChanged += new System.EventHandler(this.cmbFirm_SelectedIndexChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MM/dd/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(300, 50);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(140, 23);
            this.dtpFromDate.TabIndex = 60;
            // 
            // dtpTodate
            // 
            this.dtpTodate.CustomFormat = "MM/dd/yyyy";
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTodate.Location = new System.Drawing.Point(477, 50);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(140, 23);
            this.dtpTodate.TabIndex = 61;
            this.dtpTodate.ValueChanged += new System.EventHandler(this.dtpTodate_ValueChanged_1);
            this.dtpTodate.Enter += new System.EventHandler(this.dtpTodate_Enter_1);
            // 
            // SaleInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dtpTodate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cmbFirm);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.guna2Panel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbThisMonth);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaleInvoiceReport";
            this.Size = new System.Drawing.Size(1038, 601);
            this.Load += new System.EventHandler(this.SaleInvoiceReport_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsaleInvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbThisMonth;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Button btnAddSale;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtPaid;
        private Guna.UI2.WinForms.Guna2TextBox txtUnpaid;
        private Guna.UI2.WinForms.Guna2TextBox txtOverDue;
        private Guna.UI2.WinForms.Guna2TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvsaleInvoice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbFirm;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpTodate;
    }
}