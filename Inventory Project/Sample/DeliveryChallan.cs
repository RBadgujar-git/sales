using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Data.SqlClient;

namespace sample
{
    public partial class DeliveryChallan : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public DeliveryChallan()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void DeliveryChallan_Load(object sender, EventArgs e)
        {         
            fetchCategory();
            txtReturnNo.Enabled = false;       
            bind_sale_details();
            txtTotal.Enabled = false;
            txtBallaance.Enabled = false;
            txtsubtotal.Enabled = false;
            fetchcustomername();
           // fetchitem();
            get_id();
            txtReturnNo.Enabled = false;
            comboBox1.Visible = false;
        }
        private void fetchitem()
        {
            if (txtItemName.Text != "System.Data.DataRowView")
            {
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

        private void fetchcustomername()
        {
            if (cmbpartyname.Text != "System.Data.DataRowView") {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where DeleteData='1' and Company_ID='"+NewCompany.company_id+"' group by PartyName ");
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

       

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
                //txtsub_total.Text = sub_total.ToString();

                dis_amt = sub_total * dis / 100;
                txtDisAmt.Text = dis_amt.ToString();

                gst_amt = sub_total * gst / 100;
                txtTaxAMount1.Text = gst_amt.ToString();

                total = (sub_total + gst_amt) - dis_amt;
                txtItemTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
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
        public int verifyid = 0;
     public void verifydata()
        {
            if(cmbpartyname.Text=="")
            {
                MessageBox.Show("Party Name Is Reguerd !");
            }
            else if (txtPartyAdd.Text == "")
            {
                MessageBox.Show("Party Addresss Is Reguerd !");
                txtPartyAdd.Focus();
            }
            else if (txtcon.Text == "")
            {
                MessageBox.Show("Party Contact No Is Reguerd !");
                txtcon.Focus();
            }
            else if (txtBillingName.Text == "")
            {
                MessageBox.Show("Party Billing Name  Is Reguerd !");
                txtBillingName.Focus();
            }
            else if (txtBillingadd.Text == "")
            {
                MessageBox.Show("Party Billing Address Is Reguerd !");
                txtBillingadd.Focus();
            }
            else if (cmbStatesupply.Text == "")
            {
                MessageBox.Show("Party Supplay State  Is Reguerd !");
                //txtBillingadd.Focus();
            }
            else if (cmbStatesupply.Text == "")
            {
                MessageBox.Show("Please Select Supplay State !");
                //txtBillingadd.Focus();
            }
            else if (cmbCategory.Text == "")
            {
                MessageBox.Show(" Please Select Item Categoery!");
                //txtBillingadd.Focus();
            }
            else if (cmbPaymentType.Text == "")
            {
                MessageBox.Show(" Please Select Payment Type !");
                //txtBillingadd.Focus();
            }
            else if (cmbtax.Text == "")
            {
                MessageBox.Show(" Please Select TaxType !");
                //txtBillingadd.Focus();
            }
            else
            {
                verifyid = 1;
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


                string query = string.Format("insert into tbl_DeliveryChallan(PartyName ,BillingName,BillingAddress,PartyAddress,InvoiceDate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation,VehicleNumber,Deliverydate,Description,Tax1,CGST,SGST,TaxAmount1 ,TotalDiscount ,DiscountAmount1 ,RoundFigure ,Total, Received, RemainingBal, ContactNo,Feild1,Feild2,Feild3,Status,TableName,ItemCategory,Barcode,Company_ID) Values (@PartyName, @BillingName,  @BillingAddress,@PartyAddress,@InvoiceDate, @DueDate, @StateofSupply, @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description,@Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Received, @RemainingBal, @ContactNo, @Feild1, @Feild2, @Feild3, @Status, @TableName, @ItemCategory,@Barcode,@compid); SELECT SCOPE_IDENTITY();");
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd = new SqlCommand("tbl_DeliveryChallanSelect", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Action", "Insert");
                //cmd.Parameters.AddWithValue("@ChallanNo", txtReturnNo.Text);
                //   cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PartyName", comboBox1.Text);
                }
                cmd.Parameters.AddWithValue("@BillingName", txtBillingName.Text);
               // cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                cmd.Parameters.AddWithValue("@BillingAddress", txtPartyAdd.Text);
                cmd.Parameters.AddWithValue("@PartyAddress", txtBillingadd.Text);
                cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoice.Value);
                cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                cmd.Parameters.AddWithValue("@TransportName", txtTransportName.Text);
                cmd.Parameters.AddWithValue("@DeliveryLocation", txtDeliveryLoc.Text);
                cmd.Parameters.AddWithValue("@VehicleNumber", txtVehicleNo.Text);
                cmd.Parameters.AddWithValue("@Deliverydate", DtpdeliveryDate.Value);
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
                cmd.Parameters.AddWithValue("@Received", txtReceived.Text);
                cmd.Parameters.AddWithValue("@RemainingBal", txtBallaance.Text);
       
                cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Delivery.Text);
                cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Sale Record Added");
                
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally {
                //con.Close();
                insert_record_inner(id1.ToString());
            }
        }
       

        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerDeliveryChallanNote.Rows.Count; i++)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_DeliveryChallanInner", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);

                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount

                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerDeliveryChallanNote.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDeliveryChallanNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDeliveryChallanNote.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerDeliveryChallanNote.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerDeliveryChallanNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDeliveryChallanNote.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                    //MessageBox.Show(e1.Message);
                }
                //finally
                //{
                //    con.Close();
                //}
            }
        }
        private void cmbtax_SelectedIndexChanged(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
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

                //if (txtreceive_in_bank.Text != "") {
                //  TP = GT - receive_bank;
                //   txtpending_amt.Text = TP.ToString();
                //}
                //else {
                TP = GT - receive_cash;
                txtBallaance.Text = TP.ToString();
                //}
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
        }
        private void get_id()
        {
            if (txtReturnNo.Text != "0" || txtReturnNo.Text != "") {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

                con.Open();
                SqlCommand cmd = new SqlCommand("select MAX (CAST( ChallanNo as INT)) from tbl_DeliveryChallan", con);
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

        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbpartyname.Visible = false;
                comboBox1.Visible = true;
                bind_sale_details();
            }
        }
        private void bind_sale_details()
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string str = string.Format("SELECT * FROM tbl_DeliveryChallan where DeleteData='1' and  ChallanNo='{0}' and Company_ID='" + NewCompany.company_id + "'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);                           
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                       // txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                        comboBox1.Text = dr["PartyName"].ToString();
                        txtPartyAdd.Text = dr["BillingAddress"].ToString();
                        txtBillingName.Text = dr["BillingName"].ToString();
                        txtBillingadd.Text = dr["PartyAddress"].ToString();

                        dtpInvoice.Text = dr["InvoiceDate"].ToString();
                        dtpDueDate.Text = dr["DueDate"].ToString();
                        cmbStatesupply.Text = dr["StateofSupply"].ToString();
                        cmbPaymentType.Text = dr["PaymentType"].ToString();
                        txtTransportName.Text = dr["TransportName"].ToString();
                        txtDeliveryLoc.Text = dr["DeliveryLocation"].ToString();


                        txtVehicleNo.Text = dr["VehicleNumber"].ToString();
                        DtpdeliveryDate.Text = dr["Deliverydate"].ToString();
                        txtDescription.Text = dr["Description"].ToString();
                        cmbtax.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                        txtTaxAmount.Text = dr["TaxAmount1"].ToString();
                        txtDiscount.Text = dr["TotalDiscount"].ToString();
                        txtDisAmount.Text = dr["DiscountAmount1"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();
                        txtTotal.Text = dr["Total"].ToString();

                        //, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , 

                        txtReceived.Text = dr["Received"].ToString();
                        txtBallaance.Text = dr["RemainingBal"].ToString();
                        txtrefNo.Text = dr["Feild1"].ToString();
                        txtadditional1.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Delivery.Text=dr["TableName"].ToString();
                        cmbCategory.Text= dr["ItemCategory"].ToString();
                        textBox1.Text = dr["Barcode"].ToString();
                       
                        // lblsgst.Text = dr["ContactNo"].ToString();

                        id = dr["ChallanNo"].ToString();
                       


                    }
                }
                dr.Close();
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount


                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_DeliveryChallanInner where ID='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    int i = 0;
                    while (dr1.Read())
                    {
                        dgvInnerDeliveryChallanNote.Rows.Add();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["sr_no"].Value = i + 1;
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["txtItem"].Value = dr1["ItemName"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Item_Code"].Value = dr1["ItemCode"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Unit"].Value = dr1["BasicUnit"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["MRP"].Value = dr1["SalePrice"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax"].Value = dr1["TaxForSale"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax_Amount"].Value = dr1["SaleTaxAmount"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount"].Value = dr1["Discount"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount_Amount"].Value = dr1["DiscountAmount"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["FreeQty"].Value = dr1["freeQty"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["Amount"].Value = dr1["ItemAmount"].ToString();
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

        int row = 0;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
           
           
                try {
                if (e.KeyCode == Keys.Enter)
                {
                        float TA = 0, TD = 0, TGST = 0;
                        dgvInnerDeliveryChallanNote.Rows.Add();
                        row = dgvInnerDeliveryChallanNote.Rows.Count - 2;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells["sr_no"].Value = row + 1;
                        dgvInnerDeliveryChallanNote.CurrentCell = dgvInnerDeliveryChallanNote[1, row];

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

                        dgvInnerDeliveryChallanNote.Rows[row].Cells[1].Value = txtItem;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[2].Value = Item_code;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[3].Value = Unit;

                        dgvInnerDeliveryChallanNote.Rows[row].Cells[4].Value = MRP;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[7].Value = qty;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[8].Value = freeqty;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[5].Value = gst;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[9].Value = gst_amt;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[6].Value = dis;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[10].Value = dis_amt;
                        dgvInnerDeliveryChallanNote.Rows[row].Cells[11].Value = Total;

                        txtItemName.Focus();

                        for (int i = 0; i < dgvInnerDeliveryChallanNote.Rows.Count; i++) {
                            TA += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Amount"].Value?.ToString());
                            //   // TD += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                            //   // TGST += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());

                            txtsubtotal.Text = TA.ToString();
                            //    txtTotal.Text = TA.ToString();
                            //  //  txtDisAmt.Text = TD.ToString();
                            //   // txtTaxAMount1.Text = TGST.ToString();
                        }
                    clear_text_data();
                }              
            }
                catch (Exception e1)
            {
                    string message = e1.Message;
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
        }
        private void cleardata()
        {
            cmbpartyname.Text = "";
            txtPartyAdd.Text = "";
            txtBillingName.Text = "";
            txtBillingadd.Text = "";
           
            cmbStatesupply.Text = "";
            cmbPaymentType.Text = "";
            txtTransportName.Text = "";
            txtDeliveryLoc.Text = "";
            txtVehicleNo.Text = "";
           
            txtDescription.Text= "";
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
          //  txtrefNo.Text = "";
            txtadditional1.Text = "";
            txtadditional2.Text = "";
            ComboBox.Text= "";
            Delivery.Text= "";
            cmbCategory.Text= "";
            textBox1.Text = "";
           
        }
        private void update_record_inner(string p)
        {
            for (int i = 0; i < dgvInnerDeliveryChallanNote.Rows.Count; i++) {
                try {
                    con.Open();
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_DeliveryChallanInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id1);

                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerDeliveryChallanNote.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDeliveryChallanNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDeliveryChallanNote.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerDeliveryChallanNote.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerDeliveryChallanNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDeliveryChallanNote.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDeliveryChallanNote.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Action", "Update");

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                con.Open();
                verifydata();
                if (verifyid == 1)
                {
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_DeliveryChallanSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ChallanNo", txtReturnNo.Text);
                    // cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@BillingName", txtBillingName.Text);
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                    cmd.Parameters.AddWithValue("@BillingAddress", txtPartyAdd.Text);
                    cmd.Parameters.AddWithValue("@PartyAddress", txtBillingadd.Text);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoice.Text);
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
                    cmd.Parameters.AddWithValue("@Received", txtReceived.Text);
                    cmd.Parameters.AddWithValue("@RemainingBal", txtBallaance.Text);

                    cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                    cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                    cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                    cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                    cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                    cmd.Parameters.AddWithValue("@TableName", Delivery.Text);

                    cmd.Parameters.AddWithValue("@Action", "Update");

                    id1 = cmd.ExecuteScalar();
                    MessageBox.Show("Sale Record Update");
                }
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
            finally {
                con.Close();
                update_record_inner(txtReturnNo.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            verifydata();
            if (verifyid == 1)
            {
                insertdata();
                bind_sale_details();
                clear_text_data();
                cleardata();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
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

       

        private void cmbpartyname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') and  DeleteData='1' and Company_ID='" + NewCompany.company_id + "' GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtPartyAdd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();


                }
                dr.Close();

                txtBillingName.Focus();
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
        private void fetchCategory()
        {
            if (cmbCategory.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemCategory from tbl_ItemMaster where DeleteData='1' and Company_ID='" + NewCompany.company_id + "' group by ItemCategory  ");
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
        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}' and DeleteData='1' and Company_ID='" + NewCompany.company_id + "'group by ItemName ", cmbCategory.Text);
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
            finally
            {
                //con.Close();
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
                string Query = String.Format("select ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //con.Close();
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void txtBillingName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
