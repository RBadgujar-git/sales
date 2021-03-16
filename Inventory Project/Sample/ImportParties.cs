using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sample
{
    public partial class ImportParties : UserControl
    {
        string result = "D:\\Git project\\sales\\Inventory Project\\Sample\\bin\\Debug\\ImportPartiesTemplate.xlsx";
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);

        public ImportParties()
        {
            InitializeComponent();
        }

        public FormWindowState WindowState { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
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
            sfd.Filter = "*.xlsx | *.xls";
            sfd.FileName = "ImportPartiesTemplate";
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // int i = 0;




                int counter =Convert.ToInt32 (dataGridView1.RowCount.ToString())-1;

               // MessageBox.Show("dta va"+counter);

                for (int i = 0; i <counter; i++)

                {
                    SqlCommand cmd = new SqlCommand(" insert into tbl_PartyMaster (PartyName,ContactNo,BillingAddress,EmailID,GSTType,State,OpeningBal,AsOfDate,AddRemainder,PartyType,ShippingAddress,PartyGroup,PaidStatus) values(@PartyName,@ContactNo,@BillingAddress,@EmailID,@GSTType,@State,@OpeningBal,@AsOfDate,@AddRemainder,@PartyType,@ShippingAddress,@PartyGroup,@paidstatus)", con);
                    cmd.Parameters.AddWithValue("@PartyName", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@ContactNo", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@BillingAddress", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@EmailID", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@GSTType", dataGridView1.Rows[i].Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@State", dataGridView1.Rows[i].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@OpeningBal", dataGridView1.Rows[i].Cells[6].Value.ToString());
                    cmd.Parameters.AddWithValue("@AsOfDate", dataGridView1.Rows[i].Cells[7].Value.ToString());
                    cmd.Parameters.AddWithValue("@AddRemainder", dataGridView1.Rows[i].Cells[8].Value.ToString());
                    cmd.Parameters.AddWithValue("@PartyType", dataGridView1.Rows[i].Cells[9].Value.ToString());
                    cmd.Parameters.AddWithValue("@ShippingAddress", dataGridView1.Rows[i].Cells[10].Value.ToString());
                    cmd.Parameters.AddWithValue("@PartyGroup", dataGridView1.Rows[i].Cells[11].Value.ToString());
                    cmd.Parameters.AddWithValue("@paidstatus", dataGridView1.Rows[i].Cells[12].Value.ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert data Successfully");
                    con.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
                //throw;
            }
            finally
            { con.Close(); }
        }
    }

}