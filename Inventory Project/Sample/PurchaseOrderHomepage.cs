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
    public partial class PurchaseOrderHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
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

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select OrderNo, PartyName, OrderDate, DueDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where  OrderDate between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPurchaseOrder.DataSource = ds;
                dgvPurchaseOrder.DataMember = "temp";
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
                string Query = string.Format("select OrderNo, PartyName, OrderDate, DueDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where  PartyName like '%{0}%'", txtFilterBy.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPurchaseOrder.DataSource = ds;
                dgvPurchaseOrder.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PurchaseOrderHomepage_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_PurchaseOrder", con);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(ds, "temp");
                con.Close();
                dgvPurchaseOrder.AutoGenerateColumns = false;
                dgvPurchaseOrder.ColumnCount = 6;
                dgvPurchaseOrder.Columns[0].HeaderText = "OrderNo";
                dgvPurchaseOrder.Columns[0].DataPropertyName = "OrderNo";
                dgvPurchaseOrder.Columns[1].HeaderText = " Party Name";
                dgvPurchaseOrder.Columns[1].DataPropertyName = "PartyName";
                dgvPurchaseOrder.Columns[2].HeaderText = "OrderDate";
                dgvPurchaseOrder.Columns[2].DataPropertyName = "OrderDate";
                dgvPurchaseOrder.Columns[3].HeaderText = "DueDate";
                dgvPurchaseOrder.Columns[3].DataPropertyName = "DueDate";
                dgvPurchaseOrder.Columns[4].HeaderText = "Total";
                dgvPurchaseOrder.Columns[4].DataPropertyName = "Total";
                dgvPurchaseOrder.Columns[5].HeaderText = "Paid";
                dgvPurchaseOrder.Columns[5].DataPropertyName = "Paid";
                dgvPurchaseOrder.Columns[4].HeaderText = "Remaining Bal";
                dgvPurchaseOrder.Columns[4].DataPropertyName = "RemainingBal";
                dgvPurchaseOrder.Columns[5].HeaderText = "Status";
                dgvPurchaseOrder.Columns[5].DataPropertyName = "Status"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
