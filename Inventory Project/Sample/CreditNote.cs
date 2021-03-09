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
            bind_sale_details();
            txtTotal.Enabled = false;
            txtBallaance.Enabled = false;
           txtsubtotal.Enabled = false;        
            //  fetchdetails();
            fetchcustomername();
            fetchCategory();
            txtReturnNo.Enabled = false;
            get_id();
            comboBox1.Visible = false;
        }
        private void fetchCategory()
        {
            if (cmbCategory.Text != "System.Data.DataRowView") {
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
                    MessageBox.Show(e1.Message);
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
                    ItemId =Convert.ToInt32(dr["ItemID"]);
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                }
                dr.Close();

                txtDis.Focus();
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
                }
                dr.Close();

                txtPONo.Focus();
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

        //private void fetchdetails()
        //{
        //    for (int i = 0; i < dgvInnerCreditNote.Rows.Count; i++)
        //    {
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        DataTable dtable = new DataTable();
        //        cmd = new SqlCommand("tbl_CreditNoteInnersp", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Action", "Select");
        //        cmd.Parameters.AddWithValue("@ID", id1);
        //        cmd.Parameters.AddWithValue("@ItemName", dgvInnerCreditNote.Rows[i].Cells["txtItem"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerCreditNote.Rows[i].Cells["Unit"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@ItemCode", dgvInnerCreditNote.Rows[i].Cells["Item_Code"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@MRP", dgvInnerCreditNote.Rows[i].Cells["SalePrice"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@Tax", dgvInnerCreditNote.Rows[i].Cells["TaxForSale"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@Tax_Amount", dgvInnerCreditNote.Rows[i].Cells["SaleTaxAmount"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@Qty", dgvInnerCreditNote.Rows[i].Cells["Qty"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@FreeQty", dgvInnerCreditNote.Rows[i].Cells["freeQty"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@Discount", dgvInnerCreditNote.Rows[i].Cells["Discount"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@Discount_Amount", dgvInnerCreditNote.Rows[i].Cells["DiscountAmount"].Value?.ToString());
        //        cmd.Parameters.AddWithValue("@Amount", dgvInnerCreditNote.Rows[i].Cells["ItemAmount"].Value?.ToString());
        //    }
        //}
      
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
                MessageBox.Show(e1.Message);
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
            //   con.Open();
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

                 
        }

        private void txtOty_TextChanged(object sender, EventArgs e)
        {
            quantitcheek();
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
                con.Open();
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
                MessageBox.Show(e1.Message);
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
            txtInvoiceNo.Text = "";
            cmbpartyname.Text = "";
            txtbillingadd.Text = "";
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
            txtBallaance.Text ="0";
            txtrefNo.Text = "";
            txtadditional1.Text = "";
            txtadditional2.Text = "";
            Credit.Text = "";
            ComboBox.Text = "";
            textBox1.Text = "";
           
            cmbCategory.Text = "";
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
                        Credit.Text = dr["TableName"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        cmbCategory.Text = dr["ItemCategory"].ToString();
                        textBox1.Text = dr["Barcode"].ToString();                                           
                        id = dr["ReturnNo"].ToString();
                    }
                }
                dr.Close();
                
                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_CreditNoteInner where ID='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
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

        public int verfy = 0;
        public void verfydata()
        {
            if (cmbpartyname.Text == "")
            {
                MessageBox.Show("Party Name Is Requried");
                cmbpartyname.Focus();
            }
            else if (txtbillingadd.Text == "")
            {
                MessageBox.Show("Party Addrtess Is Requueird !");
                txtbillingadd.Focus();
            }
            else if (txtcon.Text == "")
            {
                MessageBox.Show("Party Contact no Is Requueird !");
                txtcon.Focus();
            }
            else if (txtPONo.Text == "")
            {
                MessageBox.Show("Party PONO Is Requueird !");
                txtcon.Focus();
            }
            else if (txtrefNo.Text == "")
            {
                MessageBox.Show("Party Refrence No Is Requueird !");
                txtrefNo.Focus();
            }
            else if (txtrefNo.Text == "")
            {
                MessageBox.Show("Party Refrence No Is Requueird !");
                txtrefNo.Focus();
            }
            else if (cmbStatesupply.Text == "")
            {
                MessageBox.Show("Party Refrence No Is Requueird !");

            }
            else if (txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Party Refrence No Is Requueird !");
                txtInvoiceNo.Focus();
            }
            else if (cmbCategory.Text == "")
            {
                MessageBox.Show("Party Refrence No Is Requueird !");
            }
            else if (cmbPaymentType.Text == "")
            {
                MessageBox.Show("Please Select Payment Type !");
            }
            else if (cmbPaymentType.Text == "")
            {
                MessageBox.Show("Please Select Payment Type !");
            }
            else if (cmbtax.Text == "")
            {
                MessageBox.Show("Please Select Tax !");
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


                    string query = string.Format("insert into tbl_CreditNote1( PartyName ,InvoiceNo ,BillingName,PONumber,PODate,InvoiceDate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation,VehicleNumber,Deliverydate,Description,Tax1,CGST,SGST,TaxAmount1 ,TotalDiscount ,DiscountAmount1 ,RoundFigure ,Total, Received, RemainingBal, Feild1,Feild2,Feild3,ContactNo,TableName,Status,Barcode,Company_ID) Values (@PartyName,@InvoiceNo,  @BillingName, @PONumber, @PODate,@InvoiceDate, @DueDate, @StateofSupply,  @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description, @Tax1, @CGST, @SGST, @TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Received, @RemainingBal, @Feild1, @Feild2, @Feild3, @ContactNo, @TableName, @Status,@Barcode,@compid); SELECT SCOPE_IDENTITY();");
                    SqlCommand cmd = new SqlCommand(query, con);

                    //DataTable dtable = new DataTable();
                    //cmd = new SqlCommand("tbl_CreditNote1Select", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Action", "Insert");
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
                    cmd.Parameters.AddWithValue("@Feild1", txtrefNo.Text);
                    cmd.Parameters.AddWithValue("@Feild2", txtadditional1.Text);
                    cmd.Parameters.AddWithValue("@Feild3", txtadditional2.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtcon.Text);
                    cmd.Parameters.AddWithValue("@TableName", Credit.Text);
                    cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                    cmd.Parameters.AddWithValue("@ItemCategory", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@Barcode", textBox1.Text);
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    id1 = cmd.ExecuteScalar();
                    MessageBox.Show("Sale Record Added");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
              //  con.Close();
                insert_record_inner(id1.ToString());
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
                    cmd.Parameters.AddWithValue("@ID", id1);
                  //  cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ItemName", dgvInnerCreditNote.Rows[i].Cells["txtItem"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerCreditNote.Rows[i].Cells["Unit"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", dgvInnerCreditNote.Rows[i].Cells["Item_Code"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvInnerCreditNote.Rows[i].Cells["MRP"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerCreditNote.Rows[i].Cells["Tax"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerCreditNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvInnerCreditNote.Rows[i].Cells["Qty"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", dgvInnerCreditNote.Rows[i].Cells["FreeQty"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@Discount", dgvInnerCreditNote.Rows[i].Cells["Discount"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerCreditNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerCreditNote.Rows[i].Cells["Amount"].Value?.ToString());
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                //finally
                //{
                //    con.Close();
                //}
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            verfydata();

            if (verfy == 1)
            {

                insertdata();
                //  insert_record_inner();
                bind_sale_details();
                get_id();
                cleardata();
                clear_text_data();
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

        int row = 0;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyCode == Keys.Enter) {
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

                    txtItemName.Focus();
                    for (int i = 0; i < dgvInnerCreditNote.Rows.Count; i++) {
                        TA += float.Parse(dgvInnerCreditNote.Rows[i].Cells["Amount"].Value?.ToString());                     
                        txtsubtotal.Text = TA.ToString();    
                    }
                    clear_text_data();
                }
            }
            catch (Exception e1)
            {
                string message = e1.Message;
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

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {

            try
            {
                float receive_bank = 0, receive_cash = 0, pending_amt = 0, TP = 0, GT = 0;
                receive_cash = float.Parse(txtReceived.Text);
                GT = float.Parse(txtTotal.Text);              
                TP = GT - receive_cash;
                txtBallaance.Text = TP.ToString();           
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
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            verfydata();
            if(verfy==1)
            {

            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string Query = string.Format("SELECT a.id, a.CompanyName, a.withdraw_from, a.withdraw_by, a.amount, a.inwords, a.description, c.name, c.company_address, c.mobile, c.email FROM ComapnyMaster  as a, company as c");
            SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
            SDA.Fill(ds);

            StiReport report = new StiReport();
            report.Load(@"CreditNote.mrt"); 

            report.Compile();
            StiPage page = report.Pages[0];
            report.RegData("credit_note", "credit_note", ds.Tables[0]);

            report.Dictionary.Synchronize();
            report.Render();
            report.Show(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
    }
}
