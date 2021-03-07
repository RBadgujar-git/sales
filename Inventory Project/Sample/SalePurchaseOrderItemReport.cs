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
    public partial class SalePurchaseOrderItemReport : UserControl
    {
        public SalePurchaseOrderItemReport()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvSalepurchhase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
