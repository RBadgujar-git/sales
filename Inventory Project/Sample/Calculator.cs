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
    public partial class Calculator : Form
    {
        float num1, ans;
        int count;
        public Calculator()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 1;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 0 + 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 7;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 8;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 9;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 5;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 6;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 2;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Text = txtPartyGroupName.Text + 3;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            int c = txtPartyGroupName.TextLength;
            int flag = 0;
            string text = txtPartyGroupName.Text;
            for (int i = 0; i < c; i++)
            {
                if (text[i].ToString() == ".")
                {
                    flag = 1; break;
                }
                else
                {
                    flag = 0;
                }
            }
            if (flag == 0)
            {
                txtPartyGroupName.Text = txtPartyGroupName.Text + ".";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPartyGroupName.Clear();
            count = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            compute(count);
        }
        public void compute(int count)
        {
            switch (count)
            {
                case 1:
                    ans = num1 - float.Parse(txtPartyGroupName.Text);
                    txtPartyGroupName.Text = ans.ToString();
                    break;
                case 2:
                    ans = num1 + float.Parse(txtPartyGroupName.Text);
                    txtPartyGroupName.Text = ans.ToString();
                    break;
                case 3:
                    ans = num1 * float.Parse(txtPartyGroupName.Text);
                    txtPartyGroupName.Text = ans.ToString();
                    break;
                case 4:
                    ans = num1 / float.Parse(txtPartyGroupName.Text);
                    txtPartyGroupName.Text = ans.ToString();
                    break;
                default:
                    break;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(txtPartyGroupName.Text);
            txtPartyGroupName.Clear();
            txtPartyGroupName.Focus();
            count = 4;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(txtPartyGroupName.Text);
            txtPartyGroupName.Clear();
            txtPartyGroupName.Focus();
            count = 3;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (txtPartyGroupName.Text != "")
            {
                num1 = float.Parse(txtPartyGroupName.Text);
                txtPartyGroupName.Clear();
                txtPartyGroupName.Focus();
                count = 1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(txtPartyGroupName.Text);
            txtPartyGroupName.Clear();
            txtPartyGroupName.Focus();
            count = 2;
        }
    }
}
