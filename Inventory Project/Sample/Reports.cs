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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            GSTR1 BA = new GSTR1();
            //  BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            
        }
        public int Stockmantance;
        public void cheekpass()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("Select * from Setting_Table where Company_ID=" + NewCompany.company_id + "", con);
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                   
                    Stockmantance = Convert.ToInt32(dr["Stockmantance"]);
                }
                dr.Close();

            }

            catch (Exception ew)
            {
                MessageBox.Show(ew.Message);
            }
        }

        private void Reports_Load_1(object sender, EventArgs e)
        {
            cheekpass();
            if(Stockmantance==1)
            {
                guna2Button25.Visible = false;
                guna2Button28.Visible = false;
            }
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button48_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button51_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnpurchase_Click(object sender, EventArgs e)
        {
            PurchaseReport BA = new PurchaseReport();
           // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DayBook BA = new DayBook();
            // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AllTransactionReport BA = new AllTransactionReport();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ProfitLossReport BA = new ProfitLossReport();
            // BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            SaleAging BA = new SaleAging();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            CashFlowReport BA = new CashFlowReport();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            BalanceSheet BA = new BalanceSheet();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            PartyStatement BA = new PartyStatement();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            AllParties BA = new AllParties();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
          //  guna2Panel3.Controls.Add(BA);
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            PartyReportByItem BA = new PartyReportByItem();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            SalePurchasebyPartyGroup BA = new SalePurchasebyPartyGroup();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            StockSummary BA = new StockSummary();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            ItemReportbyParty BA = new ItemReportbyParty();
            // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();

        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            ItemWiseProfitLoss BA = new ItemWiseProfitLoss();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            LowStockSummary BA = new LowStockSummary();
            // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();

        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            StockDetails BA = new StockDetails();
            // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();

        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
          //  SalePurchaseReportbyItemCategory BA = new SalePurchaseReportbyItemCategory();
          //  // BA.TopLevel = false;
          ////  BA.AutoScroll = true;
          //  this.Controls.Add(BA);
          //  //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          //  BA.Dock = DockStyle.Fill;
          //  BA.Visible = true;
          //  BA.BringToFront();
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            ItemTrackingReport BA = new ItemTrackingReport();
            // BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            BankStatement BA = new BankStatement();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            DiscountReport BA = new DiscountReport();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            TaxReport BA = new TaxReport();
            // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {
            TaxRateReport BA = new TaxRateReport();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {
            ExpensesReport BA = new ExpensesReport();
            // BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();

        }

        private void guna2Button37_Click(object sender, EventArgs e)
        {
            ExpenseCategoryReport BA = new ExpenseCategoryReport();
            // BA.TopLevel = false;
          //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button38_Click(object sender, EventArgs e)
        {
            ExpenseItemReport BA = new ExpenseItemReport();
            // BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            SalePurchaseOrderReport BA = new SalePurchaseOrderReport();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();

        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {
            SalePurchaseOrderItemReport BA = new SalePurchaseOrderItemReport();
            // BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button40_Click(object sender, EventArgs e)
        {
            OtherIncomeCategoryReport BA = new OtherIncomeCategoryReport();
            // BA.TopLevel = false;
            //BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button41_Click(object sender, EventArgs e)
        {
            OtherIncomeItemReport  BA = new OtherIncomeItemReport();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button42_Click(object sender, EventArgs e)
        {
            LoanAccountHomepage BA = new LoanAccountHomepage();
            // BA.TopLevel = false;
         //   BA.AutoScroll = true;
            this.Controls.Add(BA);
            //BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            GSTR2 BA = new GSTR2();
            //  BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            GSTR3B BA = new GSTR3B();
            //  BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            GSTR9 BA = new GSTR9();
            //  BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            //  BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }
    }
}
