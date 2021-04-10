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
using System.IO;

namespace sample
{
    public partial class Party_Group : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public Party_Group()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
            con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        }

        private void Cleardata()
        {
            txtPartyGroupName.Text = "";
        }

        private void fetchdetails()
        {  
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_PartyGroupSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@PartyGroupID", 0);
            cmd.Parameters.AddWithValue("@AddPartyGroup", txtPartyGroupName.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtable);
            dgvPartyGroup.DataSource = dtable;
            dgvPartyGroup.AllowUserToAddRows = false;
        }

        private void InsertData()
        {
            try
            {
                if (txtPartyGroupName.Text == "")
                {
                    MessageBox.Show("Party Name Requird");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_PartyGroupSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@PartyGroupID", id);
                    cmd.Parameters.AddWithValue("@AddPartyGroup", txtPartyGroupName.Text);
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

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

        private void Party_Group_Load(object sender, EventArgs e)
        {
            txtPartyGroupName.Focus();
            fetchdetails();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                InsertData();
                fetchdetails();
            }
            else
            {
                MessageBox.Show("Same Record Not Insert");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtPartyGroupName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvPartyGroup_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPartyGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            Cleardata();
        }

        private void dgvPartyGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvPartyGroup.SelectedRows[0].Cells["PartyGroupID"].Value.ToString();
            txtPartyGroupName.Text = dgvPartyGroup.SelectedRows[0].Cells["AddPartyGroup"].Value.ToString();
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
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_PartyGroupSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@PartyGroupID", id);
                    cmd.Parameters.AddWithValue("@AddPartyGroup", txtPartyGroupName.Text);
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
        private void btnupdate_Click(object sender, EventArgs e)
        {
            Update1();
            fetchdetails();
            Cleardata();
        }

        public void Delete()
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
                    SqlCommand cmd = new SqlCommand("tbl_PartyGroupSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Delete");
                    cmd.Parameters.AddWithValue("@PartyGroupID", id);
                    cmd.Parameters.AddWithValue("@AddPartyGroup", txtPartyGroupName.Text);

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

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT Delete??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete();
                fetchdetails();
                Cleardata();
            }
        }
        private void btncancel_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fetchdetails();
            }
            else
            {
                string Query = string.Format("select PartyGroupID,AddPartyGroup from tbl_PartyGroup where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' and AddPartyGroup like '%{0}%' or PartyGroupID like '%{0}%' ", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvPartyGroup.DataSource = ds;
                dgvPartyGroup.DataMember = "temp";
            }
        }

        private void txtPartyGroupName_Load(object sender, EventArgs e)
        {

        }

        private void txtPartyGroupName_TextChanged(object sender, EventArgs e)
        {
            //if (txtPartyGroupName.Text != "")
            //{

            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }
            //    //chekpoint = 0;
            //    string Query = String.Format("select AddPartyGroup from tbl_PartyGroup where DeleteData ='1'");
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            //    SDA.Fill(ds, "Temp");
            //    DataTable DT = new DataTable();
            //    SDA.Fill(ds);
            //    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //    {

            //        string partyname = ds.Tables["Temp"].Rows[i]["AddPartyGroup"].ToString();

            //        if (partyname.ToLower().ToString() == txtPartyGroupName.Text.ToLower().ToString())
            //        {
            //            //chekpoint = 1;
            //            MessageBox.Show("This Party Group Name is Already Exist ");
            //            //txtcampanyName.Clear();
            //            txtPartyGroupName.Focus();
            //        }

            //    }
            //}
        }
    }
}
