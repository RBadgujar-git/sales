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
    public partial class AllParties : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public AllParties()
        {
            InitializeComponent();
          //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void fetchcustomername()
        {
            if (cmballparties.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmballparties.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());

                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void fetchGroupname()
        {
            //if (cmballgroup.Text != "System.Data.DataRowView") {
            //    try {
            //        string SelectQuery = string.Format("select AddPartyGroup from tbl_PartyGroup group by AddPartyGroup");
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
            //        SDA.Fill(ds, "Temp");
            //        DataTable DT = new DataTable();
            //        SDA.Fill(ds);
            //        for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
            //            cmballgroup.Items.Add(ds.Tables["Temp"].Rows[i]["AddPartyGroup"].ToString());

            //        }
            //    }
            //    catch (Exception e1) {
            //        MessageBox.Show(e1.Message);
            //    }
            //}
        }

        private void AllParties_Load(object sender, EventArgs e)
        {
            dtpdate.Enabled = false;
            binddata();
            fetchcustomername();
            fetchGroupname();
           
        }
        public void binddata()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select TableName,PartyName,InvoiceDate as Date, ContactNo,Received as 'Recived/Paid' from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union all select TableName,PartyName, OrderDate as Date, ContactNo,Received as 'Recived/Paid'  from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union all select TableName,PartyName, BillDate as Date, ContactNo,Paid as 'Recived/Paid' from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union all select TableName,PartyName,  OrderDate as Date ,ContactNo,Paid as 'Recived/Paid'  from tbl_PurchaseOrder  where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvAllparties.DataSource = dt;
                dgvAllparties.AllowUserToAddRows = false;
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

        private void btnimport_Click(object sender, EventArgs e)
        {
            ImportParties BA = new ImportParties();
            //  BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmballparties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmballparties.SelectedItem == "All Parties")
            {
                binddata();
            }
            else
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select TableName,PartyName,InvoiceDate as Date,ContactNo,Received as 'Recived/Paid' from tbl_SaleInvoice where PartyName='{0}' and DeleteData='1' union all select TableName,PartyName, OrderDate as Date, ContactNo,Received as 'Recived/Paid'  from tbl_SaleOrder where PartyName='{0}' and DeleteData='1' union all select TableName,PartyName, BillDate as Date, ContactNo,Paid as 'Recived/Paid' from tbl_PurchaseBill where PartyName='{0}'union all select TableName,PartyName, OrderDate as Date ,ContactNo,Paid as 'Recived/Paid'  from tbl_PurchaseOrder  where PartyName = '{0}'  AND Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmballparties.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvAllparties.DataSource = dt;
                con.Close();
            }
          
        }

        private void dgvAllparties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = String.Format("select TableName,PartyName, ContactNo,Received as 'Recived/Paid' from tbl_SaleInvoice where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Received as 'Recived/Paid'  from tbl_SaleOrder where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Paid as 'Recived/Paid' from tbl_PurchaseBill where PartyName='{0}'union all select TableName,PartyName, ContactNo,Paid as 'Recived/Paid'  from tbl_PurchaseOrder  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "'", cmballparties.Text);

                    // string Query = string.Format("select c.CompanyID,c.CompanyName,c.PhoneNo,c.EmailID,c.GSTNumber,b.PartyName ,b.ContactNo,b.Received From tbl_PurchaseBill as b,tbl_CompanyMaster as c where CompanyID='" + NewCompany.company_id + "' and b.PartyName='{0}'",cmballparties.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"AllPartiesReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("AllParties", "AllParties", ds.Tables[0]);

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

        private void chkdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdate.Checked == true)
            {
                dtpdate.Enabled = true;
            }
            else
            {
                dtpdate.Enabled = false;
            }
        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select TableName,PartyName,InvoiceDate as Date, ContactNo,Received as 'Recived/Paid' from tbl_SaleInvoice where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union all select TableName,PartyName, OrderDate as Date, ContactNo,Received as 'Recived/Paid'  from tbl_SaleOrder where OrderDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union all select TableName,PartyName, BillDate as Date, ContactNo,Paid as 'Recived/Paid' from tbl_PurchaseBill where BillDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union all select TableName,PartyName,  OrderDate as Date ,ContactNo,Paid as 'Recived/Paid'  from tbl_PurchaseOrder  where OrderDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvAllparties.DataSource = dt;
                dgvAllparties.AllowUserToAddRows = false;
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
    }
}
