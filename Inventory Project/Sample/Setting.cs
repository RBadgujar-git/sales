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
    public partial class Setting : UserControl
    {
        public FormWindowState WindowState { get; private set; }

        public Setting()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public int password, gstint, Enablelunch, Estiment,Purchess ,dilivary,Autobackup,otherincome;
        public int loadvariable=0, cashremoinder;

        public void cheekpass()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Select count(*)  from PasswordCheek   ", con);
                password = Convert.ToInt32(cmd.ExecuteScalar());

                SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
              
                    while (dr.Read())
                    {

                    gstint = Convert.ToInt32(dr["Gst_In"]);
                    Enablelunch =Convert.ToInt32( dr["Enable_Launch"]);
                    Estiment = Convert.ToInt32 (dr["Estiment"]);
                    Purchess= Convert.ToInt32(dr["Sale_purches"]);
                    dilivary= Convert.ToInt32(dr["Delliverychallen"]);
                    Autobackup= Convert.ToInt32(dr["Autobackup"]);
                    otherincome = Convert.ToInt32(dr["OtheIncome"]);
                    cashremoinder = Convert.ToInt32(dr["cashremoinder"]);

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
        private void chkEnablePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (loadvariable != 1)
            {
                if (chkEnablePassword.Checked == true)
                {
                    PasswordAsign fr = new PasswordAsign();
                    fr.Show();
                }
                else if (chkEnablePassword.Checked == false)
                {
                    DialogResult dr = MessageBox.Show("Are you Sure To Remove Passcode ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd = new SqlCommand("Delete from PasswordCheek",con);
                        cmd.ExecuteNonQuery();

                    }
                    else if (dr == DialogResult.No)

                    {
                        chkEnablePassword.Checked = true;

                        PasswordAsign fr = new PasswordAsign();
                        fr.Hide();
                    }
                }

            }
            else
            {
                loadvariable = 0;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            clerar();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (NumericUpDown1.Value == 0)
            {
                label11.Text = "";
            }
          if (NumericUpDown1.Value==1)
            {
                label11.Text = 0.ToString();
            }
            if (NumericUpDown1.Value == 2)
            {
                label11.Text = "00";
            }
             if (NumericUpDown1.Value == 3)
            {
                label11.Text = "000";
            }
            if (NumericUpDown1.Value == 4)
            {
                label11.Text = "0000";
            }
            if (NumericUpDown1.Value == 5)
            {
                label11.Text = "00000";
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update Setting_Table Set cashremoinder ="+NumericUpDown1.Value+" where  Company_ID=" + NewCompany.company_id + " ", con);
            cmd.ExecuteNonQuery();


        }
        public static string gstin ;



        
        private void Setting_Load(object sender, EventArgs e)
        {
            cheekpass();
            panel1.Hide();
            button3.Hide();
            guna2Button3.Visible = false;
            panel3.Visible = false;
            label16.Visible = false;
            if (password !=0)
            {
                loadvariable = 1;
                chkEnablePassword.Checked = true;
                guna2Button3.Visible = true;
               

            }
            if (gstint==1)
            {
                ChkGSTin.Checked = true;
                
            }
            if (Enablelunch == 1)
            {
               chkEnableLaunch.Checked = true;
               
            }
            if (Estiment == 1)
            {
                chkEstimate.Checked = true;

            }
            if (Purchess == 1)
            {
                chkSaleOrder.Checked = true;

            }
              if (dilivary == 1)
            {
                chkDeliveryChalln.Checked = true;
                panel1.Show();
            }
            if (Autobackup == 1)
            {

                chkAutoBackup.Checked = true;
                //panel1.Show();
            }
            NumericUpDown1.Value = cashremoinder;

            if (otherincome==1)
            {
                chkOtherincome.Checked = true;
            }
            guna2Button1.Hide();
            fetchcustomername();

            
           panel2.Hide();
            fetchCampanyame();
            defualt();
            //for (int i = 0; i <= 4; i++)
            //{
            //    RadioButton rdo = new RadioButton();
            //    rdo.Name = "RadioButton" + i;
            //    rdo.Text = "Radio Button " + i;
            //   // rdo.Location = new Point(395, 79 * i);
            //    groupBox1.Controls.Add(rdo);

            //}

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void defualt()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select CompanyName  from tbl_CompanyMaster where Defulatcompany=1", con);
            label12.Text = cmd.ExecuteScalar().ToString();
            btnlogin.Hide();
            con.Close();

        }
        private void fetchCampanyame()
        {
            if (cmbCompanyName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1'");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbCompanyName.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }



           
        }
        private void chkSaleOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkSaleOrder.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Sale_purches = '1' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkSaleOrder.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Sale_purches = '0' where Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void chkOtherincome_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkOtherincome.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set OtheIncome = '1' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkOtherincome.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set OtheIncome = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CompanyMaste rr = new CompanyMaste();
            rr.Show();
        }

        int i, x , w;
        private void button2_Click(object sender, EventArgs e)
        {
            //  createButton();
          
    }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
             
                guna2Button1.Show();
            }
            else if (guna2CheckBox1.Checked == false)
            {
                
                guna2Button1.Hide();

            }
        }

        private void radiobtnFirmName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (old1.Text == "" && old2.Text == "" & old3.Text == "" && old4.Text == "")
            {
                label16.Visible = true;
                label16.Text = "Password is in complite  !";
                old1.Clear();
                old2.Clear();
                old3.Clear();
                old4.Clear();
                old1.Focus();
            }
            else
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string a1 = old1.Text.ToString() + old2.Text.ToString() + old3.Text.ToString() + old4.Text.ToString();

                SqlCommand cmd = new SqlCommand("Select Password from PasswordCheek", con);
                string Password = cmd.ExecuteScalar().ToString();

                //   MessageBox.Show("Data"+a1+ "get"+ Password);
                if (a1 == Password)
                {
                    New1.Focus();
                    label16.Visible = false;
                }
                else
                {
                    label16.Visible = true;
                    label16.Text = "Password is in complite  !";
                    old1.Clear();
                    old2.Clear();
                    old3.Clear();
                    old4.Clear();
                    old1.Focus();

                }
            }

        
    }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            clerar();
        }

         public void clerar()
        {
            old1.Clear();old2.Clear();old3.Clear();old4.Clear();
            New1.Clear();New2.Clear();New3.Clear();New4.Clear();
            Con1.Clear();Con2.Clear();Con3.Clear();Con4.Clear();
            button3.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            insert();
            panel3.Visible = false;
        }
        private void New4_TextChanged(object sender, EventArgs e)
        {
            if (old1.Text == "" && old2.Text == "" & old3.Text == "" && old4.Text == "")
            {
                label16.Visible = true;
                label16.Text = "Fill all text  !";
                New1.Clear();
                New2.Clear();
                New3.Clear();
                New4.Clear();
                New1.Focus();
            }
            else
            {
                label16.Visible = false;
                Con1.Focus();
            }
        }
        public void insert()
        {

            try
            {
                if (NewCompany.company_id == null)
                {
                    MessageBox.Show("Please Select Company !");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string a1 = New1.Text.ToString() + New2.Text.ToString() + New3.Text.ToString() + New4.Text.ToString();
                    //  MessageBox.Show("Data is " + a1);

                    SqlCommand cmd = new SqlCommand("Sp_loginpassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@password", a1);
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ComId", NewCompany.company_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passcode Update !");

                   
                }
            }
            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }

        private void Con4_TextChanged(object sender, EventArgs e)
        {
            if ((New1.Text == Con1.Text) && (New2.Text == Con2.Text) && (New3.Text == Con3.Text) && (New4.Text == Con4.Text))
            {
                button3.Show();
                label16.Hide();

            }
            else
            {
                label16.Show();
                button3.Hide();
                label16.Text = "Passcode Not  Match !";
            }

        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Text = cmbCompanyName.Text;
            btnlogin.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Update tbl_CompanyMaster set Defulatcompany='0' ", con);
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("Update tbl_CompanyMaster set Defulatcompany='1' where CompanyName='" + label12.Text + "' and DeleteData='1'", con);
                cmd1.ExecuteNonQuery();

                MessageBox.Show(label12.Text+"Set as defualt ");
                btnlogin.Hide();
                con.Close();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void chkAutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoBackup.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Autobackup = '1' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkAutoBackup.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Autobackup = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }

        private void fetchcustomername()
        {
           
                try
                {

                if(con.State==ConnectionState.Closed)
                    {
                    con.Open();
                }
                DataSet ds = new DataSet();
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster where DeleteData='1' ");
                     SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                  
                    RadioButton btn = new RadioButton();
                    btn.Name = ds.Tables["Temp"].Rows[i]["CompanyName"].ToString();
                    btn.Location = new Point(3, 14 + x);           
                    btn.Text = ds.Tables["Temp"].Rows[i]["CompanyName"].ToString();

                   

                 

                    //  btn.Checked += new EventHandler("checked",);

                    //btn.Checked += new EventHandler();
                    //////btn.Click += new EventHandler();
                    //   btn.Add("onclick", "MyFunction()");

                    //btn.Checked.Add(
                    // ", "MyFunction()");

                    Panel panel = new Panel();
                    panel.Location = new Point(3, 35 + w);
                    panel.Size = new Size(200, 2);
                    panel.BackColor = Color.DarkGreen;                  
                    panel2.Controls.Add(panel);
                    panel2.Controls.Add(btn);

                
                    x += 50;
                    w += 55;





                }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }

            
        }
        private void createButton()
        {

            for (int j = 1; j <= 5; j++)
            {
                //    Button btn = new Button();
                RadioButton btn = new RadioButton();
           

                btn.Name = "btn1";
                btn.Location = new Point(3 , 14+x);
                btn.Text = "ffjsdfs";

                Panel panel= new Panel();
                panel.Location = new Point(3, 35+ w);
                panel.Size= new Size(200, 2);
                panel.BackColor = Color.DarkGreen;
                //     panel.Location = new Point(3, 14 + x);
                panel2.Controls.Add(panel);
                panel2.Controls.Add(btn);

           //     i += 10;
                x += 50;
                w += 55;

            }

        }
        private void chkDeliveryChalln_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkDeliveryChalln.Checked == true)
            {
                panel1.Show();
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Delliverychallen = '1' where  Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();

            }
            else if (chkDeliveryChalln.Checked == false)
            {
                panel1.Hide();
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Delliverychallen = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {



        }

        private void chkEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (chkEstimate.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Estiment = '1' where   Company_ID=" + NewCompany.company_id + "", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkEstimate.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Estiment = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }

        private void chkEnableLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEnableLaunch.Checked==true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Enable_Launch = '1' where  Company_ID=" + NewCompany.company_id +"", con);
                cmd.ExecuteNonQuery();
            }
            else if (chkEnableLaunch.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Enable_Launch = '0' where   Company_ID=" + NewCompany.company_id +"", con);
                cmd.ExecuteNonQuery();
            }

        }

        private void ChkGSTin_CheckedChanged(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            if (ChkGSTin.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Gst_In = '1' where  Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }
            else if (ChkGSTin.Checked == false)
            {
                SqlCommand cmd = new SqlCommand("update Setting_Table Set Gst_In = '0' where   Company_ID=" + NewCompany.company_id + " ", con);
                cmd.ExecuteNonQuery();
            }

        }
    }
}
