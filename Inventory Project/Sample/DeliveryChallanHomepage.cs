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
    public partial class DeliveryChallanHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public DeliveryChallanHomepage()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DeliveryChallan BA = new DeliveryChallan();
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

        private void DeliveryChallanHomepage_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,ChallanNo,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_DeliveryChallan", con);
            DataSet ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            SDA.Fill(ds, "temp");
            dgvdeliveryChallan.DataSource = ds;
            dgvdeliveryChallan.DataMember = "temp";
            con.Close();
        }
    }
}
