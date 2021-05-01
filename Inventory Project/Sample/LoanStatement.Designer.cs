namespace sample
{
    partial class LoanStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanStatement));
            this.cmbAccount = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmballFirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvLoanStatement = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttotalPrinciple = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtOpeningBal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txttBalancedue = new Guna.UI2.WinForms.Guna2TextBox();
            this.txttotalInterest = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnminimize = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanStatement)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAccount
            // 
            this.cmbAccount.BackColor = System.Drawing.Color.Transparent;
            this.cmbAccount.BorderColor = System.Drawing.Color.Gray;
            this.cmbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAccount.FocusedState.Parent = this.cmbAccount;
            this.cmbAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbAccount.HoverState.Parent = this.cmbAccount;
            this.cmbAccount.ItemHeight = 30;
            this.cmbAccount.Items.AddRange(new object[] {
            "Account"});
            this.cmbAccount.ItemsAppearance.Parent = this.cmbAccount;
            this.cmbAccount.Location = new System.Drawing.Point(199, 44);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.ShadowDecoration.Parent = this.cmbAccount;
            this.cmbAccount.Size = new System.Drawing.Size(189, 36);
            this.cmbAccount.StartIndex = 0;
            this.cmbAccount.TabIndex = 2;
            this.cmbAccount.SelectedIndexChanged += new System.EventHandler(this.cmbAccount_SelectedIndexChanged);
            // 
            // cmballFirms
            // 
            this.cmballFirms.BackColor = System.Drawing.Color.Transparent;
            this.cmballFirms.BorderColor = System.Drawing.Color.Gray;
            this.cmballFirms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmballFirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmballFirms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballFirms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballFirms.FocusedState.Parent = this.cmballFirms;
            this.cmballFirms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmballFirms.ForeColor = System.Drawing.Color.Blue;
            this.cmballFirms.HoverState.Parent = this.cmballFirms;
            this.cmballFirms.ItemHeight = 30;
            this.cmballFirms.Items.AddRange(new object[] {
            "All Firms"});
            this.cmballFirms.ItemsAppearance.Parent = this.cmballFirms;
            this.cmballFirms.Location = new System.Drawing.Point(35, 44);
            this.cmballFirms.Name = "cmballFirms";
            this.cmballFirms.ShadowDecoration.Parent = this.cmballFirms;
            this.cmballFirms.Size = new System.Drawing.Size(140, 36);
            this.cmballFirms.StartIndex = 0;
            this.cmballFirms.TabIndex = 1;
            this.cmballFirms.SelectedIndexChanged += new System.EventHandler(this.cmballFirms_SelectedIndexChanged);
            // 
            // dgvLoanStatement
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvLoanStatement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLoanStatement.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgvLoanStatement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoanStatement.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoanStatement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoanStatement.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLoanStatement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoanStatement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLoanStatement.ColumnHeadersHeight = 18;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoanStatement.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLoanStatement.EnableHeadersVisualStyles = false;
            this.dgvLoanStatement.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLoanStatement.Location = new System.Drawing.Point(3, 110);
            this.dgvLoanStatement.Name = "dgvLoanStatement";
            this.dgvLoanStatement.RowHeadersVisible = false;
            this.dgvLoanStatement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanStatement.Size = new System.Drawing.Size(871, 303);
            this.dgvLoanStatement.TabIndex = 211;
            this.dgvLoanStatement.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvLoanStatement.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLoanStatement.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLoanStatement.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLoanStatement.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLoanStatement.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLoanStatement.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLoanStatement.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLoanStatement.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLoanStatement.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLoanStatement.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLoanStatement.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLoanStatement.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLoanStatement.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvLoanStatement.ThemeStyle.ReadOnly = false;
            this.dgvLoanStatement.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLoanStatement.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLoanStatement.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLoanStatement.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvLoanStatement.ThemeStyle.RowsStyle.Height = 22;
            this.dgvLoanStatement.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLoanStatement.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvLoanStatement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoanStatement_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loan Account Summary ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opening Balance :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 509);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = " Balance Due:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(513, 477);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Total Principle Paid :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Interest Paid :";
            // 
            // txttotalPrinciple
            // 
            this.txttotalPrinciple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalPrinciple.BorderColor = System.Drawing.Color.Gray;
            this.txttotalPrinciple.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalPrinciple.DefaultText = "";
            this.txttotalPrinciple.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotalPrinciple.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotalPrinciple.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalPrinciple.DisabledState.Parent = this.txttotalPrinciple;
            this.txttotalPrinciple.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalPrinciple.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalPrinciple.FocusedState.Parent = this.txttotalPrinciple;
            this.txttotalPrinciple.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotalPrinciple.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttotalPrinciple.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalPrinciple.HoverState.Parent = this.txttotalPrinciple;
            this.txttotalPrinciple.Location = new System.Drawing.Point(662, 473);
            this.txttotalPrinciple.Name = "txttotalPrinciple";
            this.txttotalPrinciple.PasswordChar = '\0';
            this.txttotalPrinciple.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttotalPrinciple.PlaceholderText = "0";
            this.txttotalPrinciple.SelectedText = "";
            this.txttotalPrinciple.ShadowDecoration.Parent = this.txttotalPrinciple;
            this.txttotalPrinciple.Size = new System.Drawing.Size(160, 26);
            this.txttotalPrinciple.TabIndex = 6;
            this.txttotalPrinciple.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotalPrinciple.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotalPrinciple_KeyPress);
            // 
            // txtOpeningBal
            // 
            this.txtOpeningBal.BorderColor = System.Drawing.Color.Gray;
            this.txtOpeningBal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOpeningBal.DefaultText = "";
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
            this.txtOpeningBal.Location = new System.Drawing.Point(151, 474);
            this.txtOpeningBal.MaxLength = 1000;
            this.txtOpeningBal.Name = "txtOpeningBal";
            this.txtOpeningBal.PasswordChar = '\0';
            this.txtOpeningBal.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtOpeningBal.PlaceholderText = "0";
            this.txtOpeningBal.SelectedText = "";
            this.txtOpeningBal.ShadowDecoration.Parent = this.txtOpeningBal;
            this.txtOpeningBal.Size = new System.Drawing.Size(160, 26);
            this.txtOpeningBal.TabIndex = 3;
            this.txtOpeningBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOpeningBal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpeningBal_KeyPress);
            // 
            // txttBalancedue
            // 
            this.txttBalancedue.BorderColor = System.Drawing.Color.Gray;
            this.txttBalancedue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttBalancedue.DefaultText = "";
            this.txttBalancedue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttBalancedue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttBalancedue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttBalancedue.DisabledState.Parent = this.txttBalancedue;
            this.txttBalancedue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttBalancedue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttBalancedue.FocusedState.Parent = this.txttBalancedue;
            this.txttBalancedue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttBalancedue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttBalancedue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttBalancedue.HoverState.Parent = this.txttBalancedue;
            this.txttBalancedue.Location = new System.Drawing.Point(151, 505);
            this.txttBalancedue.Name = "txttBalancedue";
            this.txttBalancedue.PasswordChar = '\0';
            this.txttBalancedue.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttBalancedue.PlaceholderText = "0";
            this.txttBalancedue.SelectedText = "";
            this.txttBalancedue.ShadowDecoration.Parent = this.txttBalancedue;
            this.txttBalancedue.Size = new System.Drawing.Size(160, 26);
            this.txttBalancedue.TabIndex = 5;
            this.txttBalancedue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttBalancedue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttBalancedue_KeyPress);
            // 
            // txttotalInterest
            // 
            this.txttotalInterest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalInterest.BorderColor = System.Drawing.Color.Gray;
            this.txttotalInterest.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalInterest.DefaultText = "";
            this.txttotalInterest.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotalInterest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotalInterest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalInterest.DisabledState.Parent = this.txttotalInterest;
            this.txttotalInterest.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalInterest.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalInterest.FocusedState.Parent = this.txttotalInterest;
            this.txttotalInterest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotalInterest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttotalInterest.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalInterest.HoverState.Parent = this.txttotalInterest;
            this.txttotalInterest.Location = new System.Drawing.Point(662, 504);
            this.txttotalInterest.Name = "txttotalInterest";
            this.txttotalInterest.PasswordChar = '\0';
            this.txttotalInterest.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttotalInterest.PlaceholderText = "0";
            this.txttotalInterest.SelectedText = "";
            this.txttotalInterest.ShadowDecoration.Parent = this.txttotalInterest;
            this.txttotalInterest.Size = new System.Drawing.Size(160, 26);
            this.txttotalInterest.TabIndex = 6;
            this.txttotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotalInterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotalInterest_KeyPress);
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
            this.btnminimize.Location = new System.Drawing.Point(706, 15);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 449;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(784, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 205;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(706, 60);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(20, 20);
            this.btnImport.TabIndex = 203;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(784, 55);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 25);
            this.btnPrint.TabIndex = 204;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(714, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 485;
            this.label5.Text = "Print";
            // 
            // LoanStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttotalInterest);
            this.Controls.Add(this.txttBalancedue);
            this.Controls.Add(this.dgvLoanStatement);
            this.Controls.Add(this.txtOpeningBal);
            this.Controls.Add(this.cmballFirms);
            this.Controls.Add(this.txttotalPrinciple);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbAccount);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoanStatement";
            this.Size = new System.Drawing.Size(877, 605);
            this.Load += new System.EventHandler(this.LoanStatement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanStatement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbAccount;
        private Guna.UI2.WinForms.Guna2ComboBox cmballFirms;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnPrint;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLoanStatement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txttotalPrinciple;
        private Guna.UI2.WinForms.Guna2TextBox txtOpeningBal;
        private Guna.UI2.WinForms.Guna2TextBox txttBalancedue;
        private Guna.UI2.WinForms.Guna2TextBox txttotalInterest;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Label label5;
    }
}
