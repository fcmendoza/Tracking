using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackinForm {
    public partial class TransactionsForm : Form {
        public TransactionsForm(ITransactionRepository repo) {
            _repo = repo;
            InitializeComponent();
        }
        public TransactionsForm() {
            InitializeComponent();
        }

        private void TransactionsForm_Load(object sender, EventArgs e) {
            //var item = lstvTransactions.Items.Add("Lorem ipsum");
            //item.SubItems.Add("-100");
            //item.SubItems.Add("2013-01-01");
            //item.SubItems.Add("food");
        }

        private void TransactionsForm_Shown(object sender, EventArgs e) {
            var from = new DateTime(2013, 01, 01);
            var to = new DateTime(2013, 12, 31);

            LogInfo(String.Format("Retrieving transactions from web server (from {0:yyyy-MM-dd} to {1:yyyy-MM-dd}) ...", from, to));

            var transactions = _repo.GetTransactions(from, to);
            transactions = transactions.OrderBy(t => t.Date).ThenBy(t => t.ID);

            foreach (var tran in transactions) {
                var item = lstvTransactions.Items.Add(tran.Description);
                item.SubItems.Add(String.Format("{0:N}", tran.Amount));
                item.SubItems.Add(String.Format("{0:yyyy-MM-dd}", tran.Date));
                item.SubItems.Add(String.Join(" ", tran.Tags));
            }

            LogInfo(String.Format("{0} transactions were retrieved.", transactions.Count()));
        }

        private void LogInfo(string message) {
            txtLog.AppendText(txtLog.Text.Length > 0 ? "\r\n\r" : string.Empty);
            txtLog.AppendText(String.Format("{0:yyyy-MM-dd hh:mm:ss}: {1}", DateTime.Now, message));
        }

        ITransactionRepository _repo;
    }
}
