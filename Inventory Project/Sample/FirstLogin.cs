using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Net.NetworkInformation;

namespace sample
{
    public partial class FirstLogin : Form
    {
        public FirstLogin()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifs = new FirebaseConfig()
        {
           
              AuthSecret = "BNccxyAb8l3p4CJZcrCwwB3N6KYw3o5N3fjkG8w8",
              BasePath = "https://inventory-application-76653-default-rtdb.firebaseio.com/"

        };
        IFirebaseClient client;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FirstLogin_Load(object sender, EventArgs e)
        {
            try
            {
                guna2TextBox1.Visible = false;
                guna2Button1.Visible = false;
                client = new FireSharp.FirebaseClient(ifs);

            }
            catch
            {
                MessageBox.Show("internet Connection not open");
            }
        }
        public string mca;
        public void GetMACAddress()
        {
            System.Net.NetworkInformation.NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            mca = sMacAddress;

         //  MessageBox.Show("dfjdfdfdfhjd"+sMacAddress);
        }
        private void otp_Click(object sender, EventArgs e)
        {
            //  var result = client.Get("clientData/" + txtpartyfilter.Text);
            // var seeter = client.Get("clientData/" + txtpartyfilter.Text);

            //autontification fdd = seeter.ResultAs<autontification>();
            //  guna2TextBox1.Text= fdd.MacAddress;
            if (txtpartyfilter.Text != "")
            {
                guna2TextBox1.Visible = true;
                guna2Button1.Visible = true;
                txtpartyfilter.Visible = false;
                otp.Visible = false;
            }
            else
            {
                MessageBox.Show("Enter Mobile No !");
            }
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            GetMACAddress();
          DateTime startDate = DateTime.Parse(DateTime.Now.Date.ToString());
          DateTime  expdate = startDate.AddDays(30);
            autontification fd = new autontification()
            {
                MobileNo = txtpartyfilter.Text,
                MacAddress = mca.ToString(),
                joingDate = DateTime.Now.Date.ToString(),
                trialend = expdate
            };
            var seeter = client.Set("clientData/" + mca, fd);
            //this.Close();
            // Application.Run(new Dashboard());


            var seeter1 = client.Get("clientData/" + mca);
            autontification fdd = seeter1.ResultAs<autontification>();
            Program.expdate = fdd.trialend;
            
            Dashboard ds = new Dashboard();
            ds.Show();
            this.Hide();




        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpartyfilter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
