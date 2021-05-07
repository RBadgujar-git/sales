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
    public partial class PaymentInHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public PaymentInHomepage()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Program.expdate)
            {

                Trialform tf = new Trialform();
                tf.Show();

            }
            else
            {
                PaymentIn BA = new PaymentIn();
                BA.TopLevel = false;

                //BA.AutoScroll = true;
                this.Controls.Add(BA);
                BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                BA.Dock = DockStyle.Fill;
                BA.Visible = true;
                BA.BringToFront();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void PaymentInHomepage_Load(object sender, EventArgs e)
        {
            binddata();
        }
        private void binddata()
        {
            try
            {
                string Query = string.Format("SELECT ReceiptNo,Date,CustomerName,PaymentType,Total,ReceivedAmount,UnusedAmount FROM tbl_PaymentIn where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
                dgvPaymentIn.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                string SelectQuery = string.Format("SELECT ReceiptNo,Date,CustomerName,PaymentType,Total,ReceivedAmount,UnusedAmount FROM tbl_PaymentIn where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ReceiptNo,Date, CustomerName, PaymentType, ReceivedAmount,UnusedAmount,Total from tbl_PaymentIn where  CustomerName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilterBy.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Program.expdate)
            {

                Trialform tf = new Trialform();
                tf.Show();

            }
            else
            {
                if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    try
                    {

                        DataSet ds = new DataSet();
                        //string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.Company_ID,b.TableName,b.PartyName,b.DueDate,b.InvoiceDate,b.Total,b.ReturnNo,b.Received,b.RemainingBal,b.Status,b.DeleteData FROM tbl_CompanyMaster as a, tbl_DebitNote as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData = '1' ");
                        string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.Company_ID,b.ReceiptNo,b.CustomerName,b.PaymentType,b.ReceivedAmount,b.UnusedAmount,b.Total,b.DeleteData FROM tbl_CompanyMaster as a, tbl_PaymentIn as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' ");
                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);

                        StiReport report = new StiReport();

                        report.Load(@"PaymetinData.mrt");

                        report.Compile();
                        StiPage page = report.Pages[0];
                        report.RegData("PaymentinData", "PaymentinData", ds.Tables[0]);

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

        private void label4_Click(object sender, EventArgs e)
        {
            binddata();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                string SelectQuery = string.Format("SELECT ReceiptNo,Date,CustomerName,PaymentType,Total,ReceivedAmount,UnusedAmount FROM tbl_PaymentIn where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
