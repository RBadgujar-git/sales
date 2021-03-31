using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sample
{
    public partial class BankAccount : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public BankAccount()
        {
            InitializeComponent();
          //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }


        public void Binddata()
        {
            con.Open();
            string selectquery = string.Format("Select * from tbl_BankAccount where Company_ID='"+NewCompany.company_id+"' and DeleteData='1'");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(selectquery, con);
            sda.Fill(ds, "temp");
            DataTable dt = new DataTable();
            sda.Fill(ds);
        }

        private void Cleardata()
        {
            txtbankname.Text = "";
            txtaccountname.Text = "";
            txtaccountno.Text = "";
            txtopeningbal.Text = "";
        }

        private void fetchdetails()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("BankAccountSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@BankName", txtbankname.Text);
            cmd.Parameters.AddWithValue("@AccountName", txtaccountname.Text);
            cmd.Parameters.AddWithValue("@AccountNo", txtaccountno.Text);
            cmd.Parameters.AddWithValue("@OpeningBal", txtopeningbal.Text);

            cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
            cmd.Parameters.AddWithValue("@compid",NewCompany.company_id);
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);

            sdasql.Fill(dtable);
            dgvbankaccount.DataSource = dtable;
           
            
        }
        public void Insert()
        {
            try
            {
                if (txtbankname.Text == "")
                {
                    MessageBox.Show("Bank Name Is Requried");
                    txtbankname.Focus();
                }
                else if (txtaccountname.Text == "")
                {
                    MessageBox.Show("Bank Holder Name Is Requried");
                    txtaccountname.Focus();
                }
                else if (txtaccountno.Text == "")
                {
                    MessageBox.Show("Account NO Is Requried");
                    txtaccountno.Focus();
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("BankAccountSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@BankName", txtbankname.Text);
                    cmd.Parameters.AddWithValue("@AccountName", txtaccountname.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", txtaccountno.Text);
                    cmd.Parameters.AddWithValue("@OpeningBal", txtopeningbal.Text);

                    cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    int num = cmd.ExecuteNonQuery();
                 
                    if (num > 0)
                    {
                        MessageBox.Show("Insert data Successfully");
                        Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please try again");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            BankAccountHomePage cb = new BankAccountHomePage();
           
            try
            {
                if (id == "")
                {
                    Insert();
                    txtbankname.Focus();
                    fetchdetails();
                    cb.bindbankdata();
                }
                else
                {
                    MessageBox.Show("You Have To No Permission To Insert This Record");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("error"+ex);
            }
        }

      

        private void BankAccount_Load(object sender, EventArgs e)
        {
            BankAccountHomePage cb = new BankAccountHomePage();
            fetchdetails();
            clearData();
            cb.bindbankdata();
        }

       
        public void update()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {

                    if (txtbankname.Text == "")
                    {
                        MessageBox.Show("Bank Name Is Requried");
                        txtbankname.Focus();
                    }
                    else if (txtaccountname.Text == "")
                    {
                        MessageBox.Show("Bank Holder Name Is Requried");
                        txtaccountname.Focus();
                    }
                    else if (txtaccountno.Text == "")
                    {
                        MessageBox.Show("Account NO Is Requried");
                        txtaccountno.Focus();
                    }
                    else
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("BankAccountSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@BankName", txtbankname.Text);
                        cmd.Parameters.AddWithValue("@AccountName", txtaccountname.Text);
                        cmd.Parameters.AddWithValue("@AccountNo", txtaccountno.Text);
                        cmd.Parameters.AddWithValue("@OpeningBal", txtopeningbal.Text);
                        cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                        int num = cmd.ExecuteNonQuery();
                        //if (num > 0)
                        //{
                            MessageBox.Show("Update data Successfully");
                            clearData();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please Select Record");
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }     
        private void btnupdate_Click(object sender, EventArgs e)
        {
            update();
            txtbankname.Focus();

            clearData();
            fetchdetails();
        }
        public void Delete()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {

                    if (txtbankname.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (txtaccountname.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (txtaccountno.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else
                    {

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("BankAccountSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Delete");
                        cmd.Parameters.AddWithValue("@ID", id);
                        int num = cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Delete data Successfully");
                            Cleardata();
                        }
                        else
                        {
                            MessageBox.Show("Please Select Record");
                        }
                    }
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Delete();
            txtaccountname.Focus();

            fetchdetails();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvbankaccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvbankaccount.SelectedRows[0].Cells["ID"].Value.ToString();
            txtbankname.Text = dgvbankaccount.SelectedRows[0].Cells["BankName"].Value.ToString();
            txtaccountname.Text = dgvbankaccount.SelectedRows[0].Cells["AccountName"].Value.ToString();
            txtaccountno.Text = dgvbankaccount.SelectedRows[0].Cells["AccountNo"].Value.ToString();
            txtopeningbal.Text = dgvbankaccount.SelectedRows[0].Cells["OpeningBal"].Value.ToString();
            dtpdate.Text = dgvbankaccount.SelectedRows[0].Cells["Date"].Value.ToString();
           // txtDetails.Text = dgvItemAdjustment.SelectedRows[0].Cells["Details"].Value.ToString();
        }
        public void clearData()
        {
            txtopeningbal.Text = txtbankname.Text = txtaccountno.Text = txtaccountname.Text = "";
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtaccountname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }

        private void txtaccountno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtopeningbal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbankname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtbankname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvbankaccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtaccountno_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtopeningbal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtaccountname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                fetchdetails();
                // hidedata();
            }
            else
            {
                string Query = string.Format("select * from tbl_BankAccount where AccountName like '%{0}%' or ID like '%{0}%' and  Company_ID='" + NewCompany.company_id + "' DeleteData = '1'", textBox2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvbankaccount.DataSource = ds;
                dgvbankaccount.DataMember = "temp";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
