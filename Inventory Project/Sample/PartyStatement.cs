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
    public partial class PartyStatement : UserControl
    {
        public FormWindowState WindowState { get; private set; }

        public PartyStatement()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
       
        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void fetchcustomername()
        {
            if (cmbPartyName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' group by PartyName ");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbPartyName.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void bind_sale()
        {
            try
            {
                // date1 = DateTime.Now.ToString("yyyy/MM/dd");
                // string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_CreditNote1  where InvoiceDate='{0}'and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DebitNote  where InvoiceDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DeliveryChallan  where InvoiceDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,BillDate as Date,Total,Paid as 'Receievd/Paid',RemainingBal,Status from  tbl_PurchaseBill  where BillDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,OrderDate As Date,Total,Paid as 'Receievd/Paid',RemainingBal,Status from tbl_PurchaseOrder where OrderDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_SaleInvoice where InvoiceDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from  tbl_SaleOrder where OrderDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1') ", date1);
                string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_CreditNote1 where PartyName='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DebitNote where PartyName='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1') union  (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DeliveryChallan where PartyName='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union(select TableName,PartyName,BillDate  as InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where PartyName='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate As InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where PartyName='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleInvoice where PartyName='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate as InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where PartyName='" + cmbPartyName.Text + "'and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,IncomeCategory as PartyName,Date as InvoiceDate,Total,Received,Balance,Status from tbl_OtherIncome where IncomeCategory='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,ExpenseCategory as PartyName,Date as InvoiceDate,Total,Paid,Balance,Status from tbl_Expenses where ExpenseCategory='" + cmbPartyName.Text + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");

                //String Str = string.Format("Select PartyName as Name,InvoiceID as ReferenceNo,PaymentType as Type,Total as Total,Received as MoneyIn,RemainingBal as MoneyOut from tbl_SaleInvoice where InvoiceDate='{0}' and Company_ID='"+NewCompany.company_id+"' and DeleteData='1'",date1);
                DataSet Ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(Ds, "Temp");

                dgvSofware.DataSource = Ds;
                dgvSofware.DataMember = "Temp";

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                //Bind_sale_TotalAmount();
            }

        }
        private void PartyStatement_Load(object sender, EventArgs e)
        {
            fetchcustomername();
            dgvAccounting.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_sale();
        }
    }
}
