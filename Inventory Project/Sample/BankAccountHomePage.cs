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
        private void bindbankdata()
        { 
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_BankAccount", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvBankAccount.AutoGenerateColumns = false;
            dgvBankAccount.ColumnCount = 2;
            dgvBankAccount.Columns[0].HeaderText = "Account";
            dgvBankAccount.Columns[0].DataPropertyName = "AccountName";
            dgvBankAccount.Columns[1].HeaderText = "Amount";
            dgvBankAccount.Columns[1].DataPropertyName = "OpeningBal";    
            dgvBankAccount.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select AccountName,OpeningBal from tbl_BankAccount where AccountName like '%{0}%'", txtSearch1.Text);
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
    }
  }

