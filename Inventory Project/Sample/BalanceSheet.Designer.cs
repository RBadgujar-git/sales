namespace sample
{
    partial class BalanceSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceSheet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.dtpdatefrom = new System.Windows.Forms.DateTimePicker();
            this.dtpdateto = new System.Windows.Forms.DateTimePicker();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnimprt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 59;
            this.label2.Text = "To";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(397, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(193, 16);
            this.label13.TabIndex = 73;
            this.label13.Text = "Balance Sheet as on Date";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(22, 133);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1004, 436);
            this.guna2ShadowPanel1.TabIndex = 74;
            this.guna2ShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // dtpdatefrom
            // 
            this.dtpdatefrom.CustomFormat = "MM/dd/yyyy";
            this.dtpdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdatefrom.Location = new System.Drawing.Point(166, 40);
            this.dtpdatefrom.Name = "dtpdatefrom";
            this.dtpdatefrom.Size = new System.Drawing.Size(145, 23);
            this.dtpdatefrom.TabIndex = 75;
            // 
            // dtpdateto
            // 
            this.dtpdateto.CustomFormat = "MM/dd/yyyy";
            this.dtpdateto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateto.Location = new System.Drawing.Point(375, 40);
            this.dtpdateto.Name = "dtpdateto";
            this.dtpdateto.Size = new System.Drawing.Size(156, 23);
            this.dtpdateto.TabIndex = 76;
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
            this.btncancel.Location = new System.Drawing.Point(979, 3);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(28, 26);
            this.btncancel.TabIndex = 72;
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
            this.btnprint.Location = new System.Drawing.Point(931, 30);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(24, 25);
            this.btnprint.TabIndex = 71;
            this.btnprint.UseVisualStyleBackColor = false;
            // 
            // btnimprt
            // 
            this.btnimprt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimprt.BackColor = System.Drawing.Color.Transparent;
            this.btnimprt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimprt.BackgroundImage")));
            this.btnimprt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimprt.FlatAppearance.BorderSize = 0;
            this.btnimprt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimprt.Location = new System.Drawing.Point(888, 34);
            this.btnimprt.Name = "btnimprt";
            this.btnimprt.Size = new System.Drawing.Size(25, 21);
            this.btnimprt.TabIndex = 70;
            this.btnimprt.UseVisualStyleBackColor = false;
            // 
            // BalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dtpdateto);
            this.Controls.Add(this.dtpdatefrom);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnimprt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BalanceSheet";
            this.Size = new System.Drawing.Size(1020, 567);
            this.Load += new System.EventHandler(this.BalanceSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnimprt;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.DateTimePicker dtpdatefrom;
        private System.Windows.Forms.DateTimePicker dtpdateto;
    }
}
