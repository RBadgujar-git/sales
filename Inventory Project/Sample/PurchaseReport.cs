using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample
{
    public partial class PurchaseReport : UserControl

    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public PurchaseReport()
        {
            InitializeComponent();
        }
        string date;

        private void fetchCampanyame()
        {
            if (cmbFirm.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbFirm.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void PurchaseReport_Load(object sender, EventArgs e)
        {
            fetchCampanyame();
            con.Open();
            SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill", con);
            DataSet ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            SDA.Fill(ds, "temp");
            dgvPurchaseBill.DataSource = ds;
            dgvPurchaseBill.DataMember = "temp";
            con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //this.Controls.Clear();
            PurchaseBill PB = new PurchaseBill();
            PB.TopLevel = false;
          // PB.AutoScroll = true;
            this.Controls.Add(PB);
            PB.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.Show();
           // PB.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string saledate = cmbMonth.SelectedItem.ToString();
            if (saledate == "This Month")
            {
                try
                {
                    date = DateTime.Now.Month.ToString();
                    //MessageBox.Show("moth o" + date);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where month(BillDate)=" + date + " ", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (saledate == "This Year")
            {
                try
                {
                    date = DateTime.Now.Year.ToString();

                    con.Open();
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where year(BillDate)=" + date + " ", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            else if (saledate == "Last Month")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill WHERE DATEPART(m, BillDate) = DATEPART(m, DATEADD(m, -1, getdate())) AND DATEPART(yy, BillDate) = DATEPART(yy, DATEADD(m, -1, getdate()))", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (saledate == "This Qurter")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill WHERE BillDate>= DATEADD(M, -3, GETDATE())", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (saledate == "All Sale Invoice")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpTodate_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate between '" + dtpFrom.Value.ToString() + "' and '" + dtpTodate.Value.ToString() + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPurchaseBill.DataSource = ds;
                dgvPurchaseBill.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void cmbFirm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where PartyName like '%{0}%' or BillNo like '%{0}%'", txtSearch.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPurchaseBill.DataSource = ds;
                dgvPurchaseBill.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
