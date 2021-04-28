namespace sample
{
    partial class CreditNothomePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditNothomePage));
            this.btnCredit = new Guna.UI2.WinForms.Guna2Button();
            this.dgvcreditNote = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btncalcel = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.btnminimize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcreditNote)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCredit
            // 
            this.btnCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCredit.CheckedState.Parent = this.btnCredit;
            this.btnCredit.CustomImages.Parent = this.btnCredit;
            this.btnCredit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredit.ForeColor = System.Drawing.Color.White;
            this.btnCredit.HoverState.Parent = this.btnCredit;
            this.btnCredit.Location = new System.Drawing.Point(882, 100);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.ShadowDecoration.Parent = this.btnCredit;
            this.btnCredit.Size = new System.Drawing.Size(145, 45);
            this.btnCredit.TabIndex = 202;
            this.btnCredit.Text = "Add Credit note";
            this.btnCredit.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // dgvcreditNote
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvcreditNote.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcreditNote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcreditNote.BackgroundColor = System.Drawing.Color.White;
            this.dgvcreditNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvcreditNote.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvcreditNote.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcreditNote.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcreditNote.ColumnHeadersHeight = 18;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcreditNote.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcreditNote.EnableHeadersVisualStyles = false;
            this.dgvcreditNote.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvcreditNote.Location = new System.Drawing.Point(0, 161);
            this.dgvcreditNote.Name = "dgvcreditNote";
            this.dgvcreditNote.RowHeadersVisible = false;
            this.dgvcreditNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcreditNote.Size = new System.Drawing.Size(1071, 455);
            this.dgvcreditNote.TabIndex = 201;
            this.dgvcreditNote.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvcreditNote.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvcreditNote.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvcreditNote.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvcreditNote.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvcreditNote.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvcreditNote.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvcreditNote.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvcreditNote.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvcreditNote.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvcreditNote.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvcreditNote.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvcreditNote.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvcreditNote.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvcreditNote.ThemeStyle.ReadOnly = false;
            this.dgvcreditNote.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvcreditNote.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvcreditNote.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvcreditNote.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvcreditNote.ThemeStyle.RowsStyle.Height = 22;
            this.dgvcreditNote.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvcreditNote.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvcreditNote.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcreditNote_CellContentClick);
            // 
            // btncalcel
            // 
            this.btncalcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncalcel.BackColor = System.Drawing.Color.White;
            this.btncalcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncalcel.BackgroundImage")));
            this.btncalcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncalcel.FlatAppearance.BorderSize = 0;
            this.btncalcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncalcel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncalcel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncalcel.Location = new System.Drawing.Point(993, 6);
            this.btncalcel.Name = "btncalcel";
            this.btncalcel.Size = new System.Drawing.Size(28, 26);
            this.btncalcel.TabIndex = 199;
            this.btncalcel.UseVisualStyleBackColor = false;
            this.btncalcel.Click += new System.EventHandler(this.btncalcel_Click);
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.BackColor = System.Drawing.Color.Transparent;
            this.btnprint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnprint.BackgroundImage")));
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Location = new System.Drawing.Point(993, 41);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(25, 25);
            this.btnprint.TabIndex = 198;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnimport
            // 
            this.btnimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnimport.BackColor = System.Drawing.Color.Transparent;
            this.btnimport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnimport.BackgroundImage")));
            this.btnimport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnimport.FlatAppearance.BorderSize = 0;
            this.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimport.Location = new System.Drawing.Point(933, 49);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(22, 23);
            this.btnimport.TabIndex = 197;
            this.btnimport.UseVisualStyleBackColor = false;
            this.btnimport.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 204;
            this.label1.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(398, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 16);
            this.label5.TabIndex = 206;
            this.label5.Text = "To";
            // 
            // txtfilter
            // 
            this.txtfilter.BorderColor = System.Drawing.Color.Gray;
            this.txtfilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfilter.DefaultText = "";
            this.txtfilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtfilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtfilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfilter.DisabledState.Parent = this.txtfilter;
            this.txtfilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfilter.FocusedState.Parent = this.txtfilter;
            this.txtfilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtfilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtfilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfilter.HoverState.Parent = this.txtfilter;
            this.txtfilter.Location = new System.Drawing.Point(132, 116);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.PasswordChar = '\0';
            this.txtfilter.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtfilter.PlaceholderText = "Party Name";
            this.txtfilter.SelectedText = "";
            this.txtfilter.ShadowDecoration.Parent = this.txtfilter;
            this.txtfilter.Size = new System.Drawing.Size(203, 27);
            this.txtfilter.TabIndex = 208;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 207;
            this.label3.Text = " Filter by :";
            // 
            // dtpfrom
            // 
            this.dtpfrom.CustomFormat = "MM/dd/yyyy";
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom.Location = new System.Drawing.Point(242, 42);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(150, 23);
            this.dtpfrom.TabIndex = 210;
            // 
            // dtpto
            // 
            this.dtpto.CustomFormat = "MM/dd/yyyy";
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpto.Location = new System.Drawing.Point(428, 42);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(155, 23);
            this.dtpto.TabIndex = 211;
            this.dtpto.ValueChanged += new System.EventHandler(this.dtpto_ValueChanged);
            this.dtpto.Enter += new System.EventHandler(this.dtpto_Enter);
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
            this.btnminimize.Location = new System.Drawing.Point(933, 6);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 437;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 438;
            this.label2.Text = "All Transaction";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1018, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 439;
            this.label4.Text = "Print";
            // 
            // CreditNothomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrom);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCredit);
            this.Controls.Add(this.dgvcreditNote);
            this.Controls.Add(this.btncalcel);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnimport);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreditNothomePage";
            this.Size = new System.Drawing.Size(1071, 616);
            this.Load += new System.EventHandler(this.CreditNothomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcreditNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCredit;
        private Guna.UI2.WinForms.Guna2DataGridView dgvcreditNote;
        private System.Windows.Forms.Button btncalcel;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtfilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Button btnminimize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}
