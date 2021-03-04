using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample
{
    public partial class Saleorderhomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public Saleorderhomepage()
        {
            InitializeComponent();
        }

        private void Saleorderhomepage_Load(object sender, EventArgs e)
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT OrderDate,OrderNo,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleOrder", con);
            DataSet ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            SDA.Fill(ds, "temp");
            dgvSaleOrder.DataSource = ds;
            dgvSaleOrder.DataMember = "temp";
            con.Close();
        }

        private void btnSaleorder_Click(object sender, EventArgs e)
        {
            SaleOrder BA = new SaleOrder();
            BA.TopLevel = false;
          //  BA.AutoScroll = true;
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
    }
}
