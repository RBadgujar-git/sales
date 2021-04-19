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
using System.Net.Mail;
using System.Net;

namespace sample
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public int p = 0;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Pass2.Focus();
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
                pass3.Focus();
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void pass3_TextChanged(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Pass4.Focus();
            }
            if (p == 1)
            {
                p = 0;
            }
        }

        private void Pass4_KeyDown(object sender, KeyEventArgs e)
        {
            //if (pass1.Text == "" && Pass2.Text == "" & pass3.Text == "" && Pass4.Text == "")
            //{
            //    label4.Text = "Password is in complite  !";
            //}
            //else
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (con.State == ConnectionState.Closed)
            //        {
            //            con.Open();
            //        }
            //        string a1 = pass1.Text.ToString() + Pass2.Text.ToString() +pass3.Text.ToString() +Pass4.Text.ToString();

            //        SqlCommand cmd = new SqlCommand("Select Password from PasswordCheek", con);
            //        string Password = cmd.ExecuteScalar().ToString();

            //     //   MessageBox.Show("Data"+a1+ "get"+ Password);
            //        if(a1==Password)
            //        {
            //            Dashboard ds = new Dashboard();
            //            ds.Show();
            //            this.Hide();
            //        }
            //        else
            //        {
            //            label4.Text = "Password is Incorect ! ";

            //        }
            //    }
            //}

            if (e.KeyCode == Keys.Back)
            {
                pass3.Clear();
                pass3.Focus();
                p = 1;
            }
        }

        private void Pass4_TextChanged(object sender, EventArgs e)
        {
            if (pass1.Text == "" && Pass2.Text == "" & pass3.Text == "" && Pass4.Text == "")
            {
                label4.Visible = true;
                label4.Text = "Password is in complite  !";
                pass1.Clear();
                Pass2.Clear();
                pass3.Clear();
                Pass4.Clear();
                p = 0;
                pass1.Focus();
            }
            else
            {
                
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string a1 = pass1.Text.ToString() + Pass2.Text.ToString() + pass3.Text.ToString() + Pass4.Text.ToString();

                    SqlCommand cmd = new SqlCommand("Select Password from PasswordCheek", con);
                    string Password = cmd.ExecuteScalar().ToString();

                    //   MessageBox.Show("Data"+a1+ "get"+ Password);
                    if (a1 == Password)
                    {
                        Dashboard ds = new Dashboard();
                        ds.Show();
                        this.Hide();
                    }
                    else
                    {
                        label4.Text = "Password is Incorect ! ";
                    pass1.Clear();
                    Pass2.Clear();
                    pass3.Clear();
                    Pass4.Clear();
                    p = 0;
                    pass1.Focus();
                    }
                }
            
        }
        public string to;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        string from, pass, meesagebody;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("Select Password from PasswordCheek", con);
            string Password = cmd.ExecuteScalar().ToString();

            SqlCommand cmd1 = new SqlCommand("Select EmailId from tbl_CompanyMaster Where Defulatcompany = '1' ", con);
            to = cmd1.ExecuteScalar().ToString();
            MailMessage mail = new MailMessage();

            from = "ideal.tech.info2@gmail.com";
            pass = "Ideal@123";
            meesagebody = "your reset password is \t" + Password;
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Body = meesagebody;
            mail.Subject = "Reset password";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(mail);
                MessageBox.Show("code send successfully !");
            }
            catch(Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
            



        }

        private void Pass4_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pass3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Pass2.Clear();
               Pass2.Focus();
                p = 1;
            }
        }

        private void Pass2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                pass1.Clear();
                pass1.Focus();
                p = 1;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
