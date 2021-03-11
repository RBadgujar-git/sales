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
    public partial class CompanyBankHomepage : UserControl
    {
        public CompanyBankHomepage()
        {
            InitializeComponent();
        }

        private void CompanyBankHomepage_Load(object sender, EventArgs e)
        {

        }

        private void btnSaleorder_Click(object sender, EventArgs e)
        {
            CompanyBankAccount cb = new CompanyBankAccount();
            this.Controls.Add(cb);
            cb.Dock = DockStyle.Fill;
            cb.Visible = true;
            cb.BringToFront();
        }
    }
}
