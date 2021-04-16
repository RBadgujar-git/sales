using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class Barcodeprint : Form
    {
        public Barcodeprint()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            POS ps = new POS();
            ps.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //barcode_print.BARCODE rp = new barcode_print.BARCODE();

            //barcode dss = new barcode(); //dataset name

            //string Query = string.Format("SELECT id, net_rate, mrp, model_name from item where model_name like '%{0}%'", txtsearch.Text);

            //SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //da.Fill(dss, "item");
            //rp.SetDataSource(dss);

            //barcode_viewer PV = new barcode_viewer();
            //PV.crystalReportViewer1.ReportSource = rp;

            //PV.crystalReportViewer1.BringToFront();
            //PV.crystalReportViewer1.Visible = true;
            //PV.ShowDialog();
        }
    }
}
