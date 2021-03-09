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
    public partial class ExpenseCategoryReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public ExpenseCategoryReport()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void txtExpensescategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbExpensecategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CategoryName,Paid  from tbl_Expense where CategoryName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbExpensecategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvExpensecategory.DataSource = ds;
                dgvExpensecategory.DataMember = "temp";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_Expenses where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvExpensecategory.AutoGenerateColumns = false;
            dgvExpensecategory.ColumnCount = 2;
            dgvExpensecategory.Columns[0].HeaderText = "Category Name";
            dgvExpensecategory.Columns[0].DataPropertyName = "CategoryName";
            dgvExpensecategory.Columns[1].HeaderText = " Paid Amount";
            dgvExpensecategory.Columns[1].DataPropertyName = "Paid";
            dgvExpensecategory.DataSource = dt;
        }


        private void ExpenseCategoryReport_Load(object sender, EventArgs e)
        {
            fetchCategory();
            bindbankdata();
            fetchCompany();
        }
        private void fetchCompany()
        {
            if (cmbAllfirms.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
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
        private void fetchCategory()
        {
            if (cmbExpensecategory.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_ExpenseCategory group by CategoryName where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbExpensecategory.Items.Add(ds.Tables["Temp"].Rows[i]["CategoryName"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmbAllfirms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtptodate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtptodate_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select CategoryName,Paid from tbl_Expenses  where Date between '" + dtpFromdate.Value.ToString() + "' and '" + dtptodate.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvExpensecategory.DataSource = ds;
                dgvExpensecategory.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void dgvExpensecategory_TabIndexChanged(object sender, EventArgs e)
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
            for (int i = 0; i < dgvExpensecategory.Rows.Count; i++)
            {
                TA += float.Parse(dgvExpensecategory.Rows[i].Cells["Column2"].Value?.ToString());
                txtTotalExpenses.Text = TA.ToString();
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

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
