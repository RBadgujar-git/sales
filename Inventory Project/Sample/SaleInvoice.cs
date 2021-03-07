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

namespace sample
{
    public partial class SaleInvoice : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        string id = "";
        public SaleInvoice()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void SaleInvoice_Load(object sender, EventArgs e)
        {
            fetchcustomername();
          //  fetchitem();
            fetchCategory();
            txtReturnNo.Enabled = false;
            get_id();
          //  bind_sale_details();

            cmbpartyname1.Visible = false;

            txtTotal.Enabled = false;
            txtBallaance.Enabled = false;
            txtsubtotal.Enabled = false;
            cmbpartyname.Focus();

        }

        private void clear_text_data()
        {
            txtItemName.Text = "";
            txtItemCode.Text = "";
            txtUnit.Text = "";
            txtMRP.Text = "";
            txtOty.Text = "";
            txtFreeQty.Text = "";
            txtTax1.Text = "";
            txtTaxAMount1.Text = "";
            txtDis.Text = "";
            txtDisAmt.Text = "";
            txtItemTotal.Text = "";
        }

        private void cleardata()
        {
           // cmbpartyname1.Text = "";
            cmbpartyname.Text = "";
            txtbillingadd.Text = "";
            txtcon.Text = "";
            dtpInvoice.Text = "";
            txtPoNo.Text = "";
            dtpPodate.Text = "";
            cmbStatesupply.Text = "";
            cmbPaymentType.Text = "";
            txtTransportName.Text = "";
            txtDeliveryLoc.Text = "";
            txtVehicleNo.Text = "";
            DtpdeliveryDate.Text = "";
            txtDescription.Text = "";
            cmbtax.Text = "";
            TxtIGST.Text = "";
            txtcgst.Text = "";
            txtsgst.Text = "";
            txtsubtotal.Text = "";
            txtTaxAmount.Text = "";
            txtDiscount.Text = "";
            txtDisAmount.Text = "";
            txtRoundup.Text = "";
            txtTotal.Text = "";
            txtReceived.Text = "";
            txtBallaance.Text = "";
            txtrefNo.Text = "";
            txtadditional1.Text = "";
            txtadditional2.Text = "";
            ComboBox.Text = "";
            cmbCategory.Text = "";
            Sale.Text = "";
            textBox1.Text = "";

        }

