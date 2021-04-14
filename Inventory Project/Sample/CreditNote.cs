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
    public partial class CreditNote : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        SqlCommand cmd;
        string id = "";
        public CreditNote()
        {
            InitializeComponent();
        }

        private void CreditNote_Load(object sender, EventArgs e)
        {
          
            cmbpartyname.Focus();
            fetchcustomername();
            fetchCategory();
            txtReturnNo.Enabled = false;
            get_id();
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            cmbCategory.Visible = false;
            fetchitem1();
            seeting();
            if(barcode==1)
            {
                label42.Visible = false;
                textBox1.Visible = false;
            }


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
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbCategory.Items.Add(ds.Tables["Temp"].Rows[i]["ItemCategory"].ToString());
                       
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
             //  
            }

        }

        private void fetchitem()
        {
            if (txtItemName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemName from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "' and DeleteData='1' group by ItemName");
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
                 //   MessageBox.Show(e1.Message);
                }
            }
        }
        public int ItemId;
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
                    //   ItemId =Convert.ToInt32(dr["ItemID"]);
                    guna2TextBox1.Text = dr["ItemID"].ToString();
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                  
                    txtOty.Text = 1.ToString();
                  //  txtOty.Focus();
                }
                dr.Close();
                txtOty.Focus();
                //  txtDis.Focus();

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
            //finally
            //{
            //    con.Close();
            //}
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
                   // MessageBox.Show(e1.Message);
                }
            }
        }
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
                //    MessageBox.Show(e1.Message);
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
                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtbillingadd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();
                  //  txtPoNo.Focus();
                }
                dr.Close();
              //  txtInvoiceNo.Focus();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            //finally
            //{
            //    con.Close();
            //}
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
                SqlCommand cmd = new SqlCommand("select MAX (CAST( ReturnNo as INT)) from tbl_CreditNote1", con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string Value = rd[0].ToString();
                    if (Value == "") {
                        txtReturnNo.Text = "1";
                    }
                    else
                    {
                        txtReturnNo.Text = rd[0].ToString();
                        txtReturnNo.Text = (Convert.ToInt64(txtReturnNo.Text) + 1).ToString();
                    }
                }
                rd.Close();
            }
        }

      
      
        public void cal_ItemTotal()
        {
            try
            {
                
                    float qty = 0, freeqty = 0, rate = 0,
                    sub_total = 0, dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0;
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
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
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
        public void quantitcheek()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //con.Open();
            if (txtOty.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Select MinimumStock from tbl_ItemMaster where ItemID=" + ItemId + " ", con);
                int maxmimum = Convert.ToInt32(cmd.ExecuteScalar());
                float qty = float.Parse(txtOty.Text);
                if (maxmimum >= qty)
                {

                }
                else
                {

                }

            }
            //con.Close();

                 
        }

        private void txtOty_TextChanged(object sender, EventArgs e)
        {
       //     quantitcheek();
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
              //  MessageBox.Show(e1.Message);
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
            txtInvoiceNo.Text = "";
            cmbpartyname.Text = "";
           // comboBox1.Text = "";
            txtbillingadd.Text = "";
            txtcon.Text = "";
            txtPONo.Text = "";                 
            cmbStatesupply.Text = "";
            cmbPaymentType.Text = "";
            txtTransportName.Text = "";
            txtDeliveryLoc.Text = "";
            txtVehicleNo.Text = "";
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
            txtsubtotal.Text = "";
            txtBallaance.Text ="0";
            txtrefNo.Text = "";
          //  txtsubtotal.Text = "";
            txtadditional2.Text = "";
            Credit.Text = "";
            ComboBox.Text = "";
            textBox1.Text = "";
           
            cmbCategory.Text = "";
            dgvInnerCreditNote.Rows.Clear();
    }

        private void bind_sale_details()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // con.Open();
                string str = string.Format("SELECT * FROM tbl_CreditNote1 where ReturnNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);             
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                        comboBox1.Text = dr["PartyName"].ToString();
                        txtbillingadd.Text = dr["BillingName"].ToString();
                        txtcon.Text = dr["ContactNo"].ToString();
                        txtPONo.Text = dr["PONumber"].ToString();
                        txtPODate.Text = dr["PODate"].ToString();
                        dtpInvoice.Text = dr["InvoiceDate"].ToString();
                        dtpDueDate.Text = dr["DueDate"].ToString();
                        cmbStatesupply.Text = dr["StateofSupply"].ToString();
                        cmbPaymentType.Text = dr["PaymentType"].ToString();
                        txtTransportName.Text = dr["TransportName"].ToString();
                        txtDeliveryLoc.Text = dr["DeliveryLocation"].ToString();
                        txtVehicleNo.Text = dr["VehicleNumber"].ToString();
                        DtpdeliveryDate.Text = dr["Deliverydate"].ToString();
                        txtDescription.Text = dr["Description"].ToString();
                        comboBox2.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                    ///   txtsubtotal.Text = dr[""].ToString();
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
                        Credit.Text = dr["TableName"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                      //  comboBox3.Text = dr["ItemCategory"].ToString();
                    //    textBox1.Text = dr["Barcode"].ToString();                                           
                        id = dr["ReturnNo"].ToString();
                    }
                }
                dr.Close();
                
                string str1 = string.Format("SELECT ItemID,ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_CreditNoteInner where ReturnNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
               // dr.Close();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    int i = 0;
                    while (dr1.Read())
                    {
                        dgvInnerCreditNote.Rows.Add();
                        dgvInnerCreditNote.Rows[i].Cells["sr_no"].Value = i + 1;
                        dgvInnerCreditNote.Rows[i].Cells["txtItem"].Value = dr1["ItemName"].ToString();                     
                        dgvInnerCreditNote.Rows[i].Cells["Unit"].Value = dr1["BasicUnit"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["Item_Code"].Value = dr1["ItemCode"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["MRP"].Value = dr1["SalePrice"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["Tax"].Value = dr1["TaxForSale"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["Tax_Amount"].Value = dr1["SaleTaxAmount"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["FreeQty"].Value = dr1["freeQty"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["Discount"].Value = dr1["Discount"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["Discount_Amount"].Value = dr1["DiscountAmount"].ToString();                      
                        dgvInnerCreditNote.Rows[i].Cells["Amount"].Value = dr1["ItemAmount"].ToString();
                        dgvInnerCreditNote.Rows[i].Cells["IdItem"].Value = dr1["ItemID"].ToString();

                        i++;
                    }
                  
                }
                dr1.Close();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public int verfy = 0;
        public void verfydata()
        {
            if (cmbpartyname.Text == "")
            {
                MessageBox.Show("Party Name Is Requried");
                cmbpartyname.Focus();
            }
            else if (txtPONo.Text == "")
            {
                MessageBox.Show("Party PONO Is Requried !");
                txtcon.Focus();
            }      
          
            else if (txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Invoice No Is Requried !");
                txtInvoiceNo.Focus();
            }
            else { 
                         verfy = 1;

            }

        }


        object id1;
        private void insertdata()
        {
            try
            {
                if (cmbpartyname.Text == "")
                {
                    MessageBox.Show("Party Name Is Requried");
                }
                else
                {                  
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    //string query = string.Format("insert into tbl_CreditNote1( PartyName ,InvoiceNo ,BillingName,PONumber,PODate,InvoiceDate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation,VehicleNumber,Deliverydate,Description,Tax1,CGST,SGST,TaxAmount1 ,TotalDiscount ,DiscountAmount1 ,RoundFigure ,Total, Received, RemainingBal, Feild1,Feild2,Feild3,ContactNo,TableName,Status,Barcode,Company_ID) Values (@PartyName,@InvoiceNo,  @BillingName, @PONumber, @PODate,@InvoiceDate, @DueDate, @StateofSupply,  @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description, @Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Received, @RemainingBal, @Feild1, @Feild2, @Feild3, @ContactNo, @TableName, @Status,@Barcode,@compid); SELECT SCOPE_IDENTITY();");
                    //SqlCommand cmd = new SqlCommand(query, con);

                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_CreditNote1Select", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ReturnNo", txtrefNo.Text);
                    if (cmbpartyname.Visible == true)
                    {
                        cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PartyName", comboBox1.Text);
                    }
                 //   cmd.Parameters.AddWithValue("@ReturnNo", txtReturnNo.Text);
                    cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    //cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                    cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                    cmd.Parameters.AddWithValue("@PONumber", txtPONo.Text);
                    cmd.Parameters.AddWithValue("@PODate", txtPODate.Value.Date);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoice.Value.Date);
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.Date);
                    cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                    cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                    cmd.Parameters.AddWithValue("@TransportName", txtTransportName.Text);
                    cmd.Parameters.AddWithValue("@DeliveryLocation", txtDeliveryLoc.Text);
                    cmd.Parameters.AddWithValue("@VehicleNumber", txtVehicleNo.Text);
                    cmd.Parameters.AddWithValue("@Deliverydate", DtpdeliveryDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    //  cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                    if (cmbpartyname.Visible == true)
                    {
                        cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
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
                    cmd.Parameters.AddWithValue("@Received", txtReceived.Text);
                    cmd.Parameters.AddWithValue("@RemainingBal", txtBallaance.Text);
                    cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                    cmd.Parameters.AddWithValue("@Feild2", txtsubtotal.Text);
                    cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                    cmd.Parameters.AddWithValue("@TableName", Credit.Text);
                    cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                    // cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
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
                    MessageBox.Show("Sale Record Added");
                    //cleardata();
                    //clear_text_data();
                }
            }
            catch (Exception e1)
            {
              //  MessageBox.Show(e1.Message);
            }
            finally
            {
              //  con.Close();
                insert_record_inner(txtReturnNo.ToString());
            }
        }

        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerCreditNote.Rows.Count; i++)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_CreditNoteInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ReturnNo", id1);
                    //  cmd.Parameters.AddWithValue("@ID", id);
                
                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerCreditNote.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerCreditNote.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerCreditNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerCreditNote.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerCreditNote.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerCreditNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerCreditNote.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerCreditNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerCreditNote.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerCreditNote.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerCreditNote.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemID", dgvInnerCreditNote.Rows[i].Cells["IdItem"].Value.ToString());

                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);




                    String ItemName = dgvInnerCreditNote.Rows[i].Cells["txtItem"].Value.ToString();
                    float cureentstock = Convert.ToInt32(dgvInnerCreditNote.Rows[i].Cells["Qty"].Value.ToString());
                    float freeqty = Convert.ToInt32(dgvInnerCreditNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    float Itemid = Convert.ToInt32(dgvInnerCreditNote.Rows[i].Cells["IdItem"].Value.ToString());


                    
                    ////   MessageBox.Show("Data " + ItemCode + "Data2" + cureentstock);

                    SqlCommand cmd1 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Action", "backget");
                    cmd1.Parameters.AddWithValue("@Itemcode", ItemName);
                    cmd1.Parameters.AddWithValue("@ItemID", Itemid);

                    float prestock = Convert.ToInt32(cmd1.ExecuteScalar());

                    //   float freeqty = float.Parse(txtFreeQty.Text);

                    float stockmangee = prestock + (cureentstock + freeqty);

                    SqlCommand cmd2 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                    cmd2.Parameters.AddWithValue("@stock", stockmangee);
                    cmd2.Parameters.AddWithValue("@Itemcode", ItemName);
                    cmd2.Parameters.AddWithValue("@ItemID", Itemid);
                    cmd2.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                  // MessageBox.Show(e1.Message);
                }
                
            }
           

        }
        private void dgvInnerCreditNote_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        int point = 0;
        public void existingcheek()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // con.Open();
                string str = string.Format("SELECT * FROM tbl_CreditNote1 where ReturnNo='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    point = 1;
                }
                dr.Close();
            }
            catch(Exception ew)
            {
               // MessageBox.Show(ew.Message);

            }

           
      }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                verfydata();

                if (verfy == 1)
                {
                    existingcheek();
                    if (point == 0)
                    {
                        insertdata();
                        //  insert_record_inner();
                        //   bind_sale_details();
                        get_id();
                        cleardata();
                        clear_text_data();
                        printdata(id1.ToString());
                        //   dgvInnerCreditNote.Rows.Clear();
                    }
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
                    string Query = string.Format("SELECT a.AddLogo,a.GSTNumber,a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,b.PartyName,b.BillingName,b.ContactNo, b.ReturnNo, b.InvoiceDate, b.DeliveryLocation,b.DeliveryDate,b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount FROM tbl_CompanyMaster  as a, tbl_CreditNote1 as b,tbl_CreditNoteInner as c where b.ReturnNo='{0}' and c.ReturnNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' ",id1,id1);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"CreditNote1.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("CreditNote", "CreditNote", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)
                {
                 //   MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Settings BA = new Settings();
            BA.TopLevel = false;
           // BA.AutoScroll = true;
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
        public string itemid1;
        public int chekpoint = 0;
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

                    string query = string.Format("insert into tbl_ItemMaster(ItemName,ItemCode , BasicUnit, SalePrice, TaxForSale,Barcode,MinimumStock,Company_ID ) Values ('" + txtItemName.Text + "', '" + txtItemCode.Text + "','" + txtUnit.Text + "'," + txtMRP.Text + "," + txtTax1.Text + ",'" + textBox1.Text + "'," + txtOty.Text + ",'" + NewCompany.company_id + "')");
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    string Query1 = String.Format("select ItemID from tbl_ItemMaster where ItemName='" + txtItemName.Text + "' and  DeleteData ='1' and Company_ID='" + NewCompany.company_id + "'");
                    SqlCommand cmd1 = new SqlCommand(Query1, con);
                    itemid1 = cmd1.ExecuteScalar().ToString();

                }
            }
            catch (Exception e1)

            {
                MessageBox.Show(e1.Message);
            }
        }

        int row = 0;
        string Itemid;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
           // if (txtItemCode.Text != "" && txtUnit.Text != "" && txtMRP.Text != "" && txtOty.Text != "" && txtFreeQty.Text != "" && txtTax1.Text != "" && txtTaxAMount1.Text != "" && txtDis.Text != "" && txtDisAmt.Text != "" && txtItemTotal.Text != "")

           // {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {

                    insertitem();
                    float TA = 0, TD = 0, TGST = 0;
                        dgvInnerCreditNote.Rows.Add();
                        row = dgvInnerCreditNote.Rows.Count - 2;
                        dgvInnerCreditNote.Rows[row].Cells["sr_no"].Value = row + 1;
                        dgvInnerCreditNote.CurrentCell = dgvInnerCreditNote[1, row];

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

                        dgvInnerCreditNote.Rows[row].Cells[1].Value = txtItem;
                        dgvInnerCreditNote.Rows[row].Cells[2].Value = Item_code;
                        dgvInnerCreditNote.Rows[row].Cells[3].Value = Unit;

                        dgvInnerCreditNote.Rows[row].Cells[4].Value = MRP;
                        dgvInnerCreditNote.Rows[row].Cells[7].Value = qty;
                        dgvInnerCreditNote.Rows[row].Cells[8].Value = freeqty;
                        dgvInnerCreditNote.Rows[row].Cells[5].Value = gst;
                        dgvInnerCreditNote.Rows[row].Cells[9].Value = gst_amt;
                        dgvInnerCreditNote.Rows[row].Cells[6].Value = dis;
                        dgvInnerCreditNote.Rows[row].Cells[10].Value = dis_amt;
                        dgvInnerCreditNote.Rows[row].Cells[11].Value = Total;   

                        if (guna2TextBox1.Text != "")
                       {
                         Itemid = guna2TextBox1.Text;
                        }
                      else
                       {
                        Itemid = itemid1;
                      }


                    dgvInnerCreditNote.Rows[row].Cells[12].Value = Itemid;


                    clear_text_data();
                    textBox1.Text = "";
                    guna2TextBox1.Text = "";

                    for (int i = 0; i < dgvInnerCreditNote.Rows.Count; i++)
                    {
                            TA += float.Parse(dgvInnerCreditNote.Rows[i].Cells["Amount"].Value?.ToString());
                        txtsubtotal.Text = TA.ToString();
                       
                    }

                    textBox1.Focus();
                
                  
                }
               // cmbPaymentType.Focus();

            }
                catch (Exception e1)
                {
                    string message = e1.Message;
                }
            }
       // }


     
        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbpartyname.Visible = false;
                comboBox1.Visible = true;
                cmbCategory.Visible = false;
                comboBox2.Visible = true;
                cmbtax.Visible = false;
                comboBox2.Visible = true;
                bind_sale_details();
            }
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtReceived.Text != "")
                {

                    float receive_bank = 0, receive_cash = 0, pending_amt = 0, TP = 0, GT = 0;
                    receive_cash = float.Parse(txtReceived.Text);
                    GT = float.Parse(txtTotal.Text);
                    TP = GT - receive_cash;
                    txtBallaance.Text = TP.ToString();

                }    
            }
            catch (Exception e1) {
               // MessageBox.Show(e1.Message);
            }
        }
        public void cal_Total()
        {
            try
            {
                if (txtDiscount.Text != "")
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
            catch (Exception e1) {
              //  MessageBox.Show(e1.Message);
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

        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}' and Company_ID='"+NewCompany.company_id+"' group by ItemName", cmbCategory.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {
                    txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString());
                   
                }
                txtItemName.Focus();
            }
           
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
                
            }
           
        }

        private void txtPONo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPODate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {

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

        private void update()
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Party Name Is Requried");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    //string query = string.Format("insert into tbl_CreditNote1( PartyName ,InvoiceNo ,BillingName,PONumber,PODate,InvoiceDate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation,VehicleNumber,Deliverydate,Description,Tax1,CGST,SGST,TaxAmount1 ,TotalDiscount ,DiscountAmount1 ,RoundFigure ,Total, Received, RemainingBal, Feild1,Feild2,Feild3,ContactNo,TableName,Status,Barcode,Company_ID) Values (@PartyName,@InvoiceNo,  @BillingName, @PONumber, @PODate,@InvoiceDate, @DueDate, @StateofSupply,  @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description, @Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Received, @RemainingBal, @Feild1, @Feild2, @Feild3, @ContactNo, @TableName, @Status,@Barcode,@compid); SELECT SCOPE_IDENTITY();");
                    //SqlCommand cmd = new SqlCommand(query, con);

                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_CreditNote1Select", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ReturnNo", txtrefNo.Text);
                    if (cmbpartyname.Visible == true)
                    {
                        cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PartyName", comboBox1.Text);
                    }
                    //   cmd.Parameters.AddWithValue("@ReturnNo", txtReturnNo.Text);
                    cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    //cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                    cmd.Parameters.AddWithValue("@BillingName", txtbillingadd.Text);
                    cmd.Parameters.AddWithValue("@PONumber", txtPONo.Text);
                    cmd.Parameters.AddWithValue("@PODate", txtPODate.Value.Date);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoice.Value.Date);
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.Date);
                    cmd.Parameters.AddWithValue("@StateofSupply", cmbStatesupply.Text);
                    cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.Text);
                    cmd.Parameters.AddWithValue("@TransportName", txtTransportName.Text);
                    cmd.Parameters.AddWithValue("@DeliveryLocation", txtDeliveryLoc.Text);
                    cmd.Parameters.AddWithValue("@VehicleNumber", txtVehicleNo.Text);
                    cmd.Parameters.AddWithValue("@Deliverydate", DtpdeliveryDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    //  cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
                    if (cmbpartyname.Visible == true)
                    {
                        cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);
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
                    cmd.Parameters.AddWithValue("@Received", txtReceived.Text);
                    cmd.Parameters.AddWithValue("@RemainingBal", txtBallaance.Text);
                    cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                    cmd.Parameters.AddWithValue("@Feild2", txtsubtotal.Text);
                    cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                    cmd.Parameters.AddWithValue("@TableName", Credit.Text);
                    cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                    // cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
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
                    MessageBox.Show("Update Record Sucessfully");

                    //cleardata();
                    //clear_text_data();

                }
            }
            catch (Exception e1)
            {
               MessageBox.Show(e1.Message);
            }
            finally
            {
                //  con.Close();
                update_record_inner(txtReturnNo.Text.ToString());
            }
        }
        private void update_record_inner(string id)
        {


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("tbl_DebitNoteInnersp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "inserdelete");
            cmd.Parameters.AddWithValue("@returnNo", txtReturnNo.Text);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dgvInnerCreditNote.Rows.Count; i++)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_CreditNoteInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ReturnNo", txtReturnNo.Text);
                    //  cmd.Parameters.AddWithValue("@ID", id);

                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerCreditNote.Rows[i].Cells["txtItem"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerCreditNote.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerCreditNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerCreditNote.Rows[i].Cells["MRP"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerCreditNote.Rows[i].Cells["Tax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerCreditNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerCreditNote.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerCreditNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerCreditNote.Rows[i].Cells["Discount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerCreditNote.Rows[i].Cells["Discount_Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerCreditNote.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                    // MessageBox.Show(e1.Message);
                }

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            existingcheek();
            if (point == 1)
            {
                update();
                //  insert_record_inner();
                //   bind_sale_details();
            
                cleardata();
                clear_text_data();
                printdata(txtReturnNo.Text.ToString());
                dgvInnerCreditNote.Rows.Clear();
                cmbpartyname.Visible = true;
                comboBox1.Visible = false;
                get_id();
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.AddLogo,a.GSTNumber,a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,b.PartyName,b.BillingName,b.ContactNo, b.ReturnNo, b.InvoiceDate, b.DeliveryLocation,b.DeliveryDate,b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount FROM tbl_CompanyMaster  as a, tbl_CreditNote1 as b,tbl_CreditNoteInner as c where b.ReturnNo='{0}' and c.ReturnNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"CreditNote1.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("CreditNote", "CreditNote", ds.Tables[0]);

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

        private void txtPONo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvInnerCreditNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtOty_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbpartyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtcon_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtPONo_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void cmbPaymentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtTransportName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtrefNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscount_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void TxtIGST_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtcgst_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
            clear_text_data();
            cmbpartyname.Visible = true;
            comboBox1.Visible = false;
            get_id();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void chkenble_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkenble.Checked == true)
            {
                txtReturnNo.Enabled = true;
            }
            else
            {
                txtReturnNo.Enabled = false;
                cleardata();
                cmbpartyname.Visible = true;
                comboBox1.Visible = false;
                get_id();
            }
        }

        private void txtItemTotal_TextChanged(object sender, EventArgs e)
        {
               
        }

        private void txtReturnNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtReturnNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbpartyname.Visible = false;
                comboBox1.Visible = true;
               
                cmbtax.Visible = false;
                comboBox3.Visible = true;
                //  comboBox1.Text = "";
                bind_sale_details();
            }
        }

        private void dgvInnerCreditNote_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtItemName.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["txtItem"].Value.ToString();
            txtUnit.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
            txtItemCode.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Item_Code"].Value.ToString();
            txtMRP.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["MRP"].Value.ToString();
            txtTax1.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Tax"].Value.ToString();
            txtTaxAMount1.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Tax_Amount"].Value.ToString();
            txtOty.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
            txtFreeQty.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["FreeQty"].Value.ToString();
            txtDis.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
            txtDisAmount.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Discount_Amount"].Value.ToString();
            txtItemTotal.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtrefNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

        private void txtDisAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaxAMount1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cal_Total();
            gst_devide();
        }

        private void dgvInnerCreditNote_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtItemName.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["txtItem"].Value.ToString();
            txtUnit.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
            txtItemCode.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Item_Code"].Value.ToString();
            txtMRP.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["MRP"].Value.ToString();
            txtTax1.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Tax"].Value.ToString();
            txtTaxAMount1.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Tax_Amount"].Value.ToString();
            txtOty.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
            txtFreeQty.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["FreeQty"].Value.ToString();
            txtDis.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
            txtDisAmount.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Discount_Amount"].Value.ToString();
            txtItemTotal.Text = dgvInnerCreditNote.Rows[e.RowIndex].Cells["Amount"].Value.ToString();

            int row = dgvInnerCreditNote.CurrentCell.RowIndex;
            dgvInnerCreditNote.Rows.RemoveAt(row);
        }

        private void txtReturnNo_TextChanged_1(object sender, EventArgs e)
        {
            gst_devide();
            cal_Total();
          
        }

        private void cmbtax_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cal_Total();
            gst_devide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                clear_text_data();
                guna2TextBox1.Text = "";
            }
            else
            {
                fetchBarcode();
            }
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
                    guna2TextBox1.Text = dr["ItemID"].ToString();

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

        private void TxtIGST_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcgst_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsgst_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
