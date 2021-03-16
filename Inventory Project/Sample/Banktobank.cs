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
    public partial class Banktobank : UserControl
    {

        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        private FormWindowState WindowState;

        public Banktobank()
        {
            InitializeComponent();
            // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void Cleardata()
        {
            cmbfrombank.Text = "";
            txttobank.Text = "";
            txtAmount.Text = "0";
            txtDescription.Text = "";
            textBox1.Text = "";
        }
        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            SqlCommand cmd = new SqlCommand("Banktobank", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@FromBank", cmbfrombank.Text);
            cmd.Parameters.AddWithValue("@ToBank", txttobank.Text);
            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
            cmd.Parameters.AddWithValue("@Descripition", txtDescription.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvbanktobank.DataSource = dtable;
            con.Close();
        }


        public void validdata()
        {


            if (cmbfrombank.Text == "")
            {
                MessageBox.Show("Bank Name Required");
            }
            else if (txttobank.Text == "")
            {

                MessageBox.Show("Enter Bank Name For Transfer Amount");
            }
            else if (txttobank.Text == "")
            {

                MessageBox.Show("Enter Bank Name For Transfer Amount");
            }
            else if (txtAmount.Text == "")
            {

                MessageBox.Show("Please Insert Amount");
            }

        }

        public void Insert()
        {
            try
            {
                //   validdata();
                if (cmbfrombank.Text == "")
                {
                    MessageBox.Show("Bank Name Required");
                }
                else if (txttobank.Text == "")
                {

                    MessageBox.Show("Enter Bank Name For Transfer Amount");
                }
                else if (txttobank.Text == "")
                {

                    MessageBox.Show("Enter Bank Name For Transfer Amount");
                }
                else if (txtAmount.Text == "")
                {

                    MessageBox.Show("Please Insert Amount");
                }

                else
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("Banktobank", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@FromBank", cmbfrombank.Text);
                    cmd.Parameters.AddWithValue("@ToBank", txttobank.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@Descripition", txtDescription.Text);
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
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == "")
                {
                     if (Int32.Parse(textBox1.Text) < Int32.Parse(txtAmount.Text))
                     {
                          MessageBox.Show("Insuficient Balence");
                     }   
                    else 
                    {
                        calopenbal();
                        update_opening_bal();
                        Insert();
                        fetchdetails();
                    }
                }
                else
                {
                    MessageBox.Show("You Have To No Permission To Insert This Record");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("error"+ex);
            }
            
          //  Cleardata();
        }


        private void Banktobank_Load(object sender, EventArgs e)
        {

            fetchdetails();
            bankfetch();
           
        }
        public void update_opening_bal()
        {
            try
            {
                con.Open();
                String query = string.Format("update tbl_BankAccount set OpeningBal='"+textBox1.Text+"' where (BankName='{0}') and Company_ID='"+NewCompany.company_id+"' and DeleteData='1'", cmbfrombank.Text);
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
        private void bankfetch()
        {
            if (cmbfrombank.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select BankName from tbl_BankAccount where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by BankName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbfrombank.Items.Add(ds.Tables["Temp"].Rows[i]["BankName"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }





        private void dgvbanktobank_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvbanktobank.SelectedRows[0].Cells["ID"].Value.ToString();
            cmbfrombank.Text = dgvbanktobank.SelectedRows[0].Cells["FromBank"].Value.ToString();
            txttobank.Text = dgvbanktobank.SelectedRows[0].Cells["ToBank"].Value.ToString();
            txtAmount.Text = dgvbanktobank.SelectedRows[0].Cells["Amount"].Value.ToString();
            dtpDate.Text = dgvbanktobank.SelectedRows[0].Cells["Date"].Value.ToString();
            txtDescription.Text = dgvbanktobank.SelectedRows[0].Cells["Descripition"].Value.ToString();
            // txtDetails.Text = dgvItemAdjustment.SelectedRows[0].Cells["Details"].Value.ToString();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false; }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttobank_KeyPress(object sender, KeyPressEventArgs e)
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

                    if (cmbfrombank.Text == "")
                    {
                        MessageBox.Show("Bank Name Required");
                    }
                    else if (txttobank.Text == "")
                    {

                        MessageBox.Show("Enter Bank Name For Transfer Amount");
                    }
                    else if (txttobank.Text == "")
                    {

                        MessageBox.Show("Enter Bank Name For Transfer Amount");
                    }
                    else if (txtAmount.Text == "")
                    {

                        MessageBox.Show("Please Insert Amount");
                    }
                    else
                    {


                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("Banktobank", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@FromBank", cmbfrombank.Text);
                        cmd.Parameters.AddWithValue("@ToBank", txttobank.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                        cmd.Parameters.AddWithValue("@Descripition", txtDescription.Text);
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
                finally
                { con.Close(); }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            // validdata();
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
                    if (cmbfrombank.Text == "")
                    {
                        MessageBox.Show("Bank Name Required");
                    }
                    else if (txttobank.Text == "")
                    {

                        MessageBox.Show("Enter Bank Name For Transfer Amount");
                    }
                    else if (txttobank.Text == "")
                    {

                        MessageBox.Show("Enter Bank Name For Transfer Amount");
                    }
                    else if (txtAmount.Text == "")
                    {

                        MessageBox.Show("Please Insert Amount");
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("Banktobank", con);
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
                finally { con.Close(); }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }

        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            //  validdata();
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

        private void cmbfrombank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select OpeningBal from tbl_BankAccount where (BankName='{0}') and Deletedata='1' and Company_ID='" + NewCompany.company_id + "' GROUP BY OpeningBal ", cmbfrombank.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["OpeningBal"].ToString();
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
           
        }
        public void cal()
        {
            
        }

        private void txtAmount_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
           
            //try
            //{
            //    float opening_bal=0, amount=0, remain_opening=0;

            //    opening_bal = float.Parse(textBox1.Text);
            //    amount = float.Parse(txtAmount.Text);

            //    remain_opening = opening_bal - amount;
            //    textBox1.Text = remain_opening.ToString();
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}
        }
        public void calopenbal()
        {
            float opening_bal = 0, amount = 0, remain_opening = 0;

            opening_bal = float.Parse(textBox1.Text);
            amount = float.Parse(txtAmount.Text);

            remain_opening = opening_bal - amount;
            textBox1.Text = remain_opening.ToString();
        }
        public int bankamount;
            
       public void DisplayLowQuantityItems()
        {
            con.Open();
            string Query = String.Format("select OpeningBal from tbl_BankAccount where Deletedata='1' and Company_ID='" + NewCompany.company_id + "' GROUP BY OpeningBal ", cmbfrombank.Text);
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteScalar();
          
            con.Close();
            MessageBox.Show("Is not Available\n");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
