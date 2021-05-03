using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using FireSharp.Config;

using FireSharp.Response;
using FireSharp.Interfaces;

using System.Net.NetworkInformation;


namespace sample
{
  
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

  public static string macaddress, macaddrss;

        [STAThread]
       
       

        static void Main()
        {
        Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


           
            //client = new FireSharp.FirebaseClient(ifs);

            System.Net.NetworkInformation.NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            //  Me
            }
            macaddress = sMacAddress;


            SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
            IFirebaseConfig ifs = new FirebaseConfig()
            {

                AuthSecret = "BNccxyAb8l3p4CJZcrCwwB3N6KYw3o5N3fjkG8w8",
                BasePath = "https://inventory-application-76653-default-rtdb.firebaseio.com/"

            };
            IFirebaseClient client;
            try
            {
               
                client = new FireSharp.FirebaseClient(ifs);

           
          
            var seeter = client.Get("clientData/" + macaddress);
            autontification fdd = seeter.ResultAs<autontification>();
                 macaddrss = fdd.MacAddress;
            }
            catch(Exception ew)
            {
               // MessageBox.Show("internet Connection not open"+ew);
            }

            if (macaddress == macaddrss)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(*)  from PasswordCheek ", con);
                int password = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                if (password == 0)
                {
                    Application.Run(new Dashboard());
                }
                else
                {
                    Application.Run(new LoginForm());
                }
            }
            else
            {
                Application.Run(new FirstLogin());
            }
        }
    }
}
