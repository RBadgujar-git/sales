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
    public partial class Item_Tracking : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public FormWindowState WindowState { get; private set; }

        public Item_Tracking()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void fetchdetails()
        {

            con.Open();

            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_ItemMasterSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;



        }
            private void Item_Tracking_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
                    }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
                    }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //con.Open();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("tbl_ExpenseCategorySelect", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Action", "Insert");
            //cmd.Parameters.AddWithValue("@TrackingMRP", .Text);
            //cmd.Parameters.AddWithValue("@BatchNo", txtDetails);
            //cmd.Parameters.AddWithValue("@SerialNo", txtDetails);
            //cmd.Parameters.AddWithValue("@MFgdate", txtCashadjustment.Text);
            //cmd.Parameters.AddWithValue("@Expdate", txtenterAmount.Text);
            //cmd.Parameters.AddWithValue("@Size", dtpdate.Text);
            //cmd.ExecuteNonQuery();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
