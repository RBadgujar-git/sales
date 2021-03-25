namespace sample
{
    partial class BankAccount
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankAccount));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnclick = new System.Windows.Forms.Button();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtopeningbal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtaccountno = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtbankname = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtaccountname = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvbankaccount = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnminimize = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbankaccount)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.AutoScroll = true;
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.button1);
            this.guna2Panel1.Controls.Add(this.textBox2);
            this.guna2Panel1.Controls.Add(this.btnclick);
            this.guna2Panel1.Controls.Add(this.dtpdate);
            this.guna2Panel1.Controls.Add(this.btnsave);
            this.guna2Panel1.Controls.Add(this.btnupdate);
            this.guna2Panel1.Controls.Add(this.btnprint);
            this.guna2Panel1.Controls.Add(this.txtopeningbal);
            this.guna2Panel1.Controls.Add(this.txtaccountno);
            this.guna2Panel1.Controls.Add(this.txtbankname);
            this.guna2Panel1.Controls.Add(this.txtaccountname);
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
            this.guna2Panel1.Size = new System.Drawing.Size(840, 522);
            this.guna2Panel1.TabIndex = 2;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btnclick
            // 
            this.btnclick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnclick.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclick.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnclick.Location = new System.Drawing.Point(675, 155);
            this.btnclick.Name = "btnclick";
            this.btnclick.Size = new System.Drawing.Size(90, 35);
            this.btnclick.TabIndex = 9;
            this.btnclick.Text = "Clear";
            this.btnclick.UseVisualStyleBackColor = false;
            this.btnclick.Click += new System.EventHandler(this.btn_Click);
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "MM/dd/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(467, 104);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(200, 23);
            this.dtpdate.TabIndex = 5;
            this.dtpdate.ValueChanged += new System.EventHandler(this.dtpdate_ValueChanged);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnsave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsave.Location = new System.Drawing.Point(380, 156);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(90, 35);
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
            this.btnupdate.Location = new System.Drawing.Point(479, 155);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(90, 35);
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
            this.btnprint.Location = new System.Drawing.Point(577, 155);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(90, 35);
            this.btnprint.TabIndex = 8;
            this.btnprint.Text = "Delete";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtopeningbal
            // 
            this.txtopeningbal.BackColor = System.Drawing.Color.LightGray;
            this.txtopeningbal.BorderColor = System.Drawing.Color.Gray;
            this.txtopeningbal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtopeningbal.DefaultText = "0";
            this.txtopeningbal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtopeningbal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtopeningbal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtopeningbal.DisabledState.Parent = this.txtopeningbal;
            this.txtopeningbal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtopeningbal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtopeningbal.FocusedState.Parent = this.txtopeningbal;
            this.txtopeningbal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtopeningbal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtopeningbal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtopeningbal.HoverState.Parent = this.txtopeningbal;
            this.txtopeningbal.Location = new System.Drawing.Point(467, 65);
            this.txtopeningbal.MaxLength = 1000;
            this.txtopeningbal.Name = "txtopeningbal";
            this.txtopeningbal.PasswordChar = '\0';
            this.txtopeningbal.PlaceholderText = "";
            this.txtopeningbal.SelectedText = "";
            this.txtopeningbal.SelectionStart = 1;
            this.txtopeningbal.ShadowDecoration.Parent = this.txtopeningbal;
            this.txtopeningbal.Size = new System.Drawing.Size(200, 24);
            this.txtopeningbal.TabIndex = 4;
            this.txtopeningbal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtopeningbal.TextChanged += new System.EventHandler(this.txtopeningbal_TextChanged);
            this.txtopeningbal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtopeningbal_KeyPress);
            // 
            // txtaccountno
            // 
            this.txtaccountno.BorderColor = System.Drawing.Color.Gray;
            this.txtaccountno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtaccountno.DefaultText = "";
            this.txtaccountno.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtaccountno.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtaccountno.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtaccountno.DisabledState.Parent = this.txtaccountno;
            this.txtaccountno.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtaccountno.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtaccountno.FocusedState.Parent = this.txtaccountno;
            this.txtaccountno.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtaccountno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtaccountno.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtaccountno.HoverState.Parent = this.txtaccountno;
            this.txtaccountno.Location = new System.Drawing.Point(144, 166);
            this.txtaccountno.MaxLength = 20;
            this.txtaccountno.Name = "txtaccountno";
            this.txtaccountno.PasswordChar = '\0';
            this.txtaccountno.PlaceholderText = "";
            this.txtaccountno.SelectedText = "";
            this.txtaccountno.ShadowDecoration.Parent = this.txtaccountno;
            this.txtaccountno.Size = new System.Drawing.Size(200, 24);
            this.txtaccountno.TabIndex = 3;
            this.txtaccountno.TextChanged += new System.EventHandler(this.txtaccountno_TextChanged);
            this.txtaccountno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccountno_KeyPress);
            // 
            // txtbankname
            // 
            this.txtbankname.BorderColor = System.Drawing.Color.Gray;
            this.txtbankname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbankname.DefaultText = "";
            this.txtbankname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbankname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbankname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbankname.DisabledState.Parent = this.txtbankname;
            this.txtbankname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbankname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbankname.FocusedState.Parent = this.txtbankname;
            this.txtbankname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbankname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtbankname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbankname.HoverState.Parent = this.txtbankname;
            this.txtbankname.Location = new System.Drawing.Point(144, 68);
            this.txtbankname.MaxLength = 50;
            this.txtbankname.Name = "txtbankname";
            this.txtbankname.PasswordChar = '\0';
            this.txtbankname.PlaceholderText = "";
            this.txtbankname.SelectedText = "";
            this.txtbankname.ShadowDecoration.Parent = this.txtbankname;
            this.txtbankname.Size = new System.Drawing.Size(200, 24);
            this.txtbankname.TabIndex = 1;
            this.txtbankname.TextChanged += new System.EventHandler(this.txtbankname_TextChanged);
            this.txtbankname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbankname_KeyPress);
            // 
            // txtaccountname
            // 
            this.txtaccountname.BorderColor = System.Drawing.Color.Gray;
            this.txtaccountname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtaccountname.DefaultText = "";
            this.txtaccountname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtaccountname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtaccountname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtaccountname.DisabledState.Parent = this.txtaccountname;
            this.txtaccountname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtaccountname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtaccountname.FocusedState.Parent = this.txtaccountname;
            this.txtaccountname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtaccountname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtaccountname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtaccountname.HoverState.Parent = this.txtaccountname;
            this.txtaccountname.Location = new System.Drawing.Point(144, 116);
            this.txtaccountname.MaxLength = 50;
            this.txtaccountname.Name = "txtaccountname";
            this.txtaccountname.PasswordChar = '\0';
            this.txtaccountname.PlaceholderText = "";
            this.txtaccountname.SelectedText = "";
            this.txtaccountname.ShadowDecoration.Parent = this.txtaccountname;
            this.txtaccountname.Size = new System.Drawing.Size(200, 24);
            this.txtaccountname.TabIndex = 2;
            this.txtaccountname.TextChanged += new System.EventHandler(this.txtaccountname_TextChanged);
            this.txtaccountname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccountname_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Opening bal :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Account Name :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Account No :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank Name :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvbankaccount
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvbankaccount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvbankaccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbankaccount.BackgroundColor = System.Drawing.Color.White;
            this.dgvbankaccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvbankaccount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvbankaccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbankaccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvbankaccount.ColumnHeadersHeight = 34;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbankaccount.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvbankaccount.EnableHeadersVisualStyles = false;
            this.dgvbankaccount.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvbankaccount.Location = new System.Drawing.Point(29, 239);
            this.dgvbankaccount.Margin = new System.Windows.Forms.Padding(4);
            this.dgvbankaccount.Name = "dgvbankaccount";
            this.dgvbankaccount.RowHeadersVisible = false;
            this.dgvbankaccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbankaccount.Size = new System.Drawing.Size(788, 270);
            this.dgvbankaccount.TabIndex = 0;
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
            this.dgvbankaccount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbankaccount_CellContentClick);
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
            this.guna2Panel2.Size = new System.Drawing.Size(840, 32);
            this.guna2Panel2.TabIndex = 0;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint);
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
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(356, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bank Account";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.button1.Location = new System.Drawing.Point(230, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 441;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(48, 209);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 23);
            this.textBox2.TabIndex = 440;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // BankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(840, 522);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BankAccount";
            this.Text = "BankAccount";
            this.Load += new System.EventHandler(this.BankAccount_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbankaccount)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Button btnclick;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnprint;
        private Guna.UI2.WinForms.Guna2TextBox txtopeningbal;
        private Guna.UI2.WinForms.Guna2TextBox txtaccountno;
        private Guna.UI2.WinForms.Guna2TextBox txtbankname;
        private Guna.UI2.WinForms.Guna2TextBox txtaccountname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvbankaccount;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
    }
}