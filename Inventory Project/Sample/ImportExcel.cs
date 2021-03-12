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
namespace sample
{
    public partial class ImportExcel : UserControl
    {
        SqlConnection sqlconn = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
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
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excell|*.xls;*.xlsx;";
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.Abort)
                return;
            if (dr == DialogResult.Cancel)
                return;
            textBox1.Text = od.FileName.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ImportDataFromExcel(textBox1.Text);
        }

        private void ImportExcel_Load(object sender, EventArgs e)
        {

        }
        public void ImportDataFromExcel(string excelFilePath)
        {
            string ssqltable = "Employee";
            string myexceldataquery = "select Id,Name,Address from [Feuil1$]";
            try
            {
                string sexcelconnectionstring = @"provider=microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath +
                ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
                sqlconn.Open();
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlconn);
                bulkcopy.DestinationTableName = ssqltable;
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                MessageBox.Show("File imported into sql server.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
