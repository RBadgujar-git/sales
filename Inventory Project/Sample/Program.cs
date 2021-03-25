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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                     
                con.Open();
           
            SqlCommand cmd = new SqlCommand("Select count(*)  from PasswordCheek   ", con);
           int  password = Convert.ToInt32(cmd.ExecuteScalar());          
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
    }
}
