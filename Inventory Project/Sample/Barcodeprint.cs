using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (radioButton1.Checked == true && radioButton12.Checked==true && radioButton8.Checked==true)
            {
                size1();
            }
            else if (radioButton2.Checked == true && radioButton12.Checked == true && radioButton8.Checked == true)
            {
                size2();
            }
            else if (radioButton3.Checked == true && radioButton12.Checked == true && radioButton8.Checked == true)
            {
                size3();
            }
            else if (radioButton4.Checked == true && radioButton12.Checked == true && radioButton8.Checked == true)
            {
                size4();
            }
            if (radioButton1.Checked == true && radioButton11.Checked == true && radioButton8.Checked == true)
            {
                size5();
            }
            else if (radioButton2.Checked == true && radioButton11.Checked == true && radioButton8.Checked == true)
            {
                size6();
            }
            else if (radioButton3.Checked == true && radioButton11.Checked == true && radioButton8.Checked == true)
            {
                size7();
            }
            else if (radioButton4.Checked == true && radioButton11.Checked == true && radioButton8.Checked == true)
            {
                size8();
            }
            else if (radioButton5.Checked == true && radioButton12.Checked == true && radioButton1.Checked == true)
            {
                size9();
            }
            else if (radioButton6.Checked == true && radioButton12.Checked == true && radioButton8.Checked == true)
            {
                size10();
            }
            else if (radioButton7.Checked == true && radioButton12.Checked == true && radioButton1.Checked == true)
            {
                size11();
            }
            else if (radioButton5.Checked == true && radioButton12.Checked == true && radioButton2.Checked == true)
            {
                size12();
            }
            else if (radioButton5.Checked == true && radioButton12.Checked == true && radioButton3.Checked == true)
            {
                size13();
            }
            else if (radioButton5.Checked == true && radioButton12.Checked == true && radioButton4.Checked == true)
            {
                size14();
            }
            else if (radioButton7.Checked == true && radioButton12.Checked == true && radioButton2.Checked == true)
            {
                size15();
            }
            else if (radioButton7.Checked == true && radioButton12.Checked == true && radioButton3.Checked == true)
            {
                size16();
            }
            else if (radioButton7.Checked == true && radioButton12.Checked == true && radioButton4.Checked == true)
            {
                size17();
            }



            else if (radioButton5.Checked == true && radioButton11.Checked == true && radioButton1.Checked == true)
            {
                sizebottom1();
            }
            else if (radioButton5.Checked == true && radioButton11.Checked == true && radioButton2.Checked == true)
            {
                sizebottom2();
            }
            else if (radioButton5.Checked == true && radioButton11.Checked == true && radioButton3.Checked == true)
            {
                sizebottom3();
            }
            else if (radioButton5.Checked == true && radioButton11.Checked == true && radioButton4.Checked == true)
            {
                sizebottom4();
            }
            else if (radioButton7.Checked == true && radioButton11.Checked == true && radioButton1.Checked == true)
            {
                sizebottom11();
            }
            else if (radioButton7.Checked == true && radioButton11.Checked == true && radioButton2.Checked == true)
            {
                sizebottom12();
            }
            else if (radioButton7.Checked == true && radioButton11.Checked == true && radioButton3.Checked == true)
            {
                sizebottom13();
            }
            else if (radioButton7.Checked == true && radioButton11.Checked == true && radioButton4.Checked == true)
            {
                sizebottom14();
            }
            else if (radioButton9.Checked == true && radioButton11.Checked == true && radioButton5.Checked == true)
            {
                sizebottomA4();
               
            }
            else if (radioButton9.Checked == true && radioButton12.Checked == true && radioButton5.Checked == true)
            {
                sizeA4();
            }
            else if (radioButton10.Checked == true && radioButton11.Checked == true && radioButton7.Checked == true)
            {
                
                sizebottomA41();
            }
            else if (radioButton10.Checked == true && radioButton12.Checked == true && radioButton7.Checked == true)
            {
                sizeA41();
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
        public void size5()
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
                    report.Load(@"Barcodebottom1.mrt");

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
        public void size6()
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
                    report.Load(@"Barcodebottom2.mrt");

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
        public void size7()
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
                    report.Load(@"Barcodebottom3.mrt");

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
        public void size8()
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
                    report.Load(@"Barcodebottom4.mrt");

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
        public void size9()
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
                    report.Load(@"Barcode7050.mrt");

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
        public void size10()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < 36; i++)
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
        public void size11()
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
                    report.Load(@"Barcode100100.mrt");

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
        public void size12()
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
                    report.Load(@"Barcode7050_2.mrt");

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
        public void size13()
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
                    report.Load(@"Barcod5070_3.mrt");

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
        public void size14()
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
                    report.Load(@"Barcode7050_4.mrt");

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
        public void sizeA4()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < 48; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"Barcode7050_4.mrt");

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
        public void size15()
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
                    report.Load(@"Barcode100100_2.mrt");

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
        public void size16()
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
                    report.Load(@"Barcode100100_3.mrt");

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
        public void size17()
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
                    report.Load(@"Barcode100100_4.mrt");

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
        public void sizeA41()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < 28; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"Barcode100100_4.mrt");

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
        public void sizebottom1()
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
                    report.Load(@"Barcode7050bottom_1.mrt");

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
        public void sizebottom2()
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
                    report.Load(@"Barcode7050bottom_2.mrt");

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
        public void sizebottom3()
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
                    report.Load(@"Barcode7050bottom_3.mrt");

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
        public void sizebottom4()
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
                    report.Load(@"Barcode7050bottom_4.mrt");

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
        public void sizebottomA4()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < 44; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"Barcode7050bottom_4.mrt");

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
        public void sizebottom11()
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
                    report.Load(@"Barcode100bottom_1.mrt");

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
        public void sizebottom12()
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
                    report.Load(@"Barcode100bottom_2.mrt");

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
        public void sizebottom13()
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
                    report.Load(@"Barcode100bottom_3.mrt");

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
        public void sizebottom14()
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
                    report.Load(@"Barcode100bottom_4.mrt");

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
        public void sizebottomA41()
        {
            dd = Convert.ToInt32(textBox1.Text);
            if (MessageBox.Show("DO YOU WANT PRINT??", "PRINT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int i = 0; i < 24; i++)
                    {
                        string Query = string.Format("select a.ItemName,a.SalePrice,a.Barcode,b.CompanyName from tbl_ItemMaster as a,tbl_CompanyMaster as b where a.Company_ID='" + NewCompany.company_id + "' and a.DeleteData='1' and b.CompanyID='" + NewCompany.company_id + "' and ItemName='{0}'", txtsearch.Text);
                        //string Query = string.Format("select Company_ID,BillDate, BillNo, PartyName, PaymentType, Total, Paid, RemainingBal, Status from tbl_PurchaseBill where Company_ID = '" + NewCompany.company_id + "' and DeleteData = '1'");

                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.Fill(ds);
                    }



                    StiReport report = new StiReport();
                    report.Load(@"Barcode100bottom_4.mrt");

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

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
