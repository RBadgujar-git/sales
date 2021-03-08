namespace sample
{
    partial class Item_Tracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Item_Tracking));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpexpdate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpmfgDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtSerialNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBatchNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMRP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDate = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnminimize = new System.Windows.Forms.Button();
            this.guna2Panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.dtpexpdate);
            this.guna2Panel1.Controls.Add(this.dtpmfgDate);
            this.guna2Panel1.Controls.Add(this.txtSerialNo);
            this.guna2Panel1.Controls.Add(this.txtBatchNo);
            this.guna2Panel1.Controls.Add(this.txtMRP);
            this.guna2Panel1.Controls.Add(this.txtDate);
            this.guna2Panel1.Controls.Add(this.label12);
            this.guna2Panel1.Controls.Add(this.label6);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.panel3);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(687, 219);
            this.guna2Panel1.TabIndex = 1;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // dtpexpdate
            // 
            this.dtpexpdate.CheckedState.Parent = this.dtpexpdate;
            this.dtpexpdate.FillColor = System.Drawing.Color.White;
            this.dtpexpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpexpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpexpdate.HoverState.Parent = this.dtpexpdate;
            this.dtpexpdate.Location = new System.Drawing.Point(420, 84);
            this.dtpexpdate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpexpdate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpexpdate.Name = "dtpexpdate";
            this.dtpexpdate.ShadowDecoration.Parent = this.dtpexpdate;
            this.dtpexpdate.Size = new System.Drawing.Size(200, 25);
            this.dtpexpdate.TabIndex = 43;
            this.dtpexpdate.Value = new System.DateTime(2020, 10, 20, 14, 6, 7, 389);
            this.dtpexpdate.ValueChanged += new System.EventHandler(this.guna2DateTimePicker2_ValueChanged);
            // 
            // dtpmfgDate
            // 
            this.dtpmfgDate.CheckedState.Parent = this.dtpmfgDate;
            this.dtpmfgDate.FillColor = System.Drawing.Color.White;
            this.dtpmfgDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpmfgDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpmfgDate.HoverState.Parent = this.dtpmfgDate;
            this.dtpmfgDate.Location = new System.Drawing.Point(419, 43);
            this.dtpmfgDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpmfgDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpmfgDate.Name = "dtpmfgDate";
            this.dtpmfgDate.ShadowDecoration.Parent = this.dtpmfgDate;
            this.dtpmfgDate.Size = new System.Drawing.Size(200, 25);
            this.dtpmfgDate.TabIndex = 43;
            this.dtpmfgDate.Value = new System.DateTime(2020, 10, 20, 14, 6, 7, 389);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSerialNo.DefaultText = "";
            this.txtSerialNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSerialNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSerialNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNo.DisabledState.Parent = this.txtSerialNo;
            this.txtSerialNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNo.FocusedState.Parent = this.txtSerialNo;
            this.txtSerialNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSerialNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNo.HoverState.Parent = this.txtSerialNo;
            this.txtSerialNo.Location = new System.Drawing.Point(100, 131);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.PasswordChar = '\0';
            this.txtSerialNo.PlaceholderText = "";
            this.txtSerialNo.SelectedText = "";
            this.txtSerialNo.ShadowDecoration.Parent = this.txtSerialNo;
            this.txtSerialNo.Size = new System.Drawing.Size(200, 24);
            this.txtSerialNo.TabIndex = 42;
            this.txtSerialNo.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBatchNo.DefaultText = "";
            this.txtBatchNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBatchNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBatchNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBatchNo.DisabledState.Parent = this.txtBatchNo;
            this.txtBatchNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBatchNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBatchNo.FocusedState.Parent = this.txtBatchNo;
            this.txtBatchNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBatchNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBatchNo.HoverState.Parent = this.txtBatchNo;
            this.txtBatchNo.Location = new System.Drawing.Point(100, 93);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.PasswordChar = '\0';
            this.txtBatchNo.PlaceholderText = "";
            this.txtBatchNo.SelectedText = "";
            this.txtBatchNo.ShadowDecoration.Parent = this.txtBatchNo;
            this.txtBatchNo.Size = new System.Drawing.Size(200, 24);
            this.txtBatchNo.TabIndex = 42;
            this.txtBatchNo.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // txtMRP
            // 
            this.txtMRP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMRP.DefaultText = "";
            this.txtMRP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMRP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMRP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMRP.DisabledState.Parent = this.txtMRP;
            this.txtMRP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMRP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMRP.FocusedState.Parent = this.txtMRP;
            this.txtMRP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMRP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMRP.HoverState.Parent = this.txtMRP;
            this.txtMRP.Location = new System.Drawing.Point(100, 53);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.PasswordChar = '\0';
            this.txtMRP.PlaceholderText = "";
            this.txtMRP.SelectedText = "";
            this.txtMRP.ShadowDecoration.Parent = this.txtMRP;
            this.txtMRP.Size = new System.Drawing.Size(200, 24);
            this.txtMRP.TabIndex = 42;
            this.txtMRP.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // txtDate
            // 
            this.txtDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDate.DefaultText = "";
            this.txtDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDate.DisabledState.Parent = this.txtDate;
            this.txtDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDate.FocusedState.Parent = this.txtDate;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDate.HoverState.Parent = this.txtDate;
            this.txtDate.Location = new System.Drawing.Point(423, 129);
            this.txtDate.Name = "txtDate";
            this.txtDate.PasswordChar = '\0';
            this.txtDate.PlaceholderText = "";
            this.txtDate.SelectedText = "";
            this.txtDate.ShadowDecoration.Parent = this.txtDate;
            this.txtDate.Size = new System.Drawing.Size(200, 24);
            this.txtDate.TabIndex = 42;
            this.txtDate.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(339, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 41;
            this.label12.Text = "EXP Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "MFG Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Size :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "Serial No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Batch No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "MRP :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnminimize);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(687, 41);
            this.panel3.TabIndex = 17;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
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
            this.btnCancel.Location = new System.Drawing.Point(642, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(26, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(285, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Tracking ";
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
            this.btnminimize.Location = new System.Drawing.Point(610, 10);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 447;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // Item_Tracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Item_Tracking";
            this.Size = new System.Drawing.Size(687, 219);
            this.Load += new System.EventHandler(this.Item_Tracking_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtDate;
        private Guna.UI2.WinForms.Guna2TextBox txtSerialNo;
        private Guna.UI2.WinForms.Guna2TextBox txtBatchNo;
        private Guna.UI2.WinForms.Guna2TextBox txtMRP;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpexpdate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpmfgDate;
        private System.Windows.Forms.Button btnminimize;
    }
}
