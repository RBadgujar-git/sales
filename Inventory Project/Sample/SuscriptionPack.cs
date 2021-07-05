using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class SuscriptionPack : UserControl
    {
        public SuscriptionPack()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifs = new FirebaseConfig()
        {

            AuthSecret = "BNccxyAb8l3p4CJZcrCwwB3N6KYw3o5N3fjkG8w8",
            BasePath = "https://inventory-application-76653-default-rtdb.firebaseio.com/"

        };
        IFirebaseClient client;

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifs);
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
        public string joingdate,mobileno;

       
    
   private void button1_Click(object sender, EventArgs e)
        {
             GetMACAddress();
            var seeter = client.Get("clientData/" + mca);
            autontification fdd = seeter.ResultAs<autontification>();
            //macaddrss = fdd.MacAddress;
            joingdate = fdd.joingDate;
            mobileno = fdd.MobileNo;
          //  expdate = fdd.trialend;

            DateTime startDate = DateTime.Parse(DateTime.Now.Date.ToString());
            DateTime expdate = startDate.AddDays(365);
            autontification fd = new autontification()
            {
                MobileNo = mobileno,
                MacAddress = mca.ToString(),
                joingDate = joingdate,
                trialend = expdate.Date
              //  trialend = expdate.Date
            };
            var seeter1 = client.Update("clientData/" + mca, fd);
            Program.expdate = expdate;
            MessageBox.Show("Your Subscription are start ");

        }
    }
}
