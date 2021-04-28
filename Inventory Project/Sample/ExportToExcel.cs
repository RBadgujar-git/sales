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
using Microsoft.Office.Interop;
using Microsoft.Office;
using System.IO;
namespace sample
{
    public partial class ExportToExcel : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        //SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public ExportToExcel()
        {
            InitializeComponent();
        }

        private void ExportToExcel_Load(object sender, EventArgs e)
        {
            fetchdetails();
        }
        private void fetchdetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_Itemexport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Select");
            cmd.Parameters.AddWithValue("@ItemID", 0);
            cmd.Parameters.AddWithValue("@ItemName", "");
            cmd.Parameters.AddWithValue("@HSNCode", "");
            cmd.Parameters.AddWithValue("@BasicUnit", "");
            cmd.Parameters.AddWithValue("@SecondaryUnit", "");
            cmd.Parameters.AddWithValue("@ItemCode", "");
            cmd.Parameters.AddWithValue("@ItemCategory", "");
            cmd.Parameters.AddWithValue("@SalePrice", "");
            cmd.Parameters.AddWithValue("@TaxForSale", "");
            cmd.Parameters.AddWithValue("@SaleTaxAmount", "");
            cmd.Parameters.AddWithValue("@PurchasePrice", "");
            cmd.Parameters.AddWithValue("@TaxForPurchase", "");
            cmd.Parameters.AddWithValue("@PurchaseTaxAmount", "");
            cmd.Parameters.AddWithValue("@OpeningQty", "");
            cmd.Parameters.AddWithValue("@atPrice", "");
            cmd.Parameters.AddWithValue("@Date", "");
            cmd.Parameters.AddWithValue("@ItemLocation", "");
            cmd.Parameters.AddWithValue("@TrackingMRP", "");
            cmd.Parameters.AddWithValue("@BatchNo", "");
            cmd.Parameters.AddWithValue("@SerialNo", "");
            cmd.Parameters.AddWithValue("@MFgdate", "");
            cmd.Parameters.AddWithValue("@Expdate", "");
            cmd.Parameters.AddWithValue("@Size", "");
            cmd.Parameters.AddWithValue("@Description", "");
            cmd.Parameters.AddWithValue("@MinimumStock", "");
            cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
            SqlParameter sqlpara = new SqlParameter("@Image1", SqlDbType.Image);
            sqlpara.Value = DBNull.Value;
            cmd.Parameters.Add(sqlpara);

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            dgvExportData.DataSource = dtable;
            dgvExportData.AllowUserToAddRows = false;
        }

        private void tbnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvExportData, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                fetchdetails();
            }
            else
            {
                string Query = string.Format("select ItemID,ItemName,HSNCode ,BasicUnit,SecondaryUnit,ItemCode ,ItemCategory,SalePrice,TaxForSale ,SaleTaxAmount ,TaxForPurchase ,PurchasePrice,PurchaseTaxAmount ,OpeningQty,atPrice ,Date,ItemLocation,TrackingMRP,BatchNo,SerialNo,MFgdate,Expdate,Size ,Description ,MinimumStock ,Image1,Barcode from tbl_ItemMaster where ItemName like '%{0}%' and Company_ID='" + NewCompany.company_id + "' and DeleteData = '1'", textBox2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvExportData.DataSource = ds;
                dgvExportData.DataMember = "temp";
            }
        }
    }
}
