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
    public partial class LowStockSummary : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public LowStockSummary()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void LowStockSummary_Load(object sender, EventArgs e)
        {
            fetchcategory();
            binddata();
        }
        private void binddata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_ItemMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvLowstocksummary.AutoGenerateColumns = false;
            dgvLowstocksummary.ColumnCount = 5;
            dgvLowstocksummary.Columns[0].HeaderText = "Item Name";
            dgvLowstocksummary.Columns[0].DataPropertyName = "ItemName";
            dgvLowstocksummary.Columns[1].HeaderText = " Opening Qty";
            dgvLowstocksummary.Columns[1].DataPropertyName = "OpeningQty";
            dgvLowstocksummary.Columns[2].HeaderText = "Minimum Stock";
            dgvLowstocksummary.Columns[2].DataPropertyName = "MinimumStock";
            dgvLowstocksummary.Columns[3].HeaderText = " Opening Qty";
            dgvLowstocksummary.Columns[3].DataPropertyName = "OpeningQty";
            dgvLowstocksummary.Columns[4].HeaderText = " atPrice";
            dgvLowstocksummary.Columns[4].DataPropertyName = "atPrice";
            dgvLowstocksummary.DataSource = dt;

        }
        private void fetchcategory()
        {
            if (cmbAllCategory.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_CategoryMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CategoryName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbAllCategory.Items.Add(ds.Tables["Temp"].Rows[i]["CategoryName"].ToString());

                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmbAllCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ItemName,OpeningQty,MinimumStock,atPrice  from tbl_ItemMaster where ItemCategory='{0}'and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbAllCategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvLowstocksummary.DataSource = ds;
                dgvLowstocksummary.DataMember = "temp";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLowstocksummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
