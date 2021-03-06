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
    public partial class StockDetails : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public FormWindowState WindowState { get; private set; }

        public StockDetails()
        {
            InitializeComponent();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StockDetails_Load(object sender, EventArgs e)
        {
            fetchCampanyame();



        }
        private void fetchCampanyame()
        {
            if (cmbItemname.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster  where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by ItemName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbItemname.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
