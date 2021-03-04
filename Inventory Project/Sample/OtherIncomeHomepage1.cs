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
    public partial class OtherIncomeHomepage1 : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public OtherIncomeHomepage1()
        {
            InitializeComponent();
        }

        private void OtherIncomeHomepage1_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OtherIncomeCategory BA = new OtherIncomeCategory();
            //BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OtherIncome BA = new OtherIncome();
            BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select OtherIncome from tbl_otherIncomeCaategory", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.ColumnCount = 1;
            dgvCategory.Columns[0].HeaderText = "Category";
            dgvCategory.Columns[0].DataPropertyName = "OtherIncome";


            dgvCategory.DataSource = dt;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select OtherIncome from tbl_otherIncomeCaategory where OtherIncome like '%{0}%'", txtSearch.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvCategory.DataSource = ds;
                dgvCategory.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
