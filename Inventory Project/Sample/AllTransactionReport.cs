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
    public partial class AllTransactionReport : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public AllTransactionReport()
        {
            InitializeComponent();
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AllTransactionReport_Load(object sender, EventArgs e)
        {
            fetchCompany();
        }
        private void fetchTrannsaction()
        {
            try
            {

                string Query = string.Format("(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_CreditNote1  where PartyName='{0}')union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote  where PartyName = '{0}')Union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DeliveryChallan  where PartyName = '{0}')union all(select TableName,PartyName,BillDate as Date,Total,Paid as Receievd'/'Paid,RemainingBal,Status from  tbl_PurchaseBill  where PartyName = '{0}')Union all(select TableName,PartyName,OrderDate As Date,Total,Paid as Receievd'/'Paid,RemainingBal,Status from tbl_PurchaseOrder where PartyName = '{0}')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_SaleInvoice where PartyName = '{0}')union all(select TableName,PartyName,OrderDate as Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from  tbl_SaleOrder where PartyName = '{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtpartyfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvalltransactions.DataSource = ds;
                dgvalltransactions.DataMember = "temp";
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        //select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_CreditNote1 as P Inner Join tbl_CreditNoteInner as C on P.ID= C.ID where ItemName = '{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_DebitNote as P Inner Join tbl_DebitNoteInner as C on P.ID = C.ID  where ItemName = '{0}')Union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_DeliveryChallan as P Inner Join tbl_DeliveryChallanInner as C on P.ID = C.ID  where ItemName = '{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_PurchaseBill as P Inner Join tbl_PurchaseBillInner as C on P.ID = C.ID  where ItemName = '{0}')Union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_PurchaseOrder as P Inner Join tbl_PurchaseOrderInner as C on P.ID = C.ID  where ItemName = '{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tblQuotation as P Inner Join tbl_QuotationInner as C on P.ID = C.ID  where ItemName = '{0}')Union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_SaleInvoice as P Inner Join tbl_SaleInvoiceInner as C on P.ID = C.ID  where ItemName = '{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_SaleOrder as P Inner Join tbl_SaleOrderInner as C on P.ID = C.ID where ItemName = '{0}') and Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'", lblItemName.Text);
        private void PartyName()
        {
            if (txtpartyfilter.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where  DeleteData='1' group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        txtpartyfilter.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void fetchCompany()
        {
            if (cmballfrims.Text != "System.Data.DataRowView")
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
                        cmballfrims.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtpartyfilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpartyfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchTrannsaction();
        }

        private void cmballfrims_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrder)union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice )union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder ) Where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmballfrims.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvalltransactions.DataSource = ds;
                dgvalltransactions.DataMember = "temp";

            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
