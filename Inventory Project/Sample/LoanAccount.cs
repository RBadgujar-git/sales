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
        public LoanAccount()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void LoanAccount_Load(object sender, EventArgs e)
        {
            fetchdetails();
            fetchCompany();
        }
        private void fetchCompany()
        {
            if (cmbCompanyName.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbCompanyName.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());

                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

       
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
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            cmd.Parameters.AddWithValue("@Action", "Select");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
           
              dgvDescription.DataSource = dtable;
           
        }

        private void cleardata()
        {
            txtAccountname.Text = "";
            txtAccountNo.Text = "";
            txtDescription.Text = "";
            txtLenderBank.Text = "";
            cmbCompanyName.Text = "";
            txtCurrentBal.Text = "";
            cmbLoanReceive.Text = "";
            txtintereat.Text = "";
            txtTermDuration.Text = "";
            txtProcessingFees.Text = "";
            cmbfees.Text = "";
        }

        private void InsertData()
        {
            //AccountName,AccountNo,Description,LendarBank,
            //FirmName,CurrentBal,LoanReceive,Interest,Duration,ProcessingFees,PaidBy,AdditionalFeild1,AdditionalFeild
            try
            {
                if (txtAccountname.Text == "")
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
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountname.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@LendarBank", txtLenderBank.Text);
                    cmd.Parameters.AddWithValue("@FirmName", cmbCompanyName.Text);
                    cmd.Parameters.AddWithValue("@CurrentBal", txtCurrentBal.Text);
                    cmd.Parameters.AddWithValue("@LoanReceive", cmbLoanReceive.Text);
                    cmd.Parameters.AddWithValue("@Interest", txtintereat.Text);
                    cmd.Parameters.AddWithValue("@Duration", txtTermDuration.Text);
                    cmd.Parameters.AddWithValue("@ProcessingFees", txtProcessingFees.Text);
                    cmd.Parameters.AddWithValue("@PaidBy", cmbfees.Text);
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert data Successfully");
                   
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
            txtAccountname.Text = dgvDescription.SelectedRows[0].Cells["AccountName"].Value.ToString();
            txtAccountNo.Text = dgvDescription.SelectedRows[0].Cells["AccountNo"].Value.ToString();
            txtDescription.Text = dgvDescription.SelectedRows[0].Cells["Description"].Value.ToString();
            txtLenderBank.Text = dgvDescription.SelectedRows[0].Cells["LendarBank"].Value.ToString();
            cmbCompanyName.Text = dgvDescription.SelectedRows[0].Cells["FirmName"].Value.ToString();
            txtCurrentBal.Text= dgvDescription.SelectedRows[0].Cells["CurrentBal"].Value.ToString();
            dtpdate.Text= dgvDescription.SelectedRows[0].Cells["BalAsOf"].Value.ToString();
            cmbLoanReceive.Text = dgvDescription.SelectedRows[0].Cells["LoanReceive"].Value.ToString();
            txtintereat.Text= dgvDescription.SelectedRows[0].Cells["Interest"].Value.ToString();        
            txtTermDuration.Text= dgvDescription.SelectedRows[0].Cells["Duration"].Value.ToString();
            txtProcessingFees.Text= dgvDescription.SelectedRows[0].Cells["ProcessingFees"].Value.ToString();
            cmbfees.Text= dgvDescription.SelectedRows[0].Cells["PaidBy"].Value.ToString();
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
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountname.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@LendarBank", txtLenderBank.Text);
                    cmd.Parameters.AddWithValue("@FirmName", cmbCompanyName.Text);
                    cmd.Parameters.AddWithValue("@CurrentBal", txtCurrentBal.Text);
                    cmd.Parameters.AddWithValue("@LoanReceive", cmbLoanReceive.Text);
                    cmd.Parameters.AddWithValue("@Interest", txtintereat.Text);
                    cmd.Parameters.AddWithValue("@Duration", txtTermDuration.Text);
                    cmd.Parameters.AddWithValue("@ProcessingFees", txtProcessingFees.Text);
                    cmd.Parameters.AddWithValue("@PaidBy", cmbfees.Text);
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
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertData();
            fetchdetails();
            cleardata();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtAccountname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
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
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtTermDuration_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
