using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class unitHomepage : UserControl
    {
        public unitHomepage()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Unit_Conversion BA = new Unit_Conversion();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           // BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            unitHomepage BA = new unitHomepage();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.Show();
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void unitHomepage_Load(object sender, EventArgs e)
        {

        }
    }
}
