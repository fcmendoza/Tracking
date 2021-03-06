﻿namespace TrackinForm {
    partial class TransactionsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lstvTransactions = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cboDateRange = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoTags = new System.Windows.Forms.RadioButton();
            this.rdoDescription = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoByYear = new System.Windows.Forms.RadioButton();
            this.rdoByMonth = new System.Windows.Forms.RadioButton();
            this.rdoByDay = new System.Windows.Forms.RadioButton();
            this.cmsPopupMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvTransactions
            // 
            this.lstvTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Description,
            this.Amount,
            this.Date,
            this.Tags});
            this.lstvTransactions.ContextMenuStrip = this.cmsPopupMenu;
            this.lstvTransactions.FullRowSelect = true;
            this.lstvTransactions.GridLines = true;
            this.lstvTransactions.Location = new System.Drawing.Point(25, 22);
            this.lstvTransactions.Name = "lstvTransactions";
            this.lstvTransactions.Size = new System.Drawing.Size(534, 247);
            this.lstvTransactions.TabIndex = 0;
            this.lstvTransactions.UseCompatibleStateImageBehavior = false;
            this.lstvTransactions.View = System.Windows.Forms.View.Details;
            this.lstvTransactions.DoubleClick += new System.EventHandler(this.lstvTransactions_DoubleClick);
            this.lstvTransactions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstvTransactions_KeyUp);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 0;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 160;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 100;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // Tags
            // 
            this.Tags.Text = "Tags";
            this.Tags.Width = 120;
            // 
            // cmsPopupMenu
            // 
            this.cmsPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTransactionToolStripMenuItem,
            this.removeTransactionToolStripMenuItem});
            this.cmsPopupMenu.Name = "cmsPopupMenu";
            this.cmsPopupMenu.Size = new System.Drawing.Size(180, 48);
            this.cmsPopupMenu.Opened += new System.EventHandler(this.cmsPopupMenu_Opened);
            // 
            // editTransactionToolStripMenuItem
            // 
            this.editTransactionToolStripMenuItem.Name = "editTransactionToolStripMenuItem";
            this.editTransactionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.editTransactionToolStripMenuItem.Text = "Edit transaction";
            // 
            // removeTransactionToolStripMenuItem
            // 
            this.removeTransactionToolStripMenuItem.Name = "removeTransactionToolStripMenuItem";
            this.removeTransactionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.removeTransactionToolStripMenuItem.Text = "Remove transaction";
            this.removeTransactionToolStripMenuItem.Click += new System.EventHandler(this.removeTransactionToolStripMenuItem_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(22, 292);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(80, 13);
            this.lblLog.TabIndex = 13;
            this.lblLog.Text = "Transaction log";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtLog.Location = new System.Drawing.Point(22, 308);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(537, 227);
            this.txtLog.TabIndex = 12;
            this.txtLog.TabStop = false;
            // 
            // cboDateRange
            // 
            this.cboDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateRange.FormattingEnabled = true;
            this.cboDateRange.Location = new System.Drawing.Point(572, 22);
            this.cboDateRange.Name = "cboDateRange";
            this.cboDateRange.Size = new System.Drawing.Size(121, 21);
            this.cboDateRange.TabIndex = 1;
            this.cboDateRange.SelectedIndexChanged += new System.EventHandler(this.cboDateRange_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(572, 82);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(121, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Search:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total Amount:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(438, 279);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(121, 20);
            this.txtTotalAmount.TabIndex = 15;
            this.txtTotalAmount.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoTags);
            this.panel1.Controls.Add(this.rdoDescription);
            this.panel1.Controls.Add(this.rdoAll);
            this.panel1.Location = new System.Drawing.Point(568, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 36);
            this.panel1.TabIndex = 16;
            // 
            // rdoTags
            // 
            this.rdoTags.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoTags.AutoSize = true;
            this.rdoTags.Location = new System.Drawing.Point(100, 6);
            this.rdoTags.Name = "rdoTags";
            this.rdoTags.Size = new System.Drawing.Size(41, 23);
            this.rdoTags.TabIndex = 2;
            this.rdoTags.TabStop = true;
            this.rdoTags.Text = "Tags";
            this.rdoTags.UseVisualStyleBackColor = true;
            this.rdoTags.CheckedChanged += new System.EventHandler(this.rdoTags_CheckedChanged);
            // 
            // rdoDescription
            // 
            this.rdoDescription.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDescription.AutoSize = true;
            this.rdoDescription.Location = new System.Drawing.Point(31, 6);
            this.rdoDescription.Name = "rdoDescription";
            this.rdoDescription.Size = new System.Drawing.Size(70, 23);
            this.rdoDescription.TabIndex = 1;
            this.rdoDescription.TabStop = true;
            this.rdoDescription.Text = "Description";
            this.rdoDescription.UseVisualStyleBackColor = true;
            this.rdoDescription.CheckedChanged += new System.EventHandler(this.rdoDescription_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(4, 6);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(28, 23);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Image = ((System.Drawing.Image)(resources.GetObject("btnClearLog.Image")));
            this.btnClearLog.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnClearLog.Location = new System.Drawing.Point(103, 285);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(25, 23);
            this.btnClearLog.TabIndex = 17;
            this.btnClearLog.TabStop = false;
            this.btnClearLog.Text = "&C";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(568, 235);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(544, 300);
            this.chart1.TabIndex = 18;
            this.chart1.TabStop = false;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoByYear);
            this.panel2.Controls.Add(this.rdoByMonth);
            this.panel2.Controls.Add(this.rdoByDay);
            this.panel2.Location = new System.Drawing.Point(776, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 36);
            this.panel2.TabIndex = 19;
            // 
            // rdoByYear
            // 
            this.rdoByYear.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoByYear.AutoSize = true;
            this.rdoByYear.Location = new System.Drawing.Point(115, 6);
            this.rdoByYear.Name = "rdoByYear";
            this.rdoByYear.Size = new System.Drawing.Size(54, 23);
            this.rdoByYear.TabIndex = 2;
            this.rdoByYear.TabStop = true;
            this.rdoByYear.Text = "By Year";
            this.rdoByYear.UseVisualStyleBackColor = true;
            this.rdoByYear.CheckedChanged += new System.EventHandler(this.rdoByYear_CheckedChanged);
            // 
            // rdoByMonth
            // 
            this.rdoByMonth.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoByMonth.AutoSize = true;
            this.rdoByMonth.Location = new System.Drawing.Point(54, 6);
            this.rdoByMonth.Name = "rdoByMonth";
            this.rdoByMonth.Size = new System.Drawing.Size(62, 23);
            this.rdoByMonth.TabIndex = 1;
            this.rdoByMonth.TabStop = true;
            this.rdoByMonth.Text = "By Month";
            this.rdoByMonth.UseVisualStyleBackColor = true;
            this.rdoByMonth.CheckedChanged += new System.EventHandler(this.rdoByMonth_CheckedChanged);
            // 
            // rdoByDay
            // 
            this.rdoByDay.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoByDay.AutoSize = true;
            this.rdoByDay.Location = new System.Drawing.Point(4, 6);
            this.rdoByDay.Name = "rdoByDay";
            this.rdoByDay.Size = new System.Drawing.Size(51, 23);
            this.rdoByDay.TabIndex = 0;
            this.rdoByDay.TabStop = true;
            this.rdoByDay.Text = "By Day";
            this.rdoByDay.UseVisualStyleBackColor = true;
            this.rdoByDay.CheckedChanged += new System.EventHandler(this.rdoByDay_CheckedChanged);
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cboDateRange);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lstvTransactions);
            this.Name = "TransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            this.Shown += new System.EventHandler(this.TransactionsForm_Shown);
            this.cmsPopupMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstvTransactions;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Tags;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ComboBox cboDateRange;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoTags;
        private System.Windows.Forms.RadioButton rdoDescription;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ContextMenuStrip cmsPopupMenu;
        private System.Windows.Forms.ToolStripMenuItem editTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTransactionToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoByYear;
        private System.Windows.Forms.RadioButton rdoByMonth;
        private System.Windows.Forms.RadioButton rdoByDay;
    }
}