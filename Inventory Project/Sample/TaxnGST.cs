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
    public partial class TaxnGST : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public int Hsn;
        public int cashbydefault;
        public int CustomerPoDetails;
        public int billreport;
     
        public TaxnGST()
        {
            InitializeComponent();
        }

        public FormWindowState WindowState { get; private set; }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TaxnGST_Load(object sender, EventArgs e)
        {
            cheekpass1();
            if (Hsn == 1)
            {
                chkEnableHSn.Checked = true;
            }
        }
        public void cheekpass1()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd2 = new SqlCommand("Select * from TransactionTableSetting where Company_ID='" + NewCompany.company_id + "'", con);
                SqlDataReader dr1 = cmd2.ExecuteReader();

                while (dr1.Read())
                {
                    Hsn = Convert.ToInt32(dr1["HSN"]);
                   // CustomerPoDetails = Convert.ToInt32(dr1["CustomerPoDetails"]);                   
                }
                dr1.Close();
            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }

        }
        private void chkEnableHSn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableHSn.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set HSN = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkEnableHSn.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set HSN = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
