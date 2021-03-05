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
   
    public partial class Makepayment : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public Makepayment()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void fetchdetails()
        {

            //PrincipleAmount,InterestAmount,Date,	TotalAmount,PaidFrom
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_MakePaymentSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@AccountName", "");
            cmd.Parameters.AddWithValue("@PrincipleAmount", "");
            cmd.Parameters.AddWithValue("@InterestAmount", "");
            cmd.Parameters.AddWithValue("@Date", "");
            cmd.Parameters.AddWithValue("@TotalAmount", "");
            cmd.Parameters.AddWithValue("@PaidFrom", "");    
            cmd.Parameters.AddWithValue("@Action", "Select");
            //AccountName
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);     
            dgvMakePayment.DataSource = dtable;
        }

        private void InsertData()
        {
            //PrincipleAmount,InterestAmount,Date,	TotalAmount,PaidFrom
            if (txtPrincipleAmount.Text == "")
            {
                MessageBox.Show("Amount Requrid");
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("tbl_MakePaymentSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@AccountName", cmbCompanyName.Text);
                cmd.Parameters.AddWithValue("@PrincipleAmount", txtPrincipleAmount.Text);
                cmd.Parameters.AddWithValue("@InterestAmount", txtinterestAmout.Text);
                DateTime now1 = DateTime.Today;
                cmd.Parameters.AddWithValue("@Date", now1.ToShortDateString());
                cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                cmd.Parameters.AddWithValue("@PaidFrom", cmbPaidFrom.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insert data Successfully");
                
            }
        }
        
        private void Cleardata()
        {
            txtPrincipleAmount.Text = "0";
            txtinterestAmout.Text = "0";
            txtTotalAmount.Text = "0";
            cmbPaidFrom.Text = "";
        }
        private void dgvMakePayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvMakePayment.SelectedRows[0].Cells["ID"].Value.ToString();
            cmbCompanyName.Text = dgvMakePayment.SelectedRows[0].Cells["AccountName"].Value.ToString();
            txtPrincipleAmount.Text = dgvMakePayment.SelectedRows[0].Cells["PrincipleAmount"].Value.ToString();
            txtinterestAmout.Text = dgvMakePayment.SelectedRows[0].Cells["InterestAmount"].Value.ToString();
            dtpDate.Text = dgvMakePayment.SelectedRows[0].Cells["Date"].Value.ToString();
            txtTotalAmount.Text = dgvMakePayment.SelectedRows[0].Cells["TotalAmount"].Value.ToString();
            cmbPaidFrom.Text = dgvMakePayment.SelectedRows[0].Cells["PaidFrom"].Value.ToString();
        }
    
        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertData();
            fetchdetails();
            Cleardata();
        }

        private void Makepayment_Load(object sender, EventArgs e)
        {
            fetchdetails();
            fetchLoanAccount();
        }
        private void fetchLoanAccount()
        {
            if (cmbCompanyName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select AccountName from tbl_LoanBank group by AccountName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbCompanyName.Items.Add(ds.Tables["Temp"].Rows[i]["AccountName"].ToString());
                     }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }


        private void txtinterestAmout_TextChanged(object sender, EventArgs e)
        {
            try {

         
            float PA = 0, TA = 0, IA = 0;
            PA = float.Parse(txtPrincipleAmount.Text.ToString());
            IA = float.Parse(txtinterestAmout.Text.ToString());
            TA = PA + IA;
            txtTotalAmount.Text = TA.ToString();
            }
            catch (Exception) {

                MessageBox.Show("error");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtPrincipleAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtinterestAmout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmbPaidFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
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
                    SqlCommand cmd = new SqlCommand("tbl_MakePaymentSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@AccountName", cmbCompanyName.Text);
                    cmd.Parameters.AddWithValue("@PrincipleAmount", txtPrincipleAmount.Text);
                    cmd.Parameters.AddWithValue("@InterestAmount", txtinterestAmout.Text);
                    DateTime now1 = DateTime.Today;
                    cmd.Parameters.AddWithValue("@Date", now1.ToShortDateString());
                    cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                    cmd.Parameters.AddWithValue("@PaidFrom", cmbPaidFrom.Text);
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

        private void btnUpdate_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("tbl_MakePaymentSelect", con);
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
            Delete();
            fetchdetails();
            Cleardata();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }
    }
}
