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
            SqlCommand cmd = new SqlCommand("select AccountName as Account, CurrentBal as Amount from tbl_LoanBank", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvLoanAccount.AutoGenerateColumns = false;
            dgvLoanAccount.ColumnCount = 2;
            dgvLoanAccount.Columns[0].HeaderText = "Account";
            dgvLoanAccount.Columns[0].DataPropertyName = "AccountName";
            dgvLoanAccount.Columns[1].HeaderText = "Amount";
            dgvLoanAccount.Columns[1].DataPropertyName = "CurrentBal";
            dgvbankAccount.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select AccountName,CurrentBal from tbl_LoanBank where AccountName like '%{0}%'", txtSearch1.Text);
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
    }
}
