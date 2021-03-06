﻿using System;
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
        public string companyid;

        public FormWindowState WindowState { get; private set; }

        public AdjustAccount()
        {
            InitializeComponent();
          //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }
        
        private void Cleardata()
        {
            cmbaccountname.Text= "";
            cmbEntrytype.Text = "";
            txtAcoount.Text = "0";
            txtdescription.Text = "";
            textBox1.Text = "";
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
            cmd.Parameters.AddWithValue("@compid", companyid);
            cmd.Parameters.AddWithValue("@Action", "Select");

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);

            sdasql.Fill(dtable);

            dgvAdjustaccount.DataSource = dtable;
            dgvAdjustaccount.AllowUserToAddRows = false;
            con.Close();
            ////dgvAdjustaccount.DataBind();
            //try
            //{
            //    String Str = string.Format("select * from tbl_BankAdjustment where Company_ID='" + companyid + "'");
            //    DataSet Ds = new DataSet();
            //    SqlDataAdapter SDA = new SqlDataAdapter(Str, con);
            //    SDA.Fill(Ds, "Temp");
            //    dgvAdjustaccount.DataSource = Ds;
            //    dgvAdjustaccount.DataMember = "Temp";
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}
            //finally
            //{
            //    con.Close();


            //}
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
                    cmd.Parameters.AddWithValue("@compid", companyid);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert data Successfully");
                Cleardata();
                }
            con.Close();
            
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdjustAccount_Load(object sender, EventArgs e)
        {
            companyid = NewCompany.company_id;
            bankfetch();
            fetchdetails();
            fetchdetails();
            //fetchAccountname();
          
        }

        private void fetchAccountname()
        {
            if (cmbaccountname.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select AccountName from tbl_BankAccount where Company_ID='"+NewCompany.company_id+"' group by AccountName");
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
           
            try
            {
                if (id == "")
                {
                       
                        if (cmbEntrytype.SelectedItem == "Debit")
                        {
                            if (Int32.Parse(textBox1.Text) < Int32.Parse(txtAcoount.Text))
                            {
                                MessageBox.Show("Insuficient Balence");
                            }
                            else
                            {
                                calminus();
                                Insert();
                                update_opening_bal();
                                fetchdetails();
                            }
                        }
                        else if (cmbEntrytype.SelectedItem == "Credit")
                        {
                            Caladd();
                            Insert();
                            update_opening_bal();
                            fetchdetails();
                        }        
                }
                else
                {
                    MessageBox.Show("Same Record Not Insert");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("error"+ex);
            }
        }
        public void update_opening_bal()
        {
            try
            {
                con.Open();
                String query = string.Format("update tbl_BankAccount set OpeningBal='" + textBox1.Text + "' where (BankName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", cmbaccountname.Text);
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
            id = "";
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

                    if (cmbaccountname.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else if (cmbEntrytype.Text == "")
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
                finally { con.Close();
                    Cleardata();
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
                    else if (txtAcoount.Text == "")
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
                finally { con.Close(); }
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
                Cleardata();
            }
        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmbEntrytype_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public void Caladd()
        {
            float opening_bal = 0, amount = 0, remain_opening = 0;

            opening_bal = float.Parse(textBox1.Text);
            amount = float.Parse(txtAcoount.Text);

            remain_opening = opening_bal + amount;
            textBox1.Text = remain_opening.ToString();
        }
        public void calminus()
        {
            float opening_bal = 0, amount = 0, remain_opening = 0;

            opening_bal = float.Parse(textBox1.Text);
            amount = float.Parse(txtAcoount.Text);

            remain_opening = opening_bal - amount;
            textBox1.Text = remain_opening.ToString();
         }
        private void bankfetch()
        {
            if (cmbaccountname.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select BankName from tbl_BankAccount where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by BankName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbaccountname.Items.Add(ds.Tables["Temp"].Rows[i]["BankName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void cmbaccountname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select OpeningBal from tbl_BankAccount where (BankName='{0}') and Deletedata='1' and Company_ID='" + NewCompany.company_id + "' GROUP BY OpeningBal ", cmbaccountname.Text);
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

        private void dgvAdjustaccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                fetchdetails();
                // hidedata();
            }
            else
            {
                string Query = string.Format("select ID,BankAccount,EntryType,Amount,Date,Description from tbl_BankAdjustment where Company_ID='" + NewCompany.company_id + "' and BankAccount like '%{0}%' and DeleteData = '1'", textBox2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvAdjustaccount.DataSource = ds;
                dgvAdjustaccount.DataMember = "temp";
            }
        }
    }
}
