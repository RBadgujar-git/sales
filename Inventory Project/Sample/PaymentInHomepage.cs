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
            binddata();
        }
        private void binddata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_PaymentIn where DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvPaymentIn.AutoGenerateColumns = false;
            dgvPaymentIn.ColumnCount = 6;
            dgvPaymentIn.Columns[0].HeaderText = "Receipt No";
            dgvPaymentIn.Columns[0].DataPropertyName = "ReceiptNo";
            dgvPaymentIn.Columns[1].HeaderText = " Party Name";
            dgvPaymentIn.Columns[1].DataPropertyName = "CustomerName";
            dgvPaymentIn.Columns[2].HeaderText = "Payment Type";
            dgvPaymentIn.Columns[2].DataPropertyName = "PaymentType";
            dgvPaymentIn.Columns[3].HeaderText = "Received Amount";
            dgvPaymentIn.Columns[3].DataPropertyName = "ReceivedAmount";
            dgvPaymentIn.Columns[4].HeaderText = "Unused Amount";
            dgvPaymentIn.Columns[4].DataPropertyName = "UnusedAmount";
            dgvPaymentIn.Columns[5].HeaderText = "Total";
            dgvPaymentIn.Columns[5].DataPropertyName = "Total";
            dgvPaymentIn.DataSource = dt;
        }
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("SELECT ReceiptNo,CustomerName,PaymentType,Total,ReceivedAmount,UnusedAmount FROM tbl_PaymentIn where Date between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "'");
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

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ReceiptNo, CustomerName, PaymentType, ReceivedAmount,UnusedAmount,Total from tbl_PaymentIn where  CustomerName like '%{0}%'", txtFilterBy.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
