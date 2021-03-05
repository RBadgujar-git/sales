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
    public partial class Itemmaster : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public Itemmaster()
        {
            InitializeComponent();
            con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
            //picturebox.Image = Properties.Resources.No_Image_Available;
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void Itemmaster_Load(object sender, EventArgs e)
        {
            fetchdetails();
            fetchUnit();
            fetchcategory();
        }

        private void fetchcategory()
        {
            if (cmbCategry.Text != "System.Data.DataRowView")
            {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_CategoryMaster group by CategoryName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbCategry.Items.Add(ds.Tables["Temp"].Rows[i]["CategoryName"].ToString());

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

        private void cmbUnit_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                string Query = String.Format("select SubUnitName from tbl_UnitMaster where (UnitName='{0}') GROUP BY SubUnitName", cmbUnit.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtsubunit.Text = dr["SubUnitName"].ToString();
                }
                dr.Close();
                txtItemCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //con.Close();
            }
        }
       
        private void Cleardata()
        {
            txtItemName.Text = "";
            txtHSNcode.Text = "";
            cmbUnit.Text= "";
            txtsubunit.Text = "";
            txtItemCode.Text = "";
            cmbCategry.Text= "";
            txtSalePrice.Text = "0";
            cmbSaleTax.Text = "0";
            txtTaxAmountSale.Text = "0";
            txtpurchasseprice.Text = "0";
            cmbPurchasetax.Text = "0";
            txtTaxAmountPurchase.Text = "0";
            txtOpeningqty.Text = "0";
            txtatPrice.Text = "0";
            cmbItemLocation.Text = "";
            txtMRP.Text = "0";
            txtBatchNo.Text = "";
            txtSerialNo.Text = "";
            txtsize.Text = "";
            txtDescritption.Text = "";
            txtminimumStock.Text = "";
        }
        private void cmbSaleTax_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            float gst = 0, gst_amt = 0, TA = 0;
            TA = float.Parse(txtSalePrice.Text.ToString());
            gst = float.Parse(cmbSaleTax.Text.ToString());
            gst_amt = (TA * gst / 100) + TA;
            txtTaxAmountSale.Text = gst_amt.ToString();
        }
        
        private void cmbPurchasetax_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gst = 0, gst_amt = 0, TA = 0;
            TA = float.Parse(txtpurchasseprice.Text.ToString());
            gst = float.Parse(cmbPurchasetax.Text.ToString());
            gst_amt = (TA * gst / 100) + TA;
            txtTaxAmountPurchase.Text = gst_amt.ToString();
        }

        private void txtOpeningqty_TextChanged(object sender, EventArgs e)
        {
            if (txtOpeningqty.Text != "")
            {
                float gst = 0, gst_amt = 0, TA = 0;
                TA = float.Parse(txtTaxAmountPurchase.Text.ToString());
                gst = float.Parse(txtOpeningqty.Text.ToString());
                gst_amt = TA * gst;
                txtatPrice.Text = gst_amt.ToString();
            }
        }
        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
      
            DataTable dtable = new DataTable();          
            cmd = new SqlCommand("tbl_ItemMasterSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action","Select");    
            cmd.Parameters.AddWithValue("@ItemID", 0);
            cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
            cmd.Parameters.AddWithValue("@HSNCode", txtHSNcode.Text);
            cmd.Parameters.AddWithValue("@BasicUnit", cmbUnit.Text);
            cmd.Parameters.AddWithValue("@SecondaryUnit", txtsubunit.Text);
            cmd.Parameters.AddWithValue("@ItemCode", txtItemCode.Text);
            cmd.Parameters.AddWithValue("@ItemCategory", cmbCategry.Text);
            cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
            cmd.Parameters.AddWithValue("@TaxForSale", cmbSaleTax.SelectedItem);
            cmd.Parameters.AddWithValue("@SaleTaxAmount", txtTaxAmountSale.Text);
            cmd.Parameters.AddWithValue("@PurchasePrice", txtpurchasseprice.Text);
            cmd.Parameters.AddWithValue("@TaxForPurchase", cmbPurchasetax.SelectedItem);
            cmd.Parameters.AddWithValue("@PurchaseTaxAmount", txtTaxAmountPurchase.Text);
            cmd.Parameters.AddWithValue("@OpeningQty", txtOpeningqty.Text);
            cmd.Parameters.AddWithValue("@atPrice", txtatPrice.Text);
            cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
            cmd.Parameters.AddWithValue("@ItemLocation", cmbItemLocation.Text);
            cmd.Parameters.AddWithValue("@TrackingMRP", txtMRP.Text);
            cmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text);
            cmd.Parameters.AddWithValue("@SerialNo", txtSerialNo.Text);
            cmd.Parameters.AddWithValue("@MFgdate", dtpmfgDate.Value);
            cmd.Parameters.AddWithValue("@Expdate", dtpexpdate.Value);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescritption.Text);
            cmd.Parameters.AddWithValue("@MinimumStock", txtminimumStock.Text);

            SqlParameter sqlpara = new SqlParameter("@Image1", SqlDbType.Image);
            sqlpara.Value = DBNull.Value;
            cmd.Parameters.Add(sqlpara);
   
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvItemmaster.DataSource = dtable;       
        }
           
           private void InsertData()
            {
            try
            {
                if (txtItemName.Text == "")
                {
                    MessageBox.Show("Party Name Is Requried");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    picturebox.Image.Save(ms, picturebox.Image.RawFormat);
                    byte[] arrImage1 = ms.GetBuffer();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_ItemMasterSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ItemID", id);
                    cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@HSNCode", txtHSNcode.Text);
                    cmd.Parameters.AddWithValue("@BasicUnit", cmbUnit.Text);
                    cmd.Parameters.AddWithValue("@SecondaryUnit", txtsubunit.Text);
                    cmd.Parameters.AddWithValue("@ItemCode", txtItemCode.Text);
                    cmd.Parameters.AddWithValue("@ItemCategory", cmbCategry.Text);
                    cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                    cmd.Parameters.AddWithValue("@TaxForSale", cmbSaleTax.SelectedItem);
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", txtTaxAmountSale.Text);
                    cmd.Parameters.AddWithValue("@PurchasePrice", txtpurchasseprice.Text);
                    cmd.Parameters.AddWithValue("@TaxForPurchase", cmbPurchasetax.SelectedItem);
                    cmd.Parameters.AddWithValue("@PurchaseTaxAmount", txtTaxAmountPurchase.Text);
                    cmd.Parameters.AddWithValue("@OpeningQty", txtOpeningqty.Text);
                    cmd.Parameters.AddWithValue("@atPrice", txtatPrice.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                    cmd.Parameters.AddWithValue("@ItemLocation", cmbItemLocation.Text);
                    cmd.Parameters.AddWithValue("@TrackingMRP", txtMRP.Text);
                    cmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text);
                    cmd.Parameters.AddWithValue("@SerialNo", txtSerialNo.Text);
                    cmd.Parameters.AddWithValue("@MFgdate", dtpmfgDate.Value);
                    cmd.Parameters.AddWithValue("@Expdate", dtpexpdate.Value);
                    cmd.Parameters.AddWithValue("@Size", txtsize.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescritption.Text);
                    cmd.Parameters.AddWithValue("@MinimumStock", txtminimumStock.Text);
                    cmd.Parameters.Add("@Image1", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
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
            InsertData();
            fetchdetails();
            Cleardata();
        }


        private void Update1()
        {
            MemoryStream ms = new MemoryStream();
            picturebox.Image.Save(ms, picturebox.Image.RawFormat);
            byte[] arrImage1 = ms.GetBuffer();

            //DialogResult dr = MessageBox.Show("Are you sure to delete  row ?", "Confirmation", MessageBoxButtons.YesNo);
            if (!string.IsNullOrEmpty(id))
            {
                
                try
                {     
                    if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_ItemMasterSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        cmd.Parameters.AddWithValue("@ItemID", id);
                        cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                        cmd.Parameters.AddWithValue("@HSNCode", txtHSNcode.Text);
                        cmd.Parameters.AddWithValue("@BasicUnit", cmbUnit.Text);
                        cmd.Parameters.AddWithValue("@SecondaryUnit", txtsubunit.Text);
                        cmd.Parameters.AddWithValue("@ItemCode", txtItemCode.Text);
                        cmd.Parameters.AddWithValue("@ItemCategory", cmbCategry.Text);
                        cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                        cmd.Parameters.AddWithValue("@TaxForSale", cmbSaleTax.SelectedItem);
                        cmd.Parameters.AddWithValue("@SaleTaxAmount", txtTaxAmountSale.Text);
                        cmd.Parameters.AddWithValue("@PurchasePrice", txtpurchasseprice.Text);
                        cmd.Parameters.AddWithValue("@TaxForPurchase", cmbPurchasetax.SelectedItem);
                        cmd.Parameters.AddWithValue("@PurchaseTaxAmount", txtTaxAmountPurchase.Text);
                        cmd.Parameters.AddWithValue("@OpeningQty", txtOpeningqty.Text);
                        cmd.Parameters.AddWithValue("@atPrice", txtatPrice.Text);
                        cmd.Parameters.AddWithValue("@ItemLocation", cmbItemLocation.Text);
                        cmd.Parameters.AddWithValue("@Date", dtpdate.Value);
                        cmd.Parameters.AddWithValue("@TrackingMRP", txtMRP.Text);
                        cmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text);
                        cmd.Parameters.AddWithValue("@SerialNo", txtSerialNo.Text);
                        cmd.Parameters.AddWithValue("@MFgdate", dtpmfgDate.Value);
                        cmd.Parameters.AddWithValue("@Expdate", dtpexpdate.Value);
                        cmd.Parameters.AddWithValue("@Size", txtsize.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescritption.Text);
                        cmd.Parameters.AddWithValue("@MinimumStock", txtminimumStock.Text);
                        cmd.Parameters.Add("@Image1", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
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
                //}

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update1();
            fetchdetails();
            Cleardata();
        }

     private void Delete()
        {
          //  DialogResult dr = MessageBox.Show("Are you sure to delete  row ?", "Confirmation", MessageBoxButtons.YesNo);
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                  //  if (dr == DialogResult.Yes)
                   // {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("tbl_ItemMasterSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Delete");
                        cmd.Parameters.AddWithValue("@ItemID", id);
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

        private void dgvItemmaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id= dgvItemmaster.Rows[e.RowIndex].Cells["ItemID"].Value.ToString();
            txtItemName.Text = dgvItemmaster.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
            txtHSNcode.Text = dgvItemmaster.Rows[e.RowIndex].Cells["HSNCode"].Value.ToString();
            cmbUnit.Text = dgvItemmaster.Rows[e.RowIndex].Cells["BasicUnit"].Value.ToString();
            txtsubunit.Text = dgvItemmaster.Rows[e.RowIndex].Cells["SecondaryUnit"].Value.ToString();
            txtItemCode.Text = dgvItemmaster.Rows[e.RowIndex].Cells["ItemCode"].Value.ToString();
            cmbCategry.Text = dgvItemmaster.Rows[e.RowIndex].Cells["ItemCategory"].Value.ToString();
            txtSalePrice.Text = dgvItemmaster.Rows[e.RowIndex].Cells["SalePrice"].Value.ToString();
            cmbSaleTax.Text = dgvItemmaster.Rows[e.RowIndex].Cells["TaxForSale"].Value.ToString();
            txtTaxAmountSale.Text = dgvItemmaster.Rows[e.RowIndex].Cells["SaleTaxAmount"].Value.ToString();
            txtpurchasseprice.Text = dgvItemmaster.Rows[e.RowIndex].Cells["PurchasePrice"].Value.ToString();
            cmbPurchasetax.Text = dgvItemmaster.Rows[e.RowIndex].Cells["TaxForPurchase"].Value.ToString();
            txtTaxAmountPurchase.Text = dgvItemmaster.Rows[e.RowIndex].Cells["PurchaseTaxAmount"].Value.ToString();
            txtOpeningqty.Text = dgvItemmaster.Rows[e.RowIndex].Cells["OpeningQty"].Value.ToString();
            txtatPrice.Text = dgvItemmaster.Rows[0].Cells["atPrice"].Value.ToString();
            cmbItemLocation.Text = dgvItemmaster.Rows[e.RowIndex].Cells["ItemLocation"].Value.ToString();
            dtpdate.Text = dgvItemmaster.Rows[e.RowIndex].Cells["Date"].Value.ToString();
            txtMRP.Text = dgvItemmaster.Rows[e.RowIndex].Cells["TrackingMRP"].Value.ToString();
            txtBatchNo.Text = dgvItemmaster.Rows[e.RowIndex].Cells["BatchNo"].Value.ToString();
            txtSerialNo.Text = dgvItemmaster.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();
            dtpmfgDate.Text = dgvItemmaster.Rows[e.RowIndex].Cells["MFgdate"].Value.ToString();
            dtpexpdate.Text = dgvItemmaster.Rows[e.RowIndex].Cells["Expdate"].Value.ToString();
            txtsize.Text = dgvItemmaster.Rows[e.RowIndex].Cells["Size"].Value.ToString();
            txtDescritption.Text = dgvItemmaster.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            txtminimumStock.Text = dgvItemmaster.Rows[e.RowIndex].Cells["MinimumStock"].Value.ToString();

            SqlCommand cmd = new SqlCommand("select Image1 from tbl_ItemMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[e.RowIndex]["Image1"]);
                ms.Seek(0, SeekOrigin.Begin);
                picturebox.Image = Image.FromStream(ms);
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }          
        }
       

        byte[] arrImage1;
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
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        picturebox.Image.Save(ms, picturebox.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }
       

        private void guna2Button2_Click(object sender, EventArgs e)
        {         
            itemtracking.Visible = true;
         }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Add_Unit BA = new Add_Unit();
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.Visible = true;
            BA.BringToFront();
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            itemtracking.Visible = false;
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

        private void txtHSNcode_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')           // Allowing only any letter OR Digit      // Allowing BackSpace character
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtpurchasseprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Cleardata();
        }

        private void cmbPurchasetax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOpeningqty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtatPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtminimumStock_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbSaleTax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMRP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')           // Allowing only any letter OR Digit      // Allowing BackSpace character
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')           // Allowing only any letter OR Digit      // Allowing BackSpace character
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvItemmaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtsize_KeyPress(object sender, KeyPressEventArgs e)
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

        
    }
}
