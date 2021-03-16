using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System.IO;
using System.Reflection;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop;
using System.Runtime.InteropServices;

namespace sample
{
    public partial class ImportExcel : UserControl
    {

        SqlConnection sqlconn = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        string result = "D:\\Git project\\sales\\Inventory Project\\Sample\\bin\\Debug\\ItemsTemplate.xls";

        //Save Path

        public ImportExcel()
        {
            InitializeComponent();
        }

        public FormWindowState WindowState { get; private set; }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            sfd.FileName = "Import Item Template";
            sfd.Title = "Save Excel File";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                result = sfd.FileName;
            }

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strExcelPathName, Table = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select file";
            openDialog.InitialDirectory = @"c:\";
            openDialog.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            openDialog.FilterIndex = 1;
            openDialog.RestoreDirectory = true;
            try
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openDialog.FileName != "")
                    {
                        strExcelPathName = openDialog.FileName;
                        //TxtPath.Text = strExcelPathName.ToString();
                        // comboBox1.DataSource = GetSheetNames(openDialog.FileName);

                        System.Data.OleDb.OleDbConnection MyConnection;
                        System.Data.DataSet DtSet;
                        System.Data.OleDb.OleDbDataAdapter MyCommand;
                        MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;;Data Source=" + strExcelPathName + ";Extended Properties=Excel 8.0;");
                        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                        MyCommand.TableMappings.Add("Table", "Net-informations.com");
                        DtSet = new System.Data.DataSet();       
                        MyCommand.Fill(DtSet);
                       dataGridView1.DataSource = DtSet.Tables[0];
                        MyConnection.Close();
                        //return ds.Tables[0];

                    }
                    else
                    {
                        MessageBox.Show("chose Excel sheet path..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Close();
                sqlconn.Open();
                int counter = Convert.ToInt32(dataGridView1.RowCount.ToString()) - 1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    SqlCommand cmd = new SqlCommand("insert into tbl_ItemMaster(ItemName, HSNCode, BasicUnit, SecondaryUnit, ItemCode, ItemCategory, SalePrice, TaxForSale, SaleTaxAmount, TaxForPurchase, PurchasePrice, PurchaseTaxAmount, OpeningQty, atPrice, Date, ItemLocation, TrackingMRP, BatchNo, MFgdate, Expdate, Size, Description, MinimumStock,Barcode) Values(@ItemName, @HSNCode, @BasicUnit, @SecondaryUnit, @ItemCode, @ItemCategory, @SalePrice, @TaxForSale, @SaleTaxAmount, @PurchasePrice, @TaxForPurchase, @PurchaseTaxAmount, @OpeningQty, @atPrice, @Date, @ItemLocation, @TrackingMRP, @BatchNo, @MFgdate, @Expdate, @Size, @Description, @MinimumStock, @Barcode)",sqlconn);
                    cmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@HSNCode", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@BasicUnit", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@SecondaryUnit", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@ItemCategory", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@SalePrice", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@TaxForSale", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@SaleTaxAmount", dataGridView1.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@PurchasePrice", dataGridView1.Rows[i].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@TaxForPurchase", dataGridView1.Rows[i].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@PurchaseTaxAmount", dataGridView1.Rows[i].Cells[11].Value);
                    cmd.Parameters.AddWithValue("@OpeningQty", dataGridView1.Rows[i].Cells[12].Value);
                    cmd.Parameters.AddWithValue("@atPrice", dataGridView1.Rows[i].Cells[13].Value);
                    cmd.Parameters.AddWithValue("@Date", dataGridView1.Rows[i].Cells[14].Value);
                    cmd.Parameters.AddWithValue("@ItemLocation", dataGridView1.Rows[i].Cells[15].Value);
                    cmd.Parameters.AddWithValue("@TrackingMRP", dataGridView1.Rows[i].Cells[16].Value);
                    cmd.Parameters.AddWithValue("@BatchNo", dataGridView1.Rows[i].Cells[17].Value);
                 //   cmd.Parameters.AddWithValue("@SerialNo", dataGridView1.Rows[i].Cells[18].Value);
                    cmd.Parameters.AddWithValue("@MFgdate", dataGridView1.Rows[i].Cells[19].Value);
                    cmd.Parameters.AddWithValue("@Expdate", dataGridView1.Rows[i].Cells[20].Value);
                    cmd.Parameters.AddWithValue("@Size", dataGridView1.Rows[i].Cells[21].Value);
                    cmd.Parameters.AddWithValue("@Description", dataGridView1.Rows[i].Cells[22].Value);
                    cmd.Parameters.AddWithValue("@MinimumStock", dataGridView1.Rows[i].Cells[23].Value);
                    cmd.Parameters.AddWithValue("@Barcode", dataGridView1.Rows[i].Cells[24].Value);
                    
                    cmd.ExecuteNonQuery();
                  
                        MessageBox.Show("Insert data Successfully");
                      //  Cleardata();
                    
                    //lblsaved.Text = "Saved Success";
     

                    sqlconn.Close();

                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Eror!" + es);
            }
        }

        private void ImportExcel_Load(object sender, EventArgs e)
        {

        }
       
    }
}
