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
    public partial class PaymentOutHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public PaymentOutHomepage()
        {
            InitializeComponent();
        }

        private void btnaddPaymennt_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Program.expdate)
            {

                Trialform tf = new Trialform();
                tf.Show();

            }
            else
            {
                PaymentOut BA = new PaymentOut();
                BA.TopLevel = false;
                // BA.AutoScroll = true;
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

        private void PaymentOutHomepage_Load(object sender, EventArgs e)
        {

            binddaata();
           // dgvPaymentOut.AllowUserToAddRows = false;
            //try
            //{
            //    con.Open();
            //    DataTable dt = new DataTable();
            //    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Paymentout where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", con);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            //    SDA.Fill(ds, "temp");
            //    con.Close();
            //    dgvPaymentOut.AutoGenerateColumns = false;
            //    dgvPaymentOut.ColumnCount = 6;
            //    dgvPaymentOut.Columns[0].HeaderText = "Receipt No";
            //    dgvPaymentOut.Columns[0].DataPropertyName = "ReceiptNo";
            //    dgvPaymentOut.Columns[1].HeaderText = " Party Name";
            //    dgvPaymentOut.Columns[1].DataPropertyName = "CustomerName";
            //    dgvPaymentOut.Columns[2].HeaderText = "Payment Type";
            //    dgvPaymentOut.Columns[2].DataPropertyName = "PaymentType";
            //    dgvPaymentOut.Columns[3].HeaderText = "Paid";
            //    dgvPaymentOut.Columns[3].DataPropertyName = "Paid";
            //    dgvPaymentOut.Columns[4].HeaderText = "Discount";
            //    dgvPaymentOut.Columns[4].DataPropertyName = "Discount";
            //    dgvPaymentOut.Columns[5].HeaderText = "Total";
            //    dgvPaymentOut.Columns[5].DataPropertyName = "Total";
            //    dgvPaymentOut.DataSource = dt;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            
        }
        public void binddaata()
        {
            try
            {
                string Query = string.Format("select ReceiptNo, CustomerName, PaymentType, Paid,Discount,Total from tbl_Paymentout where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPaymentOut.DataSource = ds;
                dgvPaymentOut.DataMember = "temp";
                dgvPaymentOut.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ReceiptNo, CustomerName, PaymentType, Paid,Discount,Total from tbl_Paymentout where  CustomerName like '%{0}%'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilterBy.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPaymentOut.DataSource = ds;
                dgvPaymentOut.DataMember = "temp";
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

                string SelectQuery = string.Format("select ReceiptNo,CustomerName,PaymentType,Total,Paid,Discount from tbl_Paymentout where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPaymentOut.DataSource = ds;
                dgvPaymentOut.DataMember = "temp";
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
                        string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.Company_ID,b.CustomerName,b.ReceiptNo,b.PaymentType,b.Discount,b.Total,b.Paid,b.DeleteData FROM tbl_CompanyMaster as a, tbl_Paymentout as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData = '1' ");
                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);

                        StiReport report = new StiReport();
                        report.Load(@"PaymentOutDataReport.mrt");

                        report.Compile();
                        StiPage page = report.Pages[0];
                        report.RegData("PaymentOut", "PaymentOut", ds.Tables[0]);

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

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                string SelectQuery = string.Format("select ReceiptNo,CustomerName,PaymentType,Total,Paid,Discount from tbl_Paymentout where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvPaymentOut.DataSource = ds;
                dgvPaymentOut.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            binddaata();
        }
    }
}
