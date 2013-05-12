namespace TrackinForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsForm));
            this.lstvTransactions = new System.Windows.Forms.ListView();
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvTransactions
            // 
            this.lstvTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Description,
            this.Amount,
            this.Date,
            this.Tags});
            this.lstvTransactions.FullRowSelect = true;
            this.lstvTransactions.GridLines = true;
            this.lstvTransactions.Location = new System.Drawing.Point(25, 22);
            this.lstvTransactions.Name = "lstvTransactions";
            this.lstvTransactions.Size = new System.Drawing.Size(534, 247);
            this.lstvTransactions.TabIndex = 0;
            this.lstvTransactions.UseCompatibleStateImageBehavior = false;
            this.lstvTransactions.View = System.Windows.Forms.View.Details;
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
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 562);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}