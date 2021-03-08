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
    public partial class BalanceSheet : UserControl
    {
        public FormWindowState WindowState { get; private set; }

        public BalanceSheet()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BalanceSheet_Load(object sender, EventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
