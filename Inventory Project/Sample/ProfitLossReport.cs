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
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace sample
{
    public partial class ProfitLossReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public static int compid;
        public FormWindowState WindowState { get; private set; }

        public ProfitLossReport()
        {
            InitializeComponent();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void ProfitLossReport_Load(object sender, EventArgs e)
        {
            fetchCompany();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select InvoiceDate as Date,TableName as Type,Received as 'Profit/Loss' from tbl_saleinvoice where Company_ID='"+NewCompany.company_id+ "' and DeleteData='1' union select BillDate as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select Date as Date,TableName as Type,Received as 'Profit/Loss'from  tbl_OtherIncome where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select Date as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_Expenses where Company_ID='" + NewCompany.company_id+"' and DeleteData='1'");
                //union all select a.Company_ID,a.EntryType,a.Amount,a.Date,a.Description,b.BankName,b.OpeningBal  from tbl_BankAdjustment as a,tbl_BankAccount as b where b.BankName='{0}' AND a.Company_ID='" + NewCompany.company_id + "'", cmbbankname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvProfitnlossReport.DataSource = dt;
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

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void fetchCompany()
        {
            if (cmbAllFirms.Text != "System.Data.DataRowView")
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
                        cmbAllFirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void cmbAllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmbAllFirms.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    compid = Convert.ToInt32(dr["CompanyID"].ToString());
                    //MessageBox.Show("Test" + compid);
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
            string Query = string.Format("select InvoiceDate as Date,TableName as Type,Received as 'Profit/Loss' from tbl_saleinvoice where Company_ID='" + compid + "' and DeleteData='1' union select BillDate as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_PurchaseBill where Company_ID='" + compid + "' and DeleteData='1' union select Date as Date,TableName as Type,Received as 'Profit/Loss'from  tbl_OtherIncome where Company_ID='" + compid + "' and DeleteData='1' union select Date as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_Expenses where Company_ID='" + compid + "' and DeleteData='1'", cmbAllFirms.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvProfitnlossReport.DataSource = ds;
            dgvProfitnlossReport.DataMember = "temp";
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = String.Format("select InvoiceDate as Date,TableName as Type,Received as 'Profit/Loss' from tbl_saleinvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select BillDate as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select Date as Date,TableName as Type,Received as 'Profit/Loss'from  tbl_OtherIncome where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select Date as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_Expenses where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");

                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"Profit&Loss.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("Profit&Loss", "Profit&Loss", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)
                {
                    //   MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
