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
using System.Globalization;

namespace sample
{
    public partial class Cheque1 : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        string id = "";
        public Cheque1()
        {
            InitializeComponent();
        }

        private void Cheque1_Load(object sender, EventArgs e)
        {
         //   fetchCompany();
            Bindadata();
        }
        private void fetchCompany()
        {
        //    if (cmbAllfirms.Text != "System.Data.DataRowView")
        //    {
        //        try
        //        {
        //            string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CompanyName");
        //            DataSet ds = new DataSet();
        //            SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
        //            SDA.Fill(ds, "Temp");
        //            DataTable DT = new DataTable();
        //            SDA.Fill(ds);
        //            for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
        //            {
        //                cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
        //            }
        //        }
        //        catch (Exception e1)
        //        {
        //            MessageBox.Show(e1.Message);
        //        }
        //    }
        }
        private void Bindadata()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("(select TableName, InvoiceDate as Date,InvoiceID as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PaymentType='Cheque')union all(select TableName,BillDate as Date,BillNo as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Feild1 IS NOT Null and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PaymentType='Cheque')", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvSaleOrder.DataSource = dt;
            dgvSaleOrder.AllowUserToAddRows = false;
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string Query = string.Format("(select TableName, InvoiceDate as Date,InvoiceID as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Received,RemainingBal,Status from tbl_SaleInvoice where InvoiceDate between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and PaymentType='Cheque' and DeleteData = '1' union all select TableName,BillDate as Date,BillNo as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and PaymentType='Cheque' and DeleteData = '1')", textBox1.Text);

                //  string Query = string.Format("select TableName,InvoiceDate,InvoiceID,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and TableName like '%{0}%' or PartyName like '%{0}%' and DeleteData='1' union all select TableName,OrderDate,OrderNo,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and TableName like '%{0}%' or PartyName like '%{0}%' and DeleteData='1'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSaleOrder.DataSource = ds;
                dgvSaleOrder.DataMember = "temp";
                dgvSaleOrder.AllowUserToAddRows = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ex.ToString());
            }
            
        }

        private void dtpTo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
           
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bindadata();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string Query = string.Format("(select TableName, InvoiceDate as Date,InvoiceID as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Received,RemainingBal,Status from tbl_SaleInvoice where InvoiceDate between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and PaymentType='Cheque' and DeleteData = '1' union all select TableName,BillDate as Date,BillNo as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and PaymentType='Cheque' and DeleteData = '1')", textBox1.Text);

                //  string Query = string.Format("select TableName,InvoiceDate,InvoiceID,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and TableName like '%{0}%' or PartyName like '%{0}%' and DeleteData='1' union all select TableName,OrderDate,OrderNo,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and TableName like '%{0}%' or PartyName like '%{0}%' and DeleteData='1'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSaleOrder.DataSource = ds;
                dgvSaleOrder.DataMember = "temp";
                dgvSaleOrder.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Bindadata();
            }
            else
            {
                string Query = string.Format("(select TableName, InvoiceDate as Date,InvoiceID as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Received,RemainingBal,Status from tbl_SaleInvoice where  Company_ID='" + NewCompany.company_id + "' and TableName like '%{0}%' and PaymentType='Cheque' and DeleteData = '1' union all select TableName,BillDate as Date,BillNo as Number,PartyName,PaymentType,Feild1 as CheckNo,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and  TableName like '%{0}%' and PaymentType='Cheque' and DeleteData = '1')", textBox1.Text);

                //  string Query = string.Format("select TableName,InvoiceDate,InvoiceID,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and TableName like '%{0}%' or PartyName like '%{0}%' and DeleteData='1' union all select TableName,OrderDate,OrderNo,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and TableName like '%{0}%' or PartyName like '%{0}%' and DeleteData='1'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSaleOrder.DataSource = ds;
                dgvSaleOrder.DataMember = "temp";
            }
        }
    }
}
