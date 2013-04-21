using System;
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

        private void btnAdd_Click(object sender, EventArgs e) {
            LogInfo("Adding transaction...");

            string errorMessage = null;

            var transaction = new Transaction {
                Description = txtDescription.Text.Trim(),
                Amount = nudAmount.Value,
                Date = dtpDate.Value,
                Tags = txtTags.Text.Trim().Split(' ')
            };

            try {
                bool success = _repo.InsertTransaction(transaction, out errorMessage);
                LogInfo(success ? "Transaction successfully added" : "Transaction failed. Error message: " + errorMessage);
            } 
            catch (Exception ex) {
                LogInfo("An unexpected error ocurred. Exception Message: " + ex.Message);
            }
            
        }

        ITransactionRepository _repo;

        private void TransactionForm_Load(object sender, EventArgs e) {
            btnAdd.Enabled = false;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e) {
            btnAdd.Enabled = IsEnabledAddButton();
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e) {
            btnAdd.Enabled = IsEnabledAddButton();
        }

        private void txtTags_TextChanged(object sender, EventArgs e) {
            btnAdd.Enabled = IsEnabledAddButton();
        }

        private bool IsEnabledAddButton() {
            return !String.IsNullOrWhiteSpace(txtDescription.Text) && nudAmount.Value != 0 && !String.IsNullOrWhiteSpace(txtTags.Text);
        }

        private void LogInfo(string message) {
            txtLog.AppendText(txtLog.Text.Length > 0 ? "\n" : string.Empty);
            txtLog.AppendText(String.Format("{0:yyyy-MM-dd hh:mm:ss}: {1}", DateTime.Now, message));
        }

    }
}
