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
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select TableName,Received from tbl_saleinvoice where Company_ID='59' and DeleteData='1' union select TableName,Paid from  tbl_PurchaseBill where Company_ID='59' and DeleteData='1' union select TableName,Received from  tbl_OtherIncome where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union select TableName,Paid from  tbl_Expenses where Company_ID='" + NewCompany.company_id+"' and DeleteData='1'");
                //union all select a.Company_ID,a.EntryType,a.Amount,a.Date,a.Description,b.BankName,b.OpeningBal  from tbl_BankAdjustment as a,tbl_BankAccount as b where b.BankName='{0}' AND a.Company_ID='" + NewCompany.company_id + "'", cmbbankname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dataGridView1.DataSource = dt;
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
