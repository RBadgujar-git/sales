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
    public partial class OtherIncomeReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public OtherIncomeReport()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void OtherIncomeReport_Load(object sender, EventArgs e)
        {
            fetchdata();
            fetchCompany();
        }
        private void fetchdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_OtherIncome", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvOtherIncome.AutoGenerateColumns = false;
            dgvOtherIncome.ColumnCount = 6;
            dgvOtherIncome.Columns[0].HeaderText = "IncomeCategory";
            dgvOtherIncome.Columns[0].DataPropertyName = "IncomeCategory";
            dgvOtherIncome.Columns[1].HeaderText = " Date";
            dgvOtherIncome.Columns[1].DataPropertyName = "Date";
            dgvOtherIncome.Columns[2].HeaderText = "Total";
            dgvOtherIncome.Columns[2].DataPropertyName = "total";
            dgvOtherIncome.Columns[3].HeaderText = " Paid";
            dgvOtherIncome.Columns[3].DataPropertyName = "Paid";
            dgvOtherIncome.Columns[4].HeaderText = " Balance";
            dgvOtherIncome.Columns[4].DataPropertyName = "Balance";
            dgvOtherIncome.Columns[5].HeaderText = " Status";
            dgvOtherIncome.Columns[5].DataPropertyName = "Status";
            dgvOtherIncome.DataSource = dt;
        }
        private void fetchCompany()
        {
            if (cmbAllfirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data not" + ex);
                }
            }
        }
    }
}
