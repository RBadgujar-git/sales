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
            //SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
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
            picSignature.Image = Properties.Resources.No_Image_Available;
            picCompanyLogo.Image = Properties.Resources.No_Image_Available;
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
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtContactNo.Text);
            cmd.Parameters.AddWithValue("@EmailID", txtemail.Text);
            cmd.Parameters.AddWithValue("@ReferaleCode", txtreferralcode.Text);
            cmd.Parameters.AddWithValue("@BusinessType", txtbusinesstype.Text);
            cmd.Parameters.AddWithValue("@OwnerName", ownerName.Text);
            cmd.Parameters.AddWithValue("@GSTNumber", txtGSTNo.Text);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@State", cmbState.Text);          
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
            dgvComapnyMaster.AllowUserToAddRows = false;
        }
        public int verify = 0;

        public void validfild()
        {
            if (txtcampanyName.Text == "")
            {
                MessageBox.Show("Company Name Is Required ");
                txtcampanyName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Address Is Required ");
                txtAddress.Focus();
            }
            else if (txtContactNo.Text == "")
            {
                MessageBox.Show(" Contact No. Is Required ");
                txtContactNo.Focus();
            }
            else if (txtemail.Text == "")
            {
                MessageBox.Show("Email Id Is Required ");
                txtemail.Focus();
            }
            else if (txtbusinesstype.Text == "")
            {
                MessageBox.Show("Bussness Type Is Required ");
                txtbusinesstype.Focus();
            }
            else if (txtGSTNo.Text == "")
            {
                MessageBox.Show("GST NO. Is Required ");
                txtGSTNo.Focus();
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("City Is Required ");
                txtGSTNo.Focus();
            }
            else if (ownerName.Text == "")
            {
                MessageBox.Show("Owner Name Is Required ");
                ownerName.Focus();
            }
            else if (cmbState.Text == "")
            {
                MessageBox.Show(" Please Select State ");
                //txtCity.Focus();
            }
            else if (txtBankName.Text == "")
            {
                MessageBox.Show("Bank Name Is Required ");
                //txtCity.Focus();
            }
            else if (txtAccountNo.Text == "")
            {
                MessageBox.Show("Account No Is Requried");
                txtAccountNo.Focus();
            }
            else if (txtIFSCcode.Text == "")
            {
                MessageBox.Show("IFSC Code Is Required ");
                txtIFSCcode.Focus();
            }

            else
            {
                verify = 1;

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

        public void Seeting()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmdn = new SqlCommand("Select Max(CompanyID) from tbl_CompanyMaster ",con);
            string id = cmdn.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("insert into Setting_Table(Company_ID)values("+id+")", con);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("insert into TransactionTableSeeting(Company_ID)values(" + id + ")", con);
            cmd.ExecuteNonQuery();

        }
    private void btnsave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                validfild();
                if (verify == 1)
                {
                    Insert1();
                    txtcampanyName.Focus();
                    Seeting();
                    fetchdetails();
                }
            }
            else
            {
                MessageBox.Show("No Permission");
            }
        }


        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    picSignature.Image.Save(ms, picSignature.Image.RawFormat);
                    byte[] arrImage2 = ms.GetBuffer();

                    MemoryStream po = new MemoryStream();
                    picCompanyLogo.Image.Save(po, picCompanyLogo.Image.RawFormat);
                    byte[] arrImage1 = po.GetBuffer();
                    DataTable dt = new DataTable();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

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
            txtcampanyName.Focus();
            fetchdetails();


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
            if (MessageBox.Show("DO YOU WANT Delete??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete1();
                fetchdetails();
            }
            else
            {

            }
        }

        private void CompanyMaste_Load(object sender, EventArgs e)
        {
            txtcampanyName.Focus();
            fetchdetails();
            hidedata();
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
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
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
                txtemail.Focus();
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
                txtGSTNo.Focus();
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
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        public void hidedata()
        {
          
            dgvComapnyMaster.Columns["Signature"].Visible = false;
            dgvComapnyMaster.Columns["AddLogo"].Visible = false;
            dgvComapnyMaster.Columns["BankName"].Visible = false;
            dgvComapnyMaster.Columns["AccountNo"].Visible = false;
            dgvComapnyMaster.Columns["IFSC_Code"].Visible = false;
        }
        private void dgvComapnyMaster_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvComapnyMaster.Rows[e.RowIndex].Cells["CompanyID"].Value.ToString();
            txtcampanyName.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
            txtAddress.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            txtContactNo.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["ContactNo"].Value.ToString();
            txtemail.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
            txtreferralcode.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["ReferaleCode"].Value.ToString();
            txtbusinesstype.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["BusinessType"].Value.ToString();
            ownerName.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["OwnerName"].Value.ToString();
            txtGSTNo.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["GSTNumber"].Value.ToString();
            txtCity.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["City"].Value.ToString();
            cmbState.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["State"].Value.ToString();
       
      

            SqlCommand cmd = new SqlCommand("select Signature from tbl_CompanyMaster where DeleteData='1'", con);
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

            SqlCommand cmd2 = new SqlCommand("select AddLogo from tbl_CompanyMaster where DeleteData='1'", con);
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

            txtBankName.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["BankName"].Value.ToString();
            txtAccountNo.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["AccountNo"].Value.ToString();
            txtIFSCcode.Text = dgvComapnyMaster.Rows[e.RowIndex].Cells["IFSC_Code"].Value.ToString();

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
                txtIFSCcode.Focus();
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
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }
        private void txtIFSCcode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvComapnyMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtBankName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBankName_KeyUp(object sender, EventArgs e)
        {



        }

        private void txtBankName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //don't add text if it's empty
                if (txtBankName.Text != "")
                {
                    for (int i = 0; i < txtBankName.Items.Count; i++)
                    {
                        //exit event if text already exists
                        if (txtBankName.Text == txtBankName.Items[i].ToString())
                        {
                            return;
                        }
                    }
                    //add item to comboBox1
                    txtBankName.Items.Add(txtBankName.Text);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnminimize_Resize(object sender, EventArgs e)
        {

        }


        private void btnminimize_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click_2(object sender, EventArgs e)
        {
            //  CompanyMaste cm = new CompanyMaste();
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtcampanyName_TextChanged(object sender, EventArgs e)
        {


            if (txtcampanyName.Text != "")
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //chekpoint = 0;
                string Query = String.Format("select CompanyName from tbl_CompanyMaster where DeleteData ='1'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {

                    string companyname = ds.Tables["Temp"].Rows[i]["CompanyName"].ToString();

                    if (companyname.ToLower().ToString() == txtcampanyName.Text.ToLower().ToString())
                    {
                        //chekpoint = 1;
                        MessageBox.Show("This Company Name is already Exist ");
                        txtcampanyName.Clear();
                        txtcampanyName.Focus();
                    }

                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void txtserach_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fetchdetails();
                hidedata();
            }
            else
            {
                string Query = string.Format("select CompanyID,CompanyName ,Address,PhoneNo as ContactNo,EmailID ,ReferaleCode ,BusinessType ,OwnerName  ,GSTNumber ,City ,State from tbl_CompanyMaster where DeleteData = '1' and CompanyName like '%{0}%' or CompanyID like '%{0}%'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvComapnyMaster.DataSource = ds;
                dgvComapnyMaster.DataMember = "temp";
            }
        }

        private void txtBankName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
    
  
       
