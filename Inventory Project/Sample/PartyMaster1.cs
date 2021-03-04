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
            string selectquery = string.Format("Select * from tbl_PartyMaste");
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
            cmd.Parameters.AddWithValue("@Action", "Select");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvParty.DataSource = dtable;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertData();
            fetchdetails();
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
            fetchdetails();
            fetchgroup();
        }
 
        private void dgvParty_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvParty.Rows[e.RowIndex].Cells["PartiesID"].Value.ToString();
            txtPartyname.Text = dgvParty.Rows[e.RowIndex].Cells["PartyName"].Value.ToString();
            txtContactNo.Text = dgvParty.Rows[e.RowIndex].Cells["ContactNo"].Value.ToString();
            txtBillingAdd.Text = dgvParty.Rows[e.RowIndex].Cells["BillingAddress"].Value.ToString();
            txtEmailID.Text = dgvParty.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
            txtGSTType.Text = dgvParty.Rows[e.RowIndex].Cells["GSTType"].Value.ToString();
            txtState.Text = dgvParty.Rows[e.RowIndex].Cells["State"].Value.ToString();
            txtOpeningBal.Text = dgvParty.Rows[e.RowIndex].Cells["OpeningBal"].Value.ToString();
            dtpDate.Text = dgvParty.Rows[e.RowIndex].Cells["AsOfDate"].Value.ToString();
            txtAddRemainder.Text = dgvParty.Rows[e.RowIndex].Cells["AddRemainder"].Value.ToString();
            txtPartyType.Text = dgvParty.Rows[e.RowIndex].Cells["PartyType"].Value.ToString();
            txtShippingAdd.Text = dgvParty.Rows[e.RowIndex].Cells["ShippingAddress"].Value.ToString();
            comboBox1.Text = dgvParty.Rows[e.RowIndex].Cells["PartyGroup"].Value.ToString();
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
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
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
                    string SelectQuery = string.Format("select AddPartyGroup from tbl_PartyGroup group by AddPartyGroup");
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
    }
}
