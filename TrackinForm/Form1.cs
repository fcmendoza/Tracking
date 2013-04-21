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
            var transaction = new Transaction();
            transaction.Description = txtDescription.Text;
            transaction.Amount = decimal.Parse(txtAmount.Text);
            transaction.Date = dtpDate.Value;
            transaction.Tags = txtTags.Text.Split(' ');

            _repo.InsertTransaction(transaction);
        }

        ITransactionRepository _repo;
    }
}
