﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace sample
{
    public partial class DeliveryChallanHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public DeliveryChallanHomepage()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Program.expdate)
            {

                Trialform tf = new Trialform();
                tf.Show();

            }
            else
            {
                DeliveryChallan BA = new DeliveryChallan();
                BA.TopLevel = false;
                // BA.AutoScroll = true;
                this.Controls.Add(BA);
                BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                BA.Dock = DockStyle.Fill;
                BA.Visible = true;
                BA.BringToFront();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void DeliveryChallanHomepage_Load(object sender, EventArgs e)
        {
            fetchCompany();
       //     bindbankdata();
            show();
        }
        private void fetchCompany()
        {
           
                //try
                //{
                //    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1' and Company_ID='" + NewCompany.company_id + "' group by CompanyName ");
                //    DataSet ds = new DataSet();
                //    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                //    SDA.Fill(ds, "Temp");
                //    DataTable DT = new DataTable();
                //    SDA.Fill(ds);
                //    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                //    {
                //        cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                //    }
                //}
                //catch (Exception e1)
                //{
                //    MessageBox.Show(e1.Message);
                //}
            
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_DeliveryChallan where DeleteData='1' and Company_ID='" + NewCompany.company_id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvdeliveryChallan.AutoGenerateColumns = false;
            dgvdeliveryChallan.ColumnCount = 9;
            dgvdeliveryChallan.Columns[0].HeaderText = "Type";
            dgvdeliveryChallan.Columns[0].DataPropertyName = "TableName";
            dgvdeliveryChallan.Columns[1].HeaderText = "Date";
            dgvdeliveryChallan.Columns[1].DataPropertyName = "InvoiceDate";
            dgvdeliveryChallan.Columns[2].HeaderText = "Ref No";
            dgvdeliveryChallan.Columns[2].DataPropertyName = "ReturnNo";
            dgvdeliveryChallan.Columns[3].HeaderText = "Party";
            dgvdeliveryChallan.Columns[3].DataPropertyName = "PartyName";
            dgvdeliveryChallan.Columns[4].HeaderText = "Total";
            dgvdeliveryChallan.Columns[4].DataPropertyName = "Total";
            dgvdeliveryChallan.Columns[5].HeaderText = "Paid/Recieved";
            dgvdeliveryChallan.Columns[5].DataPropertyName = "Received";
            dgvdeliveryChallan.Columns[6].HeaderText = "Balance";
            dgvdeliveryChallan.Columns[6].DataPropertyName = "RemainingBal";
            dgvdeliveryChallan.Columns[7].HeaderText = "Status";
            dgvdeliveryChallan.Columns[7].DataPropertyName = "Status";

            dgvdeliveryChallan.Columns[8].HeaderText = "Due Date";
            dgvdeliveryChallan.Columns[8].DataPropertyName = "DueDate";


        }

        public void show()
        {
            try
            {
                string Query = string.Format("select ChallanNo ,PartyName,BillingName,InvoiceDate,Total,Received from tbl_DeliveryChallan where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvdeliveryChallan.DataSource = ds;
                dgvdeliveryChallan.DataMember = "temp";
                dgvdeliveryChallan.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select  ChallanNo ,PartyName,BillingName,InvoiceDate,Total,Received  from tbl_DeliveryChallan where PartyName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvdeliveryChallan.DataSource = ds;
                dgvdeliveryChallan.DataMember = "temp";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtptodate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                string SelectQuery = string.Format("select  ChallanNo ,PartyName,BillingName,InvoiceDate,Total,Received  from tbl_DeliveryChallan where InvoiceDate between '" + dtpfromdate.Value.ToString(sysUIFormat) + "' and '" + dtptodate.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvdeliveryChallan.DataSource = ds;
                dgvdeliveryChallan.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Program.expdate)
            {

                Trialform tf = new Trialform();
                tf.Show();

            }
            else
            {
                if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        DataSet ds = new DataSet();
                        string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.Company_ID,b.ChallanNo,b.PartyName,b.BillingName,b.InvoiceDate,b.Total,b.Received,b.RemainingBal,b.DeleteData FROM tbl_CompanyMaster as a, tbl_DeliveryChallan as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData = '1' ");
                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);

                        StiReport report = new StiReport();
                        report.Load(@"DeliveryChallanDataReport.mrt");

                        report.Compile();
                        StiPage page = report.Pages[0];
                        report.RegData("DeliveryChallan", "DeliveryChallan", ds.Tables[0]);

                        report.Dictionary.Synchronize();
                        report.Render();
                        report.Show(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            show();
        }

        private void dtpfromdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                string SelectQuery = string.Format("select  ChallanNo ,PartyName,BillingName,InvoiceDate,Total,Received  from tbl_DeliveryChallan where InvoiceDate between '" + dtpfromdate.Value.ToString(sysUIFormat) + "' and '" + dtptodate.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvdeliveryChallan.DataSource = ds;
                dgvdeliveryChallan.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
