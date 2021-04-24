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
            SqlCommand cmd = new SqlCommand("select ItemName,OpeningQty,MinimumStock,atPrice from tbl_ItemMaster where OpeningQty >= MinimumStock and Company_ID='" + NewCompany.company_id+ "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvLowstocksummary.AutoGenerateColumns = false;
            dgvLowstocksummary.ColumnCount = 4;
            dgvLowstocksummary.Columns[0].HeaderText = "Item Name";
            dgvLowstocksummary.Columns[0].DataPropertyName = "ItemName";
            dgvLowstocksummary.Columns[1].HeaderText = " Opening Qty";
            dgvLowstocksummary.Columns[1].DataPropertyName = "OpeningQty";
            dgvLowstocksummary.Columns[2].HeaderText = "Minimum Stock";
            dgvLowstocksummary.Columns[2].DataPropertyName = "MinimumStock";
            dgvLowstocksummary.Columns[3].HeaderText = " atPrice";
            dgvLowstocksummary.Columns[3].DataPropertyName = "atPrice";
            
            dgvLowstocksummary.DataSource = dt;
            dgvLowstocksummary.AllowUserToAddRows = false;

        }
        private void fetchcategory()
        {
            if (cmbAllCategory.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CategoryName from tbl_CategoryMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CategoryName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
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
                dgvLowstocksummary.AllowUserToAddRows = false;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select a.ItemName,a.OpeningQty,a.MinimumStock,a.atPrice,c.CompanyName,c.CompanyID,c.Address,c.PhoneNo,c.EmailID,c.AddLogo,c.GSTNumber from tbl_ItemMaster as a,tbl_CompanyMaster as c where a.OpeningQty >= a.MinimumStock and a.Company_ID='" + NewCompany.company_id+"' and a.DeleteData='1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"StockSummaryReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("StockSummary", "StockSummary", ds.Tables[0]);

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

        private void button1_Click(object sender, EventArgs e)
        {
            StockDetails BA = new StockDetails();
            //  BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockSummary BA = new StockSummary();
            //  BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void txtItemname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ItemName,OpeningQty,MinimumStock,atPrice from tbl_ItemMaster where OpeningQty >= MinimumStock and ItemName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtItemname.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvLowstocksummary.DataSource = ds;
                dgvLowstocksummary.DataMember = "temp";

                dgvLowstocksummary.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
