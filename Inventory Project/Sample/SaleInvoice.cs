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
using Stimulsoft.Report;

using Stimulsoft.Report.Components;

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
            cmbpartyname.Focus();
            fetchcustomername();
            fetchBarcode();
            // fetchCategory();
            fetchitem();
            cmbpartyname1.Visible = false;
            comboBox2.Visible = false;
            txtReturnNo.Enabled = false;
            //comboBox3.Enabled = false;
            get_id();
            guna2TextBox1.Visible = false;

            if (discountcheck == 1)
            {
                txtDis.Hide();
                txtDisAmt.Hide();
                label32.Hide();
                label33.Hide();
             }


            if (ItemwisTax == 1)
            {
                txtTax1.Hide();
                label30.Hide();
                //txtDis ds = new txtDis();

                txtDis.Width = 130;
                txtDis.Height = 28;

                txtOty.Location = new Point(567, 42);
                txtOty.Width = 119;
                txtOty.Height = 28;
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
                string Query = String.Format("select ItemID,ItemName,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where Barcode='" + textBox1.Text+"' and Company_ID='" + NewCompany.company_id + "'  and DeleteData='1'");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            guna2TextBox1.Text = "";
        }

        private void cleardata()
        {
            cmbpartyname1.Text = "";
            cmbpartyname.Text = "";
            //  comboBox2.Text = "";
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
            TxtIGST.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtsubtotal.Text = "0";
            txtTaxAmount.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            txtRoundup.Text = "";
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBallaance.Text = "0";
            txtrefNo.Text = "";
            txtadditional2.Text = "";
            Sale.Text = "";
            textBox1.Text = "";
            cmbCategory.Text = "";
            dgvInnerDebiteNote.Rows.Clear();

        }

        private void get_id()
        {
            seeting();

            if (investment == 0)
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
                    rd.Close();
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
                seeting();

                if (investment == 0)
                {
                    cmd = new SqlCommand("tbl_SaleInvoiceSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                }
                else if (investment == 1)
                {
                    cmd = new SqlCommand("tbl_SaleInvoiceSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert1");

                }
        
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
                //  cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);



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
                cmd.Parameters.AddWithValue("@TableName", Sale.Text);
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
                cmd.Parameters.AddWithValue("@IGST", TxtIGST.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);


                id1 = cmd.ExecuteScalar();

                MessageBox.Show("Insert Record Added");
            }
            catch (Exception e1)
            {
               // MessageBox.Show(e1.Message);
            }
            finally
            {
                insert_record_inner(id1.ToString());
            }
        }

        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
            {
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

                    cmd.Parameters.AddWithValue("@InvoiceID", id1);
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
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);



                   String ItemName = dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value.ToString();
                    float cureentstock = Convert.ToInt32(dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());
                    float freeqty = Convert.ToInt32(dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    float Itemid = Convert.ToInt32(dgvInnerDebiteNote.Rows[i].Cells["ItemID"].Value.ToString());

                    ////   MessageBox.Show("Data " + ItemCode + "Data2" + cureentstock);

                    SqlCommand cmd1 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Action", "backget");
                    cmd1.Parameters.AddWithValue("@Itemcode", ItemName);
                    cmd1.Parameters.AddWithValue("@ItemID", Itemid);

                    float prestock = Convert.ToInt32(cmd1.ExecuteScalar());

                    //   float freeqty = float.Parse(txtFreeQty.Text);

                    float stockmangee = prestock - (cureentstock + freeqty);

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
        public int veryfi = 0;

        public void validdata()
        {
            if (cmbpartyname.Text == "")
            {
                MessageBox.Show("Party Name Required");
                cmbpartyname.Focus();

            }        
            else if (txtcon.Text == "")
            {
                MessageBox.Show("Contact No. Is Required");
                txtcon.Focus();
            }
            else if (txtPoNo.Text == "")
            {
                MessageBox.Show("PO No Is Requried Required");
                txtPoNo.Focus();
            }
            else if (dtpPodate.Text == "")
            {
                MessageBox.Show("PO Date Is Requried Category");
                dtpPodate.Focus();
            }
            else if (cmbStatesupply.Text == "")
            {
                MessageBox.Show("State Is Requried");
                cmbStatesupply.Focus();

            }
            else if (dtpInvoice.Text == "")
            {
                MessageBox.Show("Invoice Date Is Required");
                dtpInvoice.Focus();
            }  
            else if (cmbPaymentType.Text == "Cheque" && txtrefNo.Text == "")
            {

                MessageBox.Show("Cheque Ref No Is Required");
                txtrefNo.Focus();
            }
            else if (ComboBox.Text == "")
            {
                MessageBox.Show("Status Is Required");
                comboBox1.Focus();

            }

            else
            {
                veryfi = 1;
            }
        }

        // public int veryfi = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

                 
            string str = string.Format("SELECT * FROM tbl_SaleInvoice where InvoiceID ='" + txtReturnNo.Text + "' and  Company_ID='" + NewCompany.company_id + "'");
            SqlCommand cmd = new SqlCommand(str, con);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Invalid Data !");
                dr.Close();
            }
            else
            {
                dr.Close();
                validdata();
                if (veryfi == 1)
                {

                    insertdata();
                    insrtparty();
                    clear_text_data();
                    cleardata();
                 
                //    bind_sale_details();
                    printdata1();
                    get_id();

                }
                dr.Close();
            }
        }


        public int investment,discountcheck, ItemwisTax;
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
                investment = Convert.ToInt32(dr["InvoiceNo"]);
                discountcheck= Convert.ToInt32(dr["ItemWiseDiscount"]);
                ItemwisTax= Convert.ToInt32(dr["ItemwisTax"]);
            }
            dr.Close();
        }

        private void printdata1()
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.BillingName,b.ContactNo,b.Company_ID, b.InvoiceID,b.Deliverydate,b.DeliveryLocation,b.TransportName,b.BillingName   , b.InvoiceDate, b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount FROM tbl_CompanyMaster as a, tbl_SaleInvoice as b,tbl_SaleInvoiceInner as c where b.InvoiceID='{0}' and c.InvoiceID='{1}' and a.CompanyID='" + NewCompany.company_id + "' and c.DeleteData='1' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"SaleReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("SaleInvoice", "SaleInvoice", ds.Tables[0]);

                    report.Dictionary.Synchronize();
                    report.Render();
                    report.Show(false);
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }
            }
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

                string str = string.Format("SELECT * FROM tbl_SaleInvoice where InvoiceID='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
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
                        txtsubtotal.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Sale.Text = dr["TableName"].ToString();
                        comboBox2.Text = dr["ItemCategory"].ToString();
                        textBox1.Text = dr["Barcode"].ToString();
                        TxtIGST.Text = dr["IGST"].ToString();
                        id = dr["InvoiceID"].ToString();
                    }
                }
                dr.Close();
                string str1 = string.Format("SELECT ID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount FROM tbl_SaleInvoiceInner where InvoiceID='{0}' and Company_ID='" + NewCompany.company_id + "' and DeleteData='1' ", txtReturnNo.Text);
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
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dgvInnerDebiteNote_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtItemName.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["txtItem"].Value.ToString();
            txtUnit.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
            txtItemCode.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Item_Code"].Value.ToString();
            txtMRP.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["MRP"].Value.ToString();
            txtTax1.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Tax"].Value.ToString();
            txtTaxAMount1.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Tax_Amount"].Value.ToString();
            txtOty.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
            txtFreeQty.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["FreeQty"].Value.ToString();
            txtDis.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
            txtDisAmt.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Discount_Amount"].Value.ToString();
            txtItemTotal.Text = dgvInnerDebiteNote.Rows[e.RowIndex].Cells["Amount"].Value.ToString();

            int row = dgvInnerDebiteNote.CurrentCell.RowIndex;
            dgvInnerDebiteNote.Rows.RemoveAt(row);
        }
        private void fetchCategory()
        {
            if (cmbCategory.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemCategory from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' group by ItemCategory");
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
                  //  MessageBox.Show(e1.Message);
                }
            }
        }
        private void fetchitem()
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
                  //  MessageBox.Show(e1.Message);
                }
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
                string Query = String.Format("select ItemID,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') and Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' GROUP BY ItemID,ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                    guna2TextBox1.Text= dr["ItemID"].ToString();
                    txtOty.Text = 1.ToString();
                    txtOty.Focus();
                    //txtTaxAMount1.Text = dr["SaleTaxAmount"].ToString();
                    //  txtTaxType.Text = dr["TaxType"].ToString();

                }
                dr.Close();

            //    txtItemCode.Focus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        
        }


        private void fetchcustomername()
        {
            if (cmbpartyname.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' group by PartyName ");
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
                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') and Company_ID='" + NewCompany.company_id + "' GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtbillingadd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();
                  
                }
                dr.Close();
             //   txtPoNo.Focus();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
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


       

        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbpartyname.Visible = false;
                cmbpartyname1.Visible = true;
                cmbCategory.Visible = false;
                comboBox2.Visible = true;
                //cmbtax.Visible = false;
                //  comboBox3.Visible = true;
                bind_sale_details();
            }
        }
        private void gst_devide()
        {

            try
            {
                if (cmbtax.Text != "" && txtsgst.Text != "")
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
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
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
            if (txtsubtotal.Text != "" && txtDiscount.Text != "" && txtDisAmount.Text != "" && cmbtax.Text != "" && txtTaxAmount.Text != "" && txtTotal.Text != "")
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
            gst_devide();
        }


        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtReceived.Text != "" && txtTotal.Text != "" && txtBallaance.Text != "")
                {
                    float receive_bank = 0, receive_cash = 0, pending_amt = 0, TP = 0, GT = 0;


                    receive_cash = float.Parse(txtReceived.Text);
                    GT = float.Parse(txtTotal.Text);

                    TP = GT - receive_cash;
                    txtBallaance.Text = TP.ToString();
                }
            }
            catch(Exception ew)
            {
               // MessageBox.Show(ew.Message);
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
        public void cal_ItemTotal()
        {
            try
            {
                if (txtOty.Text != "" && txtMRP.Text != "" && txtDis.Text != "" && txtTax1.Text != "" && txtDisAmt.Text != "" && txtTaxAMount1.Text != "" && txtItemTotal.Text != "" && txtTotal.Text != "")
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
                    // txtTotal.Text = total.ToString();
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
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
        public string Itemid;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                    insertitem();
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
                    if (guna2TextBox1.Text != "")
                    {
                      Itemid = guna2TextBox1.Text;
                    }
                    else
                    {
                    Itemid = itemid1;
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
                    dgvInnerDebiteNote.Rows[row].Cells[12].Value = Itemid;
                    
                    txtItemName.Focus();

                    for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
                    {
                        TA += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value?.ToString());
                        txtsubtotal.Text = TA.ToString();
                        txtTotal.Text = TA.ToString();
                    
                    }
                   
                }

             


            }
            catch (Exception e1)
            {
                string message = e1.Message;
            }
            finally
            {
                clear_text_data();
                textBox1.Text = "";
                textBox1.Focus();

            }
        }
        private void cmbpartyname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPoNo_KeyPress(object sender, KeyPressEventArgs e)
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
                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}' and Company_ID='" + NewCompany.company_id + "'", cmbCategory.Text);
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
                MessageBox.Show(ex.Message);
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

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {

cal_Total();
            gst_devide();
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();

            // get_id();
            //   bind_sale_details();
            printdata1();

            get_id();

            clear_text_data();
            cleardata();
            // dgvInnerDebiteNote.Rows.Clear();
            comboBox2.Visible =false;
            cmbpartyname1.Visible = true;


        }

        private void update()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string str = string.Format("SELECT * FROM tbl_SaleInvoice where InvoiceID ='{0}' and  Company_ID='" + NewCompany.company_id + "'", txtReturnNo.Text);
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                try
                {
                    dr.Close();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_SaleInvoiceSelect", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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
                    //  cmd.Parameters.AddWithValue("@Tax1", cmbtax.Text);

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
                    cmd.Parameters.AddWithValue("@TableName", Sale.Text);
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
                    cmd.Parameters.AddWithValue("@IGST", TxtIGST.Text);
                    //   cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.Parameters.AddWithValue("@Action", "Update");

                    id1 = cmd.ExecuteScalar();
                    MessageBox.Show("Sale Record Update");
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                finally
                {
                    // con.Close();
                    update_record_inner(txtReturnNo.ToString());
                }
            }
            else
            {
                dr.Close();
                MessageBox.Show("Invalid Invoice ID");
            }
            dr.Close();
        }

        private void update_record_inner(string id)
        {


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("tbl_SaleInvoiceInnersp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@ID",txtReturnNo.Text);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dgvInnerDebiteNote.Rows.Count; i++)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //DataTable dtable = new DataTable();
                    //cmd = new SqlCommand("tbl_SaleInvoiceInnersp", con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@InvoiceID", id1);
                    //cmd.Parameters.AddWithValue("@ItemName", dgvInnerDebiteNote.Rows[i].Cells["txtItem"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@BasicUnit", dgvInnerDebiteNote.Rows[i].Cells["Unit"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@ItemCode", dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@SalePrice", dgvInnerDebiteNote.Rows[i].Cells["MRP"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@TaxForSale", dgvInnerDebiteNote.Rows[i].Cells["Tax"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@SaleTaxAmount", dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@Qty", dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@freeQty", dgvInnerDebiteNote.Rows[i].Cells["FreeQty"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@Discount", dgvInnerDebiteNote.Rows[i].Cells["Discount"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@DiscountAmount", dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                    //cmd.Parameters.AddWithValue("@ItemAmount", dgvInnerDebiteNote.Rows[i].Cells["Amount"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@Action", "Update");





                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_SaleInvoiceInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");

                    cmd.Parameters.AddWithValue("@InvoiceID",txtReturnNo.Text);
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
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                    //string intemcode = dgvInnerDebiteNote.Rows[i].Cells["Item_Code"].Value.ToString().ToString();
                    //string qtyw = dgvInnerDebiteNote.Rows[i].Cells["Qty"].Value.ToString().ToString();
                    //float qty1 = float.Parse(qtyw);


                    ////   MessageBox.Show("existing" +intemcode+" thtee"+ qty1+"   iifasfdsfsd"+txtReturnNo.Text);


                    //SqlCommand cmd1 = new SqlCommand("Select Qty from tbl_SaleInvoiceInnersp where ItemCode='" + intemcode + "' and InvoiceID='" + txtReturnNo.Text + "' ", con);
                    //float existingQty = Convert.ToInt32(cmd1.ExecuteScalar());

                    ////   MessageBox.Show("existing" + existingQty + "new qty" + qty1);

                    //SqlCommand cmdb = new SqlCommand("tbl_SaleInvoiceInnersp", con);
                    //cmdb.CommandType = CommandType.StoredProcedure;
                    //cmdb.Parameters.AddWithValue("@Action", "backget");
                    //cmdb.Parameters.AddWithValue("@Itemcode", intemcode);
                    //float prestock = Convert.ToInt32(cmdb.ExecuteScalar());

                    //if (existingQty > qty1)
                    //{
                    //    float finalqty = existingQty - qty1;
                    //    float stockmange = prestock - finalqty;

                    //    SqlCommand cmd2 = new SqlCommand("tbl_SaleInvoiceInnersp", con);
                    //    cmd2.CommandType = CommandType.StoredProcedure;
                    //    cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                    //    cmd2.Parameters.AddWithValue("@stock", stockmange);
                    //    cmd2.Parameters.AddWithValue("@Itemcode", intemcode);
                    //    cmd2.ExecuteNonQuery();

                    //}
                    //else if (existingQty < qty1)
                    //{

                    //    float finalqty = qty1 - existingQty;
                    //    float stockmange = prestock + finalqty;
                    //    SqlCommand cmd2 = new SqlCommand("tbl_SaleInvoiceInnersp", con);
                    //    cmd2.CommandType = CommandType.StoredProcedure;
                    //    cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                    //    cmd2.Parameters.AddWithValue("@stock", stockmange);
                    //    cmd2.Parameters.AddWithValue("@Itemcode", intemcode);
                    //    cmd2.ExecuteNonQuery();

                    //}

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ew)
                {
                 //   MessageBox.Show(ew.Message);
                }
                finally
                {
                    //  con.Close();
                }
            }

        }
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
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

       

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.BillingName,b.ContactNo,b.Company_ID, b.InvoiceID,b.Deliverydate,b.DeliveryLocation,b.TransportName,b.BillingName, b.InvoiceDate, b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Received,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount FROM tbl_CompanyMaster as a, tbl_SaleInvoice as b,tbl_SaleInvoiceInner as c where b.InvoiceID='{0}' and c.InvoiceID='{1}' and a.CompanyID='" + NewCompany.company_id + "' And c.DeleteData='1' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"SaleReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("SaleInvoice", "SaleInvoice", ds.Tables[0]);

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

        private void cmbpartyname1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbPaymentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

       

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }

     

        private void txtMRP_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
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
                string Query = String.Format("select ItemName from tbl_ItemMaster where DeleteData ='1' and Company_ID='"+NewCompany.company_id+"'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {
                    string itemname =ds.Tables["Temp"].Rows[i]["ItemName"].ToString();              
                    if (itemname.ToString() == txtItemName.Text.ToString())
                    {
                        chekpoint = 1;
                    }
                    
                }

                if (chekpoint != 1)
                {
                    string query = string.Format("insert into tbl_ItemMaster(ItemName,ItemCode , BasicUnit, SalePrice, TaxForSale,Barcode,MinimumStock,Company_ID ) Values ('" + txtItemName.Text + "', " + txtItemCode.Text + "," + txtUnit.Text + "," + txtMRP.Text + "," + txtTax1.Text + ",'" + textBox1.Text + "'," +txtOty.Text+ ",'"+ NewCompany.company_id + "')");

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    string Query1 = String.Format("select ItemID from tbl_ItemMaster where ItemName='" + txtItemName.Text + "' and  DeleteData ='1' and Company_ID='" + NewCompany.company_id + "'");
                    SqlCommand cmd1 = new SqlCommand(Query1, con);
                     itemid1 =cmd1.ExecuteScalar().ToString();

                }
            }
            catch( Exception e1)

            {
                MessageBox.Show(e1.Message);
            }
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
                            string query = string.Format("insert into tbl_PartyMaster(PartyName,BillingAddress,ContactNo,Company_ID ) Values ('" + cmbpartyname.Text + "', '" + txtbillingadd.Text + "'," + txtcon.Text + "," + NewCompany.company_id + ")");

                            SqlCommand cmd = new SqlCommand(query, con);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    
            catch (Exception e1)

            {
                MessageBox.Show(e1.Message);
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
               
      }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvInnerDebiteNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fetchBarcode();
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
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

        private void txtItemTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
