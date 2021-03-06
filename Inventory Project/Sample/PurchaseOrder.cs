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
using System.Text.RegularExpressions;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace sample
{
    public partial class PurchaseOrder : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void fetchitem()
        {
            if (txtItemName.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster where Company_ID='"+NewCompany.company_id+"' group by ItemName");
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
            if (cmbpartyname.Text != "System.Data.DataRowView")
            {
                try {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where DeleteData='1' and Company_ID='" + NewCompany.company_id + "' group by PartyName");
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
     
        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            cmbpartyname1.Visible = false;
            txtTotal.Enabled = false;
            txtBallaance.Enabled = false;
            txtsubtotal.Enabled = false;
            cmbpartyname.Focus();
            fetchcustomername();
            comboBox1.Visible = false;

            label14.Visible = false;
            //fetchitem();
            txtReturnNo.Enabled = false;
            fetchCategory();
            //     bind_sale_details();
            seeting();
            get_id();
            fetchitem1();
           // fetchBarcode();
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
                string Query = String.Format("select ItemName,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where Barcode='" + textBarcode.Text + "' and Company_ID='" + NewCompany.company_id + "'  and DeleteData='1'");
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

                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void fetchitem1()
        {
            if (txtItemName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' group by ItemName");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void txtItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                con.Open();
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice TaxForSale ,SaleTaxAmount
                string Query = String.Format("select ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') and Company_ID='" + NewCompany.company_id + "' GROUP BY ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                    //txtTaxAMount1.Text = dr["SaleTaxAmount"].ToString();
                    //  txtTaxType.Text = dr["TaxType"].ToString();

                }
                dr.Close();

                txtItemCode.Focus();
            }
            catch (Exception ex) {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void cal_ItemTotal()
        {
            if (txtDis.Text != "" && txtOty.Text != "" && txtFreeQty.Text !="" && txtTax1.Text!="")
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
                    guna2TextBox4.Text = sub_total.ToString();

                    dis_amt = sub_total * dis / 100;
                    txtDisAmt.Text = dis_amt.ToString();

                    gst_amt = sub_total * gst / 100;
                    txtTaxAMount1.Text = gst_amt.ToString();

                    total = (sub_total + gst_amt) - dis_amt;
                    txtItemTotal.Text =Math.Round(total ,reminder1).ToString();
          //    txtsubtotal.Text = total.ToString();
                }
                catch(Exception ew )
                {
                  //  MessageBox.Show(ew.Message);
                }
            }

        }
        

        private void txtDis_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtTax1_TextChanged(object sender, EventArgs e)
        {
            // cal_ItemTotal();
          //  cal_ItemTotal();
            cal_Total();
           gst_devide1();

        }
        private void gst_devide1()
        {

            try
            {

                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cd = new SqlCommand("Select State from tbl_CompanyMaster where CompanyID='" + NewCompany.company_id + "'", con);
                string State1 = cd.ExecuteScalar().ToString();
                con.Close();
                //// MessageBox.Show("Date is" + State1 + "sate" + cmbStatesupply.Text);

                if (cmbStatesupply.Text == State1)
                {

                    float gst = 0, cgst = 0, sgst = 0;
                    gst = float.Parse(txtTax1.Text);
                    cgst = gst / 2;
                    sgst = gst / 2;
                    guna2TextBox1.Text = sgst.ToString();
                    guna2TextBox2.Text = cgst.ToString();
                    guna2TextBox3.Text = 0.ToString();

                }
                else
                {
                    float gst = 0;
                    gst = float.Parse(txtTax1.Text);
                    guna2TextBox3.Text = gst.ToString();
                    guna2TextBox1.Text = 0.ToString();
                    guna2TextBox2.Text = 0.ToString();
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
        int row = 0, dublication,ip;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
            try {

                if (txtOty.Text == "0")
                {
                    MessageBox.Show(" Insert  Item Qty !");
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {

                        dublication = 0;
                        ip = 0;
                        for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
                        {
                            String itemname = dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value?.ToString();
                            if (txtItemName.Text == itemname)
                            {
                                dublication = 1;
                                ip = i;
                            }

                        }

                        if (dublication == 1)
                        {
                            dublicatiuonfunction();
                        }
                        else
                        {

                            float TA = 0, TD = 0, TGST = 0, dis1 = 0, tax = 0, itotal = 0;
                            dgvInnerDebiteNote.Rows.Add();
                            row = dgvInnerDebiteNote.Rows.Count - 2;
                            dgvInnerDebiteNote.Rows[row].Cells["sr_no"].Value = row + 1;
                            dgvInnerDebiteNote.CurrentCell = dgvInnerDebiteNote[1, row];

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
                            string caltotal = guna2TextBox4.Text;
                            string cgst = guna2TextBox1.Text;
                            string sgst = guna2TextBox2.Text;
                            string igst = guna2TextBox3.Text;

                            dgvInnerDebiteNote.Rows[row].Cells[1].Value = txtItem;
                            dgvInnerDebiteNote.Rows[row].Cells[2].Value = Item_code;
                            dgvInnerDebiteNote.Rows[row].Cells[3].Value = Unit;

                            dgvInnerDebiteNote.Rows[row].Cells[4].Value = MRP;
                            dgvInnerDebiteNote.Rows[row].Cells[7].Value = qty;
                            dgvInnerDebiteNote.Rows[row].Cells[8].Value = freeqty;
                            dgvInnerDebiteNote.Rows[row].Cells[5].Value = gst;
                            dgvInnerDebiteNote.Rows[row].Cells[9].Value = gst_amt;
                            dgvInnerDebiteNote.Rows[row].Cells[6].Value = dis;
                            dgvInnerDebiteNote.Rows[row].Cells[10].Value = dis_amt;
                            dgvInnerDebiteNote.Rows[row].Cells[11].Value = Total;
                            dgvInnerDebiteNote.Rows[row].Cells[12].Value = cgst;
                            dgvInnerDebiteNote.Rows[row].Cells[13].Value = sgst;
                            dgvInnerDebiteNote.Rows[row].Cells[14].Value = igst;
                            dgvInnerDebiteNote.Rows[row].Cells[15].Value = caltotal;
                            clear_text_data();


                            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
                            {
                                dis1 += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                                textBox4.Text = dis1.ToString();
                                tax += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());
                                textBox3.Text = tax.ToString();
                                itotal += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["CalTotal"].Value?.ToString());
                                textBox6.Text = itotal.ToString();
                                TA += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());
                                txtsubtotal.Text = TA.ToString();
                                int total = Convert.ToInt32(TA);
                                txtTotal.Text = total.ToString();


                            }

                            txtItemName.Focus();

                            //for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
                            //{
                            //    TA += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());
                            //    //   // TD += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                            //    //   // TGST += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());

                            //    txtsubtotal.Text = TA.ToString();

                            //    //    txtTotal.Text = TA.ToString();
                            //    //  //  txtDisAmt.Text = TD.ToString();
                            //    //   // txtTaxAMount1.Text = TGST.ToString();
                            //}

                        }
                    }
                }
             
            }
            catch (Exception e1) {
                string message = e1.Message;
            }
        }
        float TA;
        public void dublicatiuonfunction()
        {


            float gst1 = float.Parse(this.dgvInnerDebiteNote.Rows[ip].Cells[5].Value.ToString());
            float dis1 = float.Parse(this.dgvInnerDebiteNote.Rows[ip].Cells[6].Value.ToString());
            float qty1 = float.Parse(this.dgvInnerDebiteNote.Rows[ip].Cells[7].Value.ToString());
            float freeqty1 = float.Parse(this.dgvInnerDebiteNote.Rows[ip].Cells[8].Value.ToString());
            float txamount = float.Parse(this.dgvInnerDebiteNote.Rows[ip].Cells[9].Value.ToString());
            float discamount = float.Parse(this.dgvInnerDebiteNote.Rows[ip].Cells[10].Value.ToString());
            float txtTotal1 = float.Parse(this.dgvInnerDebiteNote.Rows[ip].Cells[11].Value.ToString());



            float qty = float.Parse(txtOty.Text) + qty1;
            float freeqty = float.Parse(txtFreeQty.Text) + freeqty1;
            float gst = float.Parse(txtTax1.Text) + gst1;
            float gst_amt = float.Parse(txtTaxAMount1.Text) + txamount;
            float dis = float.Parse(txtDis.Text) + dis1;
            float dis_amt = float.Parse(txtDisAmt.Text) + discamount;
            float Total = float.Parse(txtItemTotal.Text) + txtTotal1;



            dgvInnerDebiteNote.Rows[row].Cells[7].Value = qty;
            dgvInnerDebiteNote.Rows[row].Cells[8].Value = freeqty;
            //     dgvInnerDebiteNote.Rows[row].Cells[5].Value = gst;
            dgvInnerDebiteNote.Rows[row].Cells[9].Value = gst_amt;
            //      dgvInnerDebiteNote.Rows[row].Cells[6].Value = dis;
            dgvInnerDebiteNote.Rows[row].Cells[10].Value = dis_amt;
            dgvInnerDebiteNote.Rows[row].Cells[11].Value = Total;






            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
            {
                TA += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());
                //   // TD += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                //   // TGST += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());


                txtsubtotal.Text = TA.ToString();
                txtTotal.Text = TA.ToString();

                //  //  txtDisAmt.Text = TD.ToString();
                //   // txtTaxAMount1.Text = TGST.ToString();
            }

        }
        private void clear_text_data()
        {
            txtItemName.Text = "";
            txtItemCode.Text = "";
            txtUnit.Text = "0";
            txtMRP.Text = "0";
            txtOty.Text = "0";
            txtFreeQty.Text = "0";
            txtTax1.Text = "0";
            txtTaxAMount1.Text = "0";
            txtDis.Text = "0";
            txtDisAmt.Text = "0";
            txtItemTotal.Text = "0";
            textBarcode.Text = "";
        }

        private void cleardata()
        {
            txtTax1.Text = "0";
            cmbpartyname.Text = "";
            txtbillingadd.Text = "";
            txtcon.Text = "";
            dtpInvoice.Text = "";
            dtpDueDate.Text = "";
            cmbStatesupply.Text = "";
            cmbPaymentType.Text = "";
            txtTransportName.Text = "";
            txtDeliveryLoc.Text = "";
            txtVehicleNo.Text = "";
            DtpdeliveryDate.Text = "";
            txtDescription.Text = "";
            cmbtax.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtTaxAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            txtRoundup.Text = "0";
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBallaance.Text = "0";
            comboBox1.Text = "";
            txtadditional1.Text = "";
            txtadditional2.Text = "";
            ComboBox.Text = "";
            Order.Text = "";
            txtIGST.Text = "";
            txtTax1.Text = "0";
            textBarcode.Text = "";
            txtMRP.Text = "0";
            dgvInnerDebiteNote.Rows.Clear();
            txtsubtotal.Text = "";
            txtrefNo.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox6.Text = "0";
        }
        private void get_id()
        {
            try
            {
                if (txtReturnNo.Text != "0" || txtReturnNo.Text != "")
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                    //SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

                    con.Open();
                    SqlCommand cmd = new SqlCommand("select MAX (CAST( OrderNo as INT)) from tbl_PurchaseOrder", con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        string Value = rd[0].ToString();
                        if (Value == "")
                        {
                            txtReturnNo.Text = "1";
                        }
                        else
                        {
                            txtReturnNo.Text = rd[0].ToString();
                            txtReturnNo.Text = (Convert.ToInt64(txtReturnNo.Text) + 1).ToString();
                        }

                    }
                    rd.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error"+ex);
            }
          
        }
        public int investment, barcode, reminder1;
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
                //investment = Convert.ToInt32(dr["InvoiceNo"]);
                //barcode = Convert.ToInt32(dr["barcode"]);
                reminder1 = Convert.ToInt32(dr["cashremoinder"]);

            }
            dr.Close();
        }

        private void gst_devide()
        {
            try {


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //  con.Open();
                SqlCommand cd = new SqlCommand("Select State from tbl_CompanyMaster where CompanyID='" + NewCompany.company_id + "'", con);
                string State1 = cd.ExecuteScalar().ToString();
          //      con.Close();
                // MessageBox.Show("Date is" + State1 + "sate" + cmbStatesupply.Text);

                if (State1 == cmbStatesupply.Text)
                {

                    float gst = 0, cgst = 0, sgst = 0;
                    gst = float.Parse(cmbtax.Text);
                    cgst = gst / 2;
                    sgst = gst / 2;
                    txtsgst.Text = sgst.ToString();
                    txtcgst.Text = cgst.ToString();
                }
                else
                {
                    float gst = 0;
                    gst = float.Parse(cmbtax.Text);
                    txtIGST.Text = gst.ToString();
                    txtsgst.Text = 0.ToString();
                    txtcgst.Text = 0.ToString();

                }
                con.Close();
            }
           
            catch (Exception e1) {
                //MessageBox.Show(e1.Message);
            }
        }
        object id1;
        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {
                try {


                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //  con.Open();
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_PurchaseOrderInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);
                    cmd.Parameters.AddWithValue("@OrderNo", id1);
                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@cgst", dgvInnerDebiteNote.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sgst", dgvInnerDebiteNote.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@igst", dgvInnerDebiteNote.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemTotal", dgvInnerDebiteNote.Rows[i].Cells["CalTotal"].Value.ToString());

                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                   // con.Close();
                }
            }
        }

        private void insertdata()
        {
            try {

                // PartyName ,PONo,BillDate,PODate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation,VehicleNumber,Deliverydate,Description,TransportCharges,Image,Tax1,TaxAmount1 ,TotalDiscount 
                //    ,DiscountAmount1 ,RoundFigure ,Total, Paid, RemainingBal, PaymentTerms, Feild1,Feild2,Feild3,Feild4,Feild5
                //        con.Open();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //DataTable dtable = new DataTable();
                //cmd = new SqlCommand("tbl_PurchaseOrderSelect", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Action", "Insert");
                string query = string.Format("insert into tbl_PurchaseOrder(PartyName, BillingName, OrderDate, DueDate, StateofSupply, PaymentType, TransportName, DeliveryLocation, VehicleNumber, Deliverydate, Description, Tax1, CGST, SGST, TaxAmount1, TotalDiscount, DiscountAmount1, RoundFigure, Total, Paid, RemainingBal, ContactNo, Feild1, Feild2, Feild3,Feild4, Status, TableName, Barcode,ItemCategory,IGST,Company_ID,CalTotal,TaxShow,Discount) Values (@PartyName, @BillingName,  @OrderDate, @DueDate, @StateofSupply, @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description, @Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Paid, @RemainingBal,@ContactNo,  @Feild1, @Feild2, @Feild3,@fild4,@Status, @TableName, @Barcode,@ItemCategory,@IGST,@compid,@caltotal,@taxshow,@discount); SELECT SCOPE_IDENTITY();");
                SqlCommand cmd = new SqlCommand(query, con);

                // cmd.Parameters.AddWithValue("@OrderNo", txtReturnNo.Text);       
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname1.Text);
                }
                //  cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                cmd.Parameters.AddWithValue("@OrderDate", dtpInvoice.Text);
                cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Text);           
                cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                cmd.Parameters.AddWithValue("@TransportName", txtTransportName.Text);
                cmd.Parameters.AddWithValue("@DeliveryLocation", txtDeliveryLoc.Text);
                cmd.Parameters.AddWithValue("@VehicleNumber", txtVehicleNo.Text);
                cmd.Parameters.AddWithValue("@Deliverydate", DtpdeliveryDate.Text);         
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);         
                cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                cmd.Parameters.AddWithValue("@CGST", txtcgst.Text);
                cmd.Parameters.AddWithValue("@SGST", txtsgst.Text);
                cmd.Parameters.AddWithValue("@TaxAmount1", txtTaxAmount.Text);
                cmd.Parameters.AddWithValue("@TotalDiscount", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@DiscountAmount1", txtDisAmount.Text);
                cmd.Parameters.AddWithValue("@RoundFigure", txtRoundup.Text);
                cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                cmd.Parameters.AddWithValue("@Paid", txtReceived.Text);
                cmd.Parameters.AddWithValue("@fild4", txtsubtotal.Text);
                cmd.Parameters.AddWithValue("@RemainingBal", txtBallaance.Text); 
                cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Order.Text);
                cmd.Parameters.AddWithValue("@Barcode", textBarcode.Text);
                cmd.Parameters.AddWithValue("@ItemCategory", comboBox1.Text);
                cmd.Parameters.AddWithValue("@IGST", txtIGST.Text);
                cmd.Parameters.AddWithValue("@caltotal", textBox6.Text);
                cmd.Parameters.AddWithValue("@taxshow", textBox3.Text);
                cmd.Parameters.AddWithValue("@discount", textBox4.Text);

                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Purchase Order Added ");
                //cleardata();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally {
             //   con.Close();
                insert_record_inner(id1.ToString());
            }
        }
        private void bind_sale_details()
        {
            try {

                // con.Open();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string str = string.Format("SELECT * FROM tbl_PurchaseOrder where OrderNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {

                    while (dr.Read()) {

                        // PartyName,BillingName,ContactNo,PONo,BillDate,PODate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation
                        //,VehicleNumber,Deliverydate,Description,TransportCharges,Image,Tax1,TaxAmount1 ,TotalDiscount
                        //,DiscountAmount1 ,RoundFigure ,Total, Paid, RemainingBal, PaymentTerms, Feild1,Feild2,Feild3,Feild4,Feild5
                        //  txtInvoiceNo.Text = dr["InvoiceNo"].ToString();

                       cmbpartyname1.Text = dr["PartyName"].ToString();
                        txtbillingadd.Text = dr["BillingName"].ToString();
                        txtcon.Text = dr["ContactNo"].ToString();                   
                        dtpInvoice.Text = dr["OrderDate"].ToString();
                        dtpDueDate.Text = dr["DueDate"].ToString();
                        cmbStatesupply.Text = dr["StateofSupply"].ToString();
                        cmbPaymentType.Text = dr["PaymentType"].ToString();
                        txtTransportName.Text = dr["TransportName"].ToString();
                        txtDeliveryLoc.Text = dr["DeliveryLocation"].ToString();
                        txtVehicleNo.Text = dr["VehicleNumber"].ToString();
                        DtpdeliveryDate.Text = dr["Deliverydate"].ToString();
                        txtDescription.Text = dr["Description"].ToString();
                 //       cmbtax.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                        txtTaxAmount.Text = dr["TaxAmount1"].ToString();
                        txtDiscount.Text = dr["TotalDiscount"].ToString();
                        txtDisAmount.Text = dr["DiscountAmount1"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();
                        txtTotal.Text = dr["Total"].ToString();
                        //, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , 
                        txtReceived.Text = dr["Paid"].ToString();
                        txtBallaance.Text = dr["RemainingBal"].ToString();
                        txtrefNo.Text = dr["Feild1"].ToString();
                        txtadditional1.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                   //     ComboBox.Text = dr["Status"].ToString();
                        Order.Text = dr["TableName"].ToString();
                    ///    comboBox1.Text = dr["ItemCategory"].ToString();
                      //  textBarcode.Text = dr["Barcode"].ToString();
                        txtIGST.Text = dr["IGST"].ToString();
                        txtsubtotal.Text = dr["Feild4"].ToString();
                        textBox6.Text = dr["CalTotal"].ToString();
                        textBox3.Text = dr["TaxShow"].ToString();
                        textBox4.Text = dr["Discount"].ToString();
                        id = dr["OrderNo"].ToString();

                    }

                }
              
                dr.Close();
             
                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount,CGST,SGST,IGST,CalTotal FROM tbl_PurchaseOrderInner where OrderNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'",id);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows) {
                    int i = 0;
                    while (dr1.Read()) {
                        dgvInnerDebiteNote.Rows.Add();
                        dgvInnerDebiteNote.Rows[i].Cells["sr_no"].Value = i + 1;
                        dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value = dr1["ItemName"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value = dr1["ItemCode"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value = dr1["BasicUnit"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value = dr1["SalePrice"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value = dr1["TaxForSale"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value = dr1["SaleTaxAmount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value = dr1["Discount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value = dr1["DiscountAmount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value = dr1["freeQty"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value = dr1["ItemAmount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["CGST"].Value = dr1["CGST"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["SGST"].Value = dr1["SGST"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["IGST"].Value = dr1["IGST"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["CalTotal"].Value = dr1["CalTotal"].ToString();
                        i++;
                    }
                 
                }
                dr1.Close();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
            finally {
                //   con.Close();
            //    dr1.Close();
            }
        }

        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                cmbpartyname.Visible = false;
                cmbpartyname1.Visible = true;
                bind_sale_details();
            }
        }
        private void update_record_inner(string p)
        {
            SqlCommand cmdn = new SqlCommand("tbl_PurchaseOrderInnersp", con);
            cmdn.CommandType = CommandType.StoredProcedure;
            cmdn.Parameters.AddWithValue("@Action","inserdelete");
            cmdn.Parameters.AddWithValue("@ID", txtReturnNo.Text);           
            cmdn.ExecuteNonQuery();
                
                try
                {

                for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //  con.Open();
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_PurchaseOrderInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);
                    cmd.Parameters.AddWithValue("@OrderNo", txtReturnNo.Text);
                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemTotal", dgvInnerDebiteNote.Rows[i].Cells["CalTotal"].Value.ToString());
                    cmd.Parameters.AddWithValue("@cgst", dgvInnerDebiteNote.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sgst", dgvInnerDebiteNote.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@igst", dgvInnerDebiteNote.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    cmd.ExecuteNonQuery();
                }
                }
                catch (Exception e1)
                {
                    //MessageBox.Show(e1.Message);
                }
                finally
                {
                print();
                // con.Close();
                clear_text_data();
                    cleardata();

                cmbpartyname.Visible = true;
                cmbpartyname1.Visible = false;

                get_id();
           }


                //try {
                //  //  con.Open();
                //    DataTable dtable = new DataTable();
                //    cmd = new SqlCommand("tbl_PurchaseOrderInnersp", con);
                //    cmd.CommandType = CommandType.StoredProcedure;

                //    cmd.Parameters.AddWithValue("@id", id1);

                //    cmd.Parameters.AddWithValue("@ItemName", dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@Qty", dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@freeQty", dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@Discount", dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value.ToString());
                //    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString());

                //    cmd.Parameters.AddWithValue("@Action", "Update");
                //    cmd.ExecuteNonQuery();



                //}


                //catch (Exception e1) {
                //   MessageBox.Show(e1.Message);
                //}
                //finally {
                //    //    con.Close();
                //    comboBox1.Visible = false;
                //    cmbpartyname.Visible = true;                
                //}
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
                try
                {

                    //     con.Open();

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_PurchaseOrderSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderNo", txtReturnNo.Text);
                    // cmd.Parameters.AddWithValue("@InvoiceNo", .Text);
                    // cmd.Parameters.AddWithValue("@PONo", txtPONo.Text);
                    cmd.Parameters.AddWithValue("@PartyName",cmbpartyname1.Text);
                    cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", dtpInvoice.Text);
                    //  cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoice.Text);
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Text);
                    cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                    cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                    cmd.Parameters.AddWithValue("@TransportName", txtTransportName.Text);
                    cmd.Parameters.AddWithValue("@DeliveryLocation", txtDeliveryLoc.Text);
                    cmd.Parameters.AddWithValue("@VehicleNumber", txtVehicleNo.Text);
                    cmd.Parameters.AddWithValue("@Deliverydate", DtpdeliveryDate.Text);
                    //  cmd.Parameters.AddWithValue("@due_date", txtdue_date.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    // cmd.Parameters.AddWithValue("@TransportCharges", tx.Text);
                    cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                    cmd.Parameters.AddWithValue("@CGST", txtcgst.Text);
                    cmd.Parameters.AddWithValue("@SGST", txtsgst.Text);
                    cmd.Parameters.AddWithValue("@TaxAmount1", txtTaxAmount.Text);
                    cmd.Parameters.AddWithValue("@TotalDiscount", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@DiscountAmount1", txtDisAmount.Text);
                    cmd.Parameters.AddWithValue("@RoundFigure", txtRoundup.Text);
                    cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@Paid", txtReceived.Text);
                    cmd.Parameters.AddWithValue("@RemainingBal", txtBallaance.Text);
                    //  cmd.Parameters.AddWithValue("@PaymentTerms", .Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                    cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                    cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                    cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                    cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                    cmd.Parameters.AddWithValue("@TableName", Order.Text);
                    cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@caltotal", textBox6.Text);
                cmd.Parameters.AddWithValue("@taxshow", textBox3.Text);
                cmd.Parameters.AddWithValue("@discount", textBox4.Text);
                id1 = cmd.ExecuteScalar();
                    MessageBox.Show("Sale Record Update");
                txtBallaance.Text = 0.ToString();

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                finally
                {
                    //  con.Close();
                    update_record_inner(txtReturnNo.ToString());
                
                }
            
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cal_Total()
        {
            try
            {
                float dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0, TA = 0, DC = 0;
                TA = float.Parse(txtsubtotal.Text.ToString());

                dis = float.Parse(txtDiscount.Text.ToString());
                gst = float.Parse(cmbtax.Text.ToString());
                dis_amt = TA * dis / 100;
                txtDisAmount.Text = dis_amt.ToString();

                gst_amt = TA * gst / 100;
                txtTaxAmount.Text = gst_amt.ToString();

                total = (TA + gst_amt) - dis_amt;
                txtTotal.Text =Math.Round(total,reminder1).ToString();


            }
            catch(Exception ew)
            {
               // MessageBox.Show(ew.Message);
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

        private void txtTaxAmount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            try {
                float receive_bank = 0, receive_cash = 0, pending_amt = 0, TP = 0, GT = 0;

                // receive_bank = float.Parse(txtreceive_in_bank.Text);
                receive_cash = float.Parse(txtReceived.Text);
                GT = float.Parse(txtTotal.Text);
                TP = GT - receive_cash;
                txtBallaance.Text = TP.ToString();             
            }
            catch (Exception e1) {
               // MessageBox.Show(e1.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
       
            verfydata();
            if (verify == 1)
            {
                insertdata();
              //  bind_sale_details();
                clear_text_data();
                cleardata();
                get_id();
            }

        }

        private void cmbPaymentType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(cmbPaymentType.SelectedItem=="Cheque")
            {
                txtrefNo.Visible=true;
            }
            else if (cmbPaymentType.SelectedItem == "Cash")
            {
                txtrefNo.Visible = false;
            }
        }

        private void cmbpartyname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //con.Open();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtbillingadd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();
                }
                dr.Close();

              //  dtpInvoice.Focus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
              //  con.Close();
            }
        }

        public int verify = 0;
        public void verfydata()
        {
            if (cmbpartyname.Text == "")
            {
                MessageBox.Show("Party Name Is Requried");
                cmbpartyname.Focus();
            }
            else if (ComboBox.Text == "")
            {
                MessageBox.Show("Please Select Payment Status  !");
            }
            else
            {
                verify= 1;
            }
        
    }

        private void fetchCategory()
        {
            if (comboBox1.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemCategory from tbl_ItemMaster  where DeleteData='1' group by ItemCategory ");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        comboBox1.Items.Add(ds.Tables["Temp"].Rows[i]["ItemCategory"].ToString());
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}'group by ItemName", comboBox1.Text);
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

        private void txtItemName_SelectedIndexChanged_1(object sender, EventArgs e)
      {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice TaxForSale ,SaleTaxAmount
                string Query = String.Format("select ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') GROUP BY ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
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

                //txtItemCode.Focus();
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

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentType.SelectedItem == "Cheque")
            {
                txtrefNo.Visible = true;
            }
            else if (cmbPaymentType.SelectedItem == "Cash")
            {
                txtrefNo.Visible = false;
            }
            else if (cmbPaymentType.SelectedItem == "Online Payment")
            {
                txtrefNo.Visible = false;
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTransportName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtVehicleNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Calculator cr = new Calculator();
            cr.Show();
        }

        private void cmbpartyname1_Validated(object sender, EventArgs e)
        {
            
        }

        private void cmbpartyname1_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtbillingadd_Validating(object sender, CancelEventArgs e)
        {
        }


        private void txtItemTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvInnerDebiteNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {

        }

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvInnerDebiteNote_DoubleClick(object sender, EventArgs e)
        {

            txtItemName.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[1].Value.ToString();
            txtItemCode.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[2].Value.ToString();
            txtUnit.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[3].Value.ToString();
            txtMRP.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[4].Value.ToString();
           txtDis.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[6].Value.ToString();
            txtTax1.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[5].Value.ToString();
            txtOty.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[7].Value.ToString();
            txtFreeQty.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[8].Value.ToString();
           txtDisAmt.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[10].Value.ToString();
            txtTaxAmount.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[9].Value.ToString();
           txtItemTotal.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[11].Value.ToString();


            int row = dgvInnerDebiteNote.CurrentCell.RowIndex;
            dgvInnerDebiteNote.Rows.RemoveAt(row);
        }

        private void dgvInnerDebiteNote_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void dgvInnerDebiteNote_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.BillingName,b.Company_ID,b.ContactNo,b.Company_ID,b.OrderNo,b.Deliverydate,b.DeliveryLocation,b.TransportName,b.BillingName,b.OrderDate ,b.DueDate, b.Tax1,  b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Paid,b.RemainingBal,b.DeleteData, c.Company_ID,c.DeleteData,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.CGST, c.SGST,c.IGST,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount,c.OrderNo FROM tbl_CompanyMaster as a, tbl_PurchaseOrder as b,tbl_PurchaseOrderInner as c where b.OrderNo='{0}' and c.OrderNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='"+ NewCompany.company_id+ "' and c.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and c.DeleteData='1'", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"PurchaseOrderReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("PurchaseOrder", "PurchaseOrder", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
            }
            cmbpartyname.Visible = true;
            cmbpartyname1.Visible = false;

        }



     public void  print()
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address,a.PhoneNo,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.BillingName,b.ContactNo,b.Company_ID,b.OrderNo,b.Deliverydate,b.DeliveryLocation,b.TransportName,b.BillingName,b.OrderDate, b.DueDate, b.Tax1,  b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Paid,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.CGST, c.SGST,c.IGST,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount FROM tbl_CompanyMaster as a, tbl_PurchaseOrder as b,tbl_PurchaseOrderInner as c where b.OrderNo='{0}' and c.OrderNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"PurchaseOrderReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("PurchaseOrder", "PurchaseOrder", ds.Tables[0]);

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

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
            clear_text_data();
            get_id();
            cmbpartyname.Visible = true;
            cmbpartyname1.Visible = false;
      
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (id == "")
            {
                verfydata();
                if (verify == 1)
                {
                    insertdata();
                    //  bind_sale_details();
                    print();
                    clear_text_data();
                    cleardata();
                    get_id();
                }
            }
            else
            {
                MessageBox.Show("No permission");
            }
            
        }

        private void txtReturnNo_TextChanged_1(object sender, EventArgs e)
        {
            

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {



        }

        private void textBarcode_TextChanged(object sender, EventArgs e)
        {
            if (textBarcode.Text == "")
            {
                clear_text_data();
               
            }
            else
            {
                fetchBarcode();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtItemTotal_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkRoundOff_CheckedChanged(object sender, EventArgs e)
        {
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

        private void txtrefNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrefNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtrefNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbpartyname1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cmbpartyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cmbStatesupply_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cmbPaymentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtcon_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
           else
            {
                e.Handled = false;
            }
        }

        private void cmbtax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnlinkPayment_Click(object sender, EventArgs e)
        {

        }

        private void txtTaxAMount1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtDisAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMRP_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbpartyname1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
