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
using System.IO;
namespace sample
{
    public partial class ItemHomepage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-UK7P4M8\\SQLEXPRESS;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        // string id = "";
        public ItemHomepage()
        {
            InitializeComponent();
            //   con = new SqlConnection("Data Source=DESKTOP-UK7P4M8\\SQLEXPRESS;Initial Catalog=InventoryMgnt;Integrated Security=True");


        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ItemSevice BA = new ItemSevice();
            BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Itemmaster BA = new Itemmaster();
            BA.TopLevel = false;
              BA.AutoScroll = true;
            this.Controls.Add(BA);
            BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Add_Unit BA = new Add_Unit();
            demoaddunit BA = new demoaddunit();
            BA.TopLevel = false;
            // BA.AutoScroll = true;
            // BA.HorizontalScroll = true;
            this.Controls.Add(BA);
            // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OnlineStore BA = new OnlineStore();
            // BA.TopLevel = false;
            BA.AutoScroll = true;

            this.Controls.Add(BA);
            // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AdjustItem BA = new AdjustItem();
            // BA.TopLevel = false;
            //  BA.AutoScroll = true;
            this.Controls.Add(BA);
            // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }


        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Category BA = new Category();
            // BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            // BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }


        private void ItemHomepage_Load(object sender, EventArgs e)
        {
            fetchdetails();
           // fetchdetails1();
        }
        private void fetchdetails()
        {
            con.Open();
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("select * from tbl_ItemMaster", con);
            cmd.Parameters.AddWithValue("@ItemName","");
            cmd.Parameters.AddWithValue("@OpeningQty","");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);
            sdasql.Fill(dtable);
            con.Close();
            dgvItem.AutoGenerateColumns = false;
            dgvItem.ColumnCount = 2;
            dgvItem.Columns[0].HeaderText = "Item Name";
            dgvItem.Columns[0].DataPropertyName = "ItemName";
            dgvItem.Columns[1].HeaderText = "Quantity";
            dgvItem.Columns[1].DataPropertyName = "OpeningQty";
            dgvItem.DataSource = dtable;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select ItemName,OpeningQty from tbl_ItemMaster where ItemName like '%{0}%'", guna2TextBox1.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                dgvItem.DataSource = ds;
                dgvItem.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          


        }

        private void Stock_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ItemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                 con.Open();
                string Query = String.Format("select SalePrice,atPrice,PurchasePrice from tbl_ItemMaster where (ItemName='{0}') GROUP BY SalePrice,atPrice,PurchasePrice", lblItemName.Text);
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    SalePrice.Text = dr["SalePrice"].ToString();
                    PurchasePrice.Text = dr["PurchasePrice"].ToString();
                    StockPrice.Text = dr["atPrice"].ToString();
                }
                dr.Close();
                // txtItemCode.Focus();
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

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                lblItemName.Text = dgvItem.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                lblStock.Text = dgvItem.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                // lblItemName.Text = dgvItem.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
                // lblStock.Text = dgvItem.Rows[e.RowIndex].Cells["OpeningQty"].Value.ToString();

                string Query = string.Format("(select P.TableName,P.PartyName,C.SalePrice,C.Qty,C.freeQty,P.Status from tbl_CreditNote1 as P Inner Join tbl_CreditNoteInner as C on P.ID=C.ID where ItemName='{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_DebitNote as P Inner Join tbl_DebitNoteInner as C on P.ID = C.ID  where ItemName = '{0}')Union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_DeliveryChallan as P Inner Join tbl_DeliveryChallanInner as C on P.ID = C.ID  where ItemName = '{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_PurchaseBill as P Inner Join tbl_PurchaseBillInner as C on P.ID = C.ID  where ItemName = '{0}')Union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_PurchaseOrder as P Inner Join tbl_PurchaseOrderInner as C on P.ID = C.ID  where ItemName = '{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tblQuotation as P Inner Join tbl_QuotationInner as C on P.ID = C.ID  where ItemName = '{0}')Union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_SaleInvoice as P Inner Join tbl_SaleInvoiceInner as C on P.ID = C.ID  where ItemName = '{0}')union all(select P.TableName, P.PartyName, C.SalePrice, C.Qty, C.freeQty, P.Status from tbl_SaleOrder as P Inner Join tbl_SaleOrderInner as C on P.ID = C.ID where ItemName = '{0}')", lblItemName.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            da.Fill(ds, "temp");
            dgvItemDetails.DataSource = ds;
            dgvItemDetails.DataMember = "temp";
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }

