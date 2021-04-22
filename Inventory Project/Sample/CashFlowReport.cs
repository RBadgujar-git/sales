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
    public partial class CashFlowReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        public static int compid;
        public FormWindowState WindowState { get; private set; }

        public CashFlowReport()
        {
            InitializeComponent();
        }
        
        private void CashFlowReport_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("(select InvoiceDate as InvoiceDate,PartyName,TableName as Type,Received as 'CashIn/CashOut' from tbl_saleinvoice where Company_ID='"+NewCompany.company_id+ "' and DeleteData='1') union (select BillDate as InvoiceDate,PartyName,TableName as Type,Paid from tbl_purchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                //union all select a.Company_ID,a.EntryType,a.Amount,a.Date,a.Description,b.BankName,b.OpeningBal  from tbl_BankAdjustment as a,tbl_BankAccount as b where b.BankName='{0}' AND a.Company_ID='" + NewCompany.company_id + "'", cmbbankname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvCashflow.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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
                string Query = String.Format("(select InvoiceDate as InvoiceDate,PartyName,TableName as Type,Received as 'CashIn/CashOut' from tbl_saleinvoice where Company_ID='"+NewCompany.company_id+ "' and DeleteData='1') union (select BillDate as InvoiceDate,PartyName,TableName as Type,Paid from tbl_purchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");

                    //  string Query = string.Format("");
                    //string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.InvoiceID,b.PaymentType,b.Company_ID,b.Received,b.RemainingBal,b.Total,b.InvoiceDate FROM tbl_CompanyMaster as a, tbl_SaleInvoice as b where b.InvoiceDate='{0}' and a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "'",date1);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"CashFlow.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("CashFlow", "CashFlow", ds.Tables[0]);

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

        private void cmballfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmballfirm.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    compid = Convert.ToInt32(dr["CompanyID"].ToString());
                    MessageBox.Show("Test" + compid);
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
            }
        }
        public void companyinfo()
        {
            //string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrderWhere CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice Where CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder Where CompanyID='" + compid + "' and DeleteData='1') ", cmballfrims.Text);
            string Query = string.Format("(select InvoiceDate as InvoiceDate,PartyName,TableName as Type,Received as 'CashIn/CashOut' from tbl_saleinvoice where Company_ID='" + compid + "' and DeleteData='1') union (select BillDate as InvoiceDate,PartyName,TableName as Type,Paid from tbl_purchaseBill where Company_ID='" + compid + "' and DeleteData='1')", cmballfirm.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvCashflow.DataSource = ds;
            dgvCashflow.DataMember = "temp";
        }
    }
}
