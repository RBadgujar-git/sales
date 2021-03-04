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
    public partial class ReferandEarn : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        public ReferandEarn()
        {
            InitializeComponent();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            ReferEarnPoints BA = new ReferEarnPoints();
            //BA.TopLevel = false;
            BA.AutoScroll = true;
            this.Controls.Add(BA);
            // CN.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            BA.Dock = DockStyle.Fill;
            BA.Visible = true;
            BA.BringToFront();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

            private void ReferandEarn_Load(object sender, EventArgs e)
            {
                fetchReferalCode();
          }
       

        private void fetchReferalCode()
        {
            if (cmbReferalCode.Text != "System.Data.DataRowView")
            {
                try
                {
                    string SelectQuery = string.Format("select ReferaleCode from tbl_CompanyMaster group by ReferaleCode");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++)
                    {

                        cmbReferalCode.Items.Add(ds.Tables["Temp"].Rows[i]["ReferaleCode"].ToString());

                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void cmbReferalCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}