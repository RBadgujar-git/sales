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
    public partial class AddMore : Form
    {
        public AddMore()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            int borderWidth = 5;

            Color borderColor = SystemColors.AppWorkspace;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,

            borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,

            ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,

            borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SaleInvoice si = new SaleInvoice();
            si.Show();
        }

        private void guna2Button3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_MouseLeave(object sender, EventArgs e)
        {
            guna2Button3.ForeColor = Color.Black;
            guna2Button3.Font = new Font(guna2Button3.Font.Name, guna2Button3.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button7_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void guna2Button7_MouseLeave(object sender, EventArgs e)
        {
            guna2Button7.ForeColor = Color.Black;
            guna2Button7.Font = new Font(guna2Button7.Font.Name, guna2Button7.Font.SizeInPoints, FontStyle.Bold);
        }

             private void guna2Button5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void guna2Button5_MouseLeave(object sender, EventArgs e)
        {
            guna2Button5.ForeColor = Color.Black;
            guna2Button5.Font = new Font(guna2Button5.Font.Name, guna2Button5.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button4_MouseHover(object sender, EventArgs e)
        {
            
        }
       

        private void guna2Button2_MouseHover(object sender, EventArgs e)
        {
           
        }
       
        private void guna2Button1_MouseHover(object sender, EventArgs e)
        {
            
        }
        

        private void guna2Button6_MouseHover(object sender, EventArgs e)
        {
            
        }
       
        private void guna2Button8_MouseHover(object sender, EventArgs e)
        {
            
        }
        

        private void guna2Button9_MouseHover(object sender, EventArgs e)
        {
            
        }
       

        private void guna2Button10_MouseHover(object sender, EventArgs e)
        {
            
        }
       

        private void guna2Button11_MouseHover(object sender, EventArgs e)
        {
            
        }
      

        private void guna2Button4_MouseLeave_1(object sender, EventArgs e)
        {
             guna2Button4.ForeColor = Color.Black;
            guna2Button4.Font = new Font(guna2Button4.Font.Name, guna2Button4.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
            guna2Button2.ForeColor = Color.Black;
            guna2Button2.Font = new Font(guna2Button2.Font.Name, guna2Button2.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button1_MouseLeave(object sender, EventArgs e)
        {
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Font = new Font(guna2Button1.Font.Name, guna2Button1.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button6_MouseLeave(object sender, EventArgs e)
        {
            guna2Button6.ForeColor = Color.Black;
            guna2Button6.Font = new Font(guna2Button6.Font.Name, guna2Button6.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button8_MouseLeave(object sender, EventArgs e)
        {
            guna2Button8.ForeColor = Color.Black;
            guna2Button8.Font = new Font(guna2Button8.Font.Name, guna2Button8.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button9_MouseLeave(object sender, EventArgs e)
        {
            guna2Button9.ForeColor = Color.Black;
            guna2Button9.Font = new Font(guna2Button9.Font.Name, guna2Button9.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button10_MouseLeave(object sender, EventArgs e)
        {
            guna2Button10.ForeColor = Color.Black;
            guna2Button10.Font = new Font(guna2Button10.Font.Name, guna2Button10.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button11_MouseLeave(object sender, EventArgs e)
        {
            guna2Button11.ForeColor = Color.Black;
            guna2Button11.Font = new Font(guna2Button11.Font.Name, guna2Button11.Font.SizeInPoints, FontStyle.Bold);
        }

        private void guna2Button3_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button3.ForeColor = Color.Blue;
            guna2Button3.Font = new Font(guna2Button3.Font.Name, guna2Button3.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button7_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button7.ForeColor = Color.Blue;
            guna2Button7.Font = new Font(guna2Button7.Font.Name, guna2Button7.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button5_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button5.ForeColor = Color.Blue;
            guna2Button5.Font = new Font(guna2Button5.Font.Name, guna2Button5.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button4_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button4.ForeColor = Color.Blue;
            guna2Button4.Font = new Font(guna2Button4.Font.Name, guna2Button4.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button2_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button2.ForeColor = Color.Blue;
            guna2Button2.Font = new Font(guna2Button2.Font.Name, guna2Button2.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button1_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button1.ForeColor = Color.Blue;
            guna2Button1.Font = new Font(guna2Button1.Font.Name, guna2Button1.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button6_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button6.ForeColor = Color.Blue;
            guna2Button6.Font = new Font(guna2Button6.Font.Name, guna2Button6.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button8_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button8.ForeColor = Color.Blue;
            guna2Button8.Font = new Font(guna2Button8.Font.Name, guna2Button8.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button9_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button9.ForeColor = Color.Blue;
            guna2Button9.Font = new Font(guna2Button9.Font.Name, guna2Button9.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button10_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button10.ForeColor = Color.Blue;
            guna2Button10.Font = new Font(guna2Button10.Font.Name, guna2Button10.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button11_MouseMove(object sender, MouseEventArgs e)
        {
            guna2Button11.ForeColor = Color.Blue;
            guna2Button11.Font = new Font(guna2Button11.Font.Name, guna2Button11.Font.SizeInPoints, FontStyle.Underline | FontStyle.Bold);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            PaymentIn si = new PaymentIn();
            si.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            CreditNote si = new CreditNote();
            si.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           SaleOrder si = new SaleOrder();
            si.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Estimate_Quotation si = new Estimate_Quotation();
            si.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          DeliveryChallan si = new DeliveryChallan();
            si.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            PurchaseBill si = new PurchaseBill();
            si.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            PaymentOut si = new PaymentOut();
            si.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            DebitNote si = new DebitNote();
            si.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            PurchaseOrder si = new PurchaseOrder();
            si.Show();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Expenses si = new Expenses();
            si.Show();
        }

        private void AddMore_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

           int borderWidth = 5;

            Color borderColor = SystemColors.AppWorkspace;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,

            borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,

            ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,

            borderColor, borderWidth, ButtonBorderStyle.Solid);
            // ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
 }

