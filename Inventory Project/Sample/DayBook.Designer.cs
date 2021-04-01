namespace sample
{
    partial class DayBook
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayBook));
            this.cmbAllfirms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txttotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtmoneyIn = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMoneyOut = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.btnminimize = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Sale = new System.Windows.Forms.TabPage();
            this.Purchase = new System.Windows.Forms.TabPage();
            this.SaleOrder = new System.Windows.Forms.TabPage();
            this.PurchaseOrder = new System.Windows.Forms.TabPage();
            this.dgvSale = new System.Windows.Forms.DataGridView();
            this.dgvpurchase = new System.Windows.Forms.DataGridView();
            this.dgvsaleorder = new System.Windows.Forms.DataGridView();
            this.dgvpurchaseorder = new System.Windows.Forms.DataGridView();
            this.guna2Panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Sale.SuspendLayout();
            this.Purchase.SuspendLayout();
            this.SaleOrder.SuspendLayout();
            this.PurchaseOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsaleorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseorder)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAllfirms
            // 
            this.cmbAllfirms.BackColor = System.Drawing.Color.Transparent;
            this.cmbAllfirms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAllfirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllfirms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllfirms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbAllfirms.FocusedState.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllfirms.ForeColor = System.Drawing.Color.Blue;
            this.cmbAllfirms.HoverState.Parent = this.cmbAllfirms;
            this.cmbAllfirms.ItemHeight = 30;
            this.cmbAllfirms.Items.AddRange(new object[] {
            "All Firms"});
            this.cmbAllfirms.ItemsAppearance.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Location = new System.Drawing.Point(50, 25);
            this.cmbAllfirms.Name = "cmbAllfirms";
            this.cmbAllfirms.ShadowDecoration.Parent = this.cmbAllfirms;
            this.cmbAllfirms.Size = new System.Drawing.Size(140, 36);
            this.cmbAllfirms.StartIndex = 0;
            this.cmbAllfirms.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(879, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Print";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(832, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 26);
            this.label3.TabIndex = 30;
            this.label3.Text = "Excel\r\nReport";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.txttotal);
            this.guna2Panel1.Controls.Add(this.txtmoneyIn);
            this.guna2Panel1.Controls.Add(this.txtMoneyOut);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 509);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(981, 68);
            this.guna2Panel1.TabIndex = 37;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // txttotal
            // 
            this.txttotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotal.DefaultText = "";
            this.txttotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotal.DisabledState.Parent = this.txttotal;
            this.txttotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotal.FocusedState.Parent = this.txttotal;
            this.txttotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txttotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotal.HoverState.Parent = this.txttotal;
            this.txttotal.Location = new System.Drawing.Point(807, 13);
            this.txttotal.Name = "txttotal";
            this.txttotal.PasswordChar = '\0';
            this.txttotal.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txttotal.PlaceholderText = "0";
            this.txttotal.SelectedText = "";
            this.txttotal.ShadowDecoration.Parent = this.txttotal;
            this.txttotal.Size = new System.Drawing.Size(142, 35);
            this.txttotal.TabIndex = 41;
            this.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmoneyIn
            // 
            this.txtmoneyIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmoneyIn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmoneyIn.DefaultText = "";
            this.txtmoneyIn.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtmoneyIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtmoneyIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmoneyIn.DisabledState.Parent = this.txtmoneyIn;
            this.txtmoneyIn.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmoneyIn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmoneyIn.FocusedState.Parent = this.txtmoneyIn;
            this.txtmoneyIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtmoneyIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtmoneyIn.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmoneyIn.HoverState.Parent = this.txtmoneyIn;
            this.txtmoneyIn.Location = new System.Drawing.Point(138, 13);
            this.txtmoneyIn.Name = "txtmoneyIn";
            this.txtmoneyIn.PasswordChar = '\0';
            this.txtmoneyIn.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtmoneyIn.PlaceholderText = "0";
            this.txtmoneyIn.SelectedText = "";
            this.txtmoneyIn.ShadowDecoration.Parent = this.txtmoneyIn;
            this.txtmoneyIn.Size = new System.Drawing.Size(142, 35);
            this.txtmoneyIn.TabIndex = 40;
            this.txtmoneyIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMoneyOut
            // 
            this.txtMoneyOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoneyOut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoneyOut.DefaultText = "";
            this.txtMoneyOut.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMoneyOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMoneyOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoneyOut.DisabledState.Parent = this.txtMoneyOut;
            this.txtMoneyOut.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMoneyOut.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoneyOut.FocusedState.Parent = this.txtMoneyOut;
            this.txtMoneyOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMoneyOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMoneyOut.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMoneyOut.HoverState.Parent = this.txtMoneyOut;
            this.txtMoneyOut.Location = new System.Drawing.Point(426, 13);
            this.txtMoneyOut.Name = "txtMoneyOut";
            this.txtMoneyOut.PasswordChar = '\0';
            this.txtMoneyOut.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtMoneyOut.PlaceholderText = "0";
            this.txtMoneyOut.SelectedText = "";
            this.txtMoneyOut.ShadowDecoration.Parent = this.txtMoneyOut;
            this.txtMoneyOut.Size = new System.Drawing.Size(142, 35);
            this.txtMoneyOut.TabIndex = 39;
            this.txtMoneyOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(610, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Money In-Out :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Money In : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(306, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Money Out :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 38;
            this.label13.Text = "Transaction";
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "MM/dd/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(226, 30);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(170, 23);
            this.dtpdate.TabIndex = 39;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancel.BackgroundImage")));
            this.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncancel.Location = new System.Drawing.Point(939, 8);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(29, 26);
            this.btncancel.TabIndex = 36;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(880, 31);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 26);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(837, 33);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(24, 21);
            this.btnimport.TabIndex = 27;
            this.btnimport.UseVisualStyleBackColor = false;
            // 
            // btnminimize
            // 
            this.btnminimize.BackColor = System.Drawing.Color.White;
            this.btnminimize.BackgroundImage = global::sample.Properties.Resources.MinimizeNew;
            this.btnminimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnminimize.FlatAppearance.BorderSize = 0;
            this.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminimize.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnminimize.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnminimize.Location = new System.Drawing.Point(911, 7);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 437;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(239, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 41);
            this.groupBox1.TabIndex = 441;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(86, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 20);
            this.radioButton2.TabIndex = 440;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Purchase";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 20);
            this.radioButton1.TabIndex = 439;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Sale";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Sale);
            this.tabControl1.Controls.Add(this.Purchase);
            this.tabControl1.Controls.Add(this.SaleOrder);
            this.tabControl1.Controls.Add(this.PurchaseOrder);
            this.tabControl1.Location = new System.Drawing.Point(3, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 358);
            this.tabControl1.TabIndex = 442;
            this.tabControl1.Click += new System.EventHandler(this.Sale_Click);
            // 
            // Sale
            // 
            this.Sale.Controls.Add(this.dgvSale);
            this.Sale.Location = new System.Drawing.Point(4, 25);
            this.Sale.Name = "Sale";
            this.Sale.Padding = new System.Windows.Forms.Padding(3);
            this.Sale.Size = new System.Drawing.Size(957, 329);
            this.Sale.TabIndex = 0;
            this.Sale.Text = "Sale";
            this.Sale.Click += new System.EventHandler(this.Sale_Click);
            // 
            // Purchase
            // 
            this.Purchase.Controls.Add(this.dgvpurchase);
            this.Purchase.Location = new System.Drawing.Point(4, 25);
            this.Purchase.Name = "Purchase";
            this.Purchase.Padding = new System.Windows.Forms.Padding(3);
            this.Purchase.Size = new System.Drawing.Size(957, 329);
            this.Purchase.TabIndex = 1;
            this.Purchase.Text = "Purchase";
            this.Purchase.UseVisualStyleBackColor = true;
            this.Purchase.Click += new System.EventHandler(this.Purchase_Click);
            // 
            // SaleOrder
            // 
            this.SaleOrder.Controls.Add(this.dgvsaleorder);
            this.SaleOrder.Location = new System.Drawing.Point(4, 25);
            this.SaleOrder.Name = "SaleOrder";
            this.SaleOrder.Padding = new System.Windows.Forms.Padding(3);
            this.SaleOrder.Size = new System.Drawing.Size(957, 329);
            this.SaleOrder.TabIndex = 2;
            this.SaleOrder.Text = "Sale Order";
            this.SaleOrder.UseVisualStyleBackColor = true;
            this.SaleOrder.Click += new System.EventHandler(this.SaleOrder_Click);
            // 
            // PurchaseOrder
            // 
            this.PurchaseOrder.Controls.Add(this.dgvpurchaseorder);
            this.PurchaseOrder.Location = new System.Drawing.Point(4, 25);
            this.PurchaseOrder.Name = "PurchaseOrder";
            this.PurchaseOrder.Padding = new System.Windows.Forms.Padding(3);
            this.PurchaseOrder.Size = new System.Drawing.Size(957, 329);
            this.PurchaseOrder.TabIndex = 3;
            this.PurchaseOrder.Text = "Purchase Order";
            this.PurchaseOrder.UseVisualStyleBackColor = true;
            this.PurchaseOrder.Click += new System.EventHandler(this.PurchaseOrder_Click);
            // 
            // dgvSale
            // 
            this.dgvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSale.Location = new System.Drawing.Point(0, 0);
            this.dgvSale.Name = "dgvSale";
            this.dgvSale.Size = new System.Drawing.Size(951, 333);
            this.dgvSale.TabIndex = 0;
            // 
            // dgvpurchase
            // 
            this.dgvpurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpurchase.Location = new System.Drawing.Point(3, -2);
            this.dgvpurchase.Name = "dgvpurchase";
            this.dgvpurchase.Size = new System.Drawing.Size(951, 333);
            this.dgvpurchase.TabIndex = 1;
            // 
            // dgvsaleorder
            // 
            this.dgvsaleorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsaleorder.Location = new System.Drawing.Point(3, -2);
            this.dgvsaleorder.Name = "dgvsaleorder";
            this.dgvsaleorder.Size = new System.Drawing.Size(951, 333);
            this.dgvsaleorder.TabIndex = 1;
            // 
            // dgvpurchaseorder
            // 
            this.dgvpurchaseorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpurchaseorder.Location = new System.Drawing.Point(3, -2);
            this.dgvpurchaseorder.Name = "dgvpurchaseorder";
            this.dgvpurchaseorder.Size = new System.Drawing.Size(951, 333);
            this.dgvpurchaseorder.TabIndex = 1;
            // 
            // DayBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAllfirms);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DayBook";
            this.Size = new System.Drawing.Size(981, 577);
            this.Load += new System.EventHandler(this.DayBook_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Sale.ResumeLayout(false);
            this.Purchase.ResumeLayout(false);
            this.SaleOrder.ResumeLayout(false);
            this.PurchaseOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsaleorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpurchaseorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbAllfirms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncancel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txttotal;
        private Guna.UI2.WinForms.Guna2TextBox txtmoneyIn;
        private Guna.UI2.WinForms.Guna2TextBox txtMoneyOut;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Sale;
        private System.Windows.Forms.TabPage Purchase;
        private System.Windows.Forms.TabPage SaleOrder;
        private System.Windows.Forms.TabPage PurchaseOrder;
        private System.Windows.Forms.DataGridView dgvSale;
        private System.Windows.Forms.DataGridView dgvpurchase;
        private System.Windows.Forms.DataGridView dgvsaleorder;
        private System.Windows.Forms.DataGridView dgvpurchaseorder;
    }
}
