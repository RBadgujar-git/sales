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
    public partial class SalePurchaseOrderReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public FormWindowState WindowState { get; private set; }

        public SalePurchaseOrderReport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void SalePurchaseOrderReport_Load(object sender, EventArgs e)
        {
            fetchCompany();
            Bindadata();
        }
        private void Bindadata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("(select * from tbl_SaleOrder) union all (select * from tbl_PurchaseOrder) where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvSaleorder.AutoGenerateColumns = false;
            dgvSaleorder.ColumnCount = 7;
            dgvSaleorder.Columns[0].HeaderText = "Date";
            dgvSaleorder.Columns[0].DataPropertyName = "OrderDate";
            dgvSaleorder.Columns[1].HeaderText = " Order No";
            dgvSaleorder.Columns[1].DataPropertyName = "OrderNo";
            dgvSaleorder.Columns[2].HeaderText = "Party Name";
            dgvSaleorder.Columns[2].DataPropertyName = "PartyName";
            dgvSaleorder.Columns[3].HeaderText = " PaymentType";
            dgvSaleorder.Columns[3].DataPropertyName = "PaymentType";
            dgvSaleorder.Columns[4].HeaderText = "Total";
            dgvSaleorder.Columns[4].DataPropertyName = "Total";
            dgvSaleorder.Columns[5].HeaderText = " Status";
            dgvSaleorder.Columns[5].DataPropertyName = "Status";
            dgvSaleorder.Columns[6].HeaderText = " TableName";
            dgvSaleorder.Columns[6].DataPropertyName = "TableName";

            dgvSaleorder.DataSource = dt;
        }//BillDate,BillNo,PartyName,Pay
        private void Data()
        {
            float TA = 0;
            //dgvexpense.Rows.Add();
            //row = dgvexpense.Rows.Count - 2;
            ////dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
            //dgvexpense.CurrentCell = dgvexpense[1, row];
            //e.SuppressKeyPress = true;
            for (int i = 0; i < dgvSaleorder.Rows.Count; i++)
            {
                TA += float.Parse(dgvSaleorder.Rows[i].Cells["Paid"].Value?.ToString());
                txtTotalAmount.Text = TA.ToString();

            }
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dtpToDaate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpToDaate_Enter(object sender, EventArgs e)
        {
            try
            {
                //TableName
                string SelectQuery = string.Format("select TableName,OrderDate,OrderNo,PartyName,PaymentType,Total,DueDate,Status from tbl_SaleOrder where InvoiceDate between '" + dtpFromDate.Value.ToString() + "' and '" + dtpToDaate.Value.ToString() + "' union all select TableName,OrderDate,OrderNo,PartyName,PaymentType,Total,DueDate,Status from tbl_PurchaseOrder where InvoiceDate between '" + dtpFromDate.Value.ToString() + "' and '" + dtpToDaate.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvSaleorder.DataSource = ds;
                dgvSaleorder.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string Tablename = cmbAlllFirms.SelectedItem.ToString();
            //if (Tablename == "Sale Order")
            //{
            //    try
            //    {
            //        //date = DateTime.Now.Month.ToString();
            //        //MessageBox.Show("moth o" + date);
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("select OrderDate,OrderNo,PartyName,PaymentType,Total,DueDate,Status from tbl_SaleOrder where  Sale Order(TableName)=" + Tablename + "  and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            //        SDA.Fill(ds, "temp");
            //        dgvSaleorder.DataSource = ds;
            //        dgvSaleorder.DataMember = "temp";
            //        con.Close();
            //        Data();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}

            //else if (Tablename == "Purchase Order")
            //{
            //    try
            //    {
            //        //date = DateTime.Now.Year.ToString();

            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("select OrderDate,OrderNo,PartyName,PaymentType,Total,DueDate,Status from tbl_PurchaseOrder where Purchase(TableName)=" + Tablename + " and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", con);
            //        DataSet ds = new DataSet();
            //        SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            //        SDA.Fill(ds, "temp");
            //        dgvSaleorder.DataSource = ds;
            //        dgvSaleorder.DataMember = "temp";
            //        con.Close();
            //        Data();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbAlllFirms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvSaleorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
