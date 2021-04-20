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
    public partial class DayBook : UserControl
    {
        public string date1;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        string sumsale1;
        string sumother;
         string total;

        public FormWindowState WindowState { get; private set; }

        public DayBook()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void DayBook_Load(object sender, EventArgs e)
        {
          
            //if (radioButton1.Checked = true)
            //{
            //    bind_sale();
            //}
            //else if (radioButton2.Checked = true)
            //{
            //    bind_purchase();
            //}
            //else
            //{
            //    dgvdaybook.Rows.Clear();
            //}
            // = DateTime.Now.ToShortDateString();

            // bind_purchase();
            //Sale1();
            //OtherIncome1();
            //SaleOrder1();
            //Purchase1();
            //PurchaseOrder1();
            //Expenses1();
            // caltotalmoneyout();
            // TotalMoneyInOut();
            bind_sale();
            calm();
          // caltotalmoneyin();

        }
        private void bind_sale()
        {
            try
            {
               // date1 = DateTime.Now.ToString("yyyy/MM/dd");
                // string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_CreditNote1  where InvoiceDate='{0}'and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DebitNote  where InvoiceDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,InvoiceDate,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_DeliveryChallan  where InvoiceDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,BillDate as Date,Total,Paid as 'Receievd/Paid',RemainingBal,Status from  tbl_PurchaseBill  where BillDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')Union all(select TableName,PartyName,OrderDate As Date,Total,Paid as 'Receievd/Paid',RemainingBal,Status from tbl_PurchaseOrder where OrderDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from tbl_SaleInvoice where InvoiceDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as 'Receievd/Paid',RemainingBal,Status from  tbl_SaleOrder where OrderDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1') ", date1);
                string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_CreditNote1 where InvoiceDate='"+dtpdate.Value.ToString("MM/dd/yyyy")+"' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DebitNote where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1') union  (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DeliveryChallan where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union(select TableName,PartyName,BillDate  as InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate As InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where OrderDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleInvoice where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate as InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where OrderDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,IncomeCategory as PartyName,Date as InvoiceDate,Total,Received,Balance,Status from tbl_OtherIncome where Date='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,ExpenseCategory as PartyName,Date as InvoiceDate,Total,Paid,Balance,Status from tbl_Expenses where Date='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");

                //String Str = string.Format("Select PartyName as Name,InvoiceID as ReferenceNo,PaymentType as Type,Total as Total,Received as MoneyIn,RemainingBal as MoneyOut from tbl_SaleInvoice where InvoiceDate='{0}' and Company_ID='"+NewCompany.company_id+"' and DeleteData='1'",date1);
                DataSet Ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(Ds, "Temp");

                dataGridView1.DataSource = Ds;
                dataGridView1.DataMember = "Temp";

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
        public void calm()
        {
            con.Open();
            SqlCommand cd1 = new SqlCommand("select sum(Received) from tbl_SaleInvoice where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataReader dr1 = cd1.ExecuteReader();
            while (dr1.Read())
            {
                sumsale1 = dr1.GetValue(0).ToString();
            }
            dr1.Close();
            con.Close();
            con.Open();
            SqlCommand cd = new SqlCommand("select sum(Received) from tbl_OtherIncome where Date='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataReader dr = cd.ExecuteReader();
            while (dr.Read())
            {
                sumother = dr.GetValue(0).ToString();
            }
            dr.Close();
            con.Close();
            total = sumsale1 + sumother;
            txtmoneyin.Text = total.ToString();
        }
        private void BindPurchase_TotalAmount()
        {
            try
            {
                float Sum = 0;
                string SelectQuery=string.Format("select Received from tbl_SaleInvoice where InvoiceDate='" + date + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Sum = Sum + float.Parse(ds.Tables["Temp"].Rows[i]["Received"].ToString());
                    sumpurchase = Sum;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void BindExpenses_TotalAmount()
        {
            try
            {
                int Sum = 0;

                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    Sum = Sum + Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    sumexpenses = Sum;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        //private void bind_purchase()
        //{
        //    try
        //    {
        //        date1 = DateTime.Now.ToString("MM/dd/yyyy");
        //        String Str = string.Format("Select PartyName as Name,BillNo as ReferenceNo,PaymentType as Type,Total as Total,Received as MoneyIn,RemainingBal as MoneyOut from tbl_PurchaseBill where BillDate='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", date1);
        //        DataSet Ds = new DataSet();
        //        SqlDataAdapter SDA = new SqlDataAdapter(Str, con);
        //        SDA.Fill(Ds, "Temp");

        //        dgvdaybook.DataSource = Ds;
        //        dgvdaybook.DataMember = "Temp";

        //    }
        //    catch (Exception e1)
        //    {
        //        MessageBox.Show(e1.Message);
        //    }
        //    finally
        //    {
        //        Bind_sale_TotalAmount();
        //    }
        //}
        float sumsale = 0;
        float sumotherincome = 0;
        float sumtotalmoneyin = 0;
        private void caltotalmoneyin()
        {
            sumtotalmoneyin = sumsale + sumotherincome;
            txtmoneyin.Text = sumtotalmoneyin.ToString();
        }
        private void BindOtherIncome_TotalAmount()
        {
            try
            {
                int Sum = 0;

                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    Sum = Sum + Int32.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    sumotherincome = Sum;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }


        private void Bind_sale_TotalAmount()
        {
            try
            {
                con.Open();
                string Sum ;
                string SelectQuery = string.Format("select Received from tbl_SaleInvoice where InvoiceDate='" + date + "' and Company_ID='"+NewCompany.company_id+"' Group By Received");
                SqlCommand cmd = new SqlCommand(SelectQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();
               while(dr.Read())
                {
                    Sum = dr["Received"].ToString();
                    txtmoneyin.Text = Sum.ToString() ;
                }
                dr.Close();
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void Data()
        {
            try
            {
                float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
                //dgvexpense.Rows.Add();
                //row = dgvexpense.Rows.Count - 2;
                ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
                //dgvexpense.CurrentCell = dgvexpense[1, row];
                //e.SuppressKeyPress = true;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    TA += float.Parse(dataGridView1.Rows[i].Cells["Received"].Value?.ToString());
                    txtmoneyin.Text = TA.ToString();
                    //TD += float.Parse(dataGridView1.Rows[i].Cells["RemainingBal"].Value?.ToString());
                    //txtmoneyout.Text = TD.ToString();

                    //qty = float.Parse(txtmoneyout.Text.ToString());
                    //rate = float.Parse(txtmoneyout.Text.ToString());
                    //total = qty + rate;
                    //txttotalinout.Text = total.ToString();

                }
            }

            catch (Exception ex)
            {
                   MessageBox.Show(ex.Message);
            }
        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public string date;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    date = DateTime.Now.ToString("yyyy/MM/dd");
                    todaydate = DateTime.Now.ToString("yyyy/MM/dd");
                    DataSet ds = new DataSet();
                    string Query = string.Format("(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_CreditNote1 where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DebitNote where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1') union  (select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_DeliveryChallan where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' )union(select TableName,PartyName,BillDate  as InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseBill where BillDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate As InvoiceDate,Total,Paid,RemainingBal,Status from tbl_PurchaseOrder where OrderDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleInvoice where InvoiceDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,PartyName,OrderDate as InvoiceDate,Total,Received,RemainingBal,Status from tbl_SaleOrder where OrderDate='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,IncomeCategory as PartyName,Date as InvoiceDate,Total,Received,Balance,Status from tbl_OtherIncome where Date='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')union(select TableName,ExpenseCategory as PartyName,Date as InvoiceDate,Total,Paid,Balance,Status from tbl_Expenses where Date='" + dtpdate.Value.ToString("MM/dd/yyyy") + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1')");
                    //string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.InvoiceID,b.PaymentType,b.Company_ID,b.Received,b.RemainingBal,b.Total,b.InvoiceDate FROM tbl_CompanyMaster as a, tbl_SaleInvoice as b where b.InvoiceDate='{0}' and a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "'",date1);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"DayBookReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("DayBook", "DayBook", ds.Tables[0]);

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

        public string todaydate;

        //public void Sale1()
        //{
        //    try
        //    {
        //        todaydate = DateTime.Now.ToString("yyyy/MM/dd");
        //        string Query = string.Format("select PartyName,PaymentType,TaxAmount1,DiscountAmount1,RemainingBal,Received,Total,Status from tbl_SaleInvoice where InvoiceDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", todaydate);
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //        da.Fill(ds, "temp");
        //        dgvSale.DataSource = ds;
        //        dgvSale.DataMember = "temp";
        //        dgvSale.AllowUserToAddRows = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        Bind_sale_TotalAmount();
        //    }
        //}
        private void Sale_Click(object sender, EventArgs e)
        {

        }

        private void Purchase_Click(object sender, EventArgs e)
        {

        }

        //public void OtherIncome1()
        //{
        //    try
        //    {
        //        todaydate = DateTime.Now.ToString("yyyy/MM/dd");
        //        string Query = string.Format("select IncomeCategory,Balance,Received,Total,Status from tbl_OtherIncome where Date = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", todaydate);
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //        da.Fill(ds, "temp");
        //        dgvOtherIncome.DataSource = ds;
        //        dgvOtherIncome.DataMember = "temp";
        //        dgvOtherIncome.AllowUserToAddRows = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        BindOtherIncome_TotalAmount();
        //    }
        //}

        float sumpurchase = 0;
        float sumexpenses = 0;
        float sumtotalmoneyout = 0;

        //private void caltotalmoneyout()
        //{
        //    sumtotalmoneyout = sumexpenses + sumpurchase;
        //    txtmoneyout.Text = sumtotalmoneyout.ToString();
        //}
        //public void Expenses1()
        //{
        //    try
        //    {
        //        todaydate = DateTime.Now.ToString("yyyy/MM/dd");
        //        string Query = string.Format("select ExpenseCategory,Paid,Balance,Total,Status from tbl_Expenses where Date = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", todaydate);
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //        da.Fill(ds, "temp");
        //        dgvExpenses.DataSource = ds;
        //        dgvExpenses.DataMember = "temp";
        //        dgvExpenses.AllowUserToAddRows = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        BindExpenses_TotalAmount();
        //    }
        //}

        //public void Purchase1()
        //{
        //    try
        //    {
        //        todaydate = DateTime.Now.ToString("yyyy/MM/dd");
        //        string Query = string.Format("select PartyName,PaymentType,TaxAmount1,RemainingBal,Paid,Total,Status from tbl_PurchaseBill where BillDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", todaydate);
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //        da.Fill(ds, "temp");
        //        dgvpurchase.DataSource = ds;
        //        dgvpurchase.DataMember = "temp";
        //        dgvpurchase.AllowUserToAddRows = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        BindPurchase_TotalAmount();
        //    }
        //}

        float moneyinout = 0;

        private void TotalMoneyInOut()
        {
            moneyinout = sumtotalmoneyin - sumtotalmoneyout;
            txttotalinout.Text = moneyinout.ToString();
        }
        //public void PurchaseOrder1()
        //{
        //    try
        //    {
        //        todaydate = DateTime.Now.ToString("yyyy/MM/dd");
        //        string Query = string.Format("select PartyName,PaymentType,TaxAmount1,Paid,RemainingBal,Total,Status from tbl_PurchaseOrder where OrderDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", todaydate);
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //        da.Fill(ds, "temp");
        //        dgvpurchaseorder.DataSource = ds;
        //        dgvpurchaseorder.DataMember = "temp";
        //        dgvpurchaseorder.AllowUserToAddRows = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        ////public void SaleOrder1()
        //{
        //    try
        //    {
        //        todaydate = DateTime.Now.ToString("yyyy/MM/dd");
        //        string Query = string.Format("select PartyName,PaymentType,TaxAmount1,Received,RemainingBal,Total,Status from tbl_SaleOrder where OrderDate = '{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", todaydate);
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        //        da.Fill(ds, "temp");
        //        dgvsaleorder.DataSource = ds;
        //        dgvsaleorder.DataMember = "temp";
        //        dgvsaleorder.AllowUserToAddRows = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void SaleOrder_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseOrder_Click(object sender, EventArgs e)
        {

        }

        private void dgvpurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrintSale1_Click(object sender, EventArgs e)
        {
           
        }

        private void PrintPurchase1_Click(object sender, EventArgs e)
        {
            
        }

        private void PirntSaleOrder_Click(object sender, EventArgs e)
        {
           
        }

        private void PrintPurchaseOrder_Click(object sender, EventArgs e)
        {
           
        }

        private void PrintOtherIcome_Click(object sender, EventArgs e)
        {
            
        }

        private void PrintExpenses_Click(object sender, EventArgs e)
        {
           
        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            bind_sale();

            calm();
        }
    }
}
