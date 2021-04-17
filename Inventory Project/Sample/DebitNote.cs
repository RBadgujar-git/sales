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
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace sample
{
    public partial class DebitNote : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public DebitNote()
        {
            InitializeComponent();
            //con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void fetchdetails()
        {
            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {

                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount
                con.Open();
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_DebitNoteInnersp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ItemName", dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value?.ToString());
                cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value?.ToString());
                cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value?.ToString());
                cmd.Parameters.AddWithValue("@Qty", dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value?.ToString());
                cmd.Parameters.AddWithValue("@freeQty", dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value?.ToString());
                cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value?.ToString());
                cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value?.ToString());
                cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());
                ////cmd.Parameters.AddWithValue("@TaxType", dgvInnerDebiteNote.Rows[i].Cells["TaxType"].Value?.ToString());
                cmd.Parameters.AddWithValue("@Discount", dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value?.ToString());
                cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());

                cmd.Parameters.AddWithValue("@Action", "Select");
                con.Close();

            }

        }
        private void fetchCategory()
        {
        //    if (cmbCategory.Text != "System.Data.DataRowView")
        //    {
        //        try
        //        {
        //            string SelectQuery = string.Format("select ItemCategory from tbl_ItemMaster where DeleteData='1' and Company_ID='" + NewCompany.company_id + "' group by ItemCategory");
        //            DataSet ds = new DataSet();
        //            SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
        //            SDA.Fill(ds, "Temp");
        //            DataTable DT = new DataTable();
        //            SDA.Fill(ds);
        //            for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
        //                cmbCategory.Items.Add(ds.Tables["Temp"].Rows[i]["ItemCategory"].ToString());
        //            }
        //        }
        //        catch (Exception e1) {
        //         //   MessageBox.Show(e1.Message);
        //        }
          // }
        }

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
                //    MessageBox.Show(e1.Message);
                }
            }
        }




        private void fetchcustomername()
        {
            if (cmbpartyname.Text != "System.Data.DataRowView") {
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
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void DebitNote_Load(object sender, EventArgs e)
        {
            
            //bind_sale_details();
            cmbpartyname1.Visible = false;
           // comboBox1.Visible = false;
            txtTotal.Enabled = false;
            txtBallaance.Enabled = false;
            txtsubtotal.Enabled = false;
            cmbpartyname.Focus(); 
            fetchcustomername();
         //   fetchCategory();
            fetchitem1();
            txtReturnNo.Enabled = false;
            get_id();
        }

        private void txtFreeQty_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();


        }
        public void cal_ItemTotal()
        {
           
                try
                {
                    float qty = 0, freeqty = 0, rate = 0, sub_total = 0, dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0;

                if (txtOty.Text == "") { txtOty.Text = "0"; }
                else if (txtFreeQty.Text == "") { txtFreeQty.Text = "0"; }
                else if (txtMRP.Text == "") { txtMRP.Text = "0"; }
                else if (txtDis.Text == "") { txtDis.Text = "0"; }
                else if (txtTax1.Text == "") { txtTax1.Text = "0"; }

                    qty = float.Parse(txtOty.Text.ToString());
                    freeqty = float.Parse(txtFreeQty.Text.ToString());
                //            rate = float.Parse(txtMRP.Text.ToString());
                rate = Convert.ToInt32(txtMRP.Text);
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
                
                }
                catch(Exception ew)
                {
              //      MessageBox.Show(ew.Message);
                }
            
           
        }

        private void txtMRP_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtDisAmt_TextChanged(object sender, EventArgs e)
        {
            // cal_ItemTotal();
        }

        private void txtTaxAMount1_TextChanged(object sender, EventArgs e)
        {
            //cal_ItemTotal();
        }

        private void txtOty_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }
        private void gst_devide()
        {
            try {

                //  con.Open();
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
            catch (Exception e1) {
               // MessageBox.Show(e1.Message);
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
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_DebitNoteInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@returnNo",id);
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
                    cmd.Parameters.AddWithValue("@ItemID", dgvInnerDebiteNote.Rows[i].Cells["ItemIDDD"].Value.ToString());
                    cmd.Parameters.AddWithValue("@cgst", dgvInnerDebiteNote.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sgst", dgvInnerDebiteNote.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@igst", dgvInnerDebiteNote.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@itemtotal", dgvInnerDebiteNote.Rows[i].Cells["CalTotal"].Value.ToString());

                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.Parameters.AddWithValue("@Deletedata",'1');

                    String ItemName = dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value.ToString();
                    float cureentstock = Convert.ToInt32(dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());
                    float freeqty = Convert.ToInt32(dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    float Itemid = Convert.ToInt32(dgvInnerDebiteNote.Rows[i].Cells["ItemIDDD"].Value.ToString());

                    ////   MessageBox.Show("Data " + ItemCode + "Data2" + cureentstock);


                    SqlCommand cmd1 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Action", "backget");
                    cmd1.Parameters.AddWithValue("@Itemcode", ItemName);
                    cmd1.Parameters.AddWithValue("@ItemID", Itemid);
                    float prestock = Convert.ToInt32(cmd1.ExecuteScalar());

                    //   float freeqty = float.Parse(txtFreeQty.Text);
                    float stockmangee = prestock - cureentstock + freeqty;

                    SqlCommand cmd2 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                    cmd2.Parameters.AddWithValue("@stock", stockmangee);
                    cmd2.Parameters.AddWithValue("@Itemcode", ItemName);
                    cmd2.Parameters.AddWithValue("@ItemID", Itemid);
                    cmd2.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                   MessageBox.Show(e1.Message);
                }
                finally {
                  //  con.Close();
                }
            }
        }

        byte[] arrImage1;

        private void insertdata()
        {
            try {
                //    con.Open();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = string.Format("insert into tbl_DebitNote(InvoiceNo,PONumber,PartyName, BillingName,  PODate, InvoiceDate, DueDate, StateofSupply, PaymentType, TransportName, DeliveryLocation, VehicleNumber, Deliverydate, Description, Tax1, CGST, SGST, TaxAmount1, TotalDiscount, DiscountAmount1, RoundFigure, Total, Received, RemainingBal, ContactNo, Feild1, Feild2, Feild3, Status, TableName, Barcode,Company_ID,IGST,CalTotal,TaxShow,Discount) Values (@InvoiceNo, @PONumber, @PartyName, @BillingName, @PODate, @InvoiceDate, @DueDate, @StateofSupply,  @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description,  @Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Received, @RemainingBal,@ContactNo, @Feild1, @Feild2, @Feild3,@Status, @TableName, @Barcode,@compid,@IGST,@caltotal,@taxshow,@discount);SELECT SCOPE_IDENTITY();");
                SqlCommand cmd = new SqlCommand(query, con);

                //DataTable dtable = new DataTable();
                //cmd = new SqlCommand("tbl_DebitNoteSelect", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Action", "Insert");
                //cmd.Parameters.AddWithValue("@ReturnNo", txtReturnNo.Text);
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname1.Text);
                }
                cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                cmd.Parameters.AddWithValue("@PONumber", txtPONo.Text);
              //  cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
               
                cmd.Parameters.AddWithValue("@PODate", dtpPODate.Text);
                //cmd.Parameters.AddWithValue("@PODate", dtpPODate.Text);
               
                cmd.Parameters.AddWithValue("@InvoiceDate",dtpInvoice.Text);
                
                cmd.Parameters.AddWithValue("@DueDate",dtpDueDate.Text);
                cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                cmd.Parameters.AddWithValue("@TransportName", txtTransportName.Text);
                cmd.Parameters.AddWithValue("@DeliveryLocation", txtDeliveryLoc.Text);
                cmd.Parameters.AddWithValue("@VehicleNumber", txtVehicleNo.Text);            
                cmd.Parameters.AddWithValue("@Deliverydate",DtpdeliveryDate.Text );
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
                cmd.Parameters.AddWithValue("@TableName", Debit.Text);
                cmd.Parameters.AddWithValue("@Barcode", cmbbarcode.Text);                                        
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                cmd.Parameters.AddWithValue("@IGST",TxtIGST.Text);
                cmd.Parameters.AddWithValue("@caltotal",textBox6.Text);

                cmd.Parameters.AddWithValue("@taxshow", textBox3.Text);
                cmd.Parameters.AddWithValue("@discount", textBox4.Text);
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Debit Record Added");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally {
              //  con.Close();
            
                    insert_record_inner(id1.ToString());
                 
            }
        }


        private void cmbtax_SelectedIndexChanged(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
        }

        private void cmbtax_TextChanged(object sender, EventArgs e)
        {
            //    gst_devide();
            //    cal_Total();
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
                string Query = String.Format("select ItemID,ItemName,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where Barcode='" + cmbbarcode.Text + "' and Company_ID='" + NewCompany.company_id + "'  and DeleteData='1'");
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    guna2TextBox1.Text = dr["ItemID"].ToString();

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
        public float TA;
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

            clear_text_data();
        }
        int row = 0, dublication,ip;
       String itemid11;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
           
            try {

               

                    if (e.KeyCode == Keys.Enter) {

                    insertitem();
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
                        string caltotal = guna2TextBox5.Text;
                        string cgst = guna2TextBox2.Text;
                        string sgst = guna2TextBox3.Text;
                        string igst = guna2TextBox4.Text;
                        if (guna2TextBox1.Text == "")
                        {
                            itemid11 = itemid1;
                        }
                        else
                        {
                            itemid11 = guna2TextBox1.Text;
                        }


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
                        dgvInnerDebiteNote.Rows[row].Cells[12].Value = itemid11;
                        dgvInnerDebiteNote.Rows[row].Cells[13].Value = cgst;
                        dgvInnerDebiteNote.Rows[row].Cells[14].Value = sgst;
                        dgvInnerDebiteNote.Rows[row].Cells[15].Value = igst;
                        dgvInnerDebiteNote.Rows[row].Cells[16].Value = caltotal;
                        //   txtItemName.Focus();
                        guna2TextBox1.Text = "";
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
                        }

                        guna2TextBox1.Text = "";
                    }
                  //  clear_text_data();
                }
            }
            catch (Exception e1) {
                string message = e1.Message;
            }
        }
        public int chekpoint = 0;
        public string itemid1;

        public void insertitem()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                chekpoint = 0;
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
                    string query = string.Format("insert into tbl_ItemMaster(ItemName, BasicUnit, ItemCode, SalePrice, TaxForSale,Company_ID) Values ('" + txtItemName.Text + "', '" + txtUnit.Text + "','" + txtItemCode.Text + "', " + txtMRP.Text + ",'" + txtTax1.Text + "'," + NewCompany.company_id + ")");
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    string Query1 = String.Format("select ItemID from tbl_ItemMaster where ItemName='" + txtItemName.Text + "' and  DeleteData ='1' and Company_ID='" + NewCompany.company_id + "'");
                    SqlCommand cmd1 = new SqlCommand(Query1, con);
                    itemid1 = cmd1.ExecuteScalar().ToString();
                    guna2TextBox1.Text = "";
                }
            }
            catch (Exception e1)

            {
                // MessageBox.Show(e1.Message);
            }
        }

        private void clear_text_data()
        {
            txtItemName.Text = "";
            txtItemCode.Text = "0";
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
            txtInvoiceNo.Text = "";
            cmbpartyname.Text = "";
            txtbillingadd.Text = "";
            txtPONo.Text = "";
            dtpPODate.Text = "";
            dtpInvoice.Text = "";
            dtpDueDate.Text = "";
            cmbStatesupply.Text = "";
            cmbPaymentType.Text = "";
            txtTransportName.Text = "";
            txtDeliveryLoc.Text = "";
            txtVehicleNo.Text = "";
            DtpdeliveryDate.Text = "";
            txtDescription.Text = "";
          //  cmbtax.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtTaxAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            txtRoundup.Text = "0";
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBallaance.Text = "0";
            txtrefNo.Text = "";
            txtadditional1.Text = "";
            txtadditional2.Text = "";
            ComboBox.Text = "";
            Debit.Text = "0";
            txtcon.Text = "";
            cmbbarcode.Text = "";
            //cmbCategory.Text = "";
            txtsubtotal.Text = "0";
            cmbtax.Text = "0";
            TxtIGST.Text = "";
            dgvInnerDebiteNote.Rows.Clear();

        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        public int verfy = 0;

        public void verfydata()
        {
              
            if (txtcon.Text == "")
            {
                MessageBox.Show("Party Contact no Is Requueird !");
                txtcon.Focus();
            }
            else if (txtPONo.Text == "")
            {
                MessageBox.Show("Party PONO Is Requueird !");
                txtcon.Focus();
            }      
            else if (txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Party Invoice No Is Requueird !");
                txtInvoiceNo.Focus();
            }
            else if (cmbPaymentType.Text == "")
            {
                MessageBox.Show("Please Select Payment Type !");
            }
            else
            {
                verfy = 1;
            }
        }
        private void update_record_inner(string p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmdn = new SqlCommand("tbl_DebitNoteInnersp", con);
            cmdn.CommandType = CommandType.StoredProcedure;
            cmdn.Parameters.AddWithValue("@Action", "inserdelete");
            cmdn.Parameters.AddWithValue("@returnNo", txtReturnNo.Text);
            cmdn.ExecuteNonQuery();

            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {
                try
                {
                   
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_DebitNoteInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@returnNo", id);
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
                    cmd.Parameters.AddWithValue("@ItemID", dgvInnerDebiteNote.Rows[i].Cells["ItemIDDD"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Deletedata",1);
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id); 


                    //string intemcode = dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString();
                    //float qty1 = float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());


                    //SqlCommand cmd1 = new SqlCommand("Select Qty from tbl_DebitNoteInner where ItemCode='" + intemcode + "' and ReturnNo='" + txtReturnNo.Text + "' ", con);
                    //float existingQty = Convert.ToInt32(cmd1.ExecuteScalar());


                    //SqlCommand cmdb = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    //cmdb.CommandType = CommandType.StoredProcedure;
                    //cmdb.Parameters.AddWithValue("@Action", "backget");
                    //cmdb.Parameters.AddWithValue("@Itemcode", intemcode);
                    //float prestock = Convert.ToInt32(cmdb.ExecuteScalar());

                    //if (existingQty > qty1)
                    //{
                    //    float finalqty = existingQty - qty1;
                    //    float stockmange = prestock + finalqty;

                    //    SqlCommand cmd2 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    //    cmd2.CommandType = CommandType.StoredProcedure;
                    //    cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                    //    cmd2.Parameters.AddWithValue("@stock", stockmange);
                    //    cmd2.Parameters.AddWithValue("@Itemcode", intemcode);
                    //    cmd2.ExecuteNonQuery();

                    //}
                    //else if (existingQty < qty1)
                    //{

                    //    float finalqty = qty1 - existingQty;
                    //    float stockmange = prestock - finalqty;
                    //    SqlCommand cmd2 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    //    cmd2.CommandType = CommandType.StoredProcedure;
                    //    cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                    //    cmd2.Parameters.AddWithValue("@stock", stockmange);
                    //    cmd2.Parameters.AddWithValue("@Itemcode", intemcode);
                    //    cmd2.ExecuteNonQuery();

                    //}

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                   // con.Close();
                   

                }

            }
            fetchcustomername();
            get_id();
            cmbpartyname1.Visible = false;
            cmbpartyname.Visible = true;
            cleardata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string str = string.Format("SELECT * FROM tbl_DebitNote where ReturnNo='{0}' and Company_ID='" + NewCompany.company_id + "'", txtReturnNo.Text);
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                try
                {


                  verfydata();
                   
                    if (verfy == 1)
                    {
                    
                        //      con.Open();
                        DataTable dtable = new DataTable();
                        cmd = new SqlCommand("tbl_DebitNoteSelect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ReturnNo", txtReturnNo.Text);
                        cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                        cmd.Parameters.AddWithValue("@PONumber", txtPONo.Text);
                        cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                        cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                        DateTime now1 = DateTime.Today;
                        cmd.Parameters.AddWithValue("@PODate", now1.ToShortDateString());
                        cmd.Parameters.AddWithValue("@InvoiceDate", now1.ToShortDateString());
                        cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Text);
                        cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                        cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                        cmd.Parameters.AddWithValue("@TransportName", txtTransportName.Text);
                        cmd.Parameters.AddWithValue("@DeliveryLocation", txtDeliveryLoc.Text);
                        cmd.Parameters.AddWithValue("@VehicleNumber", txtVehicleNo.Text);
                        cmd.Parameters.AddWithValue("@Deliverydate", now1.ToShortDateString());
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
                        cmd.Parameters.AddWithValue("@TableName", Debit.Text);
                        cmd.Parameters.AddWithValue("@Barcode", cmbbarcode.Text);
                        //cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("@Action", "Update");
                        dr.Close();
                        id1 = cmd.ExecuteScalar();
                        MessageBox.Show("Sale Record Update");
                    }
                
                }
                catch (Exception e1)
                {
                  //  MessageBox.Show(e1.Message);
                }
                finally
                {
                    //    con.Close();
                    dr.Close();
                    update_record_inner(txtReturnNo.ToString());
                }
            }

            else
            {
                dr.Close();
                MessageBox.Show("Data Invalid !");
            }

        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                verfydata();
                if (verfy == 1)
                {
                        insertdata();
                    print();
                    //  bind_sale_details();
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
        private void print()
        { 
        if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
        string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address,a.AddLogo,a.GSTNumber, a.PhoneNo, a.EmailID,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,b.PartyName,b.BillingName,b.ContactNo, b.ReturnNo, b.InvoiceDate, b.DeliveryLocation,b.DeliveryDate,b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.ItemCode,c.BsicUnit,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount,c.DeleteData FROM tbl_CompanyMaster  as a, tbl_DebitNote as b,tbl_DebitNoteInner as c where b.ReturnNo='{0}' and c.ReturnNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' and c.DeleteData='1' ", txtReturnNo.Text, txtReturnNo.Text);
        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
        SDA.Fill(ds);

                    StiReport report = new StiReport();
        report.Load(@"DebitNoteReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
        report.RegData("DebitNote", "DebitNote", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ew)
                {
                    // MessageBox.Show(ew.Message);
                }
                get_id();
                cleardata();
cmbpartyname1.Visible = false;
                cmbpartyname.Visible = true;

            }
        }

        private void txtDis_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtTax1_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
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
        private void bind_sale_details()
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string str = string.Format("SELECT * FROM tbl_DebitNote where ReturnNo='{0}' and Company_ID='" + NewCompany.company_id + "'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);               
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                        cmbpartyname1.Text = dr["PartyName"].ToString();
                        txtbillingadd.Text = dr["BillingName"].ToString();
                        txtPONo.Text = dr["PONumber"].ToString();
                        dtpPODate.Text = dr["PODate"].ToString();
                        dtpInvoice.Text = dr["InvoiceDate"].ToString();
                        dtpDueDate.Text = dr["DueDate"].ToString();
                        cmbStatesupply.Text = dr["StateofSupply"].ToString();
                        cmbPaymentType.Text = dr["PaymentType"].ToString();
                        txtTransportName.Text = dr["TransportName"].ToString();
                        txtDeliveryLoc.Text = dr["DeliveryLocation"].ToString();
                        txtVehicleNo.Text = dr["VehicleNumber"].ToString();
                        DtpdeliveryDate.Text = dr["Deliverydate"].ToString();
                        txtDescription.Text = dr["Description"].ToString();
                     //   cmbtax.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                        txtTaxAmount.Text = dr["TaxAmount1"].ToString();
                        txtDiscount.Text = dr["TotalDiscount"].ToString();
                        txtDisAmount.Text = dr["DiscountAmount1"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();
                        txtTotal.Text = dr["Total"].ToString();
                        //, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , 
                        txtsubtotal.Text = dr["Feild2"].ToString();
                        txtTotal.Text = dr["Total"].ToString();
                        txtReceived.Text = dr["Received"].ToString();
                        txtBallaance.Text = dr["RemainingBal"].ToString();
                        txtrefNo.Text = dr["Feild1"].ToString();
                        //txtadditional1.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Debit.Text = dr["TableName"].ToString();
                        txtcon.Text = dr["ContactNo"].ToString();
                        cmbbarcode.Text = dr["Barcode"].ToString();
                    

                        //  comboBox1.Text = dr["ItemCategory"].ToString();
                        id = dr["ReturnNo"].ToString();
                       
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Return !");
                    dgvInnerDebiteNote.Rows.Clear();

                }
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount
                dr.Close();

                string str1 = string.Format("SELECT ID,ItemID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_DebitNoteInner where ReturnNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows) {
                    int i = 0;
                    while (dr1.Read())
                    {
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
                        dgvInnerDebiteNote.Rows[i].Cells["ItemIDDD"].Value = dr1["ItemID"].ToString();        
                        i++;
                        
                    }
                    dr1.Close();
                }
                dr1.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
               // con.Close();
            }
        }

        private void get_id()
        {
            if (txtReturnNo.Text != "0" || txtReturnNo.Text != "") {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                // SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

                con.Open();
                SqlCommand cmd = new SqlCommand("select MAX (CAST( ReturnNo as INT)) from tbl_DebitNote", con);
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
                cmbpartyname1.Visible = true;
                //cmbCategory.Visible = false;
                //comboBox1.Visible = true;
                
                bind_sale_details();
            }
        }

        private void txtsgst_TextChanged(object sender, EventArgs e)
        {
            
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
               // txtsubtotal.Text = total.ToString();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Data"+ee);
            
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

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void picImage_Click(object sender, EventArgs e)
        {
         
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

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();
            //    }

            //    string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}' and Company_ID='" + NewCompany.company_id + "' group by ItemName", cmbCategory.Text);
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            //    SDA.Fill(ds, "Temp");
            //    DataTable DT = new DataTable();
            //    SDA.Fill(ds);
            //    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
            //    {
            //        txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            ////finally
            ////{
            ////    con.Close();
            //}
        }

        private void cmbpartyname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') and Company_ID='" + NewCompany.company_id + "' GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtbillingadd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();
                }
                dr.Close();

               // txtPONo.Focus();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice TaxForSale ,SaleTaxAmount
                string Query = String.Format("select ItemID,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY ItemID,ItemCode, BasicUnit, SalePrice,TaxForSale ", txtItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    guna2TextBox1.Text= dr["ItemID"].ToString();
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                    txtOty.Text = 1.ToString();
                    //txtTaxAMount1.Text = dr["SaleTaxAmount"].ToString();
                    //  txtTaxType.Text = dr["TaxType"].ToString();

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {



        }

        private void txtcgst_TextChanged(object sender, EventArgs e)
        {

        }

        private void DebitNote_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvInnerDebiteNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address,a.AddLogo,a.GSTNumber, a.PhoneNo, a.EmailID,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,b.PartyName,b.BillingName,b.ContactNo, b.ReturnNo, b.InvoiceDate, b.DeliveryLocation,b.DeliveryDate,b.DueDate, b.Tax1, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.ItemCode,c.BasicUnit,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount,c.DeleteData,c.SGST,c.IGST,c.CGST,c.SaleTaxAmount,c.TaxForSale FROM tbl_CompanyMaster  as a, tbl_DebitNote as b,tbl_DebitNoteInner as c where b.ReturnNo='{0}' and c.ReturnNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' and c.DeleteData='1' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"DebitNoteReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("DebitNote", "DebitNote", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ew)
                {
                    MessageBox.Show(ew.Message);
                }
                get_id();
                cleardata();
                cmbpartyname1.Visible = false;
                cmbpartyname.Visible = true;

            }
        }
        private void txtItemTotal_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }
        public void fetchitem1()
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
                    // MessageBox.Show(e1.Message);
                }
            }
        }

        private void dgvInnerDebiteNote_DoubleClick(object sender, EventArgs e)
        {

            txtItemName.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[1].Value.ToString();
            txtItemCode.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[2].Value.ToString();
            txtUnit.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[3].Value.ToString();
            txtMRP.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[4].Value.ToString();
            txtDis.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[5].Value.ToString();
            txtTax1.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[6].Value.ToString();
            txtOty.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[7].Value.ToString();
            txtFreeQty.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[8].Value.ToString();
            txtDisAmt.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[9].Value.ToString();
            txtTaxAmount.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[10].Value.ToString();
            txtItemTotal.Text = this.dgvInnerDebiteNote.CurrentRow.Cells[11].Value.ToString();

            int row = dgvInnerDebiteNote.CurrentCell.RowIndex;
            dgvInnerDebiteNote.Rows.RemoveAt(row);
            //float TA=0;
            //for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
            //{
            //    TA += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());
            //    txtsubtotal.Text = TA.ToString();
            //}

            }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
            clear_text_data();
            cmbpartyname1.Visible = false;
            cmbpartyname.Visible =true ;
            get_id();
         
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

        private void cmbpartyname1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbStatesupply_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
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

        private void cmbPaymentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
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

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void TxtIGST_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDisAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTax1_TextChanged_1(object sender, EventArgs e)
        {
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

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void cmbbarcode_TextChanged(object sender, EventArgs e)
        {
            if (cmbbarcode.Text == "")
            {
                clear_text_data();
                guna2TextBox1.Text = "";
            }
            else
            {
                fetchBarcode();
            }
        }

        private void cmbpartyname1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
