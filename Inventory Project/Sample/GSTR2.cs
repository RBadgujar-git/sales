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
using System.Globalization;

namespace sample
{
    public partial class GSTR2 : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public GSTR2()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void GSTR2_Load(object sender, EventArgs e)
        {
            Bindadata();
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
                dgvsaleInvoice.DataSource = ds;
                dgvsaleInvoice.DataMember = "temp";
                dgvsaleInvoice.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select a.CompanyName,a.PhoneNo,a.Address,a.EmailID,a.GSTNumber,a.AddLogo,b.BillNo,b.BillDate,b.CalTotal,b.TaxShow,b.PartyName,b.Total from tbl_companymaster as a,tbl_PurchaseBill as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1'");

                    //string Query = string.Format("Select InvoiceID,InvoiceDate,CalTotal,TaxAmountShow,PartyName,Total from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id+"' and DeleteData='1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"GSTR2DataReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("GSTR2Data", "GSTR2Data", ds.Tables[0]);

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

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string Query = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate between '" + dtpFromdate.Value.ToString(sysUIFormat) + "' and '" + dtpToDate.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvsaleInvoice.DataSource = ds;
                dgvsaleInvoice.DataMember = "temp";
                dgvsaleInvoice.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Bindadata();
        }

        private void dtpFromdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string Query = string.Format("select BillDate,BillNo,PartyName,PaymentType,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate between '" + dtpFromdate.Value.ToString(sysUIFormat) + "' and '" + dtpToDate.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvsaleInvoice.DataSource = ds;
                dgvsaleInvoice.DataMember = "temp";
                dgvsaleInvoice.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
