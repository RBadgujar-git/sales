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
    public partial class ProfitLossReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public ProfitLossReport()
        {
            InitializeComponent();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void ProfitLossReport_Load(object sender, EventArgs e)
        {
            fetchCompany();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void cmbAllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
