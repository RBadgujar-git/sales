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
    public partial class TransactionSetting : UserControl
    {
        public TransactionSetting()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        private void TransactionSetting_Load(object sender, EventArgs e)
        {
            cheekpass();
            if(InvoiveNumber==1)
            {
                chkInvoiceBill.Checked = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public int InvoiveNumber;
        public void cheekpass()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


             
                SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    InvoiveNumber = Convert.ToInt32(dr["InvoiceNo"]);

                }
                dr.Close();



                //SqlCommand cmd1 = new SqlCommand("Select Gst_In from Setting_Table where Company_ID='"+NewCompany.company_id+"'", con);
                //gstint =Convert.ToInt32( cmd1.ExecuteScalar());

                //SqlCommand cmd2 = new SqlCommand("Select Enable_Launch from Setting_Table where Company_ID='" + NewCompany.company_id + "' ", con);
                //Enablelunch =Convert.ToInt32(cmd2.ExecuteScalar());

                //SqlCommand cmd3 = new SqlCommand("Select Estiment from Setting_Table where Company_ID='" + NewCompany.company_id + "' ", con);
                //Estiment = Convert.ToInt32(cmd3.ExecuteScalar());

            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }
        private void chkInvoiceBill_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvoiceBill.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set InvoiceNo = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkInvoiceBill.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set InvoiceNo = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }
    }
}
