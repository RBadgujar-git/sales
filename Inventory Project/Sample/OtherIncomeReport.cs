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
using System.Globalization;

namespace sample
{
    public partial class OtherIncomeReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public FormWindowState WindowState { get; private set; }

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
            fetchCompany();
            bindbankdata();
        }
        private void fetchCompany()
        {
            if (cmbAllfirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1' group by CompanyName ");
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
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_OtherIncome where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvOtherIncome.AutoGenerateColumns = false;
            dgvOtherIncome.ColumnCount = 3;
            dgvOtherIncome.Columns[0].HeaderText = "Date";
            dgvOtherIncome.Columns[0].DataPropertyName = "Date";
            dgvOtherIncome.Columns[1].HeaderText = "Category Name";
            dgvOtherIncome.Columns[1].DataPropertyName = "IncomeCategory";
            dgvOtherIncome.Columns[2].HeaderText = " Paid";
            dgvOtherIncome.Columns[2].DataPropertyName = "Paid";
            dgvOtherIncome.DataSource = dt;
        }
    

        private void cmbAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select  Date,IncomeCategory,Paid  from tbl_OtherIncome where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbAllfirms.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvOtherIncome.DataSource = ds;
                dgvOtherIncome.DataMember = "temp";



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

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string SelectQuery = string.Format("select  Date,IncomeCategory,Paid from tbl_OtherIncome  where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvOtherIncome.DataSource = ds;
                dgvOtherIncome.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select  Date,IncomeCategory,Paid from tbl_OtherIncome  where IncomeCategory l like '%{0}%' where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvOtherIncome.DataSource = ds;
                dgvOtherIncome.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                String sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                string SelectQuery = string.Format("select  Date,IncomeCategory,Paid from tbl_OtherIncome  where Date between '" + dtpFrom.Value.ToString(sysUIFormat) + "' and '" + dtpTo.Value.ToString(sysUIFormat) + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvOtherIncome.DataSource = ds;
                dgvOtherIncome.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
