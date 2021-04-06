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
    public partial class ItemReportbyParty : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public ItemReportbyParty()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void ItemReportbyParty_Load(object sender, EventArgs e)
        {
            BindData();
            fetchCompany();

        }
        private void BindData()
        {
            try
            {
                //string Query = string.Format("(select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1') union ( select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1')");
                string Query = string.Format("(select a.TableName,a.PartyName,b.ItemName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1') union ( select a.TableName,a.PartyName,b.ItemName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1')");
                //string Query = string.Format("select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_SaleInvoice as a where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' union (select a.Tablename,a.PartyName,b.Qty,b.ItemAmount from tbl_PurchaseBill as a, tbl_PurchaseBillInner as b where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "'  and a.DeleteData='1')");
                //string Query = string.Format("(select P.TableName, PI.ItemName, P.BillNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_PurchaseBill as P inner join tbl_PurchaseBillInner as PI on P.ID = PI.ID where  TableName like '%{0}%' union all select P.TableName, PI.ItemName, P.OrderNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_PurchaseOrder as P inner join tbl_PurchaseOrderInner as PI on P.ID = PI.ID where  TableName like '%{0}%') union all (select P.TableName, PI.ItemName, P.OrderNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_SaleOrder as P inner join tbl_SaleOrderInner as PI on P.ID = PI.ID where  TableName like '%{0}%' union all select P.TableName, PI.ItemName, P.InvoiceID as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_SaleInvoice as P inner join tbl_SaleInvoiceInner as PI on P.ID = PI.ID where  TableName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvitemReport.DataSource = ds;
                dgvitemReport.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fetchCompany()
        {
            if (cmbAllFirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CompanyName ");
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ItemName from tbl_ItemMaster where ItemName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", guna2TextBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvitemReport.DataSource = ds;
                dgvitemReport.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbAllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //string Query = string.Format("select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1'union ( select a.TableName,b.ItemName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1')");
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select a.TableName,a.PartyName,b.ItemName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1'union ( select a.TableName,a.PartyName,b.ItemName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1')");
                    //string Query = string.Format("(select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1') union ( select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1')",cmbparty.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"ItemReportByParty.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("ItemReportByParty", "ItemReportByParty", ds.Tables[0]);

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
