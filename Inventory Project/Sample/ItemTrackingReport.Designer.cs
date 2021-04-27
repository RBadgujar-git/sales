namespace sample
{
    partial class ItemTrackingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemTrackingReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemname = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtSerialNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbatchNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvItemTracking = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkShowOnly = new Guna.UI2.WinForms.Guna2CheckBox();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.dtpFromexp = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToexp = new System.Windows.Forms.DateTimePicker();
            this.btnminimize = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemTracking)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Item Tracking Report";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Name :";
            // 
            // txtItemname
            // 
            this.txtItemname.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtItemname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtItemname.DefaultText = "";
            this.txtItemname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtItemname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtItemname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtItemname.DisabledState.Parent = this.txtItemname;
            this.txtItemname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtItemname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtItemname.FocusedState.Parent = this.txtItemname;
            this.txtItemname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtItemname.ForeColor = System.Drawing.Color.Black;
            this.txtItemname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtItemname.HoverState.Parent = this.txtItemname;
            this.txtItemname.Location = new System.Drawing.Point(116, 57);
            this.txtItemname.Name = "txtItemname";
            this.txtItemname.PasswordChar = '\0';
            this.txtItemname.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtItemname.PlaceholderText = "Item Name";
            this.txtItemname.SelectedText = "";
            this.txtItemname.ShadowDecoration.Parent = this.txtItemname;
            this.txtItemname.Size = new System.Drawing.Size(151, 30);
            this.txtItemname.TabIndex = 2;
            this.txtItemname.TextChanged += new System.EventHandler(this.txtItemname_TextChanged);
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
            this.btnCancel.Location = new System.Drawing.Point(989, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 119;
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
            this.btnPrint.Location = new System.Drawing.Point(994, 36);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 23);
            this.btnPrint.TabIndex = 118;
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
            this.btnImport.Location = new System.Drawing.Point(886, 38);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(19, 16);
            this.btnImport.TabIndex = 117;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSerialNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSerialNo.DefaultText = "";
            this.txtSerialNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSerialNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSerialNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNo.DisabledState.Parent = this.txtSerialNo;
            this.txtSerialNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNo.FocusedState.Parent = this.txtSerialNo;
            this.txtSerialNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSerialNo.ForeColor = System.Drawing.Color.Black;
            this.txtSerialNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNo.HoverState.Parent = this.txtSerialNo;
            this.txtSerialNo.Location = new System.Drawing.Point(384, 62);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.PasswordChar = '\0';
            this.txtSerialNo.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSerialNo.PlaceholderText = "Serial No";
            this.txtSerialNo.SelectedText = "";
            this.txtSerialNo.ShadowDecoration.Parent = this.txtSerialNo;
            this.txtSerialNo.Size = new System.Drawing.Size(121, 30);
            this.txtSerialNo.TabIndex = 121;
            this.txtSerialNo.TextChanged += new System.EventHandler(this.txtSerialNo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 120;
            this.label3.Text = "Serial No :";
            // 
            // txtbatchNo
            // 
            this.txtbatchNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtbatchNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbatchNo.DefaultText = "";
            this.txtbatchNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbatchNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbatchNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbatchNo.DisabledState.Parent = this.txtbatchNo;
            this.txtbatchNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbatchNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbatchNo.FocusedState.Parent = this.txtbatchNo;
            this.txtbatchNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbatchNo.ForeColor = System.Drawing.Color.Black;
            this.txtbatchNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbatchNo.HoverState.Parent = this.txtbatchNo;
            this.txtbatchNo.Location = new System.Drawing.Point(639, 62);
            this.txtbatchNo.Name = "txtbatchNo";
            this.txtbatchNo.PasswordChar = '\0';
            this.txtbatchNo.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtbatchNo.PlaceholderText = "Batch No";
            this.txtbatchNo.SelectedText = "";
            this.txtbatchNo.ShadowDecoration.Parent = this.txtbatchNo;
            this.txtbatchNo.Size = new System.Drawing.Size(129, 30);
            this.txtbatchNo.TabIndex = 123;
            this.txtbatchNo.TextChanged += new System.EventHandler(this.txtbatchNo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 122;
            this.label4.Text = "Batch No :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 127;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 125;
            this.label6.Text = "From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(745, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 131;
            this.label7.Text = "To";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(548, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 129;
            this.label8.Text = "From";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(553, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 132;
            this.label9.Text = "Exp Date :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 133;
            this.label10.Text = "Mfg Date:";
            // 
            // dgvItemTracking
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvItemTracking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItemTracking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemTracking.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemTracking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItemTracking.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItemTracking.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemTracking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItemTracking.ColumnHeadersHeight = 34;
            this.dgvItemTracking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column6});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemTracking.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItemTracking.EnableHeadersVisualStyles = false;
            this.dgvItemTracking.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItemTracking.Location = new System.Drawing.Point(15, 193);
            this.dgvItemTracking.Name = "dgvItemTracking";
            this.dgvItemTracking.RowHeadersVisible = false;
            this.dgvItemTracking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemTracking.Size = new System.Drawing.Size(1020, 408);
            this.dgvItemTracking.TabIndex = 134;
            this.dgvItemTracking.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvItemTracking.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItemTracking.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvItemTracking.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvItemTracking.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvItemTracking.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvItemTracking.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvItemTracking.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItemTracking.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvItemTracking.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItemTracking.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemTracking.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItemTracking.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvItemTracking.ThemeStyle.HeaderStyle.Height = 34;
            this.dgvItemTracking.ThemeStyle.ReadOnly = false;
            this.dgvItemTracking.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItemTracking.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItemTracking.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItemTracking.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvItemTracking.ThemeStyle.RowsStyle.Height = 22;
            this.dgvItemTracking.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItemTracking.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvItemTracking.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemTracking_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Batch No";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Serial No";
            this.Column3.Name = "Column3";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Size";
            this.Column8.Name = "Column8";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "MFG Date";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "EXP Date";
            this.Column6.Name = "Column6";
            // 
            // chkShowOnly
            // 
            this.chkShowOnly.AutoSize = true;
            this.chkShowOnly.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowOnly.CheckedState.BorderRadius = 0;
            this.chkShowOnly.CheckedState.BorderThickness = 0;
            this.chkShowOnly.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowOnly.Location = new System.Drawing.Point(778, 89);
            this.chkShowOnly.Name = "chkShowOnly";
            this.chkShowOnly.Size = new System.Drawing.Size(191, 20);
            this.chkShowOnly.TabIndex = 136;
            this.chkShowOnly.Text = "Show Only Item in Stock";
            this.chkShowOnly.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowOnly.UncheckedState.BorderRadius = 0;
            this.chkShowOnly.UncheckedState.BorderThickness = 0;
            this.chkShowOnly.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowOnly.Visible = false;
            this.chkShowOnly.CheckedChanged += new System.EventHandler(this.chkShowOnly_CheckedChanged);
            // 
            // dtpfrom
            // 
            this.dtpfrom.CustomFormat = "MM/dd/yyyy";
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom.Location = new System.Drawing.Point(77, 147);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(145, 23);
            this.dtpfrom.TabIndex = 137;
            // 
            // dtpFromexp
            // 
            this.dtpFromexp.CustomFormat = "MM/dd/yyyy";
            this.dtpFromexp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromexp.Location = new System.Drawing.Point(593, 149);
            this.dtpFromexp.Name = "dtpFromexp";
            this.dtpFromexp.Size = new System.Drawing.Size(147, 23);
            this.dtpFromexp.TabIndex = 138;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM/dd/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(258, 147);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(156, 23);
            this.dtpToDate.TabIndex = 139;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            this.dtpToDate.Enter += new System.EventHandler(this.dtpToDate_Enter);
            // 
            // dtpToexp
            // 
            this.dtpToexp.CustomFormat = "MM/dd/yyyy";
            this.dtpToexp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToexp.Location = new System.Drawing.Point(775, 147);
            this.dtpToexp.Name = "dtpToexp";
            this.dtpToexp.Size = new System.Drawing.Size(173, 23);
            this.dtpToexp.TabIndex = 140;
            this.dtpToexp.ValueChanged += new System.EventHandler(this.dtpToexp_ValueChanged);
            this.dtpToexp.Enter += new System.EventHandler(this.dtpToexp_Enter);
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
            this.btnminimize.Location = new System.Drawing.Point(879, 5);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 438;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(992, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 16);
            this.label11.TabIndex = 439;
            this.label11.Text = "Print";
            // 
            // ItemTrackingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtpToexp);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromexp);
            this.Controls.Add(this.dtpfrom);
            this.Controls.Add(this.chkShowOnly);
            this.Controls.Add(this.dgvItemTracking);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbatchNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtItemname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemTrackingReport";
            this.Size = new System.Drawing.Size(1020, 578);
            this.Load += new System.EventHandler(this.ItemTrackingReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemTracking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtItemname;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private Guna.UI2.WinForms.Guna2TextBox txtSerialNo;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtbatchNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2DataGridView dgvItemTracking;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowOnly;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.DateTimePicker dtpFromexp;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpToexp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Label label11;
    }
}
