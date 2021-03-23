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
    public partial class DayBook : UserControl
    {
        public string date1;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);


        public FormWindowState WindowState { get; private set; }

        public DayBook()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       

        private void DayBook_Load(object sender, EventArgs e)
        {
            if (radioButton1.Checked = true)
            {
                bind_sale();
            }
            else if (radioButton2.Checked = true)
            {
                bind_purchase();
            }
            else
            {
                dgvdaybook.Rows.Clear();
            }
          // = DateTime.Now.ToShortDateString();
          
           // bind_purchase();
        }
        private void bind_sale()
        {
            try
            {
                date1 = DateTime.Now.ToString("MM/dd/yyyy");
                String Str = string.Format("Select PartyName as Name,InvoiceID as ReferenceNo,PaymentType as Type,Total as Total,Received as MoneyIn,RemainingBal as MoneyOut from tbl_SaleInvoice where InvoiceDate='{0}' and Company_ID='"+NewCompany.company_id+"' and DeleteData='1'",date1);
                DataSet Ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Str, con);
                SDA.Fill(Ds, "Temp");
               
                dgvdaybook.DataSource = Ds;
                dgvdaybook.DataMember = "Temp";
               
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                Bind_sale_TotalAmount();
            }
        }

        //private void BindPurchase_TotalAmount()
        //{
        //    try
        //    {
        //        float Sum = 0;

        //        for (int i = 0; i < dgvdaybook.Rows.Count; i++)
        //        {
        //            Sum = Sum + float.Parse(dgvdaybook.Rows[i].Cells[2].Value.ToString());
        //            txtMoneyOut.Text = Sum.ToString();
        //        }
        //    }
        //    catch (Exception e1)
        //    {
        //        //MessageBox.Show(e1.Message);
        //    }
        //}
        private void bind_purchase()
        {
            try
            {
                date1 = DateTime.Now.ToString("MM/dd/yyyy");
                String Str = string.Format("Select PartyName as Name,BillNo as ReferenceNo,PaymentType as Type,Total as Total,Received as MoneyIn,RemainingBal as MoneyOut from tbl_PurchaseBill where BillDate='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", date1);
                DataSet Ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Str, con);
                SDA.Fill(Ds, "Temp");

                dgvdaybook.DataSource = Ds;
                dgvdaybook.DataMember = "Temp";

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                Bind_sale_TotalAmount();
            }
        }
        private void Bind_sale_TotalAmount()
        {
            try
            {
                float Sum = 0;

                for (int i = 0; i < dgvdaybook.Rows.Count; i++)
                {
                    Sum = Sum + float.Parse(dgvdaybook.Rows[i].Cells[3].Value.ToString());
                    txtmoneyIn.Text = Sum.ToString();
                }
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public string date;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    date = DateTime.Now.ToString("MM/dd/yyyy");
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.InvoiceID,b.PaymentType,b.Company_ID,b.Received,b.RemainingBal,b.Total,b.InvoiceDate FROM tbl_CompanyMaster as a, tbl_SaleInvoice as b where b.InvoiceDate='{0}' and a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "'",date1);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"DayBookReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("DayBook", "DayBook", ds.Tables[0]);

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
