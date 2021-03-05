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
    public partial class AdjustItem : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //   SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public AdjustItem()
        {
            InitializeComponent();
          //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void Cleardata()
        {
            txtName.Text = "";
            combotype.Text = "";
            txtatprice.Text = "0";
            txtitemqantity.Text = "";
            txtitemdetails.Text = "";
        }

        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_ItemAdjustementSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@ItemName", txtName.Text);
            cmd.Parameters.AddWithValue("@AdjustmentType", combotype.Text);
            cmd.Parameters.AddWithValue("@AdjustmentDate", date.Value);
            cmd.Parameters.AddWithValue("@AtPrice", txtatprice.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtitemqantity.Text);
            cmd.Parameters.AddWithValue("@Details", txtitemdetails.Text);
           
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
             dgvItemAdjustment.DataSource = dtable;


        }
        public void Insert()
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Item Name Is Rquired");
                }
                else if (txtatprice.Text == "")
                {
                    MessageBox.Show("Item Price Is Rquired");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_ItemAdjustementSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ItemName", txtName.Text);
                    cmd.Parameters.AddWithValue("@AdjustmentType", combotype.Text);
                    cmd.Parameters.AddWithValue("@AdjustmentDate", date.Value);
                    cmd.Parameters.AddWithValue("@AtPrice", txtatprice.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtitemqantity.Text);
                    cmd.Parameters.AddWithValue("@Details", txtitemdetails.Text);
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

        private void buttonsave_Click(object sender, EventArgs e)
        {
            Insert();
            fetchdetails();
            Cleardata();
        }
     
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible=false;
        }     

        private void AdjustItem_Load(object sender, EventArgs e)
        {
            fetchdetails();
            fetchItemName();
        }

        private void dgvItemAdjustment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             id = dgvItemAdjustment.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txtName.Text = dgvItemAdjustment.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
            combotype.Text = dgvItemAdjustment.Rows[e.RowIndex].Cells["AdjustmentType"].Value.ToString();
            date.Text = dgvItemAdjustment.Rows[e.RowIndex].Cells["AdjustmentDate"].Value.ToString();
            txtatprice.Text = dgvItemAdjustment.Rows[e.RowIndex].Cells["AtPrice"].Value.ToString();
            txtitemqantity.Text = dgvItemAdjustment.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            txtitemdetails.Text = dgvItemAdjustment.Rows[e.RowIndex].Cells["Details"].Value.ToString();
        }

        private void guna2TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void guna2TextBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void fetchItemName()
        {
            if (txtName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster group by ItemName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        txtName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
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

                    if (txtName.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else { 
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_ItemAdjustementSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@ItemName", txtName.Text);
                        cmd.Parameters.AddWithValue("@AdjustmentType", combotype.Text);
                        cmd.Parameters.AddWithValue("@AdjustmentDate", date.Value);
                        cmd.Parameters.AddWithValue("@AtPrice", txtatprice.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtitemqantity.Text);
                        cmd.Parameters.AddWithValue("@Details", txtitemdetails.Text);
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
        private void butUpdate_Click(object sender, EventArgs e)
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

                    if (txtName.Text == "")
                    {
                        MessageBox.Show("Please Select Record");
                    }
                    else { 
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_ItemAdjustementSelect", con);
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

        private void Delete_Click(object sender, EventArgs e)
        {
            Delete();
            fetchdetails();
            //tbl_ItemAdjustement();
        }
    }
}
