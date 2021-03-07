using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace sample
{
    public partial class OtherIncome : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
        //SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");
        // SqlConnection con;
        SqlCommand cmd;
        string id = "";

        public OtherIncome()
        {
            InitializeComponent();
           // con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

        }

        private void OtherIncome_Load(object sender, EventArgs e)
        {
            fetchexpenses();
            txtReturnNo.Enabled = false;
            get_id();
            txtTotal.Enabled = false;
            
            //txtitemamount.Enabled = false;
        }
        private void get_id()
        {
            if (txtReturnNo.Text != "0" || txtReturnNo.Text != "")
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.InventoryMgntConnectionString);
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-V77UKDV;Initial Catalog=InventoryMgnt;Integrated Security=True");

                con.Open();
                SqlCommand cmd = new SqlCommand("select MAX (CAST( ID as INT)) from tbl_OtherIncome", con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string Value = rd[0].ToString();
                    if (Value == "") {
                        txtReturnNo.Text = "1";
                    }
                    else
                    {
                        txtReturnNo.Text = rd[0].ToString();
                        txtReturnNo.Text = (Convert.ToInt64(txtReturnNo.Text) + 1).ToString();
                    }
                }
                con.Close();
            }
        }
        private void fetchexpenses()
        {
            if (cmbexpenses.Text != "System.Data.DataRowView") {
                try {
                    string SelectQuery = string.Format("select OtherIncome from tbl_otherIncomeCaategory where Company_ID='" + NewCompany.company_id + "' group by OtherIncome");
                    DataSet ds = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, con);
                    SDA.Fill(ds, "Temp");
                    DataTable DT = new DataTable();
                    SDA.Fill(ds);
                    for (int i = 0; i < ds.Tables["Temp"].Rows.Count; i++) {
                        cmbexpenses.Items.Add(ds.Tables["Temp"].Rows[i]["OtherIncome"].ToString());
                    }
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }
        }

        private void txtOty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float qty = 0, rate = 0, total = 0;
                qty = float.Parse(txtOty.Text.ToString());
                rate = float.Parse(txtMRP.Text.ToString());
                total = qty * rate;
                txtitemamount.Text = total.ToString();
                txtTotal.Text = total.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        object id1;
        private void insert_record_inner(string id)
        {
            for (int i = 0; i < dgvinnerexpenses.Rows.Count; i++) {
                try {
                    con.Open();
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_OtherIncomeInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@ID", id1);

                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount

                    cmd.Parameters.AddWithValue("@ItemName", dgvinnerexpenses.Rows[i].Cells["Item"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvinnerexpenses.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvinnerexpenses.Rows[i].Cells["Price/Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvinnerexpenses.Rows[i].Cells["Amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                    con.Close();
                }
            }
        }

        private void insertdata()
        {
            //ID,ExpenseCategory,Date,Description,Image,Total,Paid,Balance,AdditinalFeild1,AdditionalFeild2
            try {
                con.Open();
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_OtherIncomeSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@ID", txtReturnNo.Text);
                cmd.Parameters.AddWithValue("@IncomeCategory", cmbexpenses.Text);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Text);
                cmd.Parameters.AddWithValue("@Description", txtdescritpition.Text);           
                cmd.Parameters.AddWithValue("@Paid", txtReceived.Text);
                cmd.Parameters.AddWithValue("@Balance", txtBalance.Text);
                cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                cmd.Parameters.AddWithValue("@AdditionalFeild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Additional2", txtAdditional1.Text);
                cmd.Parameters.AddWithValue("@Status",ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableName", Income.Text);
                cmd.Parameters.AddWithValue("@compid", NewCompany.company_id);
                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Sale Record Added");
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
            finally {
                
              
                con.Close();
                insert_record_inner(id1.ToString());
            }
        }
        int row = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertdata();
            bind_sale_details();
            clear_text_data();
            cleardata();

        }

        private void txtitemamount_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyCode == Keys.Enter) {
                    float TA = 0, TD = 0, TGST = 0;
                    dgvinnerexpenses.Rows.Add();
                    row = dgvinnerexpenses.Rows.Count - 2;
                    dgvinnerexpenses.Rows[row].Cells["sr_no"].Value = row + 1;
                    dgvinnerexpenses.CurrentCell = dgvinnerexpenses[1, row];

                    e.SuppressKeyPress = true;
                    string Item = txtItem.Text;

                    string MRP = txtMRP.Text;
                    string qty = txtOty.Text;

                    string Total = txtitemamount.Text;

                    dgvinnerexpenses.Rows[row].Cells[1].Value = Item;
                    dgvinnerexpenses.Rows[row].Cells[2].Value = MRP;
                    dgvinnerexpenses.Rows[row].Cells[3].Value = qty;
                    dgvinnerexpenses.Rows[row].Cells[4].Value = Total;

                    txtItem.Focus();

                    for (int i = 0; i < dgvinnerexpenses.Rows.Count; i++) {
                        TA += float.Parse(dgvinnerexpenses.Rows[i].Cells["Amount"].Value?.ToString());

                        txtTotal.Text = TA.ToString();

                    }
                    clear_text_data();
                }
            }
            catch (Exception e1) {
                string message = e1.Message;
            }
        }
        private void clear_text_data()
        {
            txtItem.Text = "";
            txtMRP.Text = "0";
            txtOty.Text = "0";
            txtitemamount.Text = "0";
        }
        private void cleardata()
        {
            cmbexpenses.Text = "";
            txtdescritpition.Text = "";
            picturebox1.Image = null;
            txtTotal.Text = "0";
            txtReceived.Text = "0";
            txtBalance.Text = "0";
        }

        private void txtReturnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                bind_sale_details();
            }
        }
        private void bind_sale_details()
        {
            try {
                con.Open();
                string str = string.Format("SELECT * FROM tbl_OtherIncome where ID='{0}' and where Company_ID='"+NewCompany.company_id+"'", txtReturnNo.Text);
                SqlCommand cmd = new SqlCommand(str, con);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                SqlDataReader dr = cmd.ExecuteReader();
               
                if (dr.HasRows) {

                    while (dr.Read()) {
                        cmbexpenses.Text = dr["IncomeCategory"].ToString();
                        // txtBillingAdd.Text = dr["BillingName"].ToString();

                        dtpDate.Text = dr["Date"].ToString();
                        txtdescritpition.Text = dr["Description"].ToString();

                        txtTotal.Text = dr["Total"].ToString();
                        txtReceived.Text = dr["Paid"].ToString();
                        txtBalance.Text = dr["Balance"].ToString();
                        txtrefNo.Text = dr["AdditionalFeild1"].ToString();
                        txtAdditional1.Text = dr["Additional2"].ToString();
                        ComboBox.Text = dr["Status"].ToString();
                        Income.Text = dr["TableName"].ToString();
                        id = dr["id"].ToString();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);
                            ms.Seek(0, SeekOrigin.Begin);
                            picturebox1.Image = Image.FromStream(ms); ;
                            picturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
             

                string str1 = string.Format("SELECT ID,ItemName,SalePrice,Qty,ItemAmount FROM tbl_OtherIncomeInner where ID='{0}' Company_ID='" + NewCompany.company_id + "'", txtReturnNo.Text);
                SqlCommand cmd1 = new SqlCommand(str1, con);
                dr.Close();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows) {
                    int i = 0;
                    while (dr1.Read()) {
                        dgvinnerexpenses.Rows.Add();
                        dgvinnerexpenses.Rows[i].Cells["ID"].Value = i + 1;
                        dgvinnerexpenses.Rows[i].Cells["ItemName"].Value = dr1["Item"].ToString();
                        dgvinnerexpenses.Rows[i].Cells["SalePrice"].Value = dr1["Price/Unit"].ToString();

                        dgvinnerexpenses.Rows[i].Cells["Qty"].Value = dr1["Qty"].ToString();
                        dgvinnerexpenses.Rows[i].Cells["ItemAmount"].Value = dr1["Amount"].ToString();


                        i++;
                    }
                    dr1.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                con.Close();
            }
        }

        private void update_record_inner(string p)
        {
            for (int i = 0; i < dgvinnerexpenses.Rows.Count; i++) {
                try {
         
                    con.Open();
                    DataTable dtable = new DataTable();
                    cmd = new SqlCommand("tbl_OtherIncomeInnersp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@ID", id1);

                    // ItemName,HSNCode ,BasicUnit,ItemCode ,ItemCategory,SalePrice
                    //,TaxForSale ,SaleTaxAmount ,Qty,freeQty ,BatchNo,SerialNo,MFgdate,Expdate,Size,Discount,DiscountAmount,ItemAmount
                   
                    cmd.Parameters.AddWithValue("@ItemName", dgvinnerexpenses.Rows[i].Cells["Item"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", dgvinnerexpenses.Rows[i].Cells["Qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SalePrice", dgvinnerexpenses.Rows[i].Cells["Price"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ItemAmount", dgvinnerexpenses.Rows[i].Cells["Amount"].Value.ToString());

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) {
                    //MessageBox.Show(e1.Message);
                }
                finally {
                    con.Close();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                con.Open();
                DataTable dtable = new DataTable();
                cmd = new SqlCommand("tbl_OtherIncomeSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", txtReturnNo.Text);
                cmd.Parameters.AddWithValue("@IncomeCategory", cmbexpenses.Text);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Text);
                cmd.Parameters.AddWithValue("@Description", txtdescritpition.Text);
                // cmd.Parameters.AddWithValue("@Description", .Text);
                cmd.Parameters.AddWithValue("@Paid", txtReceived.Text);
                cmd.Parameters.AddWithValue("@Balance", txtBalance.Text);
                cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                cmd.Parameters.Add("@Image", SqlDbType.Image, arrImage1.Length).Value = arrImage1;
                cmd.Parameters.AddWithValue("@AdditionalFeild1", txtrefNo.Text);
                cmd.Parameters.AddWithValue("@Additional2", txtAdditional1.Text);
                cmd.Parameters.AddWithValue("@Status", ComboBox.Text);
                cmd.Parameters.AddWithValue("@TableNmae", Income.Text);
                cmd.Parameters.AddWithValue("@Action", "Update");

                id1 = cmd.ExecuteScalar();
                MessageBox.Show("Sale Record Update");
                clear_text_data();
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
            finally {
                con.Close();
                update_record_inner(txtReturnNo.ToString());
            }
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            try {
                float receive_bank = 0, receive_cash = 0, pending_amt = 0, TP = 0, GT = 0;

                // receive_bank = float.Parse(txtreceive_in_bank.Text);
                receive_cash = float.Parse(txtReceived.Text);
                GT = float.Parse(txtTotal.Text);

                //if (txtreceive_in_bank.Text != "") {
                //  TP = GT - receive_bank;
                //   txtpending_amt.Text = TP.ToString();
                //}
                //else {
                TP = GT - receive_cash;
                txtBalance.Text = TP.ToString();
                //}
            }
            catch (Exception e1) {
                MessageBox.Show(e1.Message);
            }
        }

        private void cmbexpenses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        byte[] arrImage1;
        private void picturebox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.Multiselect = true;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                int count = 1;
                foreach (String file in openFileDialog1.FileNames) {
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);

                    if (count == 1) {
                        picturebox1.Image = Image.FromFile(file);
                        //   pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                        picturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        MemoryStream ms = new MemoryStream();
                        picturebox1.Image.Save(ms, picturebox1.Image.RawFormat);
                        arrImage1 = ms.GetBuffer();
                    }
                }
            }
        }

        private void chkenble_CheckedChanged(object sender, EventArgs e)
        {
            if (chkenble.Checked == true)
            {
                txtReturnNo.Enabled = true;
                
            }
            else {
                txtReturnNo.Enabled = false;
                cleardata();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back);
            //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    e.Handled = false;
            //}
        }

        private void txtMRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtOty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtitemamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtrefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
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
