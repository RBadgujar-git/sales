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
            //  BA.AutoScroll = true;
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
            fetchdetails1();
        }
        private void fetchdetails()
        {
            con.Open();
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_ItemMasterSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemID", 0);
            cmd.Parameters.AddWithValue("@ItemName", "");
            cmd.Parameters.AddWithValue("@OpeningQty", "");
            cmd.Parameters.AddWithValue("@Action", "Select");
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
        private void fetchdetails1()
        {

            con.Open();

            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_ItemAdjustementSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", 0);
            cmd.Parameters.AddWithValue("@ItemName", "");
            cmd.Parameters.AddWithValue("@AdjustmentType", "");
            cmd.Parameters.AddWithValue("@AdjustmentDate", "");
            cmd.Parameters.AddWithValue("@AtPrice", "");
            cmd.Parameters.AddWithValue("@Quantity", "");
            cmd.Parameters.AddWithValue("@Action", "Select");
            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);

            sdasql.Fill(dtable);
            con.Close();
            guna2DataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.ColumnCount = 5;
            guna2DataGridView1.Columns[0].HeaderText = "Adjustment Type";
            guna2DataGridView1.Columns[0].DataPropertyName = "AdjustmentType";
            guna2DataGridView1.Columns[1].HeaderText = "Item Name";
            guna2DataGridView1.Columns[1].DataPropertyName = "ItemName";
            guna2DataGridView1.Columns[2].HeaderText = "Adjustment Date";
            guna2DataGridView1.Columns[2].DataPropertyName = "AdjustmentDate";
            guna2DataGridView1.Columns[3].HeaderText = "Price";
            guna2DataGridView1.Columns[3].DataPropertyName = "AtPrice";
            guna2DataGridView1.Columns[4].HeaderText = "Quantity";
            guna2DataGridView1.Columns[4].DataPropertyName = "Quantity";
            guna2DataGridView1.DataSource = dtable;

        }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Query = string.Format("select AdjustmentType,ItemName,AdjustmentDate,Quantity,AtPrice from tbl_ItemAdjustement where AdjustmentType like '%{0}%'", guna2TextBox2.Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                da.Fill(ds, "temp");
                guna2DataGridView1.DataSource = ds;
                guna2DataGridView1.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select tbl_ItemMaster.ItemName, tbl_ItemMaster.OpeningQty,tbl_ItemMaster.ItemName,tbl_ItemMaster.AtPrice,tbl_ItemAdjustement.AdjustmentType,tbl_ItemAdjustement.Quantity from tbl_ItemMaster JOIN tbl_ItemAdjustement on tbl_ItemAdjustement.ID=tbl_ItemMaster.ItemID", con);
            DataSet ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            SDA.Fill(ds);
            con.Close();
        }
    }
    }

