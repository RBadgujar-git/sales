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
    public partial class LoanAccountHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public LoanAccountHomepage()
        {
            InitializeComponent();
           // SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
            // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoanAccount BA = new LoanAccount();
            //BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Makepayment BA = new Makepayment();
            // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LoanStatement BA = new LoanStatement();
            //  BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_LoanBank where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvbankAccount.AutoGenerateColumns = false;
            dgvbankAccount.ColumnCount = 2;
            dgvbankAccount.Columns[0].HeaderText = "Account";
            dgvbankAccount.Columns[0].DataPropertyName = "AccountName";
            dgvbankAccount.Columns[1].HeaderText = "Amount";
            dgvbankAccount.Columns[1].DataPropertyName = "CurrentBal";
            dgvbankAccount.DataSource = dt;
            dgvbankAccount.AllowUserToAddRows = false;
            dgvLoanAccount.AllowUserToAddRows = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select AccountName, CurrentBal from tbl_LoanBank where AccountName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvbankAccount.DataSource = ds;
                dgvbankAccount.DataMember = "temp";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoanAccountHomepage_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string Query = string.Format("select AccountNo,BalAsOf,LendarBank,CurrentBal,Interest,Duration from tbl_LoanBank where Company_ID='" + NewCompany.company_id + "' and AccountName='"+lblBankAccount+"' and LendarBank like '%{0}%' and DeleteData='1'", txtSearch2.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvLoanAccount.DataSource = ds;
            //    dgvLoanAccount.DataMember = "temp";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dgvbankAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblBankAccount.Text = dgvbankAccount.Rows[e.RowIndex].Cells["Column1"].Value.ToString();

            string Query = string.Format("select AccountNo,BalAsOf,LendarBank,CurrentBal,Interest,Duration from tbl_LoanBank where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and AccountName='{0}' group by AccountNo,BalAsOf,LendarBank,CurrentBal,Interest,Duration", lblBankAccount.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvLoanAccount.DataSource = ds;
            dgvLoanAccount.DataMember = "temp";
        }

        private void dgvbankAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLoanAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                string Query = string.Format("(select AccountNo,BalAsOf,LendarBank,CurrentBal,Interest,Duration from tbl_LoanBank where BalAsOf between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "' and AccountName='" + lblBankAccount.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvLoanAccount.DataSource = ds;
                dgvLoanAccount.DataMember = "temp";
                dgvbankAccount.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("(select AccountNo,BalAsOf,LendarBank,CurrentBal,Interest,Duration from tbl_LoanBank where AccountName='" + lblBankAccount.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");    //Feild1 IS NOT Null
                dgvLoanAccount.DataSource = ds;
                dgvLoanAccount.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
