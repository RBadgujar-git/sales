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
    public partial class ItemSetting : UserControl
    {
        public FormWindowState WindowState { get; private set; }

        public ItemSetting()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        private void ItemSetting_Load(object sender, EventArgs e)
        {
            chkDirectBarcodescan.Visible = false;
            demo();
            cheekpass();
            fatchname();
            panel1.Visible = false;
            chkItemsUnit.Checked = true;
            guna2Button3.Visible = true;
            if (NameMrp == 0)
            {
                chkMRP.Checked = true;
                txtMRP.Text = MRPtext;
            }
            if (batchno == 0)
            {
                chkBatchNo.Checked = true;
                txtBatchNo.Text = batchNotext;
            }
                if (Serealno == 0)
            {
                chkSerialNo.Checked = true;
                txtSerialNo.Text = SeriealText;

            }
            if (MFd == 0)
            {
                chkmfgDate.Checked = true;
                txtmfgdate.Text = Mfddatetext;
            }
              if (exd == 0)
            {
                chkExpdate.Checked = true;
                txtexpdate.Text = Expdatetext;
            }
             if (size == 0)
            {
                chkSize.Checked = true;
                txtSize.Text = Sizename;

            }
            if(itemwise==1)
            {
                guna2CheckBox16.Checked = true;
            }
            if (ItemwisTax == 1)
            {
                chkItemWiseTax.Checked = true;
            }
            if (barcode == 1)
            {
                chkBarcodeScan.Checked = true;
            }
            if(Stockmantance==0)
            {
                chkStockMaintance.Checked = true;
            }
            if(ItemCategory==1)
            {
                chkItemsCategory.Checked = true;
            }
            if(itemwisetax==1)
            {
                chkItemWiseTax.Checked = true;
            }
            chkDescription.Text = description;
            chkDescription.Checked = true;


            label6.Visible = false;

        }


        public void demo()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select count(*) from Item_Seeting where Company_ID="+NewCompany.company_id+"", con);
           int idd=Convert.ToInt32(cmd.ExecuteScalar());
           if(idd==0)
            {
                SqlCommand cmd1 = new SqlCommand("Insert into Item_Seeting(MRP,Batch_No,Serial_No,Mef_Date,Exp_date,Size,Company_ID,Expdaate,MFDAte,Description) values('MRP','Batch No','Serial No.','Mfg Date','Exp Date','Size'," + NewCompany.company_id+",'0','0','Description')", con);
                cmd1.ExecuteNonQuery();
            }     


        }

        public String MRPtext, batchNotext, SeriealText, Mfddatetext, Expdatetext,Sizename;
        public string description;
        public void fatchname()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("Select * from Item_Seeting where Company_ID=" + NewCompany.company_id + "", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    MRPtext = dr["MRP"].ToString() ;
                    batchNotext= dr["Batch_No"].ToString();
                    SeriealText= dr["Serial_No"].ToString();
                    Mfddatetext= dr["Mef_Date"].ToString();
                    Expdatetext= dr["Exp_date"].ToString();
                    Sizename= dr["Size"].ToString();
                    description = dr["Description"].ToString();
                }
                dr.Close();

            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }
    
        public int NameMrp,batchno,Serealno,MFd,exd,size,itemwise, ItemwisTax,barcode;
        public int Stockmantance, ItemCategory, itemwisetax;

        public void cheekpass()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID="+NewCompany.company_id+"", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    NameMrp=Convert.ToInt32( dr["MRPDate"]);
                    batchno = Convert.ToInt32(dr["BatchNo"]);
                    Serealno = Convert.ToInt32(dr["SerialNo"]);
                    MFd = Convert.ToInt32(dr["MnfDate"]);
                    exd = Convert.ToInt32(dr["ExpDate"]);
                    itemwise= Convert.ToInt32(dr["ItemWiseDiscount"]);
                    size = Convert.ToInt32(dr["Size"]);
                    ItemwisTax=Convert.ToInt32(dr["ItemwisTax"]);
                    barcode= Convert.ToInt32(dr["barcode"]);
                    Stockmantance= Convert.ToInt32(dr["Stockmantance"]);
                    ItemCategory = Convert.ToInt32(dr["ItemCategory"]);
                    itemwisetax = Convert.ToInt32(dr["itemwisetax"]);
                }
                dr.Close();
            
            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }
        public static string MRPrate;
       
       
        private void guna2CheckBox14_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDescription.Checked == true)
            {
                guna2Button3.Visible = true;
            }
            else if (chkDescription.Checked == false)
            {
                guna2Button3.Visible = false;
                panel1.Visible = false;
            }
        }

        private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmfgDate.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set MnfDate = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
                txtMRP.Focus();
            }
            else if (chkmfgDate.Checked == false)
            {
                 SqlCommand cmd = new SqlCommand("update Setting_Table Set MnfDate = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                txtmfgdate.Text = " Mfg Date";
                //  txtMRP.Visible = false;
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            updatename();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      public void updatename()
        {

            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update Item_Seeting Set MRP='"+txtMRP.Text+"',Batch_No='"+txtBatchNo.Text+"',Serial_No='"+txtSerialNo.Text+"',Mef_Date='"+txtmfgdate.Text+"', Exp_date='"+txtexpdate.Text+"', Size='"+txtSize.Text+"' where  Company_ID=" + NewCompany.company_id + "", con);
            cmd.ExecuteNonQuery();

        }

        private void txtMRP_TextChanged(object sender, EventArgs e)
        {
            updatename();
        }

        private void txtBatchNo_TextChanged(object sender, EventArgs e)
        {
            updatename();
        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {
            updatename();
        }

        private void txtmfgdate_TextChanged(object sender, EventArgs e)
        {
            updatename();
        }

        private void txtexpdate_TextChanged(object sender, EventArgs e)
        {
            updatename();
        }

        private void cmbmgfdate_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtmfgdate_TextChanged_1(object sender, EventArgs e)
        {
            updatename();
        }

        private void cmbmgfdate_SelectedIndexChanged_1(object sender, EventArgs e)
        {      
            if (cmbmgfdate.Text=="dd/mm/yyyy")
            {
                SqlCommand cmd = new SqlCommand("update Item_Seeting Set MFDAte = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
             //   txtMRP.Focus();
            }
            else if (cmbmgfdate.Text == "mm/yyyy")
            {
                SqlCommand cmd = new SqlCommand("update Item_Seeting Set MFDAte = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                //  txtMRP.Visible = false;
            }
        }

        private void chkEnableItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableItem.Checked == true)
            {
                chkEnableItem.Checked = true;
            }
            else if (chkEnableItem.Checked == false)
            {
                chkEnableItem.Checked = true;
                label5.Visible = true;
            }
        }
        private void chkBarcodeScan_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkBarcodeScan.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set barcode = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkBarcodeScan.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set barcode = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }

        private void chkItemWiseTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemWiseTax.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemwisTax = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkItemWiseTax.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemwisTax = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkCustomerEnable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkStockMaintance_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkStockMaintance.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Stockmantance = '0' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkStockMaintance.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Stockmantance = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkDirectBarcodescan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkItemsUnit_CheckedChanged(object sender, EventArgs e)
        {
            chkItemsUnit.Checked = true;
            label6.Visible = true;
         
        }

        private void chkShowLowstockDailog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkItemsCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkItemsCategory.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemCategory = '1' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();

            }
            else if (chkItemsCategory.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemCategory = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
               
            }
        }

        private void chkPartyWiseItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox1.Text = description;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Item_Seeting Set Description='"+textBox1.Text+"' where  Company_ID=" + NewCompany.company_id + "", con);
            cmd.ExecuteNonQuery();
            panel1.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void chkItemsUnit_Leave(object sender, EventArgs e)
        {
           
        }

        private void s(object sender, EventArgs e)
        {

        }

        private void chkItemWiseTax_CheckedChanged_1(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkItemWiseTax.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set itemwisetax = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkItemWiseTax.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set itemwisetax = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static int checkbarcode = 0;
        public static void chekpoint()
        {

            SqlConnection con1 = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

            con1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con1);
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                checkbarcode = Convert.ToInt32(dr["barcode"]);
                //NameMrp = Convert.ToInt32(dr["MRPDate"]);
                //batchno = Convert.ToInt32(dr["BatchNo"]);
                //Serealno = Convert.ToInt32(dr["SerialNo"]);
                //MFd = Convert.ToInt32(dr["MnfDate"]);
                //exd = Convert.ToInt32(dr["ExpDate"]);
                //size = Convert.ToInt32(dr["Size"]);
            }
            dr.Close();
            con1.Close();
        }

        private void guna2CheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (guna2CheckBox16.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemWiseDiscount = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (guna2CheckBox16.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemWiseDiscount = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void txtSerialNo_TextChanged_1(object sender, EventArgs e)
        {
            updatename();
        }

        private void txtBatchNo_TextChanged_1(object sender, EventArgs e)
        {
            updatename();
        }

        private void txtMRP_TextChanged_1(object sender, EventArgs e)
        {
            updatename();
        }

        private void txtexpdate_TextChanged_1(object sender, EventArgs e)
        {
            updatename();
        }

        private void expcomb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbmgfdate.Text == "dd/mm/yyyy")
            {
                SqlCommand cmd = new SqlCommand("update Item_Seeting Set Expdaate = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
                //   txtMRP.Focus();
            }
            else if (cmbmgfdate.Text == "mm/yyyy")
            {
                SqlCommand cmd = new SqlCommand("update Item_Seeting Set Expdaate = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                //  txtMRP.Visible = false;
            }
        }

        private void chkMRP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMRP.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set MRPDate = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
               txtMRP.Focus();
            }
            else if (chkMRP.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set MRPDate = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                txtMRP.Text = "MRP";
              //  txtMRP.Visible = false;
            }

        }

        private void chkBatchNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBatchNo.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set BatchNo = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
        
            }
            else if (chkBatchNo.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set BatchNo = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                txtBatchNo.Text = "Batch No.";
                //  txtMRP.Visible = false;
            }
        }

        private void chkSerialNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSerialNo.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set SerialNo = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
             
            }
            else if (chkSerialNo.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set SerialNo = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                txtSerialNo.Text = "Serial No.";
                //  txtMRP.Visible = false;
            }
        }

        private void chkExpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpdate.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ExpDate = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
               
            }
            else if (chkExpdate.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ExpDate = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                txtexpdate.Text = "Exp Date";
                //  txtMRP.Visible = false;
            }
        }

        private void chkSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSize.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Size = '0' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
     
            }
            else if (chkSize.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Size = '1' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
                txtSize.Text = "Size";
                //  txtMRP.Visible = false;
            }
        }
    }
}
