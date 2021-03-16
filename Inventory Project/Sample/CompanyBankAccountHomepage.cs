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
    public partial class CompanyBankAccountHomepage : UserControl
    {
        public CompanyBankAccountHomepage()
        {
            InitializeComponent();
        }

        private void btnSaleorder_Click(object sender, EventArgs e)
        {
            CompanyBankAccount BA = new CompanyBankAccount();
            //BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }
    }
}
