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
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace sample
{
    public partial class Add_Unit : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //  SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public Add_Unit()
        {
            InitializeComponent();
            //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void Add_Unit_Load(object sender, EventArgs e)
        {
            txtAddUnit.Focus();
            
            fetchdetails();
        }
        

        private void cleardata()
        {
            txtAddUnit.Text = "";
            txtSubunit.Text = "";
        }

        private void fetchdetails()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_UnitMasterUnit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@UnitID", 0);
            cmd.Parameters.AddWithValue("@UnitName", txtAddUnit.Text);
            cmd.Parameters.AddWithValue("@SubUnitName", txtSubunit.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
            sqlSda.Fill(dtable);
            dgvAddunit.DataSource = dtable;
            dgvAddunit.AllowUserToAddRows = false;
        }




        int i = 0;

        public FormWindowState WindowState { get; private set; }

        public void Insertdata()
        {
            try
            {
                if (txtAddUnit.Text == "")
                {
                    MessageBox.Show("Unit Name Requird");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_UnitMasterUnit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@UnitID", id);
                    cmd.Parameters.AddWithValue("@UnitName", txtAddUnit.Text);
                    cmd.Parameters.AddWithValue("@SubUnitName", txtSubunit.Text);
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    int num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("Insert data Successfully");
                        cleardata();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                Insertdata();
                fetchdetails();
            }
            else
            {
                MessageBox.Show("Same Record Not Insert");
            }
           
        }

        private void dgvAddunit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvAddunit.SelectedRows[0].Cells["UnitID"].Value.ToString();
            txtAddUnit.Text = dgvAddunit.SelectedRows[0].Cells["UnitName"].Value.ToString();
            txtSubunit.Text = dgvAddunit.SelectedRows[0].Cells["SubunitName"].Value.ToString();



        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
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


                    if (txtSubunit.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (txtAddUnit.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else
                    {
                        DataTable dtable = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_UnitMasterUnit", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@UnitID", id);
                        cmd.Parameters.AddWithValue("@UnitName", txtAddUnit.Text);
                        cmd.Parameters.AddWithValue("@SubUnitName", txtSubunit.Text);

                        int num = cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Update data Successfully");
                            cleardata();
                        }
                        else
                        {
                            MessageBox.Show("Please Select Record");
                        }
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
            cleardata();
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
                    if (txtSubunit.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (txtAddUnit.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_UnitMasterUnit", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Delete");
                        cmd.Parameters.AddWithValue("@UnitID", id);

                        int num = cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Delete data Successfully");
                            cleardata();
                        }
                        else
                        {
                            MessageBox.Show("Please Select Record");
                        }
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
                cleardata();
            }
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAddUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void txtSubunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void dgvAddunit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {

           //  this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtpartyfilter_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fetchdetails();
            }
            else
            {
                string Query = string.Format("select UnitID,UnitName,SubUnitName from tbl_UnitMaster where Company_ID ='" + NewCompany.company_id + "' and  UnitName like '%{0}%' and  DeleteData='1'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvAddunit.DataSource = ds;
                dgvAddunit.DataMember = "temp";
            }
        }
    }

  
}


