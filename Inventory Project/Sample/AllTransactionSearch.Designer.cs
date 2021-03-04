namespace sample
{
    partial class AllTransactionSearch
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
            this.btnsearch = new System.Windows.Forms.Button();
            this.dtpdatefrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpdateto = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgvalltransactionserach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvalltransactionserach)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnsearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsearch.Location = new System.Drawing.Point(387, 40);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(118, 42);
            this.btnsearch.TabIndex = 12;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            // 
            // dtpdatefrom
            // 
            this.dtpdatefrom.BorderThickness = 1;
            this.dtpdatefrom.CheckedState.Parent = this.dtpdatefrom;
            this.dtpdatefrom.FillColor = System.Drawing.Color.White;
            this.dtpdatefrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdatefrom.HoverState.Parent = this.dtpdatefrom;
            this.dtpdatefrom.Location = new System.Drawing.Point(51, 49);
            this.dtpdatefrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpdatefrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpdatefrom.Name = "dtpdatefrom";
            this.dtpdatefrom.ShadowDecoration.Parent = this.dtpdatefrom;
            this.dtpdatefrom.Size = new System.Drawing.Size(133, 25);
            this.dtpdatefrom.TabIndex = 15;
            this.dtpdatefrom.Value = new System.DateTime(2020, 10, 19, 18, 54, 42, 36);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "To ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dtpdateto
            // 
            this.dtpdateto.BorderThickness = 1;
            this.dtpdateto.CheckedState.Parent = this.dtpdateto;
            this.dtpdateto.FillColor = System.Drawing.Color.White;
            this.dtpdateto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpdateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdateto.HoverState.Parent = this.dtpdateto;
            this.dtpdateto.Location = new System.Drawing.Point(227, 49);
            this.dtpdateto.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpdateto.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpdateto.Name = "dtpdateto";
            this.dtpdateto.ShadowDecoration.Parent = this.dtpdateto;
            this.dtpdateto.Size = new System.Drawing.Size(133, 25);
            this.dtpdateto.TabIndex = 16;
            this.dtpdateto.Value = new System.DateTime(2020, 10, 19, 18, 54, 42, 36);
            // 
            // dgvalltransactionserach
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvalltransactionserach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvalltransactionserach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvalltransactionserach.BackgroundColor = System.Drawing.Color.White;
            this.dgvalltransactionserach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvalltransactionserach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvalltransactionserach.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvalltransactionserach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvalltransactionserach.ColumnHeadersHeight = 18;
            this.dgvalltransactionserach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column2,
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvalltransactionserach.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvalltransactionserach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvalltransactionserach.EnableHeadersVisualStyles = false;
            this.dgvalltransactionserach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvalltransactionserach.Location = new System.Drawing.Point(0, 106);
            this.dgvalltransactionserach.Name = "dgvalltransactionserach";
            this.dgvalltransactionserach.RowHeadersVisible = false;
            this.dgvalltransactionserach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvalltransactionserach.Size = new System.Drawing.Size(845, 453);
            this.dgvalltransactionserach.TabIndex = 17;
            this.dgvalltransactionserach.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvalltransactionserach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvalltransactionserach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvalltransactionserach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvalltransactionserach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvalltransactionserach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvalltransactionserach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvalltransactionserach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvalltransactionserach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvalltransactionserach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvalltransactionserach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvalltransactionserach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvalltransactionserach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvalltransactionserach.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvalltransactionserach.ThemeStyle.ReadOnly = false;
            this.dgvalltransactionserach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvalltransactionserach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvalltransactionserach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvalltransactionserach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvalltransactionserach.ThemeStyle.RowsStyle.Height = 22;
            this.dgvalltransactionserach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvalltransactionserach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Type";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ref No";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Total";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Received/Paid";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Balance";
            this.Column6.Name = "Column6";
            // 
            // AllTransactionSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvalltransactionserach);
            this.Controls.Add(this.dtpdateto);
            this.Controls.Add(this.dtpdatefrom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnsearch);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllTransactionSearch";
            this.Size = new System.Drawing.Size(845, 559);
            ((System.ComponentModel.ISupportInitialize)(this.dgvalltransactionserach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsearch;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpdatefrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpdateto;
        private Guna.UI2.WinForms.Guna2DataGridView dgvalltransactionserach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
