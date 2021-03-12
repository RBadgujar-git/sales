namespace sample
{
    partial class SalePurchaseOrderReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalePurchaseOrderReport));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvSaleorder = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmbAlllFirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDaate = new System.Windows.Forms.DateTimePicker();
            this.cmbtable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnminimize = new System.Windows.Forms.Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleorder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(677, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 137;
            this.label1.Text = "Total Amount :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalAmount.DefaultText = "";
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
            this.txtTotalAmount.Location = new System.Drawing.Point(790, 8);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.PasswordChar = '\0';
            this.txtTotalAmount.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtTotalAmount.PlaceholderText = "0";
            this.txtTotalAmount.SelectedText = "";
            this.txtTotalAmount.ShadowDecoration.Parent = this.txtTotalAmount;
            this.txtTotalAmount.Size = new System.Drawing.Size(200, 36);
            this.txtTotalAmount.TabIndex = 138;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txtTotalAmount);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 516);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1007, 53);
            this.guna2Panel1.TabIndex = 187;
            // 
            // dgvSaleorder
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvSaleorder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSaleorder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleorder.BackgroundColor = System.Drawing.Color.White;
            this.dgvSaleorder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSaleorder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSaleorder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleorder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSaleorder.ColumnHeadersHeight = 18;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleorder.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSaleorder.EnableHeadersVisualStyles = false;
            this.dgvSaleorder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSaleorder.Location = new System.Drawing.Point(11, 137);
            this.dgvSaleorder.Name = "dgvSaleorder";
            this.dgvSaleorder.RowHeadersVisible = false;
            this.dgvSaleorder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleorder.Size = new System.Drawing.Size(996, 373);
            this.dgvSaleorder.TabIndex = 186;
            this.dgvSaleorder.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvSaleorder.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSaleorder.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSaleorder.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSaleorder.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSaleorder.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSaleorder.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSaleorder.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSaleorder.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSaleorder.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSaleorder.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSaleorder.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSaleorder.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSaleorder.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvSaleorder.ThemeStyle.ReadOnly = false;
            this.dgvSaleorder.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSaleorder.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSaleorder.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSaleorder.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSaleorder.ThemeStyle.RowsStyle.Height = 22;
            this.dgvSaleorder.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSaleorder.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSaleorder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleorder_CellContentClick);
            // 
            // cmbAlllFirms
            // 
            this.cmbAlllFirms.BackColor = System.Drawing.Color.Transparent;
            this.cmbAlllFirms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAlllFirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlllFirms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAlllFirms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAlllFirms.FocusedState.Parent = this.cmbAlllFirms;
            this.cmbAlllFirms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbAlllFirms.ForeColor = System.Drawing.Color.Blue;
            this.cmbAlllFirms.HoverState.Parent = this.cmbAlllFirms;
            this.cmbAlllFirms.ItemHeight = 30;
            this.cmbAlllFirms.Items.AddRange(new object[] {
            "All Firms"});
            this.cmbAlllFirms.ItemsAppearance.Parent = this.cmbAlllFirms;
            this.cmbAlllFirms.Location = new System.Drawing.Point(51, 24);
            this.cmbAlllFirms.Name = "cmbAlllFirms";
            this.cmbAlllFirms.ShadowDecoration.Parent = this.cmbAlllFirms;
            this.cmbAlllFirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAlllFirms.StartIndex = 0;
            this.cmbAlllFirms.TabIndex = 185;
            this.cmbAlllFirms.SelectedIndexChanged += new System.EventHandler(this.cmbAlllFirms_SelectedIndexChanged);
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
            this.btnCancel.Location = new System.Drawing.Point(973, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 26);
            this.btnCancel.TabIndex = 180;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(864, 37);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(22, 23);
            this.btnImport.TabIndex = 178;
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 182;
            this.label6.Text = "From";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(908, 37);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 23);
            this.btnPrint.TabIndex = 179;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 184;
            this.label5.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 191;
            this.label3.Text = "FILTER";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MM/dd/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(248, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(138, 23);
            this.dtpFromDate.TabIndex = 192;
            // 
            // dtpToDaate
            // 
            this.dtpToDaate.CustomFormat = "MM/dd/yyyy";
            this.dtpToDaate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDaate.Location = new System.Drawing.Point(438, 25);
            this.dtpToDaate.Name = "dtpToDaate";
            this.dtpToDaate.Size = new System.Drawing.Size(140, 23);
            this.dtpToDaate.TabIndex = 193;
            this.dtpToDaate.ValueChanged += new System.EventHandler(this.dtpToDaate_ValueChanged);
            this.dtpToDaate.Enter += new System.EventHandler(this.dtpToDaate_Enter);
            // 
            // cmbtable
            // 
            this.cmbtable.BackColor = System.Drawing.Color.Transparent;
            this.cmbtable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbtable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtable.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbtable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbtable.FocusedState.Parent = this.cmbtable;
            this.cmbtable.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbtable.ForeColor = System.Drawing.Color.Blue;
            this.cmbtable.HoverState.Parent = this.cmbtable;
            this.cmbtable.ItemHeight = 30;
            this.cmbtable.Items.AddRange(new object[] {
            "Sale Order",
            "Purchase Order"});
            this.cmbtable.ItemsAppearance.Parent = this.cmbtable;
            this.cmbtable.Location = new System.Drawing.Point(95, 87);
            this.cmbtable.Name = "cmbtable";
            this.cmbtable.ShadowDecoration.Parent = this.cmbtable;
            this.cmbtable.Size = new System.Drawing.Size(193, 36);
            this.cmbtable.StartIndex = 0;
            this.cmbtable.TabIndex = 194;
            this.cmbtable.Visible = false;
            this.cmbtable.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
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
            this.btnminimize.Location = new System.Drawing.Point(941, 6);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 454;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // SalePurchaseOrderReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.cmbtable);
            this.Controls.Add(this.dtpToDaate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dgvSaleorder);
            this.Controls.Add(this.cmbAlllFirms);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SalePurchaseOrderReport";
            this.Size = new System.Drawing.Size(1007, 569);
            this.Load += new System.EventHandler(this.SalePurchaseOrderReport_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalAmount;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSaleorder;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAlllFirms;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDaate;
        private Guna.UI2.WinForms.Guna2ComboBox cmbtable;
        private System.Windows.Forms.Button btnminimize;
    }
}
