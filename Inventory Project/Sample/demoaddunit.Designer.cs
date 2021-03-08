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
            this.add_Unit1 = new sample.Add_Unit();
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
            // demoaddunit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 315);
            this.Controls.Add(this.add_Unit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "demoaddunit";
            this.Text = "demoaddunit";
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Unit add_Unit1;
    }
}