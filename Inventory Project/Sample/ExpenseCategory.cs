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


    public partial class ExpenseCategory : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public ExpenseCategory()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }



        public void Binddata()
        {

            string selectquery = string.Format("select * from tbl_UnitMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'");
            DataSet ds = new DataSet();

            SqlDataAdapter sda = new SqlDataAdapter(selectquery, con);
            sda.Fill(ds, "temp");
            DataTable dt = new DataTable();
            sda.Fill(ds);

        }
        private void cleardata()
        {
            txtaddcategory.Text = "";
        }
        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_ExpenseCategorySelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@CategoryID", 0);
            cmd.Parameters.AddWithValue("@CategoryName", txtaddcategory.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);

            sdasql.Fill(dtable);

            dgvExpenseCaategory.DataSource = dtable;
            dgvExpenseCaategory.AllowUserToAddRows = false;

        }

        public void Insertdata()
        {
            try
            {
                if (txtaddcategory.Text == "")
                {
                    MessageBox.Show("Category Name Required");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_ExpenseCategorySelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@CategoryID", id);
                    cmd.Parameters.AddWithValue("@CategoryName", txtaddcategory.Text);
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

        private void ExpenseCategory_Load(object sender, EventArgs e)
        {
            fetchdetails();
        }

        private void dgvExpenseCaategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id  = dgvExpenseCaategory.SelectedRows[0].Cells["CategoryID"].Value.ToString();
            txtaddcategory.Text = dgvExpenseCaategory.SelectedRows[0].Cells["CategoryName"].Value.ToString();
            ///  txtSubunit.Text = dgvAddunit.SelectedRows[0].Cells["Sub unit"].Value.ToString();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCanccel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtaddcategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
        }

        public void Delete()
        {
            if (MessageBox.Show("DO YOU WANT DELETE??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        if (txtaddcategory.Text == "")
                        {
                            MessageBox.Show("Please Select Record");
                        }
                        else
                        {
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            DataTable dtable = new DataTable();
                            SqlCommand cmd = new SqlCommand("tbl_ExpenseCategorySelect", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Action", "Delete");
                            cmd.Parameters.AddWithValue("@CategoryID", id);
                            int num = cmd.ExecuteNonQuery();
                            if (num > 0)
                            {
                                MessageBox.Show("Delete Data Successfully");
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
                        MessageBox.Show("Error" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Record");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            fetchdetails();
            cleardata();
        }
        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (txtaddcategory.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else
                    {

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dtable = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_ExpenseCategorySelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@CategoryID", id);
                        cmd.Parameters.AddWithValue("@CategoryName", txtaddcategory.Text);
                        int num = cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Update Data Successfully");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible=false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvExpenseCaategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select CategoryID,CategoryName from tbl_ExpenseCategory where CategoryName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtSearch1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvExpenseCaategory.DataSource = ds;
                dgvExpenseCaategory.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void Insertcategory()
        {
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //string Query = String.Format("select CategoryName from tbl_ExpenseCategory where DeleteData ='1' and Company_ID='" + NewCompany.company_id + "'");
            //DataSet ds = new DataSet();
            //SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            //SDA.Fill(ds, "Temp");
            //DataTable DT = new DataTable();
            //SDA.Fill(ds);
            //for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //{
            //    string catname = ds.Tables["Temp"].Rows[i]["CategoryName"].ToString();
            //    if (catname.ToLower().ToString() == txtaddcategory.Text.ToLower().ToString())
            //    {

            //        MessageBox.Show("This Category Already Exist");
            //    }

            //}
        }

        private void txtaddcategory_TextChanged(object sender, EventArgs e)
        {
            Insertcategory();
            txtaddcategory.Focus();
            //cleardata();
        }
    }
}