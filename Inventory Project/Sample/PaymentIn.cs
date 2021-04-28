using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class PaymentIn : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public PaymentIn()
        {
            InitializeComponent();
            // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void PaymentIn_Load(object sender, EventArgs e)
        {
            fetchcustomername();
            fetchdetails();
        }

        private void Cleardata()
        {
            cmbPartyName.Text = "";
            cmbPaymentType.Text = "";
            txtDescription.Text = "";
            txtReceiptNo.Text = "";
            txtReceived.Text = "0";
            txtDiscount.Text = "0";
            txtTotal.Text = "0";
            PictureBox1.Image = Properties.Resources.No_Image_Available;
            comboBox1.Text = "";
        }

        private void fetchcustomername()
        {
            if (cmbPartyName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='"+NewCompany.company_id+ "' and DeleteData='1' group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbPartyName.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void fetchdetails()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_PaymentInSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@CustomerName", cmbPartyName.Text);
            cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
            cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text);
            cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@ReceivedAmount", txtReceived.Text);
            cmd.Parameters.AddWithValue("@UnusedAmount", txtDiscount.Text);
            cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
            cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
            cmd.Parameters.AddWithValue("@TableName", textBox1.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlParameter sqlpara = new SqlParameter("@image", SqlDbType.Image);
            sqlpara.Value = DBNull.Value;
            cmd.Parameters.Add(sqlpara);

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);                      
            dgvPaymentIn.DataSource = dtable;
            dgvPaymentIn.AllowUserToAddRows = false;
        }


        private void InsertData()
        {          
                try
                {
                        MemoryStream ms = new MemoryStream();
                        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat);
                        byte[] arrImage2 = ms.GetBuffer();

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_PaymentInSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Insert");
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@CustomerName", cmbPartyName.Text);
                        cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                        cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text);
                        cmd.Parameters.AddWithValue("@Date", dtpdate.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@ReceivedAmount", txtReceived.Text);
                        cmd.Parameters.AddWithValue("@UnusedAmount", txtDiscount.Text);
                        cmd.Parameters.Add("@image", SqlDbType.Image, arrImage2.Length).Value = arrImage2;
                        cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                        cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@TableName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                     
                        int num = cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Data Save Successfully");
                    insrtparty();
                    balance();
                    Cleardata();

                        }
                        else
                        {
                            MessageBox.Show("Please try again");
                        }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);
                }

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
                  
                    MemoryStream po = new MemoryStream();
                    PictureBox1.Image.Save(po, PictureBox1.Image.RawFormat);
                    byte[] arrImage1 = po.GetBuffer();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_PaymentInSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@CustomerName", cmbPartyName.Text);
                    cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                    cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNo.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpdate.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@ReceivedAmount", txtReceived.Text);
                    cmd.Parameters.AddWithValue("@UnusedAmount", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@Status", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@TableName", textBox1.Text);
                    cmd.Parameters.Add("@image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;

                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Data Updated Successfully");
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtReceived.Text != "" && txtDiscount.Text != "" && txtTotal.Text != "")
                {
                    float receive_cash = 0, amt = 0, TP = 0, GT = 0;
                    receive_cash = float.Parse(txtReceived.Text.ToString());
                    amt = float.Parse(txtDiscount.Text.ToString());
                    TP = amt + receive_cash;
                    txtTotal.Text = TP.ToString();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }


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
                    SqlCommand cmd = new SqlCommand("tbl_PaymentInSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Delete");
                    cmd.Parameters.AddWithValue("@ID", id);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Data Deleted Successfully");
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


        private void button2_Click(object sender, EventArgs e)
        {
           
                Update1();
               fetchdetails();
                id = "";
                  
        }
        public int verify = 0;

        public void validfild()
        {
            if (cmbPartyName.Text == "")
            {
                MessageBox.Show("Party Name Is Requried ");
                cmbPartyName.Focus();
            }
            else if (cmbPaymentType.Text == "")
            {
                MessageBox.Show("Payment Type Is Requried ");
                cmbPaymentType.Focus();
            }
            else if (txtReceiptNo.Text == "")
            {
                MessageBox.Show("Receipt No. Is Requried ");
                txtReceiptNo.Focus();
            }
            
            else if (dtpdate.Text == "")
            {
                MessageBox.Show("Date Is Requried ");
                dtpdate.Focus();
            }
            else if (txtReceived.Text == "")
            {
                MessageBox.Show("Received amount Is Requried ");
                txtReceived.Focus();
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Status Is Requried ");
                comboBox1.Focus();
            }         
            else
            {
                verify = 1;

            }
        }
        public int cp;
        public void insrtparty()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' group by PartyName ");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {
                    string itemname = ds.Tables["Temp"].Rows[i]["PartyName"].ToString();
                    if (itemname.ToString() == cmbPartyName.Text.ToString())
                    {
                        cp = 1;
                    }
                }

                if (cp != 1)
                {
                  
                    string query = string.Format("insert into tbl_PartyMaster(PartyName,Company_ID,OpeningBal) Values ('" + cmbPartyName.Text + "'," + NewCompany.company_id + ",0)");

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                validfild();
                if (verify == 1)
                {
                    InsertData();
                    //insrtparty();
                    //balance();
                    fetchdetails();
                }
            }
            else
            {
                MessageBox.Show("Same Record Not Insert");
            }
        }
        public void balance()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select OpeningBal from tbl_PartyMaster where PartyName='" + cmbPartyName.Text + "' and Company_ID=" + NewCompany.company_id + " ", con);
                float prives = Convert.ToInt32(cmd.ExecuteScalar());
                float remaning = float.Parse(txtTotal.Text);
                float total = prives + remaning;
                SqlCommand cmd1 = new SqlCommand("UPDATE tbl_PartyMaster SET OpeningBal=" + total + " where PartyName='" + cmbPartyName.Text + "' and Company_ID=" + NewCompany.company_id + "", con);
                cmd1.ExecuteNonQuery();

            }
            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Settings BA = new Settings();
            BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT Delete??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete1();
                fetchdetails();
                Cleardata();
                id = "";
            }
        }

        private void dgvPaymentIn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentIn_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.F) || (e.Control && e.KeyCode == Keys.S))
            {

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            id = "";
            Cleardata();
           
        }
        byte[] arrImage1 = null;
        private void PictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvPaymentIn_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dgvPaymentIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtReceiptNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Clear_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
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
                        PictureBox1.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                fetchdetails();
              
            }
            else
            {
                string Query = string.Format("select ID,CustomerName as PartyName,PaymentType,ReceiptNo,Date,Description,ReceivedAmount,UnusedAmount,Total,Status,image from tbl_PaymentIn where Company_ID='" + NewCompany.company_id + "' and CustomerName like '%{0}%' or ID like '%{0}%' and DeleteData = '1'", textBox2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPaymentIn.DataSource = ds;
                dgvPaymentIn.DataMember = "temp";
            }
        }

        private void dgvPaymentIn_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvPaymentIn.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            cmbPartyName.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["PartyName"].Value.ToString();
            cmbPaymentType.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["PaymentType"].Value.ToString();
            txtReceiptNo.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["ReceiptNo"].Value.ToString();
            dtpdate.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["Date"].Value.ToString();
            txtDescription.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            txtReceived.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["ReceivedAmount"].Value.ToString();
            txtDiscount.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["UnusedAmount"].Value.ToString();
            txtTotal.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["Total"].Value.ToString();
            comboBox1.Text = dgvPaymentIn.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            SqlCommand cmd2 = new SqlCommand("select image from tbl_PaymentIn where DeleteData='1' and Company_ID = '" + NewCompany.company_id + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            DataSet dds = new DataSet();
            sda.Fill(dds);
            if (dds.Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])dds.Tables[0].Rows[e.RowIndex]["image"]);
                ms.Seek(0, SeekOrigin.Begin);
                PictureBox1.Image = Image.FromStream(ms);
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}


