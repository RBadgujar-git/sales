namespace sample
{
    partial class ProfitLossReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfitLossReport));
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cmbAllFirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(64, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 16);
            this.label13.TabIndex = 51;
            this.label13.Text = "Profit and Loss Report";
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
            this.btnCancel.Location = new System.Drawing.Point(983, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(29, 26);
            this.btnCancel.TabIndex = 50;
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
            this.btnPrint.Location = new System.Drawing.Point(936, 39);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(28, 22);
            this.btnPrint.TabIndex = 49;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(902, 42);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(23, 19);
            this.btnImport.TabIndex = 48;
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // cmbAllFirms
            // 
            this.cmbAllFirms.BackColor = System.Drawing.Color.Transparent;
            this.cmbAllFirms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAllFirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllFirms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllFirms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllFirms.FocusedState.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllFirms.ForeColor = System.Drawing.Color.Blue;
            this.cmbAllFirms.HoverState.Parent = this.cmbAllFirms;
            this.cmbAllFirms.ItemHeight = 30;
            this.cmbAllFirms.Items.AddRange(new object[] {
            "All Firms"});
            this.cmbAllFirms.ItemsAppearance.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Location = new System.Drawing.Point(105, 44);
            this.cmbAllFirms.Name = "cmbAllFirms";
            this.cmbAllFirms.ShadowDecoration.Parent = this.cmbAllFirms;
            this.cmbAllFirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAllFirms.StartIndex = 0;
            this.cmbAllFirms.TabIndex = 46;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(51, 132);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1021, 444);
            this.guna2ShadowPanel1.TabIndex = 52;
            this.guna2ShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/dd/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(270, 49);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(159, 23);
            this.dtpDate.TabIndex = 53;
            // 
            // ProfitLossReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cmbAllFirms);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProfitLossReport";
            this.Size = new System.Drawing.Size(1027, 569);
            this.Load += new System.EventHandler(this.ProfitLossReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAllFirms;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}
