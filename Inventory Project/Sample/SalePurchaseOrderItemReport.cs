using System;
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

namespace sample
{
    public partial class SalePurchaseOrderItemReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public static int compid;
        public FormWindowState WindowState { get; private set; }

        public SalePurchaseOrderItemReport()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void SalePurchaseOrderItemReport_Load(object sender, EventArgs e)
        {
                fetchCompany();
                con.Open();
                SqlCommand cmd = new SqlCommand("select  ItemName,Qty,freeQty,ItemAmount from tbl_PurchaseOrderInner union all select ItemName,Qty,freeQty,ItemAmount from tbl_SaleOrderInner where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(ds, "temp");
                dgvSalepurchhase.DataSource = ds;
                dgvSalepurchhase.DataMember = "temp";
                dgvSalepurchhase.AllowUserToAddRows = false;
                con.Close();
          
        }
        private void fetchCompany()
        {
            if (cmbAllFirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1' group by CompanyName");
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dtpTodate_Enter(object sender, EventArgs e)
        {
        }

        private void dgvSalepurchhase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select ItemName,Qty,freeQty,ItemAmount from tbl_PurchaseOrderInner where ItemName like '%{0}%'  union all select ItemName,Qty,freeQty,ItemAmount from tbl_SaleOrderInner where ItemName like '%{0}%' and Company_ID='" + compid + "' and DeleteData='1'", txtFilterBy.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvSalepurchhase.DataSource = ds;
                dgvSalepurchhase.DataMember = "temp";
                dgvSalepurchhase.AllowUserToAddRows = false;
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

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    //string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.Company_ID,b.OrderNo,b.PartyName,b.ContactNo,b.OrderDate,b.Total,b.Paid,b.RemainingBal,b.Status,b.DeleteData FROM tbl_CompanyMaster as a, tbl_PurchaseOrder as b where a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData = '1' ");
                    string Query = string.Format("select ItemName, Qty,freeQty, ItemAmount from tbl_PurchaseOrderInner union all select ItemName,Qty,freeQty,ItemAmount from tbl_SaleOrderInner  where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"SalePurchaseOrderItemReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("SalePurchaseOrderItem", "SalePurchaseOrderItem", ds.Tables[0]);

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

        public void companyinfo()
        {

            //string Query = string.Format("select TableName,OrderDate,OrderNo,PartyName,PaymentType,Total,DueDate,Status from tbl_SaleOrder where Company_ID='" + compid + "' and DeleteData='1' union all select TableName,OrderDate,OrderNo,PartyName,PaymentType,Total,DueDate,Status from tbl_PurchaseOrder where Company_ID='" + compid + "' and DeleteData='1'", cmbAllFirms.Text);
            string Query = string.Format("select  ItemName,Qty,freeQty,ItemAmount from tbl_PurchaseOrderInner union all select ItemName,Qty,freeQty,ItemAmount from tbl_SaleOrderInner where Company_ID='" + compid + "' and DeleteData='1'",cmbAllFirms);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvSalepurchhase.DataSource = ds;
            dgvSalepurchhase.DataMember = "temp";
            dgvSalepurchhase.AllowUserToAddRows = false;
        }

        private void cmbAllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmbAllFirms.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    compid = Convert.ToInt32(dr["CompanyID"].ToString());
                    //MessageBox.Show("Test" + compid);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                companyinfo();
               // data();
            }

        }
    }
}
