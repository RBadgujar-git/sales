using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;



namespace sample
{
    class ConnectionString
    {
        public static SqlConnection con = null;

         
        public void createConeection()
        {
            con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
            string id  = "";
          //  SqlCommand cmd;

            con.Open();
        }

    }

}
