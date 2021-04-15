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
    public partial class PartyReportByItem : UserControl

    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;

        public FormWindowState WindowState { get; private set; }

        public PartyReportByItem()
        {
            InitializeComponent();
        }

        private void PartyReportByItem_Load(object sender, EventArgs e)
        {
            fetchCompany();
            try
            {
                string Query = string.Format("(select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='"+NewCompany.company_id+"' and a.DeleteData='1') union ( select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1')");
                
                //string Query = string.Format("(select P.TableName, PI.ItemName, P.BillNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_PurchaseBill as P inner join tbl_PurchaseBillInner as PI on P.ID = PI.ID where  TableName like '%{0}%' union all select P.TableName, PI.ItemName, P.OrderNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_PurchaseOrder as P inner join tbl_PurchaseOrderInner as PI on P.ID = PI.ID where  TableName like '%{0}%') union all (select P.TableName, PI.ItemName, P.OrderNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_SaleOrder as P inner join tbl_SaleOrderInner as PI on P.ID = PI.ID where  TableName like '%{0}%' union all select P.TableName, PI.ItemName, P.InvoiceID as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_SaleInvoice as P inner join tbl_SaleInvoiceInner as PI on P.ID = PI.ID where  TableName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPartyReport.DataSource = ds;
                dgvPartyReport.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fetchCompany()
        {
            if (cmbparty.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='"+NewCompany.company_id+"' and DeleteData='1' group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbparty.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    DataSet ds = new DataSet();
                string Query = string.Format("select a.TableName,a.PartyName,b.Qty,b.freeQty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' union ( select a.TableName,b.ItemName,b.Qty,b.freeQty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1')", txtSearch1.Text);

                    //string Query = string.Format("(select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1') union ( select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1')",cmbparty.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"Partyreportbyitem.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("Partyreport", "Partyreport", ds.Tables[0]);

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

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select a.TableName,b.PartyName,b.Qty,b.freeQty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1'union ( select a.TableName,b.ItemName,b.Qty,b.freeQty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1')", txtSearch1.Text);

                //string Query = string.Format("(select P.TableName, PI.ItemName, P.BillNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_PurchaseBill as P inner join tbl_PurchaseBillInner as PI on P.ID = PI.ID where  TableName like '%{0}%' union all select P.TableName, PI.ItemName, P.OrderNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_PurchaseOrder as P inner join tbl_PurchaseOrderInner as PI on P.ID = PI.ID where  TableName like '%{0}%') union all (select P.TableName, PI.ItemName, P.OrderNo as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_SaleOrder as P inner join tbl_SaleOrderInner as PI on P.ID = PI.ID where  TableName like '%{0}%' union all select P.TableName, PI.ItemName, P.InvoiceID as Number, PI.Qty, PI.freeQty, PI.ItemAmount from tbl_SaleInvoice as P inner join tbl_SaleInvoiceInner as PI on P.ID = PI.ID where  TableName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPartyReport.DataSource = ds;
                dgvPartyReport.DataMember = "temp";
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("(select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_PurchaseBillInner as b,tbl_PurchaseBill as a where a.PartyName='{0}' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' )union( select a.TableName,a.PartyName,b.Qty,b.ItemAmount from tbl_SaleInvoiceInner as b,tbl_saleinvoice as a where a.PartyName='{0}' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' )", cmbparty.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPartyReport.DataSource = ds;
                dgvPartyReport.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2DateTimePicker2_Enter(object sender, EventArgs e)
        {
            //    try
            //    {
            //        string SelectQuery = string.Format("select IncomeCategory,Paid from tbl_OtherIncome  where Date between '" + dtpFromDate.Value.ToString() + "' and '" + dtpToDate.Value.ToString() + "'");
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
            //        SDA.Fill(ds, "temp");
            //        dgvPartyReport.DataSource = ds;
            //        dgvPartyReport.DataMember = "temp";
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Data not" + ex);
            //    }
            //}
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvPartyReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
