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
    public partial class ItemWiseProfitLoss : UserControl
    {
        public ItemWiseProfitLoss()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void ItemWiseProfitLoss_Load(object sender, EventArgs e)
        {

        }
    }
}
