namespace sample
{
    partial class LoginForm
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
            if (disposing && (components != null))
            {
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
            this.pass1 = new System.Windows.Forms.TextBox();
            this.Pass2 = new System.Windows.Forms.TextBox();
            this.pass3 = new System.Windows.Forms.TextBox();
            this.Pass4 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pass1
            // 
            this.pass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass1.Location = new System.Drawing.Point(21, 73);
            this.pass1.MaxLength = 1;
            this.pass1.Multiline = true;
            this.pass1.Name = "pass1";
            this.pass1.PasswordChar = '*';
            this.pass1.Size = new System.Drawing.Size(56, 54);
            this.pass1.TabIndex = 1;
            this.pass1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Pass2
            // 
            this.Pass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Pass2.Location = new System.Drawing.Point(87, 73);
            this.Pass2.MaxLength = 1;
            this.Pass2.Multiline = true;
            this.Pass2.Name = "Pass2";
            this.Pass2.PasswordChar = '*';
            this.Pass2.Size = new System.Drawing.Size(56, 54);
            this.Pass2.TabIndex = 2;
            this.Pass2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Pass2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.Pass2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pass2_KeyDown);
            // 
            // pass3
            // 
            this.pass3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.pass3.Location = new System.Drawing.Point(157, 73);
            this.pass3.MaxLength = 1;
            this.pass3.Multiline = true;
            this.pass3.Name = "pass3";
            this.pass3.PasswordChar = '*';
            this.pass3.Size = new System.Drawing.Size(56, 54);
            this.pass3.TabIndex = 3;
            this.pass3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass3.TextChanged += new System.EventHandler(this.pass3_TextChanged);
            this.pass3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pass3_KeyDown);
            // 
            // Pass4
            // 
            this.Pass4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.Pass4.Location = new System.Drawing.Point(231, 80);
            this.Pass4.MaxLength = 1;
            this.Pass4.Multiline = true;
            this.Pass4.Name = "Pass4";
            this.Pass4.PasswordChar = '*';
            this.Pass4.Size = new System.Drawing.Size(56, 54);
            this.Pass4.TabIndex = 4;
            this.Pass4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Pass4.TextChanged += new System.EventHandler(this.Pass4_TextChanged);
            this.Pass4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pass4_KeyDown);
            this.Pass4.MouseEnter += new System.EventHandler(this.Pass4_MouseEnter);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(169, 169);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(118, 16);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forget Password";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(25, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 993;
            this.label4.Text = "label4";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(278, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 30);
            this.btnCancel.TabIndex = 994;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(305, 207);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Pass4);
            this.Controls.Add(this.pass3);
            this.Controls.Add(this.Pass2);
            this.Controls.Add(this.pass1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pass1;
        private System.Windows.Forms.TextBox Pass2;
        private System.Windows.Forms.TextBox pass3;
        private System.Windows.Forms.TextBox Pass4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
    }
}