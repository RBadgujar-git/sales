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
    public partial class Referralcode : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public Referralcode()
        {
            InitializeComponent();
        }

        private void cleardata()
        {
            txtReferralcode.Text = "";
        }

        private void fetchdtails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("ReferralCodeSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@ReferralCode", txtReferralcode.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtable);
            dgvReferral.DataSource = dtable;
            dgvReferral.AllowUserToAddRows = false;
        }

        public void Insert1()
        {
            try
            {
                if (txtReferralcode.Text == "")
                {
                    MessageBox.Show("Referral Code Is Rquired");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("ReferralCodeSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ReferralCode", txtReferralcode.Text);
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
            
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Referralcode_Load(object sender, EventArgs e)
        {
            fetchdtails();
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnDone_Click_2(object sender, EventArgs e)
        {
            if (id == "")
            {
                Insert1();
                fetchdtails();
                cleardata();
            }
            else
            {
                MessageBox.Show("Same Record Not Inserted");
            }
        }

        private void dgvReferral_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvReferral.SelectedRows[0].Cells["ID"].Value.ToString();
            txtReferralcode.Text = dgvReferral.SelectedRows[0].Cells["ReferralCode"].Value.ToString();
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
                    cmd = new SqlCommand("ReferralCodeSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ReferralCode", txtReferralcode.Text);

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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtReferralcode.Text == "")
            {
                MessageBox.Show("Please Select Record");
            }
            else
            {
                Update1();
                fetchdtails();
                cleardata();
            }
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
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("ReferralCodeSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Delete");
                    cmd.Parameters.AddWithValue("@ID", id);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT Delete??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                Delete();
                fetchdtails();
                cleardata();
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
        }

        private void dgvReferral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fetchdtails();
            }
            else
            {
                string Query = string.Format("select ID,ReferralCode from ReferralCode1 where Company_ID ='" + NewCompany.company_id + "' and ReferralCode like '%{0}%' and  DeleteData='1'", textBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvReferral.DataSource = ds;
                dgvReferral.DataMember = "temp";
            }
        }
    }
}
