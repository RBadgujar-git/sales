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
    public partial class CompanyList : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        public CompanyList()
        {
            InitializeComponent();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            
            NewCompany BA = new NewCompany();        
           this.Controls.Add(BA);

            BA.Location = new Point(230, 55);

            BA.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void Binddata()
        {
           

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("Select CompanyName as Company_Name from tbl_CompanyMaster where DeleteData = 1", con);           
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvCompanylist.DataSource = dtable;


        }
        private void dgvCompanylist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CompanyName from tbl_CompanyMaster where CompanyName like'%{0}%' ", txtSearch.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvCompanylist.DataSource = ds;
                dgvCompanylist.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CompanyList_Load(object sender, EventArgs e)
        {
            Binddata();
        }
    }
}
