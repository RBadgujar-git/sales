namespace sample
{
    partial class DeliveryChallanHomepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryChallanHomepage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btndeliveryChallan = new Guna.UI2.WinForms.Guna2Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvdeliveryChallan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dtptodate = new System.Windows.Forms.DateTimePicker();
            this.dtpfromdate = new System.Windows.Forms.DateTimePicker();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnminimize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeliveryChallan)).BeginInit();
            this.SuspendLayout();
            // 
            // btndeliveryChallan
            // 
            this.btndeliveryChallan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndeliveryChallan.CheckedState.Parent = this.btndeliveryChallan;
            this.btndeliveryChallan.CustomImages.Parent = this.btndeliveryChallan;
            this.btndeliveryChallan.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeliveryChallan.ForeColor = System.Drawing.Color.White;
            this.btndeliveryChallan.HoverState.Parent = this.btndeliveryChallan;
            this.btndeliveryChallan.Location = new System.Drawing.Point(820, 107);
            this.btndeliveryChallan.Name = "btndeliveryChallan";
            this.btndeliveryChallan.ShadowDecoration.Parent = this.btndeliveryChallan;
            this.btndeliveryChallan.Size = new System.Drawing.Size(211, 45);
            this.btndeliveryChallan.TabIndex = 196;
            this.btndeliveryChallan.Text = "+Add Delivery Challan";
            this.btndeliveryChallan.Click += new System.EventHandler(this.guna2Button1_Click);
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
            this.btncancel.Location = new System.Drawing.Point(994, 7);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(28, 26);
            this.btncancel.TabIndex = 193;
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
            this.btnPrint.Location = new System.Drawing.Point(993, 44);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 25);
            this.btnPrint.TabIndex = 192;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(945, 41);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(22, 23);
            this.btnImport.TabIndex = 191;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Visible = false;
            // 
            // dgvdeliveryChallan
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvdeliveryChallan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdeliveryChallan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdeliveryChallan.BackgroundColor = System.Drawing.Color.White;
            this.dgvdeliveryChallan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvdeliveryChallan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvdeliveryChallan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdeliveryChallan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdeliveryChallan.ColumnHeadersHeight = 18;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdeliveryChallan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdeliveryChallan.EnableHeadersVisualStyles = false;
            this.dgvdeliveryChallan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdeliveryChallan.Location = new System.Drawing.Point(3, 171);
            this.dgvdeliveryChallan.Name = "dgvdeliveryChallan";
            this.dgvdeliveryChallan.RowHeadersVisible = false;
            this.dgvdeliveryChallan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdeliveryChallan.Size = new System.Drawing.Size(1072, 386);
            this.dgvdeliveryChallan.TabIndex = 202;
            this.dgvdeliveryChallan.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvdeliveryChallan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvdeliveryChallan.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvdeliveryChallan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvdeliveryChallan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvdeliveryChallan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvdeliveryChallan.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvdeliveryChallan.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdeliveryChallan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvdeliveryChallan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvdeliveryChallan.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvdeliveryChallan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvdeliveryChallan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvdeliveryChallan.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvdeliveryChallan.ThemeStyle.ReadOnly = false;
            this.dgvdeliveryChallan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvdeliveryChallan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvdeliveryChallan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvdeliveryChallan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvdeliveryChallan.ThemeStyle.RowsStyle.Height = 22;
            this.dgvdeliveryChallan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvdeliveryChallan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            // 
            // dtptodate
            // 
            this.dtptodate.CustomFormat = "MM/dd/yyyy";
            this.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptodate.Location = new System.Drawing.Point(416, 41);
            this.dtptodate.Name = "dtptodate";
            this.dtptodate.Size = new System.Drawing.Size(141, 23);
            this.dtptodate.TabIndex = 233;
            this.dtptodate.ValueChanged += new System.EventHandler(this.dtptodate_ValueChanged);
            // 
            // dtpfromdate
            // 
            this.dtpfromdate.CustomFormat = "MM/dd/yyyy";
            this.dtpfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfromdate.Location = new System.Drawing.Point(235, 41);
            this.dtpfromdate.Name = "dtpfromdate";
            this.dtpfromdate.Size = new System.Drawing.Size(136, 23);
            this.dtpfromdate.TabIndex = 232;
            // 
            // txtFilter
            // 
            this.txtFilter.BorderColor = System.Drawing.Color.Gray;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.DefaultText = "";
            this.txtFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.DisabledState.Parent = this.txtFilter;
            this.txtFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.FocusedState.Parent = this.txtFilter;
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.HoverState.Parent = this.txtFilter;
            this.txtFilter.Location = new System.Drawing.Point(106, 108);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PasswordChar = '\0';
            this.txtFilter.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFilter.PlaceholderText = "Party Name";
            this.txtFilter.SelectedText = "";
            this.txtFilter.ShadowDecoration.Parent = this.txtFilter;
            this.txtFilter.Size = new System.Drawing.Size(200, 36);
            this.txtFilter.TabIndex = 231;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 230;
            this.label3.Text = " Filter by :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 228;
            this.label1.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 16);
            this.label5.TabIndex = 229;
            this.label5.Text = "To";
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
            this.btnminimize.Location = new System.Drawing.Point(934, 5);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 458;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 16);
            this.label6.TabIndex = 460;
            this.label6.Text = "All Transaction";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1020, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 461;
            this.label2.Text = "Print";
            // 
            // DeliveryChallanHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtptodate);
            this.Controls.Add(this.dtpfromdate);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvdeliveryChallan);
            this.Controls.Add(this.btndeliveryChallan);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DeliveryChallanHomepage";
            this.Size = new System.Drawing.Size(1072, 574);
            this.Load += new System.EventHandler(this.DeliveryChallanHomepage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeliveryChallan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btndeliveryChallan;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvdeliveryChallan;
        private System.Windows.Forms.DateTimePicker dtptodate;
        private System.Windows.Forms.DateTimePicker dtpfromdate;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
    }
}
