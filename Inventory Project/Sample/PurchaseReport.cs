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
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

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

        public FormWindowState WindowState { get; private set; }

        private void fetchCampanyame()
        {
       
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1' group by CompanyName");
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
        

        private void PurchaseReport_Load(object sender, EventArgs e)
        {
            //fetchCampanyame();
           
            Bindadata();
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill", con);
            //DataSet ds = new DataSet();
            //SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            //SDA.Fill(ds, "temp");
            //dgvPurchaseBill.DataSource = ds;
            //dgvPurchaseBill.DataMember = "temp";
            //con.Close();
            Data();
         
        }
        private void Bindadata1(int m)
        {

            try
            {
                string Query = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Company_ID='" + m + "' and DeleteData='1'");
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
        private void Bindadata()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Query = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPurchaseBill.DataSource = ds;
                dgvPurchaseBill.DataMember = "temp";
                dgvPurchaseBill.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status 
        private void Data()
        {
            float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];

            //e.SuppressKeyPress = true;


            for (int i = 0; i < dgvPurchaseBill.Rows.Count; i++)
            {
                try
                {

                    TA += float.Parse(dgvPurchaseBill.Rows[i].Cells["Paid"].Value.ToString());
                    txtPaid.Text = TA.ToString();
                    TD += float.Parse(dgvPurchaseBill.Rows[i].Cells["RemainingBal"].Value.ToString());
                    txtUnpaid.Text = TD.ToString();

                    qty = float.Parse(txtPaid.Text.ToString());
                    rate = float.Parse(txtUnpaid.Text.ToString());
                    total = qty + rate;
                    txtTotal.Text = total.ToString();
                }
                catch(Exception ew)
                {
                  //  MessageBox.Show(ew.Message);
                }
            }
        }

        public void Datacount()
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("tbl_PurchaseBillInnersp", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@month",DateTime.Now.Month.ToString());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtPaid.Text = dr[0].ToString();
               txtUnpaid.Text = dr[1].ToString();

            }
            dr.Close();
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
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select c.CompanyID,c.CompanyName,c.Address,c.AddLogo,c.PhoneNo,c.GSTNumber,c.EmailID,b.BillDate,b.Company_ID, b.BillNo, b.PartyName, b.PaymentType, b.Total, b.Paid, b.RemainingBal,b.DeleteData, b.Status from tbl_PurchaseBill as b,tbl_CompanyMaster as c where c.CompanyID = '" + NewCompany.company_id + "' and b.Company_ID = '" + NewCompany.company_id + "' and b.DeleteData = '1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"PurchaseBillData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("PurchaseBillData", "PurchaseBillData", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where month(BillDate)=" + date + " and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                    //con.Close();
                   // Data();
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
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where year(BillDate)=" + date + " and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                   // con.Close();
                //    Data();
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
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill WHERE DATEPART(m, BillDate) = DATEPART(m, DATEADD(m, -1, getdate())) AND DATEPART(yy, BillDate) = DATEPART(yy, DATEADD(m, -1, getdate())) and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                    //con.Close();
             //       Data();

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
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill WHERE BillDate>= DATEADD(M, -3, GETDATE()) and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                  
               //     Data();
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
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(ds, "temp");
                    dgvPurchaseBill.DataSource = ds;
                    dgvPurchaseBill.DataMember = "temp";
                 
                //    Data();
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
           
            
        }

        private void cmbFirm_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            if(cmbFirm.Text=="")
            {
                Bindadata1(Convert.ToInt32(NewCompany.company_id));
            }
            else
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select CompanyID from tbl_CompanyMaster where  CompanyName='"+cmbFirm.Text+"' and DeleteData='1' ", con);
                int compid =Convert.ToInt32(cmd.ExecuteScalar());
                Bindadata1(compid);

            }



       




        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where PartyName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch.Text);
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
        private void dtpTodate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate between '" + dtpFrom.Text + "' and '" + dtpTodate.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
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

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvPurchaseBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
