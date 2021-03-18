﻿using System;
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
    public partial class CompanyBankAccount : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public CompanyBankAccount()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Insert();
            clearData();
            fetchdetails();
        }
        public void Insert()
        {
            try
            {
                if (txtBankName.Text == "")
                {
                    MessageBox.Show("Bank Name Is Requried");
                    txtBankName.Focus();
                }
                else if (txtAccountName.Text == "")
                {
                    MessageBox.Show("Bank Holder Name Is Requried");
                    txtAccountName.Focus();
                }
                else if (txtAccountNo.Text == "")
                {
                    MessageBox.Show("Account NO Is Requried");
                    txtAccountNo.Focus();
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("sp_CompanyBankAccount", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                    cmd.Parameters.AddWithValue("@OpeningBal", txtOpeningBal.Text);

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
        private void Cleardata()
        {
            txtBankName.Text = "";
            txtAccountName.Text = "";
            txtAccountNo.Text = "";
            txtOpeningBal.Text = "";
        }
        private void fetchdetails()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("sp_CompanyBankAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
            cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
            cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
            cmd.Parameters.AddWithValue("@OpeningBal", txtOpeningBal.Text);

            cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);

            sdasql.Fill(dtable);
            dgvbankaccount.DataSource = dtable;


        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void CompanyBankAccount_Load(object sender, EventArgs e)
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

                    if (txtBankName.Text == "")
                    {
                        MessageBox.Show("Bank Name Is Requried");
                        txtBankName.Focus();
                    }
                    else if (txtAccountName.Text == "")
                    {
                        MessageBox.Show("Bank Holder Name Is Requried");
                        txtAccountName.Focus();
                    }
                    else if (txtAccountNo.Text == "")
                    {
                        MessageBox.Show("Account NO Is Requried");
                        txtAccountNo.Focus();
                    }
                    else
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("sp_CompanyBankAccount", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
                        cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
                        cmd.Parameters.AddWithValue("@AccountNo", txtAccountNo.Text);
                        cmd.Parameters.AddWithValue("@OpeningBal", txtOpeningBal.Text);
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

                    if (txtBankName.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (txtAccountName.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (txtAccountNo.Text == "")
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
                        SqlCommand cmd = new SqlCommand("sp_CompanyBankAccount", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "delete");
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            Delete();
            fetchdetails();
        }

        private void dgvbankaccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvbankaccount.SelectedRows[0].Cells["ID"].Value.ToString();
            txtBankName.Text = dgvbankaccount.SelectedRows[0].Cells["BankName"].Value.ToString();
            txtAccountName.Text = dgvbankaccount.SelectedRows[0].Cells["AccountName"].Value.ToString();
            txtAccountNo.Text = dgvbankaccount.SelectedRows[0].Cells["AccountNo"].Value.ToString();
            txtOpeningBal.Text = dgvbankaccount.SelectedRows[0].Cells["OpeningBal"].Value.ToString();
            dtpdate.Text = dgvbankaccount.SelectedRows[0].Cells["Date"].Value.ToString();
           //txtDetails.Text = dgvItemAdjustment.SelectedRows[0].Cells["Details"].Value.ToString();
        }
        public void clearData()
        {
            txtOpeningBal.Text = txtBankName.Text = txtAccountNo.Text = txtAccountName.Text = "";
        }

        private void txtbankname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtaccountname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtopeningbal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtaccountno_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
