﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample
{
    public partial class PasswordAsign : Form
    {
        public PasswordAsign()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            New1.Focus();
        }
        public int p=0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          if(p==0)
            {
                New2.Focus();
                p = 0;
            }
          if(p==1)
            {
                p = 0;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                New3.Focus();
                p = 0;
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                New4.Focus();
                p = 0;
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Con1.Focus();
                p = 0;
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Con2.Focus();
                p = 0;
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Con3.Focus();
                p = 0;
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Con4.Focus();
                p = 0;
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
          
           }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
              ///  Old3.Focus();
                e.Handled = true;
            }
        }

        private void Old3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
              //  Old2.Focus();
                e.Handled = true;
            }
        }

        private void Old2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
           //     Old1.Focus();
                e.Handled = true;
            }
        }

        private void New1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void New2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                New1.Clear();
                New1.Focus();
                p = 1;
            }
        }

        private void New3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                New2.Clear();
                New2.Focus();
                p = 1;
            }
        }

        private void Con4_TextChanged(object sender, EventArgs e)
        {


            if ((New1.Text == Con1.Text) && (New2.Text == Con2.Text) && (New3.Text == Con3.Text) && (New4.Text == Con4.Text))
            {
                button1.Show();
                label4.Hide();

            }
            else
            {
                label4.Show();
                button1.Hide();
                label4.Text = "Passcode Not  Match !";
            }




        }

        private void Con4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Con3.Clear();
                Con3.Focus();       
                e.Handled = true;
                p = 1;
                button1.Hide();
              //  label4.Hide();
            }
        }

        private void Con3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Con2.Clear();
                Con2.Focus();
                e.Handled = true;
                p = 1;
            }
        }

        private void Con2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Con1.Clear();
                Con1.Focus();
                // e.Handled = true;
                p = 1;
            }
        }

        private void PasswordAsign_Load(object sender, EventArgs e)
        {
            button1.Hide();
            label4.Hide();
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
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@password", a1);
                    cmd.Parameters.AddWithValue("@ComId", NewCompany.company_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passcode Creted !");
                    this.Close();
                }
            }
            catch(Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            
            insert();

        }

        private void New4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                New3.Clear();
                New3.Focus();
               p = 1;
           }
       }

        private void Con1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                New4.Clear();
                New4.Focus();
                p = 1;
            }
        }
    }
}
