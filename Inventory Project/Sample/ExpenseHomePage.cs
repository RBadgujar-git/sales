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
        SqlConnection sqlcon = new SqlConnection((Properties.Settings.Default.InventoryMgntConnectionString));
        SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public ExpenseHomePage()
        {
            InitializeComponent();
            con = new SqlConnection((Properties.Settings.Default.InventoryMgntConnectionString));

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
            SqlCommand cmd = new SqlCommand("select CategoryName from tbl_ExpenseCategory where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            this.dgvcategory.AllowUserToAddRows = false;
            dgvcategory.ColumnCount = 1;
            dgvcategory.Columns[0].DataPropertyName = "CategoryName"; 
            dgvcategory.DataSource = dt;
            dgvExxpenses.AllowUserToAddRows = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvcategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblCategory.Text = dgvcategory.Rows[e.RowIndex].Cells["Category"].Value.ToString();


                string Query = string.Format("select Date,ExpenseCategory,Total,Paid,Balance from tbl_Expenses where ExpenseCategory = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by Date, ExpenseCategory, Total,Paid,Balance", lblCategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvExxpenses.DataSource = ds;
                dgvExxpenses.DataMember = "temp";
                this.dgvcategory.AllowUserToAddRows = false;
                this.dgvExxpenses.AllowUserToAddRows = false;
                lblCategory.Visible = true;
            }
            catch(Exception ex)
            {
               //MessageBox.Show(ex.Message);
            }

        }

        private void ExpenseHomePage_Load(object sender, EventArgs e)
        {
            bindbankdata();
            //search1();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CategoryName from tbl_ExpenseCategory where CategoryName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch.Text);
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
        public void search1()
        {
            //try
            //{
            //    string Query = string.Format("select Date, ExpenseCategory, Total,Paid,Balance from tbl_Expenses where ExpenseCategory like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvExxpenses.DataSource = ds;
            //    dgvExxpenses.DataMember = "temp";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string Query = string.Format("select Date, ExpenseCategory, Total,Paid,Balance from tbl_Expenses where ExpenseCategory like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvExxpenses.DataSource = ds;
            //    dgvExxpenses.DataMember = "temp";
               
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvExxpenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvExxpenses.AllowUserToAddRows = false;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtSearch1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void dgvExxpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("(select Date, ExpenseCategory, Total,Paid,Balance from tbl_Expenses where Date between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "' and ExpenseCategory='" + lblCategory.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");    //Feild1 IS NOT Null
                dgvExxpenses.DataSource = ds;
                dgvExxpenses.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("(select Date, ExpenseCategory, Total,Paid,Balance from tbl_Expenses where ExpenseCategory='" + lblCategory.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");    //Feild1 IS NOT Null
                dgvExxpenses.DataSource = ds;
                dgvExxpenses.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
