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
using System.Text.RegularExpressions;
using System.Configuration;
using System.IO;


namespace sample
{
    public partial class CompanyMaste : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public CompanyMaste()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
            // con = new SqlConnection("Data Source=DESKTOP-UK7P4M8\\SQLEXPRESS;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void Cleardata()
        {
            txtcampanyName.Text = "";
            txtContactNo.Text = "";
            txtemail.Text = "";
            txtreferralcode.Text = "";
            txtbusinesstype.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            cmbState.Text = "";
            txtGSTNo.Text = "";
            ownerName.Text = "";
            picSignature.Image = null;
            picCompanyLogo.Image = null;
            txtBankName.Text = "";
            txtAccountNo.Text = "";
            txtIFSCcode.Text = "";

        }
        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_CompanyMasterSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@CompanyID", 0);
            cmd.Parameters.AddWithValue("@CompanyName", txtcampanyName.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtContactNo.Text);
            cmd.Parameters.AddWithValue("@EmailID", txtemail.Text);
            cmd.Parameters.AddWithValue("@ReferaleCode", txtreferralcode.Text);
            cmd.Parameters.AddWithValue("@BusinessType", txtbusinesstype.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@State", cmbState.Text);
            cmd.Parameters.AddWithValue("@GSTNumber", txtGSTNo.Text);
            cmd.Parameters.AddWithValue("@OwnerName", ownerName.Text);
            SqlParameter sqlpara = new SqlParameter("@Signature", SqlDbType.Image);
            sqlpara.Value = DBNull.Value;
            cmd.Parameters.Add(sqlpara);
            SqlParameter sqlpar = new SqlParameter("@AddLogo", SqlDbType.Image);
            sqlpar.Value = DBNull.Value;
            cmd.Parameters.Add(sqlpar);
            cmd.Parameters.AddWithValue("@AdditinalFeild1", txtBankName.Text);
            cmd.Parameters.AddWithValue("@AdditinalFeild2", txtAccountNo.Text);
            cmd.Parameters.AddWithValue("@AdditinalFeild3", txtIFSCcode.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtable);
            dgvComapnyMaster.DataSource = dtable;
        }


