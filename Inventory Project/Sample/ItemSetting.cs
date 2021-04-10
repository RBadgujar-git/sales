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

            demo();
            cheekpass();
            fatchname();
        
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
                SqlCommand cmd1 = new SqlCommand("Insert into Item_Seeting(MRP,Batch_No,Serial_No,Mef_Date,Exp_date,Size,Company_ID) values('MRP','Batch No','Serial No.','Mfg Date','Exp Date','Size',"+NewCompany.company_id+")", con);
                cmd1.ExecuteNonQuery();
            }     


        }

        public String MRPtext, batchNotext, SeriealText, Mfddatetext, Expdatetext,Sizename;
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

                }
                dr.Close();

            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }
    
        public int NameMrp,batchno,Serealno,MFd,exd,size,itemwise, ItemwisTax;

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

        }

        private void chkItemWiseTax_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox16.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemwisTax = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (guna2CheckBox16.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set ItemwisTax = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void guna2CheckBox16_CheckedChanged(object sender, EventArgs e)
        {
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
