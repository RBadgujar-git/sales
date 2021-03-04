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
    public partial class CreditNothomePage : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public CreditNothomePage()
        {
            InitializeComponent();
        }

        private void CreditNothomePage_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreditNote BA = new CreditNote();
            BA.TopLevel = false;
           // BA.AutoScroll = true;
            this.Controls.Add(BA);
             BA.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.Show();
        }

        private void btncalcel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpto_Enter(object sender, EventArgs e)
        {
            try
            {
                string SelectQuery = string.Format("select PartyName,ReturnNo,InvoiceDate,Total,RemainingBal,PaymentType,Status, from tbl_CreditNote1 where InvoiceDate between '" + dtpfrom.Value.ToString() + "' and '" + dtpto.Value.ToString() + "'");
                DataSet ds = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                SDA.Fill(ds, "temp");
                dgvcreditNote.DataSource = ds;
                dgvcreditNote.DataMember = "temp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not" + ex);
            }
        }
    }
}
