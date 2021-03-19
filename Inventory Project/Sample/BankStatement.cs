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
    public partial class BankStatement : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public BankStatement()
        {
            InitializeComponent();
        }

        public FormWindowState WindowState { get; private set; }

        private void BankStatement_Load(object sender, EventArgs e)
        {
            bankname(); 
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbbankname_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void bankname()
        {

            if (cmbbankname.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select BankName from tbl_BankAccount where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by BankName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbbankname.Items.Add(ds.Tables["Temp"].Rows[i]["BankName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }

        }
    }
}
