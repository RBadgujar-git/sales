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

        }

        private void ExpenseCategoryReport_Load(object sender, EventArgs e)
        {
            fetchCategory();
        }
        private void fetchCategory()
        {
            if (cmbExpensecategory.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_ExpenseCategory group by CategoryName");
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
    }
}
