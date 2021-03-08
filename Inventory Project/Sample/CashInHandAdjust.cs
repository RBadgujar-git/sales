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
    public partial class CashInHandAdjust : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public CashInHandAdjust()
        {
            InitializeComponent();

            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }



        private void Cleardata()
        {
            txtCashadjustment.Text = "";
            txtenterAmount.Text = "";
            txtDescription.Text = "";
        }

        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_CashAdjustmentselect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@CashAdjustment", txtCashadjustment.Text);
            cmd.Parameters.AddWithValue("@CashAmount", txtenterAmount.Text);
            cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@compid",NewCompany.company_id);

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvCashAdjustment.DataSource = dtable;
        }

        public void Insert()
        {
            try
            {
                if (txtCashadjustment.Text == "")
                {
                    MessageBox.Show("Cash adjustmnt Requird");
                }
                else if (txtenterAmount.Text == "")
                {
                    MessageBox.Show("Amount Requird");
                }
                else
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_CashAdjustmentselect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@CashAdjustment", txtCashadjustment.Text);
                    cmd.Parameters.AddWithValue("@CashAmount", txtenterAmount.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@compid",NewCompany.company_id);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Insert();
            fetchdetails();
        }




        private void CashInHandAdjust_Load(object sender, EventArgs e)
        {
            fetchdetails();
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    
        private void dgvCashAdjustment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           id = dgvCashAdjustment.SelectedRows[0].Cells["ID"].Value.ToString();
            txtCashadjustment.Text = dgvCashAdjustment.SelectedRows[0].Cells["CashAdjustment"].Value.ToString();
            txtenterAmount.Text = dgvCashAdjustment.SelectedRows[0].Cells["CashAmount"].Value.ToString();
            dtpdate.Text = dgvCashAdjustment.SelectedRows[0].Cells["Date"].Value.ToString();
            txtDescription.Text = dgvCashAdjustment.SelectedRows[0].Cells["Description"].Value.ToString();
           // txtDescription.Text = dgvbanktobank.SelectedRows[0].Cells["Description"].Value.ToString();
        }

        private void txtenterAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtenterAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        public void Delete()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (txtCashadjustment.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (txtenterAmount.Text == "")
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
                        SqlCommand cmd = new SqlCommand("tbl_CashAdjustmentselect", con);
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
        public void Update1()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {

                    if (txtCashadjustment.Text == "")
                    {
                        MessageBox.Show("Cash adjustmnt Requird");
                    }
                    else if (txtenterAmount.Text == "")
                    {
                        MessageBox.Show("Amount Requird");
                    }
                    else
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_CashAdjustmentselect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@CashAdjustment", txtCashadjustment.Text);
                        cmd.Parameters.AddWithValue("@CashAmount", txtenterAmount.Text);
                        cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update1();
            fetchdetails();
            Cleardata();
        }

        private void txtCashadjustment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void dgvCashAdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