        public void validfild()
        {
            if (txtcampanyName.Text == "")
            {
                MessageBox.Show("Please Insert Name ");
                txtcampanyName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please Insert Address !");
                txtAddress.Focus();
            }
            else if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please Insert Contact No ");
                txtContactNo.Focus();
            }
            else if (txtemail.Text == "")
            {
                MessageBox.Show("Please Insert Email Id ");
                txtemail.Focus();
            }
            else if (txtbusinesstype.Text == "")
            {
                MessageBox.Show("Please Insert Bussness Type  ");
                txtbusinesstype.Focus();
            }
            else if (txtGSTNo.Text == "")
            {
                MessageBox.Show("Please Insert GST NO");
               txtGSTNo.Focus();
            }
            else if (ownerName.Text == "")
            {
                MessageBox.Show("Please Insert Owner Name ");
                ownerName.Focus();
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Please Insert City ");
               txtCity.Focus();
            }
            else if (string.IsNullOrEmpty(cmbState.SelectedText))
            {
                MessageBox.Show("Please Select State !");
                //txtCity.Focus();
            }
            else if (string.IsNullOrEmpty(txtBankName.SelectedText))
            {
                MessageBox.Show("Please Select Bank Name !");
                //txtCity.Focus();
            }
            else if (txtAccountNo.Text=="")
            {
                MessageBox.Show("Please Insert Account No !");
                txtAccountNo.Focus();
            }
            else if (txtIFSCcode.Text == "")
            {
                MessageBox.Show("Please Insert Account  IFSC Code!");
               txtIFSCcode.Focus();
            }
           

        }
        public void Insert1()
        {
            try
            {
             
                if (txtcampanyName.Text == "")
                {
                    MessageBox.Show("Company Name Is Requried");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    picSignature.Image.Save(ms, picSignature.Image.RawFormat);
                    byte[] arrImage2 = ms.GetBuffer();

                    MemoryStream po = new MemoryStream();
                    picCompanyLogo.Image.Save(po, picCompanyLogo.Image.RawFormat);
                    byte[] arrImage1 = po.GetBuffer();


                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_CompanyMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@CompanyID", id);
                    cmd.Parameters.AddWithValue("@CompanyName", txtcampanyName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNo", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@EmailID", txtemail.Text);
                    cmd.Parameters.AddWithValue("@ReferaleCode", txtreferralcode.Text);
                    cmd.Parameters.AddWithValue("@BusinessType", txtbusinesstype.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@State", cmbState.Text);
                    cmd.Parameters.AddWithValue("@GSTNumber", txtGSTNo.Text);
                    cmd.Parameters.AddWithValue("@OwnerName", ownerName.Text);
                    cmd.Parameters.Add("@Signature", SqlDbType.Image, arrImage2.Length).Value = arrImage2;
                    cmd.Parameters.Add("@AddLogo", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                    cmd.Parameters.AddWithValue("@AdditinalFeild1", txtBankName.Text);
                    cmd.Parameters.AddWithValue("@AdditinalFeild2", txtAccountNo.Text);
                    cmd.Parameters.AddWithValue("@AdditinalFeild3", txtIFSCcode.Text);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Insert data Successfully");
                        Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please try again");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validfild();
            Insert1();
            fetchdetails();
            Cleardata();
        }

        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MemoryStream ms = new MemoryStream();
                    picSignature.Image.Save(ms, picSignature.Image.RawFormat);
                    byte[] arrImage2 = ms.GetBuffer();

                    MemoryStream po = new MemoryStream();
                    picCompanyLogo.Image.Save(po, picCompanyLogo.Image.RawFormat);
                    byte[] arrImage1 = po.GetBuffer();
                    DataTable dt = new DataTable();
                    cmd = new SqlCommand("tbl_CompanyMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@CompanyID", id);
                    cmd.Parameters.AddWithValue("@CompanyName", txtcampanyName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNo", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@EmailID", txtemail.Text);
                    cmd.Parameters.AddWithValue("@ReferaleCode", txtreferralcode.Text);
                    cmd.Parameters.AddWithValue("@BusinessType", txtbusinesstype.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@State", cmbState.Text);
                    cmd.Parameters.AddWithValue("@GSTNumber", txtGSTNo.Text);
                    cmd.Parameters.AddWithValue("@OwnerName", ownerName.Text);
                    cmd.Parameters.Add("@Signature", SqlDbType.Image, arrImage2.Length).Value = arrImage2;
                    cmd.Parameters.Add("@AddLogo", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                    cmd.Parameters.AddWithValue("@AdditinalFeild1", txtBankName.Text);
                    cmd.Parameters.AddWithValue("@AdditinalFeild2", txtAccountNo.Text);
                    cmd.Parameters.AddWithValue("@AdditinalFeild3", txtIFSCcode.Text);

                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Update data Successfully");
                        Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update1();
            fetchdetails();
            Cleardata();
        }

        public void Delete1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    cmd = new SqlCommand("tbl_CompanyMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Delete");
                    cmd.Parameters.AddWithValue("@CompanyID", id);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Delete data Successfully");
                        Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Delete1();
            fetchdetails();
            Cleardata();
        }

        private void CompanyMaste_Load(object sender, EventArgs e)
        {
            fetchdetails();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        byte[] arrImage1 = null;
        private void picCompanyLogo_Click(object sender, EventArgs e)
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
                        picCompanyLogo.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        picCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        picCompanyLogo.Image.Save(ms, picCompanyLogo.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }

        byte[] arrImage2 = null;

        public FormWindowState WindowState { get; private set; }

        private void picSignature_Click(object sender, EventArgs e)
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
                        picSignature.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        picSignature.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        picSignature.Image.Save(ms, picSignature.Image.RawFormat);
                        arrImage2 = ms.GetBuffer();
                    }
                }
            }
        }

        private void txtcampanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ValidateEmail()
        {
            string email = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {

            }
            else
            {
                MessageBox.Show(" Invalid Email Address");
                txtemail.Text = "";
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
            }
            else
            {
                ValidateEmail();
              
            }
        }

        private void ValidateGSTNo()
        {
            string gst = txtGSTNo.Text;
            Regex regex = new Regex(@"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$");
            Match match = regex.Match(gst);
            if (match.Success)
            {

            }
            else
            {
                MessageBox.Show(" Invalid GST Number");
                txtGSTNo.Text = "";
            }
        }
        private void txtGSTNo_Leave(object sender, EventArgs e)
        {
            if (txtGSTNo.Text == "")
            {
            }
            else
            {
                ValidateGSTNo();

            }
        }
        private void ownerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;          
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;       
            }
            else
            {
                e.Handled = false;
            }
        }



        private void dgvComapnyMaster_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id= dgvComapnyMaster.Rows[e.RowIndex].Cells["CompanyID"].Value.ToString();
            txtcampanyName.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
            txtContactNo.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["PhoneNo"].Value.ToString();
            txtemail.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
            txtreferralcode.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["ReferaleCode"].Value.ToString();
            txtbusinesstype.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["BusinessType"].Value.ToString();
            txtAddress.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            txtCity.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["City"].Value.ToString();
            cmbState.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["State"].Value.ToString();
            txtGSTNo.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["GSTNumber"].Value.ToString();
            ownerName.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["OwnerName"].Value.ToString();

            SqlCommand cmd = new SqlCommand("select Signature from tbl_CompanyMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[e.RowIndex]["Signature"]);
                ms.Seek(0, SeekOrigin.Begin);
                picSignature.Image = Image.FromStream(ms);
                picSignature.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            SqlCommand cmd2 = new SqlCommand("select AddLogo from tbl_CompanyMaster", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            DataSet dds = new DataSet();
            sda.Fill(dds);
            if (dds.Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])dds.Tables[0].Rows[e.RowIndex]["AddLogo"]);
                ms.Seek(0, SeekOrigin.Begin);
                picCompanyLogo.Image = Image.FromStream(ms);
                picCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            txtBankName.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["AdditinalFeild1"].Value.ToString();
            txtAccountNo.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["AdditinalFeild2"].Value.ToString();
            txtIFSCcode.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["AdditinalFeild3"].Value.ToString();
        }

        private void txtBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtAccountNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
       private void validateIFSC()
        { 
            string gst = txtIFSCcode.Text;
            Regex regex = new Regex(@"^[A-Za-z]{4}[0-9]{6,7}$");
            Match match = regex.Match(gst);
            if (match.Success)
            {

            }
            else
            {
                MessageBox.Show(" Invalid IFSC Number");
                txtIFSCcode.Text = "";
            }
            
        }

        private void txtIFSCcode_Leave(object sender, EventArgs e)
        {
            if (txtIFSCcode.Text == "")
            {
            }
            else
            {
                validateIFSC();
            }
        }

        private void butnclear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void txtbusinesstype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
       private void txtIFSCcode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {

        }
    }

}
       
