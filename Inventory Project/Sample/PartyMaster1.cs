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
    public partial class PartyMaster1 : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public PartyMaster1()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }
        public void Binddata()
        {
            con.Open();
            string selectquery = string.Format("Select * from tbl_PartyMaste where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(selectquery, con);
            sda.Fill(ds, "temp");
            DataTable dt = new DataTable();
            sda.Fill(ds);
            con.Close();
        }

        private void Cleardata()
        {
            txtPartyname.Text = "";
            txtBillingAdd.Text = "";
            txtContactNo.Text = "";
            txtEmailID.Text = "";
            txtGSTType.Text = "";
            txtPartyType.Text = "";
            txtState.Text = "";
            txtOpeningBal.Text = "";
            txtAddRemainder.Text = "";
            txtShippingAdd.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_PartyMasterSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartiesID", 0);
            cmd.Parameters.AddWithValue("@PartyName", txtPartyname.Text);
            cmd.Parameters.AddWithValue("@ContactNo", txtBillingAdd.Text);
            cmd.Parameters.AddWithValue("@BillingAddress", txtContactNo.Text);
            cmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text);
            cmd.Parameters.AddWithValue("@GSTType", txtGSTType.Text);
            cmd.Parameters.AddWithValue("@State", txtState.Text);
            cmd.Parameters.AddWithValue("@OpeningBal", txtOpeningBal.Text);
            cmd.Parameters.AddWithValue("@AsOfDate", dtpDate.Value);
            cmd.Parameters.AddWithValue("@AddRemainder", txtAddRemainder.Text);
            cmd.Parameters.AddWithValue("@PartyType", txtPartyType.Text);
            cmd.Parameters.AddWithValue("@ShippingAddress", txtShippingAdd.Text);
            cmd.Parameters.AddWithValue("@PartyGroup", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Type", comboBox2.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

            cmd.Parameters.AddWithValue("@Action", "Select");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvParty.DataSource = dtable;
            dgvParty.AllowUserToAddRows = false;
        }

        private void InsertData()
        {
            try
            {
                if (txtPartyname.Text == "")
                {
                    MessageBox.Show("Party Name Requird");
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("tbl_PartyMasterSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@PartiesID", id);
                cmd.Parameters.AddWithValue("@PartyName", txtPartyname.Text);
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@BillingAddress", txtBillingAdd.Text);
                cmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@GSTType", txtGSTType.Text);
                cmd.Parameters.AddWithValue("@State", txtState.Text);
                cmd.Parameters.AddWithValue("@OpeningBal", txtOpeningBal.Text);
                cmd.Parameters.AddWithValue("@AsOfDate", dtpDate.Text);
                cmd.Parameters.AddWithValue("@AddRemainder", txtAddRemainder.Text);
                cmd.Parameters.AddWithValue("@PartyType", txtPartyType.Text);
                cmd.Parameters.AddWithValue("@ShippingAddress", txtShippingAdd.Text);
                cmd.Parameters.AddWithValue("@PartyGroup", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Type", comboBox2.Text);

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
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }
        public int veryfi = 0;

        public void validdata()
        {
            if (txtPartyname.Text == "")
            {
                MessageBox.Show("Party Name Is Required");
                txtPartyname.Focus();

            }
            else if (txtBillingAdd.Text == "")
            {
                MessageBox.Show("Billing Address Is Required");
                txtBillingAdd.Focus();

            }
            else if (txtContactNo.Text == "")
            {
                MessageBox.Show("Contact No Is Required");
                txtContactNo.Focus();
            }
            else if (txtEmailID.Text == "")
            {
                MessageBox.Show("Email ID Is Required");
                txtEmailID.Focus();
            }
            else if (txtGSTType.Text == "")
            {
                MessageBox.Show("GST No Is Required");
                txtGSTType.Focus();
            }
            else if (txtPartyType.Text == "")
            {
                MessageBox.Show("Party Type Is Requried");
                txtPartyType.Focus();
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Party Group Is Requried");
                comboBox1.Focus();
            }
            else if (txtState.Text == "")
            {
                MessageBox.Show("State Is Requried");
                txtState.Focus();
            }
            else if (txtOpeningBal.Text == "")
            {
                MessageBox.Show("Opening Balance Is Requried");
                txtOpeningBal.Focus();
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Costomer Type Is Requried");
                comboBox2.Focus();
            }
        
            else
            {
                veryfi = 1;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            validdata();
            if (veryfi == 1)
            {
                InsertData();
                fetchdetails();
            }
        }
        private void hidedata()
        {
            dgvParty.Columns["ShippingAddress"].Visible = false;
        }

        private void Update1()
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
                    SqlCommand cmd = new SqlCommand("tbl_PartyMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@PartiesID", id);
                    cmd.Parameters.AddWithValue("@PartyName", txtPartyname.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@BillingAddress", txtBillingAdd.Text);
                    cmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text);
                    cmd.Parameters.AddWithValue("@GSTType", txtGSTType.Text);
                    cmd.Parameters.AddWithValue("@State", txtState.Text);
                    cmd.Parameters.AddWithValue("@OpeningBal", txtOpeningBal.Text);
                    cmd.Parameters.AddWithValue("@AsOfDate", dtpDate.Text);
                    cmd.Parameters.AddWithValue("@AddRemainder", txtAddRemainder.Text);
                    cmd.Parameters.AddWithValue("@PartyType", txtPartyType.Text);
                    cmd.Parameters.AddWithValue("@ShippingAddress", txtShippingAdd.Text);
                    cmd.Parameters.AddWithValue("@PartyGroup", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Type", comboBox2.Text);
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


        private void Update_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("tbl_PartyMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Delete");
                    cmd.Parameters.AddWithValue("@PartiesID", id);
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

        private void Delete_Click(object sender, EventArgs e)
        {
            Delete1();
            fetchdetails();
            Cleardata();
        }

        private void PartyMaster1_Load(object sender, EventArgs e)
        {
            txtPartyname.Focus();
            fetchdetails();
            fetchgroup();
            hidedata();
        }

        private void dgvParty_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvParty.Rows[e.RowIndex].Cells["PartiesID"].Value.ToString();
            txtPartyname.Text = dgvParty.Rows[e.RowIndex].Cells["PartyName"].Value.ToString();
            txtContactNo.Text = dgvParty.Rows[e.RowIndex].Cells["ContactNo"].Value.ToString();
            txtBillingAdd.Text = dgvParty.Rows[e.RowIndex].Cells["BillingAddress"].Value.ToString();
            txtEmailID.Text = dgvParty.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
            txtGSTType.Text = dgvParty.Rows[e.RowIndex].Cells["GSTNo"].Value.ToString();
            txtState.Text = dgvParty.Rows[e.RowIndex].Cells["State"].Value.ToString();
            txtOpeningBal.Text = dgvParty.Rows[e.RowIndex].Cells["OpeningBal"].Value.ToString();
            dtpDate.Text = dgvParty.Rows[e.RowIndex].Cells["AsOfDate"].Value.ToString();
            txtAddRemainder.Text = dgvParty.Rows[e.RowIndex].Cells["AddRemainder"].Value.ToString();
            txtPartyType.Text = dgvParty.Rows[e.RowIndex].Cells["PartyType"].Value.ToString();
            txtShippingAdd.Text = dgvParty.Rows[e.RowIndex].Cells["ShippingAddress"].Value.ToString();
            comboBox1.Text = dgvParty.Rows[e.RowIndex].Cells["PartyGroup"].Value.ToString();
            comboBox2.Text = dgvParty.Rows[e.RowIndex].Cells["Type"].Value.ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPartyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)|| e.KeyChar == (char)Keys.Back);
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
            string email = txtEmailID.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {

            }
            else
            {
                MessageBox.Show(" Invalid Email Address");
                txtEmailID.Text = "";
                txtEmailID.Focus();
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
        private void ValidateGSTNo()
        {
            string gst = txtGSTType.Text;
            Regex regex = new Regex(@"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$");
            Match match = regex.Match(gst);
            if (match.Success)
            {

            }
            else
            {
                MessageBox.Show(" Invalid GST Number");
                txtGSTType.Text = "";
                txtGSTType.Focus();
            }
        }
        private void txtGSTType_Leave(object sender, EventArgs e)
        {
            if (txtGSTType.Text == "")
            {
            }
            else
            {
                ValidateGSTNo();
            }
        }

        private void txtPartyType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Clear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }
        private void fetchgroup()
        {
            if (comboBox1.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select AddPartyGroup from tbl_PartyGroup where Company_ID='"+NewCompany.company_id+ "' and DeleteData='1' group by AddPartyGroup");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        comboBox1.Items.Add(ds.Tables["Temp"].Rows[i]["AddPartyGroup"].ToString());
                    }

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtState_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void dgvParty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fetchdetails();
            }
            else
            {
                string Query = string.Format("select PartiesID,PartyName,ContactNo,BillingAddress,EmailID,GSTType as GSTNo,State,OpeningBal,AsOfDate,AddRemainder,PartyType,ShippingAddress,PartyGroup,PaidStatus,Type from tbl_PartyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and PartyName like '%{0}%' or PartiesID like '%{0}%'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvParty.DataSource = ds;
                dgvParty.DataMember = "temp";
            }
        }

        private void radTopay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
