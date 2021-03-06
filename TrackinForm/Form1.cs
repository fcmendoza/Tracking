﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackinForm {
    public partial class TransactionForm : Form {
        public TransactionForm() {
            InitializeComponent();
            _repo = new TransactionRepository();
        }

        public TransactionForm(Transaction transaction) {
            InitializeComponent();
            _repo = new TransactionRepository();
            _transaction = transaction;
            _isEditMode = transaction != null;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            LogInfo(_isEditMode ? "Updating transaction..." : "Adding transaction...");

            string errorMessage = null;

            var transaction = new Transaction {
                ID = _isEditMode ? _transaction.ID : 0,
                Description = txtDescription.Text.Trim(),
                Amount = nudAmount.Value,
                Date = dtpDate.Value,
                Tags = cboTags.Text.Trim().Split(' ')
            };

            try {
                bool success = _isEditMode
                    ? _repo.EditTransaction(transaction, out errorMessage)
                    : _repo.InsertTransaction(transaction, out errorMessage);

                string parameters = String.Format("'{0}', {1:N}, {2:yyyy-MM-dd}, '{3}'", transaction.Description, transaction.Amount, transaction.Date, String.Join(" ", transaction.Tags));
                LogInfo(success 
                    ? String.Format("Transaction successfully {1} ({0}).", parameters, _isEditMode ? "updated" : "added") 
                    : String.Format("Transaction failed ({0}). Error message: {1}", parameters, errorMessage));

                SetControls();
            } 
            catch (Exception ex) {
                LogInfo("An unexpected error ocurred. Exception Message: " + ex.Message);
            }
        }

        private void SetControls() {
            txtDescription.Clear();
            nudAmount.Value = 0;
            txtDescription.Focus();
        }

        private void TransactionForm_Load(object sender, EventArgs e) {
            btnAdd.Enabled = false;
            btnUpdateAndClose.Visible = _isEditMode;
            if (_transaction != null) {
                var transaction = _repo.GetTransaction(_transaction);

                this.Text = String.Format("Edit transaction (ID: {0})", transaction.ID);
                this.txtDescription.Text = transaction.Description;
                this.nudAmount.Value = transaction.Amount;
                this.dtpDate.Value = transaction.Date;
                this.cboTags.Text = transaction.TagsJoined;

                this.btnAdd.Text = "Update";
            }
        }
        private void txtDescription_TextChanged(object sender, EventArgs e) {
            btnAdd.Enabled = IsEnabledAddButton();
            btnUpdateAndClose.Enabled = IsEnabledAddButton();
        }
        private void nudAmount_ValueChanged(object sender, EventArgs e) {
            btnAdd.Enabled = IsEnabledAddButton();
            btnUpdateAndClose.Enabled = IsEnabledAddButton();
        }
        private void cboTags_SelectedIndexChanged(object sender, EventArgs e) {
            btnAdd.Enabled = IsEnabledAddButton();
            btnUpdateAndClose.Enabled = IsEnabledAddButton();
        }
        private void cboTags_TextChanged(object sender, EventArgs e) {
            btnAdd.Enabled = IsEnabledAddButton();
            btnUpdateAndClose.Enabled = IsEnabledAddButton();
        }
        private bool IsEnabledAddButton() {
            return !String.IsNullOrWhiteSpace(txtDescription.Text) && nudAmount.Value != 0 && !String.IsNullOrWhiteSpace(cboTags.Text);
        }

        private void txtDescription_Enter(object sender, EventArgs e) {
            txtDescription.SelectAll();
        }
        private void nudAmount_Enter(object sender, EventArgs e) {
            nudAmount.Select(0, nudAmount.Value.ToString().Length + 3);
        }
        private void dtpDate_Enter(object sender, EventArgs e) {
            SendKeys.Send("{RIGHT 1}");
        }

        private void label5_Click(object sender, EventArgs e) {
            cboTags.Text = ((Label)sender).Text;
        }
        private void label6_Click(object sender, EventArgs e) {
            cboTags.Text = ((Label)sender).Text;
        }
        private void label7_Click(object sender, EventArgs e) {
            cboTags.Text = ((Label)sender).Text;
        }
        private void label8_Click(object sender, EventArgs e) {
            cboTags.Text = ((Label)sender).Text;
        }

        private void btnViewTransactions_Click(object sender, EventArgs e) {
            var transactions = new TransactionsForm(_repo);
            transactions.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void btnUpdateAndClose_Click(object sender, EventArgs e) {
            btnAdd_Click(sender, e);
            this.Close();
        }

        private void LogInfo(string message) {
            txtLog.AppendText(txtLog.Text.Length > 0 ? "\r\n\r" : string.Empty);
            txtLog.AppendText(String.Format("{0:yyyy-MM-dd hh:mm:ss}: {1}", DateTime.Now, message));
        }

        ITransactionRepository _repo;
        Transaction _transaction;
        bool _isEditMode;
    }
}
