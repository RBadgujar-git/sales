﻿namespace sample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllTransactionSearch));
            this.btnsearch = new System.Windows.Forms.Button();
            this.dtpdatefrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpdateto = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgvalltransactionserach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.closebtn = new System.Windows.Forms.Button();
            this.btnminimize = new System.Windows.Forms.Button();
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
            this.dtpdateto.ValueChanged += new System.EventHandler(this.dtpdateto_ValueChanged);
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
            this.dgvalltransactionserach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvalltransactionserach_CellContentClick);
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.White;
            this.closebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closebtn.BackgroundImage")));
            this.closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closebtn.Location = new System.Drawing.Point(807, 12);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(26, 27);
            this.closebtn.TabIndex = 434;
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
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
            this.btnminimize.Location = new System.Drawing.Point(775, 12);
            this.btnminimize.Name = "btnminimize";
            this.btnminimize.Size = new System.Drawing.Size(26, 27);
            this.btnminimize.TabIndex = 435;
            this.btnminimize.UseVisualStyleBackColor = false;
            this.btnminimize.Visible = false;
            this.btnminimize.Click += new System.EventHandler(this.btnminimize_Click);
            // 
            // AllTransactionSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnminimize);
            this.Controls.Add(this.closebtn);
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
            this.Load += new System.EventHandler(this.AllTransactionSearch_Load);
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
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button btnminimize;
    }
}
