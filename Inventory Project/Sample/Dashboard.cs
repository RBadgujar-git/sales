using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.Parameters;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Diagnostics;
using Tulpep.NotificationWindow;
using System.Threading;
using kp.Toaster;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace sample
{
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {


        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
       
        public Dashboard()
        {
            //label1.Text = NewCompany.companyname;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Insert1()
        {
            try
            {



                //    MemoryStream po = new MemoryStream();
                //  picCompanyLogo.Image.Save(po, picCompanyLogo.Image.RawFormat);
                //  byte[] arrImage1 = po.GetBuffer();


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //  DataTable dtable = new DataTable();
                int ID = 1;
                SqlCommand cmd = new SqlCommand("tbl_CompanyMasterSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@CompanyID", ID);
                cmd.Parameters.AddWithValue("@CompanyName", "My Company");
                cmd.Parameters.AddWithValue("@PhoneNo",1222222222);
                cmd.Parameters.AddWithValue("@EmailID", "Demo123@gmail.com");
                cmd.Parameters.AddWithValue("@ReferaleCode", "5555");
                cmd.Parameters.AddWithValue("@BusinessType", "Distributer");
                cmd.Parameters.AddWithValue("@Address", "India");
                cmd.Parameters.AddWithValue("@City", "India");
                cmd.Parameters.AddWithValue("@State", "India");
                cmd.Parameters.AddWithValue("@GSTNumber", "12AAAAA4561A1Z2");
                cmd.Parameters.AddWithValue("@OwnerName", "Demo User");
                cmd.Parameters.AddWithValue("@def",1);

                // cmd.Parameters.Add("@Signature", SqlDbType.Image, arrImage2.Length).Value = arrImage2;
                // cmd.Parameters.Add("@AddLogo", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                cmd.Parameters.AddWithValue("@AdditinalFeild1", "12345678910");
                cmd.Parameters.AddWithValue("@AdditinalFeild2", "Demo User");
                cmd.Parameters.AddWithValue("@AdditinalFeild3", "SBIN001234");
                int num = cmd.ExecuteNonQuery();
                MessageBox.Show("Insert data Successfully");


                //SqlCommand cmd1 = new SqlCommand("Select CompanyID from tbl_CompanyMaster where PhoneNo='" + txtcontactNo.Text + "'", con);
                //int CompanyIDD = Convert.ToInt32(cmd1.ExecuteScalar());


                //NewCompany.company_id = CompanyIDD.ToString();
                ////  MessageBox.Show("Id "+NewCompany.company_id);





            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }
        public int Estiment ;
    
        public void companyID()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select CompanyID,CompanyName from tbl_CompanyMaster Where Defulatcompany = '1' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                NewCompany.company_id = dr["CompanyID"].ToString();
                compnAMAE = dr["CompanyName"].ToString();
               
            }      
            con.Close();
          
        }

        public void Seeting1()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmdn = new SqlCommand("Select Max(CompanyID) from tbl_CompanyMaster ", con);
            string id = cmdn.ExecuteScalar().ToString();

            SqlCommand cmd = new SqlCommand("insert into Setting_Table(Company_ID)values(" + id + ")", con);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("insert into TransactionTableSetting(Company_ID)values(" + id + ")", con);
            cmd1.ExecuteNonQuery();

        }

        public string compnAMAE;
        private void Form1_Load(object sender, EventArgs e)
        {


           

            panel1.Focus();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (NewCompany.company_id ==null)
            {
                SqlCommand cmd = new SqlCommand("Select count(*) from tbl_CompanyMaster Where CompanyName = 'My Company' and DeleteData='1' ", con);
                string CompantId = cmd.ExecuteScalar().ToString();
              //  MessageBox.Show("dATA IS" + NewCompany.company_id);
                if (CompantId == 0.ToString())
                {
                    Insert1();
                    Seeting1();
                }
                else
                {
                    companyID();
                  toolStripMenuItem5.Text = compnAMAE.ToString();
                }
            }
            else
            {
                toolStripMenuItem5.Text = NewCompany.companyname;
            }
            // companyID();

            setting();
            //toolStripMenuItem5.Text = "Select Company";
            if(otherincome==1)
            {
                otherIncomeToolStripMenuItem.Visible = false;
            }
            //     NewCompany.company_id = 4.ToString();


            //try
            //{
            //    con.Open();
            //    string Query = String.Format("select CompanyName from tbl_CompanyMaster where Deletedata='1' and Company_ID='" + NewCompany.company_id + "' GROUP BY CompanyName ");
            //    SqlCommand cmd = new SqlCommand(Query, con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        textBox1.Text = dr["CompanyName"].ToString();
            //    }
            //    dr.Close();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //
            if (REMINDER == 1)
            {
                reinder();
            }

        }
        //public void alert(string msg)
        //{
        //    Notification na = new Notification();
        //    na.showalert(msg,"type");
        //}

        public void reinder()
        {

            
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string result = DateTime.Today.AddDays(-10).ToString("yyyy-MM-dd");

                string SelectQuery = string.Format("select PartyName from tbl_SaleInvoice where RemainingBal!=0 and InvoiceDate='" + DateTime.Today.AddDays(-reminderdata).ToString("yyyy-MM-dd") + "' ");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "Temp");
                DataTable DT = new DataTable();
                SDA.Fill(ds);
                for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                {

                    // cmballparties.Items.Add();
                    PopupNotifier po = new PopupNotifier();
                    po.TitleText = "Payment Reminder ";
                    po.ContentText = remess + ds.Tables["Temp"].Rows[i]["PartyName"].ToString();
                    //  po.ContentText = "he baburav";
                    //   po.ContentFont = "Verdana, 13p";
                    po.Popup();

                
            }
        }                   
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
        
        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            PurchaseReport PB = new PurchaseReport();
           // PB.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
           // PB.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            BankAccountHomePage BA = new BankAccountHomePage();
          //  BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
           // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {


        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
               Feedback FD = new Feedback();
           // ex.TopLevel = false;
            FD.AutoScroll = true;
            this.Controls.Add(FD);
           // ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FD.Dock = DockStyle.Fill;
            FD.Show();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {

        }

        private void button48_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            Settings SS = new Settings();
            SS.TopLevel = false;
            SS.AutoScroll = true;
            this.Controls.Add(SS);
            SS.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SS.Dock = DockStyle.Fill;
            SS.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
             OtherIncome OI= new OtherIncome ();
            OI.TopLevel = false;
            OI.AutoScroll = true;
            this.Controls.Add(OI);
            OI.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OI.Dock = DockStyle.Fill;
            OI.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Reports RE = new Reports();
            RE.TopLevel = false;
            RE.AutoScroll = true;
            this.Controls.Add(RE);
            RE.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            RE.Dock = DockStyle.Fill;
            RE.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button47_Click(object sender, EventArgs e)
        {

        }

        private void button50_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {
            PartyMaster1 pm = new PartyMaster1();
            pm.TopLevel = false;
            pm.AutoScroll = true;
            this.Controls.Add(pm);
            pm.FormBorderStyle = FormBorderStyle.None;
            //pm.Dock = DockStyle.Fill;
            pm.Show();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaleInvoiceReport SI = new SaleInvoiceReport();
           // SI.TopLevel = false;
            SI.AutoScroll = true;
            this.Controls.Add(SI);
           // SI.FormBorderStyle = FormBorderStyle.None;
            SI.Dock = DockStyle.Fill;
            SI.Show();
        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            //    SubForm objForm= SubForm.InstanceForm();

            ItemHomepage IM = new ItemHomepage();
           // IM.TopLevel = false;
            IM.AutoScroll = true;
            this.Controls.Add(IM);
           /// IM.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            IM.Dock = DockStyle.Fill;
            IM.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PartyHomepage pm = new PartyHomepage();
            //pm.TopLevel = false;
            pm.AutoScroll = true;
            this.Controls.Add(pm);
           /// pm.FormBorderStyle = FormBorderStyle.None;
            pm.Dock = DockStyle.Fill;
            pm.Show();


        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ExpenseHomePage ex = new ExpenseHomePage();
            //ex.TopLevel = false;
            ex.AutoScroll = true;
            this.Controls.Add(ex);
            //ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ex.Dock = DockStyle.Fill;
            ex.Show();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            ReferandEarn RA = new ReferandEarn();
           // ex.TopLevel = false;
            RA.AutoScroll = true;
            this.Controls.Add(RA);
           // ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            RA.Dock = DockStyle.Fill;
            RA.Show();
        }

      

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PartyHomepage PH = new PartyHomepage();
            //ex.TopLevel = false;
           // PH.AutoScroll = true;
            this.Controls.Add(PH);
           // PH.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PH.Dock = DockStyle.Fill;
            PH.BringToFront();
        }

        private void myOnlineStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnlineStore OS = new OnlineStore();
            // ex.TopLevel = false;
            OS.AutoScroll = true;
            this.Controls.Add(OS);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OS.Dock = DockStyle.Fill;
            OS.BringToFront();
        }

        private void restoreAndBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void partyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports re = new Reports();
            re.Show();
        }

        private void salePurchaseReportByItemSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockSummaryReportByItemCaategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void businessReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bankReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panelmain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OnlineStore ex = new OnlineStore();
            //ex.TopLevel = false;
          ex.AutoScroll = true;
            this.Controls.Add(ex);
           // ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ex.Dock = DockStyle.Fill;
            ex.Show();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            RequestDemo RD = new RequestDemo();
           // RD.TopLevel = false;
            RD.AutoScroll = true;
            this.Controls.Add(RD);
            //RD.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            RD.Dock = DockStyle.Fill;
            RD.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
           // this.Controls.Clear();
            ItemHomepage PB = new ItemHomepage();
            // ex.TopLevel = false;
          //  PB.AutoScroll = true;  
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.BringToFront();
            // PB.Show();
        }
        public static int riminder;
        public int Estiment1,REMINDER,deleverychallan, otherincome, reminderdata;
        public string remess;
        public void setting()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //SqlCommand cmd3 = new SqlCommand("Select Estiment  from Setting_Table  where  Company_ID=" + NewCompany.company_id + "", con);
            //Estiment = Convert.ToInt32(cmd3.ExecuteScalar());



            SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID='" + NewCompany.company_id + "'", con);

            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                Estiment = Convert.ToInt32(dr["Estiment"]);
                Estiment1 = Convert.ToInt32(dr["Sale_purches"]);
                deleverychallan = Convert.ToInt32(dr["Delliverychallen"]);
                otherincome = Convert.ToInt32(dr["OtheIncome"]);
                remess = dr["remindermessage"].ToString();
                reminderdata =Convert.ToInt32(dr["notifyday"]);
                riminder = Convert.ToInt32(dr["cashremoinder"]);
                REMINDER = Convert.ToInt32(dr["REMINDER"]);

            }
            dr.Close();
            //  SqlCommand cmd4 = new SqlCommand("Select Sale_purches  from Setting_Table  where  Company_ID=" + NewCompany.company_id + "", con);

        }
        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //con.Open();
            //int  Estiment1 = Convert.ToInt32(cmd4.ExecuteScalar());

            setting();
                //    con.Close();
                if (Estiment == 1)
            {
             //   estimateQuotationToolStripMenuItem.Enabled = false;
                estimateQuotationToolStripMenuItem.Visible= false;

            }
            else
            {
             //   estimateQuotationToolStripMenuItem.Enabled = true;
                estimateQuotationToolStripMenuItem.Visible = true;
            }

            if (Estiment1==1)
            {
                saleOrderToolStripMenuItem.Visible = false;

            }
            else
            {
                //   estimateQuotationToolStripMenuItem.Enabled = true;
                saleOrderToolStripMenuItem.Visible = true;
            }

            if (deleverychallan == 1)
            {
                deliveryChallanToolStripMenuItem.Visible = false;

            }
            else
            {
                //   estimateQuotationToolStripMenuItem.Enabled = true;
                deliveryChallanToolStripMenuItem.Visible = true;
            }



        }

        private void saleInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleInvoiceReport ex = new SaleInvoiceReport();
            //ex.TopLevel = false;
          //  ex.AutoScroll = true;
            this.Controls.Add(ex);
            //ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ex.Dock = DockStyle.Fill;
            ex.BringToFront();

        }

        private void paymentInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentInHomepage ex = new PaymentInHomepage();
           // ex.TopLevel = false;
           // ex.AutoScroll = true;
            this.Controls.Add(ex);
          //  ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          ex.Dock = DockStyle.Fill;
            ex.BringToFront();
        }

        private void saleOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saleorderhomepage SO = new Saleorderhomepage();
           // ex.TopLevel = false;
          //  SO.AutoScroll = true;
            this.Controls.Add(SO);
           // ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SO.Dock = DockStyle.Fill;
            SO.BringToFront();
        }

        private void deliveryChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryChallanHomepage DC = new DeliveryChallanHomepage();
           // DC.TopLevel = false;
          //  DC.AutoScroll = true;
            this.Controls.Add(DC);
           // DC.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DC.Dock = DockStyle.Fill;
            DC.BringToFront();
        }

        private void salesReturnAndCreditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreditNothomePage CN = new CreditNothomePage();           // ex.TopLevel = false;
         //   CN.AutoScroll = true;
            this.Controls.Add(CN);
           // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            CN.Dock = DockStyle.Fill;
            CN.BringToFront();
        }

        private void purchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseReport PR = new PurchaseReport();
            // ex.TopLevel = false;
           // PR.AutoScroll = true;
            this.Controls.Add(PR);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PR.Dock = DockStyle.Fill;
            PR.BringToFront();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrderHomepage PO = new PurchaseOrderHomepage();
            // ex.TopLevel = false;
        //    PO.AutoScroll = true;
            this.Controls.Add(PO);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PO.Dock = DockStyle.Fill;
            PO.BringToFront();
        }

        private void paymentOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentOutHomepage POH = new PaymentOutHomepage();
            // ex.TopLevel = false;
           // POH.AutoScroll = true;
            this.Controls.Add(POH);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            POH.Dock = DockStyle.Fill;
            POH.BringToFront();
        }

        private void purchaseReturnAndDebitNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebitNotehomepage DN= new DebitNotehomepage();
            // ex.TopLevel = false;
           // DN.AutoScroll = true;
            this.Controls.Add(DN);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DN.Dock = DockStyle.Fill;
            DN.BringToFront();
        }

        private void cashInHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
           CashInHandHomepage CN = new CashInHandHomepage();
            // ex.TopLevel = false;
          //  CN.AutoScroll = true;
            this.Controls.Add(CN);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           CN.Dock = DockStyle.Fill;
            CN.BringToFront();
        }

        private void chequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cheque1 BA = new Cheque1();
            //BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void bankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankAccountHomePage BA = new BankAccountHomePage();
            // ex.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.BringToFront();
            //BA.Show();

        }

        private void otherIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherIncomeHomepage1 OI = new OtherIncomeHomepage1();
            // ex.TopLevel = false;
         //   OI.AutoScroll = true;
            this.Controls.Add(OI);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            OI.Dock = DockStyle.Fill;
            OI.BringToFront();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseHomePage EX = new ExpenseHomePage();
            // ex.TopLevel = false;
           // EX.AutoScroll = true;
            this.Controls.Add(EX);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            EX.Dock = DockStyle.Fill;
            EX.BringToFront();
        }

        private void impotItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportExcel IE = new ImportExcel();
            // ex.TopLevel = false;
            IE.AutoScroll = true;
            this.Controls.Add(IE);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           IE.Dock = DockStyle.Fill;
            IE.BringToFront();
        }

        private void importPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportParties IP = new ImportParties();
            // ex.TopLevel = false;
            IP.AutoScroll = true;
            this.Controls.Add(IP);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           IP.Dock = DockStyle.Fill;
            IP.BringToFront();
        }

        private void exportItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel IP = new ExportToExcel();
            // ex.TopLevel = false;
            IP.AutoScroll = true;
            this.Controls.Add(IP);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            IP.Dock = DockStyle.Fill;
            IP.BringToFront();
        }

        private void referalCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Referralcode RC = new Referralcode();
            // ex.TopLevel = false;
           // RC.AutoScroll = true;
            this.Controls.Add(RC);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            RC.Dock = DockStyle.Fill;
            RC.BringToFront();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings SI = new Settings();
             SI.TopLevel = false;
            SI.AutoScroll = true;
            this.Controls.Add(SI);
            SI.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SI.Dock = DockStyle.Fill;
            SI.Show();
        }

        private void guna2Button51_Click(object sender, EventArgs e)
        {
            Settings SI = new Settings();
            // ex.TopLevel = false;
            SI.AutoScroll = true;
            this.Controls.Add(SI);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SI.Dock = DockStyle.Fill;
            SI.Show();
        }

        private void guna2Button49_Click(object sender, EventArgs e)
        {
            SaleInvoiceReport SI = new SaleInvoiceReport();
            // ex.TopLevel = false;
            SI.AutoScroll = true;
            this.Controls.Add(SI);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SI.Dock = DockStyle.Fill;
            SI.Show();
        }

        private void guna2Button48_Click(object sender, EventArgs e)
        {
            PurchaseReport PB = new PurchaseReport();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.BringToFront();
            // PB.Show();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            ItemHomepage PB = new ItemHomepage();
            // ex.TopLevel = false;
         //   PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.BringToFront();
           // PB.Show();
        }

        
        private void button8_Click_1(object sender, EventArgs e)
        {
            
            SaleInvoiceReport PB = new SaleInvoiceReport();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            // PB.Show();
            PB.BringToFront();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            PurchaseReport PB = new PurchaseReport();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            // PB.Show();
            PB.BringToFront();
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            OtherIncomeHomepage1 PB = new OtherIncomeHomepage1();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            //PB.Show();
            PB.BringToFront();
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            ExpenseHomePage PB = new ExpenseHomePage();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            //PB.Show();
            PB.BringToFront();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            PartyHomepage PB = new PartyHomepage();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           PB.Dock = DockStyle.Fill;
            // PB.Show();
            PB.BringToFront();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            OnlineStore PB = new OnlineStore();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            // PB.Show();
            PB.BringToFront();
        }

        private void button48_Click_1(object sender, EventArgs e)
        {

        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            // Reports PB = new Reports();
            //  PB.TopLevel = false;
            // PB.AutoScroll = true;
            // this.Controls.Add(PB);
            //  PB.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // PB.Dock = DockStyle.Fill;
            //// PB.Show();
            // PB.BringToFront();
            Reports PB = new Reports();
            PB.Show();
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            //Settings PB = new Settings();
            // PB.TopLevel = false;
            //PB.AutoScroll = true;
            //this.Controls.Add(PB);
            //PB.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //PB.Dock = DockStyle.Fill;
            //// PB.Show();
            //PB.BringToFront();
            Settings PB = new Settings();
            PB.Show();
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            ReferandEarn PB = new ReferandEarn();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            //PB.Show();
            PB.BringToFront();
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            Feedback PB = new Feedback();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            // PB.Show();
            PB.BringToFront();
        }

        private void button51_Click_1(object sender, EventArgs e)
        {
            RequestDemo PB = new RequestDemo();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           PB.Dock = DockStyle.Fill;
            // PB.Show();
            PB.BringToFront();
        }

        private void guna2Button49_Click_1(object sender, EventArgs e)
        {
            //SaleInvoice BA = new SaleInvoice();
            //BA.TopLevel = false;
            //BA.AutoScroll = true;
            //this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //BA.Dock = DockStyle.Fill;
            //BA.Visible = true;
            //BA.Show();

            SaleInvoiceReport ex = new SaleInvoiceReport();
            //ex.TopLevel = false;
            //  ex.AutoScroll = true;
            this.Controls.Add(ex);
            //ex.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ex.Dock = DockStyle.Fill;
            ex.BringToFront();

        }

        private void guna2Button48_Click_1(object sender, EventArgs e)
        {
            //PurchaseBill PB = new PurchaseBill();
            //PB.TopLevel = false;
            //PB.AutoScroll = true;
            //this.Controls.Add(PB);
            //PB.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //PB.Dock = DockStyle.Fill;
            //PB.Show();

            PurchaseReport PR = new PurchaseReport();
            // ex.TopLevel = false;
            // PR.AutoScroll = true;
            this.Controls.Add(PR);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PR.Dock = DockStyle.Fill;
            PR.BringToFront();

        }

        private void addNewCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NewCompany PB = new NewCompany();           
            //this.Controls.Add(PB);       
            //PB.BringToFront();
            CompanyList PB = new CompanyList();
            this.Controls.Add(PB);
            PB.Dock = DockStyle.Fill;
            PB.BringToFront();
        }

        private void changeCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            BankAccountHomePage   PB = new BankAccountHomePage();
            // ex.TopLevel = false;
            PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.BringToFront();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            CompanyMaste BA = new CompanyMaste();
            //BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button51_Click_1(object sender, EventArgs e)
        {
            Settings BA = new Settings();
            BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void loanAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoanAccountHomepage BA = new LoanAccountHomepage();
           // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void backupToDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackuptoDrive br = new BackuptoDrive();
            br.Show();
        }
        private void backupToComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup bk = new backup();
            bk.Show();
        }

        private void restoreBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restore rt = new restore();
            rt.Show();
        }

        private void verifyMyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chooseFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void utilityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerCareNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estimateQuatationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddMore BA = new AddMore();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
         //   this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //BA.Dock = DockStyle.Fill;
          //  BA.Visible = true;
            BA.Show();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.Enter))
            {
                guna2Button1_Click(new object(), new EventArgs());
                return true;
            }


            if (keyData == (Keys.Alt | Keys.O))
            {
                PaymentOut payoutObject = new PaymentOut();
                payoutObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.S))
            {
                SaleInvoice saleObject = new SaleInvoice();
                saleObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.I))
            {
                PaymentIn payInObject = new PaymentIn();
                payInObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.R))
            {
                CreditNote creditObject = new CreditNote();
                creditObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.F))
            {
                SaleOrder saleOrderObject = new SaleOrder();
                saleOrderObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.Q))
            {
                Estimate_Quotation estimateObject = new Estimate_Quotation();
                estimateObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D))
            {
                DeliveryChallan delivaryObject = new DeliveryChallan();
                delivaryObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.B))
            {
                PurchaseBill purchaseObject = new PurchaseBill();
                purchaseObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.P))
            {
                DebitNote debitObject = new DebitNote();
                debitObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.U))
            {
               PurchaseOrder purchaseorderObject = new PurchaseOrder();
                purchaseorderObject.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.E))
            {
                Expenses expensesObject = new Expenses();
                expensesObject.Show();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void estimateQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstimateQuotationhomepage DC = new EstimateQuotationhomepage();
            // DC.TopLevel = false;
            //  DC.AutoScroll = true;
            this.Controls.Add(DC);
            // DC.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DC.Dock = DockStyle.Fill;
            DC.BringToFront();
        }

        private void guna2Button49_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            CompanyMaste BA = new CompanyMaste();
            //BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void barcodePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Barcodeprint br = new Barcodeprint();
            br.Show();
            //PasswordAsign as1=new  PasswordAsign();

            //as1.Show();
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            //if (panel1.Visible)
            //    panel1.Hide();
            //else
            //    panel1.Show();
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void companyBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            NewCompany n = new NewCompany();
            this.Controls.Add(n);
            n.Location = new Point(200, 120);
            n.Visible = true;
            n.BringToFront();
           
        }

        public void sms()
        {
            try
            {
                //WebClient client = new WebClient();
                //Stream s = client.OpenRead("");
                //StreamReader reder = new StreamReader(s);
                //string resulte = reder.ReadToEnd();
                //MessageBox.Show("THE ID IS" + resulte);
                //https://www.itexmo.com/php_api/api.php
                WebClient client = new WebClient();
                NameValueCollection nam = new NameValueCollection();
                nam.Add("1", "09766930263");
                nam.Add("2", "");
                nam.Add("3", "TR-VITHO405857_SJAHL");
                nam.Add("passwd", "1{iu6)@1qb");
                byte[] send = client.UploadValues("https://www.itexmo.com/php_api/api.php","POST",nam);
                System.Text.UTF8Encoding.UTF8.GetString(send);
            }
            catch ( Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
             

        }
        private void guna2Button52_Click(object sender, EventArgs e)
        {
            //sms();
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //   this.alert("the data is");
           
                 Toast.show(this, "hii IDEl tech", "grjerejjreret payment for", ToastType.INFO, ToastDuration.SHORT);
                 Toast.show(this, "hii IDEl tech", "grjerejjreret payment for", ToastType.INFO, ToastDuration.SHORT);

        }

        private void companyBankAccountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CompanyBankAccountHomepage BA = new CompanyBankAccountHomepage();
            //BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd4 = new SqlCommand("Select Sale_purches  from Setting_Table  where  Company_ID=" + NewCompany.company_id + "", con);
            int Estiment1 = Convert.ToInt32(cmd4.ExecuteScalar());

            if (Estiment1 == 1)
            {
                purchaseOrderToolStripMenuItem.Visible = false;

            }
            else
            {
                //   estimateQuotationToolStripMenuItem.Enabled = true;
                purchaseOrderToolStripMenuItem.Visible = true;
            }

        }
    }
}

