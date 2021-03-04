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
    public partial class PaymentOutHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public PaymentOutHomepage()
        {
            InitializeComponent();
        }

        private void btnaddPaymennt_Click(object sender, EventArgs e)
        {

            PaymentOut BA = new PaymentOut();
             BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
              BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void PaymentOutHomepage_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Date,ReceiptNo,CustomerName,PaymentType,Total,Paid,Discount FROM tbl_Paymentout", con);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(ds, "temp");
                dgvPaymentOut.DataSource = ds;
                dgvPaymentOut.DataMember = "temp";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select Date,ID,CustomerName,PaymentType,Total,Paid,Discount from tbl_Paymentout where Date between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPaymentOut.DataSource = ds;
                dgvPaymentOut.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
