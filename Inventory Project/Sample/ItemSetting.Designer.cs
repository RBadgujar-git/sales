namespace sample
{
    partial class ItemSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSetting));
            this.cmbmgfdate = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSerialNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBatchNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMRP = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkmfgDate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkSerialNo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkBatchNo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkMRP = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkStockMaintance = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.guna2NumericUpDown3 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.chkEnableItem = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkShowLowstockDailog = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkItemsUnit = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProductService = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chkBarcodeScan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkDirectBarcodescan = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkCustomerEnable = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkItemsCategory = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkPartyWiseItem = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkDescription = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkItemWiseTax = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2CheckBox16 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.txtmfgdate = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtexpdate = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkExpdate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtSize = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkSize = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnminimize = new System.Windows.Forms.Button();
            this.expcomb = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2NumericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbmgfdate
            // 
            this.cmbmgfdate.BackColor = System.Drawing.Color.Transparent;
            this.cmbmgfdate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbmgfdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmgfdate.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbmgfdate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbmgfdate.FocusedState.Parent = this.cmbmgfdate;
            this.cmbmgfdate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbmgfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbmgfdate.HoverState.Parent = this.cmbmgfdate;
            this.cmbmgfdate.ItemHeight = 30;
            this.cmbmgfdate.Items.AddRange(new object[] {
            "dd/mm/yyyy",
            "mm/yyyy"});
            this.cmbmgfdate.ItemsAppearance.Parent = this.cmbmgfdate;
            this.cmbmgfdate.Location = new System.Drawing.Point(525, 213);
            this.cmbmgfdate.Name = "cmbmgfdate";
            this.cmbmgfdate.ShadowDecoration.Parent = this.cmbmgfdate;
            this.cmbmgfdate.Size = new System.Drawing.Size(128, 36);
            this.cmbmgfdate.StartIndex = 0;
            this.cmbmgfdate.TabIndex = 368;
            this.cmbmgfdate.SelectedIndexChanged += new System.EventHandler(this.cmbmgfdate_SelectedIndexChanged_1);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSerialNo.DefaultText = "Serial No.";
            this.txtSerialNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSerialNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSerialNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNo.DisabledState.Parent = this.txtSerialNo;
            this.txtSerialNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNo.FocusedState.Parent = this.txtSerialNo;
            this.txtSerialNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSerialNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNo.HoverState.Parent = this.txtSerialNo;
            this.txtSerialNo.Location = new System.Drawing.Point(658, 164);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.PasswordChar = '\0';
            this.txtSerialNo.PlaceholderText = "";
            this.txtSerialNo.SelectedText = "";
            this.txtSerialNo.SelectionStart = 10;
            this.txtSerialNo.ShadowDecoration.Parent = this.txtSerialNo;
            this.txtSerialNo.Size = new System.Drawing.Size(200, 36);
            this.txtSerialNo.TabIndex = 367;
            this.txtSerialNo.TextChanged += new System.EventHandler(this.txtSerialNo_TextChanged_1);
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBatchNo.DefaultText = "Batch No.";
            this.txtBatchNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBatchNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBatchNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBatchNo.DisabledState.Parent = this.txtBatchNo;
            this.txtBatchNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBatchNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBatchNo.FocusedState.Parent = this.txtBatchNo;
            this.txtBatchNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBatchNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBatchNo.HoverState.Parent = this.txtBatchNo;
            this.txtBatchNo.Location = new System.Drawing.Point(658, 122);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.PasswordChar = '\0';
            this.txtBatchNo.PlaceholderText = "";
            this.txtBatchNo.SelectedText = "";
            this.txtBatchNo.SelectionStart = 9;
            this.txtBatchNo.ShadowDecoration.Parent = this.txtBatchNo;
            this.txtBatchNo.Size = new System.Drawing.Size(200, 36);
            this.txtBatchNo.TabIndex = 366;
            this.txtBatchNo.TextChanged += new System.EventHandler(this.txtBatchNo_TextChanged_1);
            // 
            // txtMRP
            // 
            this.txtMRP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMRP.DefaultText = "MRP";
            this.txtMRP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMRP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMRP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMRP.DisabledState.Parent = this.txtMRP;
            this.txtMRP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMRP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMRP.FocusedState.Parent = this.txtMRP;
            this.txtMRP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMRP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMRP.HoverState.Parent = this.txtMRP;
            this.txtMRP.Location = new System.Drawing.Point(658, 75);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.PasswordChar = '\0';
            this.txtMRP.PlaceholderText = "";
            this.txtMRP.SelectedText = "";
            this.txtMRP.SelectionStart = 3;
            this.txtMRP.ShadowDecoration.Parent = this.txtMRP;
            this.txtMRP.Size = new System.Drawing.Size(200, 36);
            this.txtMRP.TabIndex = 365;
            this.txtMRP.TextChanged += new System.EventHandler(this.txtMRP_TextChanged_1);
            // 
            // chkmfgDate
            // 
            this.chkmfgDate.AutoSize = true;
            this.chkmfgDate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkmfgDate.CheckedState.BorderRadius = 0;
            this.chkmfgDate.CheckedState.BorderThickness = 0;
            this.chkmfgDate.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkmfgDate.Location = new System.Drawing.Point(430, 220);
            this.chkmfgDate.Name = "chkmfgDate";
            this.chkmfgDate.Size = new System.Drawing.Size(87, 20);
            this.chkmfgDate.TabIndex = 362;
            this.chkmfgDate.Text = "Mfg Date";
            this.chkmfgDate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkmfgDate.UncheckedState.BorderRadius = 0;
            this.chkmfgDate.UncheckedState.BorderThickness = 0;
            this.chkmfgDate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkmfgDate.CheckedChanged += new System.EventHandler(this.guna2CheckBox4_CheckedChanged);
            // 
            // chkSerialNo
            // 
            this.chkSerialNo.AutoSize = true;
            this.chkSerialNo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSerialNo.CheckedState.BorderRadius = 0;
            this.chkSerialNo.CheckedState.BorderThickness = 0;
            this.chkSerialNo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSerialNo.Location = new System.Drawing.Point(430, 173);
            this.chkSerialNo.Name = "chkSerialNo";
            this.chkSerialNo.Size = new System.Drawing.Size(90, 20);
            this.chkSerialNo.TabIndex = 361;
            this.chkSerialNo.Text = "Serial No.";
            this.chkSerialNo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSerialNo.UncheckedState.BorderRadius = 0;
            this.chkSerialNo.UncheckedState.BorderThickness = 0;
            this.chkSerialNo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSerialNo.CheckedChanged += new System.EventHandler(this.chkSerialNo_CheckedChanged);
            // 
            // chkBatchNo
            // 
            this.chkBatchNo.AutoSize = true;
            this.chkBatchNo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkBatchNo.CheckedState.BorderRadius = 0;
            this.chkBatchNo.CheckedState.BorderThickness = 0;
            this.chkBatchNo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkBatchNo.Location = new System.Drawing.Point(432, 125);
            this.chkBatchNo.Name = "chkBatchNo";
            this.chkBatchNo.Size = new System.Drawing.Size(92, 20);
            this.chkBatchNo.TabIndex = 358;
            this.chkBatchNo.Text = "Batch No.";
            this.chkBatchNo.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkBatchNo.UncheckedState.BorderRadius = 0;
            this.chkBatchNo.UncheckedState.BorderThickness = 0;
            this.chkBatchNo.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkBatchNo.CheckedChanged += new System.EventHandler(this.chkBatchNo_CheckedChanged);
            // 
            // chkMRP
            // 
            this.chkMRP.AutoSize = true;
            this.chkMRP.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkMRP.CheckedState.BorderRadius = 0;
            this.chkMRP.CheckedState.BorderThickness = 0;
            this.chkMRP.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkMRP.Location = new System.Drawing.Point(431, 84);
            this.chkMRP.Name = "chkMRP";
            this.chkMRP.Size = new System.Drawing.Size(54, 20);
            this.chkMRP.TabIndex = 357;
            this.chkMRP.Text = "MRP";
            this.chkMRP.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkMRP.UncheckedState.BorderRadius = 0;
            this.chkMRP.UncheckedState.BorderThickness = 0;
            this.chkMRP.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkMRP.CheckedChanged += new System.EventHandler(this.chkMRP_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 626);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 354;
            this.label3.Text = "Quantity";
            // 
            // chkStockMaintance
            // 
            this.chkStockMaintance.AutoSize = true;
            this.chkStockMaintance.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkStockMaintance.CheckedState.BorderRadius = 0;
            this.chkStockMaintance.CheckedState.BorderThickness = 0;
            this.chkStockMaintance.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkStockMaintance.Location = new System.Drawing.Point(84, 290);
            this.chkStockMaintance.Name = "chkStockMaintance";
            this.chkStockMaintance.Size = new System.Drawing.Size(138, 20);
            this.chkStockMaintance.TabIndex = 353;
            this.chkStockMaintance.Text = "Stock Maintance";
            this.chkStockMaintance.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkStockMaintance.UncheckedState.BorderRadius = 0;
            this.chkStockMaintance.UncheckedState.BorderThickness = 0;
            this.chkStockMaintance.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(428, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(210, 18);
            this.label11.TabIndex = 352;
            this.label11.Text = "Additional Item Columns";
            // 
            // guna2NumericUpDown3
            // 
            this.guna2NumericUpDown3.BackColor = System.Drawing.Color.Transparent;
            this.guna2NumericUpDown3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2NumericUpDown3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2NumericUpDown3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2NumericUpDown3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2NumericUpDown3.DisabledState.Parent = this.guna2NumericUpDown3;
            this.guna2NumericUpDown3.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.guna2NumericUpDown3.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.guna2NumericUpDown3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2NumericUpDown3.FocusedState.Parent = this.guna2NumericUpDown3;
            this.guna2NumericUpDown3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2NumericUpDown3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2NumericUpDown3.Location = new System.Drawing.Point(165, 623);
            this.guna2NumericUpDown3.Name = "guna2NumericUpDown3";
            this.guna2NumericUpDown3.ShadowDecoration.Parent = this.guna2NumericUpDown3;
            this.guna2NumericUpDown3.Size = new System.Drawing.Size(71, 26);
            this.guna2NumericUpDown3.TabIndex = 351;
            // 
            // chkEnableItem
            // 
            this.chkEnableItem.AutoSize = true;
            this.chkEnableItem.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkEnableItem.CheckedState.BorderRadius = 0;
            this.chkEnableItem.CheckedState.BorderThickness = 0;
            this.chkEnableItem.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkEnableItem.Location = new System.Drawing.Point(84, 84);
            this.chkEnableItem.Name = "chkEnableItem";
            this.chkEnableItem.Size = new System.Drawing.Size(105, 20);
            this.chkEnableItem.TabIndex = 350;
            this.chkEnableItem.Text = "Enable Item";
            this.chkEnableItem.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkEnableItem.UncheckedState.BorderRadius = 0;
            this.chkEnableItem.UncheckedState.BorderThickness = 0;
            this.chkEnableItem.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkEnableItem.CheckedChanged += new System.EventHandler(this.chkEnableItem_CheckedChanged);
            // 
            // chkShowLowstockDailog
            // 
            this.chkShowLowstockDailog.AutoSize = true;
            this.chkShowLowstockDailog.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowLowstockDailog.CheckedState.BorderRadius = 0;
            this.chkShowLowstockDailog.CheckedState.BorderThickness = 0;
            this.chkShowLowstockDailog.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowLowstockDailog.Location = new System.Drawing.Point(84, 332);
            this.chkShowLowstockDailog.Name = "chkShowLowstockDailog";
            this.chkShowLowstockDailog.Size = new System.Drawing.Size(181, 20);
            this.chkShowLowstockDailog.TabIndex = 349;
            this.chkShowLowstockDailog.Text = "Show Low Stock Dailog";
            this.chkShowLowstockDailog.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowLowstockDailog.UncheckedState.BorderRadius = 0;
            this.chkShowLowstockDailog.UncheckedState.BorderThickness = 0;
            this.chkShowLowstockDailog.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkItemsUnit
            // 
            this.chkItemsUnit.AutoSize = true;
            this.chkItemsUnit.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkItemsUnit.CheckedState.BorderRadius = 0;
            this.chkItemsUnit.CheckedState.BorderThickness = 0;
            this.chkItemsUnit.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkItemsUnit.Location = new System.Drawing.Point(84, 372);
            this.chkItemsUnit.Name = "chkItemsUnit";
            this.chkItemsUnit.Size = new System.Drawing.Size(95, 20);
            this.chkItemsUnit.TabIndex = 348;
            this.chkItemsUnit.Text = "Items Unit";
            this.chkItemsUnit.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkItemsUnit.UncheckedState.BorderRadius = 0;
            this.chkItemsUnit.UncheckedState.BorderThickness = 0;
            this.chkItemsUnit.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Black;
            this.guna2Panel2.Location = new System.Drawing.Point(431, 58);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(350, 2);
            this.guna2Panel2.TabIndex = 347;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Black;
            this.guna2Panel1.Location = new System.Drawing.Point(74, 59);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(200, 2);
            this.guna2Panel1.TabIndex = 346;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 345;
            this.label1.Text = "Item Setting";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(1025, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 26);
            this.button4.TabIndex = 344;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 373;
            this.label2.Text = "What do you Sale";
            // 
            // cmbProductService
            // 
            this.cmbProductService.BackColor = System.Drawing.Color.Transparent;
            this.cmbProductService.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProductService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProductService.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProductService.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProductService.FocusedState.Parent = this.cmbProductService;
            this.cmbProductService.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProductService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProductService.HoverState.Parent = this.cmbProductService;
            this.cmbProductService.ItemHeight = 30;
            this.cmbProductService.Items.AddRange(new object[] {
            "Product/Sevices",
            "Product",
            "Services"});
            this.cmbProductService.ItemsAppearance.Parent = this.cmbProductService;
            this.cmbProductService.Location = new System.Drawing.Point(213, 118);
            this.cmbProductService.Name = "cmbProductService";
            this.cmbProductService.ShadowDecoration.Parent = this.cmbProductService;
            this.cmbProductService.Size = new System.Drawing.Size(151, 36);
            this.cmbProductService.StartIndex = 0;
            this.cmbProductService.TabIndex = 374;
            // 
            // chkBarcodeScan
            // 
            this.chkBarcodeScan.AutoSize = true;
            this.chkBarcodeScan.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkBarcodeScan.CheckedState.BorderRadius = 0;
            this.chkBarcodeScan.CheckedState.BorderThickness = 0;
            this.chkBarcodeScan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkBarcodeScan.Location = new System.Drawing.Point(84, 164);
            this.chkBarcodeScan.Name = "chkBarcodeScan";
            this.chkBarcodeScan.Size = new System.Drawing.Size(118, 20);
            this.chkBarcodeScan.TabIndex = 378;
            this.chkBarcodeScan.Text = "Barcode Scan";
            this.chkBarcodeScan.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkBarcodeScan.UncheckedState.BorderRadius = 0;
            this.chkBarcodeScan.UncheckedState.BorderThickness = 0;
            this.chkBarcodeScan.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkDirectBarcodescan
            // 
            this.chkDirectBarcodescan.AutoSize = true;
            this.chkDirectBarcodescan.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDirectBarcodescan.CheckedState.BorderRadius = 0;
            this.chkDirectBarcodescan.CheckedState.BorderThickness = 0;
            this.chkDirectBarcodescan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDirectBarcodescan.Location = new System.Drawing.Point(84, 206);
            this.chkDirectBarcodescan.Name = "chkDirectBarcodescan";
            this.chkDirectBarcodescan.Size = new System.Drawing.Size(162, 20);
            this.chkDirectBarcodescan.TabIndex = 377;
            this.chkDirectBarcodescan.Text = "Direct Barcode Scan";
            this.chkDirectBarcodescan.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDirectBarcodescan.UncheckedState.BorderRadius = 0;
            this.chkDirectBarcodescan.UncheckedState.BorderThickness = 0;
            this.chkDirectBarcodescan.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkCustomerEnable
            // 
            this.chkCustomerEnable.AutoSize = true;
            this.chkCustomerEnable.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCustomerEnable.CheckedState.BorderRadius = 0;
            this.chkCustomerEnable.CheckedState.BorderThickness = 0;
            this.chkCustomerEnable.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCustomerEnable.Location = new System.Drawing.Point(84, 246);
            this.chkCustomerEnable.Name = "chkCustomerEnable";
            this.chkCustomerEnable.Size = new System.Drawing.Size(271, 20);
            this.chkCustomerEnable.TabIndex = 376;
            this.chkCustomerEnable.Text = "Customer Enable Payment Remainder";
            this.chkCustomerEnable.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkCustomerEnable.UncheckedState.BorderRadius = 0;
            this.chkCustomerEnable.UncheckedState.BorderThickness = 0;
            this.chkCustomerEnable.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkItemsCategory
            // 
            this.chkItemsCategory.AutoSize = true;
            this.chkItemsCategory.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkItemsCategory.CheckedState.BorderRadius = 0;
            this.chkItemsCategory.CheckedState.BorderThickness = 0;
            this.chkItemsCategory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkItemsCategory.Location = new System.Drawing.Point(84, 409);
            this.chkItemsCategory.Name = "chkItemsCategory";
            this.chkItemsCategory.Size = new System.Drawing.Size(129, 20);
            this.chkItemsCategory.TabIndex = 383;
            this.chkItemsCategory.Text = "Items Category";
            this.chkItemsCategory.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkItemsCategory.UncheckedState.BorderRadius = 0;
            this.chkItemsCategory.UncheckedState.BorderThickness = 0;
            this.chkItemsCategory.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkPartyWiseItem
            // 
            this.chkPartyWiseItem.AutoSize = true;
            this.chkPartyWiseItem.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPartyWiseItem.CheckedState.BorderRadius = 0;
            this.chkPartyWiseItem.CheckedState.BorderThickness = 0;
            this.chkPartyWiseItem.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPartyWiseItem.Location = new System.Drawing.Point(84, 449);
            this.chkPartyWiseItem.Name = "chkPartyWiseItem";
            this.chkPartyWiseItem.Size = new System.Drawing.Size(168, 20);
            this.chkPartyWiseItem.TabIndex = 382;
            this.chkPartyWiseItem.Text = "Party Wise Item Rate";
            this.chkPartyWiseItem.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkPartyWiseItem.UncheckedState.BorderRadius = 0;
            this.chkPartyWiseItem.UncheckedState.BorderThickness = 0;
            this.chkPartyWiseItem.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkDescription
            // 
            this.chkDescription.AutoSize = true;
            this.chkDescription.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDescription.CheckedState.BorderRadius = 0;
            this.chkDescription.CheckedState.BorderThickness = 0;
            this.chkDescription.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkDescription.Location = new System.Drawing.Point(84, 493);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.Size = new System.Drawing.Size(100, 20);
            this.chkDescription.TabIndex = 381;
            this.chkDescription.Text = "Description";
            this.chkDescription.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDescription.UncheckedState.BorderRadius = 0;
            this.chkDescription.UncheckedState.BorderThickness = 0;
            this.chkDescription.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkDescription.CheckedChanged += new System.EventHandler(this.guna2CheckBox14_CheckedChanged);
            // 
            // chkItemWiseTax
            // 
            this.chkItemWiseTax.AutoSize = true;
            this.chkItemWiseTax.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkItemWiseTax.CheckedState.BorderRadius = 0;
            this.chkItemWiseTax.CheckedState.BorderThickness = 0;
            this.chkItemWiseTax.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkItemWiseTax.Location = new System.Drawing.Point(84, 535);
            this.chkItemWiseTax.Name = "chkItemWiseTax";
            this.chkItemWiseTax.Size = new System.Drawing.Size(120, 20);
            this.chkItemWiseTax.TabIndex = 380;
            this.chkItemWiseTax.Text = "Item Wise Tax";
            this.chkItemWiseTax.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkItemWiseTax.UncheckedState.BorderRadius = 0;
            this.chkItemWiseTax.UncheckedState.BorderThickness = 0;
            this.chkItemWiseTax.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkItemWiseTax.CheckedChanged += new System.EventHandler(this.chkItemWiseTax_CheckedChanged);
            // 
            // guna2CheckBox16
            // 
            this.guna2CheckBox16.AutoSize = true;
            this.guna2CheckBox16.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox16.CheckedState.BorderRadius = 0;
            this.guna2CheckBox16.CheckedState.BorderThickness = 0;
            this.guna2CheckBox16.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox16.Location = new System.Drawing.Point(84, 575);
            this.guna2CheckBox16.Name = "guna2CheckBox16";
            this.guna2CheckBox16.Size = new System.Drawing.Size(162, 20);
            this.guna2CheckBox16.TabIndex = 379;
            this.guna2CheckBox16.Text = "Items Wise Discount";
            this.guna2CheckBox16.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox16.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox16.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox16.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox16.CheckedChanged += new System.EventHandler(this.guna2CheckBox16_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(644, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 16);
            this.label9.TabIndex = 384;
            this.label9.Text = "(Batch Tracking)";
            // 
            // guna2Button3
            // 
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.White;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.Blue;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(176, 488);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(124, 29);
            this.guna2Button3.TabIndex = 385;
            this.guna2Button3.Text = "Change Texts";
            // 
            // txtmfgdate
            // 
            this.txtmfgdate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmfgdate.DefaultText = "Mfg Date";
            this.txtmfgdate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtmfgdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtmfgdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmfgdate.DisabledState.Parent = this.txtmfgdate;
            this.txtmfgdate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmfgdate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmfgdate.FocusedState.Parent = this.txtmfgdate;
            this.txtmfgdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtmfgdate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmfgdate.HoverState.Parent = this.txtmfgdate;
            this.txtmfgdate.Location = new System.Drawing.Point(659, 213);
            this.txtmfgdate.Name = "txtmfgdate";
            this.txtmfgdate.PasswordChar = '\0';
            this.txtmfgdate.PlaceholderText = "";
            this.txtmfgdate.SelectedText = "";
            this.txtmfgdate.SelectionStart = 8;
            this.txtmfgdate.ShadowDecoration.Parent = this.txtmfgdate;
            this.txtmfgdate.Size = new System.Drawing.Size(200, 36);
            this.txtmfgdate.TabIndex = 386;
            this.txtmfgdate.TextChanged += new System.EventHandler(this.txtmfgdate_TextChanged_1);
            // 
            // txtexpdate
            // 
            this.txtexpdate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtexpdate.DefaultText = "Exp Date";
            this.txtexpdate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtexpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtexpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtexpdate.DisabledState.Parent = this.txtexpdate;
            this.txtexpdate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtexpdate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtexpdate.FocusedState.Parent = this.txtexpdate;
            this.txtexpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtexpdate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtexpdate.HoverState.Parent = this.txtexpdate;
            this.txtexpdate.Location = new System.Drawing.Point(659, 263);
            this.txtexpdate.Name = "txtexpdate";
            this.txtexpdate.PasswordChar = '\0';
            this.txtexpdate.PlaceholderText = "";
            this.txtexpdate.SelectedText = "";
            this.txtexpdate.SelectionStart = 8;
            this.txtexpdate.ShadowDecoration.Parent = this.txtexpdate;
            this.txtexpdate.Size = new System.Drawing.Size(200, 36);
            this.txtexpdate.TabIndex = 389;
            this.txtexpdate.TextChanged += new System.EventHandler(this.txtexpdate_TextChanged_1);
            // 
            // chkExpdate
            // 
            this.chkExpdate.AutoSize = true;
            this.chkExpdate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkExpdate.CheckedState.BorderRadius = 0;
            this.chkExpdate.CheckedState.BorderThickness = 0;
            this.chkExpdate.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkExpdate.Location = new System.Drawing.Point(430, 270);
            this.chkExpdate.Name = "chkExpdate";
            this.chkExpdate.Size = new System.Drawing.Size(86, 20);
            this.chkExpdate.TabIndex = 387;
            this.chkExpdate.Text = "Exp Date";
            this.chkExpdate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkExpdate.UncheckedState.BorderRadius = 0;
            this.chkExpdate.UncheckedState.BorderThickness = 0;
            this.chkExpdate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkExpdate.CheckedChanged += new System.EventHandler(this.chkExpdate_CheckedChanged);
            // 
            // txtSize
            // 
            this.txtSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSize.DefaultText = "Size";
            this.txtSize.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSize.DisabledState.Parent = this.txtSize;
            this.txtSize.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSize.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSize.FocusedState.Parent = this.txtSize;
            this.txtSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSize.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSize.HoverState.Parent = this.txtSize;
            this.txtSize.Location = new System.Drawing.Point(659, 305);
            this.txtSize.Name = "txtSize";
            this.txtSize.PasswordChar = '\0';
            this.txtSize.PlaceholderText = "";
            this.txtSize.SelectedText = "";
            this.txtSize.SelectionStart = 4;
            this.txtSize.ShadowDecoration.Parent = this.txtSize;
            this.txtSize.Size = new System.Drawing.Size(200, 36);
            this.txtSize.TabIndex = 391;
            this.txtSize.TextChanged += new System.EventHandler(this.guna2TextBox6_TextChanged);
            // 
            // chkSize
            // 
            this.chkSize.AutoSize = true;
            this.chkSize.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSize.CheckedState.BorderRadius = 0;
            this.chkSize.CheckedState.BorderThickness = 0;
            this.chkSize.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSize.Location = new System.Drawing.Point(431, 314);
            this.chkSize.Name = "chkSize";
            this.chkSize.Size = new System.Drawing.Size(54, 20);
            this.chkSize.TabIndex = 390;
            this.chkSize.Text = "Size";
            this.chkSize.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSize.UncheckedState.BorderRadius = 0;
            this.chkSize.UncheckedState.BorderThickness = 0;
            this.chkSize.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSize.CheckedChanged += new System.EventHandler(this.chkSize_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 628);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 392;
            this.label4.Text = "eg. 0.00";
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
            this.btnminimize.Location = new System.Drawing.Point(993, 3);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 437;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // expcomb
            // 
            this.expcomb.BackColor = System.Drawing.Color.Transparent;
            this.expcomb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.expcomb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.expcomb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.expcomb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.expcomb.FocusedState.Parent = this.expcomb;
            this.expcomb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.expcomb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.expcomb.HoverState.Parent = this.expcomb;
            this.expcomb.ItemHeight = 30;
            this.expcomb.Items.AddRange(new object[] {
            "dd/mm/yyyy",
            "mm/yyyy"});
            this.expcomb.ItemsAppearance.Parent = this.expcomb;
            this.expcomb.Location = new System.Drawing.Point(525, 263);
            this.expcomb.Name = "expcomb";
            this.expcomb.ShadowDecoration.Parent = this.expcomb;
            this.expcomb.Size = new System.Drawing.Size(128, 36);
            this.expcomb.StartIndex = 0;
            this.expcomb.TabIndex = 438;
            this.expcomb.SelectedIndexChanged += new System.EventHandler(this.expcomb_SelectedIndexChanged);
            // 
            // ItemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.expcomb);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.chkSize);
            this.Controls.Add(this.txtexpdate);
            this.Controls.Add(this.chkExpdate);
            this.Controls.Add(this.txtmfgdate);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkItemsCategory);
            this.Controls.Add(this.chkPartyWiseItem);
            this.Controls.Add(this.chkDescription);
            this.Controls.Add(this.chkItemWiseTax);
            this.Controls.Add(this.guna2CheckBox16);
            this.Controls.Add(this.chkBarcodeScan);
            this.Controls.Add(this.chkDirectBarcodescan);
            this.Controls.Add(this.chkCustomerEnable);
            this.Controls.Add(this.cmbProductService);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbmgfdate);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.txtMRP);
            this.Controls.Add(this.chkmfgDate);
            this.Controls.Add(this.chkSerialNo);
            this.Controls.Add(this.chkBatchNo);
            this.Controls.Add(this.chkMRP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkStockMaintance);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.guna2NumericUpDown3);
            this.Controls.Add(this.chkEnableItem);
            this.Controls.Add(this.chkShowLowstockDailog);
            this.Controls.Add(this.chkItemsUnit);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemSetting";
            this.Size = new System.Drawing.Size(1066, 689);
            this.Load += new System.EventHandler(this.ItemSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2NumericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cmbmgfdate;
        private Guna.UI2.WinForms.Guna2TextBox txtSerialNo;
        private Guna.UI2.WinForms.Guna2TextBox txtBatchNo;
        private Guna.UI2.WinForms.Guna2TextBox txtMRP;
        private Guna.UI2.WinForms.Guna2CheckBox chkmfgDate;
        private Guna.UI2.WinForms.Guna2CheckBox chkSerialNo;
        private Guna.UI2.WinForms.Guna2CheckBox chkBatchNo;
        private Guna.UI2.WinForms.Guna2CheckBox chkMRP;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CheckBox chkStockMaintance;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2NumericUpDown guna2NumericUpDown3;
        private Guna.UI2.WinForms.Guna2CheckBox chkEnableItem;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowLowstockDailog;
        private Guna.UI2.WinForms.Guna2CheckBox chkItemsUnit;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProductService;
        private Guna.UI2.WinForms.Guna2CheckBox chkBarcodeScan;
        private Guna.UI2.WinForms.Guna2CheckBox chkDirectBarcodescan;
        private Guna.UI2.WinForms.Guna2CheckBox chkCustomerEnable;
        private Guna.UI2.WinForms.Guna2CheckBox chkItemsCategory;
        private Guna.UI2.WinForms.Guna2CheckBox chkPartyWiseItem;
        private Guna.UI2.WinForms.Guna2CheckBox chkDescription;
        private Guna.UI2.WinForms.Guna2CheckBox chkItemWiseTax;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox16;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2TextBox txtmfgdate;
        private Guna.UI2.WinForms.Guna2TextBox txtexpdate;
        private Guna.UI2.WinForms.Guna2CheckBox chkExpdate;
        private Guna.UI2.WinForms.Guna2TextBox txtSize;
        private Guna.UI2.WinForms.Guna2CheckBox chkSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnminimize;
        private Guna.UI2.WinForms.Guna2ComboBox expcomb;
    }
}
