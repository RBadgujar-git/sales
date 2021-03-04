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
    public partial class ExpenseHomePage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        string id = "";
        public ExpenseHomePage()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Expenses BA = new Expenses();
            BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ExpenseCategory BA = new ExpenseCategory();
           // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
           // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select CategoryName from tbl_ExpenseCategory", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvcategory.AutoGenerateColumns = false;
            dgvcategory.ColumnCount = 1;
            dgvcategory.Columns[0].HeaderText = "Category";
            dgvcategory.Columns[0].DataPropertyName = "CategoryName";
            dgvcategory.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CategoryName from tbl_ExpenseCategory where CategoryName like '%{0}%'", txtSearch.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvcategory.DataSource = ds;
                dgvcategory.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExpenseHomePage_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }
    }
}
