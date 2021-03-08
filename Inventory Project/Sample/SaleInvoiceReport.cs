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
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
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
                string Query = string.Format("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where PartyName like '%{0}%' or InvoiceID like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch.Text);
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
                    SqlCommand cmd = new SqlCommand("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where month(InvoiceDate)=" + date + " and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", con);
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
                    SqlCommand cmd = new SqlCommand("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where year(InvoiceDate)=" + date + " and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", con);
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
                    SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice WHERE DATEPART(m, InvoiceDate) = DATEPART(m, DATEADD(m, -1, getdate())) AND DATEPART(yy, InvoiceDate) = DATEPART(yy, DATEADD(m, -1, getdate())) and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
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
                    SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice WHERE InvoiceDate>= DATEADD(M, -3, GETDATE()) and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
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
                    SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
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
            Bindadata();
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status FROM tbl_SaleInvoice", con);
            //DataSet ds = new DataSet();
            //SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            //SDA.Fill(ds, "temp");
            //dgvsaleInvoice.DataSource = ds;
            //dgvsaleInvoice.DataMember = "temp";
            //con.Close();
        }
        private void Data()
        {
            float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];
            //e.SuppressKeyPress = true;
            for (int i = 0; i < dgvsaleInvoice.Rows.Count; i++)
            {
                TA += float.Parse(dgvsaleInvoice.Rows[i].Cells["Paid"].Value?.ToString());
                txtPaid.Text = TA.ToString();
                TD += float.Parse(dgvsaleInvoice.Rows[i].Cells["RemainingBal"].Value?.ToString());
                txtUnpaid.Text = TD.ToString();

                qty = float.Parse(txtPaid.Text.ToString());
                rate = float.Parse(txtUnpaid.Text.ToString());
                total = qty + rate;
                txtTotal.Text = total.ToString();
            }
        }
        private void Bindadata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvsaleInvoice.AutoGenerateColumns = false;
            dgvsaleInvoice.ColumnCount = 8;
            dgvsaleInvoice.Columns[0].HeaderText = "Date";
            dgvsaleInvoice.Columns[0].DataPropertyName = "InvoiceDate";
            dgvsaleInvoice.Columns[1].HeaderText = " Invoice No";
            dgvsaleInvoice.Columns[1].DataPropertyName = "InvoiceID";
            dgvsaleInvoice.Columns[2].HeaderText = "Party Name";
            dgvsaleInvoice.Columns[2].DataPropertyName = "PartyName";
            dgvsaleInvoice.Columns[3].HeaderText = " PaymentType";
            dgvsaleInvoice.Columns[3].DataPropertyName = "PaymentType";
            dgvsaleInvoice.Columns[4].HeaderText = "Total";
            dgvsaleInvoice.Columns[4].DataPropertyName = "Total";
            dgvsaleInvoice.Columns[5].HeaderText = " Received";
            dgvsaleInvoice.Columns[5].DataPropertyName = "Received";
            dgvsaleInvoice.Columns[6].HeaderText = "Remaining Bal";
            dgvsaleInvoice.Columns[6].DataPropertyName = "RemainingBal";
            dgvsaleInvoice.Columns[7].HeaderText = " Status";
            dgvsaleInvoice.Columns[7].DataPropertyName = "Status";
            dgvsaleInvoice.DataSource = dt;
        }//BillDate,BillNo,PartyName,PaymentType,Total,Paid,Rema

        private void dtpTodate_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dtpTodate_Enter_1(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select InvoiceDate,InvoiceID,PartyName,PaymentType,Total,Received,RemainingBal,Status from tbl_SaleInvoice where InvoiceDate between '" + dtpFromDate.Value.ToString() + "' and '" + dtpTodate.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
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

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvsaleInvoice_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
