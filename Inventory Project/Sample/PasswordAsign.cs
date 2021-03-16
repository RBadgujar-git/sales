using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class PasswordAsign : Form
    {
        public PasswordAsign()
        {
            InitializeComponent();
        }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
         
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
              New1.Focus();
                e.Handled = true;
            }
        }

        private void New3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                New2.Focus();
                e.Handled = true;
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
                Con3.Focus();
                e.Handled = true;
                button1.Hide();
              //  label4.Hide();
            }
        }

        private void Con3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Con2.Focus();
                e.Handled = true;
            }
        }

        private void Con2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                Con1.Focus();
                e.Handled = true;
            }
        }

        private void PasswordAsign_Load(object sender, EventArgs e)
        {
            button1.Hide();
            label4.Hide();
        }
    }
}
