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
namespace sample
{
    public partial class CompanyBankAccountHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public CompanyBankAccountHomepage()
        {
            InitializeComponent();
        }

        private void btnSaleorder_Click(object sender, EventArgs e)
        {
            CompanyBankAccount BA = new CompanyBankAccount();
            //BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }
        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("(select ID,BankName,AccountName,AccountNo,OpeningBal,Date from CompanyBankAccount where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvcompanybank.DataSource = dt;
            dgvcompanybank.AllowUserToAddRows = false;
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
               
           
        }

        private void CompanyBankAccountHomepage_Load(object sender, EventArgs e)
        {
            fetchdetails();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvcompanybank_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string Query = string.Format("select ID,BankName,AccountName,AccountNo,OpeningBal,Date from CompanyBankAccount where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvcompanybank.DataSource = ds;
                dgvcompanybank.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            fetchdetails();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fetchdetails();
            }
            else
            {
                string Query = string.Format("(select ID,BankName,AccountName,AccountNo,OpeningBal,Date from CompanyBankAccount where Company_ID ='" + NewCompany.company_id + "' and DeleteData='1'  and BankName like '%{0}%')", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvcompanybank.DataSource = ds;
                dgvcompanybank.DataMember = "temp";
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string Query = string.Format("select ID,BankName,AccountName,AccountNo,OpeningBal,Date from CompanyBankAccount where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvcompanybank.DataSource = ds;
                dgvcompanybank.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
