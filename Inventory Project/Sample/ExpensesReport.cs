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
        }
        private void fetchexpenses()
        {
            if (cmbexpenses.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_ExpenseCategory group by CategoryName");
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
    }
}
