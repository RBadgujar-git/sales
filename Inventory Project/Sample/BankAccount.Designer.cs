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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankAccount));
            this.label1 = new System.Windows.Forms.Label();
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
            this.btncancel = new System.Windows.Forms.Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbankaccount)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(353, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bank Account";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.AutoScroll = true;
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
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
            this.btnclick.Location = new System.Drawing.Point(668, 164);
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
            this.dtpdate.Location = new System.Drawing.Point(460, 113);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(200, 23);
            this.dtpdate.TabIndex = 5;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnsave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsave.Location = new System.Drawing.Point(373, 165);
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
            this.btnupdate.Location = new System.Drawing.Point(472, 164);
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
            this.btnprint.Location = new System.Drawing.Point(570, 164);
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
            this.txtopeningbal.Location = new System.Drawing.Point(460, 74);
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
            this.txtopeningbal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtopeningbal_KeyPress);
            // 
            // txtaccountno
            // 
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
            this.txtaccountno.Location = new System.Drawing.Point(137, 175);
            this.txtaccountno.MaxLength = 20;
            this.txtaccountno.Name = "txtaccountno";
            this.txtaccountno.PasswordChar = '\0';
            this.txtaccountno.PlaceholderText = "";
            this.txtaccountno.SelectedText = "";
            this.txtaccountno.ShadowDecoration.Parent = this.txtaccountno;
            this.txtaccountno.Size = new System.Drawing.Size(200, 24);
            this.txtaccountno.TabIndex = 3;
            this.txtaccountno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccountno_KeyPress);
            // 
            // txtbankname
            // 
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
            this.txtbankname.Location = new System.Drawing.Point(137, 77);
            this.txtbankname.MaxLength = 50;
            this.txtbankname.Name = "txtbankname";
            this.txtbankname.PasswordChar = '\0';
            this.txtbankname.PlaceholderText = "";
            this.txtbankname.SelectedText = "";
            this.txtbankname.ShadowDecoration.Parent = this.txtbankname;
            this.txtbankname.Size = new System.Drawing.Size(200, 24);
            this.txtbankname.TabIndex = 1;
            this.txtbankname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbankname_KeyPress);
            // 
            // txtaccountname
            // 
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
            this.txtaccountname.Location = new System.Drawing.Point(137, 125);
            this.txtaccountname.MaxLength = 50;
            this.txtaccountname.Name = "txtaccountname";
            this.txtaccountname.PasswordChar = '\0';
            this.txtaccountname.PlaceholderText = "";
            this.txtaccountname.SelectedText = "";
            this.txtaccountname.ShadowDecoration.Parent = this.txtaccountname;
            this.txtaccountname.Size = new System.Drawing.Size(200, 24);
            this.txtaccountname.TabIndex = 2;
            this.txtaccountname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccountname_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 77);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Opening bal :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Account Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Account No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank Name :";
            // 
            // dgvbankaccount
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvbankaccount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvbankaccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbankaccount.BackgroundColor = System.Drawing.Color.White;
            this.dgvbankaccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvbankaccount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvbankaccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbankaccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvbankaccount.ColumnHeadersHeight = 34;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbankaccount.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvbankaccount.EnableHeadersVisualStyles = false;
            this.dgvbankaccount.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvbankaccount.Location = new System.Drawing.Point(22, 225);
            this.dgvbankaccount.Margin = new System.Windows.Forms.Padding(4);
            this.dgvbankaccount.Name = "dgvbankaccount";
            this.dgvbankaccount.RowHeadersVisible = false;
            this.dgvbankaccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbankaccount.Size = new System.Drawing.Size(788, 293);
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
        //    this.dgvbankaccount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbankaccount_CellContentClick);
            this.dgvbankaccount.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbankaccount_CellDoubleClick);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.btncancel);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.ForeColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(840, 44);
            this.guna2Panel2.TabIndex = 0;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancel.BackgroundImage")));
            this.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncancel.Location = new System.Drawing.Point(764, 6);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(29, 26);
            this.btncancel.TabIndex = 45;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
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

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtopeningbal;
        private Guna.UI2.WinForms.Guna2TextBox txtaccountno;
        private Guna.UI2.WinForms.Guna2TextBox txtbankname;
        private Guna.UI2.WinForms.Guna2TextBox txtaccountname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnsave;
        private Guna.UI2.WinForms.Guna2DataGridView dgvbankaccount;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnclick;
    }
}