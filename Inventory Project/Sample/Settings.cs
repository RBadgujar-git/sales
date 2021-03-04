using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Setting BA = new Setting();
            //BA.TopLevel = false;
            BA.AutoScroll = true;
           this.Controls.Add(BA);
          // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           BA.Dock = DockStyle.Fill;
           BA.Visible = true;
           BA.BringToFront();
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            TransactionSetting BA = new TransactionSetting();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            PartySetting BA = new PartySetting();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            ItemSetting BA = new ItemSetting();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            PrintSetting BA = new PrintSetting();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            TaxnGST BA = new TaxnGST();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
