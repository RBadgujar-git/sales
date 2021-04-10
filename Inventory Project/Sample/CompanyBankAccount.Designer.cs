namespace sample
{
    partial class CompanyBankAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyBankAccount));
            this.btnclick = new System.Windows.Forms.Button();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtOpeningBal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAccountNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBankName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvbankaccount = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnminimize = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbankaccount)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclick
            // 
            this.btnclick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnclick.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclick.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnclick.Location = new System.Drawing.Point(588, 147);
            this.btnclick.Name = "btnclick";
            this.btnclick.Size = new System.Drawing.Size(75, 30);
            this.btnclick.TabIndex = 9;
            this.btnclick.Text = "Clear";
            this.btnclick.UseVisualStyleBackColor = false;
            this.btnclick.Click += new System.EventHandler(this.btnclick_Click);
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "MM/dd/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(479, 76);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(150, 20);
            this.dtpdate.TabIndex = 5;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnsave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsave.Location = new System.Drawing.Point(353, 147);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 30);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "Save ";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnupdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnupdate.Location = new System.Drawing.Point(431, 147);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(75, 30);
            this.btnupdate.TabIndex = 7;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnprint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnprint.Location = new System.Drawing.Point(511, 147);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 30);
            this.btnprint.TabIndex = 8;
            this.btnprint.Text = "Delete";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // txtOpeningBal
            // 
            this.txtOpeningBal.BackColor = System.Drawing.Color.LightGray;
            this.txtOpeningBal.BorderColor = System.Drawing.Color.Gray;
            this.txtOpeningBal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOpeningBal.DefaultText = "0";
            this.txtOpeningBal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOpeningBal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOpeningBal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOpeningBal.DisabledState.Parent = this.txtOpeningBal;
            this.txtOpeningBal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOpeningBal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOpeningBal.FocusedState.Parent = this.txtOpeningBal;
            this.txtOpeningBal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOpeningBal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtOpeningBal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOpeningBal.HoverState.Parent = this.txtOpeningBal;
            this.txtOpeningBal.Location = new System.Drawing.Point(477, 41);
            this.txtOpeningBal.MaxLength = 1000;
            this.txtOpeningBal.Name = "txtOpeningBal";
            this.txtOpeningBal.PasswordChar = '\0';
            this.txtOpeningBal.PlaceholderText = "";
            this.txtOpeningBal.SelectedText = "";
            this.txtOpeningBal.SelectionStart = 1;
            this.txtOpeningBal.ShadowDecoration.Parent = this.txtOpeningBal;
            this.txtOpeningBal.Size = new System.Drawing.Size(150, 20);
            this.txtOpeningBal.TabIndex = 4;
            this.txtOpeningBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOpeningBal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtopeningbal_KeyPress);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.BorderColor = System.Drawing.Color.Gray;
            this.txtAccountNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccountNo.DefaultText = "";
            this.txtAccountNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAccountNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAccountNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountNo.DisabledState.Parent = this.txtAccountNo;
            this.txtAccountNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountNo.FocusedState.Parent = this.txtAccountNo;
            this.txtAccountNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAccountNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtAccountNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountNo.HoverState.Parent = this.txtAccountNo;
            this.txtAccountNo.Location = new System.Drawing.Point(196, 102);
            this.txtAccountNo.MaxLength = 20;
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.PasswordChar = '\0';
            this.txtAccountNo.PlaceholderText = "";
            this.txtAccountNo.SelectedText = "";
            this.txtAccountNo.ShadowDecoration.Parent = this.txtAccountNo;
            this.txtAccountNo.Size = new System.Drawing.Size(150, 20);
            this.txtAccountNo.TabIndex = 3;
            this.txtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccountno_KeyPress);
            // 
            // txtBankName
            // 
            this.txtBankName.BorderColor = System.Drawing.Color.Gray;
            this.txtBankName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBankName.DefaultText = "";
            this.txtBankName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBankName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBankName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBankName.DisabledState.Parent = this.txtBankName;
            this.txtBankName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBankName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBankName.FocusedState.Parent = this.txtBankName;
            this.txtBankName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBankName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtBankName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBankName.HoverState.Parent = this.txtBankName;
            this.txtBankName.Location = new System.Drawing.Point(196, 43);
            this.txtBankName.MaxLength = 50;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.PasswordChar = '\0';
            this.txtBankName.PlaceholderText = "";
            this.txtBankName.SelectedText = "";
            this.txtBankName.ShadowDecoration.Parent = this.txtBankName;
            this.txtBankName.Size = new System.Drawing.Size(150, 20);
            this.txtBankName.TabIndex = 1;
            this.txtBankName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbankname_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(292, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Company Bank Account";
            // 
            // txtAccountName
            // 
            this.txtAccountName.BorderColor = System.Drawing.Color.Gray;
            this.txtAccountName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccountName.DefaultText = "";
            this.txtAccountName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAccountName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAccountName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountName.DisabledState.Parent = this.txtAccountName;
            this.txtAccountName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAccountName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountName.FocusedState.Parent = this.txtAccountName;
            this.txtAccountName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAccountName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtAccountName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAccountName.HoverState.Parent = this.txtAccountName;
            this.txtAccountName.Location = new System.Drawing.Point(196, 71);
            this.txtAccountName.MaxLength = 50;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.PasswordChar = '\0';
            this.txtAccountName.PlaceholderText = "";
            this.txtAccountName.SelectedText = "";
            this.txtAccountName.ShadowDecoration.Parent = this.txtAccountName;
            this.txtAccountName.Size = new System.Drawing.Size(150, 20);
            this.txtAccountName.TabIndex = 2;
            this.txtAccountName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccountname_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label6.Location = new System.Drawing.Point(82, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Account Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label5.Location = new System.Drawing.Point(97, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Account No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label4.Location = new System.Drawing.Point(426, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.Location = new System.Drawing.Point(102, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank Name :";
            // 
            // dgvbankaccount
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvbankaccount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbankaccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbankaccount.BackgroundColor = System.Drawing.Color.White;
            this.dgvbankaccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvbankaccount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvbankaccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbankaccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvbankaccount.ColumnHeadersHeight = 34;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbankaccount.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvbankaccount.EnableHeadersVisualStyles = false;
            this.dgvbankaccount.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvbankaccount.Location = new System.Drawing.Point(15, 203);
            this.dgvbankaccount.Margin = new System.Windows.Forms.Padding(4);
            this.dgvbankaccount.Name = "dgvbankaccount";
            this.dgvbankaccount.RowHeadersVisible = false;
            this.dgvbankaccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbankaccount.Size = new System.Drawing.Size(788, 337);
            this.dgvbankaccount.TabIndex = 100;
            this.dgvbankaccount.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvbankaccount.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvbankaccount.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvbankaccount.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvbankaccount.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvbankaccount.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvbankaccount.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvbankaccount.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvbankaccount.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvbankaccount.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvbankaccount.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvbankaccount.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvbankaccount.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvbankaccount.ThemeStyle.HeaderStyle.Height = 34;
            this.dgvbankaccount.ThemeStyle.ReadOnly = false;
            this.dgvbankaccount.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvbankaccount.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvbankaccount.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvbankaccount.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvbankaccount.ThemeStyle.RowsStyle.Height = 22;
            this.dgvbankaccount.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvbankaccount.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvbankaccount.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbankaccount_CellDoubleClick);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.btnminimize);
            this.guna2Panel2.Controls.Add(this.btncancel);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.ForeColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(820, 32);
            this.guna2Panel2.TabIndex = 0;
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
            this.btnminimize.Location = new System.Drawing.Point(757, 4);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(24, 24);
            this.btnminimize.TabIndex = 441;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
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
            this.btncancel.Location = new System.Drawing.Point(777, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(26, 24);
            this.btncancel.TabIndex = 45;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label7.Location = new System.Drawing.Point(381, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Opening bal :";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.button1);
            this.guna2Panel1.Controls.Add(this.textBox2);
            this.guna2Panel1.Controls.Add(this.btnclick);
            this.guna2Panel1.Controls.Add(this.dtpdate);
            this.guna2Panel1.Controls.Add(this.btnsave);
            this.guna2Panel1.Controls.Add(this.btnupdate);
            this.guna2Panel1.Controls.Add(this.btnprint);
            this.guna2Panel1.Controls.Add(this.txtOpeningBal);
            this.guna2Panel1.Controls.Add(this.txtAccountNo);
            this.guna2Panel1.Controls.Add(this.txtBankName);
            this.guna2Panel1.Controls.Add(this.txtAccountName);
            this.guna2Panel1.Controls.Add(this.label7);
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.dgvbankaccount);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(820, 544);
            this.guna2Panel1.TabIndex = 3;
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
            this.button1.Location = new System.Drawing.Point(62, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 443;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 156);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(137, 20);
            this.textBox2.TabIndex = 442;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // CompanyBankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "CompanyBankAccount";
            this.Size = new System.Drawing.Size(820, 544);
            this.Load += new System.EventHandler(this.CompanyBankAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbankaccount)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnclick;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnprint;
        private Guna.UI2.WinForms.Guna2TextBox txtOpeningBal;
        private Guna.UI2.WinForms.Guna2TextBox txtAccountNo;
        private Guna.UI2.WinForms.Guna2TextBox txtBankName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtAccountName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvbankaccount;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
    }
}
