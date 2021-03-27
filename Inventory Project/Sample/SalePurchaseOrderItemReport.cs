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
    public partial class SalePurchaseOrderItemReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

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
               
                string SelectQuery = string.Format("select ItemName,Qty,freeQty,ItemAmount from tbl_PurchaseOrderInner where ItemName like '%{0}%'  union all select ItemName,Qty,freeQty,ItemAmount from tbl_SaleOrderInner where ItemName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilterBy);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvSalepurchhase.DataSource = ds;
                dgvSalepurchhase.DataMember = "temp";
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
    }
}
