using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace sample
{
    public partial class ItemSevice : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public ItemSevice()
        {
            InitializeComponent();
         //   con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

       private void Cleardata()
        {
            txtItemName.Text = "";
            txtHSNCode.Text = "";
            cmbUnit.Text = "";
            txtSubunit.Text = "";
            txtitemcode.Text = "";
            cmbItemCategory.Text = "";
            txtSaleCoategory.Text = "";
            cmbTaxType.Text = "";
            cmbTaxRate.Text = "";
            txtDescription.Text = "";
            picturebox.Image = null;
        }

        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_ItemServicemasterSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Select");
                cmd.Parameters.AddWithValue("@ServiceID", 0);
                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                cmd.Parameters.AddWithValue("@ItemHSNCOde", txtHSNCode.Text);
                cmd.Parameters.AddWithValue("@Unit", cmbUnit.Text);
                cmd.Parameters.AddWithValue("@Subunit", txtSubunit.Text);
                cmd.Parameters.AddWithValue("@ItemCode", txtitemcode.Text);
                cmd.Parameters.AddWithValue("@Category", cmbItemCategory.Text);
                cmd.Parameters.AddWithValue("@SalePrice", txtSaleCoategory.Text);
                cmd.Parameters.AddWithValue("@TaxType", cmbTaxType.Text);
                cmd.Parameters.AddWithValue("@TaxRate", cmbTaxRate.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                
                SqlParameter sqlpara = new SqlParameter("@Image", SqlDbType.Image);
                sqlpara.Value = DBNull.Value;
                cmd.Parameters.Add(sqlpara);

                SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
                sdasql.Fill(dtable); 
                dgvItemServices.DataSource = dtable;
            }

            private void InsertData()
            {

            MemoryStream ms = new MemoryStream();
            picturebox.Image.Save(ms, picturebox.Image.RawFormat);
            byte[] arrImage1 = ms.GetBuffer();
            try
            {
                if (txtItemName.Text == "")
                {
                    MessageBox.Show("Item Name Required");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_ItemServicemasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ServiceID", id);
                    cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@ItemHSNCOde", txtHSNCode.Text);
                    cmd.Parameters.AddWithValue("@Unit", cmbUnit.Text);
                    cmd.Parameters.AddWithValue("@Subunit", txtSubunit.Text);
                    cmd.Parameters.AddWithValue("@ItemCode", txtitemcode.Text);
                    cmd.Parameters.AddWithValue("@Category", cmbItemCategory.Text);
                    cmd.Parameters.AddWithValue("@SalePrice", txtSaleCoategory.Text);
                    cmd.Parameters.AddWithValue("@TaxType", cmbTaxType.Text);
                    cmd.Parameters.AddWithValue("@TaxRate", cmbTaxRate.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
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
        public int veryfi = 0;

        public void validdata()
        {
            if (txtItemName.Text == "")
            {
                MessageBox.Show("Item Name Required");
                txtItemName.Focus();

            }
            else if (txtHSNCode.Text == "")
            {
                MessageBox.Show("Item HSN Required");
                txtHSNCode.Focus();

            }
            else if (cmbUnit.Text == "")
            {
                MessageBox.Show("Item Unit Required");
                cmbUnit.Focus();
            }        
            else if (txtitemcode.Text == "")
            {
                MessageBox.Show("Item unit code Required");
                txtitemcode.Focus();
            }
            else if (cmbItemCategory.Text == "")
            {
                MessageBox.Show("Please Select Item Category");
                cmbItemCategory.Focus();
            }
            else if (txtSaleCoategory.Text == "")
            {
                MessageBox.Show("Insert Salling  Prize !");
                txtSaleCoategory.Focus();

            }
            else if (cmbTaxType.Text == "")
            {
                MessageBox.Show(" select Tax Type !");              
             }
            else if (cmbTaxRate.Text == "")
            {
                MessageBox.Show(" select Tax Rate !");

            }
            else if (cmbTaxRate.Text == "")
            {
                MessageBox.Show(" select Tax Rate !");

            }
            else
            {
                veryfi = 1;
            }



        }
       
        private void btnsave_Click(object sender, EventArgs e)
        {
            validdata();
            if (veryfi == 1)
            {
                InsertData();
                fetchdetails();
            }
        }

        private void Update1()
        {



            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MemoryStream ms = new MemoryStream();
                    picturebox.Image.Save(ms, picturebox.Image.RawFormat);
                    byte[] arrImage1 = ms.GetBuffer();

                    DataTable dtable = new DataTable();
                    SqlCommand cmd = new SqlCommand("tbl_ItemServicemasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ServiceID", id);
                    cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@ItemHSNCOde", txtHSNCode.Text);
                    cmd.Parameters.AddWithValue("@Unit", cmbUnit.Text);
                    cmd.Parameters.AddWithValue("@Subunit", txtSubunit.Text);
                    cmd.Parameters.AddWithValue("@ItemCode", txtitemcode.Text);
                    cmd.Parameters.AddWithValue("@Category", cmbItemCategory.Text);
                    cmd.Parameters.AddWithValue("@SalePrice", txtSaleCoategory.Text);
                    cmd.Parameters.AddWithValue("@TaxType", cmbTaxType.Text);
                    cmd.Parameters.AddWithValue("@TaxRate", cmbTaxRate.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            validdata();
            if (veryfi == 1)
            {
                Update1();
                fetchdetails();
            }
        }

        public void Delete()
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {

                    if (txtItemName.Text == "")
                    {

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dtable = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_ItemServicemasterSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Delete");
                        cmd.Parameters.AddWithValue("@ServiceID", id);
                        int num = cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Delete Data Successfully");
                            Cleardata();
                        }
                        else
                        {
                            MessageBox.Show("Please Select Record");
                        }
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            Delete();
            fetchdetails();
        }
        
        private void ItemSevice_Load(object sender, EventArgs e)
        {
            fetchdetails();
            fetchUnit();
            fetchcategory();
        }

        private void fetchcategory()
        {
            if (cmbItemCategory.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_CategoryMaster group by CategoryName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbItemCategory.Items.Add(ds.Tables["Temp"].Rows[i]["CategoryName"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void fetchUnit()
        {
            if (cmbUnit.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select UnitName from tbl_UnitMaster group by UnitName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbUnit.Items.Add(ds.Tables["Temp"].Rows[i]["UnitName"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = String.Format("select SubUnitName from tbl_UnitMaster where (UnitName='{0}') GROUP BY SubUnitName", cmbUnit.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtSubunit.Text = dr["SubUnitName"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Add_Unit BA = new Add_Unit();
           // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
          //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        byte[] arrImage1 = null;
        private void picturebox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int count = 1;
                foreach (String file in openFileDialog1.FileNames)
                {
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);

                    if (count == 1)
                    {
                        picturebox.Image = Image.FromFile(file);
                        // PictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                        picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        picturebox.Image.Save(ms, picturebox.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHSNCode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSaleCoategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbTaxRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvItemServices_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgvItemServices.Rows[e.RowIndex].Cells["ServiceID"].Value.ToString();
            txtItemName.Text = dgvItemServices.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
            txtHSNCode.Text = dgvItemServices.Rows[e.RowIndex].Cells["ItemHSNCOde"].Value.ToString();
            cmbUnit.Text = dgvItemServices.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
            txtSubunit.Text = dgvItemServices.Rows[e.RowIndex].Cells["Subunit"].Value.ToString();
            txtitemcode.Text = dgvItemServices.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();
            cmbItemCategory.Text = dgvItemServices.Rows[e.RowIndex].Cells["Category"].Value.ToString();
            txtSaleCoategory.Text = dgvItemServices.Rows[e.RowIndex].Cells["SalePrice"].Value.ToString();
            cmbTaxType.Text = dgvItemServices.Rows[e.RowIndex].Cells["TaxType"].Value.ToString();
            cmbTaxRate.Text = dgvItemServices.Rows[e.RowIndex].Cells["TaxRate"].Value.ToString();
            txtDescription.Text = dgvItemServices.Rows[e.RowIndex].Cells["Description"].Value.ToString();

            SqlCommand cmd = new SqlCommand("select Image from tbl_ItemServicemaster", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[e.RowIndex]["Image"]);
                ms.Seek(0, SeekOrigin.Begin);
                picturebox.Image = Image.FromStream(ms);
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void txtitemcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
