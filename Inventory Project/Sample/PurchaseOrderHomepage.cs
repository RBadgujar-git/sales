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
    public partial class PurchaseOrderHomepage : UserControl
    {
        public FormWindowState WindowState { get; private set; }

        public PurchaseOrderHomepage()
        {
            InitializeComponent();
        }

        private void btnpurchaseorder_Click(object sender, EventArgs e)
        {
            PurchaseOrder BA = new PurchaseOrder();
             BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
             BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvPurchaseOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PurchaseOrderHomepage_Load(object sender, EventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
