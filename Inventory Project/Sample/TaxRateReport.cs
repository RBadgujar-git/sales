using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace sample
{
    public partial class TaxRateReport : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        public TaxRateReport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvTaxRate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TaxRateReport_Load(object sender, EventArgs e)
        {
            fetchCompany();
            con.Open();
            SqlCommand cd = new SqlCommand("select sum(SaleTaxAmount) as total from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataReader dr = cd.ExecuteReader();
            while (dr.Read())
            {
                txtTotalTaxIn.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
            con.Close();
            con.Open();
            SqlCommand cd1 = new SqlCommand("select sum(PurchaseTaxAmount) from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataReader dr1 = cd1.ExecuteReader();
            while (dr1.Read())
            {
                txtTaxOut.Text = dr1.GetValue(0).ToString();
            }
            dr1.Close();
            con.Close();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("Select ItemName,TaxForSale,SaleTaxAmount,TaxForPurchase,PurchaseTaxAmount from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                //union all select a.Company_ID,a.EntryType,a.Amount,a.Date,a.Description,b.BankName,b.OpeningBal  from tbl_BankAdjustment as a,tbl_BankAccount as b where b.BankName='{0}' AND a.Company_ID='" + NewCompany.company_id + "'", cmbbankname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvTaxRate.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void fetchCompany()
        {
            if (cmbAllFirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'group by CompanyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbAllFirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void cmbAllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("(select ItemName,TaxForSale,SaleTaxAmount,TaxForPurchase,PurchaseTaxAmount from tbl_ItemMaster where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1')", cmbAllFirms.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvTaxRate.DataSource = ds;
                dgvTaxRate.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Data();
        }
        private void Data()
        {
            float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
           
            for (int i = 0; i < dgvTaxRate.Rows.Count; i++)
            {
                TA += float.Parse(dgvTaxRate.Rows[i].Cells["Column2"].Value?.ToString());
                txtTotalTaxIn.Text = TA.ToString();
                TD += float.Parse(dgvTaxRate.Rows[i].Cells["Column3"].Value?.ToString());
                txtTaxOut.Text = TD.ToString();

                //qty = float.Parse(txtPaid.Text.ToString());
                //rate = float.Parse(txtUnpaid.Text.ToString());
                //total = qty + rate;
                //txtTotal.Text = total.ToString();
            }
        }
        private void Bindadata()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dgvTaxRate.AutoGenerateColumns = false;
            dgvTaxRate.ColumnCount = 8;
            dgvTaxRate.Columns[0].HeaderText = "Item Name";
            dgvTaxRate.Columns[0].DataPropertyName = "ItemName";
            dgvTaxRate.Columns[1].HeaderText = " Tax For Sale ";
            dgvTaxRate.Columns[1].DataPropertyName = "TaxForSale";
            dgvTaxRate.Columns[2].HeaderText = " Sale Tax Amount";
            dgvTaxRate.Columns[2].DataPropertyName = "SaleTaxAmount";
            dgvTaxRate.Columns[3].HeaderText = " Tax For Purchase";
            dgvTaxRate.Columns[3].DataPropertyName = "TaxForPurchase";
            dgvTaxRate.Columns[4].HeaderText = "Purchase Tax Amount";
            dgvTaxRate.Columns[4].DataPropertyName = "PurchaseTaxAmount";
            
            dgvTaxRate.DataSource = dt;
        }//BillDate,BillNo,PartyName,PaymentType,Total,Paid,Rema


        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select ItemName,TaxForSale,SaleTaxAmount,TaxForPurchase,PurchaseTaxAmount  from tbl_ItemMaster where Date between '" + dtpFromdate.Value.ToString() + "' and '" + dtpToDate.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvTaxRate.DataSource = ds;
                dgvTaxRate.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("Select a.CompanyName,a.AddLogo,a.GSTNumber,a.EmailID,a.PhoneNo,a.Address,b.ItemName,b.TaxForSale,b.SaleTaxAmount,b.TaxForPurchase,b.PurchaseTaxAmount from tbl_ItemMaster as b,tbl_CompanyMaster as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1'");
                    //string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.InvoiceID,b.PaymentType,b.Company_ID,b.Received,b.RemainingBal,b.Total,b.InvoiceDate FROM tbl_CompanyMaster as a, tbl_SaleInvoice as b where b.InvoiceDate='{0}' and a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "'",date1);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"TaxRateReport1.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("TaxRateReport", "TaxRateReport", ds.Tables[0]);

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
}
