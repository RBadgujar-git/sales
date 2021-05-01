namespace sample
{
    partial class Makepayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Makepayment));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrincipleAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtinterestAmout = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvMakePayment = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPaidFrom = new System.Windows.Forms.ComboBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnminimize = new System.Windows.Forms.Button();
            this.txtcurrentbal = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakePayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Make Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Principle Amount :";
            // 
            // txtPrincipleAmount
            // 
            this.txtPrincipleAmount.BorderColor = System.Drawing.Color.Gray;
            this.txtPrincipleAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrincipleAmount.DefaultText = "0";
            this.txtPrincipleAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrincipleAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrincipleAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrincipleAmount.DisabledState.Parent = this.txtPrincipleAmount;
            this.txtPrincipleAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrincipleAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrincipleAmount.FocusedState.Parent = this.txtPrincipleAmount;
            this.txtPrincipleAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrincipleAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPrincipleAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrincipleAmount.HoverState.Parent = this.txtPrincipleAmount;
            this.txtPrincipleAmount.Location = new System.Drawing.Point(171, 107);
            this.txtPrincipleAmount.MaxLength = 1000;
            this.txtPrincipleAmount.Name = "txtPrincipleAmount";
            this.txtPrincipleAmount.PasswordChar = '\0';
            this.txtPrincipleAmount.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtPrincipleAmount.PlaceholderText = "";
            this.txtPrincipleAmount.SelectedText = "";
            this.txtPrincipleAmount.SelectionStart = 1;
            this.txtPrincipleAmount.ShadowDecoration.Parent = this.txtPrincipleAmount;
            this.txtPrincipleAmount.Size = new System.Drawing.Size(200, 30);
            this.txtPrincipleAmount.TabIndex = 2;
            this.txtPrincipleAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrincipleAmount.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            this.txtPrincipleAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrincipleAmount_KeyPress);
            // 
            // txtinterestAmout
            // 
            this.txtinterestAmout.BorderColor = System.Drawing.Color.Gray;
            this.txtinterestAmout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtinterestAmout.DefaultText = "0";
            this.txtinterestAmout.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtinterestAmout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtinterestAmout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtinterestAmout.DisabledState.Parent = this.txtinterestAmout;
            this.txtinterestAmout.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtinterestAmout.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtinterestAmout.FocusedState.Parent = this.txtinterestAmout;
            this.txtinterestAmout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtinterestAmout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtinterestAmout.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtinterestAmout.HoverState.Parent = this.txtinterestAmout;
            this.txtinterestAmout.Location = new System.Drawing.Point(171, 145);
            this.txtinterestAmout.MaxLength = 1000;
            this.txtinterestAmout.Name = "txtinterestAmout";
            this.txtinterestAmout.PasswordChar = '\0';
            this.txtinterestAmout.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtinterestAmout.PlaceholderText = "";
            this.txtinterestAmout.SelectedText = "";
            this.txtinterestAmout.SelectionStart = 1;
            this.txtinterestAmout.ShadowDecoration.Parent = this.txtinterestAmout;
            this.txtinterestAmout.Size = new System.Drawing.Size(200, 30);
            this.txtinterestAmout.TabIndex = 3;
            this.txtinterestAmout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtinterestAmout.TextChanged += new System.EventHandler(this.txtinterestAmout_TextChanged);
            this.txtinterestAmout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinterestAmout_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Interest Amount :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Amount :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BorderColor = System.Drawing.Color.Gray;
            this.txtTotalAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalAmount.DefaultText = "0";
            this.txtTotalAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalAmount.DisabledState.Parent = this.txtTotalAmount;
            this.txtTotalAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalAmount.FocusedState.Parent = this.txtTotalAmount;
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTotalAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalAmount.HoverState.Parent = this.txtTotalAmount;
            this.txtTotalAmount.Location = new System.Drawing.Point(510, 75);
            this.txtTotalAmount.MaxLength = 1000;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.PasswordChar = '\0';
            this.txtTotalAmount.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTotalAmount.PlaceholderText = "";
            this.txtTotalAmount.SelectedText = "";
            this.txtTotalAmount.SelectionStart = 1;
            this.txtTotalAmount.ShadowDecoration.Parent = this.txtTotalAmount;
            this.txtTotalAmount.Size = new System.Drawing.Size(200, 30);
            this.txtTotalAmount.TabIndex = 5;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(424, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Paid From :";
            // 
            // dgvMakePayment
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMakePayment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMakePayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMakePayment.BackgroundColor = System.Drawing.Color.White;
            this.dgvMakePayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMakePayment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMakePayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMakePayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMakePayment.ColumnHeadersHeight = 18;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMakePayment.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMakePayment.EnableHeadersVisualStyles = false;
            this.dgvMakePayment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMakePayment.Location = new System.Drawing.Point(25, 254);
            this.dgvMakePayment.Name = "dgvMakePayment";
            this.dgvMakePayment.RowHeadersVisible = false;
            this.dgvMakePayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMakePayment.Size = new System.Drawing.Size(729, 287);
            this.dgvMakePayment.TabIndex = 13;
            this.dgvMakePayment.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvMakePayment.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMakePayment.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvMakePayment.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvMakePayment.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvMakePayment.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvMakePayment.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvMakePayment.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMakePayment.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvMakePayment.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMakePayment.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMakePayment.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMakePayment.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvMakePayment.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvMakePayment.ThemeStyle.ReadOnly = false;
            this.dgvMakePayment.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMakePayment.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMakePayment.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMakePayment.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvMakePayment.ThemeStyle.RowsStyle.Height = 22;
            this.dgvMakePayment.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMakePayment.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvMakePayment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMakePayment_CellDoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(357, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancel.BackgroundImage")));
            this.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncancel.Location = new System.Drawing.Point(746, 7);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(30, 27);
            this.btncancel.TabIndex = 156;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MM-yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(510, 44);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 4;
            // 
            // cmbPaidFrom
            // 
            this.cmbPaidFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPaidFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaidFrom.FormattingEnabled = true;
            this.cmbPaidFrom.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "Online Payment"});
            this.cmbPaidFrom.Location = new System.Drawing.Point(510, 114);
            this.cmbPaidFrom.Name = "cmbPaidFrom";
            this.cmbPaidFrom.Size = new System.Drawing.Size(200, 24);
            this.cmbPaidFrom.TabIndex = 6;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnclear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnclear.Location = new System.Drawing.Point(625, 203);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(85, 35);
            this.btnclear.TabIndex = 10;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(536, 203);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 35);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdate.Location = new System.Drawing.Point(447, 203);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 35);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(171, 45);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(200, 24);
            this.cmbCompanyName.TabIndex = 1;
            this.cmbCompanyName.SelectedIndexChanged += new System.EventHandler(this.cmbCompanyName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Account Name :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnminimize
            // 
            this.btnminimize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnminimize.BackColor = System.Drawing.Color.White;
            this.btnminimize.BackgroundImage = global::sample.Properties.Resources.MinimizeNew;
            this.btnminimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnminimize.FlatAppearance.BorderSize = 0;
            this.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminimize.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnminimize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnminimize.Location = new System.Drawing.Point(723, 8);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 440;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // txtcurrentbal
            // 
            this.txtcurrentbal.BorderColor = System.Drawing.Color.Gray;
            this.txtcurrentbal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcurrentbal.DefaultText = "0";
            this.txtcurrentbal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcurrentbal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcurrentbal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcurrentbal.DisabledState.Parent = this.txtcurrentbal;
            this.txtcurrentbal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcurrentbal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcurrentbal.FocusedState.Parent = this.txtcurrentbal;
            this.txtcurrentbal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtcurrentbal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtcurrentbal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcurrentbal.HoverState.Parent = this.txtcurrentbal;
            this.txtcurrentbal.Location = new System.Drawing.Point(171, 75);
            this.txtcurrentbal.MaxLength = 1000;
            this.txtcurrentbal.Name = "txtcurrentbal";
            this.txtcurrentbal.PasswordChar = '\0';
            this.txtcurrentbal.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtcurrentbal.PlaceholderText = "";
            this.txtcurrentbal.SelectedText = "";
            this.txtcurrentbal.SelectionStart = 1;
            this.txtcurrentbal.ShadowDecoration.Parent = this.txtcurrentbal;
            this.txtcurrentbal.Size = new System.Drawing.Size(200, 25);
            this.txtcurrentbal.TabIndex = 441;
            this.txtcurrentbal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 442;
            this.label8.Text = "Loan Amount  :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::sample.Properties.Resources.icons8_search_1001;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(82, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 22);
            this.button1.TabIndex = 444;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderColor = System.Drawing.Color.Gray;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.DefaultText = "";
            this.textBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox2.DisabledState.Parent = this.textBox2;
            this.textBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox2.FocusedState.Parent = this.textBox2;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox2.HoverState.Parent = this.textBox2;
            this.textBox2.Location = new System.Drawing.Point(112, 215);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textBox2.PlaceholderText = "Account Name";
            this.textBox2.SelectedText = "";
            this.textBox2.ShadowDecoration.Parent = this.textBox2;
            this.textBox2.Size = new System.Drawing.Size(180, 26);
            this.textBox2.TabIndex = 453;
            this.textBox2.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged_1);
            // 
            // Makepayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcurrentbal);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.cmbCompanyName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.cmbPaidFrom);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMakePayment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtinterestAmout);
            this.Controls.Add(this.txtPrincipleAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Makepayment";
            this.Size = new System.Drawing.Size(783, 545);
            this.Load += new System.EventHandler(this.Makepayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakePayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtPrincipleAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtinterestAmout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalAmount;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMakePayment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbPaidFrom;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnminimize;
        private Guna.UI2.WinForms.Guna2TextBox txtcurrentbal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2TextBox textBox2;
    }
}
