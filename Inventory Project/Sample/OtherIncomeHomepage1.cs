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
using System.Globalization;

namespace sample
{
    public partial class OtherIncomeHomepage1 : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
      

        public FormWindowState WindowState { get; private set; }

        public OtherIncomeHomepage1()
        {
            InitializeComponent();
        }

        private void OtherIncomeHomepage1_Load(object sender, EventArgs e)
        {
            bindbankdata();
         //   search2();
        }
        private void bindbankdata()
        {
           
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select OtherIncome from tbl_otherIncomeCaategory where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            dgvCategory.DataSource = dt;

            //con.Open();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("select OtherIncome from tbl_otherIncomeCaategory where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            // con.Close();
            dgvCategory.AllowUserToAddRows = false;
            //dgvCategory.ColumnCount = 1;
            //dgvCategory.Columns[0].DataPropertyName = "OtherIncome";
            //dgvCategory.DataSource = dt;
            dgvOtherincome.AllowUserToAddRows = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Program.expdate)
            {

                Trialform tf = new Trialform();
                tf.Show();

            }
            else
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Program.expdate)
            {

                Trialform tf = new Trialform();
                tf.Show();

            }
            else
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
            lblBankAccount.Text = dgvCategory.Rows[e.RowIndex].Cells["OtherIncome"].Value.ToString();

            string Query = string.Format("select Date,IncomeCategory,total,Received,Balance from tbl_OtherIncome where IncomeCategory='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by Date,IncomeCategory,total,Received,Balance", lblBankAccount.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvOtherincome.DataSource = ds;
            dgvOtherincome.DataMember = "temp";
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvOtherincome.AllowUserToAddRows = false;
            lblBankAccount.Visible = true;

            //con.Open();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("select OtherIncome from tbl_otherIncomeCaategory where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //con.Close();

            con.Open();
            DataTable dt = new DataTable();
            SqlCommand Query1 = new SqlCommand("select Date,IncomeCategory,total,Received,Balance from tbl_OtherIncome where IncomeCategory like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'",con);
           
            SqlDataAdapter da1 = new SqlDataAdapter(Query1);
            da.Fill(dt);
            con.Close();
        }

        public void search2()
        {
            //try
            //{
            //    string Query = string.Format("select Date,IncomeCategory,total,Received,Balance from tbl_OtherIncome where IncomeCategory like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch2.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvOtherincome.DataSource = ds;
            //    dgvOtherincome.DataMember = "temp";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string Query = string.Format("select Date,IncomeCategory,total,Received,Balance from tbl_OtherIncome where IncomeCategory like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch2.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvOtherincome.DataSource = ds;
            //    dgvOtherincome.DataMember = "temp";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select OtherIncome from tbl_otherIncomeCaategory where OtherIncome  like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch.Text);
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtSearch2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void dgvOtherincome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
           try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string SelectQuery = string.Format("(select Date, IncomeCategory, total, Received, Balance from tbl_OtherIncome where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and IncomeCategory='"+lblBankAccount.Text+"' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");    //Feild1 IS NOT Null
                dgvOtherincome.DataSource = ds;
                dgvOtherincome.DataMember = "temp";
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
                string SelectQuery = string.Format("(select Date, IncomeCategory, total, Received, Balance from tbl_OtherIncome where IncomeCategory='" + lblBankAccount.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");    //Feild1 IS NOT Null
                dgvOtherincome.DataSource = ds;
                dgvOtherincome.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string SelectQuery = string.Format("(select Date, IncomeCategory, total, Received, Balance from tbl_OtherIncome where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and IncomeCategory='" + lblBankAccount.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");    //Feild1 IS NOT Null
                dgvOtherincome.DataSource = ds;
                dgvOtherincome.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
