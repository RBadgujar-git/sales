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
    public partial class GSTR1 : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public GSTR1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GSTR1_Load(object sender, EventArgs e)
        {
            Bindadata();
        }
        private void Bindadata()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

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
            dgvsaleInvoice.AllowUserToAddRows = false;
        }//BillDate,BillNo,PartyName,PaymentType,Total,Paid,Rema

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select a.InvoiceId,a.InvoiceDate,a.CalTotal,a.TaxAmountShow,a.PartyName,a.Total,c.CompanyName,c.PhoneNo,c.EmailID,c.Address,c.AddLogo,c.GSTNumber from tbl_SaleInvoice as a,tbl_CompanyMaster as c where a.Company_ID='"+NewCompany.company_id+"' and a.DeleteData='1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"GSTR1Data.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("GSTR1Data", "GSTR1Data", ds.Tables[0]);

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