        private void get_id()
        {
            if (txtReturnNo.Text != "0" || txtReturnNo.Text != "")
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select MAX (CAST( InvoiceID as INT)) from tbl_SaleInvoice", con);
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

                //string query = string.Format("insert into tbl_SaleInvoice( PartyName,BillingName,ContactNo ,PoNumber,PoDate,InvoiceDate,StateofSupply  ,PaymentType,TransportName,DeliveryLocation,VehicleNumber,Deliverydate,Description,Tax1,CGST,SGST,TaxAmount1 ,TotalDiscount ,DiscountAmount1 ,RoundFigure ,Total, Received, RemainingBal, Feild1,Feild2,Feild3, Status,TableName,Barcode) Values (@PartyName, @BillingName, @ContactNo, @PoNumber, @PoDate, @InvoiceDate, @StateofSupply, @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description, @Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Received, @RemainingBal, @Feild1, @Feild2, @Feild3, @Status, @TableName,@Barcode); SELECT SCOPE_IDENTITY();");
                //SqlCommand cmd = new SqlCommand(query, con);
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_SaleInvoiceSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname1.Text);
                }
                cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoice.Text);
                cmd.Parameters.AddWithValue("@PoNumber", txtPoNo.Text);
                cmd.Parameters.AddWithValue("@PoDate", dtpPodate.Text);
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
                cmd.Parameters.AddWithValue("@Received", txtReceived.Text);
                cmd.Parameters.AddWithValue("@RemainingBal", txtBallaance.Text);
                cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Sale.Text);
                cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                cmd.Parameters.AddWithValue("@IGST", TxtIGST.Text);
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Sale Record Added");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {             
                insert_record_inner(id1.ToString());
            }
        }

        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++) {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_SaleInvoiceInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);
                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                    //MessageBox.Show(e1.Message);
                }            
            }
        }
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            insertdata();
            bind_sale_details();
            clear_text_data();
            cleardata();
        }
        private void bind_sale_details()
        {
            try
            {
                //    SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string str = string.Format("SELECT * FROM tbl_SaleInvoice where InvoiceID='{0}'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        //con.Close();
                        cmbpartyname1.Text = dr["PartyName"].ToString();
                        txtbillingadd.Text = dr["BillingName"].ToString();
                        txtcon.Text = dr["ContactNo"].ToString();
                        dtpInvoice.Text = dr["InvoiceDate"].ToString();
                        txtPoNo.Text = dr["PoNumber"].ToString();
                         dtpPodate.Text = dr["Podate"].ToString();
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
                        txtReceived.Text = dr["Received"].ToString();
                        txtBallaance.Text = dr["RemainingBal"].ToString();
                        txtrefNo.Text = dr["Feild1"].ToString();
                        txtadditional1.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Sale.Text = dr["TableName"].ToString();
                        cmbCategory.Text = dr["ItemCategory"].ToString();
                        textBox1.Text = dr["Barcode"].ToString();
                        TxtIGST.Text = dr["IGST"].ToString();
                        id = dr["InvoiceID"].ToString();
                    }
                }
              dr.Close();
                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_SaleInvoiceInner where ID='{0}'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
               //r.Close();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    int i = 0;
                    while (dr1.Read())
                    {
                        dgvInnerDebiteNote.Rows.Add();
                        dgvInnerDebiteNote.Rows[i].Cells["sr_no"].Value = i + 1;
                        dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value = dr1["ItemName"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value = dr1["BasicUnit"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value = dr1["ItemCode"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value = dr1["SalePrice"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value = dr1["TaxForSale"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value = dr1["SaleTaxAmount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value = dr1["freeQty"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value = dr1["Discount"].ToString();
                        dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value = dr1["DiscountAmount"].ToString();           
                        dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value = dr1["ItemAmount"].ToString();

                        i++;
                    }
                    dr1.Close();
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
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
        private void fetchitem()
        {
            if (txtItemName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster group by ItemName");
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

        private void txtItemName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
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
                con.Close();
            }
        }


        private void fetchcustomername()
        {
            if (cmbpartyname.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster group by PartyName");
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

        private void cmbpartyname_SelectedIndexChanged_1(object sender, EventArgs e)
        {         
            try
            {
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
                txtPoNo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleSwitch1.Checked == true)
            {
                CreditNote BA = new CreditNote();
                BA.TopLevel = false;
                // BA.AutoScroll = true;
                this.Controls.Add(BA);
                BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                BA.Dock = DockStyle.Fill;
                BA.Visible = true;
                BA.BringToFront();
            }
        }


        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            

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
        private void gst_devide()
        {
            if (cmbtax.Text != "" && txtsgst.Text != "" && txtcgst.Text != "")
            {
                float gst = 0, cgst = 0, sgst = 0;
                gst = float.Parse(cmbtax.Text);
                cgst = gst / 2;
                sgst = gst / 2;
                txtsgst.Text = sgst.ToString();
                txtcgst.Text = cgst.ToString();
            }
        
       }

     
        private void btnSetting_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cal_Total()
        {
           if(txtsubtotal.Text != "" && txtDiscount.Text != "" && txtDisAmount.Text != "" && cmbtax.Text != "" && txtTaxAmount.Text != "" && txtTotal.Text != "")
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
           
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }


        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
             
            if(txtReceived.Text != "" && txtTotal.Text != "" && txtBallaance.Text !="")
            { 
                float receive_bank = 0, receive_cash = 0, pending_amt = 0, TP = 0, GT = 0;

              
                receive_cash = float.Parse(txtReceived.Text);
                GT = float.Parse(txtTotal.Text);

                TP = GT - receive_cash;
                txtBallaance.Text = TP.ToString();
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
        public void cal_ItemTotal()
        {
            if (txtOty.Text != "" && txtMRP.Text != "" && txtDis.Text != "" &&  txtTax1.Text != "" && txtDisAmt.Text != "" && txtTaxAMount1.Text != "" && txtItemTotal.Text != "" && txtTotal.Text != "")
            {
                float qty = 0, freeqty = 0, rate = 0, sub_total = 0, dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0;

                qty = float.Parse(txtOty.Text);
                freeqty = float.Parse(txtFreeQty.Text.ToString());
                rate = float.Parse(txtMRP.Text.ToString());
                //  sub_total = float.Parse(txtsub_total.Text.ToString());
                dis = float.Parse(txtDis.Text.ToString());
                gst = float.Parse(txtTax1.Text);

                sub_total = (qty + freeqty) * rate;
                //txtsub_total.Text = sub_total.ToString();

                dis_amt = sub_total * dis / 100;
                txtDisAmt.Text = dis_amt.ToString();

                gst_amt = sub_total * gst / 100;
                txtTaxAMount1.Text = gst_amt.ToString();

                total = (sub_total + gst_amt) - dis_amt;
                txtItemTotal.Text = total.ToString();
                txtTotal.Text = total.ToString();
            }
        }

        private void txtDis_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtOty_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtTax1_TextChanged(object sender, EventArgs e)
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

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
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
                    for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
                    {
                        TA += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());
                        //   // TD += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                        //   // TGST += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());

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
        private void cmbpartyname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtbillingadd_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPoNo_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
           // if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = false;
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTransportName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTransportName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDeliveryLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            cleardata();
            clear_text_data();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
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
            try
            {             
                con.Close();
                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}'", cmbCategory.Text);
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

        private void cmbpartyname1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            // if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = false;
            }
        }

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {
            gst_devide();
        }

        private void TxtIGST_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void txtsgst_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
