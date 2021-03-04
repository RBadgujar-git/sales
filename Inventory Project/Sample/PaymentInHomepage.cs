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
    public partial class PaymentInHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public PaymentInHomepage()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PaymentIn BA = new PaymentIn();
            BA.TopLevel = false;
            
            //BA.AutoScroll = true;
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

        private void PaymentInHomepage_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Date,ReceiptNo,CustomerName,PaymentType,Total,ReceivedAmount,UnusedAmount,Status FROM tbl_PaymentIn", con);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("SELECT Date,ReceiptNo,CustomerName,PaymentType,Total,ReceivedAmount,UnusedAmount,Status FROM tbl_PaymentIn where Date between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
