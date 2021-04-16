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
    public partial class DiscountReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public DiscountReport()
        {
            InitializeComponent();
        }

        private void DiscountReport_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select TableName as Type,PartyName,Discount as 'SaleDiscount/PurchaseDiscount' from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select TableName as Type,PartyName,Discount as 'SaleDiscount/PurchaseDiscount' from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                //union all select a.Company_ID,a.EntryType,a.Amount,a.Date,a.Description,b.BankName,b.OpeningBal  from tbl_BankAdjustment as a,tbl_BankAccount as b where b.BankName='{0}' AND a.Company_ID='" + NewCompany.company_id + "'", cmbbankname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvDiscountReport.DataSource = dt;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

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
                    // string Query = String.Format("select InvoiceDate as Date,TableName as Type,Received as 'Profit/Loss' from tbl_saleinvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select BillDate as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select Date as Date,TableName as Type,Received as 'Profit/Loss'from  tbl_OtherIncome where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select Date as Date,TableName as Type,Paid as 'Profit/Loss' from  tbl_Expenses where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                    // string Query = String.Format("select TableName as Type,PartyName,TaxAmountShow as 'SaleTax/PurchaseTax' from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select TableName as Type,PartyName,TaxShow as 'SaleTax/PurchaseTax' from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                    string Query = String.Format("select TableName as Type,PartyName,Discount as 'SaleDiscount/PurchaseDiscount' from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select TableName as Type,PartyName,Discount as 'SaleDiscount/PurchaseDiscount' from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");

                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"DiscountReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("DiscountReport", "DiscountReport", ds.Tables[0]);

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
