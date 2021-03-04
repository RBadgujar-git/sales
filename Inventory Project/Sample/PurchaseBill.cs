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
    public partial class PurchaseBill : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public PurchaseBill()
        {
            InitializeComponent();
          //  con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void PurchaseBill_Load(object sender, EventArgs e)
        {
            fetchitem();
            fetchcustomername();
            bind_sale_details();
            txtReturnNo.Enabled = false;
            get_id();
            txtsubtotal.Enabled = false;
            txtTotal.Enabled = false;
        }
        private void fetchdetails()
        {
            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_PurchaseBillInnersp", con);
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
               // con.Close();

            }

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

        // PartyName ,PONo,BillDate,PODate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation,
        //    VehicleNumber,Deliverydate,Description,TransportCharges,Image,Tax1,TaxAmount1 ,TotalDiscount ,DiscountAmount1 ,RoundFigure ,Total, Paid, RemainingBal, PaymentTerms, Feild1,Feild2,Feild3,Feild4,Feild5
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbpartyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    txtbillingadd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();


                }
                dr.Close();

                txtPONo.Focus();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                // con.Close();
            }
        }

        private void txtItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice TaxForSale ,SaleTaxAmount
                string Query = String.Format("select ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') GROUP BY ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
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
                MessageBox.Show(ex.Message);
            }
            finally {
                //con.Close();
            }
        }

        public void cal_ItemTotal()
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
            txtsubtotal.Text= total.ToString();
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
        int row = 0;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyCode == Keys.Enter) {
                    float TA = 0, TD = 0, TGST = 0;
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

                    txtItemName.Focus();

                    for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {
                        TA += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());
                        //   // TD += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                        //   // TGST += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());

                        txtsubtotal.Text = TA.ToString();
                        //    txtTotal.Text = TA.ToString();
                        //  //  txtDisAmt.Text = TD.ToString();
                        //   // txtTaxAMount1.Text = TGST.ToString();
                    }
                    Clear_Text_data();
                }
            }
            catch (Exception e1) {
                string message = e1.Message;
            }
        }
       


    
    private void get_id()
        {
            if (txtReturnNo.Text != "0" || txtReturnNo.Text != "") {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                // SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select MAX (CAST( BillNo as INT)) from tbl_PurchaseBill", con);
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
               // con.Close();
            }
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
        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {
                try {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);

                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount

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

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                  //  con.Close();
                }
            }
        }

        private void Clear_Text_data()
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
            txtbillingadd.Text = "";
            txtcon.Text = "";
            txtPONo.Text = "";
            txtReturnNo.Text = "";
            cmbPaymentTrems.Text = "";
            cmbStatesupply.Text = "";
            cmbPaymentType.Text = "";
            txtDescription.Text = "";
            txtTransportName.Text = "";
            txtDeliveryLoc.Text = "";
            txtVehicleNo.Text = "";
            picImage.Image = null;
            txtrefNo.Text = "";
            txtadditional1.Text = "";
            txtadditional2.Text = "";
            txtsubtotal.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            cmbtax.Text = "";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtTaxAmount.Text = "0";
            txtRoundup.Text = "0";
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBallaance.Text = "0";
            ComboBox.Text = "";
            Purchase.Text = "";
        }
        private void insertdata()
        {
            try {

                // PartyName ,PONo,BillDate,PODate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation,VehicleNumber,Deliverydate,Description,TransportCharges,Image,Tax1,TaxAmount1 ,TotalDiscount 
                //    ,DiscountAmount1 ,RoundFigure ,Total, Paid, RemainingBal, PaymentTerms, Feild1,Feild2,Feild3,Feild4,Feild5
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MemoryStream ms = new MemoryStream();
                picImage.Image.Save(ms, picImage.Image.RawFormat);
                byte[] arrImage1 = ms.GetBuffer();

                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_PurchaseBillselect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@BillNo", txtReturnNo.Text);
               // cmd.Parameters.AddWithValue("@InvoiceNo", .Text);
                cmd.Parameters.AddWithValue("@PONo", txtPONo.Text);
                cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                cmd.Parameters.AddWithValue("@PODate", dtpPODate.Text);
                cmd.Parameters.AddWithValue("@BillDate", dtpInvoice.Text);
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
                cmd.Parameters.AddWithValue("@PaymentTerms", cmbPaymentTrems.Text);

                cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Purchase.Text);
                cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Sale Record Added");
                cleardata();
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
            finally {
                //con.Close();
                insert_record_inner(id.ToString());
            }
        }

        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                string str = string.Format("SELECT * FROM tbl_PurchaseBill where BillNo ='{0}'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                { 

                while (dr.Read())
                    {

                        // PartyName,BillingName,ContactNo,PONo,BillDate,PODate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation
                        //,VehicleNumber,Deliverydate,Description,TransportCharges,Image,Tax1,TaxAmount1 ,TotalDiscount
                        //,DiscountAmount1 ,RoundFigure ,Total, Paid, RemainingBal, PaymentTerms, Feild1,Feild2,Feild3,Feild4,Feild5
                        //  txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                        cmbpartyname.Text = dr["PartyName"].ToString();
                        txtbillingadd.Text = dr["BillingName"].ToString();
                        txtcon.Text = dr["ContactNo"].ToString();
                        txtPONo.Text = dr["PONo"].ToString();
                        dtpInvoice.Text = dr["BillDate"].ToString();
                        dtpPODate.Text = dr["PoDate"].ToString();

                       
                        dtpDueDate.Text = dr["DueDate"].ToString();
                        cmbStatesupply.Text = dr["StateofSupply"].ToString();
                        cmbPaymentType.Text = dr["PaymentType"].ToString();
                        txtTransportName.Text = dr["TransportName"].ToString();
                        txtDeliveryLoc.Text = dr["DeliveryLocation"].ToString();


                        txtVehicleNo.Text = dr["VehicleNumber"].ToString();
                        DtpdeliveryDate.Text = dr["Deliverydate"].ToString();
                       
                        txtDescription.Text = dr["Description"].ToString();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);
                            ms.Seek(0, SeekOrigin.Begin);
                            picImage.Image = Image.FromStream(ms); ;
                            picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        cmbtax.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                        txtTaxAmount.Text = dr["TaxAmount1"].ToString();
                        txtDiscount.Text = dr["TotalDiscount"].ToString();
                        txtDisAmount.Text = dr["DiscountAmount1"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();
                        txtRoundup.Text = dr["Total"].ToString();
                        
                        //, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , 

                        txtReceived.Text = dr["Paid"].ToString();
                        txtBallaance.Text = dr["RemainingBal"].ToString();
                        cmbPaymentTrems.Text = dr["PaymentTerms"].ToString();
                        txtrefNo.Text = dr["Feild1"].ToString();
                        txtadditional1.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Purchase.Text = dr["TableName"].ToString();

                        id = dr["id"].ToString();
                       
                    }
                }
               
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount


                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_PurchaseBillInner where ID='{0}'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                dr.Close();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    int i = 0;
                    while (dr1.Read())
                    {
                        dgvInnerDebiteNote.Rows.Add();
                        dgvInnerDebiteNote.Rows[i].Cells["ID"].Value = i + 1;
                        dgvInnerDebiteNote.Rows[i].Cells["ItemName"].Value = dr1["txtItem"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["ItemCode"].Value = dr1["Item_Code"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["BasicUnit"].Value = dr1["Unit"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["SalePrice"].Value = dr1["MRP"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["TaxForSale"].Value = dr1["Tax"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["SaleTaxAmount"].Value = dr1["Tax_Amount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value = dr1["Discount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["DiscountAmount"].Value = dr1["Discount_Amount"].ToString();

                        dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["freeQty"].Value = dr1["FreeQty"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["ItemAmount"].Value = dr1["Amount"].ToString();


                        i++;
                    }
                    dr1.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                //con.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void update_record_inner(string p)
        {
            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {
                try {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id1);

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
                    cmd.Parameters.AddWithValue("@Action", "Update");

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                  //  con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                MemoryStream ms = new MemoryStream();
                picImage.Image.Save(ms, picImage.Image.RawFormat);
                byte[] arrImage1 = ms.GetBuffer();
                 DataTable dtable = new DataTable();
                 cmd = new SqlCommand("tbl_PurchaseBillselect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillNo", txtReturnNo.Text);
                // cmd.Parameters.AddWithValue("@InvoiceNo", .Text);
                cmd.Parameters.AddWithValue("@PONo", txtPONo.Text);
                cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                cmd.Parameters.AddWithValue("@PODate", dtpPODate.Text);
                cmd.Parameters.AddWithValue("@BillDate", dtpInvoice.Text);
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
                cmd.Parameters.AddWithValue("@PaymentTerms", cmbPaymentTrems.Text);

                cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Purchase.Text);
                cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                cmd.Parameters.AddWithValue("@Action", "Update");

                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Sale Record Update");
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
            finally {
               // con.Close();
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

        private void cmbtax_SelectedIndexChanged(object sender, EventArgs e)
        {
            cal_Total();
            gst_devide();
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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertdata();
            bind_sale_details();
            Clear_Text_data();
            cleardata();

        }

        private void btnlinkPayment_Click(object sender, EventArgs e)
        {

        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPaymentType.SelectedItem == "Cheque")
            {
                txtrefNo.Visible = true;
            }
            else if (cmbPaymentType.SelectedItem == "Cash")
            {
                txtrefNo.Visible = false;
            }
        }

        byte[] arrImage1;
        private void picImage_Click(object sender, EventArgs e)
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
                        picImage.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        picImage.Image.Save(ms, picImage.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
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
                cleardata();
            }
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            cleardata();
        }
    }
    }

