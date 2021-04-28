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


namespace sample
{
    public partial class Category : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public Category()
        {
            InitializeComponent();
            // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void cleardata()
        {
            txtCategory.Text = "";
        }

        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_CategoryMasterSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@CategoryID", 0);
            cmd.Parameters.AddWithValue("@CategoryName", txtCategory.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtable);
            dgvCategory.DataSource = dtable;
            dgvCategory.AllowUserToAddRows = false;
        }

        private void Category_Load(object sender, EventArgs e)
        {
            txtCategory.Focus();
            fetchdetails();
        }

        public void Insert()
        {
            try
            {
                if (txtCategory.Text == "")
                {
                    MessageBox.Show("Catgory Name Is Requried");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_CategoryMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@CategoryID", id);
                    cmd.Parameters.AddWithValue("@CategoryName", txtCategory.Text);
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                Insert();
                fetchdetails();
                cleardata();
            }
            else
            {
                MessageBox.Show("Same Record Not Insert");
            }
        }
     
        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {


                    if (txtCategory.Text == "") {

                        MessageBox.Show("Please Select Record");
                    }
                    else
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_CategoryMasterSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@CategoryID", id);
                        cmd.Parameters.AddWithValue("@CategoryName", txtCategory.Text);
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
        private void butUpdate_Click(object sender, EventArgs e)
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

                    if (txtCategory.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_CategoryMasterSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Delete");
                        cmd.Parameters.AddWithValue("@CategoryID", id);

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
        private void butDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT Delete??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete();
                fetchdetails();
                cleardata();
            }
        }

        private void dgvCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvCategory.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
            txtCategory.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtCategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fetchdetails();
            }
            else
            {
                string Query = string.Format("select CategoryID,CategoryName from tbl_CategoryMaster where Company_ID ='" + NewCompany.company_id + "' and DeleteData='1' and CategoryName like '%{0}%'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvCategory.DataSource = ds;
                dgvCategory.DataMember = "temp";
            }
        }
    }
}
