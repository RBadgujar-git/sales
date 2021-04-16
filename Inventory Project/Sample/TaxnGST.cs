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
    public partial class TaxnGST : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public int Hsn;
        public int supplace;
        public int eway;
        public int enablegst;
        public int enablegst1;

        public TaxnGST()
        {
            InitializeComponent();
        }

        public FormWindowState WindowState { get; private set; }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TaxnGST_Load(object sender, EventArgs e)
        {
            chkEnableHSn.Hide();
            chkEnablePlace.Hide();
            chkEWayBilling.Hide();
            chkGenerateEWay.Hide();
            chkRevesreCharges.Hide();
            chkAdditionalCases.Hide();
            chkComposite.Hide();
            txtRemainder.Hide();
            guna2Button2.Hide();
            cheekpass1();
            if (Hsn == 1)
            {
                chkEnableHSn.Checked = true;
                chkEnablleGSt.Checked = true;
            }
            if (supplace == 1)
            {
                chkEnablePlace.Checked = true;
                chkEnablleGSt.Checked = true;
            }
            if (eway == 1)
            {
                chkEWayBilling.Checked = true;
                chkEnablleGSt.Checked = true;
            }
            if(Cess==1)
            {
                chkAdditionalCases.Checked = true;
                chkEnablleGSt.Checked = true;
            }
        }
        public int Cess;
        public void cheekpass1()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd2 = new SqlCommand("Select * from TransactionTableSetting where Company_ID='" + NewCompany.company_id + "'", con);
                SqlDataReader dr1 = cmd2.ExecuteReader();

                while (dr1.Read())
                {
                    Hsn = Convert.ToInt32(dr1["HSN"]);
                    supplace = Convert.ToInt32(dr1["PlaceOfSupply"]);  
                    eway = Convert.ToInt32(dr1["EwayBill"]);
                    Cess = Convert.ToInt32(dr1["Cess"]);
                    enablegst = Convert.ToInt32(dr1["EnableGst"]);
                }
                dr1.Close();
            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
            finally {  }
        }
        private void chkEnableHSn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableHSn.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set HSN = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkEnableHSn.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set HSN = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();

            }
        }
        public int checkpoint=0;
        private void chkAdditionalCases_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdditionalCases.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set Cess = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkAdditionalCases.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set Cess = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkEWayBilling_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEWayBilling.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set EwayBill = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkEWayBilling.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set EwayBill = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkEnablleGSt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnablleGSt.Checked == true)
            {
                chkEnableHSn.Show();
                chkEnablePlace.Show();
                chkEWayBilling.Show();
                chkGenerateEWay.Show();
                chkRevesreCharges.Show();
                chkAdditionalCases.Show();
                chkComposite.Show();
                txtRemainder.Show();
                guna2Button2.Show();
            }
            if (chkEnablleGSt.Checked == false)
            {
                chkEnableHSn.Hide();
                chkEnablePlace.Hide();
                chkEWayBilling.Hide();
                chkGenerateEWay.Hide();
                chkRevesreCharges.Hide();
                chkAdditionalCases.Hide();
                chkComposite.Hide();
                txtRemainder.Hide();
                guna2Button2.Hide();
            }
        }

        private void chkRevesreCharges_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
