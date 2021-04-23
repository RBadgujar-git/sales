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
    public partial class ExpenseItemReport : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public static int compid;
        public ExpenseItemReport()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void ExpenseItemReport_Load(object sender, EventArgs e)
        {
            fetchCategory();
            bindbankdata();
            fetchCompany();
            int sum = 0;
            for (int i = 0; i < dgvexpense.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvexpense.Rows[i].Cells[1].Value);
            }
            txtTotalQty.Text = sum.ToString();
            int sum1 = 0;
            for (int i = 0; i < dgvexpense.Rows.Count; ++i)
            {
                sum1 += Convert.ToInt32(dgvexpense.Rows[i].Cells[2].Value);
            }
            txttotal.Text = sum1.ToString();
        }
        private void fetchCompany()
        {
            if (cmbAllfirms.Text != "System.Data.DataRowView")
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
                        cmbAllfirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_ExpensesInner where DeleteData='1' and Company_ID='"+NewCompany.company_id+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvexpense.AutoGenerateColumns = false;
            dgvexpense.ColumnCount = 4;
            dgvexpense.Columns[0].HeaderText = "Expense Item";
            dgvexpense.Columns[0].DataPropertyName = "ItemName";
            dgvexpense.Columns[1].HeaderText = "Quantity";
            dgvexpense.Columns[1].DataPropertyName = "Qty";
            //dgvexpense.Columns[2].HeaderText = "Free Qty";
            //dgvexpense.Columns[2].DataPropertyName = "freeQty";
            dgvexpense.Columns[2].HeaderText = "Amount";
            dgvexpense.Columns[2].DataPropertyName = "ItemAmount";
            dgvexpense.DataSource = dt;
        }
        private void fetchCategory()
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

        private void dtptodate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbExpensecategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select ItemName,Qty,ItemAmount from tbl_ExpensesInner  where ItemName like'%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvexpense.DataSource = ds;
                dgvexpense.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int row = 0;

        public FormWindowState WindowState { get; private set; }

        private void Data()
            {
            float TA = 0, TD = 0, total = 0,TG=0,qty=0,rate=0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];
            //e.SuppressKeyPress = true;
            for (int i = 0; i < dgvexpense.Rows.Count; i++)
            {
                TA += float.Parse(dgvexpense.Rows[i].Cells["Column2"].Value?.ToString());
                txttotal.Text = TA.ToString();
                TD+= float.Parse(dgvexpense.Rows[i].Cells["Column1"].Value?.ToString());
                txtqty.Text = TD.ToString();
                //TG += float.Parse(dgvexpense.Rows[i].Cells["FreeQty"].Value?.ToString());
                //txtfreeqty.Text = TG.ToString();
                qty = float.Parse(txtqty.Text.ToString());
                //rate = float.Parse(txtfreeqty.Text.ToString());
                total = qty + rate;
                txtTotalQty.Text = total.ToString();
            }
        }

        private void txtfreeqty_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvexpense_TabIndexChanged(object sender, EventArgs e)
        {
            Data();
        }

        private void cmbAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID from tbl_CompanyMaster where (CompanyName='{0}') and DeleteData='1'  GROUP BY CompanyID", cmbAllfirms.Text);
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
                companyinfo();
                data();
            }
        }
        public void data()
        {
            int sum = 0;
            for (int i = 0; i < dgvexpense.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvexpense.Rows[i].Cells[1].Value);
            }
            txtTotalQty.Text = sum.ToString();
            int sum1 = 0;
            for (int i = 0; i < dgvexpense.Rows.Count; ++i)
            {
                sum1 += Convert.ToInt32(dgvexpense.Rows[i].Cells[2].Value);
            }
            txttotal.Text = sum1.ToString();
        }
        public void companyinfo()
        {
            //string Query = string.Format("(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_CreditNote1  )union all(select TableName,PartyName,Date,Total,Received as Receievd'/'Paid,RemainingBal,Status from tbl_DebitNote )Union all(select TableName,PartyName,Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_DeliveryChallan )union all(select TableName,PartyName,BillDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from  tbl_PurchaseBill ')Union all(select TableName,PartyName,OrderDate as Date,Total,Paid as ReceievdPaid,RemainingBal,Status from tbl_PurchaseOrderWhere CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,InvoiceDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from tbl_SaleInvoice Where CompanyID='" + compid + "' and DeleteData='1')union all(select TableName,PartyName,OrderDate as Date,Total,Received as ReceievdPaid,RemainingBal,Status from  tbl_SaleOrder Where CompanyID='" + compid + "' and DeleteData='1') ", cmballfrims.Text);
            string Query = string.Format("select ItemName,Qty,ItemAmount from tbl_ExpensesInner  where Company_ID='" + compid + "' and DeleteData='1'", cmbAllfirms.Text);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvexpense.DataSource = ds;
            dgvexpense.DataMember = "temp";
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("select c.CompanyID,c.CompanyName,c.Address,c.AddLogo,c.PhoneNo,c.GSTNumber,c.EmailID,b.ItemName,b.Qty,b.ItemAmount,b.Company_ID from tbl_ExpensesInner as b,tbl_CompanyMaster as c where b.Company_ID = '" + NewCompany.company_id + "' and c.CompanyID='" + NewCompany.company_id + "' and b.DeleteData = '1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"ExpensesItemData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("ExpensesItemData", "ExpensesItemData", ds.Tables[0]);

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

        private void dgvexpense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
  }
