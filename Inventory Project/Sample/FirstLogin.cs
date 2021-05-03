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
            var resu = client.Get("clientData/"+ txtpartyfilter.Text);
            autontification fd = resu.ResultAs<autontification>();
            string mac = fd.MacAddress;
            MessageBox.Show(" mac address"+mac);
            guna2TextBox1.Visible = true;



        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            GetMACAddress();
            autontification fd = new autontification()
            {
                MobileNo = txtpartyfilter.Text,
                MacAddress = mca.ToString()
            };
            var seeter = client.Set("clientData/" + txtpartyfilter.Text, fd);
           
        }
    }
}
