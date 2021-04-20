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
using System.Text.RegularExpressions;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
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
        public int dispurchase;
        public int supplace;
        public int gstint;
        public int cust;
       // public int dispurchase;
        public int displayfree;
        public int count1;
        public int taxwise;
        public int diswise;
        public int show;
        public int duedate;
        public int round;
        public int vehicle;
        public int delloc;
        public int deldt;
        public int transname;
        public int showadd;
        public int printshowadd;
        public int placesupp;
        public int eway;

        private void PurchaseBill_Load(object sender, EventArgs e)
        {
            cleardata();
            fetchCategory();
            cmbStatesupply.Hide();
            label5.Hide();
            chkRoundOff.Hide();
            txtRoundup.Hide();          
            txtVehicleNo.Hide();
            txtTransportName.Hide();
            DtpdeliveryDate.Hide();
            txtDeliveryLoc.Hide();
            label8.Hide();
            label12.Hide();
            label11.Hide();
            label16.Hide();
            txtDiscount.Enabled = false;
            txtDisAmount.Enabled = false;
            cmbtax.Enabled = false;
            guna2TextBox1.Enabled = false;
            txtsgst.Enabled = false;
            txtcgst.Enabled = false;
            txtTaxAmount.Enabled = false;
            txtFreeQty.Enabled = false;
            cmbStatesupply.Enabled = false;
            guna2TextBox2.Enabled = false;
            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select DisplayPurchasePriseOnItem from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            dispurchase = Convert.ToInt32(cmd3.ExecuteScalar());
            con.Close();
            if (dispurchase == 1)
            {
                fetchitem();
            }
            else if (dispurchase == 0)
            {
                fetchitem1();
            }
            con.Open();
            SqlCommand cmd4 = new SqlCommand("Select PlaceOfSupply from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            supplace = Convert.ToInt32(cmd4.ExecuteScalar());
            con.Close();
            if (supplace == 1)
            {
                cmbStatesupply.Enabled = true;
                cmbStatesupply.Visible = true;
                cmbStatesupply.Show();
                label5.Show();
            }
            con.Open();
            SqlCommand cmd9 = new SqlCommand("Select RoundOff from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            round = Convert.ToInt32(cmd9.ExecuteScalar());
            con.Close();
            if (round == 1)
            {
                chkRoundOff.Show();
                txtRoundup.Show();
            }
            con.Open();
            SqlCommand cmd10 = new SqlCommand("Select VehicleNo from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            vehicle = Convert.ToInt32(cmd10.ExecuteScalar());
            con.Close();
            if (vehicle == 1)
            {
                txtVehicleNo.Show();
                label12.Show();
            }
            con.Open();
            SqlCommand cmd11 = new SqlCommand("Select TransportName from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            transname = Convert.ToInt32(cmd11.ExecuteScalar());
            con.Close();
            if (transname == 1)
            {
                txtTransportName.Show();
                label8.Show();
            }
            con.Open();
            SqlCommand cmd12 = new SqlCommand("Select DeliveryDate from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            deldt = Convert.ToInt32(cmd12.ExecuteScalar());
            con.Close();
            if (deldt == 1)
            {
                DtpdeliveryDate.Show();
                label16.Show();
            }
            con.Open();
            SqlCommand cmd13 = new SqlCommand("Select DeliveryLocation from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            delloc = Convert.ToInt32(cmd13.ExecuteScalar());
            con.Close();
            if (delloc == 1)
            {
                txtDeliveryLoc.Show();
                label11.Show();
            }
            con.Open();
            SqlCommand cmd14 = new SqlCommand("Select ShippingAddress from TransactionTableSetting where Company_ID=" + NewCompany.company_id + " ", con);
            showadd = Convert.ToInt32(cmd14.ExecuteScalar());
            con.Close();
            if (showadd == 1)
            {
                txtbillingadd.Enabled = true;
            }
            // fetchitem();
            fetchcustomername();
          //  bind_sale_details();
            txtReturnNo.Enabled = false;
            cmbpartyname.Focus();
            get_id();
            txtsubtotal.Enabled = false;
            txtTotal.Enabled = false;
            comboBox2.Visible = false;
            guna2TextBox2.Visible = true;
            guna2TextBox2.Hide();


            if(barcode==1)
            {
                label15.Visible = false;
                cmbbarcode.Visible = false;

            }
        }
        private void fetchitem()
        {
            if (txtItemName.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemName,PurchasePrice from tbl_ItemMaster where Company_ID='" + NewCompany.company_id + "'  and DeleteData='1' group by ItemName,PurchasePrice");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {
                        txtItemName.Items.Add(ds.Tables["Temp"].Rows[i]["ItemName"].ToString() + " " + ds.Tables["Temp"].Rows[i]["PurchasePrice"].ToString());

                    }
                }
                catch (Exception e1)
                {
                    //  MessageBox.Show(e1.Message);
                }
            }
        }
        private void fetchdetails()
        {
            for (int i = 0; i < guna2DataGridView2.Rows.Count; i++) {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_PurchaseBillInnersp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ItemName", guna2DataGridView2.Rows[i].Cells["txtItem"].Value?.ToString());
                cmd.Parameters.AddWithValue("@ItemCode", guna2DataGridView2.Rows[i].Cells["Item_Code"].Value?.ToString());
                cmd.Parameters.AddWithValue("@BasicUnit", guna2DataGridView2.Rows[i].Cells["Unit"].Value?.ToString());
                cmd.Parameters.AddWithValue("@Qty", guna2DataGridView2.Rows[i].Cells["Qty"].Value?.ToString());
                cmd.Parameters.AddWithValue("@freeQty", guna2DataGridView2.Rows[i].Cells["FreeQty"].Value?.ToString());
                cmd.Parameters.AddWithValue("@SalePrice", guna2DataGridView2.Rows[i].Cells["MRP"].Value?.ToString());
                cmd.Parameters.AddWithValue("@TaxForSale", guna2DataGridView2.Rows[i].Cells["Tax"].Value?.ToString());
                cmd.Parameters.AddWithValue("@SaleTaxAmount", guna2DataGridView2.Rows[i].Cells["Tax_Amount"].Value?.ToString());
                ////cmd.Parameters.AddWithValue("@TaxType", dgvInnerDebiteNote.Rows[i].Cells["TaxType"].Value?.ToString());
                cmd.Parameters.AddWithValue("@Discount", guna2DataGridView2.Rows[i].Cells["Discount"].Value?.ToString());
                cmd.Parameters.AddWithValue("@DiscountAmount", guna2DataGridView2.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                cmd.Parameters.AddWithValue("@ItemAmount", guna2DataGridView2.Rows[i].Cells["Amount"].Value?.ToString());
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);

                cmd.Parameters.AddWithValue("@Action", "Select");
               // con.Close();
            }
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
        private void fetchcustomername()
        {
            if (cmbpartyname.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select PartyName from tbl_PartyMaster where DeleteData='1' and Company_ID='" + NewCompany.company_id+"' group by PartyName");
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
                   // MessageBox.Show(e1.Message);
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
           
        }

        private void txtItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice TaxForSale ,SaleTaxAmount
                string Query = String.Format("select ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') and  Company_ID='" + NewCompany.company_id + "'GROUP BY ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
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
            finally {
                //con.Close();
            }
        }

        public void cal_ItemTotal()
        {
            try
            {
                if (txtOty.Text != "" && txtDis.Text != "")
                {
                    float qty = 0, freeqty = 0, rate = 0, sub_total = 0, dis = 0, gst = 0, total = 0, dis_amt = 0, gst_amt = 0;
                    qty = float.Parse(txtOty.Text.ToString());
                    freeqty = float.Parse(txtFreeQty.Text.ToString());
                    rate = float.Parse(txtMRP.Text.ToString());
                    //  sub_total = float.Parse(txtsub_total.Text.ToString());
                    dis = float.Parse(txtDis.Text.ToString());
                    gst = float.Parse(txtTax1.Text.ToString());

                    sub_total = (qty + freeqty) * rate;
                    guna2TextBox6.Text = sub_total.ToString();

                    dis_amt = sub_total * dis / 100;
                    txtDisAmt.Text = dis_amt.ToString();

                    gst_amt = sub_total * gst / 100;
                    txtTaxAMount1.Text = gst_amt.ToString();

                    total = (sub_total + gst_amt) - dis_amt;
                    txtItemTotal.Text = total.ToString();
                    txtsubtotal.Text = total.ToString();
                }
            }
            catch(Exception ex)
            {
               // MessageBox.Show(ex.Message);
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

        private void txtFreeQty_TextChanged(object sender, EventArgs e)
        {
            
                cal_ItemTotal();
            
        }
        int row = 0;
        public int dublication, ip;
        private void txtItemTotal_KeyDown(object sender, KeyEventArgs e)

        {
            try {

                if (txtOty.Text == "0")
                {
                    MessageBox.Show("PleaseSelect the Item Qty !");
                }
                else
                {
                 
                    if (e.KeyCode == Keys.Enter)
                    {
                        insertitem();
                        dublication = 0;
                        ip =0;
                        for (int i = 0; i< guna2DataGridView2.Rows.Count; i++)
                        {
                          String  itemname =guna2DataGridView2.Rows[i].Cells["ItemName"].Value?.ToString();
                           if(txtItemName.Text==itemname)
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
                            float TA = 0, TD = 0, TGST = 0,dis1=0,tax=0,itotal=0;
                            guna2DataGridView2.Rows.Add();
                            row = guna2DataGridView2.Rows.Count - 2;
                            guna2DataGridView2.Rows[row].Cells["sr_no1"].Value = row + 1;
                            guna2DataGridView2.CurrentCell = guna2DataGridView2[1, row];

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
                            string caltotal = guna2TextBox6.Text;
                            string cgst = guna2TextBox3.Text;
                            string sgst = guna2TextBox4.Text;
                            string igst = guna2TextBox5.Text;

                            string itemid11;
                            if(guna2TextBox2.Text== "")
                            {
                                itemid11 = itemid1;
                            }
                            else
                            {
                                itemid11 = guna2TextBox2.Text;
                            }

                            
                            guna2DataGridView2.Rows[row].Cells[1].Value = txtItem;
                            guna2DataGridView2.Rows[row].Cells[2].Value = Item_code;
                            guna2DataGridView2.Rows[row].Cells[3].Value = Unit;
                            guna2DataGridView2.Rows[row].Cells[4].Value = MRP;
                            guna2DataGridView2.Rows[row].Cells[7].Value = qty;
                            guna2DataGridView2.Rows[row].Cells[8].Value = freeqty;
                            guna2DataGridView2.Rows[row].Cells[5].Value = gst;
                            guna2DataGridView2.Rows[row].Cells[9].Value = gst_amt;
                            guna2DataGridView2.Rows[row].Cells[6].Value = dis;
                            guna2DataGridView2.Rows[row].Cells[10].Value = dis_amt;
                            guna2DataGridView2.Rows[row].Cells[11].Value = Total;
                            guna2DataGridView2.Rows[row].Cells[12].Value = itemid11;
                            guna2DataGridView2.Rows[row].Cells[13].Value = cgst;
                            guna2DataGridView2.Rows[row].Cells[14].Value = sgst;
                            guna2DataGridView2.Rows[row].Cells[15].Value = igst;
                            guna2DataGridView2.Rows[row].Cells[16].Value = caltotal;

                            txtItemName.Focus();

                            for (int i = 0; i < guna2DataGridView2.Rows.Count; i++)
                            {
                                dis1 += float.Parse(guna2DataGridView2.Rows[i].Cells["DiscountAmount"].Value?.ToString());
                                textBox4.Text = dis1.ToString();
                                tax += float.Parse(guna2DataGridView2.Rows[i].Cells["SaleTaxAmount"].Value?.ToString());
                                textBox3.Text = tax.ToString();
                                itotal += float.Parse(guna2DataGridView2.Rows[i].Cells["CalTotal"].Value?.ToString());
                                textBox6.Text = itotal.ToString();
                                TA += float.Parse(guna2DataGridView2.Rows[i].Cells["ItemAmount"].Value?.ToString());                              
                                txtsubtotal.Text = TA.ToString();
                                txtTotal.Text = TA.ToString();
                            }
                        }
                        guna2TextBox2.Text = "";
                        cmbbarcode.Text = "";
                        cal_Total();
                        Clear_Text_data();
                        
                    }

                  
                }
            }
            catch (Exception e1) {
                string message = e1.Message;
                 //  MessageBox.Show(e1.Message);

            }
        }

        public void dublicatiuonfunction()
        {


            float gst1 = float.Parse(this.guna2DataGridView2.Rows[ip].Cells[5].Value.ToString());
           float dis1 = float.Parse(this.guna2DataGridView2.Rows[ip].Cells[6].Value.ToString());
           float qty1 = float.Parse(this.guna2DataGridView2.Rows[ip].Cells[7].Value.ToString());
          float freeqty1= float.Parse(this.guna2DataGridView2.Rows[ip].Cells[8].Value.ToString());
          float txamount = float.Parse(this.guna2DataGridView2.Rows[ip].Cells[9].Value.ToString());
          float discamount = float.Parse(this.guna2DataGridView2.Rows[ip].Cells[10].Value.ToString());
           float  txtTotal1 = float.Parse(this.guna2DataGridView2.Rows[ip].Cells[11].Value.ToString());



            float qty =float.Parse(txtOty.Text)+ qty1;
            float freeqty = float.Parse(txtFreeQty.Text)+ freeqty1;
            float gst = float.Parse(txtTax1.Text)+ gst1;
            float gst_amt = float.Parse(txtTaxAMount1.Text)+ txamount;
            float dis = float.Parse(txtDis.Text)+ dis1;
            float dis_amt = float.Parse(txtDisAmt.Text)+ discamount;
            float Total = float.Parse(txtItemTotal.Text)+ txtTotal1;



                           guna2DataGridView2.Rows[row].Cells[7].Value = qty;
                        guna2DataGridView2.Rows[row].Cells[8].Value = freeqty;
                   //     dgvInnerDebiteNote.Rows[row].Cells[5].Value = gst;
                        guna2DataGridView2.Rows[row].Cells[9].Value = gst_amt;
                  //      dgvInnerDebiteNote.Rows[row].Cells[6].Value = dis;
                        guna2DataGridView2.Rows[row].Cells[10].Value = dis_amt;
                        guna2DataGridView2.Rows[row].Cells[11].Value = Total;
               
            
            
            
            
               
                        for (int i = 0; i < guna2DataGridView2.Rows.Count; i++)
                        {
                          TA += float.Parse(guna2DataGridView2.Rows[i].Cells["Amount"].Value?.ToString());
                //   // TD += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                //   // TGST += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());

                
                            txtsubtotal.Text = TA.ToString();
                            txtTotal.Text = TA.ToString();

                            //  //  txtDisAmt.Text = TD.ToString();
                            //   // txtTaxAMount1.Text = TGST.ToString();
                       }
         
        }
        public int investment,barcode, reminder; 
       public  void seeting()
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                investment= Convert.ToInt32(dr["InvoiceNo"]);
                barcode= Convert.ToInt32(dr["barcode"]);
                reminder = Convert.ToInt32(dr["cashremoinder"]);

            }
            dr.Close();
        }

    
    private void get_id()
        {
            seeting();

            if (investment == 0) {
                if (txtReturnNo.Text != "0" || txtReturnNo.Text != "")
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                    // SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("select MAX (CAST( BillNo as INT)) from tbl_PurchaseBill", con);
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
                    // con.Close();
                }
            }
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
                
                //MessageBox.Show("dara"+NewCompany.company_id);
              //   MessageBox.Show("Date is" + State1 + "sate" + cmbStatesupply.Text);

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
                    guna2TextBox1.Text = gst.ToString();
                    txtsgst.Text = 0.ToString();
                    txtcgst.Text = 0.ToString();

                }
            }
            catch (Exception e1) {
           //     MessageBox.Show(e1.Message);
            }

        }
        object id1;
        private void insert_record_inner(string id)
        {
            for (int i = 0; i < guna2DataGridView2.Rows.Count; i++) {
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

                    cmd.Parameters.AddWithValue("@ItemName", guna2DataGridView2.Rows[i].Cells["ItemName"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", guna2DataGridView2.Rows[i].Cells["ItemCode"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", guna2DataGridView2.Rows[i].Cells["BasicUnit"].Value.ToString());
                      cmd.Parameters.AddWithValue("@Qty", guna2DataGridView2.Rows[i].Cells["Qty1"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", guna2DataGridView2.Rows[i].Cells["FreeQty1"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", guna2DataGridView2.Rows[i].Cells["SalePrice"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", guna2DataGridView2.Rows[i].Cells["TaxforSale"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", guna2DataGridView2.Rows[i].Cells["SaleTaxAmount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", guna2DataGridView2.Rows[i].Cells["Discount1"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", guna2DataGridView2.Rows[i].Cells["DiscountAmount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", guna2DataGridView2.Rows[i].Cells["ItemAmount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemID", guna2DataGridView2.Rows[i].Cells["ItemID11"].Value.ToString());
                    cmd.Parameters.AddWithValue("@cgst", guna2DataGridView2.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sgst", guna2DataGridView2.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@igst", guna2DataGridView2.Rows[i].Cells["IGST"].Value.ToString());
                   // cmd.Parameters.AddWithValue("@caltotal", guna2DataGridView2.Rows[i].Cells["CalTotal"].Value.ToString());

                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.Parameters.AddWithValue("@BillNo",id1);


                    
                  String ItemName = guna2DataGridView2.Rows[i].Cells["ItemName"].Value.ToString();
                  float cureentstock = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["Qty1"].Value.ToString());
                    float freeqty = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["FreeQty1"].Value.ToString());
                    float Itemid = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["ItemID11"].Value.ToString());

                    ////   MessageBox.Show("Data " + ItemCode + "Data2" + cureentstock);

                    SqlCommand cmd1 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                   cmd1.CommandType = CommandType.StoredProcedure;
                  cmd1.Parameters.AddWithValue("@Action","backget");
                    cmd1.Parameters.AddWithValue("@Itemcode", ItemName);
                    cmd1.Parameters.AddWithValue("@ItemID", Itemid);
                    float prestock =Convert.ToInt32(cmd1.ExecuteScalar());

                 //   float freeqty = float.Parse(txtFreeQty.Text);
                  float stockmangee = prestock + cureentstock+freeqty;
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
                 // MessageBox.Show(e1.Message);
                }
                finally {
                   con.Close();
                }
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
                    string query = string.Format("insert into tbl_ItemMaster(ItemName, BasicUnit, ItemCode, SalePrice, TaxForSale,OpeningQty,Company_ID) Values ('" + txtItemName.Text + "', '" + txtUnit.Text + "','" + txtItemCode.Text + "', " + txtMRP.Text + ",'" + txtTax1.Text + "','"+txtOty.Text+"'," + NewCompany.company_id + ")");
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    string Query1 = String.Format("select ItemID from tbl_ItemMaster where ItemName='" + txtItemName.Text + "' and  DeleteData ='1' and Company_ID='" + NewCompany.company_id + "'");
                    SqlCommand cmd1 = new SqlCommand(Query1, con);
                    itemid1 = cmd1.ExecuteScalar().ToString();
                    guna2TextBox2.Text = "";
                }
            }
            catch (Exception e1)
            {
             //  MessageBox.Show(e1.Message);
            }
        }

        private void Clear_Text_data()
        {///
            
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
           
            txtrefNo.Text = "";
            txtadditional1.Text = "";
            txtadditional2.Text = "";
            txtsubtotal.Text = "0";
            txtDiscount.Text = "0";
            txtDisAmount.Text = "0";
            cmbtax.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtTaxAmount.Text = "0";
            txtRoundup.Text = "0";
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBallaance.Text = "0";
            ComboBox.Text = "";
            Purchase.Text = "";
            cmbbarcode.Text = "";
           // comboBox2.Text = "";
            comboBox1.Text = "";
            guna2TextBox1.Text = "0";
            txtTax1.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox6.Text = "0";
            guna2DataGridView2.Rows.Clear();
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
                seeting();

                string query = string.Format("insert into tbl_PurchaseBill(PartyName,PONo,BillingName, PODate, BillDate,  DueDate, StateofSupply, PaymentType, TransportName, DeliveryLocation, VehicleNumber, Deliverydate, Description, Tax1,CGST, SGST, TaxAmount1, TotalDiscount, DiscountAmount1, RoundFigure, Total,Paid, RemainingBal, PaymentTerms,ContactNo,  Feild1, Feild2, Feild3, Status, TableName, Barcode, ItemCategory,IGST,Company_ID,Discount,TaxShow,CalTotal) Values (@PartyName, @PONo, @BillingName, @PoDate,@BillDate, @DueDate,  @StateofSupply, @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description,@Tax1, @CGST, @SGST,@TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Paid, @RemainingBal, @PaymentTerms, @ContactNo, @Feild1, @Feild2, @Feild3, @Status, @TableName, @Barcode, @ItemCategory,@IGST,@compid,@Discount,@TaxShow,@CalTotal); SELECT SCOPE_IDENTITY();");
                SqlCommand cmd = new SqlCommand(query, con);
                //DataTable dtable = new DataTable();
                //cmd = new SqlCommand("tbl_PurchaseBillselect", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("@Action", "Insert");
                //cmd.Parameters.AddWithValue("@BillNo", txtReturnNo.Text);
                // cmd.Parameters.AddWithValue("@InvoiceNo", .Text);

                if (cmbpartyname.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PartyName", comboBox2.Text);
                }
                cmd.Parameters.AddWithValue("@PONo", txtPONo.Text);
               // cmd.Parameters.AddWithValue("@PartyName", cmbpartyname.Text);
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
                cmd.Parameters.AddWithValue("@return", txtReturnNo.Text);
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
                cmd.Parameters.AddWithValue("@Barcode", cmbbarcode.Text);
                cmd.Parameters.AddWithValue("@ItemCategory", comboBox1.Text);
                cmd.Parameters.AddWithValue("@IGST", guna2TextBox1.Text);
                cmd.Parameters.AddWithValue("@Discount", textBox4.Text);
                cmd.Parameters.AddWithValue("@TaxShow", textBox3.Text);
                cmd.Parameters.AddWithValue("@CalTotal", textBox6.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                id1 = cmd.ExecuteScalar();

                //if (investment == 0)
                //{


                //}
                //else
                //{
                //    if (txtReturnNo.Text != "")
                //    {
                //        string query = string.Format("insert into tbl_PurchaseBill(BillNo,PartyName,PONo,BillingName, PODate, BillDate,  DueDate, StateofSupply, PaymentType, TransportName, DeliveryLocation, VehicleNumber, Deliverydate, Description, Tax1,CGST, SGST, TaxAmount1, TotalDiscount, DiscountAmount1, RoundFigure, Total,Paid, RemainingBal, PaymentTerms,ContactNo,  Feild1, Feild2, Feild3, Status, TableName, Barcode, ItemCategory,IGST,Company_ID) Values (@return,@PartyName, @PONo, @BillingName, @PoDate,@BillDate, @DueDate,  @StateofSupply, @PaymentType, @TransportName, @DeliveryLocation, @VehicleNumber, @Deliverydate, @Description,@Tax1, @CGST, @SGST,@TaxAmount1, @TotalDiscount, @DiscountAmount1, @RoundFigure, @Total, @Paid, @RemainingBal, @PaymentTerms, @ContactNo, @Feild1, @Feild2, @Feild3, @Status, @TableName, @Barcode, @ItemCategory,@IGST,@compid); SELECT SCOPE_IDENTITY();");
                //        SqlCommand cmd = new SqlCommand(query, con);
                //        id1 = cmd.ExecuteScalar();
                //    }
                //}

                MessageBox.Show("Purchase Bill Added");
                //cleardata();
            }
            catch (Exception e1)
            {

               // MessageBox.Show(e1.Message);
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
                    cmbpartyname.Visible = false;
                    comboBox2.Visible = true;
                    bind_sale_details();
                }
          
        }

        public float TA;
        private void bind_sale_details()
        {
            try {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string str = string.Format("SELECT * FROM tbl_PurchaseBill where BillNo ='{0}' and  Company_ID='" + NewCompany.company_id + "'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);             
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                { 

                while (dr.Read())
                    {

                        // PartyName,BillingName,ContactNo,PONo,BillDate,PODate ,DueDate,StateofSupply ,PaymentType,TransportName,DeliveryLocation
                        //,VehicleNumber,Deliverydate,Description,TransportCharges,Image,Tax1,TaxAmount1 ,TotalDiscount
                        //,DiscountAmount1 ,RoundFigure ,Total, Paid, RemainingBal, PaymentTerms, Feild1,Feild2,Feild3,Feild4,Feild5
                        //  txtInvoiceNo.Text = dr["InvoiceNo"].ToString();

                        comboBox2.Text = dr["PartyName"].ToString();
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
                        cmbtax.Text = dr["Tax1"].ToString();
                        txtcgst.Text = dr["CGST"].ToString();
                        txtsgst.Text = dr["SGST"].ToString();
                        txtTaxAmount.Text = dr["TaxAmount1"].ToString();
                        txtDiscount.Text = dr["TotalDiscount"].ToString();
                        txtDisAmount.Text = dr["DiscountAmount1"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();
                        txtRoundup.Text = dr["RoundFigure"].ToString();                       
                        //, , , , , , , , , , , , , , , , , , , , , , , , , , , , , , 

                        txtReceived.Text = dr["Paid"].ToString();
                        txtBallaance.Text = dr["RemainingBal"].ToString();
                        cmbPaymentTrems.Text = dr["PaymentTerms"].ToString();
                        txtrefNo.Text = dr["Feild1"].ToString();
                        txtadditional1.Text = dr["Feild2"].ToString();
                        txtadditional2.Text = dr["Feild3"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Purchase.Text = dr["TableName"].ToString();
                        cmbpartyname.Text = dr["ItemCategory"].ToString();
                        guna2TextBox1.Text = dr["IGST"].ToString();
                        cmbbarcode.Text = dr["Barcode"].ToString();
                        txtTotal.Text = dr["Total"].ToString();
                        txtTaxAMount1.Text = dr["TaxAmount1"].ToString();
                        textBox6.Text = dr["CalTotal"].ToString();
                        textBox3.Text = dr["TaxShow"].ToString();
                        textBox4.Text = dr["Discount"].ToString();
                        id = dr["BillNo"].ToString();
                       
                    }
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Invalid  BillNo !");
                    cleardata();
                    cmbpartyname.Visible = false;
                    comboBox2.Visible = true;
                    get_id();
                }


                // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount


                string str1 = string.Format("SELECT ID,ItemID,ItemName,ItemCode,BasicUnit,SalePrice,TaxForSale,SaleTaxAmount,Qty,freeQty,Discount,DiscountAmount,ItemAmount,CGST,SGST,IGST,CalTotal FROM tbl_PurchaseBillInner where BillNo='{0}' and  Company_ID='" + NewCompany.company_id + "' and DeleteData='1'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                
                dr.Close(); 
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    int i = 0;
                    while (dr1.Read())
                    {
                        
                        guna2DataGridView2.Rows.Add();
                        guna2DataGridView2.Rows[i].Cells["sr_no1"].Value = i + 1;
                        guna2DataGridView2.Rows[i].Cells["ItemName"].Value = dr1["ItemName"].ToString();
                        guna2DataGridView2.Rows[i].Cells["ItemCode"].Value = dr1["ItemCode"].ToString();
                        guna2DataGridView2.Rows[i].Cells["BasicUnit"].Value = dr1["BasicUnit"].ToString();
                        guna2DataGridView2.Rows[i].Cells["SalePrice"].Value = dr1["SalePrice"].ToString();
                        guna2DataGridView2.Rows[i].Cells["TaxforSale"].Value = dr1["TaxForSale"].ToString();
                        guna2DataGridView2.Rows[i].Cells["SaleTaxAmount"].Value = dr1["SaleTaxAmount"].ToString();
                        guna2DataGridView2.Rows[i].Cells["Discount1"].Value = dr1["Discount"].ToString();
                        guna2DataGridView2.Rows[i].Cells["DiscountAmount"].Value = dr1["DiscountAmount"].ToString();
                        guna2DataGridView2.Rows[i].Cells["Qty1"].Value = dr1["Qty"].ToString();
                        guna2DataGridView2.Rows[i].Cells["FreeQty1"].Value = dr1["freeQty"].ToString();
                        guna2DataGridView2.Rows[i].Cells["ItemAmount"].Value = dr1["ItemAmount"].ToString();
                        guna2DataGridView2.Rows[i].Cells["ItemID11"].Value = dr1["ItemID"].ToString();
                        guna2DataGridView2.Rows[i].Cells["CGST"].Value = dr1["CGST"].ToString();
                        guna2DataGridView2.Rows[i].Cells["SGST"].Value = dr1["SGST"].ToString();
                        guna2DataGridView2.Rows[i].Cells["IGST"].Value = dr1["IGST"].ToString();
                        guna2DataGridView2.Rows[i].Cells["CalTotal"].Value = dr1["CalTotal"].ToString();
                        i++;
                    }
                    dr1.Close();
                }
                else {
                    dr1.Close();
                
                }

                TA =0;
                for (int i = 0; i < guna2DataGridView2.Rows.Count; i++)
                {

                     TA += float.Parse(guna2DataGridView2.Rows[i].Cells["ItemAmount"].Value?.ToString());
                    //   // TD += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Discount_Amount"].Value?.ToString());
                    //   // TGST += float.Parse(dgvInnerDebiteNote.Rows[i].Cells["Tax_Amount"].Value?.ToString());

                    txtsubtotal.Text = TA.ToString();

                    //  //  txtDisAmt.Text = TD.ToString();
                    //   // txtTaxAMount1.Text = TGST.ToString();
                }
            }
            catch (Exception ex) {
             //   MessageBox.Show(ex.Message);
            }
            finally
            {
                //con.Close();
                              
            }
        }

     
        private void update_record_inner(string p)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmdn = new SqlCommand("tbl_PurchaseBillInnersp", con);
            cmdn.CommandType = CommandType.StoredProcedure;
            cmdn.Parameters.AddWithValue("@Action", "DeleteData");
            cmdn.Parameters.AddWithValue("@ID", txtReturnNo.Text);
            cmdn.ExecuteNonQuery();

            for (int i = 0; i < guna2DataGridView2.Rows.Count; i++) {
                try {                   
                    cmd = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);

                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount

                    cmd.Parameters.AddWithValue("@ItemName", guna2DataGridView2.Rows[i].Cells["ItemName"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", guna2DataGridView2.Rows[i].Cells["ItemCode"].Value.ToString());
                    cmd.Parameters.AddWithValue("@BasicUnit", guna2DataGridView2.Rows[i].Cells["BasicUnit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", guna2DataGridView2.Rows[i].Cells["Qty1"].Value.ToString());
                    cmd.Parameters.AddWithValue("@freeQty", guna2DataGridView2.Rows[i].Cells["FreeQty1"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", guna2DataGridView2.Rows[i].Cells["SalePrice"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxForSale", guna2DataGridView2.Rows[i].Cells["TaxforSale"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", guna2DataGridView2.Rows[i].Cells["SaleTaxAmount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", guna2DataGridView2.Rows[i].Cells["Discount1"].Value.ToString());
                    cmd.Parameters.AddWithValue("@DiscountAmount", guna2DataGridView2.Rows[i].Cells["DiscountAmount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", guna2DataGridView2.Rows[i].Cells["ItemAmount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemID", guna2DataGridView2.Rows[i].Cells["ItemID11"].Value.ToString());
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.Parameters.AddWithValue("@BillNo", txtReturnNo.Text);

                    String ItemName = guna2DataGridView2.Rows[i].Cells["ItemName"].Value.ToString();
                    float cureentstock = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["Qty1"].Value.ToString());
                    float freeqty = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["FreeQty1"].Value.ToString());
                    float Itemid = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["ItemID11"].Value.ToString());



                    //   MessageBox.Show("existing" +intemcode+" thtee"+ qty1+"   iifasfdsfsd"+txtReturnNo.Text);


                    SqlCommand cmd1 = new SqlCommand("Select Qty from tbl_PurchaseBillInner where ItemName='" + ItemName + "' and BillNo='" + txtReturnNo.Text + "' ", con);
                    float existingQty = Convert.ToInt32(cmd1.ExecuteScalar());
                    

                    SqlCommand cmdw = new SqlCommand("tbl_PurchaseBillInnersp", con);
                    cmdw.CommandType = CommandType.StoredProcedure;
                    cmdw.Parameters.AddWithValue("@Action", "backget");
                    cmdw.Parameters.AddWithValue("@Itemcode", ItemName);
                    cmdw.Parameters.AddWithValue("@ItemID", Itemid);
                    float prestock = float.Parse(cmdw.ExecuteScalar().ToString());


                   // MessageBox.Show("exsing " + existingQty + "new qty" + qtyy+"stock"+prestock);

                    if (existingQty > cureentstock)
                    {

                        float finalqty = existingQty - cureentstock;
                         float stockmange = prestock - finalqty;

                           SqlCommand cmd2 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                           cmd2.CommandType = CommandType.StoredProcedure;
                          cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                           cmd2.Parameters.AddWithValue("@stock", stockmange);
                           cmd2.Parameters.AddWithValue("@Itemcode", ItemName);
                          cmd2.Parameters.AddWithValue("@ItemID", Itemid);        
                           cmd2.ExecuteNonQuery();

                         }
                          else if (existingQty < cureentstock)
                         {

                            float finalqty = cureentstock - existingQty ;

                          float stockmange = prestock + finalqty;
                              SqlCommand cmd2 = new SqlCommand("tbl_PurchaseBillInnersp", con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@Action", "UpdateMinimumstock");
                        cmd2.Parameters.AddWithValue("@stock", stockmange);
                        cmd2.Parameters.AddWithValue("@Itemcode", ItemName);
                        cmd2.Parameters.AddWithValue("@ItemID", Itemid);
                        cmd2.ExecuteNonQuery();

                        }

                    cmd.ExecuteNonQuery();
                    //   cmd.ExecuteNonQuery();


                }
                catch (Exception ew) {
             //   MessageBox.Show(ew.Message);
                }
                finally {
                    //  con.Close();
                   

                }
            }
            print();
            cleardata();
            comboBox2.Visible = false;

            get_id();

            fetchcustomername();
            cmbpartyname.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            verfydata();
            if (verify == 1)
            {
              
                    string str = string.Format("SELECT * FROM tbl_PurchaseBill where BillNo ='{0}' and  Company_ID='" + NewCompany.company_id + "'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        DataTable dtable = new DataTable();
                        cmd = new SqlCommand("tbl_PurchaseBillselect", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BillNo", txtReturnNo.Text);
                        // cmd.Parameters.AddWithValue("@InvoiceNo", .Text);
                        //   cmd.Parameters.AddWithValue("@PONo", txtPONo.Text);
                        cmd.Parameters.AddWithValue("@PartyName", comboBox2.Text);
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

                        cmd.Parameters.AddWithValue("@Action", "Update");

                        id1 = cmd.ExecuteScalar();
                        MessageBox.Show("Purchase Bill Updated !!");
                    }
                    catch (Exception e1)
                    {
                        // MessageBox.Show(e1.Message);
                    }
                    finally
                    {
                        // con.Close();
                        dr.Close();
                        update_record_inner(txtReturnNo.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Bill No");
                    dr.Close();
                }
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
            if (txtsubtotal.Text != "" && txtDiscount.Text != "" && cmbtax.Text != "")
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
                //txtTotal.Text = total.ToString();
                txtTotal.Text = Math.Round(total,reminder).ToString();               
                // txtTotal.Text = total.ToString();


            }

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
                //MessageBox.Show(e1.Message);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            cal_Total();
        }
        public int verify = 0;

        public void verfydata()
        {
         
             if (txtbillingadd.Text == "")
            {
                MessageBox.Show("Party Addrtess Is Requueird !");
                txtbillingadd.Focus();
            }
            else if (txtcon.Text == "")
            {
                MessageBox.Show("Party Contact no Is Requueird !");
                txtcon.Focus();
            }          
         
            else if (ComboBox.Text == "")
            {
                MessageBox.Show("Please Select Payment Status  !");
            }
            else
            {
                verify = 1;
            }
        

            //else if (ValidateChildren(ValidationConstraints.Enabled))
            //{
            //    MessageBox.Show(txtcon, "Demo App - Message!");
            //}
            //else if (ValidateChildren(ValidationConstraints.Enabled))
            //{
            //    MessageBox.Show(txtPONo, "Demo App - Message!");

            //}
            //else if (ValidateChildren(ValidationConstraints.Enabled))
            //{
            //    MessageBox.Show(txtrefNo, "Demo App - Message!");
            //}
            //else if (ValidateChildren(ValidationConstraints.Enabled))
            //{
            //    MessageBox.Show(cmbStatesupply, "Demo App - Message!");
            //}


        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                verfydata();
                if (verify == 1)
                {
                    insertdata();
                    print();
                    //  bind_sale_details();
                    Clear_Text_data();
                    cleardata();
                    get_id();
                }
            }
            else
            {
                MessageBox.Show("No permission");
            }
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
                get_id();
                cmbpartyname.Visible = true;
            }
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            id = "";
            cleardata();
            Clear_Text_data();
            get_id();
            comboBox2.Visible = false;
            cmbpartyname.Visible = true;
        }

        private void cmbpartyname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
             
                string Query = String.Format("select BillingAddress, ContactNo from tbl_PartyMaster where (PartyName='{0}') and  Company_ID='" + NewCompany.company_id + "' GROUP BY BillingAddress, ContactNo", cmbpartyname.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtbillingadd.Text = dr["BillingAddress"].ToString();
                    txtcon.Text = dr["ContactNo"].ToString();
                }
                dr.Close();
             
            }
            catch (Exception ex)
            {
               

             //   MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            


        }

        private void cmbPaymentType_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void txtItemName_SelectedIndexChanged_1(object sender, EventArgs e)
        {


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice TaxForSale ,SaleTaxAmount

                    string Query = String.Format("select ItemID,ItemCode, BasicUnit, SalePrice,TaxForSale from tbl_ItemMaster where (ItemName='{0}') and DeleteData='1' and  Company_ID='" + NewCompany.company_id + "' GROUP BY ItemID,ItemCode, BasicUnit, SalePrice,TaxForSale", txtItemName.Text);
                    SqlCommand cmd = new SqlCommand(Query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                       guna2TextBox2.Text = dr["ItemID"].ToString();
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
               // MessageBox.Show(ex.Message);
            }
            finally
            {
               // con.Close();
            }
        }
        private void fetchCategory()
        {
            if (comboBox1.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ItemCategory from tbl_ItemMaster where DeleteData='1' and  Company_ID='" + NewCompany.company_id + "' group by ItemCategory");
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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // con.Close();
                string Query = String.Format("select ItemName from tbl_ItemMaster where ItemCategory='{0}' and  Company_ID='" + NewCompany.company_id + "'group by ItemName", comboBox1.Text);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtPONo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvInnerDebiteNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtItemTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbillingadd_Validating(object sender, CancelEventArgs e)
        {
         
        }

        private void txtbillingadd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReturnNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReturnNo_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void dgvInnerDebiteNote_DoubleClick(object sender, EventArgs e)
        {

           
        }

        private void txtMRP_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtrefNo_TextChanged(object sender, EventArgs e)
        {

        }

        public void print()
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo, a.EmailID,a.GSTNumber,a.AddLogo,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3,b.PartyName,b.BillingName,b.ContactNo,b.Company_ID, b.PONo,b.Deliverydate,b.DeliveryLocation,b.TransportName,b.BillingName   , b.PoDate, b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Paid,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount FROM tbl_CompanyMaster as a, tbl_PurchaseBill as b,tbl_PurchaseBillInner as c where b.BillNo='{0}' and c.BillNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and c.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and c.DeleteData='1' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"PurchaseBillReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("PurchaseBill", "PurchaseBill", ds.Tables[0]);

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
        private void txtadditional1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    DataSet ds = new DataSet();
                    string Query = string.Format("SELECT a.CompanyID,a.CompanyName, a.Address, a.PhoneNo,a.AdditinalFeild1,a.AdditinalFeild2,a.AdditinalFeild3, a.EmailID,a.GSTNumber,a.AddLogo,b.PartyName,b.BillingName,b.ContactNo,b.Company_ID, b.PONo,b.Deliverydate,b.DeliveryLocation,b.TransportName,b.BillingName   , b.PoDate, b.DueDate, b.Tax1, b.CGST, b.SGST, b.TaxAmount1,b.TotalDiscount,b.DiscountAmount1,b.Total,b.Paid,b.RemainingBal,c.ID,c.ItemName,c.BasicUnit,c.SaleTaxAmount,c.TaxForSale,c.ItemCode,c.SalePrice,c.Qty,c.freeQty,c.ItemAmount FROM tbl_CompanyMaster as a, tbl_PurchaseBill as b,tbl_PurchaseBillInner as c where b.BillNo='{0}' and c.BillNo='{1}' and a.CompanyID='" + NewCompany.company_id + "' and b.Company_ID='" + NewCompany.company_id + "' and c.Company_ID='" + NewCompany.company_id + "' and b.DeleteData='1' and c.DeleteData='1' ", txtReturnNo.Text, txtReturnNo.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.Fill(ds);

                    StiReport report = new StiReport();
                    report.Load(@"PurchaseBillReport.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("PurchaseBill", "PurchaseBill", ds.Tables[0]);

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
            comboBox2.Visible = false;
            cmbpartyname.Visible = true;
        }

        private void txtcon_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtPONo_Validating(object sender, CancelEventArgs e)
        {

           
        }

        private void cmbStatesupply_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void dgvInnerDebiteNote_Validating(object sender, CancelEventArgs e)
        {
        }

        private void cmbPaymentType_Validating(object sender, CancelEventArgs e)
        {
        }

        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void cmbpartyname_Validating(object sender, CancelEventArgs e)
        {
          
        }

        private void panel1_Validating(object sender, CancelEventArgs e)
        {

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
                    guna2TextBox3.Text=sgst.ToString();
                    guna2TextBox4.Text= cgst.ToString();
                    guna2TextBox5.Text = 0.ToString();

                }
                else
                {
                    float gst = 0;
                    gst = float.Parse(txtTax1.Text);
                    guna2TextBox5.Text = gst.ToString();
                    guna2TextBox3.Text = 0.ToString();
                    guna2TextBox4.Text = 0.ToString();
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDisAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBallaance_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlinkPayment_Click(object sender, EventArgs e)
        {

        }

        private void txtcon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void txtDisAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMRP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDis_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTax1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOty_KeyPress(object sender, KeyPressEventArgs e)
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
                    txtItemName.Text = dr["ItemName"].ToString();
                    txtItemCode.Text = dr["ItemCode"].ToString();
                    txtUnit.Text = dr["BasicUnit"].ToString();
                    txtMRP.Text = dr["SalePrice"].ToString();
                    txtTax1.Text = dr["TaxForSale"].ToString();
                    guna2TextBox2.Text = dr["ItemID"].ToString();
                    txtOty.Text = 1.ToString();
                    //txtTaxAMount1.Text = dr["SaleTaxAmount"].ToString();
                    //  txtTaxType.Text = dr["TaxType"].ToString();
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
             //  MessageBox.Show(ex.Message);
            }

        }
        private void txtFreeQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbbarcode_TextChanged(object sender, EventArgs e)
        {
            if (cmbbarcode.Text == "")
            {
                clear_text_data();
                guna2TextBox2.Text = "";
            }
            else
            {
                fetchBarcode();
            }
        }

        private void dgvInnerDebiteNote_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                txtItemName.Text = this.guna2DataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtItemCode.Text = this.guna2DataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtUnit.Text = this.guna2DataGridView2.CurrentRow.Cells[3].Value.ToString();
                txtMRP.Text = this.guna2DataGridView2.CurrentRow.Cells[4].Value.ToString();
                txtDis.Text = this.guna2DataGridView2.CurrentRow.Cells[6].Value.ToString();
                txtTax1.Text = this.guna2DataGridView2.CurrentRow.Cells[5].Value.ToString();
                txtOty.Text = this.guna2DataGridView2.CurrentRow.Cells[7].Value.ToString();
                txtFreeQty.Text = this.guna2DataGridView2.CurrentRow.Cells[8].Value.ToString();
                txtDisAmt.Text = this.guna2DataGridView2.CurrentRow.Cells[10].Value.ToString();
                txtTaxAmount.Text = this.guna2DataGridView2.CurrentRow.Cells[9].Value.ToString();
                txtItemTotal.Text = this.guna2DataGridView2.CurrentRow.Cells[11].Value.ToString();
                guna2TextBox2.Text = this.guna2DataGridView2.CurrentRow.Cells[12].Value.ToString();


                int row = guna2DataGridView2.CurrentCell.RowIndex;
                guna2DataGridView2.Rows.RemoveAt(row);
            }
            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtDisAmt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTaxAMount1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            cal_ItemTotal();
        }

        private void txtTaxAMount1_TextChanged(object sender, EventArgs e)
        {

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
    }
}

