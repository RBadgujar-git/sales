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
            cmd.Parameters.AddWithValue("@UnitName", "");
            cmd.Parameters.AddWithValue("@SubUnitName", "");         
            SqlDataAdapter sqlSda = new SqlDataAdapter(cmd);
            sqlSda.Fill(dtable);
            dgvAddunit.DataSource = dtable;
           }

        int i = 0;
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
            Insertdata();
            fetchdetails();
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
            Delete();
            fetchdetails();
            cleardata();
        }
    }
}
