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
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
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
        public int verify;
        private void fetchitem()
        {
            if (txtItemName.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by ItemName");
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

        int cmbpoint = 0;
        private void fetchcustomername()
        {
            if (cmbpartyname.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by PartyName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        cmbpartyname.Items.Add(ds.Tables["Temp"].Rows[i]["PartyName"].ToString());

                    }
                    
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }

            }
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  void itemfeatch()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // con.Close();
                string Query = String.Format("select ItemName from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {
                    txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Estimate_Quotation_Load(object sender, EventArgs e)
        {
            cmbCategory.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            cmbpartyname.Focus();             
            txtReturnNo.Enabled = false;        
            get_id();
            fetchcustomername();
            itemfeatch();
            fetchCategory();         
            comboBox1.Visible = false;
            dgvInnerQuotation.AllowUserToAddRows = false;

            seeting();
            if(barcode==1)
            {
                label6.Visible = false;
                textBox1.Visible = false;
            }

            //if (chkRoundOff.Checked == false)
            //{
            //    Math.Round(Convert.ToDouble(txtTotal.Text));
            //}
        }
        private void fetchCategory()
        {
            if (cmbCategory.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemCategory from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1'  group by ItemCategory");
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
                //  
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
                rd.Close();
            }
        }

        
        public void cal_ItemTotal()
        {
            try
            {
                float qty = 0, freeqty = 0, rate = 0, sub_total = 0, dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0;

                qty = float.Parse(txtOty.Text.ToString());
                freeqty = float.Parse(txtFreeQty.Text.ToString());
                rate = float.Parse(txtMRP.Text.ToString());
                //  sub_total = float.Parse(txtsub_total.Text.ToString());
                dis = float.Parse(txtDis.Text.ToString());
                gst = float.Parse(txtTax1.Text.ToString());

                sub_total = (qty + freeqty) * rate;
                guna2TextBox5.Text = sub_total.ToString();

                dis_amt = sub_total * dis / 100;
                txtDisAmt.Text = dis_amt.ToString();

                gst_amt = sub_total * gst / 100;
                txtTaxAMount1.Text = gst_amt.ToString();

                total = (sub_total + gst_amt) - dis_amt;
                txtItemTotal.Text = total.ToString();
                //txtTotal.Text = total.ToString();
            }
            catch (Exception ex) {
               // MessageBox.Show(ex.Message);
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
            gst_devide1();
        }
        private void gst_devide1()
        {

            try
            {

                //SqlCommand cd = new SqlCommand("Select State from tbl_CompanyMaster where CompanyID='" + NewCompany.company_id + "'", con);
                //string State1 = cd.ExecuteScalar().ToString();
                //con.Close();
                //// MessageBox.Show("Date is" + State1 + "sate" + cmbStatesupply.Text);

                if (cmbStatesupply.SelectedItem == "Maharashtra")
                {

                    float gst = 0, cgst = 0, sgst = 0;
                    gst = float.Parse(txtTax1.Text);
                    cgst = gst / 2;
                    sgst = gst / 2;
                    guna2TextBox2.Text = sgst.ToString();
                    guna2TextBox3.Text = cgst.ToString();
                    guna2TextBox4.Text = 0.ToString();

                }
                else
                {
                    float gst = 0;
                    gst = float.Parse(txtTax1.Text);
                    guna2TextBox4.Text = gst.ToString();
                    guna2TextBox2.Text = 0.ToString();
                    guna2TextBox3.Text = 0.ToString();
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

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
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cd = new SqlCommand("Select State from tbl_CompanyMaster where CompanyID='" + NewCompany.company_id + "'", con);
                string State1 = cd.ExecuteScalar().ToString();

                //MessageBox.Show("dara"+NewCompany.company_id);
                //   MessageBox.Show("Date is" + State1 + "sate" + cmbStatesupply.Text);

                if (State1 == cmbStatesupply.Text)
                {

                    //float gst = 0, cgst = 0, sgst = 0;
                    //gst = float.Parse(cmbtax.Text);
                    //cgst = gst / 2;
                    //sgst = gst / 2;
                    //txtsgst.Text = sgst.ToString();
                    //txtcgst.Text = cgst.ToString();

                    float gst = 0, cgst = 0, sgst = 0;
                    gst = float.Parse(cmbtax.Text);
                    cgst = gst / 2;
                    sgst = gst / 2;

                    txtsgst.Text = sgst.ToString();
                    txtcgst.Text = cgst.ToString();
                    //txtIGST.Text = 0.ToString();
                }
                else
                {
                    //float gst = 0;
                    //gst = float.Parse(cmbtax.Text);
                    //guna2TextBox1.Text = gst.ToString();
                    //txtsgst.Text = 0.ToString();
                    //txtcgst.Text = 0.ToString();

                    float gst = 0;
                    gst = float.Parse(cmbtax.Text);
                    txtIGST.Text = gst.ToString();
                    txtsgst.Text = 0.ToString();
                    txtcgst.Text = 0.ToString();
                }


                //float gst = 0, cgst = 0, sgst = 0;
                //gst = float.Parse(cmbtax.Text);
                //cgst = gst / 2;
                //sgst = gst / 2;
               
                //txtsgst.Text = sgst.ToString();
                //txtcgst.Text = cgst.ToString();
                //txtIGST.Text = gst.ToString();

            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
        }


        public void validdata()
        {
            if ( cmbpartyname.Text == "")
            {
                MessageBox.Show("Please Insert Party Name");
                
            }
            else if(txtBillingAdd.Text=="")
            {
                MessageBox.Show("Please Insert Address Of Party");
                txtBillingAdd.Focus();
            }
            else if (txtcon.Text == "")
            {
                MessageBox.Show("Please Insert Contact no");
                txtcon.Focus();
            }
            else if (txtcon.Text == "")
            {
                MessageBox.Show("Please Insert Contact no");
                txtcon.Focus();

            }
            else if (txtReturnNo.Text == "")
            {
                MessageBox.Show("Please Insert Contact no");
                txtReturnNo.Focus();

            }
             else if (cmbStatesupply.Text == "")
            {
                MessageBox.Show("Please Select State ");
            }
            else if (cmbtax.Text == "")
            {
                MessageBox.Show("Please Select Tax !");
            }
            else if (ComboBox.Text == "")
            {
                MessageBox.Show("Please Select Payment Status !");
            }
            else
            {
                verify = 1;
            }
        }

        object id1;
        private void insertdata()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_QuotationSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@RefNo", txtReturnNo.Text);
                //cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                }
                else

                {
                    cmd.Parameters.AddWithValue("@PartyName", comboBox1.Text);
                }
                cmd.Parameters.AddWithValue("@BillingAddress", txtBillingAdd.Text);
                cmd.Parameters.AddWithValue("@Date", dtpInvoice.Text);
                cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
              //  cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                if (cmbtax.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@Tax1", cmbpartyname.Text);
                }
                else

                {
                    cmd.Parameters.AddWithValue("@Tax1", comboBox3.Text);
                }
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
                cmd.Parameters.AddWithValue("@CalTotal", textBox6.Text);
                cmd.Parameters.AddWithValue("@TaxShow", textBox3.Text);
                cmd.Parameters.AddWithValue("@Discount", textBox4.Text);


                //if (cmbpartyname.Visible == true)
                //{
                //    cmd.Parameters.AddWithValue("@Itemcatgory", cmbCategory.Text);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@Itemcatgory", comboBox2.Text);
                //}

                cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                // cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Quotation Record Added");
               
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                 con.Close();
                insert_record_inner(id1.ToString());
            }
        }
        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerQuotation.Rows.Count; i++)
            {
                try {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_QuotationInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@RefNo", txtReturnNo.Text);              
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
                    cmd.Parameters.AddWithValue("@CGST", dgvInnerQuotation.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SGST", dgvInnerQuotation.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@IGST", dgvInnerQuotation.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@CalTotal", dgvInnerQuotation.Rows[i].Cells["CalTotal"].Value.ToString());

                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                    //MessageBox.Show(e1.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
      //  byte[] arrImage1;
       
        int row = 0;
        public int chekpoint = 0;
        public void insertitem()
        {
            try
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
                    if (itemname.ToString() == txtItemName.Text.ToString())
                    {
                        chekpoint = 1;
                    }

                }

                if (chekpoint != 1)
                {
                    string query = string.Format("insert into tbl_ItemMaster(ItemName, BasicUnit, ItemCode, SalePrice, TaxForSale,Barcode,Company_ID ) Values ('" + txtItemName.Text + "', '" + txtUnit.Text + "'," + txtItemCode.Text + ", " + txtMRP.Text + "," + txtTax1.Text + "," + textBox1.Text + "," + NewCompany.company_id + ")");

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e1)

            {
                MessageBox.Show(e1.Message);
            }
        }
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                insertitem();
                if (e.KeyCode == Keys.Enter)
                {
                    float TA = 0, TD = 0, TGST = 0, dis1 = 0, tax = 0, itotal = 0;
                    dgvInnerQuotation.Rows.Add();
                    row = dgvInnerQuotation.Rows.Count - 1;
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
                    string caltotal = guna2TextBox5.Text;
                    string cgst = guna2TextBox2.Text;
                    string sgst = guna2TextBox3.Text;
                    string igst = guna2TextBox4.Text;

                    dgvInnerQuotation.Rows[row].Cells[1].Value = txtItem;
                    dgvInnerQuotation.Rows[row].Cells[2].Value = Item_code;
                    dgvInnerQuotation.Rows[row].Cells[3].Value = Unit;

                    dgvInnerQuotation.Rows[row].Cells[4].Value = MRP;
                    dgvInnerQuotation.Rows[row].Cells[7].Value = qty;
                    dgvInnerQuotation.Rows[row].Cells[8].Value = freeqty;
                    dgvInnerQuotation.Rows[row].Cells[6].Value = gst;
                    dgvInnerQuotation.Rows[row].Cells[9].Value = gst_amt;
                    dgvInnerQuotation.Rows[row].Cells[5].Value = dis;
                    dgvInnerQuotation.Rows[row].Cells[10].Value = dis_amt;
                    dgvInnerQuotation.Rows[row].Cells[11].Value = Total;
                    dgvInnerQuotation.Rows[row].Cells[12].Value = cgst;
                    dgvInnerQuotation.Rows[row].Cells[13].Value = sgst;
                    dgvInnerQuotation.Rows[row].Cells[14].Value = igst;
                    dgvInnerQuotation.Rows[row].Cells[15].Value = caltotal;

                    txtItemName.Focus();
                   // int count=Convert.ToInt32(dgvInnerQuotation.RowCount.ToString())-1;
                    for (int i = 0; i < dgvInnerQuotation.RowCount; i++)
                    {
                        dis1 += float.Parse(dgvInnerQuotation.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                        textBox4.Text = dis1.ToString();
                        tax += float.Parse(dgvInnerQuotation.Rows[i].Cells["Tax_Amount"].Value?.ToString());
                        textBox3.Text = tax.ToString();
                        itotal += float.Parse(dgvInnerQuotation.Rows[i].Cells["CalTotal"].Value?.ToString());
                        textBox6.Text = itotal.ToString();
                        TA += float.Parse(dgvInnerQuotation.Rows[i].Cells["Amount"].Value?.ToString());

                        txtsubtotal.Text = TA.ToString();
                        txtTotal.Text = TA.ToString();
                    }

                }
                txtDescription.Focus();
            }
            catch (Exception e1)
            {
                string message = e1.Message;
            }
            finally
            {
                clear_text_data();
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
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            txtcon.Text = "";
            cmbpartyname.Text = "";
            txtBillingAdd.Text = "";
            // txtReturnNo.Text = "";
            comboBox1.Text = "";
            cmbStatesupply.Text = "";
            txtDescription.Text = "";
            //cmbtax.Text = "0";
            txtIGST.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            txtRoundup.Text = "0";
            cmbCategory.Text = "";
            ComboBox.Text = "";
            Quatation.Text = "";
            textBox1.Text = "";
            txtTotal.Text = "";
            txtsubtotal.Text = "";
            cmbtax.Text = "";
            comboBox2.Text = "0";
            txtTaxAmount.Text = "0";
            dgvInnerQuotation.Rows.Clear();
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox6.Text = "0";
        }

        private void update_record_inner(string id)
        {

            //int count = Convert.ToInt32(dgvInnerQuotation.RowCount.ToString()) - 1;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Update tbl_QuotationInner set DeleteData='0' where RefNo=" + txtReturnNo.Text+ " " , con);
            cmd.ExecuteNonQuery();
          
            for (int i = 0; i < dgvInnerQuotation.Rows.Count; i++)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_QuotationInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@RefNo", txtReturnNo.Text);
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
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
            //bind_sale_details();
            clear_text_data();
            cleardata();
            get_id();
            cmbpartyname.Visible = true;
            comboBox1.Visible = false;
           // cleardata();
            //printdata(id1.ToString());
            dgvInnerQuotation.Rows.Clear();
        }

        private void update()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_QuotationSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@RefNo", txtReturnNo.Text);
                //cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PartyName", comboBox1.Text);
                }
                cmd.Parameters.AddWithValue("@BillingAddress", txtBillingAdd.Text);
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
                cmd.Parameters.AddWithValue("@CalTotal", textBox6.Text);
                cmd.Parameters.AddWithValue("@TaxShow", textBox3.Text);
                cmd.Parameters.AddWithValue("@Discount", textBox4.Text);

                //if (cmbpartyname.Visible == true)
                //{
                //    cmd.Parameters.AddWithValue("@Itemcatgory", cmbCategory.Text);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@Itemcatgory", comboBox2.Text);
                //}

                cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                // cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Update Record Sucessfully");

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                 con.Close();
                update_record_inner(txtReturnNo.ToString());
            }
        }
        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode == Keys.Enter)
            {
                cmbtax.Visible = false;
                comboBox3.Visible = true;
                cmbpartyname.Visible = false;
                comboBox1.Visible = true;
                bind_sale_details();
            }
        }


        private void bind_sale_details()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string str = string.Format("SELECT * FROM tblQuotation where RefNo ='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        comboBox1.Text = dr["PartyName"].ToString();
                        txtBillingAdd.Text = dr["BillingAddress"].ToString();
                        txtcon.Text = dr["ContactNo"].ToString();
                        dtpInvoice.Text = dr["Date"].ToString();
                        cmbStatesupply.Text = dr["StateofSupply"].ToString();
                        txtDescription.Text = dr["Description"].ToString();
                        comboBox2.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                        txtTaxAmount.Text = dr["TaxAmount1"].ToString();
                        txtDiscount.Text = dr["TotalDiscount"].ToString();
                        txtDisAmount.Text = dr["DiscountAmount1"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();
                        txtTotal.Text = dr["Total"].ToString();

                        ComboBox.Text = dr["Status"].ToString();
                        Quatation.Text = dr["TableName"].ToString();
                        comboBox2.Text = dr["Itemcatgory"].ToString();
                        textBox1.Text = dr["Barcode"].ToString();
                        textBox6.Text = dr["CalTotal"].ToString();
                        textBox3.Text = dr["TaxShow"].ToString();
                        textBox4.Text = dr["Discount"].ToString();

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


                string str1 = string.Format("SELECT RefNo,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount,CGST,SGST,IGST,CalTotal FROM tbl_QuotationInner where RefNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    int i = 0;
                    while (dr1.Read())
                    {
                        dgvInnerQuotation.Rows.Add();
                        dgvInnerQuotation.Rows[i].Cells["sr_no"].Value = i + 1;
                        dgvInnerQuotation.Rows[i].Cells["txtItem"].Value = dr1["ItemName"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Unit"].Value = dr1["BasicUnit"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Item_Code"].Value = dr1["ItemCode"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["MRP"].Value = dr1["SalePrice"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Tax"].Value = dr1["TaxForSale"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Tax_Amount"].Value = dr1["SaleTaxAmount"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["FreeQty"].Value = dr1["freeQty"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Discount"].Value = dr1["Discount"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Discount_Amount"].Value = dr1["DiscountAmount"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["Amount"].Value = dr1["ItemAmount"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["CGST"].Value = dr1["CGST"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["SGST"].Value = dr1["SGST"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["IGST"].Value = dr1["IGST"].ToString();
                        dgvInnerQuotation.Rows[i].Cells["CalTotal"].Value = dr1["CalTotal"].ToString();

                        i++;
                    }
                    dr1.Close();
                }
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
            
            catch (Exception ex)
            {
               //MessageBox.Show(ex.Message);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();

        }

        private void cmbtax_SelectedIndexChanged(object sender, EventArgs e)
        {
            cal_Total();
            gst_devide();
            
        }

        private void txtRoundup_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
            //if (chkRoundOff.Checked == true)
            //{
            //    Math.Round(Convert.ToDouble(txtTotal.Text));
            //}
        }

        public int cp = 0;
        public void insrtparty()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' group by PartyName ");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {
                    string itemname = ds.Tables["Temp"].Rows[i]["PartyName"].ToString();
                    if (itemname.ToString() == txtItemName.Text.ToString())
                    {
                        cp = 1;
                    }
                }

                if (cp != 1)
                {
                    string query = string.Format("insert into tbl_PartyMaster(PartyName,BillingAddress,ContactNo,Company_ID ) Values ('" + cmbpartyname.Text + "', '" + txtBillingAdd.Text + "'," + txtcon.Text + "," + NewCompany.company_id + ")");

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                validdata();
                if (verify == 1)
                {
                    insertdata();
                    insertitem();
                    insrtparty();
                    //bind_sale_details();
                    clear_text_data();
                    cleardata();
                    get_id();
                    //printdata(id1.ToString());
                    dgvInnerQuotation.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("No permission");
            }
        }

        private void printdata(string id1)
        {
        if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.BillingAddress,b.ContactNo, b.RefNo, b.Date, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.BillingAddress,b.DiscountAmount1,b.Total,c.ID,c.ItemName,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount,c.TaxForSale,c.SaleTaxAmount FROM tbl_CompanyMaster  as a, tblQuotation as b,tbl_QuotationInner as c where b.RefNo='{0}' and c.RefNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' ", id1,id1);
                     SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                      report.Load(@"EstimateReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                      report.RegData("Estimate", "Estimate", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);
                }
            }
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
            if (chkenble.Checked == true)
            {
                txtReturnNo.Enabled = true;
            }
            else
            {
                txtReturnNo.Enabled = false;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                con.Open();

                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by ItemName", cmbCategory.Text);
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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtBillingAdd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();
                }
                dr.Close();
                dtpInvoice.Focus();
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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = String.Format("select ItemID ,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY ItemID ,ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                   //id = Convert.ToInt32(dr["ItemID"]);
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                    txtOty.Text = 1.ToString();
                }
                dr.Close();
                

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                txtOty.Focus();
            }
        }
        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by ItemName", cmbCategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {
                    txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,a.AddLogo,b.PartyName,b.BillingAddress,b.ContactNo, b.RefNo, b.Date, b.Tax1, b.TaxAmount1,b.TotalDiscount,b.BillingAddress,b.DiscountAmount1,b.Total,c.ID,c.ItemName,c.ItemCode,c.BasicUnit,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount,c.TaxForSale,c.SaleTaxAmount,c.CGST,c.IGST,c.SGST FROM tbl_CompanyMaster  as a, tblQuotation as b,tbl_QuotationInner as c where b.RefNo='{0}' and c.RefNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"EstimateReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("Estimate", "Estimate", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            get_id();
            cmbpartyname.Visible = true;
            comboBox1.Visible = false;
            cleardata();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public int barcode;
        public void seeting()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {

                barcode = Convert.ToInt32(dr["barcode"]);

            }
            dr.Close();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcon_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
            clear_text_data();
            get_id();
            cmbpartyname.Visible = true;
            comboBox1.Visible = false;
        }

        private void cmbpartyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cmbStatesupply_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cmbtax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void cmbtax_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
        }

        private void txtDis_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFreeQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void chkRoundOff_CheckedChanged(object sender, EventArgs e)
        {
            //int round = 0;

            //if (chkRoundOff.Checked == false)
            //{
            //    txtTotal.Clear();
            //    txtRoundup.Text = txtTotal.Text;            // +Math.Round(double.Parse(txtTotal.Text)).ToString();;
            //}
            //else if (chkRoundOff.Checked == true)
            //{

            //    txtRoundup.Text = txtTotal.Text;
            //    txtTotal.Text = Math.Round(double.Parse(txtTotal.Text)).ToString();
            //    round = Convert.ToInt32(txtTotal.Text);

            //    txtTotal.Text = round.ToString();

            //}
            /// Math.Round(Convert.ToDouble(txtTotal.Text));
            if (chkRoundOff.Checked == true)
            {
                int round = 0;
                txtRoundup.Text = txtTotal.Text;
                txtTotal.Text = Math.Round(double.Parse(txtTotal.Text)).ToString();
                round = Convert.ToInt32(txtTotal.Text);
                txtTotal.Text = round.ToString();

            }
            if (chkRoundOff.Checked == false)
            {
                cal_Total();
                txtRoundup.Text = "";
            }
        }
        private void dgvInnerQuotation_DoubleClick(object sender, EventArgs e)
        {
            txtItemName.Text = this.dgvInnerQuotation.CurrentRow.Cells[1].Value.ToString();
            txtItemCode.Text = this.dgvInnerQuotation.CurrentRow.Cells[2].Value.ToString();
            txtUnit.Text = this.dgvInnerQuotation.CurrentRow.Cells[3].Value.ToString();
            txtMRP.Text = this.dgvInnerQuotation.CurrentRow.Cells[4].Value.ToString();
            txtDis.Text = this.dgvInnerQuotation.CurrentRow.Cells[5].Value.ToString();
            txtTax1.Text = this.dgvInnerQuotation.CurrentRow.Cells[6].Value.ToString();
            txtOty.Text = this.dgvInnerQuotation.CurrentRow.Cells[7].Value.ToString();
            txtFreeQty.Text = this.dgvInnerQuotation.CurrentRow.Cells[8].Value.ToString();
            txtDisAmt.Text = this.dgvInnerQuotation.CurrentRow.Cells[9].Value.ToString();
            txtTaxAMount1.Text = this.dgvInnerQuotation.CurrentRow.Cells[10].Value.ToString();
            txtItemTotal.Text = this.dgvInnerQuotation.CurrentRow.Cells[11].Value.ToString();

            int row = dgvInnerQuotation.CurrentCell.RowIndex;
            dgvInnerQuotation.Rows.RemoveAt(row);


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void fetchBarcode()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice TaxForSale ,SaleTaxAmount
                string Query = String.Format("select ItemName,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where Barcode='" + textBox1.Text + "' and Company_ID='" + NewCompany.company_id + "'  and DeleteData='1'");
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtItemName.Text = dr["ItemName"].ToString();
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                    txtOty.Text = 1.ToString();
                    //txtTaxAMount1.Text = dr["SaleTaxAmount"].ToString();
                    //  txtTaxType.Text = dr["TaxType"].ToString();
                   // dr.Close();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                 //MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void txtItemTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtMRP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTax1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDisAmt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTaxAMount1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtsubtotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRoundup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                clear_text_data();

            }
            else
            {
                fetchBarcode();
            }

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtTaxAmount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

        private void txtDisAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
