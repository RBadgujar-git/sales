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
    public partial class BankAccountHomePage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public BankAccountHomePage()
        {
            InitializeComponent();
            // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BankAccount BA = new BankAccount();
            BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdjustAccount BA = new AdjustAccount();
            // BA.TopLevel = false;
            //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banktobank BA = new Banktobank();
            //  BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void BankAccountHomePage_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }
        public void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select AccountName,OpeningBal from tbl_BankAccount where Company_ID='" + NewCompany.company_id + "' And DeleteData='1'  ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
           
            dgvBankAccount.DataSource = dt;
            //dgvBankAccount.AutoGenerateColumns = false;
            //dgvBankAccount.ColumnCount = 2;
            //dgvBankAccount.Columns[0].HeaderText = "AccountName";
            //dgvBankAccount.Columns[0].DataPropertyName = "AccountName";
            //dgvBankAccount.Columns[1].HeaderText = "Opening Balance";
            //dgvBankAccount.Columns[1].DataPropertyName = "OpeningBal";
            //dgvBankAccount.DataSource = dt;
            dgvBankAccount.AllowUserToAddRows = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {
            BankAccountHomePage cb = new BankAccountHomePage();
            cb.bindbankdata();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvBankAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblBankAccount.Text = dgvBankAccount.Rows[e.RowIndex].Cells["Column1"].Value.ToString();

            string Query = string.Format("select AccountNo,AccountName,BankName,Date,OpeningBal from tbl_BankAccount where AccountName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by AccountNo,AccountName,BankName,Date,OpeningBal", lblBankAccount.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvBankAcc.DataSource = ds;
            dgvBankAcc.DataMember = "temp";

        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select AccountName,OpeningBal from tbl_BankAccount where AccountName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvBankAccount.DataSource = ds;
                dgvBankAccount.DataMember = "temp";
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)

            {
                string Query = string.Format("select AccountNo,AccountName,BankName,Date,OpeningBal from tbl_BankAccount where DeleteData='1' and AccountName like '%{0}%' and  Company_ID ='" + NewCompany.company_id + "'", txtSearch2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvBankAcc.DataSource = ds;
                dgvBankAcc.DataMember = "temp";
            }
        

        private void dgvBankAcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBankAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
