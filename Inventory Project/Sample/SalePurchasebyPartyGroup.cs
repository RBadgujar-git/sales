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

namespace sample
{
    public partial class SalePurchasebyPartyGroup : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public SalePurchasebyPartyGroup()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmbAAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SalePurchasebyPartyGroup_Load(object sender, EventArgs e)
        {
            fetchCompany();
            data();
        }

        private void data()
        {
            try
            {
                con.Open();
                string Query = string.Format("select TableName,PartyName, OrderDate as Date,Total from tbl_SaleOrder where  PartyName = '{0}' union all select TableName,PartyName, OrderDate as Date,Total from tbl_PurchaseOrder where  PartyName = '{0}' union all select TableName,PartyName, BillDate as Date,Total from tbl_PurchaseBill where  PartyName = '{0}' union all  select TableName,PartyName, InvoiceDate as Date,Total from tbl_SaleInvoice where  PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSalepurchaseReport.DataSource = ds;
                dgvSalepurchaseReport.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }


        private void fetchCompany()
        {
            if (cmbAAllfirms.Text != "System.Data.DataRowView")
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
                        cmbAAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void fetchPartyGroup()
        {
            if (cmbGroup.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select AddPartyGroup from tbl_PartyGroupSelect where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CompanyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbGroup.Items.Add(ds.Tables["Temp"].Rows[i]["AddPartyGroup"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                string Query = string.Format("select TableName,PartyName, OrderDate as Date,Total from tbl_SaleOrder where  PartyName Like '%{0}%' union all select TableName,PartyName, OrderDate as Date,Total from tbl_PurchaseOrder where  PartyName Like '%{0}%' union all select TableName,PartyName, BillDate as Date,Total from tbl_PurchaseBill where  PartyName Like '%{0}%' union all  select TableName,PartyName, InvoiceDate as Date,Total from tbl_SaleInvoice where  PartyName Like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilterBy);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSalepurchaseReport.DataSource = ds;
                dgvSalepurchaseReport.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
    }
