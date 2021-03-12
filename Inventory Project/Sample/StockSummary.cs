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
    public partial class StockSummary : UserControl
    {


        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        public FormWindowState WindowState { get; private set; }

        public StockSummary()
        {
            InitializeComponent();
        }

        private void StockSummary_Load(object sender, EventArgs e)
        {
            fetchCampanyame();
            Bindadata();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dgvStockSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbAAllCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("(select ItemName,SalePrice,PurchasePrice,OpeningQty,MinimumStock  from tbl_ItemMaster where ItemCategory = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')", cmbAAllCategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvStockSummary.DataSource = ds;
                dgvStockSummary.DataMember = "temp";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Bindadata()
        {

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", con);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(ds, "temp");
                con.Close();
                dgvStockSummary.AutoGenerateColumns = false;
                dgvStockSummary.ColumnCount = 5;
                dgvStockSummary.Columns[0].HeaderText = "Item Name";
                dgvStockSummary.Columns[0].DataPropertyName = "ItemName";
                dgvStockSummary.Columns[1].HeaderText = " Sale Price";
                dgvStockSummary.Columns[1].DataPropertyName = "SalePrice";
                dgvStockSummary.Columns[2].HeaderText = "Purchase Price";
                dgvStockSummary.Columns[2].DataPropertyName = "PurchasePrice";
                dgvStockSummary.Columns[3].HeaderText = "Opening Qty";
                dgvStockSummary.Columns[3].DataPropertyName = "OpeningQty";
                dgvStockSummary.Columns[4].HeaderText = "MinimumStock";
                dgvStockSummary.Columns[4].DataPropertyName = "MinimumStock";
                dgvStockSummary.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
     private void fetchCampanyame()
        {
            if (cmbAAllCategory.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CategoryName from tbl_CategoryMaster  where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CategoryName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbAAllCategory.Items.Add(ds.Tables["Temp"].Rows[i]["CategoryName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
    }
}
