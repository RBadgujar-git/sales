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

  
    public partial class PurchaseOrderHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public FormWindowState WindowState { get; private set; }

        public PurchaseOrderHomepage()
        {
            InitializeComponent();
        }

        private void btnpurchaseorder_Click(object sender, EventArgs e)
        {
            PurchaseOrder BA = new PurchaseOrder();
             BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
             BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvPurchaseOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        public void binddata()
        {
            try
            {

                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                string Query = string.Format("select OrderNo,PartyName,ContactNo,OrderDate,Paid,Total,RemainingBal,Status from tbl_PurchaseOrder where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
               dgvPurchaseOrder.DataSource = ds;
                dgvPurchaseOrder.DataMember = "temp";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PurchaseOrderHomepage_Load(object sender, EventArgs e)
        {
            binddata();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
