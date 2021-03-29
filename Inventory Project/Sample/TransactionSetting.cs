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
            cheekpass1();
            if (InvoiveNumber==1)
            {
                chkInvoiceBill.Checked = true;
            }
            else if (cashbydefault == 1)
            {
                chkCashSale.Checked = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public int InvoiveNumber;
        public int cashbydefault;
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
            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
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
                    cashbydefault = Convert.ToInt32(dr1["CashSaleByDefault"]);

                }
                dr1.Close();
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

                SqlCommand cmd1 = new SqlCommand("SET IDENTITY_INSERT [tbl_PurchaseBill] ON", con);
                cmd1.ExecuteNonQuery();

                //SqlCommand cmd2 = new SqlCommand("SET IDENTITY_INSERT [tbl_SaleInvoice] ON", con);
                //cmd2.ExecuteNonQuery();

                

            }
            else if (chkInvoiceBill.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set InvoiceNo = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SET IDENTITY_INSERT [tbl_PurchaseBill] OFF", con);
                cmd1.ExecuteNonQuery();

                //SqlCommand cmd2 = new SqlCommand("SET IDENTITY_INSERT [tbl_SaleInvoice] OFF", con);
                //cmd2.ExecuteNonQuery();

            }

        }

        private void chkCashSale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCashSale.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [CashSaleByDefault] = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkCashSale.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [CashSaleByDefault] = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
