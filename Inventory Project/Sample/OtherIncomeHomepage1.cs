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
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public OtherIncomeHomepage1()
        {
            InitializeComponent();
        }

        private void OtherIncomeHomepage1_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_otherIncomeCaategory where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.ColumnCount = 2;
            dgvCategory.Columns[0].HeaderText = "Category";
            dgvCategory.Columns[0].DataPropertyName = "OtherIncome";
           


            dgvCategory.DataSource = dt;
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

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblBankAccount.Text = dgvCategory.Rows[e.RowIndex].Cells["Column1"].Value.ToString();

            string Query = string.Format("select Date,IncomeCategory,total,Paid,Balance from tbl_OtherIncome where IncomeCategory='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by Date,IncomeCategory,total,Paid,Balance", lblBankAccount.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvOtherincome.DataSource = ds;
            dgvOtherincome.DataMember = "temp";
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select total from tbl_OtherIncome where total like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvOtherincome.DataSource = ds;
                dgvOtherincome.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select OtherIncome from tbl_otherIncomeCaategory where OtherIncome  like '%{0}%' where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch.Text);
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

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvOtherincome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
