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
    public partial class AdjustAccount : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
       // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
       // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public AdjustAccount()
        {
            InitializeComponent();
          //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }
        
        private void Cleardata()
        {
            cmbaccountname.Text= "";
            cmbEntrytype.Text = "";
            txtAcoount.Text = "";
            txtdescription.Text = "";
        }
        private void fetchdetails()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            DataTable dtable = new DataTable();

            cmd = new SqlCommand("tbl_BankAdjustmentselect", con);
            cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@BankAccount", "");
            cmd.Parameters.AddWithValue("@EntryType", "");
            cmd.Parameters.AddWithValue("@Amount", "");
            cmd.Parameters.AddWithValue("@Date", "");
            cmd.Parameters.AddWithValue("@Description", "");
            cmd.Parameters.AddWithValue("@Action", "Select");

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);

            sdasql.Fill(dtable);
           
            dgvAdjustaccount.DataSource = dtable;
          
            // dgvAdjustaccount.DataBind();

        }
        public void Insert()
        {
            
           
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                    if (cmbaccountname.Text == "")
                    {
                        MessageBox.Show("Account Name Requried");
                    }
                    else if (cmbEntrytype.Text=="")
                        {
                    MessageBox.Show("Please Select Entry Type");
                }
                else if (txtAcoount.Text == "")
                {
                    MessageBox.Show("Please Ensert Amount ");
                }
                else
                {

                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_BankAdjustmentselect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@BankAccount", cmbaccountname.Text);
                    cmd.Parameters.AddWithValue("@EntryType", cmbEntrytype.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtAcoount.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                    cmd.Parameters.AddWithValue("@Description", txtdescription.Text);
                    //cmd.Parameters.AddWithValue("@Details", txtdescription.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert data Successfully");
                }
              
            
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdjustAccount_Load(object sender, EventArgs e)
        {
            fetchdetails();
            fetchAccountname();
        }

        private void fetchAccountname()
        {
            if (cmbaccountname.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select AccountName from tbl_BankAccount group by AccountName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbaccountname.Items.Add(ds.Tables["Temp"].Rows[i]["AccountName"].ToString());

                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvAdjustaccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           id = dgvAdjustaccount.SelectedRows[0].Cells["ID"].Value.ToString();
            cmbaccountname.Text = dgvAdjustaccount.SelectedRows[0].Cells["BankAccount"].Value.ToString();
            cmbEntrytype.Text = dgvAdjustaccount.SelectedRows[0].Cells["EntryType"].Value.ToString();
            txtAcoount.Text = dgvAdjustaccount.SelectedRows[0].Cells["Amount"].Value.ToString();
            dtpdate.Text = dgvAdjustaccount.SelectedRows[0].Cells["Date"].Value.ToString();
            txtdescription.Text = dgvAdjustaccount.SelectedRows[0].Cells["Description"].Value.ToString();
          
        }

        private void btnSaave_Click(object sender, EventArgs e)
        {
            Insert();
            fetchdetails();
            Cleardata();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtAcoount_KeyPress(object sender, KeyPressEventArgs e)
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

                    if (cmbaccountname.Text=="")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (cmbEntrytype.Text== "")
                    {
                        MessageBox.Show("Please Select Entry Type");
                    }
                    else if (txtAcoount.Text == "")
                    {
                        MessageBox.Show("Please Ensert Amount ");
                    }
                    else
                    {

                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_BankAdjustmentselect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@BankAccount", cmbaccountname.Text);
                        cmd.Parameters.AddWithValue("@EntryType", cmbEntrytype.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtAcoount.Text);
                        cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                        cmd.Parameters.AddWithValue("@Description", txtdescription.Text);
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



                    if (cmbaccountname.Text=="")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else
                    {

                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_BankAdjustmentselect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Delete");
                        cmd.Parameters.AddWithValue("@ID", id);

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
            Cleardata();
        }
    }
}
