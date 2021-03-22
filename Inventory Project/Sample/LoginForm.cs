using System;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
            Pass2.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pass3.Focus();
        }

        private void pass3_TextChanged(object sender, EventArgs e)
        {
           Pass4.Focus();
        }

        private void Pass4_KeyDown(object sender, KeyEventArgs e)
        {
            if (pass1.Text == "" && Pass2.Text == "" & pass3.Text == "" && Pass4.Text == "")
            {
                label4.Text = "Password is in complite  !";
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string a1 = pass1.Text.ToString() + Pass2.Text.ToString() +pass3.Text.ToString() +Pass4.Text.ToString();

                    SqlCommand cmd = new SqlCommand("Select Password from PasswordCheek", con);
                    string Password = cmd.ExecuteScalar().ToString();

                 //   MessageBox.Show("Data"+a1+ "get"+ Password);
                    if(a1==Password)
                    {
                        Dashboard ds = new Dashboard();
                        ds.Show();
                        this.Hide();
                    }
                    else
                    {
                        label4.Text = "Password is Incorect ! ";

                    }
                }
            }
        }

        private void Pass4_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
         

        }
    }
}
