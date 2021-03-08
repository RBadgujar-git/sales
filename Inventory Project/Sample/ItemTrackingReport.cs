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
    public partial class ItemTrackingReport : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public ItemTrackingReport()
        {
            InitializeComponent();
        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvItemTracking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ItemTrackingReport_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }

        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_ItemMaster where DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvItemTracking.AutoGenerateColumns = false;
            dgvItemTracking.ColumnCount = 7;
            dgvItemTracking.Columns[0].HeaderText = "Item Name";
            dgvItemTracking.Columns[0].DataPropertyName = "ItemName";
            dgvItemTracking.Columns[1].HeaderText = "Batch No";
            dgvItemTracking.Columns[1].DataPropertyName = "BatchNo";
            dgvItemTracking.Columns[2].HeaderText = "Serial No";
            dgvItemTracking.Columns[2].DataPropertyName = "SerialNo";
            dgvItemTracking.Columns[3].HeaderText = "Size";
            dgvItemTracking.Columns[3].DataPropertyName = "Size";
            dgvItemTracking.Columns[4].HeaderText = "Mfg date";
            dgvItemTracking.Columns[4].DataPropertyName = "MFgdate";
            dgvItemTracking.Columns[5].HeaderText = "Exp date";
            dgvItemTracking.Columns[5].DataPropertyName = "Expdate";
           
            dgvItemTracking.DataSource = dt;
        }

        private void txtItemname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ItemName,BatchNo,SerialNo,Size,MFgdate,Expdate from tbl_ItemMaster where ItemName like '%{0}%'", txtItemname.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvItemTracking.DataSource = ds;
                dgvItemTracking.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

        private void dtpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select ItemName,BatchNo,SerialNo,Size ,MFgdate,Expdate from tbl_ItemMaster  where MFgdate between '" + dtpfrom.Value.ToString() + "' and '" + dtpfrom.Value.ToString() + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvItemTracking.DataSource = ds;
                dgvItemTracking.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void dtpToexp_ValueChanged(object sender, EventArgs e)
        {
                
        }

        private void dtpToexp_Enter(object sender, EventArgs e)
        {
            {
                try
                {
                    string SelectQuery = string.Format("select ItemName,BatchNo,SerialNo,Size ,MFgdate,Expdate from tbl_ItemMaster  where Expdate between '" + dtpFromexp.Value.ToString() + "' and '" + dtpToexp.Value.ToString() + "'");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "temp");
                    dgvItemTracking.DataSource = ds;
                    dgvItemTracking.DataMember = "temp";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data not" + ex);
                }
            }
        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ItemName,BatchNo,SerialNo,Size,MFgdate,Expdate from tbl_ItemMaster where SerialNo like '%{0}%'", txtSerialNo.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvItemTracking.DataSource = ds;
                dgvItemTracking.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtbatchNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ItemName,BatchNo,SerialNo,Size,MFgdate,Expdate from tbl_ItemMaster where BatchNo like '%{0}%'", txtbatchNo.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvItemTracking.DataSource = ds;
                dgvItemTracking.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
