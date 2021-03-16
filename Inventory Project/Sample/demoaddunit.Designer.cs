namespace sample
{
    partial class demoaddunit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(demoaddunit));
            this.add_Unit1 = new sample.Add_Unit();
            this.closebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add_Unit1
            // 
            this.add_Unit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_Unit1.Location = new System.Drawing.Point(0, 0);
            this.add_Unit1.Name = "add_Unit1";
            this.add_Unit1.Size = new System.Drawing.Size(640, 315);
            this.add_Unit1.TabIndex = 0;
            this.add_Unit1.Load += new System.EventHandler(this.add_Unit1_Load);
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.White;
            this.closebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closebtn.BackgroundImage")));
            this.closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closebtn.Location = new System.Drawing.Point(579, 6);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(22, 22);
            this.closebtn.TabIndex = 1;
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // demoaddunit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 315);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.add_Unit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "demoaddunit";
            this.Text = "demoaddunit";
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Unit add_Unit1;
        private System.Windows.Forms.Button closebtn;
    }
}