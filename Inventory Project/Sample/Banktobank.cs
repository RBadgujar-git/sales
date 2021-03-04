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
    public partial class Banktobank : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public Banktobank()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void Cleardata()
        {
            cmbfrombank.Text = "";
            txttobank.Text = "";
            txtAmount.Text = "";
            txtDescription.Text = "";
        }
        private void fetchdetails()
        {         
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            SqlCommand cmd = new SqlCommand("Banktobank", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID",0);
            cmd.Parameters.AddWithValue("@FromBank", cmbfrombank.Text);
            cmd.Parameters.AddWithValue("@ToBank", txttobank.Text);
            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
            cmd.Parameters.AddWithValue("@Descripition", txtDescription.Text);
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvbanktobank.DataSource = dtable;     
    }

        public void Insert()
        {
            try
            {
                if (cmbfrombank.Text == "")
                {
                    MessageBox.Show("Bank Name Required");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("Banktobank", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@FromBank", cmbfrombank.Text);
                    cmd.Parameters.AddWithValue("@ToBank", txttobank.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@Descripition", txtDescription.Text);
                  
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
            fetchdetails();
            Cleardata();
        }

       
        private void Banktobank_Load(object sender, EventArgs e)
        {

            fetchdetails();
            bankfetch();
        }
        private void bankfetch()
        {
            if (cmbfrombank.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select BankName from tbl_BankAccount group by BankName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbfrombank.Items.Add(ds.Tables["Temp"].Rows[i]["BankName"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }
       


       

        private void dgvbanktobank_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvbanktobank.SelectedRows[0].Cells["ID"].Value.ToString();
            cmbfrombank.Text = dgvbanktobank.SelectedRows[0].Cells["FromBank"].Value.ToString();
            txttobank.Text = dgvbanktobank.SelectedRows[0].Cells["ToBank"].Value.ToString();
            txtAmount.Text = dgvbanktobank.SelectedRows[0].Cells["Amount"].Value.ToString();
            dtpDate.Text = dgvbanktobank.SelectedRows[0].Cells["Date"].Value.ToString();
            txtDescription.Text = dgvbanktobank.SelectedRows[0].Cells["Descripition"].Value.ToString();
            // txtDetails.Text = dgvItemAdjustment.SelectedRows[0].Cells["Details"].Value.ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttobank_KeyPress(object sender, KeyPressEventArgs e)
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
                    SqlCommand cmd = new SqlCommand("Banktobank", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@FromBank", cmbfrombank.Text);
                    cmd.Parameters.AddWithValue("@ToBank", txttobank.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@Descripition", txtDescription.Text);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Update data Successfully");
                        Cleardata();
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
            Cleardata();
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
                    SqlCommand cmd = new SqlCommand("Banktobank", con);
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
        private void btndelete_Click(object sender, EventArgs e)
        {
            Delete();
            fetchdetails();
            Cleardata();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }
    }
}