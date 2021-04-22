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
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

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
            fetchitem();
            fetchcustomername();  
            get_id();
            txtReturnNo.Enabled = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            cmbCategory.Visible = false;
            label38.Visible = false;
            seeting();
            if(barcode==1)
            {
                label40.Visible = false;
                textBox1.Visible = false;
            }
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
                    //MessageBox.Show(e1.Message);
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
                  //  MessageBox.Show(e1.Message);
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
                guna2TextBox5.Text = sub_total.ToString();

                dis_amt = sub_total * dis / 100;
                txtDisAmt.Text = dis_amt.ToString();

                gst_amt = sub_total * gst / 100;
                txtTaxAMount1.Text = gst_amt.ToString();

                total = (sub_total + gst_amt) - dis_amt;
                txtItemTotal.Text = total.ToString();
              //  txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
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

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cd = new SqlCommand("Select State from tbl_CompanyMaster where CompanyID='" + NewCompany.company_id + "'", con);
                string State1 = cd.ExecuteScalar().ToString();
                con.Close();
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
                    TxtIGST.Text = gst.ToString();
                    txtsgst.Text = 0.ToString();
                    txtcgst.Text = 0.ToString();

                }


            }
            catch (Exception e1)
            {
               // MessageBox.Show(e1.Message);
            }
        }
        public int verifyid = 0;
     public void verifydata()
        {
            if(cmbpartyname.Text=="")
            {
                MessageBox.Show("Party Name Is Reguerd !");
            }
         else if (cmbPaymentType.Text == "")
            {
                MessageBox.Show(" Please Select Payment Type !");
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


                cmd = new SqlCommand("tbl_DeliveryChallanSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@ChallanNo", txtReturnNo.Text);
              //  cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
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
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Tax1", comboBox3.Text);
                }
                // cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
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
                cmd.Parameters.AddWithValue("@Feild2", txtsubtotal.Text);
                cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Delivery.Text);
                cmd.Parameters.AddWithValue("@CalTotal", textBox6.Text);
                cmd.Parameters.AddWithValue("@TaxShow", textBox3.Text);
                cmd.Parameters.AddWithValue("@Discount", textBox4.Text);

                //  cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ItemCategory", comboBox2.Text);
                }
                cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Record Added Successfully");
                
            }
            catch (Exception e1)
            {
               // MessageBox.Show(e1.Message);
            }
            finally
            {
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
                    cmd = new SqlCommand("tbl_DeliveryChallanInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ChallanNo", id1);

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
                    cmd.Parameters.AddWithValue("@CGST", dgvInnerDeliveryChallanNote.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SGST", dgvInnerDeliveryChallanNote.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@IGST", dgvInnerDeliveryChallanNote.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@CalTotal", dgvInnerDeliveryChallanNote.Rows[i].Cells["CalTotal"].Value.ToString());

                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                   // MessageBox.Show(e1.Message);
                }
                //finally
                //{
                //    con.Close();
                //}
            }
        }

        private void update()
        {
            try
            {
                con.Open();
               
                {
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_DeliveryChallanSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ChallanNo", txtReturnNo.Text);
                    // cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@BillingName", txtBillingName.Text);
                    cmd.Parameters.AddWithValue("@PartyName", comboBox1.Text);
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
                    cmd.Parameters.AddWithValue("@Feild2", txtsubtotal.Text);
                    cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                    cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                    cmd.Parameters.AddWithValue("@TableName", Delivery.Text);
                    cmd.Parameters.AddWithValue("@CalTotal", textBox6.Text);
                    cmd.Parameters.AddWithValue("@TaxShow", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Discount", textBox4.Text);

                    cmd.Parameters.AddWithValue("@Action", "Update");
                    id1 = cmd.ExecuteScalar();
                    MessageBox.Show("Sale Record Update");

                }
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
            }
            finally
            {
                con.Close();
                update_record_inner(txtReturnNo.Text.ToString());
            }
        }
        private void cmbtax_SelectedIndexChanged(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
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
                    txtTotal.Text = total.ToString();
                }
            
            
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
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
               // MessageBox.Show(e1.Message);
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
                cmbCategory.Visible = false;
                comboBox2.Visible =false;
                cmbtax.Visible = false;
                comboBox3.Visible = true;
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

                        txtcon.Text = dr["ContactNo"].ToString();
                        txtVehicleNo.Text = dr["VehicleNumber"].ToString();
                        DtpdeliveryDate.Text = dr["Deliverydate"].ToString();
                        txtDescription.Text = dr["Description"].ToString();
                        comboBox3.Text = dr["Tax1"].ToString();
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
                        txtsubtotal.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Delivery.Text=dr["TableName"].ToString();
                        textBox6.Text = dr["CalTotal"].ToString();
                        textBox3.Text = dr["TaxShow"].ToString();
                        textBox4.Text = dr["Discount"].ToString();
                        //   comboBox2.Text= dr["ItemCategory"].ToString();
                        //textBox1.Text = dr["Barcode"].ToString();

                        // lblsgst.Text = dr["ContactNo"].ToString();

                        id = dr["ChallanNo"].ToString();
                       


                    }
                }
                else
                {
                    MessageBox.Show("Invalid Id !");
                    cleardata();
                    get_id();
                    cmbpartyname.Visible = true;
                    comboBox1.Visible = false;
                }
                dr.Close();
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount


                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount,CGST,SGST,IGST,CalTotal FROM tbl_DeliveryChallanInner where ChallanNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
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
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["CGST"].Value = dr1["CGST"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["SGST"].Value = dr1["SGST"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["IGST"].Value = dr1["IGST"].ToString();
                        dgvInnerDeliveryChallanNote.Rows[i].Cells["CalTotal"].Value = dr1["CalTotal"].ToString();
                        i++;
                    }
                    dr1.Close();
                }
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message);
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
                        float TA = 0, TD = 0, TGST = 0, dis1 = 0, tax = 0, itotal = 0;
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
                    string caltotal = guna2TextBox5.Text;
                    string cgst = guna2TextBox2.Text;
                    string sgst = guna2TextBox3.Text;
                    string igst = guna2TextBox4.Text;

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
                    dgvInnerDeliveryChallanNote.Rows[row].Cells[12].Value = cgst;
                    dgvInnerDeliveryChallanNote.Rows[row].Cells[13].Value = sgst;
                    dgvInnerDeliveryChallanNote.Rows[row].Cells[14].Value = igst;
                    dgvInnerDeliveryChallanNote.Rows[row].Cells[15].Value = caltotal;

                    clear_text_data();
                    txtItemName.Focus();

                    for (int i = 0; i < dgvInnerDeliveryChallanNote.Rows.Count; i++) {
                        dis1 += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                        textBox4.Text = dis1.ToString();
                        tax += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());
                        textBox3.Text = tax.ToString();
                        itotal += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["CalTotal"].Value?.ToString());
                        textBox6.Text = itotal.ToString();
                        TA += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Amount"].Value?.ToString());
                            //   // TD += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                            //   // TGST += float.Parse(dgvInnerDeliveryChallanNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());

                            txtsubtotal.Text = TA.ToString();
                        txtTotal.Text = TA.ToString();
                        //    txtTotal.Text = TA.ToString();
                        //  //  txtDisAmt.Text = TD.ToString();
                        //   // txtTaxAMount1.Text = TGST.ToString();
                    }
                
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
            txtUnit.Text = "";
            txtMRP.Text = "0";
            txtOty.Text = "0";
            txtFreeQty.Text = "0";
            txtTax1.Text = "0";
            txtTaxAMount1.Text = "0";
            txtDis.Text = "0";
            txtDisAmt.Text = "0";
            txtItemTotal.Text = "00";
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
            txtcon.Text = "";
            txtDescription.Text= "";
            cmbtax.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtTaxAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            txtRoundup.Text = "";
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBallaance.Text = "0";
            txtrefNo.Text = "";
            txtsubtotal.Text = "0";
            txtadditional2.Text = "";
            ComboBox.Text= "";
            Delivery.Text= "";
            cmbCategory.Text= "";
            textBox1.Text = "";
            dgvInnerDeliveryChallanNote.Rows.Clear();
            txtsubtotal.Text = "";
            cmbpartyname.Focus();
            txtrefNo.Visible = false;
            cmbtax.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox6.Text = "0";
        }
        private void update_record_inner(string id)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmdn = new SqlCommand("tbl_DeliveryChallanInnersp", con);
            cmdn.CommandType = CommandType.StoredProcedure;
            cmdn.Parameters.AddWithValue("@Action", "Delete");
            cmdn.Parameters.AddWithValue("@ID", txtReturnNo.Text);
            cmdn.ExecuteNonQuery();


            for (int i = 0; i < dgvInnerDeliveryChallanNote.Rows.Count; i++)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_DeliveryChallanInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ChallanNo",txtReturnNo.Text);

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
                    cmd.Parameters.AddWithValue("@ItemTotal", dgvInnerDeliveryChallanNote.Rows[i].Cells["CalTotal"].Value.ToString());
                    cmd.Parameters.AddWithValue("@cgst", dgvInnerDeliveryChallanNote.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sgst", dgvInnerDeliveryChallanNote.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@igst", dgvInnerDeliveryChallanNote.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                   // MessageBox.Show(e1.Message);
                }
                //finally
                //{
                //    con.Close();
                //}
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
            clear_text_data();
            cleardata();
            cmbpartyname.Visible = true;
            comboBox1.Visible = false;
            printdata(txtrefNo.Text.ToString());
            get_id();

            //   dgvInnerDeliveryChallanNote.Rows.Clear();
        }

      


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                verifydata();
                if (verifyid == 1)
                {
                    insertdata();
                    clear_text_data();
                    cleardata();

                    printdata(txtReturnNo.Text.ToString());
                    get_id();
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
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,b.PartyName,b.BillingName,b.ContactNo, b.ChallanNo,b.Deliverydate,b.DeliveryLocation,b.TransportName ,b.BillingAddress  , b.Company_ID,b.InvoiceDate, b.DueDate, b.Tax1, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount , c.CGST, c.SGST,c.IGST FROM tbl_CompanyMaster as a, tbl_DeliveryChallan as b,tbl_DeliveryChallanInner as c where b.ChallanNo='{0}' and c.ChallanNo='{1}' and c.Company_ID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.CompanyID='" + NewCompany.company_id + "' ", id1, id1);
                    //string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,,b.PartyName,b.BillingName,b.ContactNo, b.ChallanNo,b.Deliverydate,b.DeliveryLocation,b.TransportName ,b.BillingAddress  , b.InvoiceDate, b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.IGST, c.CGST, c.SGST,c.ItemAmount FROM tbl_CompanyMaster as a, tbl_DeliveryChallan as b,tbl_DeliveryChallanInner as c where b.ChallanNo='{0}' and c.ChallanNo='{1}' and c.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.CompanyID='" + NewCompany.company_id + "' ", id1,id1);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"DeliveryChallan.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("DeliveryChallan1", "DeliveryChallan1", ds.Tables[0]);

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

               
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message);
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
                    ///MessageBox.Show(e1.Message);
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
              //  MessageBox.Show(ex.Message);
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
                    txtOty.Text = 1.ToString();
                    //txtTaxAMount1.Text = dr["SaleTaxAmount"].ToString();
                    //  txtTaxType.Text = dr["TaxType"].ToString();

                }
                dr.Close();

                //txtOty.Focus();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
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
            else if(cmbPaymentType.SelectedItem == "Cash")
            {
                txtrefNo.Visible = false;
            }
            else if (cmbPaymentType.SelectedItem == "Online Payment")
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

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void buttprint_Click(object sender, EventArgs e)
        {
         
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,b.PartyName,b.BillingName,b.ContactNo, b.ChallanNo,b.Deliverydate,b.DeliveryLocation,b.TransportName ,b.BillingAddress  , b.Company_ID,b.InvoiceDate, b.DueDate, b.Tax1, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount , c.CGST, c.SGST,c.IGST FROM tbl_CompanyMaster as a, tbl_DeliveryChallan as b,tbl_DeliveryChallanInner as c where b.ChallanNo='{0}' and c.ChallanNo='{1}' and c.Company_ID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and a.CompanyID='" + NewCompany.company_id + "' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"DeliveryChallan.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("DeliveryChallan1", "DeliveryChallan1", ds.Tables[0]);

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
            comboBox1.Visible = false;
            get_id();
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
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

        private void cmbPaymentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtDeliveryLoc_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void txtBallaance_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            id = "";
            cmbpartyname.Visible = true;
            comboBox1.Visible = false;
            cleardata();
            clear_text_data();
            get_id();
        }

        private void txtDisAmount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

        private void cmbtax_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cal_Total();
            gst_devide();

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
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
          
        }

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {
            //cal_Total();
            //gst_devide();
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

        private void dgvInnerDeliveryChallanNote_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtItemName.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["txtItem"].Value.ToString();
            txtUnit.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
            txtItemCode.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Item_Code"].Value.ToString();
            txtMRP.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["MRP"].Value.ToString();
            txtTax1.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Tax"].Value.ToString();
            txtTaxAMount1.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Tax_Amount"].Value.ToString();
            txtOty.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
            txtFreeQty.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["FreeQty"].Value.ToString();
            txtDis.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
            txtDisAmt.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Discount_Amount"].Value.ToString();
            txtItemTotal.Text = dgvInnerDeliveryChallanNote.Rows[e.RowIndex].Cells["Amount"].Value.ToString();

            //int row = dgvInnerDeliveryChallanNote.CurrentCell.RowIndex;
            //dgvInnerDeliveryChallanNote.Rows.RemoveAt(row);
        }

        private void txtDisAmt_TextChanged(object sender, EventArgs e)
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
        private void panel1_Paint(object sender, PaintEventArgs e)
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
                    txtOty.Focus();
                    //txtTaxAMount1.Text = dr["SaleTaxAmount"].ToString();
                    //  txtTaxType.Text = dr["TaxType"].ToString();

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                clear_text_data();
                //guna2TextBox2.Text = "";
            }
            else
            {
                fetchBarcode();
            }
          
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

        private void dgvInnerDeliveryChallanNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Delivery_TextChanged(object sender, EventArgs e)
        {

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

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtItemTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }
    }
    }

