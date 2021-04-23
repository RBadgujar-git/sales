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


    public partial class LoanStatementReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public LoanStatementReport()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void fetchcustomername()
        {
            if (cmbloanbank.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select BankName from tbl_LoanAccount where Company_ID='" + NewCompany.company_id + "' group by BankName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbloanbank.Items.Add(ds.Tables["Temp"].Rows[i]["BankName"].ToString());

                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void cmbloanbank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string Query = String.Format("select BankName, from tbl_SaleInvoice where BankName='{0}'union all select  from tbl_SaleOrder where BankName='{0}' AND Company_ID='" + NewCompany.company_id + "'", cmbloanbank.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvAllLoanStat.DataSource = dt;
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

        private void LoanStatementReport_Load(object sender, EventArgs e)
        {
            fetchcustomername();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
