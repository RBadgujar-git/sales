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
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
          //  timer1.Interval = 1;
            //action = enumAction.close;

        }
        public enum enumAction
        {
            wait,
            start,
            close
        }
        private Notification.enumAction action;

        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(this.action)
            {
                case enumAction.wait:
                    //timer1.Interval = 5000;
                    action = enumAction.close;
                    break;
                case enumAction.start:
                    //timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;

                    }
                    else
                    {

                        if (this.Opacity == 1.0)
                        {
                            action = enumAction.wait;
                        }
                    }
                    break;
                case enumAction.close:
                    //timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if(base.Opacity==0.0)
                    {
                        base.Close();

                    }
                    break;

            }
            
        }

        private void Notification_Load(object sender, EventArgs e)
        {

        }

        public enum enumtype
        {
            succes,
            warrning,
            error,
            info
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void showalert(string msg , enumtype  type)
        {
            this.Opacity=0.0;
            this.StartPosition = FormStartPosition.Manual;
            string farm;
            for(int i=0;i<=10;i++)
            {
                farm = "alretr" + i.ToString();
                Notification na = (Notification)Application.OpenForms[farm];
                if(na==null)
                {
                    this.Name = farm;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width +15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height*i;
                    this.Location = new Point(this.x, this.y);
                    break;
   
                }
            }


            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            switch(type)
            {
                case enumtype.succes:
                    this.BackColor = Color.SeaGreen;
                    break;

            }




            this.label1.Text = msg;
            this.Show();
            this.action = enumAction.start;
            //this.timer1.Interval = 1;
            //timer1.Start();

        }
    }
}
