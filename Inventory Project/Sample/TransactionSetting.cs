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

        public int InvoiveNumber;
        public int cashbydefault;
        public int CustomerPoDetails;
        public int billreport;
        public int displaypurchaseprice;
        public int displayfree;
        public int count1;
        public static string sa;
        public int taxwise;
        public int diswise;
        public int showpreview;
        public int duedate;
        public int round;
        public int vehicle;
        public int delloc;
        public int deldt;
        public int transname;


        private void TransactionSetting_Load(object sender, EventArgs e)
        {
            cheekpass();
            cheekpass1();
            if (InvoiveNumber == 1)
            {
                chkInvoiceBill.Checked = true;
            }
            if (cashbydefault == 1)
            {
                chkCashSale.Checked = true;
            }
            if (CustomerPoDetails == 1)
            {
                chkCustomerPo.Checked = true;
            }
            if (billreport == 1)
            {
                chkBillingname.Checked = true;
            }
            if (displaypurchaseprice == 1)
            {
                chkDisplayPurchase.Checked = true;
            }
            if (displayfree == 1)
            {
                chkDisplayfreeQty.Checked = true;
            }
            if (count1 == 1)
            {
                Chkcount.Checked = true;
            }
            if (taxwise == 1)
            {
                chkTranscationWiseTax.Checked = true;
            }
            if (diswise == 1)
            {
                chkTransactionWiseDiscount.Checked = true;
            }
            if (showpreview == 1)
            {
                chkInvoicePreview.Checked = true;
            }
            if (duedate == 1)
            {
                chkDuedate.Checked = true;
            }
            if (round == 1)
            {
                chkRound.Checked = true;
            }
            if (vehicle == 1)
            {
                guna2CheckBox1.Checked = true;
            }
            if (deldt == 1)
            {
                guna2CheckBox2.Checked = true;
            }
            if (delloc == 1)
            {
                guna2CheckBox3.Checked = true;
            }
            if (transname == 1)
            {
                guna2CheckBox4.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
       
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
                    CustomerPoDetails = Convert.ToInt32(dr1["CustomerPoDetails"]);
                    billreport = Convert.ToInt32(dr1["BillingNameByParties"]);
                    displaypurchaseprice = Convert.ToInt32(dr1["DisplayPurchasePriseOnItem"]);
                    displayfree = Convert.ToInt32(dr1["DisplayFreeQty"]);
                    count1 = Convert.ToInt32(dr1["Count"]);
                    taxwise = Convert.ToInt32(dr1["TransactionWiseTax"]);
                    diswise = Convert.ToInt32(dr1["TransactionWiseDiscount"]);
                    showpreview = Convert.ToInt32(dr1["DoNotShowInvoicePreview"]);
                    duedate = Convert.ToInt32(dr1["DueDatesAndPaymentTerms"]);
                    round = Convert.ToInt32(dr1["RoundOff"]);
                    vehicle = Convert.ToInt32(dr1["VehicleNo"]);
                    deldt = Convert.ToInt32(dr1["DeliveryDate"]);
                    delloc = Convert.ToInt32(dr1["DeliveryLocation"]);
                    transname = Convert.ToInt32(dr1["TransportName"]);

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

        private void chkCustomerPo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomerPo.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set CustomerPoDetails = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkCustomerPo.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set CustomerPoDetails = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkBillingname_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBillingname.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set BillingNameByParties = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkBillingname.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set BillingNameByParties = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkDisplayPurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisplayPurchase.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DisplayPurchasePriseOnItem = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkDisplayPurchase.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DisplayPurchasePriseOnItem = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkDisplayfreeQty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisplayfreeQty.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DisplayFreeQty = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkDisplayfreeQty.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DisplayFreeQty = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void Chkcount_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkcount.Checked == true)
            {
                textBox1.Enabled = true;
                guna2Button3.Enabled = true;
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set Count = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (Chkcount.Checked == false)
            {
                textBox1.Enabled = false;
                guna2Button3.Enabled = false;
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set Count = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {         
            sa = textBox1.Text;
        }

        private void chkTranscationWiseTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTranscationWiseTax.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [TransactionWiseTax] = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkTranscationWiseTax.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [TransactionWiseTax] = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkTransactionWiseDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransactionWiseDiscount.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [TransactionWiseDiscount] = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkTransactionWiseDiscount.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [TransactionWiseDiscount] = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkInvoicePreview_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvoicePreview.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [DoNotShowInvoicePreview] = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkInvoicePreview.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [DoNotShowInvoicePreview] = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkDuedate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuedate.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [DueDatesAndPaymentTerms] = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkDuedate.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [DueDatesAndPaymentTerms] = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkRound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRound.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [RoundOff] = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkRound.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set [RoundOff] = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set TransportName = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (guna2CheckBox1.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set TransportName = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox3.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DeliveryLocation = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (guna2CheckBox3.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DeliveryLocation = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox4.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set VehicleNo = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (guna2CheckBox4.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set VehicleNo = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox2.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DeliveryDate = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (guna2CheckBox2.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update TransactionTableSetting Set DeliveryDate = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
