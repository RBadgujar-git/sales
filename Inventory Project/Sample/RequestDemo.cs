using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample
{
    public partial class RequestDemo : UserControl
    {
        public RequestDemo()
        {
            InitializeComponent();
        }
       
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public void Insert1()
        {
            try
            {

             
                    
                  //    MemoryStream po = new MemoryStream();
                  //  picCompanyLogo.Image.Save(po, picCompanyLogo.Image.RawFormat);
                  //  byte[] arrImage1 = po.GetBuffer();


                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                //  DataTable dtable = new DataTable();
                      int ID=1;
                   SqlCommand cmd = new SqlCommand("tbl_CompanyMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@CompanyID",ID);
                    cmd.Parameters.AddWithValue("@CompanyName","My Company");
                    cmd.Parameters.AddWithValue("@PhoneNo",txtcontactNo.Text);
                    cmd.Parameters.AddWithValue("@EmailID","Demo123@gmail.com");
                    cmd.Parameters.AddWithValue("@ReferaleCode","5555");
                    cmd.Parameters.AddWithValue("@BusinessType","Distributer");
                    cmd.Parameters.AddWithValue("@Address","India");
                    cmd.Parameters.AddWithValue("@City","India");
                    cmd.Parameters.AddWithValue("@State","India");
                    cmd.Parameters.AddWithValue("@GSTNumber","12AAAAA4561A1Z2");
                    cmd.Parameters.AddWithValue("@OwnerName","Demo User");
                   // cmd.Parameters.Add("@Signature", SqlDbType.Image, arrImage2.Length).Value = arrImage2;
                   // cmd.Parameters.Add("@AddLogo", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                    cmd.Parameters.AddWithValue("@AdditinalFeild1","12345678910");
                    cmd.Parameters.AddWithValue("@AdditinalFeild2","Demo User");
                    cmd.Parameters.AddWithValue("@AdditinalFeild3", "SBIN001234");
                    int num = cmd.ExecuteNonQuery();
                   MessageBox.Show("Insert data Successfully");


                SqlCommand cmd1 = new SqlCommand("Select CompanyID from tbl_CompanyMaster where PhoneNo='"+txtcontactNo.Text+"'",con);
               int CompanyIDD=Convert.ToInt32(cmd1.ExecuteScalar());


                NewCompany.company_id = CompanyIDD.ToString();
              //  MessageBox.Show("Id "+NewCompany.company_id);

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {


            if (txtcontactNo.Text=="")
            {
                MessageBox.Show("Please Enter Mobile No ");

            }
            else
            {
                Insert1();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
