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
        public int hns;
        public Itemmaster()
        {
            InitializeComponent();
            con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
           // picturebox.Image = Properties.Resources.No_Image_Available;
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }


        public int NameMrp, batchno, Serealno, MFd, exd, size;
        public int hsnid, Cess, Category;
        public int itemwisetax;
        public void chekpoint()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           
            SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                NameMrp = Convert.ToInt32(dr["MRPDate"]);
                batchno = Convert.ToInt32(dr["BatchNo"]);
                Serealno = Convert.ToInt32(dr["SerialNo"]);
                MFd = Convert.ToInt32(dr["MnfDate"]);
                exd = Convert.ToInt32(dr["ExpDate"]);
                size = Convert.ToInt32(dr["Size"]);
                Category = Convert.ToInt32(dr["ItemCategory"]);
                itemwisetax = Convert.ToInt32(dr["itemwisetax"]);

            }
            dr.Close();




            SqlCommand cmd12 = new SqlCommand("Select * from TransactionTableSetting where Company_ID='" + NewCompany.company_id + "'", con);
            SqlDataReader dr1 = cmd12.ExecuteReader();

            while (dr1.Read())
            {
                hsnid = Convert.ToInt32(dr1["HSN"]);
                Cess= Convert.ToInt32(dr1["cess"]);


            }
            dr1.Close();

        }

        public int  m = 0;
        public void setting()
        {
            if(NameMrp==1)
            {
                label24.Hide();
                txtMRP.Hide();
                m++;
            }
            if (batchno == 1)
            {
                label23.Hide();
                txtBatchNo.Hide();
                m++;
            }
            if (Serealno == 1)
            {
                label22.Hide();
                txtSerialNo.Hide();
                m++;
            }
           if (MFd == 1)
            {
                label20.Hide();
                dtpmfgDate.Hide();
                m++;
            }

            if (exd == 1)
            {
                label14.Hide();
                dtpexpdate.Hide();
                m++;
            }

            if (exd == 1)
            {
                label21.Hide();
                txtsize.Hide();
                m++;
            }

            if(hsnid==1)
            {
                label3.Visible = false;
                txtHSNcode.Visible = false;
            }
            if (m == 6)
            {
                guna2Button2.Hide();
            }
            if(Cess==0)
            {
                label26.Visible = false;
                Cesstxt.Visible = false;
            }
            if(Category==1)
            {
                cmbCategry.Visible = true;
                label6.Visible = true;
            }

            if (itemwisetax == 1)
            {
                cmbPurchasetax.Visible = false;
                cmbSaleTax.Visible = false;
                txtTaxAmountPurchase.Visible = false;
                txtTaxAmountSale.Visible = false;

            }
        }

        public String MRPtext, batchNotext, SeriealText, Mfddatetext, Expdatetext, Sizename;
        public string Decription;

        public void fatchname()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("Select * from Item_Seeting where Company_ID=" + NewCompany.company_id + "", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    MRPtext = dr["MRP"].ToString();
                    batchNotext = dr["Batch_No"].ToString();
                    SeriealText = dr["Serial_No"].ToString();
                    Mfddatetext = dr["Mef_Date"].ToString();
                    Expdatetext = dr["Exp_date"].ToString();
                    Sizename = dr["Size"].ToString();
                    Decription = dr["Description"].ToString();
                }
                dr.Close();

            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }

        public void showpaneldata()
        {
            label24.Text = MRPtext;
            label23.Text = batchNotext;
            label22.Text = SeriealText;
            label20.Text = Mfddatetext;
            label14.Text = Mfddatetext;
            label21.Text = Sizename;
            label17.Text = Decription;

        }

        private void Itemmaster_Load(object sender, EventArgs e)
        {
            cmbCategry.Visible = false;
            label6.Visible = false;

            chekpoint();
            setting();
            fatchname();
            showpaneldata();
           // autogenrate();
            fetchdetails();
            fetchUnit();
            fetchcategory();
            dgvItemmaster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            hidedatagri();
           // con.Open();
          
        }

        private void fetchcategory()
        {
            if (cmbCategry.Text != "System.Data.DataRowView")
            {
                try {
                    string SelectQuery = string.Format("select CategoryName from tbl_CategoryMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by CategoryName");
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
            if (cmbUnit.Text != "System.Data.DataRowView")
            {
                try {
                    string SelectQuery = string.Format("select UnitName from tbl_UnitMaster  where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by UnitName");
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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = String.Format("select SubUnitName from tbl_UnitMaster where (UnitName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY SubUnitName", cmbUnit.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtsubunit.Text = dr["SubUnitName"].ToString();
                }
                dr.Close();
               // txtItemCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally
            //{
            //    con.Close();
            //}
        }

        private void Cleardata()
        {
            txtItemName.Text = "";
            txtHSNcode.Text = "";
            cmbUnit.Text = "";
            txtsubunit.Text = "";
            txtItemCode.Text = "";
            cmbCategry.Text = "";
            txtSalePrice.Text = "";
            cmbSaleTax.Text = "";
            txtTaxAmountSale.Text = "";
            txtpurchasseprice.Text = "";
            cmbPurchasetax.Text = "";
            txtTaxAmountPurchase.Text = "";
            txtOpeningqty.Text = "";
            txtatPrice.Text = "";
            cmbItemLocation.Text = "";
            txtMRP.Text = "";
            txtBatchNo.Text = "";
            txtSerialNo.Text = "";
            txtsize.Text = "";
            txtDescritption.Text = "";
            txtminimumStock.Text = "";
            textBox1.Text = "";
            Cesstxt.Text = "";
           picturebox.Image = Properties.Resources.No_Image_Available;
        }
        private void cmbSaleTax_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (txtSalePrice.Text != "" && cmbSaleTax.Text != "")
            {
                float gst = 0, gst_amt = 0, TA = 0;
                TA = float.Parse(txtSalePrice.Text.ToString());
                gst = float.Parse(cmbSaleTax.Text.ToString());
                gst_amt = (TA * gst / 100) + TA;
                txtTaxAmountSale.Text = gst_amt.ToString();
            }
        }

        private void cmbPurchasetax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtpurchasseprice.Text != "" && cmbPurchasetax.Text != "")
            {
                float gst = 0, gst_amt = 0, TA = 0;
                TA = float.Parse(txtpurchasseprice.Text.ToString());
                gst = float.Parse(cmbPurchasetax.Text.ToString());
                gst_amt = (TA * gst / 100) + TA;
                txtTaxAmountPurchase.Text = gst_amt.ToString();
            }
        }

        private void txtOpeningqty_TextChanged(object sender, EventArgs e)
        {
           try
            {
                float gst = 0, gst_amt = 0, TA = 0;
                TA = float.Parse(txtTaxAmountPurchase.Text.ToString());
                gst = float.Parse(txtOpeningqty.Text.ToString());
                gst_amt = TA * gst;
                txtatPrice.Text = gst_amt.ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("error" + ex.Message);
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
            cmd.Parameters.AddWithValue("@Action", "Select");
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
            cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlParameter sqlpara = new SqlParameter("@Image1", SqlDbType.Image);
            sqlpara.Value = DBNull.Value;
            cmd.Parameters.Add(sqlpara);

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvItemmaster.DataSource = dtable;
            hidedatagri();
            dgvItemmaster.AllowUserToAddRows = false;
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
                    cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                    cmd.Parameters.Add("@Image1", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.Parameters.AddWithValue("@Cess",Cesstxt.Text);


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

        public void autogenrate()
            {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                vald();
                if (veryfy == 1)
                {
                   
                    InsertData();
                    fetchdetails();
                }
            }
            else
            {
                MessageBox.Show("Same Record Not Insert");
            }
        }
        public void insert()
        {
           
        }
        public int veryfy = 0;
        public void vald()
        {
            if (txtItemName.Text == "")
            {
                MessageBox.Show("Please Insert ItemName");
            }
            else if (cmbUnit.Text == "")
            {
                MessageBox.Show("Please Select ItemUnit");

            }         
            else if (txtpurchasseprice.Text == "0 "||txtpurchasseprice.Text=="")
            {
                MessageBox.Show("Please Insert Item Puchess Amount ");
            }
            else if (txtatPrice.Text == "0 ")
            {
                MessageBox.Show("Please Insert At Prices ");
            }
            else if (txtSalePrice.Text == "0 ")
            {
                MessageBox.Show("Please Insert Saleing Price !");
            }
            else
            {
                veryfy = 1;
            }
       

        }

        private void Update1()
        {
            

            //DialogResult dr = MessageBox.Show("Are you sure to delete  row ?", "Confirmation", MessageBoxButtons.YesNo);
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
                        cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                        cmd.Parameters.Add("@Image1", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                        cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    if (Cesstxt.Visible == true)
                    {
                        cmd.Parameters.AddWithValue("@Cess", Cesstxt.Text);
                    }
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
            if (MessageBox.Show("DO YOU WANT Delete??", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete();
                fetchdetails();
            }
        }
        public void hidedatagri()
        {
          //  dgvItemmaster.Columns["HSNCode"].Visible = false;
            dgvItemmaster.Columns["BasicUnit"].Visible = false;
            dgvItemmaster.Columns["SecondaryUnit"].Visible = false;
            dgvItemmaster.Columns["ItemCategory"].Visible = false;
            dgvItemmaster.Columns["TaxForSale"].Visible = false;
            dgvItemmaster.Columns["SaleTaxAmount"].Visible = false;
        //    dgvItemmaster.Columns["PurchasePrice"].Visible = false;

            dgvItemmaster.Columns["TaxForPurchase"].Visible = false;
            dgvItemmaster.Columns["PurchaseTaxAmount"].Visible = false;
            dgvItemmaster.Columns["atPrice"].Visible = false;
            dgvItemmaster.Columns["ItemLocation"].Visible = false;
            dgvItemmaster.Columns["atPrice"].Visible = false;
            dgvItemmaster.Columns["SerialNo"].Visible = false;
            dgvItemmaster.Columns["TrackingMRP"].Visible = false;
            dgvItemmaster.Columns["MFgdate"].Visible = false;
            dgvItemmaster.Columns["Expdate"].Visible = false;
            dgvItemmaster.Columns["Expdate"].Visible = false;
            dgvItemmaster.Columns["Size"].Visible = false;
            dgvItemmaster.Columns["DeleteData"].Visible = false;
             dgvItemmaster.Columns["Image1"].Visible = false;
          //  cmd.Parameters.Add("@Image1", SqlDbType.Image, arrImage1.Length).Value = arrImage1=false;
            dgvItemmaster.Columns["CategoryID"].Visible = false;
            dgvItemmaster.Columns["Barcode"].Visible = false;
            dgvItemmaster.Columns["Company_ID"].Visible = false;
            dgvItemmaster.Columns["Barcode"].Visible = false;
            dgvItemmaster.Columns["BatchNo"].Visible=false;
            dgvItemmaster.Columns["UnitID"].Visible = false;
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
            txtatPrice.Text = dgvItemmaster.Rows[e.RowIndex].Cells["atPrice"].Value.ToString();
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
            textBox1.Text = dgvItemmaster.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
            Cesstxt.Text = dgvItemmaster.Rows[e.RowIndex].Cells["Cess"].Value.ToString();


            try
            {
                SqlCommand cmd = new SqlCommand("select Image1 from tbl_ItemMaster where  Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", con);
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
            catch (Exception ex)
            {
               // MessageBox.Show("error" + ex.Message);
            }
        }
       

        byte[] arrImage1=null;
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
          else
            {
                e.Handled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = "";
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

        private void cmbCategry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cmbItemLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string Query = String.Format("select ItemName from tbl_ItemMaster where DeleteData ='1' and Company_ID='" + NewCompany.company_id + "'");
            DataSet ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            SDA.Fill(ds, "Temp");
            DataTable DT = new DataTable();
            SDA.Fill(ds);
            for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            {
                string itemname = ds.Tables["Temp"].Rows[i]["ItemName"].ToString();
                if (itemname.ToLower().ToString() == txtItemName.Text.ToLower().ToString())
                {
                    MessageBox.Show("This Item Already Exist");
                    txtItemName.Focus();
                }

            }
          
            
        }

        private void txtHSNcode_TextChanged(object sender, EventArgs e)
        {

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
         //   dgvItemmaster.Rows[e.RowIndex].Cells[11].Visible = false;
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click_1(object sender, EventArgs e)
        {
           
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                fetchdetails();
                hidedatagri();
            }
            else
            {
                string Query = string.Format("select ItemID,ItemName,HSNCode ,ItemCode,SalePrice,PurchasePrice,OpeningQty,Date,Description ,MinimumStock from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and  DeleteData = '1' and ItemName like '%{0}%' or ItemID like '%{0}%'", textBox2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvItemmaster.DataSource = ds;
                dgvItemmaster.DataMember = "temp";
            }
        }

        private void itemtracking_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
