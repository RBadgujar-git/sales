﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System.Globalization;

namespace sample
{
    public partial class EstimateQuotationhomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public EstimateQuotationhomepage()
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
                Estimate_Quotation BA = new Estimate_Quotation();
                BA.TopLevel = false;
                // BA.AutoScroll = true;
                this.Controls.Add(BA);
                //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                BA.Dock = DockStyle.Fill;
                BA.Visible = true;
                BA.BringToFront();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select Date,PartyName,Total,Status from tblQuotation where PartyName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvEstimate.DataSource = ds;
                dgvEstimate.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EstimateQuotationhomepage_Load(object sender, EventArgs e)
        {
            fetchCompany();
            bindbankdata();
        }

        private void fetchCompany()
        {
            //if (cmbAllfirms.Text != "System.Data.DataRowView")
            //{
            //    try
            //    {
            //        string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'  group by CompanyName ");
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
            //        SDA.Fill(ds, "Temp");
            //        DataTable DT = new DataTable();
            //        SDA.Fill(ds);
            //        for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //        {
            //            cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
            //        }
            //    }
            //    catch (Exception e1)
            //    {
            //        MessageBox.Show(e1.Message);
            //    }
            //}
        }
        private void bindbankdata()
        {
            try
            {
                string Query = string.Format("select Date,PartyName,Total,Status from tblQuotation where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvEstimate.DataSource = ds;
                dgvEstimate.DataMember = "temp";
                dgvEstimate.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                string SelectQuery = string.Format("select Date,PartyName,Total,Status from tblQuotation where Date between '" + dtpfrom.Value.ToString(sysUIFormat) + "' and '" + dtpto.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvEstimate.DataSource = ds;
                dgvEstimate.DataMember = "temp";
                dgvEstimate.AllowUserToAddRows = false;
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

        private void dgvEstimate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            bindbankdata();
        }

        private void btnprint_Click(object sender, EventArgs e)
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
                        string Query = string.Format("SELECT a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.Date,b.Total,b.Status FROM tbl_CompanyMaster as a, tblQuotation as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData = '1' ");
                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);

                        StiReport report = new StiReport();
                        report.Load(@"EstimateHomeReport.mrt");

                        report.Compile();
                        StiPage page = report.Pages[0];
                        report.RegData("Estimate", "Estimate", ds.Tables[0]);

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

        private void dtpfrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                string SelectQuery = string.Format("select Date,PartyName,Total,Status from tblQuotation where Date between '" + dtpfrom.Value.ToString(sysUIFormat) + "' and '" + dtpto.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvEstimate.DataSource = ds;
                dgvEstimate.DataMember = "temp";
                dgvEstimate.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }

        }
    }
}
