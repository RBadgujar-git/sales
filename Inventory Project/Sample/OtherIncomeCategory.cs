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
    public partial class OtherIncomeCategory : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public OtherIncomeCategory()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }
      
        private void fetchdetails()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("tbl_otherIncomeCategorySelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@OtherIncome", txtOtherIncome.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dt);
            dgvcategory.DataSource = dt;
            dgvcategory.AllowUserToAddRows= false;
        }
        private void cleardata()
        {
            txtOtherIncome.Text = "";
        }

        private void InsertData()
        {
            //PrincipleAmount,InterestAmount,Date,	TotalAmount,PaidFrom
            if (txtOtherIncome.Text == "")
            {
                MessageBox.Show("Other Income requried");
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("tbl_otherIncomeCategorySelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@OtherIncome", txtOtherIncome.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insert Data Successfully");
                
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        // tbl_otherIncomeCategorySelect
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                InsertData();
                fetchdetails();
                cleardata();
            }

            else
            {
                MessageBox.Show("Same Record Not Insert");
            }
        }
    private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtOtherIncome_KeyPress(object sender, KeyPressEventArgs e)
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

        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (txtOtherIncome.Text == "")
                    {
                         MessageBox.Show("Other Income requried");
                    }
                    else if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_otherIncomeCategorySelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@OtherIncome", txtOtherIncome.Text);
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
        private void label1_Click(object sender, EventArgs e)
        {

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
                        SqlCommand cmd = new SqlCommand("tbl_otherIncomeCategorySelect", con);
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
        
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT Delete??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete();
                fetchdetails();
                cleardata();
            }
        }

        private void dgvcategory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvcategory.SelectedRows[0].Cells["ID"].Value.ToString();
            txtOtherIncome.Text = dgvcategory.SelectedRows[0].Cells["OtherIncome"].Value.ToString();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
        }

        private void OtherIncomeCategory_Leave(object sender, EventArgs e)
        {

        }

        private void OtherIncomeCategory_Load(object sender, EventArgs e)
        {
            fetchdetails();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }


        private void insertCategory()
        {
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //string Query = String.Format("select OtherIncome from tbl_otherIncomeCaategory where DeleteData ='1' and Company_ID='" + NewCompany.company_id + "'");
            //DataSet ds = new DataSet();
            //SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            //SDA.Fill(ds, "Temp");
            //DataTable DT = new DataTable();
            //SDA.Fill(ds);
            //for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //{
            //    string catname = ds.Tables["Temp"].Rows[i]["OtherIncome"].ToString();
            //    if (catname.ToLower().ToString() == txtOtherIncome.Text.ToLower().ToString())
            //    {
            //        MessageBox.Show("This Category Already Exist");
            //    }

            //}
        }
        private void txtOtherIncome_TextChanged(object sender, EventArgs e)
        {
            insertCategory();
            txtOtherIncome.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ID,OtherIncome from tbl_otherIncomeCaategory where OtherIncome like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
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
    }
}
