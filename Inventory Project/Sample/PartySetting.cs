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

            if(Partygroup==1)
            {
                chkPartyGrouping.Checked = true;
            }
            if(REMINDER==1)
                {
                chkCustomerEnablePayment.Checked = true;
            }
            NumericUpDown.Value = notifyday;
            panel2.Visible = false;
            textBox1.Text = remindermessage;

        }
        public string remindermessage;
        private void ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {

        }
        public int Partygroup, REMINDER,dayreminder, notifyday;
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


                SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {

                    Partygroup = Convert.ToInt32(dr["Partygroup"]);
                    REMINDER= Convert.ToInt32(dr["REMINDER"]);
                    dayreminder = Convert.ToInt32(dr["dayreminder"]);
                    notifyday = Convert.ToInt32(dr["notifyday"]);
                    remindermessage = (dr["remindermessage"]).ToString();
                }
                dr.Close();

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("update Setting_Table Set remindermessage ='" + textBox1.Text + "' where  Company_ID=" + NewCompany.company_id + " ", con);
            cmd.ExecuteNonQuery();
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           
                SqlCommand cmd = new SqlCommand("update Setting_Table Set notifyday ="+NumericUpDown.Value+" where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            
        }

        private void chkPartyGrouping_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkPartyGrouping.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Partygroup = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkPartyGrouping.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Partygroup = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

            
        }

        private void chkCustomerEnablePayment_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkCustomerEnablePayment.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set REMINDER = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkCustomerEnablePayment.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set REMINDER = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }
    }
}
