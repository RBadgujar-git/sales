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
        public static int compid;
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
            PartyName();
            // fetchTrannsaction();
            try
            {
                //con.Open();
                DataTable dt = new DataTable();


                // string Query = string.Format("(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_SaleInvoice where PartyName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,Total,Paid as 'Receievd/Paid',RemainingBal,Status from tbl_PurchaseBill  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_CreditNote1  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')", txtpartyfilter.Text);

                //string Query = string.Format("(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_CreditNote1  where PartyName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DebitNote  where PartyName = '{1}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DeliveryChallan  where PartyName = '{2}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,BillDate,Total,Paid as 'Receievd/Paid',RemainingBal,Status from  tbl_PurchaseBill  where PartyName = '{3}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,OrderDate ,Total,Paid as 'Receievd/Paid',RemainingBal,Status from tbl_PurchaseOrder where PartyName = '{4}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_SaleInvoice where PartyName = '{5}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union all(select TableName,PartyName,OrderDate ,Total,Received as 'Receievd/Paid',RemainingBal,Status from  tbl_SaleOrder where PartyName = '{6}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')",txtpartyfilter.Text);
               string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_CreditNote1 where Company_ID='"+NewCompany.company_id+ "' and DeleteData='1')union (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DebitNote where Company_ID='" + NewCompany.company_id + "' and DeleteData='1') union  (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DeliveryChallan where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union(select TableName,PartyName,BillDate  as InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate As InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate as InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");

                //string Query = String.Format("select TableName,PartyName, ContactNo,Received as 'Recived/Paid' from tbl_SaleInvoice where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Received as 'Recived/Paid'  from tbl_SaleOrder where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Paid as 'Recived/Paid' from tbl_PurchaseBill where PartyName='{0}'union all select TableName,PartyName, ContactNo,Paid as 'Recived/Paid'  from tbl_PurchaseOrder  where PartyName = '{0}'  AND Company_ID='" + NewCompany.company_id + "'", cmballparties.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvalltransactions.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //con.Close();
            }
        }
        private void fetchTrannsaction()
        {
            try
            {

                string Query = string.Format("(select TableName,PartyName,Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_CreditNote1  where PartyName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DebitNote  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DeliveryChallan  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,BillDate as Date,Total,Paid as 'Receievd/Paid',RemainingBal,Status from  tbl_PurchaseBill  where PartyName = '{0}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,OrderDate As Date,Total,Paid as 'Receievd/Paid',RemainingBal,Status from tbl_PurchaseOrder where PartyName = '{0}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_SaleInvoice where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union all(select TableName,PartyName,OrderDate as Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from  tbl_SaleOrder where PartyName = '{0}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvalltransactions.DataSource = ds;
                dgvalltransactions.DataMember = "temp";
               
            }
            catch (Exception)
            {

               // throw;
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
        private void Party()
        {
            if (txtpartyfilter.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where  DeleteData='1' and Company_ID='"+compid+"'group by PartyName");
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
            try
            {
                //con.Open();
                DataTable dt = new DataTable();


                // string Query = string.Format("(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_SaleInvoice where PartyName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,Total,Paid as 'Receievd/Paid',RemainingBal,Status from tbl_PurchaseBill  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_CreditNote1  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')", txtpartyfilter.Text);

                //string Query = string.Format("(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_CreditNote1  where PartyName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DebitNote  where PartyName = '{1}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DeliveryChallan  where PartyName = '{2}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,BillDate,Total,Paid as 'Receievd/Paid',RemainingBal,Status from  tbl_PurchaseBill  where PartyName = '{3}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,OrderDate ,Total,Paid as 'Receievd/Paid',RemainingBal,Status from tbl_PurchaseOrder where PartyName = '{4}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_SaleInvoice where PartyName = '{5}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union all(select TableName,PartyName,OrderDate ,Total,Received as 'Receievd/Paid',RemainingBal,Status from  tbl_SaleOrder where PartyName = '{6}'  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')",txtpartyfilter.Text);
                string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_CreditNote1 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName='{0}')union (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DebitNote where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName='{0}') union  (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DeliveryChallan where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName='{0}' )union(select TableName,PartyName,BillDate  as InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName='{0}')union(select TableName,PartyName,OrderDate As InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName='{0}')union(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName='{0}')union(select TableName,PartyName,OrderDate as InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName='{0}')",txtpartyfilter.Text);

                //string Query = String.Format("select TableName,PartyName, ContactNo,Received as 'Recived/Paid' from tbl_SaleInvoice where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Received as 'Recived/Paid'  from tbl_SaleOrder where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Paid as 'Recived/Paid' from tbl_PurchaseBill where PartyName='{0}'union all select TableName,PartyName, ContactNo,Paid as 'Recived/Paid'  from tbl_PurchaseOrder  where PartyName = '{0}'  AND Company_ID='" + NewCompany.company_id + "'", cmballparties.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
                sqlSda.Fill(dt);
                dgvalltransactions.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //con.Close();
            }
        }

        private void cmballfrims_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmballfrims.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    compid = Convert.ToInt32(dr["CompanyID"].ToString());
                    MessageBox.Show("Test" + compid);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                companyinfo();
                Party();
            }
        }
        public void companyinfo()
        {
            //string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrderWhere CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice Where CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder Where CompanyID='" + compid + "' and DeleteData='1') ", cmballfrims.Text);
            string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_CreditNote1 where Company_ID='" + compid + "' and DeleteData='1')union (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DebitNote where Company_ID='" + compid + "' and DeleteData='1') union  (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DeliveryChallan where Company_ID='" + compid + "' and DeleteData='1' )union(select TableName,PartyName,BillDate  as InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Company_ID='" + compid + "' and DeleteData='1')union(select TableName,PartyName,OrderDate As InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where Company_ID='" + compid + "' and DeleteData='1')union(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + compid + "' and DeleteData='1')union(select TableName,PartyName,OrderDate as InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + compid + "' and DeleteData='1')", cmballfrims.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvalltransactions.DataSource = ds;
            dgvalltransactions.DataMember = "temp";
        }
        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_CreditNote1 where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DebitNote where Company_ID='" + NewCompany.company_id + "' and DeleteData='1') union  (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DeliveryChallan where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union(select TableName,PartyName,BillDate  as InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate As InvoiceDate,Total,Paid as Received,RemainingBal,Status from tbl_PurchaseOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleInvoice where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate as InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"AllTransactionDataReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("AllTransaction", "AllTransaction", ds.Tables[0]);

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
    }
}
