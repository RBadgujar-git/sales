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
    public partial class CompanyBankAccount : UserControl
    {
        public CompanyBankAccount()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
       
        private void btnminimize_Click(object sender, EventArgs e)
        {
        }
    }
}
