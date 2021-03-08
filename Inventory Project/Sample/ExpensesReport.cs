﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace sample
{
    public partial class ExpensesReport : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public ExpensesReport()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void ExpensesReport_Load(object sender, EventArgs e)
        {
            fetchexpenses();
            bindbankdata();
        }
        private void bindbankdata()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from tbl_Expenses where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dgvexpenses.AutoGenerateColumns = false;
            dgvexpenses.ColumnCount = 3;
            dgvexpenses.Columns[0].HeaderText = "Date";
            dgvexpenses.Columns[0].DataPropertyName = "Date";
            dgvexpenses.Columns[1].HeaderText = "Category";
            dgvexpenses.Columns[1].DataPropertyName = "ExpenseCategory";
            dgvexpenses.Columns[2].HeaderText = "Total";
            dgvexpenses.Columns[2].DataPropertyName = "Total";
            
            dgvexpenses.DataSource = dt;
        }
        private void fetchexpenses()
        {
            if (cmbexpenses.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_ExpenseCategory where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CategoryName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbexpenses.Items.Add(ds.Tables["Temp"].Rows[i]["CategoryName"].ToString());

                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cmbexpenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CategoryName from tbl_Expenses where CategoryName='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbexpenses.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvexpenses.DataSource = ds;
                dgvexpenses.DataMember = "temp";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpTodate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTodate_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select Date,CategoryName,Total from tbl_Expenses  where Date between '" + dtpFromDate.Value.ToString() + "' and '" + dtpTodate.Value.ToString() + "' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvexpenses.DataSource = ds;
                dgvexpenses.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }

        private void dgvexpenses_TabIndexChanged(object sender, EventArgs e)
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
            for (int i = 0; i < dgvexpenses.Rows.Count; i++)
            {
                TA += float.Parse(dgvexpenses.Rows[i].Cells["Column2"].Value?.ToString());
                txtTotalexpenes.Text = TA.ToString();
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
        }
}
