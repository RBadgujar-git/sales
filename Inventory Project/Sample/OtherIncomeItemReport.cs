﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
namespace sample
{
    public partial class OtherIncomeItemReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public static int compid;
        public FormWindowState WindowState { get; private set; }

        public OtherIncomeItemReport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void OtherIncomeItemReport_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cd1 = new SqlCommand("select sum(ItemAmount) as received from tbl_OtherIncomeInner3 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataReader dr1 = cd1.ExecuteReader();
            while (dr1.Read())
            {
                txttotal.Text = dr1.GetValue(0).ToString();
            }
            dr1.Close();
            con.Close();
            fetchCompany();
            fetchdata();
            con.Open();
            SqlCommand cd = new SqlCommand("select sum(Qty) as total from tbl_OtherIncomeInner3 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataReader dr = cd.ExecuteReader();
            while (dr.Read())
            {
                txtTotalQty.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
            con.Close();
           
        }
        private void fetchdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_OtherIncomeInner3 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvOtherIncome.AutoGenerateColumns = false;
            dgvOtherIncome.ColumnCount = 3;
            dgvOtherIncome.Columns[0].HeaderText = "Item Name";
            dgvOtherIncome.Columns[0].DataPropertyName = "ItemName";
            dgvOtherIncome.Columns[1].HeaderText = " Quantity";
            dgvOtherIncome.Columns[1].DataPropertyName = "Qty";
            dgvOtherIncome.Columns[2].HeaderText = " Item Amount";
            dgvOtherIncome.Columns[2].DataPropertyName = "ItemAmount";
            dgvOtherIncome.DataSource = dt;
            dgvOtherIncome.AllowUserToAddRows = false;
        }
        private void fetchCompany()
        {
            if (cmbAlllFirms.Text != "System.Data.DataRowView")
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
                        cmbAlllFirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void dtpToDate_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select * from tbl_OtherIncomeInner3 where ItemName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvOtherIncome.DataSource = ds;
                dgvOtherIncome.DataMember = "temp";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Data()
        {
            float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];
            //e.SuppressKeyPress = true;
            for (int i = 0; i < dgvOtherIncome.Rows.Count; i++)
            {
                TA += float.Parse(dgvOtherIncome.Rows[i].Cells["Column2"].Value?.ToString());
                txttotal.Text = TA.ToString();
                TD += float.Parse(dgvOtherIncome.Rows[i].Cells["Column3"].Value?.ToString());
                txtqty.Text = TD.ToString();
                TG += float.Parse(dgvOtherIncome.Rows[i].Cells["freeqty"].Value?.ToString());
                txtfreeqty.Text = TG.ToString();
                qty = float.Parse(txtqty.Text.ToString());
                rate = float.Parse(txtfreeqty.Text.ToString());
                total = qty +rate;
                txtTotalQty.Text = total.ToString();
            }
        }

        private void cmbAlllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmbAlllFirms.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    compid = Convert.ToInt32(dr["CompanyID"].ToString());
                    // MessageBox.Show("Test" + compid);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                companyinfo();
                data();
            }
        }
        public void data()
        {
            con.Open();
            SqlCommand cd1 = new SqlCommand("select sum(ItemAmount) as received from tbl_OtherIncomeInner3 where Company_ID='" + compid + "' and DeleteData='1'", con);
            SqlDataReader dr1 = cd1.ExecuteReader();
            while (dr1.Read())
            {
                txttotal.Text = dr1.GetValue(0).ToString();
            }
            dr1.Close();
            con.Close();
           
            con.Open();
            SqlCommand cd = new SqlCommand("select sum(Qty) as total from tbl_OtherIncomeInner3 where Company_ID='" + compid + "' and DeleteData='1'", con);
            SqlDataReader dr = cd.ExecuteReader();
            while (dr.Read())
            {
                txtTotalQty.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
            con.Close();
        }
        public void companyinfo()
        {
            //string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrderWhere CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice Where CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder Where CompanyID='" + compid + "' and DeleteData='1') ", cmballfrims.Text);
            string Query = string.Format("select ItemName,Qty,ItemAmount from tbl_OtherIncomeInner3  where  Company_ID='" + compid + "' and DeleteData='1'", cmbAlllFirms.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvOtherIncome.DataSource = ds;
            dgvOtherIncome.DataMember = "temp";
            dgvOtherIncome.AllowUserToAddRows = false;
        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select c.CompanyID,c.CompanyName,c.Address,c.AddLogo,c.PhoneNo,c.GSTNumber,c.EmailID,b.ItemName,b.Qty,b.ItemAmount,b.Company_ID from tbl_OtherIncomeInner3 as b,tbl_CompanyMaster as c where b.Company_ID = '" + NewCompany.company_id + "' and c.CompanyID='" + NewCompany.company_id + "' and b.DeleteData = '1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"OtherIncomeItemData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("OtherIncomeItemData", "OtherIncomeItemData", ds.Tables[0]);

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
    }
}
