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
    public partial class OtherIncomeItemReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public OtherIncomeItemReport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void OtherIncomeItemReport_Load(object sender, EventArgs e)
        {
            fetchCompany();
            fetchdata();
        }
        private void fetchdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_OtherIncomeInner where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvOtherIncome.AutoGenerateColumns = false;
            dgvOtherIncome.ColumnCount = 4;
            dgvOtherIncome.Columns[0].HeaderText = "Item Name";
            dgvOtherIncome.Columns[0].DataPropertyName = "ItemName";
            dgvOtherIncome.Columns[1].HeaderText = " Quantity";
            dgvOtherIncome.Columns[1].DataPropertyName = "Qty";
            dgvOtherIncome.Columns[2].HeaderText = "Free Qty";
            dgvOtherIncome.Columns[2].DataPropertyName = "freeQty";
            dgvOtherIncome.Columns[3].HeaderText = " Item Amount";
            dgvOtherIncome.Columns[3].DataPropertyName = "ItemAmount";
            dgvOtherIncome.DataSource = dt;
        }
        private void fetchCompany()
        {
            if (cmbAlllFirms.Text != "System.Data.DataRowView")
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
                        cmbAlllFirms.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
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
            
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select ItemName,Qty,freeQty,ItemAmount from tbl_OtherIncomeInner  where ItemName like'%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtfilter.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvOtherIncome.DataSource = ds;
                dgvOtherIncome.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }

        }
        private void Data()
        {
            float TA = 0, TD = 0, total = 0, TG = 0, qty = 0, rate = 0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];
            //e.SuppressKeyPress = true;
            for (int i = 0; i < dgvOtherIncome.Rows.Count; i++)
            {
                TA += float.Parse(dgvOtherIncome.Rows[i].Cells["Column2"].Value?.ToString());
                txttotal.Text = TA.ToString();
                TD += float.Parse(dgvOtherIncome.Rows[i].Cells["Column3"].Value?.ToString());
                txtqty.Text = TD.ToString();
                TG += float.Parse(dgvOtherIncome.Rows[i].Cells["freeqty"].Value?.ToString());
                txtfreeqty.Text = TG.ToString();
                qty = float.Parse(txtqty.Text.ToString());
                rate = float.Parse(txtfreeqty.Text.ToString());
                total = qty +rate;
                txtTotalQty.Text = total.ToString();
            }
        }

        private void cmbAlllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
