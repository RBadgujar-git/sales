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
    public partial class LoanStatement : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public LoanStatement()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void LoanStatement_Load(object sender, EventArgs e)
        {
            fetchCompany();
            fetchLoanAccount();

        }
    private void fetchCompany()
        {
            if (cmballFirms.Text != "System.Data.DataRowView")
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
                        cmballFirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void fetchLoanAccount()
        {
            if (cmbAccount.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select AccountName from tbl_LoanBank where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by AccountName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbAccount.Items.Add(ds.Tables["Temp"].Rows[i]["AccountName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select LoanAmount,CurrentBal,Interest  from tbl_LoanBank where AccountName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbAccount.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvLoanStatement.DataSource = ds;
                dgvLoanStatement.DataMember = "temp";

                con.Open();
                string Query1 = String.Format("select CurrentBal from tbl_LoanBank where (AccountName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY CurrentBal", cmbAccount.Text);
                SqlCommand cmd = new SqlCommand(Query1, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtOpeningBal.Text = dr["CurrentBal"].ToString();
                }
                dr.Close();
                con.Close();

                con.Open();
                string Query2 = String.Format("select PrincipleAmount,InterestAmount from tbl_MakePayment where (AccountName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY PrincipleAmount,InterestAmount", cmbAccount.Text);
                SqlCommand cmd1 = new SqlCommand(Query2, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    txttotalPrinciple.Text = dr1["PrincipleAmount"].ToString();
                    txttotalInterest.Text = dr1["InterestAmount"].ToString();
                }
                dr1.Close();
                con.Close();
                float PA = 0, TA = 0, BalanceDue = 0;
                 PA = float.Parse(txttotalPrinciple.Text.ToString());
                TA = float.Parse(txttotalInterest.Text.ToString());
                BalanceDue = PA + TA;
                txttBalancedue.Text = BalanceDue.ToString();
                dr.Close();
                dr1.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txttBalancedue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txttotalPrinciple_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txttotalInterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvLoanStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    //  string Query = String.Format("select TableName,PartyName, ContactNo,Received as 'Recived/Paid' from tbl_SaleInvoice where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Received as 'Recived/Paid'  from tbl_SaleOrder where PartyName='{0}'union all select TableName,PartyName,  ContactNo,Paid as 'Recived/Paid' from tbl_PurchaseBill where PartyName='{0}'union all select TableName,PartyName, ContactNo,Paid as 'Recived/Paid'  from tbl_PurchaseOrder  where PartyName = '{0}' and Company_ID='" + NewCompany.company_id + "'", cmballparties.Text);
                    string Query = string.Format("select a.LoanAmount,a.CurrentBal,a.Interest,a.AccountName,a.Company_ID,a.DeleteData,b.CompanyName,b.Address,b.GSTNumber,b.PhoneNo,b.EmailID,b.AddLogo,b.CompanyID  from tbl_LoanBank as a,tbl_CompanyMaster as b where a.AccountName='{0}' and a.Company_ID='" + NewCompany.company_id + "' and b.CompanyID='" + NewCompany.company_id + "' and a.DeleteData='1'", cmbAccount.Text);

                    // string Query = string.Format("select c.CompanyID,c.CompanyName,c.PhoneNo,c.EmailID,c.GSTNumber,b.PartyName ,b.ContactNo,b.Received From tbl_PurchaseBill as b,tbl_CompanyMaster as c where CompanyID='" + NewCompany.company_id + "' and b.PartyName='{0}'",cmballparties.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"BankStatementData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("BankStatement", "BankStatement", ds.Tables[0]);

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
