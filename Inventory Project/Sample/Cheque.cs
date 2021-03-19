using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample
{
    public partial class Cheque : Form
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        string id = "";

        public Cheque()
        {
            InitializeComponent();

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cheque_Load(object sender, EventArgs e)
        {
            fetchCompany();
            Bindadata();
        }
        private void fetchCompany()
        {
            if (cmbAllfirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CompanyName");
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
        private void Bindadata()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("(select TableName, InvoiceDate as Date,InvoiceID as Number,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Feild1 IS NOT Null and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,OrderDate as Date,OrderNo as Number,PartyName,PaymentType,Feild1,Total,Received,RemainingBal,Status  from tbl_SaleOrder where Feild1 IS NOT Null and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvSaleOrder.DataSource = dt;
            //dgvSaleOrder.AutoGenerateColumns = false;
            //dgvSaleOrder.ColumnCount = 9;
            //dgvSaleOrder.Columns[0].HeaderText = "Date";
            //dgvSaleOrder.Columns[0].DataPropertyName = "InvoiceDate";
            //dgvSaleOrder.Columns[1].HeaderText = " Invoice No";
            //dgvSaleOrder.Columns[1].DataPropertyName = "InvoiceID";
            //dgvSaleOrder.Columns[2].HeaderText = "Party Name";
            //dgvSaleOrder.Columns[2].DataPropertyName = "PartyName";
            //dgvSaleOrder.Columns[3].HeaderText = " PaymentType";
            //dgvSaleOrder.Columns[3].DataPropertyName = "PaymentType";
            //dgvSaleOrder.Columns[4].HeaderText = " Feild1";
            //dgvSaleOrder.Columns[4].DataPropertyName = "Ref No";

            //dgvSaleOrder.Columns[5].HeaderText = "Total";
            //dgvSaleOrder.Columns[5].DataPropertyName = "Total";
            //dgvSaleOrder.Columns[6].HeaderText = " Received";
            //dgvSaleOrder.Columns[6].DataPropertyName = "Received";
            //dgvSaleOrder.Columns[7].HeaderText = "Remaining Bal";
            //dgvSaleOrder.Columns[7].DataPropertyName = "RemainingBal";
            //dgvSaleOrder.Columns[8].HeaderText = " Status";
            //dgvSaleOrder.Columns[8].DataPropertyName = "Status";

        }//BillDate,BillNo,PartyName,PaymentType,T
        private void dtpTo_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select TableName,InvoiceDate as Date,InvoiceID as Number,PartyName,PaymentType,Feild1 as Ref No,Total,Received,RemainingBal,Status  from tbl_SaleInvoice where Feild1 IS NOT Null  InvoiceDate between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' union all select TableName,OrderDate as Date,OrderNo as Number,PartyName,PaymentType,Feild1 as Ref No,Total,Received,RemainingBal,Status  from tbl_SaleOrder where Feild1 IS NOT Null OrderDate between '" + dtpFrom.Value.ToString() + "' and '" + dtpTo.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);     
                SDA.Fill(ds, "temp");
                dgvSaleOrder.DataSource = ds;
                dgvSaleOrder.DataMember = "temp";
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
        private void txtFilterBy_TextChanged(object sender, EventArgs e)

        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}
