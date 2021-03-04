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
namespace sample
{
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                    }

        private void Form1_Load(object sender, EventArgs e)
        {
             
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
            PH.AutoScroll = true;
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

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            CreditNothomePage CN = new CreditNothomePage();
           // ex.TopLevel = false;
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
            NewCompany PB = new NewCompany();
            // ex.TopLevel = false;
           // PB.AutoScroll = true;
            this.Controls.Add(PB);
             //PB.FormBorderStyle = FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.BringToFront();
        }

        private void changeCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyList PB = new CompanyList();
            // ex.TopLevel = false;
          //  PB.AutoScroll = true;
            this.Controls.Add(PB);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PB.Dock = DockStyle.Fill;
            PB.BringToFront();
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
            Process.Start("www.gmail.com");
        }
        private void backupToComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();
        }

        private void restoreBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "DB files (*.DB)|*.DB|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();
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
    }
}

