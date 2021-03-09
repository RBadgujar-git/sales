namespace sample
{
    partial class AllTransactionReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllTransactionReport));
            this.dgvalltransactions = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmballfrims = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtpartyfilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmballpayment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmballtransaction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnminimize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvalltransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvalltransactions
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvalltransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvalltransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvalltransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvalltransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvalltransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvalltransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvalltransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvalltransactions.ColumnHeadersHeight = 18;
            this.dgvalltransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column9,
            this.Column6,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvalltransactions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvalltransactions.EnableHeadersVisualStyles = false;
            this.dgvalltransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvalltransactions.Location = new System.Drawing.Point(48, 163);
            this.dgvalltransactions.Name = "dgvalltransactions";
            this.dgvalltransactions.RowHeadersVisible = false;
            this.dgvalltransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvalltransactions.Size = new System.Drawing.Size(1019, 410);
            this.dgvalltransactions.TabIndex = 39;
            this.dgvalltransactions.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvalltransactions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvalltransactions.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvalltransactions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvalltransactions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvalltransactions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvalltransactions.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvalltransactions.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvalltransactions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvalltransactions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvalltransactions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvalltransactions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvalltransactions.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvalltransactions.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvalltransactions.ThemeStyle.ReadOnly = false;
            this.dgvalltransactions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvalltransactions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvalltransactions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvalltransactions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvalltransactions.ThemeStyle.RowsStyle.Height = 22;
            this.dgvalltransactions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvalltransactions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvalltransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Reference no ";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Type";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Received/Paid";
            this.Column9.Name = "Column9";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Balance";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Due Date";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Status";
            this.Column8.Name = "Column8";
            // 
            // cmballfrims
            // 
            this.cmballfrims.BackColor = System.Drawing.Color.Transparent;
            this.cmballfrims.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmballfrims.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmballfrims.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballfrims.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballfrims.FocusedState.Parent = this.cmballfrims;
            this.cmballfrims.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmballfrims.ForeColor = System.Drawing.Color.Blue;
            this.cmballfrims.HoverState.Parent = this.cmballfrims;
            this.cmballfrims.ItemHeight = 30;
            this.cmballfrims.Items.AddRange(new object[] {
            "All Firms"});
            this.cmballfrims.ItemsAppearance.Parent = this.cmballfrims;
            this.cmballfrims.Location = new System.Drawing.Point(106, 27);
            this.cmballfrims.Name = "cmballfrims";
            this.cmballfrims.ShadowDecoration.Parent = this.cmballfrims;
            this.cmballfrims.Size = new System.Drawing.Size(140, 36);
            this.cmballfrims.StartIndex = 0;
            this.cmballfrims.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(65, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Transaction";
            // 
            // txtpartyfilter
            // 
            this.txtpartyfilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpartyfilter.DefaultText = "";
            this.txtpartyfilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpartyfilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpartyfilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpartyfilter.DisabledState.Parent = this.txtpartyfilter;
            this.txtpartyfilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpartyfilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpartyfilter.FocusedState.Parent = this.txtpartyfilter;
            this.txtpartyfilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtpartyfilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtpartyfilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpartyfilter.HoverState.Parent = this.txtpartyfilter;
            this.txtpartyfilter.Location = new System.Drawing.Point(130, 115);
            this.txtpartyfilter.Name = "txtpartyfilter";
            this.txtpartyfilter.PasswordChar = '\0';
            this.txtpartyfilter.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtpartyfilter.PlaceholderText = "Party Filter";
            this.txtpartyfilter.SelectedText = "";
            this.txtpartyfilter.ShadowDecoration.Parent = this.txtpartyfilter;
            this.txtpartyfilter.Size = new System.Drawing.Size(197, 28);
            this.txtpartyfilter.TabIndex = 46;
            // 
            // cmballpayment
            // 
            this.cmballpayment.BackColor = System.Drawing.Color.Transparent;
            this.cmballpayment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmballpayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmballpayment.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballpayment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballpayment.FocusedState.Parent = this.cmballpayment;
            this.cmballpayment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmballpayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmballpayment.HoverState.Parent = this.cmballpayment;
            this.cmballpayment.ItemHeight = 30;
            this.cmballpayment.Items.AddRange(new object[] {
            "All Payment",
            "Paid",
            "Unpaid",
            "Partial",
            "Overdue"});
            this.cmballpayment.ItemsAppearance.Parent = this.cmballpayment;
            this.cmballpayment.Location = new System.Drawing.Point(533, 110);
            this.cmballpayment.Name = "cmballpayment";
            this.cmballpayment.ShadowDecoration.Parent = this.cmballpayment;
            this.cmballpayment.Size = new System.Drawing.Size(159, 36);
            this.cmballpayment.StartIndex = 0;
            this.cmballpayment.TabIndex = 47;
            // 
            // cmballtransaction
            // 
            this.cmballtransaction.BackColor = System.Drawing.Color.Transparent;
            this.cmballtransaction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmballtransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmballtransaction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballtransaction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmballtransaction.FocusedState.Parent = this.cmballtransaction;
            this.cmballtransaction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmballtransaction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmballtransaction.HoverState.Parent = this.cmballtransaction;
            this.cmballtransaction.ItemHeight = 30;
            this.cmballtransaction.Items.AddRange(new object[] {
            "All Transaction",
            "sale",
            "Purchase",
            "credit Note",
            "Debit Note",
            "Payment In",
            "Payment Out",
            "Sale Order",
            "Purchase Order",
            "Estimate",
            "Delivery Challan"});
            this.cmballtransaction.ItemsAppearance.Parent = this.cmballtransaction;
            this.cmballtransaction.Location = new System.Drawing.Point(350, 112);
            this.cmballtransaction.Name = "cmballtransaction";
            this.cmballtransaction.ShadowDecoration.Parent = this.cmballtransaction;
            this.cmballtransaction.Size = new System.Drawing.Size(169, 36);
            this.cmballtransaction.StartIndex = 0;
            this.cmballtransaction.TabIndex = 48;
            this.cmballtransaction.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox3_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "FILTER";
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "MM/dd/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(267, 35);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(153, 23);
            this.dtpdate.TabIndex = 50;
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
            this.btncancel.Location = new System.Drawing.Point(981, 5);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(29, 26);
            this.btncancel.TabIndex = 44;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.BackColor = System.Drawing.Color.Transparent;
            this.btnprint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnprint.BackgroundImage")));
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Location = new System.Drawing.Point(945, 37);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(25, 22);
            this.btnprint.TabIndex = 41;
            this.btnprint.UseVisualStyleBackColor = false;
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(900, 40);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(26, 19);
            this.btnimport.TabIndex = 40;
            this.btnimport.UseVisualStyleBackColor = false;
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
            this.btnminimize.Location = new System.Drawing.Point(949, 5);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 437;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // AllTransactionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmballtransaction);
            this.Controls.Add(this.cmballpayment);
            this.Controls.Add(this.txtpartyfilter);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.dgvalltransactions);
            this.Controls.Add(this.cmballfrims);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllTransactionReport";
            this.Size = new System.Drawing.Size(1019, 569);
            this.Load += new System.EventHandler(this.AllTransactionReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvalltransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnimport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvalltransactions;
        private Guna.UI2.WinForms.Guna2ComboBox cmballfrims;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txtpartyfilter;
        private Guna.UI2.WinForms.Guna2ComboBox cmballpayment;
        private Guna.UI2.WinForms.Guna2ComboBox cmballtransaction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnminimize;
    }
}
