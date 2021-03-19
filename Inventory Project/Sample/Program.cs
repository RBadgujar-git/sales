using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Data.SqlClient;
namespace sample
{
   
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
      
        static void Main()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*)  from PasswordCheek  ", con);
          string  password = cmd.ExecuteScalar().ToString();
          //  MessageBox.Show("daata "+password);
            if (password == 0.ToString())
            {

                Application.Run(new Dashboard());
                // Application.Run(new CompanyMaste());
            }
            else
            {
                Application.Run(new LoginForm());

            }
            con.Close();

        }
    }
}
