using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace sample
{
    public partial class NewCompany : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
      //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public static string company_id;
        public NewCompany()
        {
            InitializeComponent();
            con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        }
        private void ClearData()
        {
            cmbCompanyName.Text = "";
            txtContactNo.Text = "";
            txtEmailID.Text = "";
            txtReferralCode.Text = "";
            guna2CirclePictureBox1.Image = null;
        }


        private void fetchdetails()
        {
            con.Open();
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("addcompany", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@CompanyName", "");
            cmd.Parameters.AddWithValue("@ContactNo", "");
            cmd.Parameters.AddWithValue("@EmailId", "");
            cmd.Parameters.AddWithValue("@ReferralCode", "");
            SqlParameter sqlpara = new SqlParameter("@Image1", SqlDbType.Image);
            sqlpara.Value = DBNull.Value;
            cmd.Parameters.Add(sqlpara);
            cmd.Parameters.AddWithValue("@Action", "Select");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            con.Close();
        } 
        private void InsertData()
        {        
              
            try
            {
                if (cmbCompanyName.Text == "")
                {
                    MessageBox.Show("Company Name Is Requried");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
                    byte[] arrImage1 = ms.GetBuffer();
                   
                        con.Open();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("addcompany", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@CompanyName", cmbCompanyName.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@EmailId", txtEmailID.Text);
                    cmd.Parameters.AddWithValue("@ReferralCode", txtReferralCode.Text);
                    cmd.Parameters.Add("@Image1", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert data Successfully");
                    con.Close();
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            InsertData();
            ClearData();
        }  

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Enter Number");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ValidateEmail()
        {
           string email = txtEmailID.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") ;
            Match match = regex.Match(email);
            if (match.Success)
            {
                
            }
            else
            {
               MessageBox.Show(" Invalid Email Address");
                txtEmailID.Text = "";
            }
        }

        private void txtEmailID_Leave(object sender, EventArgs e)
        {
            if (txtEmailID.Text == "")
            {
            }
            else
            {
                ValidateEmail();
            }
        }

        byte[] arrImage1;
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int count = 1;
                foreach (String file in openFileDialog1.FileNames)
                {
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);

                    if (count == 1)
                    {
                        guna2CirclePictureBox1.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }

        private void txtCompanyName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
                MessageBox.Show("Enter Character");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void NewCompany_Load(object sender, EventArgs e)
        {
            fetchCampanyame();           
        }

       
        private void fetchCampanyame()
        {
            if (cmbCompanyName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select CompanyName from tbl_CompanyMaster group by CompanyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbCompanyName.Items.Add(ds.Tables["Temp"].Rows[i]["CompanyName"].ToString());
                   }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select CompanyID,PhoneNo,EmailID,ReferaleCode from tbl_CompanyMaster where (CompanyName='{0}') GROUP BY CompanyID,PhoneNo,EmailID,ReferaleCode", cmbCompanyName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   company_id = dr["CompanyID"].ToString();
                    txtContactNo.Text = dr["PhoneNo"].ToString();
                    txtEmailID.Text = dr["EmailID"].ToString();
                    txtReferralCode.Text = dr["ReferaleCode"].ToString();

                    dr.Close();

                    SqlCommand cmd2 = new SqlCommand("select AddLogo from tbl_CompanyMaster", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataSet dds = new DataSet();
                    sda.Fill(dds);
                    if (dds.Tables[0].Rows.Count > 0)
                    {
                        MemoryStream ms = new MemoryStream((byte[])dds.Tables[0].Rows[0]["AddLogo"]);
                        ms.Seek(0, SeekOrigin.Begin);
                        guna2CirclePictureBox1.Image = Image.FromStream(ms);
                        guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               con.Close();
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmailID_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
