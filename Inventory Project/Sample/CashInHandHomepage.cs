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
    public partial class CashInHandHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public CashInHandHomepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashInHandAdjust BA = new CashInHandAdjust();
            //BA.TopLevel = false;
            // BA.AutoScroll = true;
            this.Controls.Add(BA);

            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //try
            //{ //(select TableName as Type,PartyName,InvoiceDate as Date,Total from tbl_SaleInvoice)union all(select TableName as Type,PartyName,OrderDate as Date,Total from tbl_SaleOrder )Union all(select TableName as Type,PartyName,BillDate as Date,Total from tbl_PurchaseBill )Union all(select TableName as Type,PartyName,OrderDate as Date,Total from tbl_PurchaseOrder)union all(select TableName as Type,CustomerName as PartyName,Date as Date,TOTAL as Total from tbl_PaymentIn )union all(select TableName as Type,CustomerName as PartyName,Date as Date,TOTAL as Total  from tbl_Paymentout)Union all(select CashAdjustment as Type,Description as PartyName,Date as Date,CashAmount from tbl_CashAdjustment)

            //    string Query = string.Format("select P.TableName,PO.TableName,S.TableName,SO.TableName,PI.TableName,POP.TableName,C.CashAdjustment from tbl_CashAdjustment as C,tbl_PaymentIn as PI,tbl_Paymentout as POP,tbl_PurchaseBill as P,tbl_PurchaseOrder as PO, tbl_SaleInvoice S,tbl_SaleOrder as SO where TableName  like '%{0}%'", txtSearch.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //    da.Fill(ds, "temp");
            //    dgvCashInHand.DataSource = ds;
            //    dgvCashInHand.DataMember = "temp";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}




        }

        private void CashInHandHomepage_Load(object sender, EventArgs e)
        {
            bindbankdata();
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("(select TableName as Type,PartyName,InvoiceDate as Date,Total from tbl_SaleInvoice)union all(select TableName as Type,PartyName,OrderDate as Date,Total from tbl_SaleOrder )Union all(select TableName as Type,PartyName,BillDate as Date,Total from tbl_PurchaseBill )Union all(select TableName as Type,PartyName,OrderDate as Date,Total from tbl_PurchaseOrder)union all(select TableName as Type,CustomerName as PartyName,Date as Date,TOTAL as Total from tbl_PaymentIn )union all(select TableName as Type,CustomerName as PartyName,Date as Date,TOTAL as Total  from tbl_Paymentout)Union all(select CashAdjustment as Type,Description as PartyName,Date as Date,CashAmount from tbl_CashAdjustment)", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();



            dgvCashInHand.DataSource = dt;

        }
    }
}
