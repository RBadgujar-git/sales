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
    public partial class OtherIncomeCategoryReport : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public OtherIncomeCategoryReport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void OtherIncomeCategoryReport_Load(object sender, EventArgs e)
        {
            fetchCompany();
            fetchCategory();
            bindbankdata();

        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_OtherIncome where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvincomeCategory.AutoGenerateColumns = false;
            dgvincomeCategory.ColumnCount = 2;
            dgvincomeCategory.Columns[0].HeaderText = "Category Name";
            dgvincomeCategory.Columns[0].DataPropertyName = "IncomeCategory";
            dgvincomeCategory.Columns[1].HeaderText = "Received";
            dgvincomeCategory.Columns[1].DataPropertyName = "Received";
            dgvincomeCategory.DataSource = dt;
        }
        private void fetchCategory()
        {
            if (cmbExpensecategory.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select OtherIncome from tbl_otherIncomeCaategory where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by OtherIncome ");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbExpensecategory.Items.Add(ds.Tables["Temp"].Rows[i]["OtherIncome"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void fetchCompany()
        {
            if (cmbAllFirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1' group by CompanyName ");
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

        private void dtpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select IncomeCategory,Received from tbl_OtherIncome  where Date between '" + dtpFromDate.Value.ToString() + "' and '" + dtpToDate.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvincomeCategory.DataSource = ds;
                dgvincomeCategory.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void cmbExpensecategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select IncomeCategory,Received  from tbl_OtherIncome where IncomeCategory='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbExpensecategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvincomeCategory.DataSource = ds;
                dgvincomeCategory.DataMember = "temp";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvincomeCategory_TabIndexChanged(object sender, EventArgs e)
        {
            Data();
        }
             private void Data()
        {
            float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];
            //e.SuppressKeyPress = true;
            for (int i = 0; i < dgvincomeCategory.Rows.Count; i++)
            {
                TA += float.Parse(dgvincomeCategory.Rows[i].Cells["Column2"].Value?.ToString());
                dgvincomeCategory.Text = TA.ToString();
                //    TD += float.Parse(dgvexpense.Rows[i].Cells["Column1"].Value?.ToString());
                //    txtqty.Text = TD.ToString();
                //    TG += float.Parse(dgvexpense.Rows[i].Cells["FreeQty"].Value?.ToString());
                //    txtfreeqty.Text = TG.ToString();
                //    qty = float.Parse(txtqty.Text.ToString());
                //    rate = float.Parse(txtfreeqty.Text.ToString());
                //    total = qty * rate;
                //    txtTotalQty.Text = total.ToString();
            }
        }

        private void cmbAllFirms_SelectedIndexChanged(object sender, EventArgs e)
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
                    string Query = string.Format("select c.CompanyID,c.CompanyName,c.Address,c.AddLogo,c.PhoneNo,c.GSTNumber,c.EmailID,b.IncomeCategory,b.Received,b.Company_ID from tbl_OtherIncome as b,tbl_CompanyMaster as c where b.Company_ID = '" + NewCompany.company_id + "' and c.CompanyID='" + NewCompany.company_id + "' and b.DeleteData = '1'");
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"OtherIncomeCategoryData.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("IncomeCategoryData", "IncomeCategoryData", ds.Tables[0]);

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
