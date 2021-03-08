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
            Insert();
            clearData();
            fetchdetails();
        }

      

        private void BankAccount_Load(object sender, EventArgs e)
        {
            fetchdetails();
            clearData();
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
    }
}
