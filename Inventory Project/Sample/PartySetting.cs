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
    public partial class PartySetting : UserControl
    {
        public FormWindowState WindowState { get; private set; }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public int shipadd;
        public int printship;
        public PartySetting()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PartySetting_Load(object sender, EventArgs e)
        {
            cheekpass1();
            if (shipadd == 1)
            {
                chkShippingAdd.Checked = true;
            }
            if (printship == 1)
            {
                chkPrintShipping.Checked = true;
            }
        }

        private void ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {

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
                    shipadd = Convert.ToInt32(dr1["ShippingAddress"]);
                    printship = Convert.ToInt32(dr1["PrintShippingAddress"]);
                }
                dr1.Close();
            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }

        }
        private void chkShippingAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShippingAdd.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set ShippingAddress = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkShippingAdd.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set ShippingAddress = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkPrintShipping_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrintShipping.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set PrintShippingAddress = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkPrintShipping.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set PrintShippingAddress = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
