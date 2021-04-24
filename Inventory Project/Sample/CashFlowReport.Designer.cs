namespace sample
{
    partial class CashFlowReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashFlowReport));
            this.cmballfirm = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtcrnote = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkamounttransaction = new Guna.UI2.WinForms.Guna2CheckBox();
            this.dgvCashflow = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtclosing = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTotalcashIn = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTotalCashout = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashflow)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmballfirm
            // 
            this.cmballfirm.BackColor = System.Drawing.Color.Transparent;
            this.cmballfirm.BorderColor = System.Drawing.Color.Gray;
            this.cmballfirm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmballfirm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmballfirm.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballfirm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballfirm.FocusedState.Parent = this.cmballfirm;
            this.cmballfirm.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmballfirm.ForeColor = System.Drawing.Color.Blue;
            this.cmballfirm.HoverState.Parent = this.cmballfirm;
            this.cmballfirm.ItemHeight = 30;
            this.cmballfirm.Items.AddRange(new object[] {
            "All Firms"});
            this.cmballfirm.ItemsAppearance.Parent = this.cmballfirm;
            this.cmballfirm.Location = new System.Drawing.Point(95, 25);
            this.cmballfirm.Name = "cmballfirm";
            this.cmballfirm.ShadowDecoration.Parent = this.cmballfirm;
            this.cmballfirm.Size = new System.Drawing.Size(140, 36);
            this.cmballfirm.StartIndex = 0;
            this.cmballfirm.TabIndex = 54;
            this.cmballfirm.SelectedIndexChanged += new System.EventHandler(this.cmballfirm_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(271, 16);
            this.label13.TabIndex = 59;
            this.label13.Text = "Unused Payment and Open Cr Note :";
            // 
            // txtcrnote
            // 
            this.txtcrnote.BorderColor = System.Drawing.Color.Gray;
            this.txtcrnote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcrnote.DefaultText = "";
            this.txtcrnote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcrnote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcrnote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcrnote.DisabledState.Parent = this.txtcrnote;
            this.txtcrnote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcrnote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcrnote.FocusedState.Parent = this.txtcrnote;
            this.txtcrnote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtcrnote.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtcrnote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcrnote.HoverState.Parent = this.txtcrnote;
            this.txtcrnote.Location = new System.Drawing.Point(290, 115);
            this.txtcrnote.Name = "txtcrnote";
            this.txtcrnote.PasswordChar = '\0';
            this.txtcrnote.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtcrnote.PlaceholderText = "0";
            this.txtcrnote.SelectedText = "";
            this.txtcrnote.ShadowDecoration.Parent = this.txtcrnote;
            this.txtcrnote.Size = new System.Drawing.Size(91, 28);
            this.txtcrnote.TabIndex = 65;
            this.txtcrnote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkamounttransaction
            // 
            this.chkamounttransaction.AutoSize = true;
            this.chkamounttransaction.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkamounttransaction.CheckedState.BorderRadius = 0;
            this.chkamounttransaction.CheckedState.BorderThickness = 0;
            this.chkamounttransaction.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkamounttransaction.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkamounttransaction.Location = new System.Drawing.Point(477, 38);
            this.chkamounttransaction.Name = "chkamounttransaction";
            this.chkamounttransaction.Size = new System.Drawing.Size(184, 17);
            this.chkamounttransaction.TabIndex = 70;
            this.chkamounttransaction.Text = "Show 0 amount Transaction";
            this.chkamounttransaction.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkamounttransaction.UncheckedState.BorderRadius = 0;
            this.chkamounttransaction.UncheckedState.BorderThickness = 0;
            this.chkamounttransaction.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // dgvCashflow
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvCashflow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCashflow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashflow.BackgroundColor = System.Drawing.Color.White;
            this.dgvCashflow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCashflow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCashflow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashflow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCashflow.ColumnHeadersHeight = 34;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashflow.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCashflow.EnableHeadersVisualStyles = false;
            this.dgvCashflow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCashflow.Location = new System.Drawing.Point(4, 162);
            this.dgvCashflow.Name = "dgvCashflow";
            this.dgvCashflow.RowHeadersVisible = false;
            this.dgvCashflow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashflow.Size = new System.Drawing.Size(968, 399);
            this.dgvCashflow.TabIndex = 71;
            this.dgvCashflow.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvCashflow.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCashflow.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCashflow.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCashflow.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCashflow.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCashflow.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCashflow.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCashflow.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCashflow.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCashflow.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCashflow.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCashflow.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCashflow.ThemeStyle.HeaderStyle.Height = 34;
            this.dgvCashflow.ThemeStyle.ReadOnly = false;
            this.dgvCashflow.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCashflow.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCashflow.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCashflow.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvCashflow.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCashflow.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCashflow.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txtclosing);
            this.guna2Panel1.Controls.Add(this.txtTotalcashIn);
            this.guna2Panel1.Controls.Add(this.txtTotalCashout);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 482);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(977, 58);
            this.guna2Panel1.TabIndex = 72;
            // 
            // txtclosing
            // 
            this.txtclosing.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtclosing.DefaultText = "";
            this.txtclosing.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtclosing.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtclosing.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtclosing.DisabledState.Parent = this.txtclosing;
            this.txtclosing.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtclosing.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtclosing.FocusedState.Parent = this.txtclosing;
            this.txtclosing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtclosing.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtclosing.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtclosing.HoverState.Parent = this.txtclosing;
            this.txtclosing.Location = new System.Drawing.Point(816, 11);
            this.txtclosing.Name = "txtclosing";
            this.txtclosing.PasswordChar = '\0';
            this.txtclosing.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtclosing.PlaceholderText = "0";
            this.txtclosing.SelectedText = "";
            this.txtclosing.ShadowDecoration.Parent = this.txtclosing;
            this.txtclosing.Size = new System.Drawing.Size(141, 36);
            this.txtclosing.TabIndex = 68;
            this.txtclosing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalcashIn
            // 
            this.txtTotalcashIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalcashIn.DefaultText = "";
            this.txtTotalcashIn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalcashIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalcashIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalcashIn.DisabledState.Parent = this.txtTotalcashIn;
            this.txtTotalcashIn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalcashIn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalcashIn.FocusedState.Parent = this.txtTotalcashIn;
            this.txtTotalcashIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalcashIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTotalcashIn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalcashIn.HoverState.Parent = this.txtTotalcashIn;
            this.txtTotalcashIn.Location = new System.Drawing.Point(219, 11);
            this.txtTotalcashIn.Name = "txtTotalcashIn";
            this.txtTotalcashIn.PasswordChar = '\0';
            this.txtTotalcashIn.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTotalcashIn.PlaceholderText = "0";
            this.txtTotalcashIn.SelectedText = "";
            this.txtTotalcashIn.ShadowDecoration.Parent = this.txtTotalcashIn;
            this.txtTotalcashIn.Size = new System.Drawing.Size(99, 36);
            this.txtTotalcashIn.TabIndex = 67;
            this.txtTotalcashIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCashout
            // 
            this.txtTotalCashout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalCashout.DefaultText = "";
            this.txtTotalCashout.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalCashout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalCashout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalCashout.DisabledState.Parent = this.txtTotalCashout;
            this.txtTotalCashout.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalCashout.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalCashout.FocusedState.Parent = this.txtTotalCashout;
            this.txtTotalCashout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalCashout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTotalCashout.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalCashout.HoverState.Parent = this.txtTotalCashout;
            this.txtTotalCashout.Location = new System.Drawing.Point(507, 11);
            this.txtTotalCashout.Name = "txtTotalCashout";
            this.txtTotalCashout.PasswordChar = '\0';
            this.txtTotalCashout.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTotalCashout.PlaceholderText = "0";
            this.txtTotalCashout.SelectedText = "";
            this.txtTotalCashout.ShadowDecoration.Parent = this.txtTotalCashout;
            this.txtTotalCashout.Size = new System.Drawing.Size(113, 36);
            this.txtTotalCashout.TabIndex = 66;
            this.txtTotalCashout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(653, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Closing Cash In hand :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(326, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Cash-Out Amount :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(53, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Cash-In Amount :";
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "MM/dd/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(257, 32);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(151, 23);
            this.dtpdate.TabIndex = 73;
            this.dtpdate.ValueChanged += new System.EventHandler(this.dtpdate_ValueChanged);
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
            this.btnCancel.Location = new System.Drawing.Point(897, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 69;
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
            this.btnPrint.Location = new System.Drawing.Point(896, 49);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 25);
            this.btnPrint.TabIndex = 68;
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
            this.btnImport.Location = new System.Drawing.Point(852, 36);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(23, 20);
            this.btnImport.TabIndex = 67;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "All Transaction";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(888, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 75;
            this.label5.Text = "Print";
            // 
            // CashFlowReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvCashflow);
            this.Controls.Add(this.chkamounttransaction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtcrnote);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmballfirm);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CashFlowReport";
            this.Size = new System.Drawing.Size(977, 540);
            this.Load += new System.EventHandler(this.CashFlowReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashflow)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmballfirm;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txtcrnote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private Guna.UI2.WinForms.Guna2CheckBox chkamounttransaction;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCashflow;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtclosing;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalcashIn;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalCashout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
