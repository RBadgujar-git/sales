﻿using System;
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
    public partial class Estimate_Quotation : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public Estimate_Quotation()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }
        private void fetchitem()
        {
            if (txtItemName.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster group by ItemName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void fetchcustomername()
        {
            if (cmbpartyname.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbpartyname.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());

                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }
    
        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Estimate_Quotation_Load(object sender, EventArgs e)
        {
           
            txtTotal.Enabled = false;          
            txtsubtotal.Enabled = false;           
            txtReturnNo.Enabled = false;        
            fetchcustomername();
            txtReturnNo.Enabled = false;
            get_id();
            fetchCategory();
            bind_sale_details();

        }
        private void fetchCategory()
        {
            if (cmbCategory.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemCategory from tbl_ItemMaster group by ItemCategory");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbCategory.Items.Add(ds.Tables["Temp"].Rows[i]["ItemCategory"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void get_id()
        {
            if (txtReturnNo.Text != "0" || txtReturnNo.Text != "") {
                // SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
                SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select MAX (CAST( RefNo as INT)) from tblQuotation", con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) {
                    string Value = rd[0].ToString();
                    if (Value == "") {
                        txtReturnNo.Text = "1";
                    }
                    else {
                        txtReturnNo.Text = rd[0].ToString();
                        txtReturnNo.Text = (Convert.ToInt64(txtReturnNo.Text) + 1).ToString();
                    }
                }
                con.Close();
            }
        }

        
        public void cal_ItemTotal()
        {
            try {
                float qty = 0, freeqty = 0, rate = 0, sub_total = 0, dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0;

                qty = float.Parse(txtOty.Text.ToString());
                freeqty = float.Parse(txtFreeQty.Text.ToString());
                rate = float.Parse(txtMRP.Text.ToString());
                //  sub_total = float.Parse(txtsub_total.Text.ToString());
                dis = float.Parse(txtDis.Text.ToString());
                gst = float.Parse(txtTax1.Text.ToString());

                sub_total = (qty + freeqty) * rate;
                //txtsub_total.Text = sub_total.ToString();

                dis_amt = sub_total * dis / 100;
                txtDisAmt.Text = dis_amt.ToString();

                gst_amt = sub_total * gst / 100;
                txtTaxAMount1.Text = gst_amt.ToString();

                total = (sub_total + gst_amt) - dis_amt;
                txtItemTotal.Text = total.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMRP_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtDis_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtTax1_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtOty_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtFreeQty_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }
        private void gst_devide()
        {
            try {
                float gst = 0, cgst = 0, sgst = 0;
                gst = float.Parse(cmbtax.Text);
                cgst = gst / 2;
                sgst = gst / 2;
                txtsgst.Text = sgst.ToString();
                txtcgst.Text = cgst.ToString();
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
        }

        object id1;
        private void insertdata()
        {
            try
            {
                con.Open();
                //MemoryStream ms = new MemoryStream();
                //picImage.Image.Save(ms, picImage.Image.RawFormat);
                //byte[] arrImage1 = ms.GetBuffer();

                //DataTable dtable = new DataTable();
                //cmd = new SqlCommand("tbl_QuotationSelect", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Action", "Insert");
                string query = string.Format("insert into tblQuotation(PartyName, BillingAddress, Date, StateofSupply, Description, Tax1, CGST, SGST, TaxAmount1, TotalDiscount, DiscountAmount1, RoundFigure, Total, Status, TableName, Barcode) Values(@PartyName, @BillingAddress, @Date, @StateofSupply, @Description, @Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @ContactNo, @Status, @TableName, @Barcode); SELECT SCOPE_IDENTITY();");
                SqlCommand cmd = new SqlCommand(query, con);
                //  cmd.Parameters.AddWithValue("@RefNo", txtReturnNo.Text);
                cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                cmd.Parameters.AddWithValue("@BillingName", txtBillingAdd.Text);
                cmd.Parameters.AddWithValue("@Date", dtpInvoice.Text);
                cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                cmd.Parameters.AddWithValue("@CGST", txtcgst.Text);
                cmd.Parameters.AddWithValue("@SGST", txtsgst.Text);
                cmd.Parameters.AddWithValue("@TaxAmount1", txtTaxAmount.Text);
                cmd.Parameters.AddWithValue("@TotalDiscount", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@DiscountAmount1", txtDisAmount.Text);
                cmd.Parameters.AddWithValue("@RoundFigure", txtRoundup.Text);
                cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                //  cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);

                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Quatation.Text);
                cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                // cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Sale Record Added");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                con.Close();
                insert_record_inner(id.ToString());
            }
        }
        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerQuotation.Rows.Count; i++) {
                try {
                    con.Open();
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_QuotationInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);

                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount



                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerQuotation.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerQuotation.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerQuotation.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerQuotation.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerQuotation.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerQuotation.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerQuotation.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerQuotation.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerQuotation.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerQuotation.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerQuotation.Rows[i].Cells["Amount"].Value.ToString());

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                    con.Close();
                }
            }
        }
      //  byte[] arrImage1;
       
        int row = 0;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyCode == Keys.Enter) {
                    float TA = 0, TD = 0, TGST = 0;
                    dgvInnerQuotation.Rows.Add();
                    row = dgvInnerQuotation.Rows.Count - 2;
                    dgvInnerQuotation.Rows[row].Cells["sr_no"].Value = row + 1;
                    dgvInnerQuotation.CurrentCell = dgvInnerQuotation[1, row];

                    e.SuppressKeyPress = true;
                    string txtItem = txtItemName.Text;

                    string Item_code = txtItemCode.Text;
                    string Unit = txtUnit.Text;
                    string MRP = txtMRP.Text;
                    string qty = txtOty.Text;
                    string freeqty = txtFreeQty.Text;
                    string gst = txtTax1.Text;
                    string gst_amt = txtTaxAMount1.Text;
                    string dis = txtDis.Text;
                    string dis_amt = txtDisAmt.Text;
                    string Total = txtItemTotal.Text;

                    dgvInnerQuotation.Rows[row].Cells[1].Value = txtItem;
                    dgvInnerQuotation.Rows[row].Cells[2].Value = Item_code;
                    dgvInnerQuotation.Rows[row].Cells[3].Value = Unit;

                    dgvInnerQuotation.Rows[row].Cells[4].Value = MRP;
                    dgvInnerQuotation.Rows[row].Cells[7].Value = qty;
                    dgvInnerQuotation.Rows[row].Cells[8].Value = freeqty;
                    dgvInnerQuotation.Rows[row].Cells[5].Value = gst;
                    dgvInnerQuotation.Rows[row].Cells[9].Value = gst_amt;
                    dgvInnerQuotation.Rows[row].Cells[6].Value = dis;
                    dgvInnerQuotation.Rows[row].Cells[10].Value = dis_amt;
                    dgvInnerQuotation.Rows[row].Cells[11].Value = Total;

                    txtItemName.Focus();

                    for (int i = 0; i < dgvInnerQuotation.Rows.Count; i++) {
                        TA += float.Parse(dgvInnerQuotation.Rows[i].Cells["Amount"].Value?.ToString());
                       
                        txtsubtotal.Text = TA.ToString();
                       
                    }
                    clear_text_data();
                }
            }
            catch (Exception e1) {
                string message = e1.Message;
            }
        }
        private void clear_text_data()
        {
            txtItemName.Text = "";
            txtItemCode.Text = "";
            txtUnit.Text = "";
            txtMRP.Text = "0";
            txtOty.Text = "0";
            txtFreeQty.Text = "0";
            txtTax1.Text = "0";
            txtTaxAMount1.Text = "0";
            txtDis.Text = "0";
            txtDisAmt.Text = "0";
            txtItemTotal.Text = "0";
        }
        private void cleardata()
        {
            cmbpartyname.Text = "";
            txtBillingAdd.Text = "";
          txtReturnNo.Text = "";
            cmbStatesupply.Text = "";
            txtDescription.Text = "";
            cmbtax.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtTaxAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            txtRoundup.Text = "";
           
            ComboBox.Text = "";
            Quatation.Text = "";
            textBox1.Text = "";
        }

        private void update_record_inner(string p)
        {
            for (int i = 0; i < dgvInnerQuotation.Rows.Count; i++) {
                try {
                    con.Open();
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_QuotationInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id1);

                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerQuotation.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerQuotation.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerQuotation.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerQuotation.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerQuotation.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerQuotation.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerQuotation.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerQuotation.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerQuotation.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerQuotation.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerQuotation.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Action", "Update");

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                    con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                con.Open();
                //MemoryStream ms = new MemoryStream();
                //picImage.Image.Save(ms, picImage.Image.RawFormat);
                //byte[] arrImage1 = ms.GetBuffer();

                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_QuotationSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@RefNo", txtReturnNo.Text);
                cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                cmd.Parameters.AddWithValue("@BillingName", txtBillingAdd.Text);
                cmd.Parameters.AddWithValue("@Date", dtpInvoice.Text);
                cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                cmd.Parameters.AddWithValue("@CGST", txtcgst.Text);
                cmd.Parameters.AddWithValue("@SGST", txtsgst.Text);
                cmd.Parameters.AddWithValue("@TaxAmount1", txtTaxAmount.Text);
                cmd.Parameters.AddWithValue("@TotalDiscount", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@DiscountAmount1", txtDisAmount.Text);
                cmd.Parameters.AddWithValue("@RoundFigure", txtRoundup.Text);
                cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
               
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Quatation.Text);
             //   cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                cmd.Parameters.AddWithValue("@Action", "Update");

            id1 = cmd.ExecuteScalar();
            MessageBox.Show("Sale Record Update");
        }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
            finally {
                con.Close();
                update_record_inner(txtReturnNo.ToString());
}
        }

        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) {
                bind_sale_details();
            }
        }
        private void bind_sale_details()
        {
            try {
                con.Open();
                string str = string.Format("SELECT * FROM tblQuotation where RefNo='{0}'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        cmbpartyname.Text = dr["PartyName"].ToString();
                        txtBillingAdd.Text = dr["BillingName"].ToString();
                        
                        dtpInvoice.Text = dr["Date"].ToString();
                        cmbStatesupply.Text = dr["StateofSupply"].ToString();
                        txtDescription.Text = dr["Description"].ToString();
                        cmbtax.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                        txtTaxAmount.Text = dr["TaxAmount1"].ToString();
                        txtDiscount.Text = dr["TotalDiscount"].ToString();
                        txtDisAmount.Text = dr["DiscountAmount1"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();
                        txtTotal.Text = dr["Total"].ToString();
                     
                        ComboBox.Text = dr["Status"].ToString();
                        Quatation.Text = dr["TableName"].ToString();
                        textBox1.Text = dr["Barcode"].ToString();
                        id = dr["RefNo"].ToString();
                        //if (ds.Tables[0].Rows.Count > 0) {
                        //    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);
                        //    ms.Seek(0, SeekOrigin.Begin);
                        //    picImage.Image = Image.FromStream(ms); ;
                        //    picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        //}
                    }
                }
                dr.Close();
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount


                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_DebitNoteInner where ID='{0}'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows) {
                    int i = 0;
                    while (dr1.Read()) {
                        dgvInnerQuotation.Rows.Add();
                        dgvInnerQuotation.Rows[i].Cells["sr_no"].Value = i + 1;
                        dgvInnerQuotation.Rows[i].Cells["txtItem"].Value = dr1["ItemName"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Item_Code"].Value = dr1["ItemCode"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Unit"].Value = dr1["BasicUnit"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["MRP"].Value = dr1["SalePrice"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Tax"].Value = dr1["TaxForSale"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Tax_Amount"].Value = dr1["SaleTaxAmount"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Discount"].Value = dr1["Discount"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Discount_Amount"].Value = dr1["DiscountAmount"].ToString();

                        dgvInnerQuotation.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["FreeQty"].Value = dr1["freeQty"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Amount"].Value = dr1["ItemAmount"].ToString();


                        i++;
                    }
                    dr1.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                con.Close();
            }
        }
        public void cal_Total()
        {
            try {
                float dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0, TA = 0, DC = 0;



                TA = float.Parse(txtsubtotal.Text.ToString());

                dis = float.Parse(txtDiscount.Text.ToString());
                gst = float.Parse(cmbtax.Text.ToString());




                dis_amt = TA * dis / 100;
                txtDisAmount.Text = dis_amt.ToString();

                gst_amt = TA * gst / 100;
                txtTaxAmount.Text = gst_amt.ToString();

                total = (TA + gst_amt) - dis_amt;
                txtTotal.Text = total.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

        private void cmbtax_SelectedIndexChanged(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
        }

        private void txtRoundup_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertdata();
            bind_sale_details();
            clear_text_data();
            cleardata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings BA = new Settings();
            BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void chkenble_CheckedChanged(object sender, EventArgs e)
        {
            if (chkenble.Checked == true) {
                txtReturnNo.Enabled = true;
            }
            else {
                txtReturnNo.Enabled = false;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                con.Open();

                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}'group by ItemName", cmbCategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                    txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                con.Close();
            }
        }

       

        private void cmbpartyname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtBillingAdd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void txtItemName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') GROUP BY ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();


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
                con.Close();
            }
        }
    }
    
}