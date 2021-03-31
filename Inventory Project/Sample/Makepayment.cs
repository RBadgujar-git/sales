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

        public FormWindowState WindowState { get; private set; }

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
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            cmd.Parameters.AddWithValue("@Action", "Select");
            //AccountName
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);     
            dgvMakePayment.DataSource = dtable;
            con.Close();
        }
        private void InsertData()
        {
            //PrincipleAmount,InterestAmount,Date,	TotalAmount,PaidFrom
            if (txtPrincipleAmount.Text == "")
            {
                MessageBox.Show("Amount Required");
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
                
                cmd.Parameters.AddWithValue("@Date",dtpDate.Value);
                cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                cmd.Parameters.AddWithValue("@PaidFrom", cmbPaidFrom.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insert data Successfully");
                con.Close();
            }
        }
        
        private void Cleardata()
        {
            txtPrincipleAmount.Text = "0";
            txtinterestAmout.Text = "0";
            txtTotalAmount.Text = "0";
            cmbPaidFrom.Text = "";
            txtcurrentbal.Text = "";
            cmbCompanyName.Text = "";
        }
        private void dgvMakePayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvMakePayment.SelectedRows[0].Cells["ID"].Value.ToString();
            cmbCompanyName.Text = dgvMakePayment.SelectedRows[0].Cells["AccountName"].Value.ToString();
            //txtcurrentbal.Text = dgvMakePayment.SelectedRows[0].Cells["CurrentBal"].Value.ToString();
            txtPrincipleAmount.Text = dgvMakePayment.SelectedRows[0].Cells["PrincipleAmount"].Value.ToString();
            txtinterestAmout.Text = dgvMakePayment.SelectedRows[0].Cells["InterestAmount"].Value.ToString();
            dtpDate.Text = dgvMakePayment.SelectedRows[0].Cells["Date"].Value.ToString();
            txtTotalAmount.Text = dgvMakePayment.SelectedRows[0].Cells["TotalAmount"].Value.ToString();
            cmbPaidFrom.Text = dgvMakePayment.SelectedRows[0].Cells["PaidFrom"].Value.ToString();
        }
    
        private void btnSave_Click(object sender, EventArgs e)
        {         
            try
            {
                if (id == "")
                {
                    if (Int32.Parse(txtcurrentbal.Text) < Int32.Parse(txtPrincipleAmount.Text))
                    {
                        MessageBox.Show("Insufficient Balance");
                    }
                    else
                    {
                        calopenbal();
                        update_opening_bal();
                        InsertData();
                        fetchdetails();
                        Cleardata();
                    }
                }
                else
                {
                    MessageBox.Show("You Have To No Permission To Insert This Record");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error"+ex);
            }
        }
        public void calopenbal()
        {
            float opening_bal = 0, amount = 0, remain_opening = 0;

            opening_bal = float.Parse(txtcurrentbal.Text);
            amount = float.Parse(txtPrincipleAmount.Text);

            remain_opening = opening_bal - amount;
            txtcurrentbal.Text = remain_opening.ToString();
        }
        public void update_opening_bal()
        {
            try
            {
                con.Close();
                con.Open();
                String query = string.Format("update tbl_LoanBank set LoanAmount='" + txtcurrentbal.Text + "' where (AccountName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbCompanyName.Text);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                
            }
        }
        //public void calopenbal()
        //{
        //    float opening_bal = 0, amount = 0, remain_opening = 0;

        //    opening_bal = float.Parse(txtCurrentBal.Text);
        //    amount = float.Parse(txtTotal.Text);

        //    remain_opening = opening_bal - amount;
        //    txtCurrentBal.Text = remain_opening.ToString();
        //}
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
                    string SelectQuery = string.Format("select AccountName from tbl_LoanBank where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by AccountName");
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
            catch (Exception ex)
            {

                //MessageBox.Show("error"+ex);
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
                   
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
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
                finally { con.Close(); }
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
                finally { con.Close(); }
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

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                string Query = String.Format("select LoanAmount from tbl_LoanBank where (AccountName='{0}') and Deletedata='1' and Company_ID='" + NewCompany.company_id + "' GROUP BY LoanAmount ", cmbCompanyName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtcurrentbal.Text = dr["LoanAmount"].ToString();
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                fetchdetails();
                // hidedata();
            }
            else
            {
                string Query = string.Format("select ID,PrincipleAmount,InterestAmount,Date,TotalAmount,PaidFrom,AccountName from tbl_MakePayment where DeleteData = '1' and AccountName like '%{0}%' or ID like '%{0}%' and  Company_ID='" + NewCompany.company_id + "'", textBox2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvMakePayment.DataSource = ds;
                dgvMakePayment.DataMember = "temp";
            }
        }
    }
}
