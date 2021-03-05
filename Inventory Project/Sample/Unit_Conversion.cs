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
    public partial class Unit_Conversion : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        // SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";
        public Unit_Conversion()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        }

        private void fetchdetails()
        {

            //PrincipleAmount,InterestAmount,Date,	TotalAmount,PaidFrom
            con.Open();
            DataTable dtable = new DataTable();
            cmd = new SqlCommand("tbl_UnitConversionSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UnitConversionID", 0);
            cmd.Parameters.AddWithValue("@BasicUnit", "");
            cmd.Parameters.AddWithValue("@SecondaryUnit", "");
            cmd.Parameters.AddWithValue("@Rate", "");


            cmd.Parameters.AddWithValue("@Action", "Select");

            SqlDataAdapter sdasql = new SqlDataAdapter(cmd);

            sdasql.Fill(dtable);
            con.Close();
            for (int i = 0; i < dtable.Rows.Count; i++) {

                dgvUnitConversion.Rows[i].Cells[0].Value = dtable.Rows[i][0].ToString();
                dgvUnitConversion.Rows[i].Cells[1].Value = dtable.Rows[i][1].ToString();
                dgvUnitConversion.Rows[i].Cells[2].Value = dtable.Rows[i][2].ToString();
                dgvUnitConversion.Rows[i].Cells[3].Value = dtable.Rows[i][3].ToString();


            }

        }

        private void InsertData()
        {
            //PrincipleAmount,InterestAmount,Date,	TotalAmount,PaidFrom

            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("tbl_UnitConversionSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Insert");
            cmd.Parameters.AddWithValue("@UnitConversionID", id);
            cmd.Parameters.AddWithValue("@BasicUnit", txtBasicUnit.Text);
            cmd.Parameters.AddWithValue("@SecondaryUnit", txtSecondaryunit.Text);
            cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert data Successfully");


        }
        private void Unit_Conversion_Load(object sender, EventArgs e)
        {
            fetchdetails();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            fetchdetails();
        }

        private void dgvUnitConversion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBasicUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtSecondaryunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
