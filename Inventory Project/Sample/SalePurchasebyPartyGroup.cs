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
    public partial class SalePurchasebyPartyGroup : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public static int compid;
        public FormWindowState WindowState { get; private set; }

        public SalePurchasebyPartyGroup()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmbAAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmbAAllfirms.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    compid = Convert.ToInt32(dr["CompanyID"].ToString());
                    //MessageBox.Show("Test" + compid);
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
                string idd = compid.ToString();
                fetchPartyGroup(idd);
                companyinfo();

            }
        }
        //public void companyinfo1()
        //{
        //    //string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrderWhere CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice Where CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder Where CompanyID='" + compid + "' and DeleteData='1') ", cmballfrims.Text);
        //    string Query = string.Format("select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + compid + "' and b.DeleteData='1'union ( select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + compid + "' and b.DeleteData='1' and a.AddPartyGroup='"+cmbGroup.Text+"')", cmbAAllfirms.Text);

        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //    da.Fill(ds, "temp");
        //    dgvSalepurchaseReport.DataSource = ds;
        //    dgvSalepurchaseReport.DataMember = "temp";
        //}
        //private void SalePurchasebyPartyGroup_Load(object sender, EventArgs e)
        //{
        //    fetchPartyGroup(NewCompany.company_id);
        //    fetchCompany();
        //    data();
        //}
        public void companyinfo()
        {
            //string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrderWhere CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice Where CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder Where CompanyID='" + compid + "' and DeleteData='1') ", cmballfrims.Text);
            string Query = string.Format("select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + compid + "' and b.DeleteData='1'union ( select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + compid + "' and b.DeleteData='1')", cmbAAllfirms.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvSalepurchaseReport.DataSource = ds;
            dgvSalepurchaseReport.DataMember = "temp";
        }
        private void SalePurchasebyPartyGroup_Load(object sender, EventArgs e)
        {
            fetchPartyGroup(NewCompany.company_id);
            fetchCompany();
            data();
            dgvSalepurchaseReport.AllowUserToAddRows = false;
        }

        private void data()
        {
            try
            {
                con.Open();
                string Query = string.Format("select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1'union ( select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1')", con);

                //string Query = string.Format("select TableName,PartyName, OrderDate as Date,Total from tbl_SaleOrder where  PartyName = '{0}' union all select TableName,PartyName, OrderDate as Date,Total from tbl_PurchaseOrder where  PartyName = '{0}' union all select TableName,PartyName, BillDate as Date,Total from tbl_PurchaseBill where  PartyName = '{0}' union all  select TableName,PartyName, InvoiceDate as Date,Total from tbl_SaleInvoice where  PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvSalepurchaseReport.DataSource = ds;
                dgvSalepurchaseReport.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }


        private void fetchCompany()
        {
            if (cmbAAllfirms.Text != "System.Data.DataRowView")
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
                        cmbAAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                     
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
     
        private void fetchPartyGroup(String m)
        {
            if (cmbGroup.Text != "System.Data.DataRowView")
            {
                try
                {
                    cmbGroup.Items.Clear();
                    string SelectQuery = string.Format("select AddPartyGroup from tbl_PartyGroup where Company_ID="+m +" and DeleteData='1' group by AddPartyGroup");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                   // cmbGroup.Items.Add("Party Group".ToString());
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbGroup.Items.Add(ds.Tables["Temp"].Rows[i]["AddPartyGroup"].ToString());
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
                
            //    string Query = string.Format("select TableName,PartyName, OrderDate as Date,Total from tbl_SaleOrder where  PartyName Like '%{0}%' union all select TableName,PartyName, OrderDate as Date,Total from tbl_PurchaseOrder where  PartyName Like '%{0}%' union all select TableName,PartyName, BillDate as Date,Total from tbl_PurchaseBill where  PartyName Like '%{0}%' union all  select TableName,PartyName, InvoiceDate as Date,Total from tbl_SaleInvoice where  PartyName Like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtFilterBy);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvSalepurchaseReport.DataSource = ds;
            //    dgvSalepurchaseReport.DataMember = "temp";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
           
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
                    string Query = string.Format("select a.TableName,b.ItemName,b.Qty,b.freeQty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1'union ( select a.TableName,b.ItemName,b.Qty,b.freeQty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1')");

                    //string Query = string.Format("(select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1') union ( select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1')",cmbparty.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"saleparty.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("saleparty", "saleparty", ds.Tables[0]);

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

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
