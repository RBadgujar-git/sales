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
    public partial class ExpenseHomePage : UserControl
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public ExpenseHomePage()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

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
            SqlCommand cmd = new SqlCommand("select * from tbl_ExpenseCategory", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvcategory.AutoGenerateColumns = false;
            dgvcategory.ColumnCount = 1;
            dgvcategory.Columns[0].HeaderText = "Category";
            dgvcategory.Columns[0].DataPropertyName = "CategoryName";
            

            dgvcategory.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvcategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCategory.Text = dgvcategory.Rows[e.RowIndex].Cells["Column1"].Value.ToString();


            string Query = string.Format("select ID,Date,Total,Paid,Balance from tbl_Expenses where ExpenseCategory = '{0}' group by ID,Date,Total,Paid,Balance", lblCategory.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvExxpenses.DataSource = ds;
            dgvExxpenses.DataMember = "temp";

        }

        private void ExpenseHomePage_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CategoryName from tbl_ExpenseCategory where CategoryName like '%{0}%'", txtSearch.Text);
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

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ID from tbl_Expenses where ID like '%{0}%'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvExxpenses.DataSource = ds;
                dgvExxpenses.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
