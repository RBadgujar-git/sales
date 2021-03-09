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
    public partial class OtherIncomeReport : UserControl
    {
        public FormWindowState WindowState { get; private set; }

        public OtherIncomeReport()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void OtherIncomeReport_Load(object sender, EventArgs e)
        {

        }

        private void cmbAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
