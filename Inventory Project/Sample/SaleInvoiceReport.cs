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
    public partial class SaleInvoiceReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public SaleInvoiceReport()
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaleInvoice BA = new SaleInvoice();
            BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dtpTodate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTodate_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void dgvsaleInvoice_Enter(object sender, EventArgs e)
        {

        }

        private void dtpTodate_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where PartyName like '%{0}%' or InvoiceID like '%{0}%'", txtSearch.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvsaleInvoice.DataSource = ds;
                dgvsaleInvoice.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbThisMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string saledate = cmbThisMonth.SelectedItem.ToString();
            if (saledate == "This Month")
            {
                try
                {
                    date = DateTime.Now.Month.ToString();
                    //MessageBox.Show("moth o" + date);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where month(InvoiceDate)=" + date + " ", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvsaleInvoice.DataSource = ds;
                    dgvsaleInvoice.DataMember = "temp";
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
                    SqlCommand cmd = new SqlCommand("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where year(InvoiceDate)=" + date + " ", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvsaleInvoice.DataSource = ds;
                    dgvsaleInvoice.DataMember = "temp";
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
                    SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice WHERE DATEPART(m, InvoiceDate) = DATEPART(m, DATEADD(m, -1, getdate())) AND DATEPART(yy, InvoiceDate) = DATEPART(yy, DATEADD(m, -1, getdate()))", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvsaleInvoice.DataSource = ds;
                    dgvsaleInvoice.DataMember = "temp";
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
                    SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice WHERE InvoiceDate>= DATEADD(M, -3, GETDATE())", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvsaleInvoice.DataSource = ds;
                    dgvsaleInvoice.DataMember = "temp";
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
                    SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvsaleInvoice.DataSource = ds;
                    dgvsaleInvoice.DataMember = "temp";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SaleInvoiceReport_Load(object sender, EventArgs e)
        {
            
            fetchCampanyame();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice", con);
            DataSet ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            SDA.Fill(ds, "temp");
            dgvsaleInvoice.DataSource = ds;
            dgvsaleInvoice.DataMember = "temp";
            con.Close();
        }

        private void dtpTodate_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dtpTodate_Enter_1(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where InvoiceDate between '" + dtpFromDate.Value.ToString() + "' and '" + dtpTodate.Value.ToString() + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvsaleInvoice.DataSource = ds;
                dgvsaleInvoice.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void cmbFirm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvsaleInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
