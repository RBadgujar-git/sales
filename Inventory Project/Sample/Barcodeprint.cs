using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System.Data.SqlClient;

namespace sample
{
    public partial class Barcodeprint : Form
    {
        DataTable dt;
        StiReport report = new StiReport();
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public Barcodeprint()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        public int dd;
        public string tt;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                size1();
            }
            else if (radioButton2.Checked == true)
            {
                size2();
            }
            else if (radioButton3.Checked == true)
            {
                size3();
            }
            else if (radioButton4.Checked == true)
            {
                size4();
            }
            //StiReport report1 = new StiReport();
            //        DataSet ds = new DataSet();

            //dt.Rows.Add(txtsearch.Text, textBox2.Text, textBox3.Text);
            //report1.Load("stiReport1.mrt");
            //        report.RegData("demo", "demo",dt.TableName[0]);          
            //report1.Design();
            //barcode_print.BARCODE rp = new barcode_print.BARCODE();

            //barcode dss = new barcode(); //dataset name

            //string Query = string.Format("SELECT id, net_rate, mrp, model_name from item where model_name like '%{0}%'", txtsearch.Text);

            //SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //da.Fill(dss, "item");
            //rp.SetDataSource(dss);

            //barcode_viewer PV = new barcode_viewer();
            //PV.crystalReportViewer1.ReportSource = rp;

            //PV.crystalReportViewer1.BringToFront();
            //PV.crystalReportViewer1.Visible = true;
            //PV.ShowDialog();

        }
        public void size1()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < dd; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"barcodeprintreportdemo.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("demo", "demo", ds.Tables[0]);

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
        public void size2()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < dd; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"barcodesizeprint2.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("demo", "demo", ds.Tables[0]);

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
        public void size3()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < dd; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"barcodesize3.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("demo", "demo", ds.Tables[0]);

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
        public void size4()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < dd; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"barcodesize4.mrt");

                    report.Compile();
                    StiPage page = report.Pages[0];
                    report.RegData("demo", "demo", ds.Tables[0]);

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
        private void Barcodeprint_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.TableName = "DataTable1";
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("SalePrice", typeof(string));
            dt.Columns.Add("Barcode", typeof(string));

            // this.reportViewer1.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = String.Format("select ItemName,SalePrice,Barcode from tbl_ItemMaster where (ItemName='{0}') and DeleteData='1'  GROUP BY ItemName,SalePrice,Barcode", txtsearch.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr["SalePrice"].ToString();
                    textBox3.Text = dr["Barcode"].ToString();                
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
    }
}
