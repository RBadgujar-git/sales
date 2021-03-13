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
        string result = "D:\\Git project\\sales\\Inventory Project\\Sample\\bin\\Debug\\Import Items Template.xls";

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
            sfd.Filter = "*.xls; | *.xlsx;";
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
                        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Template$]", MyConnection);
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
           
        }

        private void ImportExcel_Load(object sender, EventArgs e)
        {

        }
       
    }
}
