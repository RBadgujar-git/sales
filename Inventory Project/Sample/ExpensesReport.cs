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
using System.IO;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System.Globalization;

namespace sample
{
    public partial class ExpensesReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        public static int compid;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public ExpensesReport()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void ExpensesReport_Load(object sender, EventArgs e)
        {
            fetchexpenses();
            bindbankdata();
            fetchCompany();
            Data();
        }

        private void fetchCompany()
        {
            if (cmballfirms.Text != "System.Data.DataRowView")
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
                        cmballfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_Expenses where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvexpenses.AutoGenerateColumns = false;
            dgvexpenses.ColumnCount = 3;
            dgvexpenses.Columns[0].HeaderText = "Date";
            dgvexpenses.Columns[0].DataPropertyName = "Date";
            dgvexpenses.Columns[1].HeaderText = "Category";
            dgvexpenses.Columns[1].DataPropertyName = "ExpenseCategory";
            dgvexpenses.Columns[2].HeaderText = "Total";
            dgvexpenses.Columns[2].DataPropertyName = "Total";
            
            dgvexpenses.DataSource = dt;
            dgvexpenses.AllowUserToAddRows = false;

        }
        private void fetchexpenses()
        {
            //if (cmbexpenses.Text != "System.Data.DataRowView") {
            //    try {
            //        string SelectQuery = string.Format("select CategoryName from tbl_ExpenseCategory where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CategoryName");
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
            //        SDA.Fill(ds, "Temp");
            //        DataTable DT = new DataTable();
            //        SDA.Fill(ds);
            //        for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //        {
            //            cmbexpenses.Items.Add(ds.Tables["Temp"].Rows[i]["CategoryName"].ToString());

            //        }
            //    }
            //    catch (Exception e1)
            //    {
            //        MessageBox.Show(e1.Message);
            //    }
           // }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmbexpenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //string Query = string.Format("select CategoryName from tbl_ExpenseCategory where CategoryName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbexpenses.Text);
            //    string Query = string.Format("select Date,ExpenseCategory,Total from tbl_Expenses where ExpenseCategory='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbexpenses.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvexpenses.DataSource = ds;
            //    dgvexpenses.DataMember = "temp";



            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dtpTodate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string SelectQuery = string.Format("select Date,ExpenseCategory,Total from tbl_Expenses where Date between '" + dtpFromDate.Value.ToString(sysUIFormat) + "' and '" + dtpTodate.Value.ToString(sysUIFormat) + "' and Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'", txtfilter.Text);
                //string SelectQuery = string.Format("select ItemName,Qty,ItemAmount from tbl_OtherIncomeInner3  where ItemName like'%{0}%' and Company_ID='" + compid + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvexpenses.DataSource = ds;
                dgvexpenses.DataMember = "temp";
                dgvexpenses.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
            finally
            {
                Data();
            }
        }

        private void dtpTodate_Enter(object sender, EventArgs e)
        {
          
        }

        private void dgvexpenses_TabIndexChanged(object sender, EventArgs e)
        {
            //Data();
        }
        private void Data()
        {
            float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];
            //e.SuppressKeyPress = true;
            for (int i = 0; i < dgvexpenses.Rows.Count; i++)
            {
                TA += float.Parse(dgvexpenses.Rows[i].Cells["Column2"].Value?.ToString());
                txtTotalexpenes.Text = TA.ToString();
                //    TD += float.Parse(dgvexpense.Rows[i].Cells["Column1"].Value?.ToString());
                //    txtqty.Text = TD.ToString();
                //    TG += float.Parse(dgvexpense.Rows[i].Cells["FreeQty"].Value?.ToString());
                //    txtfreeqty.Text = TG.ToString();
                //    qty = float.Parse(txtqty.Text.ToString());
                //    rate = float.Parse(txtfreeqty.Text.ToString());
                //    total = qty * rate;
                //    txtTotalQty.Text = total.ToString();
                }
            }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select c.CompanyID,c.CompanyName,c.Address,c.AddLogo,c.PhoneNo,c.GSTNumber,c.EmailID, b.ID1, b.Date, b.ExpenseCategory, b.Total,b.Company_ID from tbl_Expenses as b,tbl_CompanyMaster as c where b.Company_ID = '" + NewCompany.company_id + "' and c.CompanyID='" + NewCompany.company_id + "' and b.DeleteData = '1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"ExpenceData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("ExpencesData", "ExpencesData", ds.Tables[0]);

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

        private void cmballfirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmballfirms.Text);
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
                // party();
            }
        }
        public void companyinfo()
        {
            //string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrderWhere CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice Where CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder Where CompanyID='" + compid + "' and DeleteData='1') ", cmballfrims.Text);
            string Query = string.Format("select Date,ExpenseCategory,Total from tbl_Expenses where Company_ID='" + compid + "' and DeleteData='1'", cmballfirms.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvexpenses.DataSource = ds;
            dgvexpenses.DataMember = "temp";
            dgvexpenses.AllowUserToAddRows = false;
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select Date,ExpenseCategory,Total from tbl_Expenses where ExpenseCategory like '%{0}%' and DeleteData = '1' and Company_ID = '" + NewCompany.company_id + "'", txtfilter.Text);
                //string SelectQuery = string.Format("select ItemName,Qty,ItemAmount from tbl_OtherIncomeInner3  where ItemName like'%{0}%' and Company_ID='" + compid + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvexpenses.DataSource = ds;
                dgvexpenses.DataMember = "temp";
                dgvexpenses.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
            finally
            {
                Data();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select * from tbl_Expenses where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                //string SelectQuery = string.Format("select ItemName,Qty,ItemAmount from tbl_OtherIncomeInner3  where ItemName like'%{0}%' and Company_ID='" + compid + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvexpenses.DataSource = ds;
                dgvexpenses.DataMember = "temp";
                dgvexpenses.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string SelectQuery = string.Format("select Date,ExpenseCategory,Total from tbl_Expenses where Date between '" + dtpFromDate.Value.ToString(sysUIFormat) + "' and '" + dtpTodate.Value.ToString(sysUIFormat) + "' and Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'", txtfilter.Text);
                //string SelectQuery = string.Format("select ItemName,Qty,ItemAmount from tbl_OtherIncomeInner3  where ItemName like'%{0}%' and Company_ID='" + compid + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvexpenses.DataSource = ds;
                dgvexpenses.DataMember = "temp";
                dgvexpenses.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
            finally
            {
                Data();
            }
        }
    }
}
