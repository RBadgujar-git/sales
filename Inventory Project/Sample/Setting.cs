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
        public int password, gstint, Enablelunch, Estiment,Purchess ,dilivary,Autobackup;
        public int loadvariable=0;

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

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        public static string gstin ;



        private void Setting_Load(object sender, EventArgs e)
        {
            cheekpass();
            panel1.Hide();
            if (password !=0)
            {
                loadvariable = 1;
                chkEnablePassword.Checked = true;               
            }
            if(gstint==1)
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

            guna2Button1.Hide();
            fetchcustomername();

           // panel2.Hide();


            //for (int i = 0; i <= 4; i++)
            //{
            //    RadioButton rdo = new RadioButton();
            //    rdo.Name = "RadioButton" + i;
            //    rdo.Text = "Radio Button " + i;
            //   // rdo.Location = new Point(395, 79 * i);
            //    groupBox1.Controls.Add(rdo);

            //}
        }

        private void chkSaleOrder_CheckedChanged(object sender, EventArgs e)
        {
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
