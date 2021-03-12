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
    public partial class LoanAccount : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public LoanAccount()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void LoanAccount_Load(object sender, EventArgs e)
        {
            fetchdetails();
            //fetchCompany();
            bankfetch();
            companyfetch();
        }
        private void bankfetch()
        {
            if (cmbAccount.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select BankName from tbl_BankAccount where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by BankName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbAccount.Items.Add(ds.Tables["Temp"].Rows[i]["BankName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        //private void fetchCompany()
        //{
        //    try
        //    {
        //        con.Open();
        //        string Query = String.Format("select CompanyName from tbl_CompanyMaster where Deletedata='1' GROUP BY CompanyName ");
        //        SqlCommand cmd = new SqlCommand(Query, con);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            txtcompanyname.Text = dr["CompanyName"].ToString();
        //        }
        //        dr.Close();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {

        //    }
        //}


        private void fetchdetails()
        {
            //AccountName,AccountNo,Description,LendarBank,
            //FirmName,CurrentBal,LoanReceive,Interest,Duration,ProcessingFees,PaidBy,AdditionalFeild1,AdditionalFeild
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_LoanBankSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@AccountName", "");
            cmd.Parameters.AddWithValue("@AccountNo", "");
            cmd.Parameters.AddWithValue("@Description", "");
            cmd.Parameters.AddWithValue("@LendarBank", "");
            cmd.Parameters.AddWithValue("@FirmName", "");
            cmd.Parameters.AddWithValue("@CurrentBal", "");
            cmd.Parameters.AddWithValue("@LoanReceive", "");
            cmd.Parameters.AddWithValue("@Interest", "");
            cmd.Parameters.AddWithValue("@Duration", "");
            cmd.Parameters.AddWithValue("@ProcessingFees", "");
            cmd.Parameters.AddWithValue("@PaidBy", "");
            cmd.Parameters.AddWithValue("@loanamount", "");
            cmd.Parameters.AddWithValue("@total", "");
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            cmd.Parameters.AddWithValue("@Action", "Select");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
           
              dgvDescription.DataSource = dtable;
            con.Close();
        }

        private void cleardata()
        {
            cmbAccount.Text = "";
            txtAccountNo.Text = "";
            txtDescription.Text = "";
            txtLenderBank.Text = "";
            txtcompanyname.Text = "";
            txtCurrentBal.Text = "";
            cmbLoanReceive.Text = "";
            txtinterest.Text = "";
            txtTermDuration.Text = "";
            txtProcessingFees.Text = "0";
            cmbfees.Text = "";
            txtLoanAmount.Text = "";
            txtTotal.Text = "";
        }

        private void InsertData()
        {
            //AccountName,AccountNo,Description,LendarBank,
            //FirmName,CurrentBal,LoanReceive,Interest,Duration,ProcessingFees,PaidBy,AdditionalFeild1,AdditionalFeild
            try
            {
                if (cmbAccount.Text == "")
                {
                    MessageBox.Show("Account Name is requried");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_LoanBankSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@AccountName", cmbAccount.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@LendarBank", txtLenderBank.Text);
                    cmd.Parameters.AddWithValue("@FirmName", txtcompanyname.Text);
                    cmd.Parameters.AddWithValue("@CurrentBal", txtCurrentBal.Text);
                    cmd.Parameters.AddWithValue("@LoanReceive", cmbLoanReceive.Text);
                    cmd.Parameters.AddWithValue("@Interest", txtinterest.Text);
                    cmd.Parameters.AddWithValue("@Duration", txtTermDuration.Text);
                    cmd.Parameters.AddWithValue("@ProcessingFees", txtProcessingFees.Text);
                    cmd.Parameters.AddWithValue("@PaidBy", cmbfees.Text);
                    cmd.Parameters.AddWithValue("@loanamount", txtLoanAmount.Text);
                    cmd.Parameters.AddWithValue("@total", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert data Successfully");
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgvDescription_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvDescription.SelectedRows[0].Cells["ID"].Value.ToString();
            cmbAccount.Text = dgvDescription.SelectedRows[0].Cells["AccountName"].Value.ToString();
            txtAccountNo.Text = dgvDescription.SelectedRows[0].Cells["AccountNo"].Value.ToString();
            txtDescription.Text = dgvDescription.SelectedRows[0].Cells["Description"].Value.ToString();
            txtLenderBank.Text = dgvDescription.SelectedRows[0].Cells["LendarBank"].Value.ToString();
            txtcompanyname.Text = dgvDescription.SelectedRows[0].Cells["FirmName"].Value.ToString();
            txtCurrentBal.Text= dgvDescription.SelectedRows[0].Cells["CurrentBal"].Value.ToString();
            dtpdate.Text= dgvDescription.SelectedRows[0].Cells["BalAsOf"].Value.ToString();
            cmbLoanReceive.Text = dgvDescription.SelectedRows[0].Cells["LoanReceive"].Value.ToString();
            txtinterest.Text= dgvDescription.SelectedRows[0].Cells["Interest"].Value.ToString();        
            txtTermDuration.Text= dgvDescription.SelectedRows[0].Cells["Duration"].Value.ToString();
            txtProcessingFees.Text= dgvDescription.SelectedRows[0].Cells["ProcessingFees"].Value.ToString();
            cmbfees.Text= dgvDescription.SelectedRows[0].Cells["PaidBy"].Value.ToString();
            txtLoanAmount.Text = dgvDescription.SelectedRows[0].Cells["LoanAmount"].Value.ToString();
            txtTotal.Text = dgvDescription.SelectedRows[0].Cells["Total"].Value.ToString();
        }
        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_LoanBankSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@AccountName", cmbAccount.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@LendarBank", txtLenderBank.Text);
                    cmd.Parameters.AddWithValue("@FirmName", txtcompanyname.Text);
                    cmd.Parameters.AddWithValue("@CurrentBal", txtCurrentBal.Text);
                    cmd.Parameters.AddWithValue("@LoanReceive", cmbLoanReceive.Text);
                    cmd.Parameters.AddWithValue("@Interest", txtinterest.Text);
                    cmd.Parameters.AddWithValue("@Duration", txtTermDuration.Text);
                    cmd.Parameters.AddWithValue("@ProcessingFees", txtProcessingFees.Text);
                    cmd.Parameters.AddWithValue("@PaidBy", cmbfees.Text);
                    cmd.Parameters.AddWithValue("@loanamount", txtLoanAmount.Text);
                    cmd.Parameters.AddWithValue("@total", txtTotal.Text);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Update data Successfully");
                        cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
                finally { con.Close(); }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Update1();
            fetchdetails();
            cleardata();
        }

        public void Delete()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_LoanBankSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Delete");
                    cmd.Parameters.AddWithValue("@ID", id);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Delete data Successfully");
                        cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
                finally { con.Close(); }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //calopenbal();
            //update_opening_bal();
            InsertData();
            fetchdetails();
            cleardata();
        }
        public void calopenbal()
        {
            float opening_bal = 0, amount = 0, remain_opening = 0;

            opening_bal = float.Parse(txtCurrentBal.Text);
            amount = float.Parse(txtTotal.Text);

            remain_opening = opening_bal + amount;
            txtCurrentBal.Text = remain_opening.ToString();
        }
        public void update_opening_bal()
        {
            try
            {
                con.Open();
                String query = string.Format("update tbl_BankAccount set OpeningBal='" + txtCurrentBal.Text + "' where (BankName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbAccount.Text);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtAccountname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCurrentBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtLenderBank_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTermDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')           // Allowing only any letter OR Digit      // Allowing BackSpace character
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtProcessingFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCompanyName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }
        public void companyfetch()
        {
            //try
            //{
            //    con.Open();
            //    string Query = String.Format("select CompanyName from tbl_CompanyMaster where Deletedata='1' GROUP BY CompanyName ");
            //    SqlCommand cmd = new SqlCommand(Query, con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        txtcompanyname.Text = dr["CompanyName"].ToString();
            //    }
            //    dr.Close();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //}
            txtcompanyname.Text = NewCompany.companyname;
        }
        private void cmbLoanReceive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Delete();
            fetchdetails();
            cleardata();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cleardata();
        }

        private void dgvDescription_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtinterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select OpeningBal from tbl_BankAccount where (BankName='{0}') and Deletedata='1' and Company_ID='" + NewCompany.company_id + "' GROUP BY OpeningBal ", cmbAccount.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtCurrentBal.Text = dr["OpeningBal"].ToString();
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void txtCurrentBal_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //float emi;
          

            //float principal, rate, time,fee;
            //principal = float.Parse(txtLoanAmount.Text);
            //rate = float.Parse(txtinterest.Text);
            //time = float.Parse(txtTermDuration.Text);
            //fee = float.Parse(txtProcessingFees.Text);
          
            //emi = (principal * rate * time) / 100;
            //txtTotal.Text = (emi + principal + fee).ToString();
        }

        private void txtProcessingFees_KeyDown(object sender, KeyEventArgs e)
        {
            //float emi;


            //float principal, rate, time, fee;
            //principal = float.Parse(txtLoanAmount.Text);
            //rate = float.Parse(txtinterest.Text);
            //time = float.Parse(txtTermDuration.Text);
            //fee = float.Parse(txtProcessingFees.Text);

            //emi = (principal * rate * time) / 100;
            //txtTotal.Text = (emi + principal + fee).ToString();
        }

        private void txtcompanyname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
