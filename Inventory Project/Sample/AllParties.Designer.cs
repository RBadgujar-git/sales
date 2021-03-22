namespace sample
{
    partial class AllParties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllParties));
            this.cmballparties = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkdate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cmbbalparty = new Guna.UI2.WinForms.Guna2CheckBox();
            this.dgvAllparties = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txttotalRecieve = new Guna.UI2.WinForms.Guna2TextBox();
            this.txttotalPayable = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnminimize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllparties)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmballparties
            // 
            this.cmballparties.BackColor = System.Drawing.Color.Transparent;
            this.cmballparties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmballparties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmballparties.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballparties.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballparties.FocusedState.Parent = this.cmballparties;
            this.cmballparties.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmballparties.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmballparties.HoverState.Parent = this.cmballparties;
            this.cmballparties.ItemHeight = 30;
            this.cmballparties.Items.AddRange(new object[] {
            "All Parties"});
            this.cmballparties.ItemsAppearance.Parent = this.cmballparties;
            this.cmballparties.Location = new System.Drawing.Point(75, 40);
            this.cmballparties.Name = "cmballparties";
            this.cmballparties.ShadowDecoration.Parent = this.cmballparties;
            this.cmballparties.Size = new System.Drawing.Size(140, 36);
            this.cmballparties.StartIndex = 0;
            this.cmballparties.TabIndex = 1;
            this.cmballparties.SelectedIndexChanged += new System.EventHandler(this.cmballparties_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 84;
            this.label1.Text = "FILTER";
            // 
            // chkdate
            // 
            this.chkdate.AutoSize = true;
            this.chkdate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkdate.CheckedState.BorderRadius = 0;
            this.chkdate.CheckedState.BorderThickness = 0;
            this.chkdate.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkdate.Location = new System.Drawing.Point(377, 48);
            this.chkdate.Name = "chkdate";
            this.chkdate.Size = new System.Drawing.Size(96, 20);
            this.chkdate.TabIndex = 85;
            this.chkdate.Text = "Date Filter";
            this.chkdate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkdate.UncheckedState.BorderRadius = 0;
            this.chkdate.UncheckedState.BorderThickness = 0;
            this.chkdate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cmbbalparty
            // 
            this.cmbbalparty.AutoSize = true;
            this.cmbbalparty.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbalparty.CheckedState.BorderRadius = 0;
            this.cmbbalparty.CheckedState.BorderThickness = 0;
            this.cmbbalparty.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbalparty.Location = new System.Drawing.Point(667, 47);
            this.cmbbalparty.Name = "cmbbalparty";
            this.cmbbalparty.Size = new System.Drawing.Size(99, 20);
            this.cmbbalparty.TabIndex = 86;
            this.cmbbalparty.Text = "0 Bal Party";
            this.cmbbalparty.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cmbbalparty.UncheckedState.BorderRadius = 0;
            this.cmbbalparty.UncheckedState.BorderThickness = 0;
            this.cmbbalparty.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // dgvAllparties
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAllparties.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllparties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllparties.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllparties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAllparties.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllparties.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllparties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllparties.ColumnHeadersHeight = 18;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllparties.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllparties.EnableHeadersVisualStyles = false;
            this.dgvAllparties.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllparties.Location = new System.Drawing.Point(4, 101);
            this.dgvAllparties.Name = "dgvAllparties";
            this.dgvAllparties.RowHeadersVisible = false;
            this.dgvAllparties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllparties.Size = new System.Drawing.Size(989, 362);
            this.dgvAllparties.TabIndex = 87;
            this.dgvAllparties.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvAllparties.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllparties.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAllparties.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAllparties.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvAllparties.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvAllparties.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllparties.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllparties.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvAllparties.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAllparties.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllparties.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAllparties.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvAllparties.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvAllparties.ThemeStyle.ReadOnly = false;
            this.dgvAllparties.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllparties.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllparties.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllparties.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAllparties.ThemeStyle.RowsStyle.Height = 22;
            this.dgvAllparties.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllparties.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAllparties.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllparties_CellContentClick);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txttotalRecieve);
            this.guna2Panel1.Controls.Add(this.txttotalPayable);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 493);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(999, 75);
            this.guna2Panel1.TabIndex = 88;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // txttotalRecieve
            // 
            this.txttotalRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalRecieve.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalRecieve.DefaultText = "";
            this.txttotalRecieve.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotalRecieve.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotalRecieve.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalRecieve.DisabledState.Parent = this.txttotalRecieve;
            this.txttotalRecieve.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalRecieve.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalRecieve.FocusedState.Parent = this.txttotalRecieve;
            this.txttotalRecieve.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotalRecieve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttotalRecieve.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalRecieve.HoverState.Parent = this.txttotalRecieve;
            this.txttotalRecieve.Location = new System.Drawing.Point(593, 11);
            this.txttotalRecieve.Name = "txttotalRecieve";
            this.txttotalRecieve.PasswordChar = '\0';
            this.txttotalRecieve.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttotalRecieve.PlaceholderText = "0";
            this.txttotalRecieve.SelectedText = "";
            this.txttotalRecieve.ShadowDecoration.Parent = this.txttotalRecieve;
            this.txttotalRecieve.Size = new System.Drawing.Size(91, 36);
            this.txttotalRecieve.TabIndex = 78;
            this.txttotalRecieve.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttotalPayable
            // 
            this.txttotalPayable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalPayable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotalPayable.DefaultText = "";
            this.txttotalPayable.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotalPayable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotalPayable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalPayable.DisabledState.Parent = this.txttotalPayable;
            this.txttotalPayable.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotalPayable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalPayable.FocusedState.Parent = this.txttotalPayable;
            this.txttotalPayable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotalPayable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttotalPayable.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotalPayable.HoverState.Parent = this.txttotalPayable;
            this.txttotalPayable.Location = new System.Drawing.Point(812, 13);
            this.txttotalPayable.Name = "txttotalPayable";
            this.txttotalPayable.PasswordChar = '\0';
            this.txttotalPayable.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttotalPayable.PlaceholderText = "0";
            this.txttotalPayable.SelectedText = "";
            this.txttotalPayable.ShadowDecoration.Parent = this.txttotalPayable;
            this.txttotalPayable.Size = new System.Drawing.Size(91, 36);
            this.txttotalPayable.TabIndex = 69;
            this.txttotalPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total :";
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "MM/dd/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(479, 45);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(161, 23);
            this.dtpdate.TabIndex = 2;
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
            this.btncancel.Location = new System.Drawing.Point(950, 3);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(28, 26);
            this.btncancel.TabIndex = 80;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(918, 40);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(22, 28);
            this.btnPrint.TabIndex = 79;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(878, 45);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(20, 20);
            this.btnimport.TabIndex = 78;
            this.btnimport.UseVisualStyleBackColor = false;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
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
            this.btnminimize.Location = new System.Drawing.Point(918, 3);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 437;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // AllParties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvAllparties);
            this.Controls.Add(this.cmbbalparty);
            this.Controls.Add(this.chkdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmballparties);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnimport);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllParties";
            this.Size = new System.Drawing.Size(999, 568);
            this.Load += new System.EventHandler(this.AllParties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllparties)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnimport;
        private Guna.UI2.WinForms.Guna2ComboBox cmballparties;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CheckBox chkdate;
        private Guna.UI2.WinForms.Guna2CheckBox cmbbalparty;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAllparties;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txttotalRecieve;
        private Guna.UI2.WinForms.Guna2TextBox txttotalPayable;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnminimize;
    }
}
